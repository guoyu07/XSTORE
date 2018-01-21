using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.Weixin;

namespace Wx_NewWeb.Message
{
    public partial class ReviewContent : weixinAuth
    {
        public static int newsid;
        public static int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region MyRegion
            if (!IsPostBack)
            {
                string _tdxWeixin = Session["wpWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');

                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');

                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\" />";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssIndex/" + _theme[0] + "/comm.css\" /> ";
                lt_theme.Text += "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssDetail/" + _theme[2] + "/detail.css\" /> ";
            } 
            #endregion

            if (!IsPostBack)
            {
                userid = int.Parse(Session["userid"].ToString());
                newsid = int.Parse(string.IsNullOrEmpty(Request.QueryString["newsid"]) ? "" : Request.QueryString["newsid"]);
                lit_show.Text = Show(newsid);

                //B2C_worker bw = new B2C_worker(Convert.ToInt32(_tdxWeixinArry[0]));
                string sql1 = "select * from  b2c_worker where id= 1";
                DataSet ds1 = comfun.GetDataSetBySQL(sql1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lt_tel.Text = "<a href='tel:" + ds1.Tables[0].Rows[0]["m_tel"] + "'><img src=\"/images/icon_tel.png\">拨打电话</a>";
                    lt_plus_qq1.Text = "<a href=\"http://wpa.qq.com/msgrd?v=3&amp;uin=" + ds1.Tables[0].Rows[0]["m_qq"].ToString() + "&amp;site=qq&amp;menu=yes\" target=\"_blank\"><img src=\"/images/icon_qq.png\">QQ客服</a>";
                    lt_plus_weixin1.Text = "<a href=\"http://hongdou.creatrue.net/tuan/kefu.aspx\" target=\"_blank\"><img src=\"/images/icon_weixin.png\">微信客服</a>";
                }
                else
                {
                    lt_tel.Text = "<a href='tel:'><img src=\"/images/icon_tel.png\">拨打电话</a>";
                    lt_plus_qq1.Text = "<a href=\"\" target=\"_blank\"><img src=\"/images/icon_qq.png\">QQ客服</a>";
                    lt_plus_weixin1.Text = "<a href=\"http://hongdou.creatrue.net/tuan/kefu.aspx\" target=\"_blank\"><img src=\"/images/icon_weixin.png\">微信客服</a>";
                }
            }
        }

        public string Show(int newsid)
        {
            StringBuilder str = new StringBuilder();

            DTcms.BLL.WP_NewsInfo newsinfobll = new DTcms.BLL.WP_NewsInfo();

            DTcms.BLL.WP_UserInfo userinfobll = new DTcms.BLL.WP_UserInfo();

            DTcms.BLL.WP_UbindN ubindnbll = new DTcms.BLL.WP_UbindN();

            DTcms.BLL.WP_PingLun pinglunbll = new DTcms.BLL.WP_PingLun();

            DTcms.Model.WP_UserInfo userinfomodel = new DTcms.Model.WP_UserInfo();

            DTcms.Model.WP_NewsInfo newsinfomodel = new DTcms.Model.WP_NewsInfo();

            DTcms.Model.WP_UbindN ubindnmodel = new DTcms.Model.WP_UbindN();

            DTcms.Model.WP_PingLun pinglunmodel = new DTcms.Model.WP_PingLun();


            //获取新闻信息
            DataTable dtnew = newsinfobll.GetList(" 1=1 and id=" + newsid + " order by CreateDate desc").Tables[0];

            if (dtnew.Rows.Count > 0)
            {

                //获取用户信息
                DataTable dtuser = userinfobll.GetList("  id=" + dtnew.Rows[0]["WriterID"]).Tables[0];

                if (dtuser.Rows.Count > 0)
                {
                    str.Append("<div class=\"box box_shadow\">");
                    str.Append("<div class=\"box_padd\">");
                    str.Append("<div class=\"autho clear\">" + (dtuser.Rows[0]["sex"].ToString() == "女" ? "<s class=\"girl\"></s><span>" : "<s class=\"boy\"></s><span>") + "" + dtuser.Rows[0]["username"] + "</span></div>");
                }
                DateTime time = (DateTime)dtnew.Rows[0]["CreateDate"];
                str.Append("<div class=\"time\">" + time.ToString("yyyy-MM-dd") + "</div>");
                str.Append("<div class=\"cont\">" + dtnew.Rows[0]["NewsContent"] + "</div>");
                str.Append("<ul class=\"operating clear\">");
                str.Append("<li><a href=\"#\" onclick='fenxiang()' class=\"clear\"><s class=\"share\"></s><span>分享</span></a></li>");

                //赞或已赞
                DataTable dtubindn = ubindnbll.GetList("  UserID=" + Convert.ToInt32(Session["userid"].ToString()) + " and NewsID=" + dtnew.Rows[0]["id"]).Tables[0];

                if (dtubindn.Rows.Count > 0)
                {

                    str.Append("<li><a href=\"javascript:;\" onclick=\"zan(" + dtnew.Rows[0]["id"] + "," + Convert.ToInt32(Session["userid"].ToString()) + ")\" class=\"clear\">" + (dtubindn.Rows[0]["IsZan"].ToString().Equals("True") ? "<s id=s" + dtnew.Rows[0]["id"] + " class=\"old_zan\"></s>" : "<s id=s" + dtnew.Rows[0]["id"] + " class=\"zan\"></s>") + "<span id=" + dtnew.Rows[0]["id"] + ">" + (dtubindn.Rows[0]["IsZan"].ToString().Equals("True") ? "已赞" : "赞") + "</span></a></li>");
                }
                else
                {
                    str.Append("<li><a href=\"javascript:;\" onclick=\"zan(" + dtnew.Rows[0]["id"] + "," + Convert.ToInt32(Session["userid"].ToString()) + ")\" class=\"clear\"><s id=s" + dtnew.Rows[0]["id"] + " class=\"zan\"></s><span id=" + dtnew.Rows[0]["id"] + ">赞</span></a></li>");
                }

                ///触发评论 

                str.Append("<li><a href=\"#\" class=\"clear  pinglun\" onclick='pinglun(" + dtnew.Rows[0]["id"] + "," + userid + ")' ><s class=\"review\"></s><span>评论</span></a></li>");
                str.Append("</ul>");

                ///判断赞的人数
                string sqlzan = "select count(*) as zancount from TM_UbindN  where NewsID='" + dtnew.Rows[0]["id"] + "' and IsZan='1' ";

                DataTable dtzan = DbHelperSQL.Query(sqlzan).Tables[0];
                if (dtzan.Rows.Count > 0)
                {
                    if (dtzan.Rows[0]["zancount"].ToString() != "0")
                    {

                        str.Append("<div class=\"num_zan clear\"><s class='old_zan'></s><span id=zan" + dtnew.Rows[0]["id"] + ">" + dtzan.Rows[0]["zancount"] + "</span><span>人觉得很赞</span></div>");
                    }
                    
                }

                str.Append("<ul id=ul" + dtnew.Rows[0]["id"] + " class=\"review_list\">");

                ///显示评论内容
                DataTable dtpinglun = pinglunbll.GetList(" NewsID=" + dtnew.Rows[0]["id"] + "  order by id desc").Tables[0];

                if (dtpinglun.Rows.Count > 0)
                {
                    for (int j = 0; j < dtpinglun.Rows.Count; j++)
                    {
                        DataTable dtuserpl = userinfobll.GetList(" id=" + dtpinglun.Rows[j]["UserID"]).Tables[0];

                        if (dtuserpl.Rows.Count > 0)
                        {
                            str.Append("<li class=\"clear\">");
                            str.Append("<div class=\"autho clear\">" + (dtuserpl.Rows[0]["sex"].ToString() == "女" ? "<s class=\"girl\"></s><span>" : "<s class=\"boy\"></s>") + "<span>" + dtuserpl.Rows[0]["username"] + "：</span></div>");
                            str.Append("<div class=\"con\">" + dtpinglun.Rows[j]["PContent"] + "</div>");
                            str.Append("</li>");

                        }
                    }
                }

                str.Append("</ul>");
                str.Append("<div class=\"more\"></div>");
                str.Append("</div>");
                str.Append("</div>");


            }


            return str.ToString();

        }

