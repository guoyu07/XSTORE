using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Web;
using System.Web.SessionState;
using System.Data;
namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// paySucessOpenbox 的摘要说明
    /// </summary>
    public class paySucessOpenbox : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            try
            {
                string order_no = context.Request["order_no"].ObjToStr();
                string sql_state = "select isnull(是否开箱,0) as 是否开箱 from wp_订单子表 where 订单编号='" + order_no + "'";
                Log.WriteLog("接口：paySucessOpenbox", "方法：ProcessRequest", "sql_state:" + sql_state);
                DataTable dt_state = comfun.GetDataTableBySQL(sql_state);
                var flag = true;
                if (dt_state.Rows.Count > 0)
                {
                    foreach (DataRow item in dt_state.Rows)
                    {
                        if (item["是否开箱"].ObjToInt(0) == 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        er.state = 1;
                        er.info = "开箱成功";
                        er.guid = Guid.NewGuid().ToString();
                        context.Response.Write(Utils.JsonSerialize(er));
                        return;
                    }
                    else
                    {
                        er.state = 0;
                        er.info = "开箱失败";
                        er.guid = Guid.NewGuid().ToString();
                        context.Response.Write(Utils.JsonSerialize(er));
                        return;
                    }
                    //Log.WriteLog("接口：paySucessOpenbox", "方法：ProcessRequest", "state原始:" + dt_state.Rows[0]["state"].ObjToStr());
                    //Log.WriteLog("接口：paySucessOpenbox", "方法：ProcessRequest", "state:" + dt_state.Rows[0]["state"].ObjToInt(0));
                    //switch (dt_state.Rows[0]["state"].ObjToInt(0))
                    //{
                    //    case 3: 
                    //        er.state = 1;
                    //        er.info = "开箱成功";
                    //        er.guid = Guid.NewGuid().ToString();
                    //        context.Response.Write(Utils.JsonSerialize(er));
                    //        return;
                    //    case 5: 
                    //        er.state = 0;
                    //        er.info = "开箱失败";
                    //        er.guid = Guid.NewGuid().ToString();
                    //        context.Response.Write(Utils.JsonSerialize(er));
                    //        return;
                    //    default:
                    //        er.state = 2;
                    //        er.info = "未知错误";
                    //        er.guid = Guid.NewGuid().ToString();
                    //        context.Response.Write(Utils.JsonSerialize(er));
                    //        return;
                    //}
                }
                else
                {
                    er.state = 2;
                    er.info = "订单不存在";
                    er.guid = Guid.NewGuid().ToString();
                    context.Response.Write(Utils.JsonSerialize(er));
                    return;
                }
                //if (dt_state.Rows[0]["state"].ObjToInt(0) == 5)
                //{
                //    comfun.GetDataTableBySQL("update wp_订单表 set state=5 where 订单编号='" + order_no + "'");
                //    er.state = 0;
                //    er.info = "开箱失败";
                //    er.guid = Guid.NewGuid().ToString();
                //    context.Response.Write(Utils.JsonSerialize(er));
                //    return;
                //}
                //else if (dt_state.Rows[0]["state"].ObjToInt(0) == 3)
                //{
                //    er.state = 1;
                //    er.info = "开箱成功";
                //    er.guid = Guid.NewGuid().ToString();
                //    context.Response.Write(Utils.JsonSerialize(er));
                //    return;
                //}
                //else
                //{
                //    comfun.GetDataTableBySQL("update wp_订单表 set state=5 where 订单编号='" + order_no + "'");
                //    er.state = 2;
                //    er.info = "未知错误";
                //    er.guid = Guid.NewGuid().ToString();
                //    context.Response.Write(Utils.JsonSerialize(er));
                //    return;
                //}

            }
            catch(Exception ex)
            {
                Log.WriteLog("接口：paySuccessOpenbox", "方法：ProcessRequest", "异常信息:" + ex.Message);
                er.state = 3;
                er.info = "未知错误";
                er.guid = Guid.NewGuid().ToString();
                context.Response.Write(Utils.JsonSerialize(er));
                return;
            }
 


        }

        struct errReg
        {
            public int state;
            public string info;
            public string guid;
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