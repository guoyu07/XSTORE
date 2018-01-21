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
    public partial class honor_action : weixinAuth
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
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" /> ";
                lt_theme.Text += "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssDetail/" + _theme[2] + "/detail.css\" /> ";
                //lt_theme2.Text = _tdxWeixinArry[2];

                string WWV = Request["WWV"] != null ? Request["WWV"].ToString().Trim() : "";
                string _ids = Request["id"] != null ? Request["id"].ToString().Trim() : "0";
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
                //奖品是否全部抽完
                string _sql_price = "select count(*) from Wx_action_gain where acID=" + _ids + " and ac_jpID=1;";
                _sql_price += "select count(*) from Wx_action_gain where acID=" + _ids + " and ac_jpID=2;";
                _sql_price += "select count(*) from Wx_action_gain where acID=" + _ids + " and ac_jpID=3;";
                DataSet set = comfun.GetDataSetBySQL(_sql_price);
                int p1 = Convert.ToInt32(set.Tables[0].Rows[0][0]);
                int p2 = Convert.ToInt32(set.Tables[1].Rows[0][0]);
                int p3 = Convert.ToInt32(set.Tables[2].Rows[0][0]);
                if (p1 >= 1 && p2 >= 3 && p2 >= 5)
                {
                    lt_newsContent.Text = "<p class='serv_res'><span class='red'>活动已经结束</span></p>";
                    mainpan.Visible = false;
                    return;
                }

                DataTable dt_log_num = comfun.GetDataTableBySQL("select count(id) from Wx_action_logs where froms='" + WWV + "' and acID=" + _ids);
                DataTable dt = comfun.GetDataTableBySQL("select * from wx_action where id=" + _ids);
                if (Convert.ToInt32(dt_log_num.Rows[0][0]) < Convert.ToInt32(dt.Rows[0]["ac_men_num"])) //小于3才可以玩
                {
                    lt_newsContent.Text = "";

                    h_WWV.Value = WWV;
                    h_acID.Value = _ids;
                    chjnum.Value = Convert.ToString(dt.Rows[0]["ac_men_num"]);
                    //


                    if (dt.Rows.Count > 0)
                    {
                        if (DateTime.Now < Convert.ToDateTime(dt.Rows[0]["ac_bdate"]))
                        {
                            lt_newsContent.Text = "<p class='serv_res'><span class='red'>活动开始时间为："+Convert.ToDateTime(dt.Rows[0]["ac_bdate"]).ToString()+"</span></p>";
                            mainpan.Visible = false;
                            return;
                        }
                        if (DateTime.Now > Convert.ToDateTime(dt.Rows[0]["ac_edate"]))
                        {
                            lt_newsContent.Text = "<p class='serv_res'><span class='red'>活动已经结束</span></p>";
                            mainpan.Visible = false;
                            return;
                        }
                        lt_newsContent.Text = "<h1>" + dt.Rows[0]["ac_title"].ToString().Trim() + "</h1><p>" + dt.Rows[0]["ac_des"].ToString().Trim() + "</p>";
                        lt_jp1.Text = dt.Rows[0]["ac_jp_one"].ToString().Trim() != "" ? dt.Rows[0]["ac_jp_one"].ToString().Trim() : "";
                        lt_jp2.Text = dt.Rows[0]["ac_jp_two"].ToString().Trim() != "" ? dt.Rows[0]["ac_jp_two"].ToString().Trim() : "";
                        lt_jp3.Text = dt.Rows[0]["ac_jp_three"].ToString().Trim() != "" ? dt.Rows[0]["ac_jp_three"].ToString().Trim() : "";
                        lt_shuoming.Text = dt.Rows[0]["ac_dj_info"].ToString().Trim();
                    }
                    else
                    {
                        lt_newsContent.Text = "<p class='serv_res'><span class='red'>没有设定活动ID</span></p>";
                        mainpan.Visible = false;
                    }
                    dt.Dispose();
                }
                else //大于3不能玩
                {
                    lt_newsContent.Text += "<p  class='wxenable'>抱歉啦！最多参加"+Convert.ToInt32(dt.Rows[0]["ac_men_num"])+"次抽奖</p>";
                    mainpan.Visible = false;
                    return;
                }
            }
        }
    }
}
