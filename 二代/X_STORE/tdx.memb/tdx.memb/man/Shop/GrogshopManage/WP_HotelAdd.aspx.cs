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
            string[] albumArr1 = DTRequest.GetFormString("hid_photo_name").Split(',');
            string str1 = string.Join(",", albumArr1);
            string str = str1.Substring(3, 39);
            string jdqc = txtjdmc.Text.ToString();
            string jdjc = txtjdjc.Text.ToString();
            int areaid = Convert.ToInt32(dparea.SelectedItem.Value);
            string xxdz = txtdizhi.Text.ToString();
            string phonenum = txtphone.Text.ToString();
            string sql = "insert into WP_酒店表 (酒店全称,酒店简称,Logo,区域id,地址,电话,总数,总额,区域管理id,酒店管理id,是否活跃,是否删除,最后修改时间,最后修改人id,创建时间,创建人id) values('"+jdqc+"','"+jdjc+"','"+str+"','"+areaid+"','"+xxdz+"','"+phonenum+"','0','0','6','6','','',getdate(),'',getdate(),'')";
            DataSet all = comfun.GetDataSetBySQL(sql);
            MessageBox.Show(this, sql); return;
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