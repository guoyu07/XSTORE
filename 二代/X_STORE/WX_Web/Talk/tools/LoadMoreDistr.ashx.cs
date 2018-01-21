using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Wx_NewWeb.Talk.tools
{
    /// <summary>
    /// LoadMoreDistr 的摘要说明
    /// </summary>
    public class LoadMoreDistr : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mid = string.IsNullOrEmpty(context.Request.Params["mid"]) ? "-1" : context.Request.Params["mid"];
            string index = string.IsNullOrEmpty(context.Request.Params["pageindex"]) ? "-1" : context.Request.Params["pageindex"];
            int mypageindex = -1;
            int.TryParse(index, out mypageindex);
            string myresult = GetHtml(mid, index);
            string mymessage = "true";
            if (string.IsNullOrEmpty(myresult))
                mymessage = "false";
            object obj = new { message = mymessage, result = myresult, pageindex = mypageindex + 1 };

            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
        private string GetHtml(string mid, string index)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n select  c_name,ac_des,ac_money,ac_regdate from    ");
            sb.Append("\r\n (select row_number() over (order by ac_regdate asc) as rownum,* from B2C_Account a    ");
            sb.Append("\r\n left join [dbo].[B2C_kemu] b on a.cno=b.c_no where a.cno in ('015','016') and a.mid=" + mid + " ) t   ");
            sb.Append("\r\n where t.rownum between 10*(" + index + "-1)+1   and  10*" + index + "  ");
            StringBuilder sbhtml = new StringBuilder();
            DataTable dt =DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                  sbhtml.Append("\r\n     <li>                                                                   ");
                  sbhtml.Append("\r\n     <div class=\"proj clear\">" + dr["c_name"].ToString() + "</div>            ");
                  sbhtml.Append("\r\n     <div class=\"t_yj clear\">                                                                   ");
                  sbhtml.Append("\r\n      <div class=\"fl\">" + dr["ac_regdate"].ToString() + "</div>                                                                              ");
                  sbhtml.Append("\r\n      <div class=\"fr\"><span>佣金：</span><span class=\"price\"><em>¥</em><span id=\"totalmoney\">" + dr["ac_money"].ToString() + "</span></span></div> ");
                  sbhtml.Append("\r\n      </div>                                                                             ");
                  sbhtml.Append("\r\n      <div class=\"yj_con\">" + dr["ac_des"].ToString() + "</div>");
                  sbhtml.Append("\r\n       </li>                                                     ");
                }
                return sbhtml.ToString();
            }
            else 
                return "";
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