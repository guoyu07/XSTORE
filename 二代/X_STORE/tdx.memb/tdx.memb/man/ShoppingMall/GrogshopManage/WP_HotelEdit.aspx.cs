using Creatrue.Common.Msgbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.DBUtility;
using tdx.database;
using Creatrue.kernel;
using DTcms.BLL;
using System.Data.SqlClient;

namespace tdx.memb.man.ShoppingMall.GrogshopManage
{
    public partial class WP_HotelEdit : System.Web.UI.Page
    {
        DTcms.BLL.WP_地区表 dqbll= new DTcms.BLL.WP_地区表();
        DTcms.BLL.WP_酒店表 jdbll=new DTcms.BLL.WP_酒店表();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]); if (!IsPostBack)
            {
                dpareachoose();
                //charu();

                // Dropleibie(); 
                //if (id != -1)
                //{
                //    charu(id);
                //}    
                charu(id);
            }
           
            
           // 

        }
        protected void charu(int id)
        {
            //显示酒店
            DataTable jd_dt = jdbll.GetList("id=" + id).Tables[0];
            if (jd_dt.Rows.Count > 0)
            {//绑定酒店全称、酒店简称、电话、详细地址
            txtjdmc.Text = jd_dt.Rows[0]["酒店全称"].ObjToStr();
            txtjdjc.Text=jd_dt.Rows[0]["酒店简称"].ObjToStr();
            //txtphone.Text = jd_dt.Rows[0]["电话"].ObjToStr();
            //txtdizhi.Text = jd_dt.Rows[0]["地址"].ObjToStr();
            dparea.SelectedValue = jd_dt.Rows[0]["区域id"].ObjToStr();
            //绑定图片
            rptlogo.DataSource = jd_dt;
            rptlogo.DataBind();
            
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] albumArr1 = DTRequest.GetFormString("hid_photo_name").Split(',');
            string str = "";
            if (albumArr1 != null && albumArr1.Length > 0 && albumArr1[0] != "")
            {
                string str1 = string.Join(".", albumArr1);
                //str = str1.Substring(2, 40);
                List<string> list_str = str1.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                str = list_str[1];
            }
            else {
                MessageBox.Show(this, "请先上传图片！"); return;
            }
           
            
            string jdqc = txtjdmc.Text.ObjToStr();
            string jdjc = txtjdjc.Text.ObjToStr();
            string areaid = dparea.SelectedValue;
            //string xxdz = txtdizhi.Text.ObjToStr();
            //string phonenum = txtphone.Text.ObjToStr();
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            string sql  = "update WP_酒店表 set 酒店全称='" + jdqc + "',酒店简称='" + jdjc + "',Logo='" + str + "',最后修改时间=getdate(),区域id="+areaid+" where id='" + id + "'";
           int  flag = comfun.UpdateBySQL(sql);

           if (flag > 0)
           {
               MessageBox.ShowAndRedirect(this,"修改成功","WP_HotelList.aspx");
           }
           else {
               MessageBox.Show(this, "修改失败"); return;
           }
            //lblx.Text =str;
           
            //if (id > 0&&albumArr1!=null)
            //{
            //    MessageBox.ShowAndRedirect(this, "修改成功！", "WP_HotelList.aspx");
            //}
            //else {
            //    MessageBox.ShowAndRedirect(this, "修改成功！", "WP_HotelList.aspx");
            //}
        }

        protected void dpareachoose()
        {
            string sql = "select id,名称 from WP_地区表 where 删除时间 is null";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            dparea.DataTextField = "名称";
            dparea.DataValueField = "id";
            this.dparea.DataSource = dt;
            dparea.DataBind();
        }

    }
}