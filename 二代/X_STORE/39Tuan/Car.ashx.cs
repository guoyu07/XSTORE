using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Creatrue.kernel;
using WxPayAPI;

namespace Tuan
{
    /// <summary>
    /// Car 的摘要说明
    /// </summary>
    public class Car : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request["type"].ToString();
           
            if (type.Equals("changecount"))
            {
                string openid = context.Request["openid"].ToString();
                int id = Convert.ToInt32(context.Request["id"].ToString());
                int count = Convert.ToInt32(context.Request["count"].ToString());
                comfun.UpdateBySQL("update TM_购物车 set 数量=" + count + " where id=" + id + "");

            }
            else if (type.Equals("del"))  //删除
            {
                int id = Convert.ToInt32(context.Request["id"].ToString());
                comfun.DelbySQL("delete from TM_购物车 where id=" + id + "");
            }
            else if (type.Equals("jiesuan"))//结算
            {
                string ddbh = context.Request["ddbh"].ToString();
                int id = Convert.ToInt32(context.Request["id"].ToString());
                DataTable dtcar = comfun.GetDataTableBySQL("select * from TM_购物车 where id=" + id + "");
                if (dtcar.Rows.Count > 0)
                {
                    
                    string openid2 = dtcar.Rows[0]["openid"].ToString();
                    string spbh = dtcar.Rows[0]["商品编号"].ToString();
                    int count = Convert.ToInt32(dtcar.Rows[0]["数量"].ToString());
                    decimal price = Convert.ToDecimal(dtcar.Rows[0]["单价"].ToString());
                    DataTable dtunionid = comfun.GetDataTableBySQL("select * from WP_会员表 where openid='" + openid2 + "'");
                    string unionid = "";
                    if (dtunionid.Rows.Count > 0)
                    {
                        unionid = dtunionid.Rows[0]["unionid"].ToString();
                    }


                    string sqlddb = "select * from TM_订单表 where 订单编号='" + ddbh + "'";
                    DataTable dtddb = comfun.GetDataTableBySQL(sqlddb);
                    if (dtddb.Rows.Count > 0)  //有订单主表信息
                    {
                        string sqlsel = "select * from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and a.订单编号='"+ddbh+"' and b.商品编号='" + spbh + "'";
                        DataTable dtsel = comfun.GetDataTableBySQL(sqlsel);
                        if (dtsel.Rows.Count > 0)
                        {
                            return;
                        }
                        else
                        {
                            try
                            {
                                comfun.InsertBySQL("insert into TM_订单子表 (商品编号,订单编号,价格,数量,推荐人openid,推荐人订单号,备注) values ('" + spbh + "','" + ddbh + "'," + price + "," + count + ",'','','')");
                                decimal zje = price * count;
                                comfun.UpdateBySQL("update TM_订单表 set 总金额='" + (Convert.ToDecimal(dtddb.Rows[0]["总金额"].ToString())+zje)+  "' where 订单编号="+ddbh+"");
                                int i = comfun.UpdateBySQL("update TM_购物车 set 是否结算=1 where id=" + id + "");
                                if (i > 0)
                                {
                                    context.Response.Write("PageBuy.aspx?openid=" + openid2 + "&price=" + Convert.ToInt32((Convert.ToDecimal(dtddb.Rows[0]["总金额"].ToString()) + zje) * 100) + "&ddbh=" + ddbh + "&otheropenid=&otherddbh=&unionid=" + unionid + "");
                                }
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
                            
                            comfun.InsertBySQL("insert into TM_订单表 (订单编号,总金额,下单时间,openid,备注) values('" + ddbh + "'," + (price * count) + ",'" + DateTime.Now + "','" + openid2 + "','')");
                            comfun.InsertBySQL("insert into TM_订单子表 (商品编号,订单编号,价格,数量,推荐人openid,推荐人订单号,备注) values ('" + spbh + "','" + ddbh + "'," + price + "," + count + ",'','','')");
                            int i = comfun.UpdateBySQL("update TM_购物车 set 是否结算=1 where id=" + id + "");
                            if (i > 0)
                            {
                                context.Response.Write("PageBuy.aspx?openid=" + openid2 + "&price=" + Convert.ToInt32((price * count) * 100) + "&ddbh=" + ddbh + "&otheropenid=&otherddbh=&unionid=" + unionid + "");
                            }
                           
                        }
                        catch (Exception)
                        {
                            return;
                        }

                    }


                  
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