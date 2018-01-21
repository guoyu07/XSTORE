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
    /// otherRoomsDetails 的摘要说明
    /// </summary>
    public class otherRoomsDetails : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            try
            {
                int rooms_id = Utils.ObjToInt(context.Request["rooms_id"], 0);
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                string sql_rooms = @"select top 12  位置 as box_address,品名 as goods_name,本站价 as price from wp_库位表 
left join wp_箱子表 on wp_箱子表.库位id=wp_库位表.id
left join wp_商品表 on wp_商品表.id=wp_箱子表.实际商品id
where wp_库位表.id='" + rooms_id + "' order by 位置 asc ";
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