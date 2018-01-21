using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.DBUtility;
using Tuan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using tdx.Weixin;
using System.IO;

namespace Wx_NewWeb.Message
{
    public partial class ReviewList : weixinAuth
    {
        public int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            Chat chat = new Chat();
            DTcms.BLL.WP_UserInfo user = new DTcms.BLL.WP_UserInfo();
            DTcms.Model.WP_UserInfo usermodel = new DTcms.Model.WP_UserInfo();

            if (Request["openid"] != null && Request["name"] != null && Request["sex"] != null && Request["headimg"] != null)
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

                    string openid = Request["openid"].ToString();
               
              
                        DataTable dt1 = user.GetList(" openid='" + openid + "'").Tables[0];
                        if (dt1.Rows.Count > 0)
                        {
                            string name = Request["name"].ToString();
                            string sex = Request["sex"].ToString();
                            string headimgurl = Request["headimg"].ToString();

                            usermodel.id = Convert.ToInt32(dt1.Rows[0]["id"].ToString());
                            usermodel.openid = openid;
                            usermodel.sex = sex;
                            usermodel.username = name;
                            usermodel.remark = headimgurl;
                            bool i = user.Update(usermodel);
                            if (i)
                            {

                                userid = Convert.ToInt32(dt1.Rows[0]["id"].ToString());
                                Session["userid"] = userid;

                            }
                            else
                            {
                                Alert("网络异常，请重新登陆页面！");
                            }
                        }
                        else
                        {


                                string name = Request["name"].ToString();
                            string sex = Request["sex"].ToString();
                            string headimgurl = Request["headimg"].ToString();

                            usermodel.openid = openid;
                            usermodel.sex = sex;
                            usermodel.username = name;
                            usermodel.remark = headimgurl;
                            int i = user.Add(usermodel);
                            if (i > 0)
                            {
                                lit_show.Text = Shows();
                                DataTable dt = user.GetList(" openid='" + openid + "'").Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    userid = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                                    Session["userid"] = userid;
                                }
                                else
                                {
                                    Alert("网络异常，请重新登陆页面！");
                                }
                            }
                            else
                            {
                                Alert("网络异常，请重新登陆页面！");
                            }
                        }
                    

                }

            }
            else
            {
                string str = HttpContext.Current.Request.Url.AbsolutePath;
                string strs = Path.GetFileName(str);
                string url = HttpContext.Current.Request.Url.Query;
                if (url.Equals(""))
                    url = "?1+1";
                Response.Redirect("TestGetInfo.aspx?back_url=" + (strs + url));
            }

            lit_show.Text = Shows();
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Shows()
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
            DataTable dtnew = newsinfobll.GetList(" isliu=0 order by CreateDate desc").Tables[0];

            if (dtnew.Rows.Count > 0)
            {
                for (int i = 0; i < dtnew.Rows.Count; i++)
                {
                    //获取用户信息
                    DataTable dtuser = userinfobll.GetList("  id=" + dtnew.Rows[i]["WriterID"]).Tables[0];

                    if (dtuser.Rows.Count > 0)
                    {
                        str.Append("<div class=\"box box_shadow\">");
                        str.Append("<div class=\"box_padd\">");
                        str.Append("<div class=\"autho clear\">" + (dtuser.Rows[0]["sex"].ToString() == "女" ? "<s class=\"girl\"></s><span>" : "<s class=\"boy\"></s><span>") + "" + dtuser.Rows[0]["username"] + "</span></div>");
                    }
                    DateTime time = (DateTime)dtnew.Rows[i]["CreateDate"];
                    str.Append("<div class=\"time\">" + time.ToString("yyyy-MM-dd") + "</div>");
                    str.Append("<div class=\"cont\">" + dtnew.Rows[i]["NewsContent"] + "</div>");
                    str.Append("<ul class=\"operating clear\">");
                    str.Append("<li><a href=\"#\" onclick='fenxiang()' class=\"clear\"><s class=\"share\"></s><span>分享</span></a></li>");

                    //赞或已赞
                    DataTable dtubindn = ubindnbll.GetList("  UserID=" + Convert.ToInt32(Session["userid"].ToString()) + " and NewsID=" + dtnew.Rows[i]["id"]).Tables[0];

                    if (dtubindn.Rows.Count > 0)
                    {

                        str.Append("<li><a href=\"javascript:;\" onclick=\"zan(" + dtnew.Rows[i]["id"] + "," + Convert.ToInt32(Session["userid"].ToString()) + ")\" class=\"clear\">" + (dtubindn.Rows[0]["IsZan"].ToString().Equals("True") ? "<s id=s" + dtnew.Rows[i]["id"] + " class=\"old_zan\"></s>" : "<s id=s" + dtnew.Rows[i]["id"] + " class=\"zan\"></s>") + "<span id=" + dtnew.Rows[i]["id"] + ">" + (dtubindn.Rows[0]["IsZan"].ToString().Equals("True") ? "已赞" : "赞") + "</span></a></li>");
                    }
                    else
                    {
                        str.Append("<li><a href=\"javascript:;\" onclick=\"zan(" + dtnew.Rows[i]["id"] + "," + Convert.ToInt32(Session["userid"].ToString()) + ")\" class=\"clear\"><s id=s" + dtnew.Rows[i]["id"] + " class=\"zan\"></s><span id=" + dtnew.Rows[i]["id"] + ">赞</span></a></li>");
                    }

                    ///触发评论 

                    str.Append("<li><a href=\"#\" class=\"clear  pinglun\" onclick='pinglun(" + dtnew.Rows[i]["id"] + "," + userid + ")' ><s class=\"review\"></s><span>评论</span></a></li>");
                    str.Append("</ul>");

                    ///判断赞的人数
                    string sqlzan = "select count(*) as zancount from TM_UbindN  where NewsID='" + dtnew.Rows[i]["id"] + "' and IsZan='1' ";

                    DataTable dtzan = DbHelperSQL.Query(sqlzan).Tables[0];
                    if (dtzan.Rows.Count > 0)
                    {
                        if (dtzan.Rows[0]["zancount"].ToString() != "0")
                        {

                            str.Append("<div class=\"num_zan clear\"><s class='old_zan'></s><span id=zan" + dtnew.Rows[i]["id"] + ">" + dtzan.Rows[0]["zancount"] + "</span><span>人觉得很赞</span></div>");
                        }
                        

                    }

                    str.Append("<ul id=ul"+dtnew.Rows[i]["id"]+" class=\"review_list\">");

                    ///显示评论内容
                    DataTable dtpinglun = pinglunbll.GetList(5, " NewsID=" + dtnew.Rows[i]["id"]+"", " id  desc").Tables[0];

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

                    ///评论个数
                    string plcountsql = "select count(*) as plcount from TM_PingLun  where NewsID='" + dtnew.Rows[i]["id"] + "'";

                    DataTable dtpingluncount = DbHelperSQL.Query(plcountsql).Tables[0];

                    if (dtpingluncount.Rows.Count > 0)
                    {
                        if ((int.Parse(dtpingluncount.Rows[0]["plcount"].ToString()) - 5) > 0)
                        {
                            str.Append("<div class=\"more\"><a href=\"ReviewContent.aspx?newsid=" + dtnew.Rows[i]["id"] + "\">查看剩余" + (int.Parse(dtpingluncount.Rows[0]["plcount"].ToString()) - 5) + "条评论>></a></div>");
                        }
                        else
                        {
                            str.Append("<div class=\"more\"></div>");
                        }
                    }

                    str.Append("</div>");
                    str.Append("</div>");

                }
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
                newsinfomodel.Title = "";
                newsinfomodel.NewsContent = txt_fabiao.Value;
                newsinfomodel.WriterID =Convert.ToInt32(Session["userid"].ToString());//用户id
                newsinfomodel.IsView = false;
                newsinfomodel.CreateDate = DateTime.Now;
                newsinfomodel.Title = "未审核";

                int i = newsinfobll.Add(newsinfomodel);
                if (i > 0)
                {
                    lit_show.Text = Shows();
                    txt_fabiao.Value = "";
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
                    lit_show.Text = Shows();
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