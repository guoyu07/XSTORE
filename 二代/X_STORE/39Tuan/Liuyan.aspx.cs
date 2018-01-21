using Tuan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.Weixin;

namespace Wx_NewWeb.Message
{
    public partial class Liuyan : weixinAuth
    {
        public int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            Chat chat = new Chat();
            DTcms.BLL.WP_UserInfo user = new DTcms.BLL.WP_UserInfo();
            DTcms.Model.WP_UserInfo usermodel = new DTcms.Model.WP_UserInfo();
           
            if (Request["openid"] != null&&Request["name"]!=null&&Request["sex"]!=null&&Request["headimg"]!=null)
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


                    string openid = Request["openid"].ToString();

                    DataTable dt1 = user.GetList(" openid='" + openid + "'").Tables[0];
                    if (dt1.Rows.Count > 0)
                    {

                        string name = Request["name"].ToString();
                        string sex = Request["sex"].ToString();
                        string headimgurl = Request["headimg"].ToString();
                       // Alert(HttpContext.Current.Request.Url.Query);
                        //Alert(sex);
                        //Alert(headimgurl);
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
                    //    try
                    //    {
                    //}
                    //catch (Exception ex)
                    //{
                    //    Response.Write(ex);
                        
                    //}
                    //string openid = chat.Openid("http://hongdou.creatrue.net/tuan/message/liuyan.aspx?wwx=gh_4891e4667327");
                   
                    

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
            }
           


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
                newsinfomodel.WriterID = Convert.ToInt32(Session["userid"].ToString());//用户id
                newsinfomodel.IsView = false;
                newsinfomodel.CreateDate = DateTime.Now;
                newsinfomodel.IsLiu = true;
                newsinfomodel.Title = "未审核";

                int i = newsinfobll.Add(newsinfomodel);
                if (i > 0)
                {
                    txt_fabiao.Value = "";
                }
                else
                {
                    Alert("发布失败！");
                }
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