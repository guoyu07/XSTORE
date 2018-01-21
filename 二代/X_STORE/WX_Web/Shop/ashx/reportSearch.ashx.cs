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
    /// reportSearch 的摘要说明
    /// </summary>
    public class reportSearch : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                string hotel_id = HttpContext.Current.Session["hotelId"].ObjToStr();

                string start_time_str = context.Request["start_time"].ObjToStr();
                string end_time_str = context.Request["end_time"].ObjToStr();
                decimal total_price = 0;
                if (!string.IsNullOrEmpty(start_time_str))
                {
                    #region
                    if (!string.IsNullOrEmpty(end_time_str))
                    {
                        string sql_goods = @"select c.品名,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where b.仓库id='" + hotel_id + "' and A.操作日期 between '" + start_time_str + "' and'" + end_time_str + "' group by c.品名,c.本站价";
                        DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
                        if (total_price == 0)
                        {
                            for (int i = 0; i < dt_goods.Rows.Count; i++)
                            {
                                total_price = total_price + dt_goods.Rows[i]["总价"].ObjToDecimal(0);
                            }
                        }
                        foreach (DataRow dr in dt_goods.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
                        {
                            Dictionary<string, object> result = new Dictionary<string, object>();
                            foreach (DataColumn dc in dt_goods.Columns)
                            {
                                result.Add(dc.ColumnName, dr[dc].ToString());
                            }
                            list.Add(result);
                        }

                        er.state = 1;
                        er.info = "请求成功";
                        er.price = total_price;
                        er.data = list;
                        context.Response.Write(Utils.JsonSerialize(er));
                    }
                    else
                    {
                        er.state = 0;
                        er.info = "请求失败，请选择结束时间";
                       // er.price = total_price;
                       // er.data = list;
                        context.Response.Write(Utils.JsonSerialize(er));
                    }
                    #endregion
                }
                else if (!string.IsNullOrEmpty(end_time_str))
                {
                    #region
                    if (!string.IsNullOrEmpty(start_time_str))
                    {
                        string sql_goods = @"select c.品名,c.本站价,sum(A.数量) as 总数,(C.本站价*sum(A.数量))as 总价 from WP_出库表  A
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
where b.仓库id='" + hotel_id + "' and A.操作日期 between '" + start_time_str + "' and'" + end_time_str + "' group by c.品名,c.本站价";
                        DataTable dt_goods = comfun.GetDataTableBySQL(sql_goods);
                        if (total_price == 0)
                        {
                            for (int i = 0; i < dt_goods.Rows.Count; i++)
                            {
                                total_price = total_price + dt_goods.Rows[i]["总价"].ObjToDecimal(0);
                            }
                        }
                        foreach (DataRow dr in dt_goods.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
                        {
                            Dictionary<string, object> result = new Dictionary<string, object>();
                            foreach (DataColumn dc in dt_goods.Columns)
                            {
                                result.Add(dc.ColumnName, dr[dc].ToString());
                            }
                            list.Add(result);
                        }
                        er.state = 1;
                        er.info = "请求成功";
                        er.price = total_price;
                        er.data = list;
                        context.Response.Write(Utils.JsonSerialize(er));
                    }
                    else
                    {
                        er.state = 0;
                        er.info = "请求失败，开始时间";
                        // er.price = total_price;
                        // er.data = list;
                        context.Response.Write(Utils.JsonSerialize(er));
                    }
                    #endregion
                }
                else
                {
                    er.state = 0;
                er.info = "请求失败，请选择时间";
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
            public decimal price;
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