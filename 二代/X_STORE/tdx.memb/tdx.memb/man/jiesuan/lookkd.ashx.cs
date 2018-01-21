using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using tdx.database.Common_Pay.WeiXinPay;

namespace tdx.memb.man.jiesuan
{
    /// <summary>
    /// look 的摘要说明
    /// </summary>
    public class lookkd : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Log.WriteLog("测试进入:", "进入", ":");
            string ApiKey = "ae7785a434906804";
            string wuliu = context.Request["wuliu"].ObjToStr();//物流公司id
            string danhao = context.Request["danhao"].ObjToStr();
            string sql = @"select code from 快递表 where id=" + wuliu;
            DataTable dt = new comfun().GetDataTable(sql);
            string code = "";
            if(dt.Rows.Count>0){
                code = dt.Rows[0]["code"].ObjToStr();
            }

            string apiurl = "http://www.kuaidi100.com/applyurl?key=" + ApiKey + "&com=" + code + "&nu=" + danhao;
            Log.WriteLog("接口：look", "apiurl", apiurl);
            //Response.Write (apiurl);
            WebRequest request = WebRequest.Create(@apiurl);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            Encoding encode = Encoding.UTF8;
            StreamReader reader = new StreamReader(stream, encode);
            string detail = reader.ReadToEnd();
            Log.WriteLog("", "", detail);
            context.Response.Write(detail);
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