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
    public partial class HotelWarehousekwAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                area();
                ddl_shen.Items.Insert(0, new ListItem("--请选择--", "0"));
               // ddl_shi.Items.Insert(0, new ListItem("--请选择--", "0"));
                ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
                ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string shenid=ddl_shen.SelectedValue;
            string hotelid = ddl_hotel.SelectedValue;
            string ckid = ddl_warehouse.SelectedValue;
            
            if(shenid=="0"){
                MessageBox.Show(this,"请选择地区!");
                return;
            }
            if (hotelid == "0")
            {
                MessageBox.Show(this, "请选择酒店!");
                return;
            }
            if (ckid == "0")
            {
                MessageBox.Show(this, "请选择仓库!");
                return;
            }
            string kwname = txtkw.Value.ObjToStr();
            string mac = txt_mac.Text.Trim().ObjToStr();
            if(kwname==""){
                MessageBox.Show(this,"请填写房间号");
                return;
            }
            if (mac == "")
            {
                MessageBox.Show(this, "请填写MAC");
                return;
            }
            else
            {
                var macCheckSql = string.Format(@"select * from WP_库位表 where 箱子MAC ='{0}'", mac);
                var macCheckDt = comfun.GetDataTableBySQL(macCheckSql);
                if (macCheckDt.Rows.Count > 0)
                {
                    MessageBox.Show(this, "mac地址已存在");
                    txt_mac.Text = string.Empty;
                    return;
                }
            }
            string sql = "insert into WP_库位表 (仓库id,库位名,箱子MAC) values('" + ckid + "','" + kwname + "','"+mac+"') ";
            string sqlkw = "select 仓库id,库位名 from WP_库位表 where 仓库id='" + ckid + "' and 库位名='" + kwname + "'";
            DataTable dt = comfun.GetDataTableBySQL(sqlkw);
            if (dt.Rows.Count == 0)
            {
                comfun.InsertBySQL(sql);
                //MessageBox.ShowAndRedirect(this, "添加成功！", "HotelWarehousekw.aspx");
                MessageBox.Show(this, "添加成功！");
            }
            else
            {
                MessageBox.Show(this, "添加失败！库位已存在");
            }
        }



        private void area()
        {
            string sql = "select id,名称 from WP_地区表 where 父级id is null"; //or 名称='全国'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_shen.DataTextField = "名称";
            ddl_shen.DataValueField = "id";
            ddl_shen.DataSource = dt;
            ddl_shen.DataBind();
        }
        //shi
        //private void shi()
        //{
        //    string shenid = ddl_shen.SelectedItem.Value;
        //    string shi = "select id,名称 from WP_地区表 where 父级id='" + shenid + "'";
        //    DataTable dt = comfun.GetDataTableBySQL(shi);
        //    ddl_shi.DataTextField = "名称";
        //    ddl_shi.DataValueField = "id";
        //    ddl_shi.DataSource = dt;
        //    ddl_shi.DataBind();
        //}
        //jd
        private void jd()
        {
            //select id,酒店简称 from WP_酒店表  where 区域id='2'
            //string shiid = ddl_shi.SelectedItem.Value;
            string shenid = ddl_shen.SelectedValue;
            string jd = "select id,酒店简称 from WP_酒店表  where 区域id= " + shenid + "  and IsShow=1 ";
            DataTable dt = comfun.GetDataTableBySQL(jd);
            ddl_hotel.DataTextField = "酒店简称";
            ddl_hotel.DataValueField = "id";
            ddl_hotel.DataSource = dt;
            ddl_hotel.DataBind();

        }
        private void warehouse()
        {
            string jdid = ddl_hotel.SelectedItem.Value;
            string warehouse = "select id,仓库名 from WP_仓库表 where 酒店id=" + jdid + " and IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(warehouse);
            ddl_warehouse.DataTextField = "仓库名";
            ddl_warehouse.DataValueField = "id";
            ddl_warehouse.DataSource = dt;
            ddl_warehouse.DataBind();
        }

        protected void ddl_shen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //shi();
            ddl_hotel.Items.Clear();
            ddl_warehouse.Items.Clear();
            //ddl_shi.Items.Insert(0, new ListItem("--请选择--", "0"));
            jd();
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        protected void ddl_shi_SelectedIndexChanged(object sender, EventArgs e)
        {
            jd();
          //  ddl_warehouse.Items.Clear();
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        protected void ddl_hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            warehouse();
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        protected void ddl_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}