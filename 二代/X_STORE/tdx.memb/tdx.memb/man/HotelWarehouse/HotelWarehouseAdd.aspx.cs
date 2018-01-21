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
    public partial class HotelWarehouseAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                area();
                ddl_shen.Items.Insert(0, new ListItem("--请选择--", "0"));
             //   ddl_shi.Items.Insert(0, new ListItem("--请选择--", "0"));
                ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
                //dparea.Items.Insert(0, new ListItem("--请选择--", "0"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int s = Convert.ToInt32(ddl_hotel.SelectedItem.Value);
            if (ddl_shen.SelectedValue=="0")
            {
                MessageBox.Show(this, "请选择省份");
                return;
            }
            if (ddl_hotel.SelectedValue == "0")
            {
                MessageBox.Show(this, "请选择酒店");
                return;
            }
         
            if (txtck.Value=="")
            {
             MessageBox.Show(this, "请填写仓库名");
             return;
            }
            if (txtdizhi.Text=="")
            {
                MessageBox.Show(this, "请填写详细地址");
                return;
            }
            if (txtphone.Text=="")
            {
                MessageBox.Show(this,"请填写前台电话!");
                return;
            }else{
            Boolean boo=isPhone(txtphone.Text);
                if(!boo){
                    MessageBox.Show(this,"请正确按照格式填写前台电话!");
                    return;
                }
            }
            
            
            string ckname = txtck.Value.ObjToStr();
            string sql = "insert into WP_仓库表 (仓库名,酒店id,区域id,详细地址,电话) values('" + ckname + "','" + s + "'," + ddl_shen.SelectedValue + ",'" + txtdizhi.Text + "','"+txtphone.Text+"') ";
            string sqlck = "select 仓库名,酒店id from WP_仓库表 where 仓库名='" + ckname + "' and 酒店id='" + s + "'";
            DataTable dt = comfun.GetDataTableBySQL(sqlck);
            if (dt.Rows.Count == 0)
            {
                comfun.InsertBySQL(sql);//插入酒店
                string sel_sql = @"select 区号 from WP_地区表 where id=" + ddl_shen.SelectedValue;
                DataTable dta=new comfun().GetDataTable(sel_sql);
                string ckmax = @"select max(id) as id from WP_仓库表";//酒店顺序
                DataTable dtb = new comfun().GetDataTable(ckmax);

                if(dta.Rows.Count>0){
                    string name = dta.Rows[0]["区号"].ObjToStr()+dtb.Rows[0]["id"].ObjToStr().PadLeft(4,'0')+"101";
                    string name2 = dta.Rows[0]["区号"].ObjToStr() + dtb.Rows[0]["id"].ObjToStr().PadLeft(4, '0') + "102";
                    string name3 = dta.Rows[0]["区号"].ObjToStr() + dtb.Rows[0]["id"].ObjToStr().PadLeft(4, '0') + "111";
                    string name4 = dta.Rows[0]["区号"].ObjToStr() + dtb.Rows[0]["id"].ObjToStr().PadLeft(4, '0') + "112";
                    string name5 = dta.Rows[0]["区号"].ObjToStr() + dtb.Rows[0]["id"].ObjToStr().PadLeft(4, '0') + "113";
                    /*用户名
                     * 四位城市区号
                     * 四位酒店顺序
                     * 一位，级别编码；最基层1，总部9，中间暂时空缺，根据未来发展再增加
                     * 二维，岗位编码；酒店经理01，酒店财务02，酒店补货员11,12,13
                     */
                    string ins_sql   = @"insert into WP_用户表(用户名,密码,IsShow,角色id)values('" + name +"','123456','1','1')";
                    string ins_sql2 = @"insert into WP_用户表(用户名,密码,IsShow,角色id)values('" + name2 + "','123456','1','2')";
                    string ins_sql3 = @"insert into WP_用户表(用户名,密码,IsShow,角色id)values('" + name3 + "','123456','1','3')";
                    string ins_sql4 = @"insert into WP_用户表(用户名,密码,IsShow,角色id)values('" + name4 + "','123456','1','3')";
                    string ins_sql5 = @"insert into WP_用户表(用户名,密码,IsShow,角色id)values('" + name5 + "','123456','1','3')";
                    new comfun().Insert(ins_sql);
                    new comfun().Insert(ins_sql2);
                    new comfun().Insert(ins_sql3);
                    new comfun().Insert(ins_sql4);
                    new comfun().Insert(ins_sql5);
                }
                
                MessageBox.ShowAndRedirect(this, "添加成功！", "HotelWarehouseList.aspx");

            }
            else
            {
                MessageBox.Show(this, "添加失败！仓库已存在");
            }
        }

        public static bool isPhone(string input)
        {
            Regex regex = new Regex(@"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
            //Regex regex = new Regex(@"/^0\d{2,3}-[1-9]\d{6,7}$/");
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
        //市
        //private void shi()
        //{
        //    string shenid = ddl_shen.SelectedValue;
        //    string shi = "select id,名称 from WP_地区表 where 父级id='" + shenid + "'";
        //    DataTable dt = comfun.GetDataTableBySQL(shi);
        //    ddl_shi.DataTextField = "名称";
        //    ddl_shi.DataValueField = "id";
        //    ddl_shi.DataSource = dt;
        //    ddl_shi.DataBind();
        //}
        //酒店
        private void jd()
        {
            //select id,酒店简称 from WP_酒店表  where 区域id='2'
            //string shiid = ddl_shi.SelectedValue;
            string shenid = ddl_shen.SelectedValue;
            string jd = "select id,酒店全称 from WP_酒店表  where 区域id=" + shenid + " and IsShow=1 ";
            DataTable dt = comfun.GetDataTableBySQL(jd);
            ddl_hotel.DataSource = dt;
            ddl_hotel.DataTextField = "酒店全称";
            ddl_hotel.DataValueField = "id";
            ddl_hotel.DataBind();

        }

        //省级联动
        protected void ddl_shen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //shi();
            ddl_hotel.Items.Clear();
            jd();
            //dpareachoose();
            
           // ddl_shi.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

    }
}