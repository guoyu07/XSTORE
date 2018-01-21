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
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.appv
{
    public partial class helps : weixinAuth
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
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/" + _tdxWeixinArry[2] + "/apps_main.css\" />";
                 

                string _cno = Request["cno"] != null ? Request["cno"].ToString().Trim() : "";
                string _page = Request["page"] != null ? Request["page"].ToString().Trim() : "1";
                string _postionID = Request["positionID"] != null ? Request["positionID"].ToString().Trim() : "";

                string _sql = "select * from b2c_tpage order by id"; // where cityid=" + Session["wID"].ToString().Trim() + "
                DataTable dt = comfun.GetDataTableBySQL(_sql);
                string result = ""; 
                if (dt.Rows.Count > 0)
                {
                    result += "\r\n"; 
                    result += "<ul> \r\n";
                    foreach (DataRow dr in dt.Rows)
                    {
                        string _files = "tpage.aspx?id=" + dr["id"].ToString().Trim()+"&WWX="+Request["WWX"].ToString().Trim();
                        if (Convert.ToInt32(dr["g_isurl"]) == 1 && dr["g_url"].ToString().Trim() != "")
                            _files = dr["g_url"].ToString().Trim();
                        result += "\r\n<a href='" + _files + "'>";
                        result += "<li> \r\n";
                        result += "     \r\n    " + dr["gtitle"].ToString().Trim(); 
                        result += "</li> \r\n";
                        result += "</a>\r\n";
                    }
                    result += "</ul>\r\n"; 
                }
                dt.Dispose();
                dt = null; 

                lt_newslist.Text = result; 
            }
        }
        private string GetMoney(string _money)
        {
            return string.Format("{0:F}", Convert.ToDouble(_money));
        }
    }
}
