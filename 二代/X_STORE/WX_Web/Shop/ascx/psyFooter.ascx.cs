using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Wx_NewWeb.Shop.ascx
{
    public partial class psyFooter : System.Web.UI.UserControl
    {
        public string openid = "";
        public string page = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{
            //    string openid = (this.Parent.Parent.FindControl(Session["OpenId"] != null ? Session["OpenId"].ToString():"").ObjToStr()); 
            //    //.FindControl("TextBox1")).Text;
            //    //openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
            //    string sql = "select 用户名 from WP_用户表 where opeind='" + openid + "'";
            //    DataTable dt = comfun.GetDataTableBySQL(sql);
            //    username.Text = dt.Rows[0]["用户名"].ObjToStr();
            //}
        }
    }
}