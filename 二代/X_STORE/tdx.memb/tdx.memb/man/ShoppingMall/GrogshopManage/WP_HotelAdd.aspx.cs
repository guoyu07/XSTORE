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
    public partial class WP_HotelAdd : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpareachoose();
                
            }
           
            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string jdqc = txtjdmc.Text.ObjToStr();
            string jdjc = txtjdjc.Text.ObjToStr();
            if(jdqc==""){
                MessageBox.Show(this,"请填写酒店全称");
                return;
            }
            if (jdjc == "")
            {
                MessageBox.Show(this, "请填写酒店简称");
                return;
            }
            string[] albumArr1 = DTRequest.GetFormString("hid_photo_name").Split(',');
            string str = "";
            if (albumArr1 != null && albumArr1.Length > 0 && albumArr1[0] != "")
            {
                string str1 = string.Join(".", albumArr1);
                //  str = str1.Substring(2, 40);
                List<string> list_str = str1.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                str = list_str[1];
            }
            else
            {
                MessageBox.Show(this, "请先上传图片！"); return;
            }
            int areaid = Convert.ToInt32(dparea.SelectedValue);
            
            

            string sql = "insert into WP_酒店表 (酒店全称,酒店简称,Logo,总数,总额,区域管理id,酒店管理id,是否活跃,是否删除,最后修改时间,最后修改人id,创建时间,创建人id,区域id) values('" + jdqc + "','" + jdjc + "','" + str + "','0','0','6','6','','',getdate(),'',getdate(),'','" + areaid + "')";
            int flag = comfun.InsertBySQL(sql);
            if (flag > 0)
            {
                MessageBox.ShowAndRedirect(this,"添加成功","WP_HotelList.aspx");
            }
            else
            {
                MessageBox.Show(this, "添加失败"); return;
            }
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