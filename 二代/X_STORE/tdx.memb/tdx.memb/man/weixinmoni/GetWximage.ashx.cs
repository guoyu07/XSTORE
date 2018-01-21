using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Net;
using System.IO;
using System.Text;
using Creatrue.kernel;

namespace tdx.memb.man.weixinmoni
{
    /// <summary>
    /// GetWximage 的摘要说明
    /// </summary>
    public class GetWximage : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {

                CookieContainer cookie = null;
                string token = null;
                //cookie = WeiXinLogin.LoginInfo.LoginCookie;//取得cookie
                //token = WeiXinLogin.LoginInfo.Token;//取得token
                if (HttpContext.Current.Session["weixinCookie"] != null)
                {
                    cookie = (CookieContainer)HttpContext.Current.Session["weixinCookie"];
                }
                else
                {
                    throw new Exception("请登陆");
                }
                if (HttpContext.Current.Session["weixinToken"] != null)
                {
                    token = HttpContext.Current.Session["weixinToken"].ToString();
                }
                else
                {
                    throw new Exception("请登录");
                }
                /* 1.token此参数为上面的token 2.pagesize此参数为每一页显示的记录条数

                3.pageid为当前的页数，4.groupid为微信公众平台的用户分组的组id*/
                string Url = "https://mp.weixin.qq.com/cgi-bin/appmsg?begin=0&count=1000&t=media/appmsg_list&type=10&action=list&token=" + token + "&lang=zh_CN";
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);//Url为获取用户信息的链接
                webRequest.CookieContainer = cookie;
                webRequest.ContentType = "text/html; charset=UTF-8";
                webRequest.Method = "GET";
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string text = sr.ReadToEnd();

                ///////////保存文档
                string filename = consts.uploadPath + "/weixin/" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + ".txt";
                FileStream tempStream = new FileStream(context.Server.MapPath(filename), FileMode.Create);
                StreamWriter writer = new StreamWriter(tempStream);
                writer.WriteLine(text);
                writer.Close();
                tempStream.Close();
                context.Response.Write("更新成功");
                //MatchCollection mc;
                //Regex Rex = new Regex(@"(?<=\{""item"":).+(?=,""file_cnt"":)");
                //mc = Rex.Matches(text);
                //JArray ImgandTxt = new JArray();
                //Dictionary<string, List<Tuwen>> tuwenlist = new Dictionary<string, List<Tuwen>>();
                //tuwenlist.Clear();
                //if (mc.Count != 0)
                //{
                //    for (int i = 0; i < mc.Count; i++)
                //    {
                //        ImgandTxt = (JArray)JsonConvert.DeserializeObject(mc[i].Value);
                //    }
                //}
                //if (ImgandTxt.Count > 0)
                //{
                //    //开始处理信息
                //    if (context.Session["wid"] != null)
                //    {
                //        string _wid = context.Session["wid"].ToString();

                //        List<Tuwen> lts = new List<Tuwen>();
                //        System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);
                //        try
                //        {
                //            oracleConnection.Open();
                //            for (int i = 0; i < ImgandTxt.Count; i++)  //第一层  图文组数
                //            {
                //                string appid = ImgandTxt[i]["app_id"].ToString();//取组号


                //                for (int j = 0; j < (ImgandTxt[i]["multi_item"]).Count(); j++)
                //                {

                //                    SqlParameter[] paras = new SqlParameter[] { 
                //                  new SqlParameter("@cno", "000"),
                //                  new SqlParameter("@title", (ImgandTxt[i]["multi_item"])[j]["title"].ToString()),
                //                  new SqlParameter("@cover", (ImgandTxt[i]["multi_item"])[j]["cover"].ToString()),
                //                  new SqlParameter("@digest", (ImgandTxt[i]["multi_item"])[j]["digest"].ToString()),
                //                  new SqlParameter("@content_url", (ImgandTxt[i]["multi_item"])[j]["content_url"].ToString().Replace("&amp;", "&")),
                //                  new SqlParameter("@author",(ImgandTxt[i]["multi_item"])[j]["author"].ToString()),
                //                  new SqlParameter("@source_url", (ImgandTxt[i]["multi_item"])[j]["source_url"].ToString()),
                //                  new SqlParameter("@file_id", (ImgandTxt[i]["multi_item"])[j]["file_id"].ToString()),
                //                  new SqlParameter("@cityID", _wid),
                //                     new SqlParameter("@app_id", appid)
                //                  };
                //                    string cmdstr0 = "select * from B2C_tmsg where file_id='" + (ImgandTxt[i]["multi_item"])[j]["file_id"].ToString() + "' and cityID=" + _wid;
                //                    System.Data.SqlClient.SqlCommand cmdql = new System.Data.SqlClient.SqlCommand(cmdstr0, oracleConnection);
                //                    System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter(cmdql);
                //                    System.Data.DataSet dataSet = new System.Data.DataSet();


                //                    dataAdapter.Fill(dataSet);
                //                    DataTable dt = dataSet.Tables[0];


