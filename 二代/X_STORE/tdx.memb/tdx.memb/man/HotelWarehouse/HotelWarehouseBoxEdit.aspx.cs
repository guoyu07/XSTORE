using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using DTcms.DBUtility;
using DTcms.Common;
using System.Text;
using System.Data.SqlClient;
using Wuqi.Webdiyer;

namespace tdx.memb.man.HotelWarehouse
{
    public partial class HotelWarehouseBoxEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                area(id); 
                selected(id);
            }
        }
        private void selected(int id)
        {
            string sql1 = "select 仓库id,库位名,箱子MAC from WP_库位表 where id='" + id + "'";
            DataTable dt1 = comfun.GetDataTableBySQL(sql1);
            if (dt1.Rows[0]["仓库id"].ObjToStr() != null)
            {
                string sql2 = "select 酒店id,仓库名 from WP_仓库表 where id='" + dt1.Rows[0]["仓库id"].ObjToStr() + "'";
                DataTable dt2 = comfun.GetDataTableBySQL(sql2);
                string sql3 = "select 区域id from WP_酒店表 where id='" + dt2.Rows[0]["酒店id"].ObjToStr() + "'";
                DataTable dt3 = comfun.GetDataTableBySQL(sql3);
                string sql4 = "select 父级id from WP_地区表 where id='" + dt3.Rows[0]["区域id"].ObjToStr() + "'";
                DataTable dt4 = comfun.GetDataTableBySQL(sql4);
                ddl_hotel.SelectedValue= dt2.Rows[0]["酒店id"].ObjToStr();
               // ddl_shi.SelectedValue = dt3.Rows[0]["区域id"].ObjToStr();
                ddl_shen.SelectedValue = dt4.Rows[0]["父级id"].ObjToStr();
                ddl_warehouse.SelectedValue=dt1.Rows[0]["仓库id"].ObjToStr();
                txtkw.Value = dt1.Rows[0]["库位名"].ObjToStr();
                txt_mac.Text=dt1.Rows[0]["箱子MAC"].ObjToStr();
            }

        }
        #region--插入仓库--
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            int s = Convert.ToInt32(ddl_warehouse.SelectedValue);
            string kwname = txtkw.Value.ObjToStr();
            string sql = "update  WP_库位表 set 库位名='" + kwname + "',箱子MAC='" + txt_mac .Text.Trim()+ "' where id='" + id + "'";
            //string sql = "insert into WP_库位表 (仓库id,库位名) values('" + s + "','" + kwname + "') ";
            string sqlkw = "select 仓库id,库位名 from WP_库位表 where 仓库id='" + s + "' and 库位名='" + kwname + "'";
            DataTable dt = comfun.GetDataTableBySQL(sqlkw);
            if (dt.Rows.Count==0)
            {
                comfun.UpdateBySQL(sql);
             //   comfun.InsertBySQL(sql);
                //MessageBox.ShowAndRedirect(this, "修改成功！", "HotelWarehousekw.aspx");
                MessageBox.Show(this, "修改成功！");
            }
            else
            {
                MessageBox.Show(this, "修改失败！库位已存在");
            }
        }
        #endregion


        private void area(int id)
        {
            string sql = " where a.id=" + id;
            DataTable dt =sel_sql(sql);

            ddl_shen.DataSource = dt;
            ddl_shen.DataTextField = "名称";
            ddl_shen.DataValueField = "地区id";
            ddl_shen.DataBind();

            ddl_hotel.DataSource = dt;
            ddl_hotel.DataTextField = "酒店全称";
            ddl_hotel.DataValueField = "酒店id";
            ddl_hotel.DataBind();

            ddl_warehouse.DataSource = dt;
            ddl_warehouse.DataTextField = "仓库名";
            ddl_warehouse.DataValueField = "仓库id";
            ddl_warehouse.DataBind();
        }
 
        protected DataTable sel_sql(string where_sql) {
            string sql = @"select top 1 d.id as 地区id,d.名称 as 名称,c.id as 酒店id,c.酒店全称 as 酒店全称,b.仓库名 as 仓库名,b.id as 仓库id 
from WP_库位表 a left join WP_仓库表 b on a.仓库id=b.id left join WP_酒店表 c on b.酒店id=c.id left join WP_地区表 d on c.区域id=d.id  " + where_sql;
            DataTable dt = comfun.GetDataTableBySQL(sql);
            return dt;
        }


       
    }
}