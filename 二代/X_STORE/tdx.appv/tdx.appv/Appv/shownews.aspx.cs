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
using tdx.database.database;

namespace tdx.appv
{
    public partial class shownews : weixinAuth
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
                lt_keywords.Text =" <meta name=\"keywords\" content=\""+ _tdxWeixinArry[1]+"\" />";
                lt_description.Text = " <meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_theme.Text = " <link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" />";
                lt_theme.Text += " <link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssDetail/" + _theme[2] + "/detail.css\" />";
                //lt_theme2.Text = _tdxWeixinArry[2];

                int id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                if (id == 0)
                {
                    Response.Write("<p>您找的新闻不存在</p>");
                    return;
                }
                B2C_tmsg bt = new B2C_tmsg(id);
                lt_title.Text = bt.t_title;

                lt_proTitle.Text = comfun.DeCodeHtml(bt.t_title);//bt.cname;
                lt_proAuthor.Text = comfun.DeCodeHtml(bt.t_author)!="" ? ("作者:" + comfun.DeCodeHtml(bt.t_author)) :"";
                lt_proDate.Text = bt.t_wdate != null ? ("发布:" + bt.t_wdate.ToString()) : "";
                img_detail.Src = bt.t_gif;
                lt_newsContent.Text = comfun.DeCodeHtml(bt.t_msg);

                try
                {
                    //B2C_worker bw = new B2C_worker(Convert.ToInt32(_tdxWeixinArry[0]));    

                    wx_config bw = new wx_config();
                    
                    lt_tel.Text = "<a href='tel:"+bw.M_tel+"'><img src=\"/appv/images/icon_tel.png\">拨打电话</a>";
                }
                catch (Exception ex) { }
            }
        }
    }
}
