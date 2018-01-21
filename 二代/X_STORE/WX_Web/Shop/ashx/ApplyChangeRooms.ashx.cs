using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// ApplyChangeRooms_ 的摘要说明
    /// </summary>
    public class ApplyChangeRooms_ : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            try
            {
                int old_roomsId = Utils.ObjToInt(context.Request["old_roomsId"], 0);
                int new_roomsId = Utils.ObjToInt(context.Request["new_roomsId"], 0);
                int user_id = Utils.ObjToInt(context.Request["user_id"], 0);
                string sql_userInfo = "select openid from wp_用户表 where id='" + user_id + "'";
                DataTable dt_userInfo = comfun.GetDataTableBySQL(sql_userInfo);
                if (dt_userInfo.Rows.Count > 0)
                {
                    string sql_apply = @"select * from wp_换箱表 where 新库位id='" + new_roomsId + "'and 原库位id='" + old_roomsId + "' and openid='" + dt_userInfo.Rows[0]["openid"].ToString() + "'";
                    DataTable dt_apply = comfun.GetDataTableBySQL(sql_apply);
                    if (dt_apply.Rows.Count > 0)
                    {
                        comfun.UpdateBySQL("update wp_换箱表 set 新库位id='" + new_roomsId + "' where 原库位id='" + old_roomsId + "' openid=(select openid from wp_用户表 where id='" + user_id + "') and 状态=1");
                        //  return JsonConvert.SerializeObject(new { state = 1, info = "请求成功" });
                        er.state = 1;
                        er.info = "请求正在处理中！";
                        //   er.data = list;
                        context.Response.Write(Utils.JsonSerialize(er));
                    }
                    else
                    {
                        try
                        {
                            string sql_insert = "insert into wp_换箱表 (mac,原库位id,新库位id,状态,申请时间,openid) values((select 箱子mac from wp_库位表 where id='" + old_roomsId + "'),'" + old_roomsId + "','" + new_roomsId + "',1,getdate(),(select openid from wp_用户表 where id='" + user_id + "'))";
                            comfun.InsertBySQL(sql_insert);
                            er.state = 1;
                            er.info = "请求成功";
                            //  er.data = list;
                            context.Response.Write(Utils.JsonSerialize(er));
                        }
                        catch
                        {
                            er.state = 0;
                            er.info = "请求失败";
                            //   er.data = list;
                            context.Response.Write(Utils.JsonSerialize(er));
                        }
                    }
                }
                else
                {
                    er.state = 0;
                    er.info = "请求失败";
                    //   er.data = list;
                    context.Response.Write(Utils.JsonSerialize(er));
                }
            }

            catch (Exception ex)
            {
                er.state = 0;
                er.info = "请求失败";
                //   er.data = list;
                context.Response.Write(Utils.JsonSerialize(er));
            }
        }

        struct errReg
        {
            public int state;
            public string info;
            public List<Dictionary<string, object>> data;
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