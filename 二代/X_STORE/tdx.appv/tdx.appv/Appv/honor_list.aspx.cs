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

namespace tdx.appv
{
    public partial class honor_list : System.Web.UI.Page
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
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/" + _tdxWeixinArry[2] + "/comm.css\" />";
                lt_theme.Text += "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/" + _tdxWeixinArry[2] + "/detail.css\" />";
                string result = "";
                DataTable dt = comfun.GetDataTableBySQL("select * from wx_honor where isHonor=1 and DateDiff(dd,regtime,getdate())=0");
                result += "<h1 class='proTitle'>今日获奖名单</h1> \r\n";
                if (dt.Rows.Count == 0)
                {
                    result += "<p>暂无朋友获奖! 赶快参加吧！</p>  \r\n";
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result += "<li>[" + dr["regtime"].ToString() + "]" + dr["fromuser"].ToString().Trim() + ": 中奖号码" + dr["resultNum"].ToString().Trim() + "</li>\r\n";
                    }
                }
                dt.Dispose();
                lt_prolist.Text = result;
            }
        }
    }
}
