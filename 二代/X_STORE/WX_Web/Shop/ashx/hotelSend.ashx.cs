using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Data;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// hotelSend 的摘要说明
    /// </summary>
    public class hotelSend : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          //  context.Response.Write("Hello World");
            errReg er = new errReg();
            try
            {
                string hotel_id = context.Request["hotelId"].ObjToStr();
                string sql_send = @"select d.仓库名,b.仓库id,c.id as 商品id,c.品名 as 商品品名,c.规格,c.单位,c.本站价 as 销售价,c.折扣率,c.分销率,(C.本站价*sum(A.数量))as 结算金额 from wp_订单子表 a
left join wp_库位表 b on a.库位id=b.id 
left join wp_商品表 c on c.id=A.商品id
left join wp_仓库表 d on d.id=b.仓库id
where a.仓库id='" + hotel_id + "' and b.库位名 not like '%总台%' and a.结算状态=0 group by d.仓库名,b.仓库id,c.id,c.品名,c.规格,c.单位,c.本站价,c.分销率,c.折扣率";
                DataTable dt_send = comfun.GetDataTableBySQL(sql_send);
                if (dt_send.Rows.Count > 0)
                {
//                    for (int i = 0; i < dt_send.Rows.Count; i++)
//                    {
//                        string sql_insert = @"insert INTO   WP_酒店结算表(仓库名,仓库id,商品id,商品品名,规格,单位,销售价,折扣率,分销率,结算金额,是否结算,申请日期)
//VALUES   ('" + dt_send.Rows[i]["仓库名"].ObjToStr() + "','" + dt_send.Rows[i]["仓库id"].ObjToStr() + "','" + dt_send.Rows[i]["商品id"].ObjToStr() + "','" + dt_send.Rows[i]["商品品名"].ObjToStr() + "','" + dt_send.Rows[i]["规格"].ObjToStr() + "','" + dt_send.Rows[i]["单位"].ObjToStr() + "','" + dt_send.Rows[i]["销售价"].ObjToDecimal(0) + "','" + dt_send.Rows[i]["折扣率"].ObjToDecimal(0) + "','" + dt_send.Rows[i]["分销率"].ObjToDecimal(0) + "','" + dt_send.Rows[i]["结算金额"].ObjToStr() + "',0,getdate())";
//                        comfun.InsertBySQL(sql_insert);
//                    }
           
                    string sql_update = @"update wp_订单子表 set 结算状态=1 where 仓库id='"+hotel_id+"' and 结算状态=0 ";
                    comfun.UpdateBySQL(sql_update);
                    er.state = 1;
                    er.info = "申请成功";
                    er.guid = Guid.NewGuid().ObjToStr(); ;
                    context.Response.Write(Utils.JsonSerialize(er));
                }
                else
                {
                    er.state = 0;
                    er.info = "未知错误";
                    er.guid = Guid.NewGuid().ObjToStr(); ;
                    context.Response.Write(Utils.JsonSerialize(er));
                }

            }
            catch
            {
              
                er.state = 0;
                er.info = "未知错误";
                er.guid = Guid.NewGuid().ObjToStr(); ;
                context.Response.Write(Utils.JsonSerialize(er));
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