using System.IO;
using System.Net;
using System.Text;
using System.Web;
using tdx.database.Common_Pay.WeiXinPay;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// look 的摘要说明
    /// </summary>
    public class look : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
       //     context.Response.Write("Hello World");
            string dh = context.Request["danhao"].ObjToStr();
            string wlgs = context.Request["wuliu"].ObjToStr();
            string apiurl = "http://www.kuaidi100.com/applyurl?key=ae7785a434906804&com=" + wlgs + "&nu=" + dh + "";
            //Response.Write (apiurl);
            WebRequest request = WebRequest.Create(@apiurl);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            Encoding encode = Encoding.UTF8;
            StreamReader reader = new StreamReader(stream, encode);
            string detail = reader.ReadToEnd();
            //Log.WriteLog("", "", detail);
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