using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using Creatrue.kernel;

namespace Wx_NewWeb.appv
{
    /// <summary>
    /// honor_cj 的摘要说明
    /// </summary>
    public class honor_cj : IHttpHandler, IRequiresSessionState
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
            if (string.IsNullOrEmpty(WWV)) //如果没传递参数过来，不让玩这个游戏。
            {
                result = "{\"success\":\"nowwv\",\"prizetype\":\"\",\"sn\":\"\"}";
                context.Response.Write(result);
                return;
            }

            DataTable dt_log_num = comfun.GetDataTableBySQL("select count(id) from Wx_action_logs where froms='" + WWV + "' and acID=" + typeID);
            DataTable dt_action = comfun.GetDataTableBySQL("select * from wx_action where id=" + typeID);
            if (Convert.ToInt32(dt_log_num.Rows[0][0]) >= Convert.ToInt32(dt_action.Rows[0]["ac_men_num"])) //小于3才可以玩
            {
                result = "{\"success\":\"invalid\",\"prizetype\":\"\",\"sn\":\"\"}";
                context.Response.Write(result);
                return;

            }



            //是否已经中奖了
            DataTable dt = comfun.GetDataTableBySQL("select * from Wx_action_gain where acID=" + typeID + " and froms='" + WWV + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                result = "{\"success\":\"getsn\",\"prizetype\":\"" + dr["ac_jpID"] + "\",\"sn\":\"" + dr["SN"] + "\"}";
                context.Response.Write(result);
                return;
            }


            //开始抽奖
            string sn = System.Guid.NewGuid().ToString("N");
            Random ran = new Random(DateTime.Now.Millisecond);

            int count = Convert.ToInt32(dt_action.Rows[0]["ac_men_num"]) * Convert.ToInt32(dt_action.Rows[0]["ac_totlenum"]);//5
            int prizeno1 = Convert.ToInt32(dt_action.Rows[0]["ac_jp_one_num"]);//140
            int prizeno2 = Convert.ToInt32(dt_action.Rows[0]["ac_jp_two_num"]);//280
            int prizeno3 = Convert.ToInt32(dt_action.Rows[0]["ac_jp_three_num"]);//5600

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

                comfun.InsertBySQL("insert into Wx_action_logs(acID,froms,from_Res) values(" + typeID + ",'" + WWV + "',0)");
                // Wx_action_logs.MyInsert(WWV, "", 0);
                context.Response.Write(result);
                return;
            }
            if (roletype != 0)
            {

                string _sql_price = "select count(*) from Wx_action_gain where acID=" + typeID + " and ac_jpID=1;";
                _sql_price += "select count(*) from Wx_action_gain where acID=" + typeID + " and ac_jpID=2;";
                _sql_price += "select count(*) from Wx_action_gain where acID=" + typeID + " and ac_jpID=3;";
                DataSet set = comfun.GetDataSetBySQL(_sql_price);
                //一等奖,中奖数目
                int p1 = Convert.ToInt32(set.Tables[0].Rows[0][0]);
                //二等奖,中奖数目
                int p2 = Convert.ToInt32(set.Tables[1].Rows[0][0]);
                //三等奖,中奖数目
                int p3 = Convert.ToInt32(set.Tables[2].Rows[0][0]);
                if (roletype == 1)
                {
                    if (p1 >= prizeno1)
                    {
                        roletype = 0;
                    }
                }
                if (roletype == 2)
                {
                    if (p2 >= prizeno2)
                    {
                        roletype = 0;
                    }
                }
                if (roletype == 3)
                {
                    if (p3 >= prizeno3)
                    {
                        roletype = 0;

                    }
                }
                if (roletype == 0)
                {
                    result = "{\"success\":\"meizhong\",\"prizetype\":\"\",\"sn\":\"\"}";

                    comfun.InsertBySQL("insert into Wx_action_logs(acID,froms,from_Res) values(" + typeID + ",'" + WWV + "',0)");
                    context.Response.Write(result);
                    return;
                }
            }
            //if (roletype == 1)
            //{
            //    if (p1 >= 1)
            //    {
            //        if (p2 >= 3)
            //        {

            //            if (p3 >= 5)
            //            {
            //                roletype = 0;
            //            }
            //            else
            //                roletype = 3;
            //        }
            //        else
            //        {
            //            roletype = 2;
            //        }
            //    }
            //}

            if (roletype != 0)
            {

                string ac_jpID = "" + roletype;
                string sql = "insert into Wx_action_gain (acID,ac_jpID,froms,from_tel,SN) values (@acID,@ac_jpID,@froms,@from_tel,@SN)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@acID", typeID),
                    new SqlParameter("@ac_jpID", ac_jpID),
                    new SqlParameter("@froms", WWV), 
                    new SqlParameter("@from_tel", ""),
                    new SqlParameter("@SN", sn)};
                try
                {
                    new comfun().ExecuteNonQuery(sql, paras);

                    comfun.InsertBySQL("insert into Wx_action_logs(acID,froms,from_Res) values(" + typeID + ",'" + WWV + "'," + roletype + ")");
                    context.Response.Write(result);
                    return;

                }
                catch (Exception ex)
                {
                    result = "{\"success\":\"servererror\",\"prizetype\":\"\",\"sn\":\"\"}";
                    context.Response.Write(result);
                    return;
                }

            }


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
            DataTable dt = comfun.GetDataTableBySQL("select * from Wx_action_gain where acID=" + acID + " and sn='" + SN + "'");
            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];
                try
                {
                    int i = comfun.UpdateBySQL("update Wx_action_gain set from_tel='" + from_tel + "' , from_name='" + name + "', from_comp='" + comp + "' ,from_addr='" + addr + "' ,from_email='" + email + "'  where id=" + Convert.ToInt32(dr["id"]));
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