using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTcms.Common;
using System.Data;
using Creatrue.kernel;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Common.AliDayu;
using Newtonsoft.Json.Linq;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// SsendMessage 的摘要说明
    /// </summary>
    public class SendMessage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                string phone = context.Request["phone"].ObjToStr();
 
                Random ran = new Random();
                string str = ran.Next(1000, 10000).ToString();
                DataTable dt_tel = comfun.GetDataTableBySQL("select id from WP_用户表 where 1=1 and 手机号='" + phone + "'");
                string sql = "select SMS_id from  [WP_发送验证码] where sendtime>(select dateadd(minute ,-1,getdate())) and wx_openid='" + phone + "' ";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt.Rows.Count > 0)
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "验证已发送的您的手机，请稍后再试!" }));
                    return;
                }
                else
                {
                    var job = new JObject();
                    job["code"] = str;
                    job["product"] = "";
                    if (AliSendMessage.Send(phone, JsonConvert.SerializeObject(job)))
                    {
                        string sms_sql = @"INSERT INTO  [WP_发送验证码]([sms_phone] ,[sms_code]  ,[sendtime]  ,[wx_openid]) 
                            VALUES   ('" + phone + "'  ,'" + str + "'   ,'" + System.DateTime.Now + "'  ,'" + phone + "')";
                        if (comfun.InsertBySQL(sms_sql) == 1)
                        {
                            context.Response.Write(JsonConvert.SerializeObject(new { state = 0, info = "验证码已发送到您的手机", code = str }));
                            return;
                        }
                        else
                        {

                            context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "验证码发送失败" }));
                            return;
                        }
                    }
                    else
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "验证码发送失败" }));
                        return;
                    };
                }
            }
            catch (Exception e)
            {
                Log.WriteLog("接口：SendMessage","错误信息："+e.Message,"-----");
                context.Response.Write(JsonConvert.SerializeObject(new { state = 1,info="数据异常",exception = e.Message}));
                return;
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