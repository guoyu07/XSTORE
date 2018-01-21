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
using Creatrue.Common;
using tdx.Weixin;

namespace tdx.caimi
{
    public partial class honor_action2 : weixinAuth
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
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\">";
            

                string WWV = Request["WWV"] != null ? Request["WWV"].ToString().Trim() : "";
                string _ids = Request["acID"] != null ? Request["acID"].ToString().Trim() : "0";
                if (WWV == "") //如果没传递参数过来，不让玩这个游戏。
                {
                    lt_newsContent.Text = "<p class='serv_res'><span class='red'>只有微信过来的会员才能参加抽奖</span></p>";
                    mainpan.Visible = false;
                    return;
                }
                if (_ids == "0" || string.IsNullOrEmpty(_ids))
                {
                    lt_newsContent.Text = "<p class='serv_res'><span class='red'>没有设定活动ID</span></p>";
                    mainpan.Visible = false;
                    return;
                }
                //判断是否有连续猜对谜语的
                string _sql = "select count(id) as idcount,guid_no from wx_acm_action_log where acid=" + _ids + " and wwv='" + WWV + "' and DateDiff(dd,regdate,getdate())=0 group by guid_no";
                _sql = "with c as (" + _sql + ")select guid_no from c where idcount>2"; 
                 
                _sql += ";with b as (select count(id) as idcount,guid_no from wx_acm_action_log where acid=" + _ids + " and wwv='" + WWV + "' group by guid_no)";
                _sql += "select * from wx_acm_gain_log where wwv='" + WWV + "' and guidno in (select guid_no from b where idcount>2) and DateDiff(dd,regdate,getdate())=0";

                DataSet ds = comfun.GetDataSetBySQL(_sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lt_newsContent.Text = "<p class='serv_res'><span class='red'>您还没有抽奖机会。<a href='index2.aspx?wwx=" + _tdxWeixinArry[3] + "&wwv=" + WWV + "&id=" + _ids + "'>请参加我们的猜谜活动，获得抽奖机会</a>。</span></p>";
                    mainpan.Visible = false;
                    return;
                }
                else
                {
                   //确认有机会抽奖
                    chjnum.Value = (3 - ds.Tables[1].Rows.Count).ToString();//可用抽奖次数
                    h_WWV.Value = WWV;
                    h_acID.Value = _ids;
                    h_guidno.Value = ds.Tables[0].Rows[0]["guid_no"].ToString();

                    lt_jp1.Text = "<p>【魅力新江南2014休闲游园年卡】</p>";
                    lt_shuoming.Text = "1）连续答对三道谜语，就有机会参加的转盘抽奖，赢取“魅力新江南2014休闲游园年卡”一张。";
                    lt_shuoming.Text += "    <br>";
                    lt_shuoming.Text += "2）抽中奖品的朋友,请去领奖台领取奖品。<br>";
                    lt_shuoming.Text += "3）每人只有三次机会。";
                }
               
            }
        }
    }
}
