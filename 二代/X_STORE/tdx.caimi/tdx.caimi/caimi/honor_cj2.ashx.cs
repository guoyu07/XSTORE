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
using tdx.database;
using Creatrue.Common;
using tdx.Weixin;
using System.Data.SqlClient;

namespace tdx.caimi
{
    public class honor_cj2 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"] == null ? "" : context.Request["action"].ToString().Trim();
            //这次抽奖是否累加次数
            string add = context.Request["add"] == null ? "" : context.Request["add"].ToString().Trim();

            switch (action)
            {
                case "zhuanpan": //抽奖
                    zhuanpan(context, add);
                    break;
                //case "ggl": //验证导航菜单ID是否重复
                //    ggl(context);
                //    break;
                case "tijiao": //中奖后提交手机
                    tijiao(context);
                    break;

            }
        }



        #region 大转盘抽奖,刮刮乐,砸金蛋========================
        private void zhuanpan(HttpContext context, string add)
        {
            string result = "";
            string WWV = context.Request["WWV"] != null ? context.Request["WWV"].ToString().Trim() : "";
            string typeID = context.Request["typeID"] != null ? context.Request["typeID"].ToString().Trim() : "0";
            string guidno = context.Request["guidno"] != null ? context.Request["guidno"].ToString().Trim() : "";
            if (string.IsNullOrEmpty(WWV)) //如果没传递参数过来，不让玩这个游戏。
            {
                result = "{\"success\":\"nowwv\",\"prizetype\":\"\",\"sn\":\"\"}";
                context.Response.Write(result);
                return;
            }

            string _sql = "select id from wx_acm_gain_log where acID=" + typeID + " and wwv='" + WWV + "' and guidno='" + guidno + "'";
            _sql += ";select freq from wx_acm_action where id=" + typeID; //玩的频率
            _sql += ";select id from wx_acm_gain where acID=" + typeID + " and wwv='" + WWV + "'"; //是否曾经中国
            _sql += ";select id from wx_acm_gain where acID=" + typeID + " and DateDiff(dd,regdate,getdate())=0";//今天中奖数量
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count >= Convert.ToInt32(ds.Tables[1].Rows[0]["freq"]))
            {//已经超过次数
                result = "{\"success\":\"invalid\",\"prizetype\":\"\",\"sn\":\"\"}";
                context.Response.Write(result);
                return;
            }
            if (ds.Tables[2].Rows.Count > 0)
            {//已经中过奖
                result = "{\"success\":\"getsn\",\"prizetype\":\"1\",\"sn\":\"" + ds.Tables[2].Rows[0]["SN"] + "\"}";
                context.Response.Write(result);
                return;
            }
            if (ds.Tables[3].Rows.Count >= 2)
            {//今天的中奖人数已满 
                result = "{\"success\":\"meizhong\",\"prizetype\":\"\",\"sn\":\"\"}";
                context.Response.Write(result);
                return;
            }

            //开始抽奖
            string sn = System.Guid.NewGuid().ToString("N");
            Random ran = new Random(DateTime.Now.Millisecond);

            int count = 60; //可能的总人次:20人，每人3次，共60人次
            int prizeno1 = 3;
            int prizeno2 = 0;
            int prizeno3 = 0;

            int role = ran.Next(1, count);
            int roletype = 0;
            //role = 1;
            if (role <= prizeno1)
            {
                roletype = 1;
                result = "{\"success\":\"zhong\",\"prizetype\":\"1\",\"sn\":\"" + sn + "\"}";
            }
            else if (role > prizeno1 && role <= prizeno1 + prizeno2)
            {
                roletype = 2;
                result = "{\"success\":\"zhong\",\"prizetype\":\"2\",\"sn\":\"" + sn + "\"}";
            }
            else if (role > prizeno1 + prizeno2 && role <= prizeno1 + prizeno2 + prizeno3)
            {
                roletype = 3;
                result = "{\"success\":\"zhong\",\"prizetype\":\"3\",\"sn\":\"" + sn + "\"}";
            }
            else
            {
                roletype = 0;
                result = "{\"success\":\"meizhong\",\"prizetype\":\"\",\"sn\":\"\"}";
              
            }
            //加入日志表;加入中奖表 
            _sql = "insert into wx_acm_gain_log(acID,wwv,guidno,result) values(" + typeID + ",'" + WWV + "','" + guidno + "','" + roletype.ToString() + "')";
             if (roletype != 0)
            {
                _sql += ";insert into wx_acm_gain(acid,gid,wwv,sn) values(" + typeID + ",1,'" + WWV + "','" + sn + "')" ;
            }
             try
             {
                 comfun.UpdateBySQL(_sql);

             }
             catch (Exception ex)
             {
                 result = "{\"success\":\"servererror\",\"prizetype\":\"\",\"sn\":\"" + ex.Message + "\"}";
                 context.Response.Write(result);
                 return;
             }

            //最后写回调。
            context.Response.Write(result);
            return;

        }
        #endregion

        #region 刮刮乐 抽奖========================
        private void ggl(HttpContext context)
        {
            string result = "";
            string sn = System.Guid.NewGuid().ToString("N");
            Random ran = new Random(DateTime.Now.Millisecond);
            int role = ran.Next(1, 10000);
            if (role == 1)
            {
                result = "{\"msg\":1,\"prize\":\"一等奖\",\"sn\":\"" + sn + "\"}";
            }
            else if (role > 1 && role <= 4)
            {
                result = "{\"msg\":2,\"prize\":\"二等奖\",\"sn\":\"" + sn + "\"}";
            }
            else if (role > 4 && role <= 9)
            {
                result = "{\"msg\":3,\"prize\":\"三等奖\",\"sn\":\"" + sn + "\"}";
            }
            else
            {
                result = "{\"msg\":0,\"prize\":\"下次没准就能中哦\",\"sn\":\"\"}";
            }
            //result = "{\"msg\":1,\"prize\":\"一等奖\"}";
            context.Response.Write(result);
            return;
        }
        #endregion

        #region 中奖后提交电话===============================

        private void tijiao(HttpContext context)
        {
            string acID = context.Request["acID"] == null ? "0" : context.Request["acID"].ToString().Trim();
            string froms = context.Request["WWV"] == null ? "" : context.Request["WWV"].ToString().Trim();
            string from_tel = context.Request["tel"] == null ? "" : context.Request["tel"].ToString().Trim().Replace(@"\'", " "); ;
            string SN = context.Request["sn"] == null ? "" : context.Request["sn"].ToString().Trim();
            string name = context.Request["name"] == null ? "" : context.Request["name"].ToString().Trim().Replace(@"\'", " ");
            string comp = context.Request["comp"] == null ? "" : context.Request["comp"].ToString().Trim().Replace(@"\'", " ");
            string addr = context.Request["addr"] == null ? "" : context.Request["addr"].ToString().Trim().Replace(@"\'", " ");
            string email = context.Request["email"] == null ? "" : context.Request["email"].ToString().Trim().Replace(@"\'", " ");
            DataTable dt = comfun.GetDataTableBySQL("select * from wx_acm_gain where acID=" + acID + " and sn='" + SN + "'");
            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];
                try
                {
                    int i = comfun.UpdateBySQL("update wx_acm_gain set ga_tel='" + from_tel + "' ,ga_uname='" + name + "', ga_idc='" + comp + "' ,ga_addr='" + addr + "' ,ga_email='" + email + "'  where id=" + Convert.ToInt32(dr["id"]));
                    if (i > 0)
                    {
                        context.Response.Write("success");
                        return;
                    }
                    else
                    {
                        context.Response.Write("出现错误");
                        return;
                    }
                }
                catch (System.Exception ex)
                {
                    context.Response.Write("出现错误：" + ex.Message);
                    return;
                }
            }
            else
            {
                context.Response.Write("此SN不存在");
                return;
            }

        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
