using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.manager
{
    public partial class WX_user_hotel_manage : System.Web.UI.Page
    {
        string id = DTRequest.GetQueryString("id").ObjToStr();//用户id
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                sel_hotel();
            }
        }

        //查询所有仓库
        protected void sel_hotel() {
            string hotel_sql = @"select c.id as id,c.仓库名 as 仓库 from WP_地区表 a left join WP_酒店表 b on a.id=b.区域id left join WP_仓库表 c on b.id=c.酒店id where c.id is not null and b.IsShow=1 and c.IsShow=1 ";
            DataTable dt=comfun.GetDataTableBySQL(hotel_sql);
            rp_hotel.DataSource = dt;
            rp_hotel.DataBind();
        }

        //绑定选中数据
        protected void rp_hotel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string decide_sql = @"select 仓库id from WP_用户仓库 where IsShow=1 and 用户id="+id;
            DataTable dt = comfun.GetDataTableBySQL(decide_sql);//查出用户绑定的酒店
            CheckBox cb = (CheckBox)e.Item.FindControl("chkId");//选中状态
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["仓库id"]) == Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value))
                    {
                        cb.Checked = true;
                    }

                }
            }
        }

        //点击保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string hotel_goods = "";
            int flag = 0;
            for (int i = 0; i < rp_hotel.Items.Count; i++)
            {
                int ck_id = Convert.ToInt32(((HiddenField)rp_hotel.Items[i].FindControl("hidId")).Value);//酒店id
                CheckBox cb = (CheckBox)rp_hotel.Items[i].FindControl("chkId");
                //查看商品是否有
                DataTable dt = comfun.GetDataTableBySQL(@"select id from WP_用户仓库 where 用户id=" + id + " and 仓库id=" + ck_id);
                if (cb.Checked)//现在选中
                {
                    if (dt.Rows.Count == 0)//当前选中的酒店在此人属性中没有
                    {//没有就插入
                        hotel_goods = @"insert into WP_用户仓库(用户id,仓库id) values(" + id + "," + ck_id + ")";
                        flag = comfun.InsertBySQL(hotel_goods);
                    }
                    else {//有就更新状态 
                        string del_sql = @"update WP_用户仓库 set IsShow=1 where 用户id=" + id + " and 仓库id =" + ck_id;
                        flag = comfun.UpdateBySQL(del_sql);
                    }

                }
                else
                { //现在未选中
                    if (dt.Rows.Count > 0)//有，就更新
                    {
                        string del_sql = @"update WP_用户仓库 set IsShow=0 where 用户id=" + id + " and 仓库id =" + ck_id;
                    flag=comfun.UpdateBySQL(del_sql);
                    }
                }

            }
            if (flag > 0)
            {
                MessageBox.ShowAndRedirect(this, "操作成功！", "WX_users.aspx");
            }
            else {
                MessageBox.Show(this,"操作失败！");
                return;
            }
            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='HotelGoodsList.aspx'", true);

        }

    }
}