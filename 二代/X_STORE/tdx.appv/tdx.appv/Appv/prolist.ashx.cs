using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Creatrue.kernel;
using System.Web.SessionState;

namespace tdx.appv
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class prolist1 : IHttpHandler, IRequiresSessionState
    {
        public string _DefTheme = "";
        public string _DefWID = "";
        public string _DefNiChen = "";
        public string _DefGuID = "";

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Session["tdxWeixin"] != null)
            {
                string _tdxWeixin = context.Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');

                _DefWID = _tdxWeixinArry[0];
                _DefNiChen = _tdxWeixinArry[1];
                _DefTheme = _tdxWeixinArry[2];
                _DefGuID = _tdxWeixinArry[3];
            }
            else if (context.Request.Cookies["tdxWeixin"] != null)
            {
                _DefWID = context.Request.Cookies["tdxWeixin"]["WID"];
                _DefNiChen = context.Request.Cookies["tdxWeixin"]["NiChen"];
                _DefTheme = context.Request.Cookies["tdxWeixin"]["Theme"];
                _DefGuID = context.Request.Cookies["tdxWeixin"]["GuID"];
                //写入Session
                context.Session["wID"] = _DefWID;
                context.Session["tdxWeixin"] = _DefWID + "|" + _DefNiChen + "|" + _DefTheme + "|" + _DefGuID;
            }
            else
            {
                context.Response.Redirect("err.aspx?t=只支持微信浏览本站");
            }

            string _cno = context.Request["cno"] != null ? context.Request["cno"].ToString().Trim() : "";
            string _page = context.Request["page"] != null ? context.Request["page"].ToString().Trim() : "1";
            int pagesize = 10;

            string _sql = "with c as (select row_number() over(order by g_sort,id desc) as rown,*,(select c_name from b2c_category where c_no=cno and cityid=" + _DefWID + ") as cname from b2c_goods where cno like '%" + _cno + "%' and g_isactive=1 and g_isdel=0 and cityid=" + _DefWID + ") select top " + pagesize.ToString() + " * from c where rown > " + (Convert.ToInt32(_page) * pagesize).ToString() + " order by rown";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            string result = "";
            if (dt.Rows.Count > 0)
            {
                result += "\r\n";
                foreach (DataRow dr in dt.Rows)
                {
                    result += "<li id=l_item\"" + dr["id"].ToString() + "\"> \r\n";
                    result += "\r\n<a href='showpro.aspx?id=" + dr["id"].ToString().Trim() + "&WWX=" + _DefGuID + "'>";
                    //result += "<div class=\"item\"> \r\n";
                    result += "     \r\n<img src='" + (string.IsNullOrEmpty(dr["g_gif"].ToString()) ? "images/nopic.png" : dr["g_gif"].ToString().Replace("all", "min")) + "' border='0' />";
                    //result += "     \r\n <div >";
                    result += "     \r\n    <h1>" + dr["g_name"].ToString().Trim() + "</h1>";
                    result += "     \r\n    <p>" + dr["g_des"].ToString().Trim().Replace("'", "").Replace("\"", "").Replace("\r", "").Replace("\n", "") + "</p>";                  
                    //result += "     \r\n </div> \r\n";
                    result += "</a> \r\n";
                    result += "</li>";
                    result += "\r\n";
                } 
            }
            else
            {
                result += "\r\n";
                result += "<p>下面已经没有内容</p>";
            }
            dt.Dispose();
            dt = null;

            context.Response.Write(result);
            return;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private string GetMoney(string _money)
        {
            return string.Format("{0:F}", Convert.ToDouble(_money));
        }
    }
}