                //                    //  = comfun.GetDataTableBySQL(cmdstr0);
                //                    if (dt.Rows.Count == 0)
                //                    {
                //                        string nrs = "insert into B2C_tmsg (cno,t_title,t_author,t_source,t_gif,t_url,t_des,app_id,file_id,cityID)values(@cno,@title,@author,@source_url,@cover,@content_url,@digest,@app_id,@file_id,@cityID)";
                //                        //comfun con = new comfun();
                //                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(nrs, oracleConnection);
                //                        cmd.Parameters.AddRange(paras);
                //                        cmd.CommandType = CommandType.Text;
                //                        cmd.ExecuteNonQuery();
                //                        //  con.ExecuteNonQuery(nrs, paras);

                //                    }




                //                    //处理里面的一层个数
                //                    //Tuwen tw = new Tuwen();
                //                    //tw.cover = (ImgandTxt[i]["multi_item"])[j]["cover"].ToString();
                //                    //tw.title = (ImgandTxt[i]["multi_item"])[j]["title"].ToString();
                //                    //tw.digest = (ImgandTxt[i]["multi_item"])[j]["digest"].ToString();
                //                    //tw.content_url = (ImgandTxt[i]["multi_item"])[j]["content_url"].ToString().Replace("&amp;", "&");
                //                    //tw.author = (ImgandTxt[i]["multi_item"])[j]["author"].ToString();
                //                    //tw.source_url = (ImgandTxt[i]["multi_item"])[j]["source_url"].ToString();
                //                    //tw.file_id = (ImgandTxt[i]["multi_item"])[j]["file_id"].ToString();

                //                    //lts.Add(tw);
                //                }
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            throw new NotSupportedException(ex.Message);
                //        }
                //        finally
                //        {
                //            oracleConnection.Close();
                //        }
                //        //tuwenlist.Add(appid, lts);

                //        //if (tuwenlist.Count > 0)
                //        //{
                //        //    //数据库查询

                //        //foreach (string ke in tuwenlist.Keys)
                //        //{
                //        //    for (int k = 0; k < tuwenlist[ke].Count; k++)
                //        //    {

                //        //        SqlParameter[] paras = new SqlParameter[] { 
                //        //  new SqlParameter("@cno", "000"),
                //        //  new SqlParameter("@title", tuwenlist[ke][k].title),
                //        //  new SqlParameter("@cover", tuwenlist[ke][k].cover),
                //        //  new SqlParameter("@digest", tuwenlist[ke][k].digest),
                //        //  new SqlParameter("@content_url", tuwenlist[ke][k].content_url),
                //        //  new SqlParameter("@author", tuwenlist[ke][k].author),
                //        //  new SqlParameter("@source_url", tuwenlist[ke][k].source_url),
                //        //  new SqlParameter("@file_id", tuwenlist[ke][k].file_id),
                //        //  new SqlParameter("@cityID", _wid),
                //        //     new SqlParameter("@app_id", ke)
                //        //  };
                //        //        string cmdstr0 = "select * from B2C_tmsg where file_id='" + tuwenlist[ke][k].file_id + "' and cityID=" + _wid;
                //        //        DataTable dt = comfun.GetDataTableBySQL(cmdstr0);
                //        //        if (dt.Rows.Count == 0)
                //        //        {
                //        //            string nrs = "insert into B2C_tmsg (cno,t_title,t_author,t_source,t_gif,t_url,t_des,app_id,file_id,cityID)values(@cno,@title,@author,@source_url,@cover,@content_url,@digest,@app_id,@file_id,@cityID)";
                //        //            comfun con = new comfun();
                //        //            con.ExecuteNonQuery(nrs, paras);

                //        //        }
                //        //    }
                //        //}
                //        //开始替换文章链接
                //        string cmdstrwz = "select * from B2C_tmsg where  cno='000' and  t_utl<>='' and cityID=" + _wid;
                //        DataTable dtwz = comfun.GetDataTableBySQL(cmdstrwz);
                //        if (dtwz.Rows.Count > 0)
                //        {
                //            //
                //            for (int i = 0; i < dtwz.Rows.Count; i++)
                //            {
                //                string Urlwz = dtwz.Rows[i]["t_url"].ToString();
                //                HttpWebRequest webRequestwz = (HttpWebRequest)WebRequest.Create(Urlwz);//Url为获取用户信息的链接
                //                webRequestwz.ContentType = "text/html; charset=UTF-8";
                //                webRequestwz.Method = "GET";
                //                webRequestwz.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                //                webRequestwz.ContentType = "application/x-www-form-urlencoded";
                //                HttpWebResponse responsewz = (HttpWebResponse)webRequestwz.GetResponse();
                //                StreamReader srwz = new StreamReader(responsewz.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                //                string textwz = srwz.ReadToEnd();
                //                int bodyf = textwz.IndexOf("<body id=\"activity-detail\">");
                //                textwz = textwz.Remove(0, bodyf);
                //                int bodye = textwz.LastIndexOf("</body>");
                //                textwz = textwz.Remove(bodye);
                //                ///然后取出DIV
                //                int divs = textwz.IndexOf("<div id=\"page-content\" class=\"page-content\">");
                //                textwz = textwz.Remove(0, divs);
                //                textwz = "<body>" + textwz;
                //                int pf = textwz.LastIndexOf("<p class=\"page-toolbar\">");
                //                int pe = textwz.LastIndexOf("</p>");
                //                textwz = textwz.Remove(pf, pe - pf + 4);

                //            }
                //        }
                //        context.Response.Write("更新成功");

                //        //}
                //    }

                //}
            }
            catch (System.Exception ex)
            {
                context.Response.Write(ex.Message + ex.StackTrace);
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}