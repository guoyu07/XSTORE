using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.Weixin;

namespace Wx_NewWeb.Talk
{
    public partial class Talk_Detail : weixinAuth
    {
        //weixinAuth
        public int 发帖表id = 0;
        protected string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
                Talk_head1.Title = "微社区详情";
                if (!string.IsNullOrEmpty(Request["BH"]))
                {
                    DataTable dtTieZi = DbHelperSQL.Query(@"
select top 1 a.*,b.wx昵称,b.wx头像 from TK_发帖表 a left join [dbo].[WP_会员表] b on a.openid=b.openid where a.编号 ='" + Request["BH"].ToString() + "' order by 是否置顶 desc,创建时间 desc").Tables[0];
                    TalkTieZi.DataSource = dtTieZi;
                    TalkTieZi.DataBind();
                    发帖表id = Convert.ToInt32(dtTieZi.Rows[0]["id"]);
                    if (dtTieZi.Rows.Count > 0)
                    {
                        DataTable dtPingLun = DbHelperSQL.Query("select a.*,b.wx昵称,b.wx头像 from [dbo].[TK_评论表] a left join [dbo].[WP_会员表] b on a.openid=b.openid where a.发帖表id='" + 发帖表id + "' order by a.评论时间 desc").Tables[0];
                        RepeaterPingLun.DataSource = dtPingLun;
                        RepeaterPingLun.DataBind();
                    }

                }
                else
                { 
                    string msg=" <script>$(function () { $(\"#button\").attr(\"onclick\", \"\");})</script>";
                    //Page.ClientScript.RegisterStartupScript(GetType(), "msg", msg, true);
                    ltrHuifu.Text = msg;
                }
            }
        }

        protected string GetTime(string _time)
        {
            string val = "";
            DateTime t1 = Convert.ToDateTime(_time);
            DateTime t2 = DateTime.Now;
            System.TimeSpan ts = t2 - t1;
            double days = ts.Days;
            double hours = ts.Hours;
            double minutes = ts.Minutes;
            if (days < 1)
            {
                val = hours + "小时" + minutes + "分钟前";
            }
            else
            {
                val = Convert.ToDateTime(_time).ToString("yyyy-MM-dd");
            }
            return val;
        }
    }
}