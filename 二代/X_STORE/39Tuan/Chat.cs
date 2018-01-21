using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using DTcms.DBUtility;

namespace Tuan
{
    /// <summary>
    /// 2015.6.15 封装该类
    /// 用于获取appid 、 secret、access_token 的值
    /// &Vincene  
    /// </summary>
    public class Chat
    {
        public int wxid { get; set; }

        
        #region  1.0 获取appid  + string appid()
        /// <summary>
        ///   获取appid
        /// </summary>
        /// <returns></returns>
        public string appid()
        {
            string sqlgetapp = "";
            if (wxid == 0)
            {
                sqlgetapp = "select * from wx_mp";
            }
            else {
                sqlgetapp = "select * from wx_mp where id="+wxid+"";
            }
            
            DataTable dtgetapp = DbHelperSQL.Query(sqlgetapp).Tables[0];
            if (dtgetapp.Rows.Count > 0)
            {
                return dtgetapp.Rows[0]["wx_DID"].ToString();

            }
            else
            {
                return "该微信号未启用！";
            }

        }
        #endregion

        #region 2.0 获取secret + string secret()
        /// <summary>
        /// 获取secret
        /// </summary>
        /// <returns></returns>
        public string secret()
        {
            string sqlgetapp = "";
            if (wxid == 0)
            {
                sqlgetapp = "select * from wx_mp";
            }
            else
            {
                sqlgetapp = "select * from wx_mp where id=" + wxid + "";
            }
         
            DataTable dtgetapp = DbHelperSQL.Query(sqlgetapp).Tables[0];
            if (dtgetapp.Rows.Count > 0)
            {
                return dtgetapp.Rows[0]["wx_Dpsw"].ToString();

            }
            else
            {
                return "该微信号未启用！";
            }
        }
        #endregion

        #region  3.0 获取access_token  + string access_token()
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <returns></returns>
        public string access_token()
        {
            string tokenget = String.Empty;
            string gettoken = String.Empty;
            string sqlselendtime = "";
            if (wxid == 0)
            {
                sqlselendtime = "select * from TM_token";
            }
            else
            {
                sqlselendtime = "select * from TM_token where id=" + wxid + "";
            }
           

            int endtime = Convert.ToInt32((((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000) + 7000));

            int nowtime = Convert.ToInt32(((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000));

            DataTable dtselendtime = DbHelperSQL.Query(sqlselendtime).Tables[0];

            if (dtselendtime.Rows.Count > 0)
            {
                if (nowtime >= Convert.ToInt32(dtselendtime.Rows[0]["endtime"]))
                {
                    tokenget = token(appid(), secret());

                    JObject jo2 = (JObject)JsonConvert.DeserializeObject(tokenget);

                    string updateendtime = "update TM_token set access_token='" + jo2["access_token"].ToString() + "',endtime=" + endtime + " where wxid="+wxid+"";

                    int i = DbHelperSQL.ExecuteSql(updateendtime);
                    gettoken = jo2["access_token"].ToString();
                    if (i > 0)
                    {
                        gettoken = jo2["access_token"].ToString();
                        // HttpContext.Current.Response.Write("修改成功");
                    }
                }
                else
                {
                    gettoken = dtselendtime.Rows[0]["access_token"].ToString();
                }

            }
            else
            {
                tokenget = token(appid(), secret());

                JObject jo2 = (JObject)JsonConvert.DeserializeObject(tokenget);

                string inserttoken = "insert into TM_token (access_token,endtime,wxid) values('" + jo2["access_token"].ToString() + "'," + endtime + ","+wxid+")";

                int i = DbHelperSQL.ExecuteSql(inserttoken);
                gettoken = jo2["access_token"].ToString();
                if (i > 0)
                {
                    gettoken = jo2["access_token"].ToString();
                    //   HttpContext.Current.Response.Write("插入成功");
                }
            }


            return gettoken;
        }
        #endregion

        #region 4.0 获取Openid + string Openid(string redirect_uri)
        /// <summary>
        /// 获取Openid
        /// </summary>
        /// <param name="redirect_uri"></param>
        /// <returns></returns>
        public string Openid(string redirect_uri)
        {
            string code = String.Empty;
            string openid = String.Empty;
            if (HttpContext.Current.Request["code"] != null)
            {
                if (HttpContext.Current.Session["code"] != null && HttpContext.Current.Session["code"].ToString() == HttpContext.Current.Request["code"].ToString())
                {
                    GetCode(redirect_uri);
                }
                else
                {
                    code = HttpContext.Current.Request["code"].ToString();
                    openid = getoneopenid(code, appid(), secret());
                }
            }
            if (openid != null)
            {
                JObject jo2 = (JObject)JsonConvert.DeserializeObject(openid);

                return jo2["openid"].ToString();
            }
            else
            {
                return "";
            }

        }

        #endregion

        #region 5.0 获取WeChatUserInfo + string WeChatUserInfo(string redirect_uri)
        /// <summary>
        /// 获取WeChatUserInfo
        /// </summary>
        /// <param name="redirect_uri"></param>
        /// <returns></returns>
        public string WeChatUserInfo(string redirect_uri)
        {
            return getuserinfo(access_token(), Openid(redirect_uri));
        }
        #endregion

        #region 获取GetCode
        /// <summary>
        ///  获取GetCode
        /// </summary>
        public void GetCode(string redirect_uri)
        {
            string _url = "";

            _url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appid() + "&redirect_uri=" + redirect_uri + "&response_type=code&scope=snsapi_base&state=1#wechat_redirect";

            HttpContext.Current.Response.Redirect(_url);
        }
        #endregion

        #region 获取token
        public string token(string appid, string secret)
        {
            string ul = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret + "";

            string r = string.Empty;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(ul.ToString());
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //从Internet资源返回数据流
            Stream webStream = webResponse.GetResponseStream();
            //读取数据流
            StreamReader webStreamReader = new StreamReader(webStream, System.Text.Encoding.UTF8);
            //读取数据
            r = webStreamReader.ReadToEnd();
            webStreamReader.Close();
            webStream.Close();
            webResponse.Close();

            return r;


        }
        #endregion

        #region 获取单个openid
        public string getoneopenid(string code, string appid, string secret)
        {
            string ul = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + secret + "&code=" + code + "&grant_type=authorization_code";
            string r = string.Empty;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(ul.ToString());
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //从Internet资源返回数据流
            Stream webStream = webResponse.GetResponseStream();
            //读取数据流
            StreamReader webStreamReader = new StreamReader(webStream, System.Text.Encoding.UTF8);
            //读取数据
            r = webStreamReader.ReadToEnd();
            webStreamReader.Close();
            webStream.Close();
            webResponse.Close();

            return r;

        }
        #endregion

        #region 获取用户基本信息
        public string getuserinfo(string access_token, string openid)
        {
            string ul = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + access_token + "&openid=" + openid + "";

            string r = string.Empty;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(ul.ToString());
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //从Internet资源返回数据流
            Stream webStream = webResponse.GetResponseStream();
            //读取数据流
            StreamReader webStreamReader = new StreamReader(webStream, System.Text.Encoding.UTF8);
            //读取数据
            r = webStreamReader.ReadToEnd();
            webStreamReader.Close();
            webStream.Close();
            webResponse.Close();

            return r;
        }
        #endregion


    }
}
