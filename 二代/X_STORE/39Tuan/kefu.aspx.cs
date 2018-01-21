using Tuan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb
{
    public partial class kefu : System.Web.UI.Page
    {
        Chat chat = new Chat();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Request["openid"] != null)
                {
                    chat.wxid = 0;
                    string s = chat.access_token();

                    try
                    {
                     
                        JObject jo = (JObject)JsonConvert.DeserializeObject(kfhao(s));

                        JArray jo2 = JArray.Parse(jo["kf_online_list"].ToString());

                        int auto1 = Convert.ToInt32(jo2[0]["auto_accept"].ToString());
                        int bi = 0;
                        int j = 0;
                        int case1 = Convert.ToInt32(jo2[0]["accepted_case"].ToString());
                        int count1 = auto1 - case1;
                        bi = count1;
                        for (int i = 1; i < jo2.Count; i++)
                        {

                            //  int case2 = Convert.ToInt32((i == jo2.Count - 1 ? jo2[i]["accepted_case"].ToString() : jo2[i + 1]["accepted_case"].ToString()));

                            //  int auto2 = Convert.ToInt32((i == jo2.Count - 1 ? jo2[i]["auto_accept"].ToString() : jo2[i + 1]["auto_accept"].ToString()));
                            int case2 = Convert.ToInt32(jo2[i]["accepted_case"].ToString());
                            int auto2 = Convert.ToInt32(jo2[i]["auto_accept"].ToString());
                            int count2 = auto2 - case2;
                            if (bi >= count2)
                            {
                                if (bi == count1)
                                {
                                    j = 0;
                                }
                                else
                                {
                                    j = i;
                                }
                            }
                            else
                            {
                                bi = count2;
                                j = i;
                            }

                        }
                        JObject jsms = (JObject)JsonConvert.DeserializeObject(SMS(Request["openid"], s, jo2[j]["kf_account"].ToString()));


                        if (Convert.ToInt32(jsms["errcode"].ToString()) <= 0)
                        {

                            Response.Write("<script>alert('连接客服" + jo2[j]["kf_id"].ToString() + "号成功！');</script>");

                        }
                        else
                        {
                            Response.Write("<script>alert('系统出错，请稍后重试！');</script>");
                        }


                    }
                    catch (Exception ex)
                    {
                  
                        Response.Write("<script>alert('当前没有客服在线！请稍后再试！');</script>");
                        close.Value = "返回公众号菜单";
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

         
        }

        protected string SMS(string openid, string token, string kfaccount)
        {
            StringBuilder url = new StringBuilder();

            url.Append("https://api.weixin.qq.com/customservice/kfsession/create?access_token=" + token + "");


            string param = "";

            param = "{\"kf_account\" : \"" + kfaccount + "\",    \"openid\" : \"" + openid + "\",    \"text\" : \"你好！\" }";
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(param); // 转化   
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
                webRequest.Method = "POST";
                webRequest.ContentType = "text/xml";
                webRequest.ContentLength = byteArray.Length;

                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length); //写入参数   

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);

                //Response.Write(sr.ReadToEnd());
                newStream.Close();
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 获取客服号
        protected string kfhao(string token)
        {


            string ul = "https://api.weixin.qq.com/cgi-bin/customservice/getonlinekflist?access_token=" + token + "";

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