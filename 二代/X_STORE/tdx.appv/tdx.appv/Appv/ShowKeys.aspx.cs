using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;
using tdx.Weixin;
 

namespace tdx.appv
{
    public partial class ShowKeys : weixinAuth
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
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" />";
                lt_theme1.Text = "<br/><link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssDetail/" + _theme[2] + "/detail.css\" />";
                int id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                if (id == 0)
                {
                    Response.Write("<p>您找的图文信息不存在</p>");
                    return;
                }
                wx_keys w_keys = new wx_keys(id);
                lt_title.Text = w_keys.k_words;
                lt_proTitle.Text = comfun.DeCodeHtml(w_keys.k_answer);
                lt_newsContent.Text = comfun.DeCodeHtml(w_keys.k_content);
                img_detail.Src = w_keys.k_image;
                try
                {
                    //B2C_worker bw = new B2C_worker(Convert.ToInt32(_tdxWeixinArry[0]));
                    //lt_tel.Text = "<button class=\"button2\" onclick=\"location.href='tel:" + bw.M_tel + "';\"> <img src=\"/appv/images/icon_tel.png\">&nbsp;拨打电话</button>";
                    //lt_tel.Text = "<a href='tel:" + bw.M_tel + "'><img src=\"/appv/images/icon_tel.png\">拨打电话</a>";             
                }
                catch (Exception ex) { }
            }
        }
    }
}