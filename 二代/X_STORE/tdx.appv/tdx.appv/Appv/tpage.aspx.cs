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
    public partial class tpage : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');

                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');

                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\" />";
                lt_description.Text = "<meta name=\"description\" content=\""+_tdxWeixinArry[1]+"\" />";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" /> ";
                lt_theme1.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssDetail/" + _theme[2] + "/detail.css\" /> ";
                //lt_theme2.Text = _tdxWeixinArry[2];
                string cno = Request["cno"] != null ? Convert.ToString(Request["cno"]) : "";
                int id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                if (id != 0)
                {
                    B2C_tpage bt = new B2C_tpage(id);
                    img_detail.Src = bt.ggif;
                    lt_proTitle.Text = bt.gtitle;
                    lt_newsContent.Text = bt.gcontent;
                }
                else
                {
                    string _wwx = Request["wwx"] != null ? Request["wwx"].ToString().Trim() : "";
                    string _wwv = Request["wwv"] != null ? Request["wwv"].ToString().Trim() : "";
                    Response.Redirect("tpagelist.aspx?cno=" + cno + "&wwx=" + _wwx + "&wwv=" + _wwv);

                    //Response.Write("<p>您找的页面不存在</p>");
                    //return;
                }
               
            }
        }
    }
}
