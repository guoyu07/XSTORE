using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// ApplyChangeGoods 的摘要说明
    /// </summary>
    public class ApplyChangeGoods : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            try
            {
                int box_id = Utils.ObjToInt(context.Request["box_id"], 0);
                int user_id = Utils.ObjToInt(context.Request["user_id"], 0);
                int new_GoodsId = Utils.ObjToInt(context.Request["new_GoodsId"], 0);
                int old_GoodsId = Utils.ObjToInt(context.Request["old_GoodsId"], 0);
                string sql_oldgoods = @"select * from WP_换货表 where 箱子id='" + box_id + "' and 原商品id='" + old_GoodsId + "' and openid=(select openid from wp_用户表 where id='" + user_id + "')";
                DataTable dt_oldgoods = comfun.GetDataTableBySQL(sql_oldgoods);
                if (dt_oldgoods.Rows.Count > 0)
                {
                    comfun.UpdateBySQL("update wp_换货表 set 新商品id='" + new_GoodsId + "' where openid=(select openid from wp_用户表 where id='" + user_id + "') and 箱子id='" + box_id + "' and 状态=1");

                    er.state = 1;
                    er.info = "请求成功";
                    //   er.data = list;
                    context.Response.Write(Utils.JsonSerialize(er));
                }
                else
                {
                    string sql_newgoods = "insert into wp_换货表 (箱子id,原商品id,新商品id,状态,申请时间,openid) values ('" + box_id + "','" + old_GoodsId + "','" + new_GoodsId + "',1,getdate(),(select openid from wp_用户表 where id='" + user_id + "'))";
                    comfun.InsertBySQL(sql_newgoods);

                    er.state = 1;
                    er.info = "请求成功";
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