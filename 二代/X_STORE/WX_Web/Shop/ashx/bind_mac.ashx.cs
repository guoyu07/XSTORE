using Creatrue.kernel;
using DTcms.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// bind_mac 的摘要说明
    /// </summary>
    public class bind_mac : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
              
                var kuwei_id = context.Request["kuwei_id"].ObjToInt(0);
                //Log.WriteLog("接口：bind_mac", "方法：ProcessRequest", "kuwei_id：" + kuwei_id);
                var mac = context.Request["mac"].ObjToStr();
                //Log.WriteLog("接口：bind_mac", "方法：ProcessRequest", "mac：" + mac);
                var select_sql = string.Format("SELECT isnull(库位名,'') as 库位名 FROM WP_库位表 WHERE 箱子MAC LIKE '%{0}%'", mac);
                //Log.WriteLog("接口：bind_mac", "方法：ProcessRequest", "select_sql：" + select_sql);
                var select_dt = comfun.GetDataTableBySQL(select_sql);
                if (select_dt.Rows.Count > 0)
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "已绑定房间号：" + select_dt.Rows[0]["库位名"].ObjToStr() +" 请勿重复绑定"}));
                    return;
                }
                var sql = string.Format("UPDATE WP_库位表 SET 箱子MAC = '{0}' WHERE id = {1}", mac, kuwei_id);
                sql +=
                    string.Format(
                        @" UPDATE WP_BarCode SET [KuWeiId] = {0},HotelId = (select top 1 仓库id from WP_库位表 where id = {0}),HasBind = 1,BindTime = getdate() WHERE BarCode = '{1}'", kuwei_id,mac);
                var b = comfun.UpdateBySQL(sql);
                if (b > 0)
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { state = 0, info = "绑定成功" }));
                    return;
                }
                else
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "绑定失败" }));
                }

            }
            catch(Exception ex)
            {
                Log.WriteLog("接口：bind_mac", "方法：ProcessRequest", "异常错误："+ex.Message);
                context.Response.Write(JsonConvert.SerializeObject(new { state = 1, info = "数据异常" }));
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