        /// <summary>
        /// 发布信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_fabu_Click(object sender, EventArgs e)
        {
            DTcms.BLL.WP_NewsInfo newsinfobll = new DTcms.BLL.WP_NewsInfo();

            DTcms.BLL.WP_UserInfo userinfobll = new DTcms.BLL.WP_UserInfo();

            DTcms.Model.WP_UserInfo userinfomodel = new DTcms.Model.WP_UserInfo();

            DTcms.Model.WP_NewsInfo newsinfomodel = new DTcms.Model.WP_NewsInfo();

            if (txt_fabiao.Value.Trim() != null)
            {
                newsinfomodel.Title = "未审核";
                newsinfomodel.NewsContent = txt_fabiao.Value;
                newsinfomodel.WriterID = Convert.ToInt32(Session["userid"].ToString());//用户id
                newsinfomodel.IsView = false;
                newsinfomodel.CreateDate = DateTime.Now;

                int i = newsinfobll.Add(newsinfomodel);
                if (i > 0)
                {

                    lit_show.Text = Show(newsid);
                }
                else
                {
                    Alert("发布失败！");
                }
            }

        }

        /// <summary>
        /// 评论新闻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_pinglun_Click(object sender, EventArgs e)
        {
            DTcms.BLL.WP_PingLun pinglunbll = new DTcms.BLL.WP_PingLun();

            DTcms.Model.WP_PingLun pinglunmodel = new DTcms.Model.WP_PingLun();

            if (txt_pinglun.Value.Trim() != null)
            {
                pinglunmodel.IsView = false;
                pinglunmodel.NewsID = int.Parse(btn_nids.Value);
                pinglunmodel.UserID = Convert.ToInt32(Session["userid"].ToString());//用户id
                pinglunmodel.PCreateDate = DateTime.Now;
                pinglunmodel.PContent = txt_pinglun.Value;
                pinglunmodel.ReMark = "未审核";

                bool b = pinglunbll.Add(pinglunmodel);
                if (b)
                {
                    txt_pinglun.Value = "";
                    lit_show.Text = Show(newsid);
                }
                else
                {
                    Alert("评论失败！");
                }

            }
            else
            {
                Alert("评论内容不能为空！");
            }
        }

        #region 弹出提示  +void Alert(string alert)
        /// <summary>
        /// 弹出提示
        /// </summary>
        /// <param name="alert"></param>
        private void Alert(string alert)
        {
            Response.Write("<script>alert('" + alert + "')</script>");
        }
        #endregion
    }
}