using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Tuan;

namespace Tuan
{
    /// <summary>
    /// PaySQL 的摘要说明
    /// </summary>
    public class PaySQL : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                string openid = context.Request["openid"].ToString();
                string ddbh = context.Request["ddbh"].ToString();
                string name = context.Request["name"].ToString();
                string tel = context.Request["tel"].ToString();
                string spbh = context.Request["spbh"].ToString();
                string otheropenid = context.Request["otheropenid"].ToString();
                string otherddbh = context.Request["otherddbh"].ToString();
                string dzid = context.Request["dzid"].ToString();
                if (dzid.Equals(""))
                {
                    context.Response.Write("请完善收获地址！");
                    return;
                }

                DataTable dtaddress = comfun.GetDataTableBySQL("select * from WP_地址表 where 订单编号 ='" + ddbh + "' and openid='" + openid + "' and 地址ID='" + dzid + "'");
                int i = 0;
                if (dtaddress.Rows.Count > 0)
                {
                    i = 1;

                }
                else
                {
                    i = comfun.InsertBySQL("insert into WP_地址表 (openid,订单编号,地址ID) values ('" + openid + "','" + ddbh + "','" + dzid + "')");
                }

              
                    DataTable dtdd = comfun.GetDataTableBySQL("select * from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and  a.订单编号='" + ddbh + "'");
                    int b = 0;
                    if (dtdd.Rows.Count > 0)
                    {
                        b = 1;
                    }
                    else
                    {

                        //  b = comfun.InsertBySQL("insert into TM_订单表 (订单编号,总金额,下单时间,openid,备注) values('" + ddbh + "','" + Convert.ToDecimal(dtsp.Rows[0]["本站价"].ToString()) + "','" + DateTime.Now + "','" + openid + "','无')");
                        //    b = comfun.InsertBySQL("insert into TM_订单子表 (商品编号,订单编号,价格,数量,推荐人openid,推荐人订单号,备注) values('" + spbh + "','" + ddbh + "','" + Convert.ToDecimal(dtsp.Rows[0]["本站价"].ToString()) + "',1,'" + otheropenid + "','" + otherddbh + "','无')");
                    }
                    if (b > 0 && i > 0)
                    {
                        //HttpContext.Current.Session["ddbh"] = ddbh;
                        //HttpContext.Current.Session["openid"] = openid;
                        // context.Response.Write(b);
                        DataTable dtspxx = comfun.GetDataTableBySQL("select * from TM_商品表 a ,dt_manager b,wx_mp c where a.用户ID=b.id  and b.wxid=c.id and 编号='" + spbh + "'");
                        if (dtspxx.Rows.Count > 0)
                        {
                            context.Response.Write("" + openid + ":" + ddbh + ":" + dtdd.Rows[0]["商品编号"] + ":" + dtspxx.Rows[0]["wxid"].ToString() + "");
                        }


                    }
                    //else
                    //{
                    //    context.Response.Write("<script>alert('支付失败，请重新下单')</script>");
                    //}
                
                //else
                //{
                //    context.Response.Write("<script>alert('该商品不存在')</script>");
                //    context.Response.Redirect("index.aspx");
                //}
            }
            catch (Exception)
            {
                context.Response.Write("请完善收获信息！");
                throw;
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