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

namespace tdx.memb.man.Shop.GrogshopManage
{
    public partial class WP_HotelEdit : System.Web.UI.Page
    {
        DTcms.BLL.WP_地区表 dqbll= new DTcms.BLL.WP_地区表();
        DTcms.BLL.WP_酒店表 jdbll=new DTcms.BLL.WP_酒店表();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpareachoose();
                //charu();

                // Dropleibie(); 
                //if (id != -1)
                //{
                //    charu(id);
                //}    

            }
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            charu(id);
           // 

        }
        protected void charu(int id)
        {
            //显示酒店
            DataTable jd_dt = jdbll.GetList("id=" + id).Tables[0];
            if (jd_dt.Rows.Count > 0)
            {//绑定酒店全称、酒店简称、电话、详细地址
            txtjdmc.Text = jd_dt.Rows[0]["酒店全称"].ToString();
            txtjdjc.Text=jd_dt.Rows[0]["酒店简称"].ToString();
            txtphone.Text = jd_dt.Rows[0]["电话"].ToString();
            txtdizhi.Text = jd_dt.Rows[0]["地址"].ToString();
            dparea.SelectedValue = jd_dt.Rows[0]["区域id"].ToString();
                //绑定图片
           //// string sql = "select 酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id,是否活跃,是否删除,最后修改时间,最后修改人id,创建时间,创建人id from WP_酒店表 where id='1'";
           // string pic_sql = "select * from [WP_酒店表] where 酒店全称='" + jd_dt.Rows[0]["酒店全称"].ToString() + "' and 地址='" + jd_dt.Rows[0]["地址"].ToString() + "' order by 创建时间 asc";
           // DataTable pic_dt = DbHelperSQL.Query(pic_sql).Tables[0];
           // if (pic_dt.Rows.Count > 0)
           // {
           //     rptlogo.DataSource = pic_dt;
           // }
            }


           // string sql = "select 酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id,是否活跃,是否删除,最后修改时间,最后修改人id,创建时间,创建人id from WP_酒店表 where id='"+id+"'";
            
            
            
        
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] albumArr1 = DTRequest.GetFormString("hid_photo_name").Split('.');
            string str1 = string.Join(",", albumArr1);
            string str = str1.Substring(3, 39);
            string jdqc = txtjdmc.Text.ToString();
            string jdjc = txtjdjc.Text.ToString();
            int areaid = Convert.ToInt32(dparea.SelectedItem.Value);
            string xxdz = txtdizhi.Text.ToString();
            string phonenum = txtphone.Text.ToString();
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            string sql = "update WP_酒店表 set 酒店全称='" + jdqc + "',酒店简称='" + jdjc + "',Logo='" + str + "',区域id='" + areaid + "',地址='" + xxdz + "',电话='" + phonenum + "',最后修改时间=getdate() where id='"+id+"'";
            DataSet all = comfun.GetDataSetBySQL(sql);
            //lblx.Text =str;
            MessageBox.Show(this, sql); return;
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
            string sql = "select id,名称 from WP_地区表 where 父级id is null and 删除时间 is null";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            dparea.DataTextField = "名称";
            dparea.DataValueField = "id";
            this.dparea.DataSource = dt;
            dparea.DataBind();
        }

    }
}