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
    public partial class news : weixinAuth
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
                 

                string result = "\r\n <ul>";

                string _sql = "select c_no,c_name from b2c_tclass where c_parent=0 order by c_sort,c_id"; // and cityID=" + Session["wID"].ToString().Trim() + "
                DataTable dt = comfun.GetDataTableBySQL(_sql);
                foreach (DataRow dr in dt.Rows)
                {
                    result += "<a href='newslist.aspx?cno=" + dr["c_no"].ToString().Trim() + "&WWX=" + Request["WWX"].ToString().Trim() + "'><li>" + dr["c_name"].ToString().Trim() + "</li></a>  \r\n";
                }

                result += "\r\n </ul>";
                lt_prolist.Text = result;
            }

        }
    }
}
