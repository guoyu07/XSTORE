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
    public partial class showpro : weixinAuth
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
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + " />";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + " />";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" />";
                lt_theme1.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssDetail/" + _theme[2] + "/detail.css\" />";
                int id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                if (id == 0)
                {
                    Response.Write("<p>您找的商品不存在</p>");
                    return;
                }

                B2C_Goods bg = new B2C_Goods(id);
                lt_title.Text = bg.g_name;
                lt_proTitle.Text = bg.g_name;
                lt_proImg.Src = bg.g_gif.Replace("all", "min");                
                //lt_proNo.Text = bg.g_no;
                //lt_proUnit.Text = bg.g_unit;               
                lt_proDes.Text = bg.g_des;
                try
                {
                    B2C_Goods_M bgm = new B2C_Goods_M(id);
                    lt_proMsg.Text = bgm.g_msg;
                }
                catch(Exception ex)
                {
                    ;
                }
                
            }
        }
    }
}
