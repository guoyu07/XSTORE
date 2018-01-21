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
    /// AnswerMiYu 的摘要说明
    /// </summary>
    public class AnswerMiYu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string result = "";
            string resultCode = "error";

            string _ids = context.Request["acID"] != null ? context.Request["acID"].ToString() : "0";
            string _wwv = context.Request["wwv"] != null ? context.Request["wwv"].ToString() : "";
            string _tid = context.Request["tID"] != null ? context.Request["tID"].ToString() : "0";
            string _tAnswer = context.Request["tAnswer"] != null ? context.Request["tAnswer"].ToString() : "";
            string _guid = context.Request["guid"] != null ? context.Request["guid"].ToString() : "";

            string _sql = "select t_answer from wx_acm_test where id=" + _tid; //取答案
            _sql += ";select count(id) from wx_acm_action_log where acid=" + _ids + " and wwv='" + _wwv + "' and guid_no='" + _guid + "' and DateDiff(dd,regdate,getdate())=0";
            _sql += ";select freq from wx_acm_action where id=" + _ids;
            _sql += ";select * from wx_acm_action_gains where acid=" + _ids;
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (Convert.ToInt32(ds.Tables[1].Rows[0][0]) > Convert.ToInt32(ds.Tables[2].Rows[0][0]))
            {
                result = "您今天累了，明天再来玩吧~";
            }
            else
            {

                if (ds.Tables[0].Rows[0][0].ToString().Trim() == _tAnswer.Trim())  //答案正确               
                {
                    //更新日志
                    wx_acm_action_log.MyUpdate(Convert.ToInt32(_ids), Convert.ToInt32(_tid), _wwv, _tAnswer, 1);
                    //写入到日志中 
                    //wx_acm_action_log.MyInsert(Convert.ToInt32(_ids), Convert.ToInt32(_tid), _wwv, _tAnswer, 1, "", "");
                    //这里还要判断是玩下一题，还是跳转到大转盘去。
                    if (Convert.ToInt32(ds.Tables[1].Rows[0][0]) >= Convert.ToInt32(ds.Tables[2].Rows[0][0]))
                    {
                        //准备跳转到大转盘抽奖活动
                        resultCode = "OKOKOK";
                        result = "您真棒！您连续答对了三道谜语，获得一次抽取奖品的机会。现在就去抽奖，Go！";
                        //context.Response.Redirect("honor_action.aspx?wwv=" + _wwv + "&acID=" + _ids);
                    }
                    else
                    {
                        resultCode = "OK";
                        result = "恭喜您，答对了！请再继续猜谜~~";
                    }
                }
                else
                {
                    wx_acm_action_log.MyUpdate(Convert.ToInt32(_ids), Convert.ToInt32(_tid), _wwv, _tAnswer, 0);
                    //写入到日志中
                    //wx_acm_action_log.MyInsert(Convert.ToInt32(_ids), Convert.ToInt32(_tid), _wwv, _tAnswer, 0, "", "");
                    result = "很遗憾！您答错了~~";
                }
            }
            result = "{\"code\":\"" + resultCode + "\",\"msg\":\"" + result + "\"}";

            context.Response.ContentType = "text/Json";
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
    }
}