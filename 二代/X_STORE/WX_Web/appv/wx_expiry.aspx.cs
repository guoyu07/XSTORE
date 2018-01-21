using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.appv
{
    public partial class wx_expiry : tdx.Weixin.weixinAuth
    {
        public string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            tdx.Weixin.weixin _wx = new tdx.Weixin.weixin();
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                    {
                        string Code = Request.QueryString["code"].ToString();

                        tdx.Weixin.Weixin.OAuth_Token oauth = _wx.Get_token(Code);
                        string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                        string[] _tdxWeixinArry = _tdxWeixin.Split('|');

                        string themeModel = Session["theme"].ToString();
                        string[] _theme = themeModel.Split('|');

                        lt_title.Text = _tdxWeixinArry[1];
                        lt_keywords.Text = " <meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\" />";
                        lt_description.Text = " <meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
                        lt_theme.Text = " <link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssIndex/" + _theme[0] + "/comm.css\" />";
                        lt_theme.Text += " <link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssDetail/" + _theme[2] + "/detail.css\" />";
                        //lt_theme2.Text = _tdxWeixinArry[2];

                        ///获取获奖的网页授权Openid
                        string Prize_Openid = oauth.openid != null ? oauth.openid.Trim() : "";

                        try
                        {
                            if (!string.IsNullOrEmpty(Prize_Openid))
                            {
                                DataTable dt_Prize = comfun.GetDataTableBySQL("select * from Wx_action_gain  where 1=1 and froms='" + Prize_Openid + "' and acID=" + id + "");
                                if (dt_Prize.Rows.Count > 0)
                                {
                                    DataTable dt_活动名称 = comfun.GetDataTableBySQL("select * from wx_action where id=" + dt_Prize.Rows[0]["acID"].ToString() + "");
                                    if (Creatrue.Common.Cookie_Session_Cache.CookieHelper.GetCookieValue("" + id + "OpenId") == Prize_Openid)
                                    {
                                        lt_newsContent.Text = "您已经领过奖了!";
                                    }
                                    else
                                    {
                                        string str_priz = "";
                                        str_priz += "恭喜你参与" + dt_活动名称.Rows[0]["ac_title"].ToString() + "的活动,中了" + dt_Prize.Rows[0]["ac_jpID"].ToString() + "等奖,奖品为";
                                        switch (dt_Prize.Rows[0]["ac_jpID"].ToString())
                                        {
                                            case "1":
                                                str_priz += dt_活动名称.Rows[0]["ac_jp_one"].ToString();
                                                break;
                                            case "2":
                                                str_priz += dt_活动名称.Rows[0]["ac_jp_two"].ToString();
                                                break;
                                            case "3":
                                                str_priz += dt_活动名称.Rows[0]["ac_jp_three"].ToString();
                                                break;
                                        }
                                        lt_newsContent.Text = str_priz;
                                        Creatrue.Common.Cookie_Session_Cache.CookieHelper.SetCookie("" + id + "OpenId", Prize_Openid);
                                    }
                                }
                                else
                                {
                                    lt_newsContent.Text = "您没有中奖!";
                                }
                            }
                            else
                            {
                                lt_newsContent.Text = "您没有中奖!";
                            }
                        }
                        catch
                        {

                        }
                    }

                    else
                    {
                        // 网页授权跳转页面
                        //string RedirectUri = "http://hongdou.creatrue.net/appv/wx_expiry.aspx?id=6";
                        string RedirectUri = Request.Url.ToString();
                        //只获取OpenID
                        string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + _wx.devlopID + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";
                        Response.Redirect(URL);
                    }
                }
                else
                {
                    lt_newsContent.Text = "验证码无效!";
                }
            }
        }
    }
}