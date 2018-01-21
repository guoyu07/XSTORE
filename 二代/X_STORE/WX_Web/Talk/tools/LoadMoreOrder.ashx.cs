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
    public class LoadMoreOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mid = string.IsNullOrEmpty(context.Request.Params["mid"]) ? "-1" : context.Request.Params["mid"];
            string index = string.IsNullOrEmpty(context.Request.Params["pageindex"]) ? "-1" : context.Request.Params["pageindex"];
            int mypageindex=-1;
            int.TryParse(index,out mypageindex);
            string myresult = GetHtml(mid, index);
            string mymessage = "true";
            if (string.IsNullOrEmpty(myresult))
                mymessage = "false";
            object obj = new { message = mymessage, result = myresult, pageindex = mypageindex+1 };

            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
        private string GetHtml(string mid, string index)
        {
            /*
             ("wx昵称")%>
             ("orderNo")%
             ("总金额")%>
             ("下单时间")
             */
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n select  *  from  (select wx昵称,orderNo,总金额,下单时间,row_number() over (order by 下单时间 desc)  as rownum   from  (   ");
            sb.Append("\r\n select cno,orderNo,wx昵称,总金额,下单时间 from B2C_Account a left join [dbo].[WP_订单表] b on a.orderNo=b.订单编号    ");
            sb.Append("\r\n left join WP_会员表 c on b.openid=c.openid where a.cno=015 and a.mid=87   ");
            sb.Append("\r\n union select cno,orderNo,wx昵称,总金额,下单时间 from B2C_Account a    ");
            sb.Append("\r\n left join [dbo].[TM_订单表] b on a.orderNo=b.订单编号 left join WP_会员表 c on b.openid=c.openid  where a.cno=016 and a.mid=" + mid + ") t) t2   ");
            sb.Append("\r\n where t2.rownum   between 10*(" + index + "-1)+1   and  10*" + index + "  ");
            StringBuilder sbhtml = new StringBuilder();
            DataTable dt =DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                  sbhtml.Append("        <li>                                                               ");
                    sbhtml.Append("        <div class=\"proj clear\">" + dr["orderNo"].ToString() +"</div>  ");
                    sbhtml.Append("        <div class=\"t_yj clear\">                                       ");
                    sbhtml.Append("        <div class=\"fl\">" + dr["下单时间"]+"</div>                                 ");
                    sbhtml.Append("        <div class=\"fr\"><span class=\"price\"><em>¥</em>"+dr["总金额"].ToString()+"></span></div>");
                    sbhtml.Append("        </div>                                                                       ");
                    sbhtml.Append("        <div class=\"yj_con\">"+dr["wx昵称"].ToString()+"</div>          ");
                    sbhtml.Append("      </li>                                                              ");
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