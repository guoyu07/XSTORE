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
    /// otherGoods 的摘要说明
    /// </summary>
    public class otherGoods : IHttpHandler
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
                string sql_needs = @"select d.品名 as goodsname,d.本站价 as price,c.位置 as box_address from wp_库位表 a
left join wp_箱子表 B on B.库位id=A.id 
left join wp_出库表 c on c.位置=b.位置 and c.库位id=b.库位id
left join wp_商品表 d on d.id =b.实际商品id
where A.id='" + rooms_id + "' and c.位置  is not null group by d.品名,d.本站价,c.位置 order by c.位置 asc";
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
            catch (Exception ex)
            {
                er.state = 0;
                er.info = "请求失败";
                //   er.guid = list;
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