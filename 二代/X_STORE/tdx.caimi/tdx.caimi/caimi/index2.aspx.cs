using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using Creatrue.Common;
using tdx.Weixin;
using System.Data;

namespace tdx.caimi
{
    public partial class index2 : weixinAuth
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
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "猜谜活动\" />";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "猜谜活动\">";
                

                string WWV = Request["WWV"] != null ? Request["WWV"].ToString().Trim() : "";
                string wwx = Request["wwx"] != null ? Request["wwx"].ToString().Trim() : "";
                string _ids = "3";// Request["id"] != null ? Request["id"].ToString().Trim() : "3";

                if (WWV == "") //如果没传递参数过来，不让玩这个游戏。
                {
                    try
                    {
                        if (Request["code"] != null)
                        {
                            string _code = Request["code"].ToString().Trim();
                            weixin wx = new weixin("wx91cf50871e83ac27", "ca66f57565d1e1b1d659074c91700c56");
                            WWV = wx.GetOpenID(_code);
                            _ids = Request["state"].ToString().Trim();
                        }
                        else
                        {
                            GetCode(_ids);
                        }
                    }
                    catch (Exception ex)
                    {
                        lt_newsContent.Text = "<p class='serv_res'><span class='red'>只有微信过来的会员才能参加抽奖</span></p>";
                        mainPage.Visible = false;
                        return;
                    } 
                }
                if (_ids == "0" || string.IsNullOrEmpty(_ids))
                {
                    lt_newsContent.Text = "<p class='serv_res'><span class='red'>没有设定活动ID</span></p>";
                    mainPage.Visible = false;
                    return;
                }
                //判断活动ID是否存在以及今天是否还可玩
                string _guid = comEncrypt.GetGuid32();
                string sql = "select * from wx_acm_action where id=" + _ids;
                sql += ";select guid_no from wx_acm_action_log where acid=" + _ids + " and wwv='" + WWV + "' and DateDiff(dd,regdate,getdate())=0 group by guid_no";
              
                DataSet ds = comfun.GetDataSetBySQL(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count >= Convert.ToInt32(ds.Tables[0].Rows[0]["freq"])) //已经玩过几次，不允许再玩
                    {
                        lt_newsContent.Text = "<p class='serv_res'><span class='red'>您今天已经累了，明天再来玩吧~~</span></p>";
                        mainPage.Visible = false;
                        return;
                    }
                    else
                    {
                        h_WWV.Value = WWV;
                        h_WWX.Value = _tdxWeixinArry[3];
                        h_acID.Value = _ids;
                        h_tID.Value = "0";
                        h_guid.Value = _guid;
                        lt_newsContent.Text = "";
                        lt_newsContent.Text = "<script language='javascript'>GetMiyu('" + _ids + "','" + WWV + "','" + _guid + "');</script>";
                        //ClientScript.RegisterStartupScript(this.Page.GetType(), "GetMiyu", "<script>GetMiyu('" + _ids + "','" + WWV + "');</script>");
                        //ClientScript.RegisterStartupScript(this.Page.GetType(), "SayHello", "SayHello('" + WWV + "');",true);
                    }
                }
                else //活动不存在
                {
                    lt_newsContent.Text = "<p class='serv_res'><span class='red'>该活动已不存在</span></p>";
                    mainPage.Visible = false;
                    return;
                }
 

                //ClientScript.RegisterStartupScript(this.Page.GetType(), "SayHello", "SayHello('" + _ids + "');", true);
            }
            //lt_newsContent.Text = "<script language='javascript'>SayHello('tianya');</script>";
            //ClientScript.RegisterStartupScript(Page.GetType(), "SayHello1", "SayHello1('tianya')", true);
        }


        private void GetCode(string _state)
        {

            string _url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx91cf50871e83ac27&redirect_uri=http://www.tdx.cn/caimi/index.aspx&response_type=code&scope=snsapi_base&state=" + _state + "#wechat_redirect";

            Response.Redirect(_url);
        } 
    }
}