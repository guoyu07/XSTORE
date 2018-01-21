using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data.SqlClient;
using System.Text;
using Creatrue.kernel;
using System.Data;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace tdx.memb.man.weixinmoni
{
    public class WeiXinRetInfo//保存登录失败微信公众平台网页返回的信息
    {
        public string Ret { get; set; }
        public string ErrMsg { get; set; }
        public string ShowVerifyCode { get; set; }
        public string ErrCode { get; set; }
    }
    public class WeiXinYulan
    {
        public string ret { get; set; }
        public string msg { get; set; }
        public string appMsgId { get; set; }
        public string fakeid { get; set; }
    }
    public partial class WeiXinMoNi : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void select_value(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alert('你选择了分组ID是" + fenzu.SelectedValue + "');</script>");
            //根据选择的分组ID 进行筛选


        }
        protected void ShuxinWeixin(object sender, EventArgs e)
        {
            ListItem li = fenzu.SelectedItem;
            List<SingleGroup> allgroupdata = new List<SingleGroup>();
            Dictionary<string, ListItem> dsl = (Dictionary<string, ListItem>)Session["weixinlistitem"];
            weixinfun.getEachGroupInfo(li.Value, dsl[li.Value].Value, dsl[li.Value].Text, ref allgroupdata);
            StringBuilder nr = new StringBuilder();
            string _wid = Session["wid"].ToString();
            foreach (SingleGroup sin in allgroupdata)
            {

                for (int i = 0; i < sin.groupdata.Count; i++)
                {

                    nr.Append(string.Format("@fake_id={0},@nick_name={1},@remark_name={2},@group_id={3}\n", sin.groupdata[i]["id"].ToString(), sin.groupdata[i]["nick_name"].ToString(), sin.groupdata[i]["remark_name"].ToString(), sin.group_name));
                    SqlParameter[] paras = new SqlParameter[] { 
                                  new SqlParameter("@fake_id", sin.groupdata[i]["id"].ToString()),
                                  new SqlParameter("@nick_name",  sin.groupdata[i]["nick_name"].ToString()),
                                  new SqlParameter("@remark_name", sin.groupdata[i]["remark_name"].ToString()),
                                  new SqlParameter("@group_name", sin.group_name),
                                  new SqlParameter("@cityID", _wid) 
                                  };



                    string cmdstr0 = "select *from wx_userInfo where fake_id='" + sin.groupdata[i]["id"].ToString().Trim() + "' and cityID=" + _wid;
                    DataTable dt = comfun.GetDataTableBySQL(cmdstr0);
                    comfun cm = new comfun();
                    if (dt.Rows.Count > 0)
                    {
                        string gengxin = "Update wx_userInfo  set nick_name =@nick_name,remark_name=@remark_name,group_name=@group_name where fake_id=@fake_id, cityID=@cityID";
                        cm.ExecuteNonQuery(gengxin, paras);
                    }
                    else
                    {
                        string cmdstr = "insert into wx_userInfo values(@fake_id,@nick_name,@remark_name,@group_name,'',@cityID,'')";
                        cm.ExecuteNonQuery(cmdstr, paras);
                    }
                    //cmd0.CommandText = cmdstr0;

                    //if (cmd0.ExecuteScalar() == null)
                    //{

                    //    string cmdstr = "insert into t_UserData values(@fake_id,@nick_name,@remark_name,@group_id,'" + DBNull.Value + "',1)";
                    //    cmd.CommandText = cmdstr;
                    //    updatesum += cmd.ExecuteNonQuery();


                    //}
                    //cmd.Parameters.Clear();

                }
            }
            //  html.Value = nr.ToString();
        }
        protected void send(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(weixinming.Text.ToString()))
            //{
            //    Response.Write("<script language='javascript'>alert('微信号不能为空');</script>");
            //    return;
            //}
            //if (Request["wz"] != null && string.IsNullOrEmpty(Request["wz"].ToString()))
            //{
            //    Response.Write("<script language='javascript'>alert('请选择图文');</script>");
            //    return;
            //}
        }
        protected void login(object sender, EventArgs e)
        {
            // html.Value = "";
            if (ExecLogin(zhanghao.Text.Trim(), mima.Text.Trim()))
            {

                Response.Write("<script language='javascript'>alert('登陆成功');</script>");
                List<SingleGroup> allgroupdata = new List<SingleGroup>();

                ListItemCollection lic = new ListItemCollection();
                weixinfun.getGroupInfo(ref lic);
                fenzu.Items.Clear();
                foreach (ListItem li in lic)
                {
                    fenzu.Items.Add(li);
                }
                if (fenzu.Items.Count > 0)
                {
                    anniu.Text = " <input type=\"Button\" id =\"shuaxina\" name=\"shuax\"  class=\"btnGreen\"  value=\"刷新该分组\"  onclick=\"wxselectChange('#fenzu')\"/><br/>";
                }
                //<input type=\"Button\" id =\"tuwenxinxi\" name=\"shuax\"  value=\"更新图文信息\"  onclick=\"wxGetimage('#html')\"/>
                ////////////////////


                //独立图文
                mingzi.Text = "请输入微信号:";
                //fasong.Visible = true;
                //weixinming.Visible = true;
                anniu.Text += "<input type=\"Button\" id =\"tuwenxinxi\" name=\"shuax\"  class=\"btnGreen\"  value=\"展示图文信息列表\"  onclick=\"GettwList('#neirong')\"/><br/>";

            }
            else
            {


                // MessageBox.Show("错误代码：" + WeiXinLogin.LoginInfo.Err, "温馨提示");
                mima.Text = LoginInfo.Err;

                //"-1":"系统错误。 
                //"-2":"帐号或密码错误 
                //"-3":"密码错误。" 
                //"-4":"不存在该帐户。" 
                //"-5":"访问受限。" 
                //"-6":"需要输入验证码" 
                //"-7":"此帐号已绑定私人微信号，不可用于公众平台登录。" 
                //"-8":"邮箱已存在。" 
                //"-32":"验证码输入错误" 
                //"-200":n="因频繁提交虚假资料，该帐号被拒绝登录。" 
                //"-94":"请使用邮箱登陆。" 
                //"10":"该公众会议号已经过期，无法再登录使用。" 
                //"65201":"65202":"成功登陆，正在跳转..." 
                //"0":n="成功登陆，正在跳转..." 
                //default："未知的返回。" 

            }

        }
        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string GetMd5Str32(string str) //MD5摘要算法
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.  
            char[] temp = str.ToCharArray();
            byte[] buf = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                buf[i] = (byte)temp[i];
            }
            byte[] data = md5Hasher.ComputeHash(buf);
            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data   
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.  
            return sBuilder.ToString();
        }

        public bool ExecLogin(string name, string pass)//登陆微信公众平台函数
        {

            bool result = false;

            string password = GetMd5Str32(pass).ToUpper();

            string padata = "username=" + name + "&pwd=" + password + "&imgcode=&f=json";

            //  string url = "http://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN ";//请求登录的URL
            string url = WeiXinUrl.Denlu_Url;

            try
            {

                CookieContainer cc = new CookieContainer();//接收缓存

                byte[] byteArray = Encoding.UTF8.GetBytes(padata); // 转化

                HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);  //新建一个WebRequest对象用来请求或者响应url

                webRequest2.CookieContainer = cc;                                      //保存cookie  

                webRequest2.Method = "POST";                                          //请求方式是POST

                webRequest2.ContentType = "application/x-www-form-urlencoded";       //请求的内容格式为application/x-www-form-urlencoded

                webRequest2.ContentLength = byteArray.Length;

                // webRequest2.Referer = "https://mp.weixin.qq.com/";
                webRequest2.Referer = WeiXinUrl.DenluLaiyuanUrl;

                Stream newStream = webRequest2.GetRequestStream();           //返回用于将数据写入 Internet 资源的 Stream。

                // Send the data.

                newStream.Write(byteArray, 0, byteArray.Length);    //写入参数

                newStream.Close();

                HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();

                StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);

                string text2 = sr2.ReadToEnd();

                //此处用到了newtonsoft来序列化

                LoginInfo.Err = text2;
                //{"base_resp":{"ret":0,"err_msg":"ok"},"redirect_url":"\/cgi-bin\/home?t=home\/index&lang=zh_CN&token=136331741"}
                // WeiXinRetInfo retinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<WeiXinRetInfo>(text2);


                string token = string.Empty;


                if (text2.Length > 0)
                {

                    if (text2.Contains("&token="))
                    {

                        token = text2.Split(new char[] { '&' })[2].Split(new char[] { '=' })[1].ToString().Replace("\"}", "").ToString();//取得token

                        Session["weixinCookie"] = cc;
                        //LoginInfo.LoginCookie = cc;
                        Session["weixincreateDate"] = DateTime.Now;
                        // LoginInfo.CreateDate = DateTime.Now;
                        Session["weixinToken"] = token;
                        //  LoginInfo.Token = token;

                        result = true;

                    }

                    else
                    {


                        result = false;

                    }

                }

                //if (retinfo.ErrMsg.Length > 0)
                //{

                //    if (retinfo.ErrMsg.Contains("ok"))
                //    {

                //        token = retinfo.ErrMsg.Split(new char[] { '&' })[2].Split(new char[] { '=' })[1].ToString();//取得token

                //        Session["weixinCookie"] = cc;
                //        //LoginInfo.LoginCookie = cc;
                //        Session["weixincreateDate"] = DateTime.Now;
                //        // LoginInfo.CreateDate = DateTime.Now;
                //        Session["weixinToken"] = token;
                //        //  LoginInfo.Token = token;

                //        result = true;

                //    }

                //    else
                //    {


                //        result = false;

                //    }

                //}
                response2.Close();
                webRequest2.Abort();

            }

            catch (Exception ex)
            {


                throw new Exception(ex.StackTrace);

            }
            finally
            {

            }

            return result;

        }

    }
    public static class LoginInfo//保存登陆后返回的信息
    {

        /// <summary>

        /// 登录后得到的令牌

        /// </summary>        

        public static string Token { get; set; }

        /// <summary>

        /// 登录后得到的cookie

        /// </summary>

        public static CookieContainer LoginCookie { get; set; }

        /// <summary>

        /// 创建时间

        /// </summary>

        public static DateTime CreateDate { get; set; }


        public static string Err { get; set; }



    }
}