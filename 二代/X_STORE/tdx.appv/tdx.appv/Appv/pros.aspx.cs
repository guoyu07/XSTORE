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
    public partial class pros : weixinAuth
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

                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" />";
                lt_theme1.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssList/" + _theme[1] + "/list.css\" />";
                 

                string result = "\r\n <ul>";
                //                                                                                   cityid=" + Session["wID"].ToString().Trim() + " and
                string _sql = "select c_no,c_name,isnull(c_gif,(select top 1 g_gif from b2c_goods where  g_isactive=1 and g_isdel=0 and cno=c_no order by g_sort,id desc)) as cgif from b2c_category where c_parent=0 order by c_sort,c_id"; // and cityID=" + Session["wID"].ToString().Trim() + "
                DataTable dt = comfun.GetDataTableBySQL(_sql);
                foreach (DataRow dr in dt.Rows)
                {
                    //result += "<a href='prolist.aspx?cno=" + dr["c_no"].ToString().Trim() + "&WWX="+Request["WWX"].ToString().Trim()+"'><li><img src='" + dr["cgif"].ToString().Trim() + "' border='0' />" + "<p>" + dr["c_name"].ToString().Trim() + "</p></li></a>  \r\n";
                    //result += "<a href='prolist.aspx?cno=" + dr["c_no"].ToString().Trim() + "&WWX=" + Request["WWX"].ToString().Trim() + "'><li>" + "<p>" + dr["c_name"].ToString().Trim() + "</p></li></a>  \r\n";

                    result += "<li> \r\n"; // id=l_item\"" + dr["id"].ToString() + "\"
                    result += "\r\n<a href='prolist.aspx?cno=" + dr["c_no"].ToString().Trim() + "&WWX=" + Request["WWX"].ToString().Trim() + "'>";
                    //result += "     \r\n<img src='" + (string.IsNullOrEmpty(dr["g_gif"].ToString()) ? "images/nopic.png" : dr["g_gif"].ToString().Replace("all", "min")) + "' border='0' />";
                    result += "     \r\n    <h1>" + dr["c_name"].ToString().Trim() + "</h1>";
                    //result += "     \r\n    <p>" + dr["g_des"].ToString().Trim() + "</p>";
                    result += "</a>\r\n";
                    result += "</li>";

                }

                result += "\r\n </ul>";
                lt_prolist.Text = result;
            }

        }
    }
}
