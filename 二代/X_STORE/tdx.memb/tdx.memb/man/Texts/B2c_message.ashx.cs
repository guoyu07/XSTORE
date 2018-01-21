using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using tdx.memb.man.config;

namespace tdx.memb.man.Texts
{
    /// <summary>
    /// B2c_message 的摘要说明
    /// </summary>
    public class B2c_message : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["wwv"] != null && context.Request["mid"] != null && context.Request["content"] != null)
            {
                string _wwv = context.Request["wwv"].ToString();
                string con = context.Request["content"].ToString();
                string mid = context.Request["mid"].ToString();

                string _sql = "select top 1 * from wx_mp where id=" + mid;
                DataTable _tab = comfun.GetDataTableBySQL(_sql);
                string pid = "";
                string pwd = "";
                if (_tab.Rows.Count > 0)
                {
                    pid = Convert.IsDBNull(_tab.Rows[0]["wx_DID"]) ? "" : Convert.ToString(_tab.Rows[0]["wx_DID"]);
                    pwd = Convert.IsDBNull(_tab.Rows[0]["wx_Dpsw"]) ? "" : Convert.ToString(_tab.Rows[0]["wx_Dpsw"]);
                }
                else
                {
                    context.Response.Write("no");
                    return;
                }
                if (!string.IsNullOrEmpty(pid) && !string.IsNullOrEmpty(pwd))
                {
                    try
                    {
                        //执行发送
                        weixin wx = new weixin();
                        if (wx.WxSendText(_wwv, con, pid, pwd) == 0)
                        {
                            context.Response.Write("ok");
                            return;

                        }
                        else
                        {

                            context.Response.Write("no");
                            return;
                        }

                    }
                    catch (System.Exception ex)
                    {

                        context.Response.Write("no");
                        return;
                    }
                }



            }
            else
            {
                context.Response.Write("no");
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