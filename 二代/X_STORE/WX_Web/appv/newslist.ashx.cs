using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
 
using System.Data;
using Creatrue.kernel;

namespace Wx_NewWeb
{
    /// <summary>
    /// newslist 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public  class newslist : IHttpHandler, IRequiresSessionState
    {
        public string _DefTheme = "";
        public string _DefWID = "";
        public string _DefNiChen = "";
        public string _DefGuID = "";
        public void ProcessRequest(HttpContext context)
        {
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
                return;
            }

            string _cno = context.Request["cno"] != null ? context.Request["cno"].ToString().Trim() : "";
            string _page = context.Request["page"] != null ? context.Request["page"].ToString().Trim() : "1";
            int pagesize = 10;

            string _sql = "with c as (select row_number() over(order by t_sort,id desc) as rown,*,(select c_name from b2c_tclass where c_no=cno) as cname" +// and cityid=" + _DefWID + "
                " from b2c_tmsg where cno like '%" + _cno + "%' and t_isactive=1 and t_isdel=0)" + // and cityid=" + _DefWID + "
                " select top " + pagesize.ToString() + " * from c where rown > " + (Convert.ToInt32(_page) * pagesize).ToString() + " order by rown";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            string result = "";
            if (dt.Rows.Count > 0)
            {
                result += "\r\n";
                foreach (DataRow dr in dt.Rows)
                {

                    result += "<li> \r\n";
                    result += "\r\n<a href='shownews.aspx?id=" + dr["id"].ToString().Trim() + "&WWX=" + _DefGuID + "&WWV=" + (context.Request["WWV"] == null ? "" : context.Request["WWV"].ToString().Trim()) + "'><h1>";
                    result += "     \r\n    " + (dr["t_title"].ToString().Trim().Length > 20 ? (dr["t_title"].ToString().Trim().Substring(0, 17) + "...") : dr["t_title"].ToString().Trim());// +"[" + Convert.ToDateTime(dr["t_wdate"]).ToShortDateString() + "]";
                    result += "</h1></a>\r\n";
                    result += "</li> \r\n";

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
        }


        private string GetMoney(string _money)
        {
            return string.Format("{0:F}", Convert.ToDouble(_money));
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