using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// otherRooms 的摘要说明
    /// </summary>
    public class otherRooms : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                int user_id = Utils.ObjToInt(context.Request["user_id"], 0);
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                string sql_hotel = @"select 仓库id from wp_用户权限 where 用户id='" + user_id + "'";
                DataTable dt_hotel = comfun.GetDataTableBySQL(sql_hotel);
                if (dt_hotel.Rows.Count > 0)
                {
                    string sql_rooms = @"select B.id as value,b.库位名 as text from WP_仓库表 A
left join wp_库位表 b on b.仓库id=A.id
left join wp_箱子表 c on c.库位id=b.id
left join wp_出库表 d on d.库位id=b.id
where  a.id='" + dt_hotel.Rows[0]["仓库id"].ToString() + "' and 库位名 not like '%总台%' and (d.操作日期 is not null or DateDiff(dd,d.操作日期,getdate())<=30) and 箱子mac is not null and b.isshow=1 group by  B.id,b.库位名 ";
                    DataTable dt_rooms = comfun.GetDataTableBySQL(sql_rooms);
                    foreach (DataRow dr in dt_rooms.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
                    {
                        Dictionary<string, object> result = new Dictionary<string, object>();
                        foreach (DataColumn dc in dt_rooms.Columns)
                        {
                            result.Add(dc.ColumnName, dr[dc].ToString());
                        }
                        list.Add(result);
                    }
                    er.state = 1;
                    er.info = "请求成功";
                    er.data = list;
                    context.Response.Write(Utils.JsonSerialize(er));
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