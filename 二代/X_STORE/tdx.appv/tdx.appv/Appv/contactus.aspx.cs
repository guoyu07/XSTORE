using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using tdx.database;
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.appv
{
    public partial class contactus : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');
                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/" + _tdxWeixinArry[2] + "/apps_main.css\" /> ";
                //lt_theme2.Text = _tdxWeixinArry[2];

                int id = 0;
                DataTable dt = comfun.GetDataTableBySQL("select top 2 * from B2C_tpage order by id"); // where cityID=" +Session["wID"].ToString() + "
                if (dt.Rows.Count > 1)
                {
                    id = Convert.ToInt32(dt.Rows[1]["id"]);
                    lt_proTitle.Text = dt.Rows[1]["gtitle"].ToString().Trim();
                    lt_newsContent.Text = dt.Rows[1]["gcontent"].ToString().Trim();
                }
                if (id == 0)
                {
                    Response.Write("<p>您找的内容不存在</p>");
                    return;
                } 
               
            }
        }
    }
}
