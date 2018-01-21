using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.Common;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class GoodsConfig : System.Web.UI.Page
    {
        string id = DTRequest.GetQueryString("id");//组合商品id
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(!IsPostBack){
                Bindlist(); 
                sel_group_name();
            }
            
        }
        private int _productId=0;
        protected int ProductId
        {
            get
            {
                if (_productId == 0)
                {
                    _productId = DTRequest.GetQueryString("id").ObjToInt(0);
                }
                return _productId;
            }
            set { 
            }
        }
        protected void Bindlist() {

            DataTable dtb = comfun.GetDataTableBySQL("select 组名, 商品组合id as 商品id, 主商品id, 数量, 品名, 规格, 单位, 重量 from 视图商品组 where 1=1 and IsShow=1  and 商品组合id="+id);
            sptList1.DataSource = dtb;
            sptList1.DataBind();
        
        }

  


        //给telerik控件绑定数据
        protected void sel_group_name() {
            //var dt = DbHelperSQL.Query("select 品名,id from WP_商品表 where IsShow=1 ");
            var dt = DbHelperSQL.Query(@" select id,图片路径,编号new,编号,品名,类别,单位,规格,重量,市场价,本站价,库存数量,限购数量,分销率,折扣率,是否卖家承担运费,上架时间,下架时间,IsShow,是否上架 from 视图商品信息表 where 1=1 and IsShow=1 ");
            group_name.DataSource = dt;
            group_name.DataBind();
        }


    //添加
        protected void save_combo(object sender, EventArgs e)
        {
            
            string goods_id= group_name.SelectedValue ;//获取当前的value(id)
            comfun.InsertBySQL("insert into WP_商品表组(商品组合id,商品id,数量,IsShow)values(" + id + "," + goods_id + ",1,1)");
            Bindlist();
        }

        //更改数量
        //protected void update_combo(object sender, EventArgs e)
        //{
        //    string all_vals=Bindlist_hidd.Value;
        //    string all_ids = all_id.Value;
            
        //    string[] one_val=all_vals.Split(',');
        //    string[] one_id = all_ids.Split(',');

        //    for (int i = 0; i < one_id.Length - 1;i++ )
        //    {
        //        comfun.UpdateBySQL("update WP_商品表组 set 数量="+one_val[i]+" where 商品id="+one_id[i]);
        //    }

        //}
        protected void num_TextChanged(object sender, EventArgs e)
        {
            var obj = sender as TextBox;//当前数量值
            string number=obj.Text;
            var sub_product_id = obj.Attributes["product-id"].ObjToInt(0);//商品id
            GoodsConfig gc = new GoodsConfig();
            var combo_id = gc.ProductId;//商品组合id
            string sql = "update WP_商品表组 set 数量=" + number + " where 商品组合id=" + combo_id + " and 商品id=" + sub_product_id;
            comfun.UpdateBySQL(sql);
          
        }

        //删除某一样商品
        protected void del_goods(object sender, EventArgs e)
        {
            for (int i = 0; i < sptList1.Items.Count; i++)
            {
                int opt_for_id = Convert.ToInt32(((HiddenField)sptList1.Items[i].FindControl("hidId")).Value);//选中的id
                CheckBox cb = (CheckBox)sptList1.Items[i].FindControl("chkId");//选中的按钮
                if (cb.Checked)
                {
                    string del_sql = @"update WP_商品表组 set IsShow=0 where 商品组合id=" + id + " and 商品id=" + opt_for_id;
                    comfun.UpdateBySQL(del_sql);
                }
            }
            Bindlist();
        }


    }
}