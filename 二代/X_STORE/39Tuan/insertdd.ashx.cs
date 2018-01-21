using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Creatrue.kernel;

namespace Tuan
{
    /// <summary>
    /// insertdd 的摘要说明
    /// </summary>
    public class insertdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string openid = context.Request["openid"].ToString();
            string spbh = context.Request["spbh"].ToString();
            decimal price =Convert.ToDecimal(context.Request["price"].ToString())/100;
            string ddbh = context.Request["ddbh"].ToString();
            string otheropenid = context.Request["otheropenid"].ToString();
            string otherddbh = context.Request["otherddbh"].ToString();
            string count = context.Request["count"]  == null ? "1" : context.Request["count"].ToString();
            decimal totalprice =Convert.ToDecimal(context.Request["totalprice"] == null ? context.Request["price"].ToString() : context.Request["totalprice"].ToString())/100;
            string remark= context.Request["remark"]  == null ? "" : context.Request["remark"].ToString();

            string sqlddb = "select * from TM_订单表 where 订单编号='" + ddbh + "'";
            DataTable dtddb = comfun.GetDataTableBySQL(sqlddb);
            if (dtddb.Rows.Count > 0)  //有订单主表信息
            {
                string sqlsel = "select * from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and a.订单编号='" + ddbh + "' and b.商品编号='" + spbh + "'";
                DataTable dtsel = comfun.GetDataTableBySQL(sqlsel);
                if (dtsel.Rows.Count > 0)
                {
                    return;
                }
                else
                {
                    try
                    {
                        comfun.InsertBySQL("insert into TM_订单子表 (商品编号,订单编号,价格,数量,推荐人openid,推荐人订单号,备注) values ('"+spbh+"','"+ddbh+"',"+price+","+count+",'"+otheropenid+"','"+otherddbh+"','"+remark+"')");

                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
            else  //主表子表都没有
            {
                try
                {
                    comfun.InsertBySQL("insert into TM_订单表 (订单编号,总金额,下单时间,openid,备注) values('" + ddbh + "'," + totalprice + ",'" + DateTime.Now + "','" + openid + "','" + remark + "')");
                    comfun.InsertBySQL("insert into TM_订单子表 (商品编号,订单编号,价格,数量,推荐人openid,推荐人订单号,备注) values ('"+spbh+"','"+ddbh+"',"+price+","+count+",'"+otheropenid+"','"+otherddbh+"','"+remark+"')");
                }
                catch (Exception)
                {
                    return;
                }
            
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