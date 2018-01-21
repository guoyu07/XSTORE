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
using System.Text.RegularExpressions;
namespace tdx.memb.man.HotelWarehouse
{
    public partial class HotelWarehouseEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            if (!IsPostBack)
            {
                area();
                jd();
                selected(id);
                
            }
        }
        private void selected(int id)
        {
            string sql = "select id,酒店id,仓库名,详细地址,电话 from WP_仓库表 where id=" + id + " and IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count>0)
            {
                txtdizhi.Text = dt.Rows[0]["详细地址"].ObjToStr();
                txtck.Value= dt.Rows[0]["仓库名"].ObjToStr();//仓库名
                txtphone.Text = dt.Rows[0]["电话"].ObjToStr();//电话
                string sql3 = "select id,区域id,酒店全称 from WP_酒店表 where id=" + dt.Rows[0]["酒店id"].ToString() + " ";
                DataTable dt3 = comfun.GetDataTableBySQL(sql3);
                if(dt3.Rows.Count>0){
                    ddl_hotel.DataSource = dt3;//酒店
                    ddl_hotel.DataTextField = "酒店全称";
                    ddl_hotel.DataValueField = "id";
                    ddl_hotel.DataBind();

                    string sql4 = @"select id,名称 from WP_地区表 where id="+dt3.Rows[0]["区域id"].ObjToStr();
                    DataTable dt4 = comfun.GetDataTableBySQL(sql4);
                    if(dt4.Rows.Count>0){
                        ddl_shen.DataSource = dt4;
                        ddl_shen.DataTextField="名称";
                        ddl_shen.DataValueField="id";
                        ddl_shen.DataBind();
                    }
                       
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);

            int s = Convert.ToInt32(ddl_hotel.SelectedItem.Value);//酒店
            string ckname = txtck.Value.ObjToStr();//仓库名
            string location = txtdizhi.Text.Trim().ObjToStr();//详细地址
            string phono = txtphone.Text.Trim().ObjToStr();
            if(phono==""){
                MessageBox.Show(this, "请填写前台电话!");
                return;
            }else
            {
                Boolean boo = isPhone(txtphone.Text);
                if (!boo)
                {
                    MessageBox.Show(this, "请正确按照格式填写前台电话!");
                    return;
                }
            }
            string sql = "update  WP_仓库表 set 仓库名='" + ckname + "',详细地址='" + location + "',电话='" + phono + "' where id='" + id + "'";
            int flag=comfun.UpdateBySQL(sql);
            new comfun().Update(@"update WP_酒店表 set 区域id="+ddl_shen.SelectedValue+" where id="+ddl_hotel.SelectedValue);
            if (flag != 0)
            {
                MessageBox.ShowAndRedirect(this, "修改成功！", "HotelWarehouseList.aspx");
            }
            else {
                MessageBox.Show(this,"修改失败!");
            }
            

        }
        //判断是否电话
        public static bool isPhone(string input)
        {
            Regex regex = new Regex(@"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
          //  Regex regex = new Regex(@"/^0\d{2,3}-[1-9]\d{6,7}$/");
            return regex.IsMatch(input);
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
        private void jd()
        {
            string shenid=ddl_shen.SelectedValue;
            string jd = "select id,酒店简称 from WP_酒店表  where 区域id='" + shenid + "'and 是否删除='false' and IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(jd);
            ddl_hotel.DataTextField = "酒店简称";
            ddl_hotel.DataValueField = "id";
            ddl_hotel.DataSource = dt;
            ddl_hotel.DataBind();

        }


        protected void ddl_shen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_hotel.Items.Clear();
            jd();
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

    }
}