using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// SearchGoods_hotelmanager 的摘要说明
    /// </summary>
    public class SearchGoods_hotelmanager : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            errReg er = new errReg();
            context.Response.ContentType = "text/plain";
            try
            {
                string user_id = context.Session["UserId"].ObjToStr();
                string goodsName = context.Server.UrlDecode(context.Request["goodsName"]).ObjToStr();
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                string sql = @"select WP_用户权限.仓库id as 子酒店id,wp_库位表.id as 总台库id  from WP_用户权限 
left join wp_库位表 on WP_库位表.仓库id=WP_用户权限.仓库id
where 用户id='" + user_id + "' and wp_库位表.库位名 like '%总台%'";
                DataTable dt_ztk = comfun.GetDataTableBySQL(sql);
                //框架表
                //  string search3 = @"select a.本站价,a.品名,a.本站价,b.图片路径,c.库存数,d.总数 as 出库数 from WP_商品表 a
                //left join wp_商品图片表 b on a.编号=b.商品编号
                //left join 视图在库表 c on c.商品id=a.id
                //left join 视图出库列表 d on d.商品id=a.id
                //where 库位id=75";
                string search3 = @"
                select a.id as goodsId,a.品名 as goodsName,a.本站价 as price,b.图片路径 as img,c.库存数 as inStockNum,cast(0 as int) outStockNum from WP_商品表 a
                left join wp_商品图片表 b on a.编号=b.商品编号
                left join 视图在库表 c on c.商品id=a.id
                where 库位id=75";
                DataTable search3_dt = comfun.GetDataTableBySQL(search3);
                DataTable test3 = new DataTable();
                test3 = search3_dt.Clone();
                object[] obj3 = new object[test3.Columns.Count];
                //
                for (int i = 0; i < dt_ztk.Rows.Count; i++)
                {
                    string sql_xiangqing = @"
                select a.id as goodsId,a.品名 as goodsName,a.本站价 as price,b.图片路径 as img,c.库存数 as inStockNum,cast(0 as int) outStockNum from WP_商品表 a
                left join wp_商品图片表 b on a.编号=b.商品编号
                left join 视图在库表 c on c.商品id=a.id
                where 库位id='" + dt_ztk.Rows[i]["总台库id"].ObjToInt(0) + "' and a.品名 like '%" + goodsName + "%'";
                    DataTable dt_xiangqing = comfun.GetDataTableBySQL(sql_xiangqing);
                    for (int b = 0; b < dt_xiangqing.Rows.Count; b++)
                    {
                        dt_xiangqing.Rows[b].ItemArray.CopyTo(obj3, 0);
                        test3.Rows.Add(obj3);//循环插入test 将结果
                    }
                    string sql_outstock = @"select 总数,商品id,库位id,仓库id from 视图出库列表
                where 库位id='" + dt_ztk.Rows[i]["总台库id"].ObjToInt(0) + "' ";
                    DataTable dt_outstock = comfun.GetDataTableBySQL(sql_outstock);
                    if (dt_outstock.Rows.Count > 0)
                    {
                        for (int c = 0; c < test3.Rows.Count; c++)
                        {
                            for (int d = 0; dt_outstock.Rows.Count > d; d++)
                            {
                                if (dt_outstock.Rows[d]["商品id"].ObjToInt(0) == test3.Rows[c]["goodsId"].ObjToInt(0))
                                {
                                    test3.Rows[c]["outStockNum"] = dt_outstock.Rows[d]["总数"].ObjToInt(0);
                                }
                            }
                        }
                    }
                }
               // DataTable dt_rooms = comfun.GetDataTableBySQL(test3);
                foreach (DataRow dr in test3.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    foreach (DataColumn dc in test3.Columns)
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