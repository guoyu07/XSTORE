using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using Creatrue.Common;
using tdx.Weixin;

namespace tdx.caimi
{
    /// <summary>
    /// GetMiYu 的摘要说明
    /// </summary>
    public class GetMiYu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string _ids = context.Request["acID"]!=null ? context.Request["acID"].ToString() : "0";
            string _wwv = context.Request["wwv"]!=null ? context.Request["wwv"].ToString() : "";
            string _guid = context.Request["guid"] != null ? context.Request["guid"].ToString() : "";
            string _sql = "select top 1 id,t_title from wx_acm_test where not id in (select tid from wx_acm_action_log where acid=" + _ids + " and wwv='" + _wwv + "')";
                                                                        //曾经答过的不再出现
            //_sql += " and lid in (select '0'+lid from wx_acm_action where id=" + _ids + ")"; //谜语等级在活动配置的等级之中
            //_sql += " and ((select hid from wx_acm_action where id=" + _ids + ") in ('0'+hid))"; //节日适合
            //_sql += " and ((select whid from wx_acm_action where id=" + _ids + ") in ('0'+whid))"; //氛围适合
            _sql += " order by newID()";

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            string result = "";
            if (dt.Rows.Count > 0)
            {
                //写入日志表
                wx_acm_action_log.MyInsert(Convert.ToInt32(_ids), Convert.ToInt32(dt.Rows[0]["id"]), _wwv, "", _guid);
                //返回给前台
                result += "{\"IDs\":\"" + dt.Rows[0]["id"].ToString() + "\",\"Title\":\"" + dt.Rows[0]["t_title"].ToString() + "\"}";
                context.Response.ContentType = "text/Json";
                context.Response.Write(result);
            }
            return;

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