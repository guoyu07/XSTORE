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
    /// needChangeGoods 的摘要说明
    /// </summary>
    public class needChangeGoods : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            try
            {
                int user_id = Utils.ObjToInt(context.Request["user_id"], 0);
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                string sql_hotel = "select 仓库id from wp_用户权限 where 用户id='" + user_id + "'";
                DataTable dt_hotel = comfun.GetDataTableBySQL(sql_hotel);
                if (dt_hotel.Rows.Count > 0)
                {
                    string sql_needs = @"select B.id as roomId,b.库位名 as roomName,c.位置 as box_address,c.id as box_id,c.实际商品id as goodsid,e.品名 as goodsname  from WP_仓库表 A
left join wp_库位表 b on b.仓库id=A.id
left join wp_箱子表 c on c.库位id=b.id
left join wp_出库表 d on d.库位id=b.id
left join wp_商品表 e on e.id =c.实际商品id
where  a.id='" + dt_hotel.Rows[0]["仓库id"].ToString() + "' and 库位名 not like '%总台%' and c.位置 is not null  and (d.操作日期 is  null or DateDiff(dd,d.操作日期,getdate())>=30 ) and 箱子mac is not null group by B.id,b.库位名,c.位置,c.实际商品id,e.品名,c.id";
                    DataTable dt_needs = comfun.GetDataTableBySQL(sql_needs);
                    foreach (DataRow dr in dt_needs.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
                    {
                        Dictionary<string, object> result = new Dictionary<string, object>();
                        foreach (DataColumn dc in dt_needs.Columns)
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