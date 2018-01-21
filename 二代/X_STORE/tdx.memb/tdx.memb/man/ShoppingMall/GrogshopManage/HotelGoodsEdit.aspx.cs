using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using Creatrue.Common.Msgbox;

namespace tdx.memb.man.ShoppingMall.GrogshopManage
{
    public partial class HotelGoodsEdit : System.Web.UI.Page
    {
        string hotel_id = DTRequest.GetQueryString("hotel_id").ObjToStr();//获取酒店的id
        protected void Page_Load(object sender, EventArgs e)
            {
               
                if(!IsPostBack){
                    sel_shop();
            }
        }

        //查找所有的商品
        protected void  sel_shop() {
            string shop_sql = @"select 品名,id as goods_id,规格,单位,重量 from 视图商品信息表 where IsShow=1 ";
            DataTable dt=comfun.GetDataTableBySQL(shop_sql);
            //PagedDataSource pdsList = new PagedDataSource();
            //pdsList.DataSource = dt.DefaultView;
            //pdsList.AllowPaging = true;//数据源允许分页
            //pdsList.PageSize = 10;//取控件的分页大小
            //pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            ////设置控件
            //this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数

            rp_hotel_goods.DataSource = dt;
            rp_hotel_goods.DataBind();
        }

       

        //点击保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string hotel_goods="";
            for (int i = 0; i < rp_hotel_goods.Items.Count; i++)
            {
                int goods_id = Convert.ToInt32(((HiddenField)rp_hotel_goods.Items[i].FindControl("hidId")).Value);//商品id
                CheckBox cb = (CheckBox)rp_hotel_goods.Items[i].FindControl("chkId");
                //查看商品是否有
                DataTable dt = comfun.GetDataTableBySQL(@"select id from WP_酒店商品 where  仓库id=" + hotel_id + " and 商品id=" + goods_id);
                string zk = ((TextBox)cb.Parent.Parent.FindControl("zhekou")).Text.ObjToStr();//折扣
                string min = ((TextBox)cb.Parent.Parent.FindControl("min_repertory")).Text.ObjToStr();//最小库存
                string max = ((TextBox)cb.Parent.Parent.FindControl("max_repertory")).Text.ObjToStr();//最大库存
                if (cb.Checked)//现在选中
                {
                   
                    if (zk == "") {
                        MessageBox.Show(this, "折扣不能为空！"); return;
                    }if(min==""){
                        MessageBox.Show(this, "最小库存不能为空！"); return;
                    } if (max == "")
                    {
                        MessageBox.Show(this, "最大库存不能为空！"); return;
                    }

                    if (dt.Rows.Count > 0)//当前选中的商品在酒店中有
                    {//更新
                        hotel_goods = @"update WP_酒店商品 set 折扣=" + zk + ",最小库存="+min+",最大库存="+max+",IsShow=1 where 仓库id=" + hotel_id;
                        comfun.UpdateBySQL(hotel_goods);
                    }
                    else
                    {//没有就插入
                        hotel_goods = @"insert into WP_酒店商品(仓库id,商品id,折扣,最小库存,最大库存)values(" + hotel_id + "," + goods_id + "," + zk + ","+min+","+max+")";
                        comfun.InsertBySQL(hotel_goods);
                    }
                    
                }
                else { //现在未选中
                       if(dt.Rows.Count>0){
                           string del_sql = @"update WP_酒店商品 set IsShow=0 WHERE 商品id = "+goods_id+" and 仓库id="+hotel_id;
                           comfun.UpdateBySQL(del_sql);        
                       } 
                }
             
            }
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='HotelGoodsList.aspx'", true);
           
        }

        //绑定选中数据
        protected void rp_hotel_goods_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string decide_sql = @"select 商品id ,折扣,最小库存,最大库存 from WP_酒店商品 a left join WP_商品表 b on a.商品id=b.id where a.IsShow=1 and b.IsShow=1 and 仓库id=" + hotel_id;
            DataTable dt = comfun.GetDataTableBySQL(decide_sql);//查出酒店有哪些些商品
            int j = 0;
            CheckBox cb = (CheckBox)e.Item.FindControl("chkId");//选中状态
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["商品id"]) == Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value))
                    {
                        cb.Checked = true;
                        ((TextBox)cb.Parent.Parent.FindControl("zhekou")).Text = dt.Rows[j]["折扣"].ObjToStr();//
                        ((TextBox)cb.Parent.Parent.FindControl("min_repertory")).Text = dt.Rows[j]["最小库存"].ObjToStr();//
                        ((TextBox)cb.Parent.Parent.FindControl("max_repertory")).Text = dt.Rows[j]["最大库存"].ObjToStr();//
                        j++;
                    }
                    
                }
            }
        }



    }
}