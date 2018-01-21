using Creatrue.kernel;
using DTcms.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// managerSetPsd 的摘要说明
    /// </summary>
    public class managerSetPsd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                string phone = context.Request["phone"].ObjToStr();
                string name = context.Request["name"].ObjToStr();
                string account = context.Request["account"].ObjToStr();
                string password = context.Request["password"].ObjToStr();
                string md5_password = string.Empty;

                int user_id = context.Request["user_id"].ObjToInt(0);
                string sql = "select 用户名, 密码, openid, 手机号, 真实姓名, QQ, Email, 微信昵称, 微信头像, IsShow, 角色id from WP_用户表 where id='" + user_id + "'";
                Log.WriteLog("接口：ModifyPassword", "方法：ProcessRequest", "sql：" + sql);
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt.Rows.Count > 0)
                {
                    MD5 md5 = MD5.Create();
                    byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < s.Length; i++)
                    {
                        // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                        md5_password = md5_password + s[i].ToString("X");
                    }
                    //string sql_old = @"insert into WP_用户历史表 (用户名, 密码, openid, 手机号, 真实姓名, QQ, Email, 微信昵称, 微信头像, IsShow, 角色id) values('" + dt.Rows[0]["用户名"].ObjToStr() + "','" + dt.Rows[0]["密码"].ObjToStr() + "','" + dt.Rows[0]["openid"].ObjToStr() + "','" + dt.Rows[0]["手机号"].ObjToStr() + "','" + dt.Rows[0]["真实姓名"].ObjToStr() + "','" + dt.Rows[0]["QQ"].ObjToStr() + "','" + dt.Rows[0]["Email"].ObjToStr() + "','" + dt.Rows[0]["微信昵称"].ObjToStr() + "','" + dt.Rows[0]["微信头像"].ObjToStr() + "','" + dt.Rows[0]["IsShow"].ObjToStr() + "','" + dt.Rows[0]["角色id"].ObjToStr() + "')";
                    //comfun.InsertBySQL(sql_old);
                    string sql_new = " update WP_用户表 set 用户名= '" + account + "',加密='" + md5_password + "',密码='" + password + "',真实姓名='" + name + "',手机号='" + phone + "' where id='" + user_id + "'";
                    //Log.WriteLog("接口：ModifyPassword", "方法：ProcessRequest", "sql_new：" + sql_new);
                    if (comfun.UpdateBySQL(sql_new) > 0)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new { state = 0, info = "修改成功",url="employeeManager.aspx" }));
                    }
                }
                else
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "用户不存在" }));
                    return;
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog("接口：ModifyPassword", "数据异常信息", ex.Message);
                context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "数据异常", exception = ex.Message }));
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