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
    /// Pay 的摘要说明
    /// </summary>
    public class Pay : IHttpHandler
    {
        MoBanMessage moban = new MoBanMessage();
        public int nowcount = 0;
        public static int wxid { set; get; }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request["type"].ToString();
            if (type.Equals("39"))
            {
                pagebind39();
            }
            else if(type.Equals("13"))
            {
                pagebind();
            }
        }
        #region pagebind()
        void pagebind()
        {
            string pin = HttpContext.Current.Request["msg"];
            string[] a = pin.Split(':');
            string openid2 = a[0].ToString();
            string ddbh2 = a[1].ToString();

            DataTable dtdd = comfun.GetDataTableBySQL("select * from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and  a.订单编号='" + ddbh2 + "'");
            if (dtdd.Rows.Count > 0)
            {

                for (int i = 0; i < dtdd.Rows.Count; i++)
                {


                    DataTable dtddzf = comfun.GetDataTableBySQL("select * from TM_订单支付表 where 订单编号='" + ddbh2 + "' and openid='" + openid2 + "'");
                    if (dtddzf.Rows.Count > 0)
                    {


                    }
                    else
                    {
                        DataTable spxx = comfun.GetDataTableBySQL("select * from TM_商品表 where 编号='" + dtdd.Rows[i]["商品编号"].ToString() + "'");
                        if (spxx.Rows.Count > 0)
                        {
                            comfun.UpdateBySQL("update TM_商品表 set 库存数量=" + (Convert.ToInt32(spxx.Rows[0]["库存数量"].ToString()) - 1) + " where id=" + Convert.ToInt32(spxx.Rows[0]["id"].ToString()) + "");


                            DataTable dtmanager = comfun.GetDataTableBySQL("select * from dt_manager where id=" + Convert.ToInt32(spxx.Rows[0]["用户ID"].ToString()) + "");
                            if (dtmanager.Rows.Count > 0)
                            {
                                DataTable dtmopay = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%订单支付成功%' and wxid=" + Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()) + "");
                                if (dtmopay.Rows.Count > 0)
                                {
                                    moban.payinfo(dtmopay.Rows[0]["mobanid"].ToString(), Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()), openid2, spxx.Rows[0]["品名"].ToString(), Convert.ToDouble(dtdd.Rows[i]["总金额"].ToString()));
                                }
                                DataTable dtinfo = comfun.GetDataTableBySQL("select * from WP_订单地址表 where id in (select 地址ID from WP_地址表 where 订单编号='" + ddbh2 + "')");
                                if (dtinfo.Rows.Count > 0)
                                {


                                    DataTable dtmo = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%新订单通知%' and wxid=" + Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()) + "");
                                    if (dtmo.Rows.Count > 0)
                                    {
                                        moban.newding(dtmo.Rows[0]["mobanid"].ToString(), Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()), dtmanager.Rows[0]["openid"].ToString(), ddbh2, dtdd.Rows[i]["商品编号"].ToString(), Convert.ToDouble(dtdd.Rows[i]["总金额"].ToString()), DateTime.Now.ToString(), dtinfo.Rows[0]["手机号"].ToString(), dtinfo.Rows[0]["收货人"].ToString());
                                    }
                                }

                            }
                           int zf= comfun.InsertBySQL("insert into TM_订单支付表 (订单编号,支付方式,支付金额,openid,支付时间) values('" + ddbh2 + "','微信支付'," + Convert.ToDecimal(dtdd.Rows[0]["价格"].ToString()) + ",'" + openid2 + "','" + DateTime.Now + "')");
                           if (zf > 0)
                           {
                               HttpContext.Current.Response.Write("MyDing.aspx");
                           }
                        }
                    }
                }

            }
        }
        #endregion


        #region 39 /////////////////////////////////////////////pagebind()
        void pagebind39()
        {
           
            string pin = HttpContext.Current.Request["msg"];
            string[] a = pin.Split(':');
            string openid2 = a[0].ToString();
            string ddbh2 = a[1].ToString();
            string spbh2 = a[2].ToString();

            DataTable dtdd = comfun.GetDataTableBySQL("select * from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and  a.订单编号='" + ddbh2 + "'");
            if (dtdd.Rows.Count > 0)
            {

                for (int i = 0; i < dtdd.Rows.Count; i++)
                {
                    
                
                DataTable dtddzf = comfun.GetDataTableBySQL("select * from TM_订单支付表 where 订单编号='" + ddbh2 + "' and openid='" + openid2 + "'");
                if (dtddzf.Rows.Count > 0)
                {


                }
                else
                {
                    DataTable spxx = comfun.GetDataTableBySQL("select * from TM_商品表 where 编号='" + dtdd.Rows[0]["商品编号"].ToString() + "'");
                    if (spxx.Rows.Count > 0)
                    {
                        comfun.UpdateBySQL("update TM_商品表 set 库存数量=" + (Convert.ToInt32(spxx.Rows[0]["库存数量"].ToString()) - 1) + " where id=" + Convert.ToInt32(spxx.Rows[0]["id"].ToString()) + "");


                        DataTable dtmanager = comfun.GetDataTableBySQL("select * from dt_manager where id=" + Convert.ToInt32(spxx.Rows[0]["用户ID"].ToString()) + "");
                        if (dtmanager.Rows.Count > 0)
                        {
                            DataTable dtmopay = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%订单支付成功%' and wxid=" + Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()) + "");
                            if (dtmopay.Rows.Count > 0)
                            {
                                moban.payinfo(dtmopay.Rows[0]["mobanid"].ToString(), Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()), openid2, spxx.Rows[0]["品名"].ToString(), Convert.ToDouble(dtdd.Rows[0]["价格"].ToString()));
                            }
                            DataTable dtinfo = comfun.GetDataTableBySQL("select * from WP_订单地址表 where id in (select 地址ID from WP_地址表 where 订单编号='" + ddbh2 + "')");
                            if (dtinfo.Rows.Count > 0)
                            {


                                DataTable dtmo = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%新订单通知%' and wxid=" + Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()) + "");
                                if (dtmo.Rows.Count > 0)
                                {
                                    moban.newding(dtmo.Rows[0]["mobanid"].ToString(), Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()), dtmanager.Rows[0]["openid"].ToString(), ddbh2, spbh2, Convert.ToDouble(dtdd.Rows[0]["价格"].ToString()), DateTime.Now.ToString(), dtinfo.Rows[0]["手机号"].ToString(), dtinfo.Rows[0]["收货人"].ToString());
                                }
                            }

                        }
                        comfun.InsertBySQL("insert into TM_订单支付表 (订单编号,支付方式,支付金额,openid,支付时间) values('" + ddbh2 + "','微信支付'," + Convert.ToDecimal(dtdd.Rows[0]["价格"].ToString()) + ",'" + openid2 + "','" + DateTime.Now + "')");
                    }
                }
                #region 团员
                DataTable dttj = comfun.GetDataTableBySQL("select * from TM_订单表 a ,TM_订单子表 b where a.订单编号=b.订单编号 and  a.订单编号 in (select 订单编号 from TM_订单支付表) and 推荐人订单号='" + ddbh2 + "'");
                nowcount = dttj.Rows.Count + 1;
                DataTable dtfl = comfun.GetDataTableBySQL("select * from WP_返利表 where openid='" + openid2 + "' and 订单号='" + ddbh2 + "'");
                if (nowcount >= 3 && nowcount < 9)
                {
                    if (dtfl.Rows.Count > 0)
                    {

                    }
                    else                                       //返3团 
                    {
                        DataTable dtspxxb = comfun.GetDataTableBySQL("select * from TM_商品表 a ,dt_manager b,wx_mp c where a.用户ID=b.id  and b.wxid=c.id and 编号='" + spbh2 + "' ");
                        if (dtspxxb.Rows.Count > 0)
                        {
                            wxid = Convert.ToInt32(dtspxxb.Rows[0]["wxid"].ToString());


                            //Response.Write("<script>alert('" + Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) + "')</script>");
                            //Response.Write("<script>alert('" + Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString()) + "')</script>");
                            //Response.Write("<script>alert('" + (Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString())) + "')</script>");
                            // decimal tuikuanjine = (Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString()));
                            int bzj = Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) * 100));
                            int stj = Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString()) * 100));

                            string result = Refund.Run("", ddbh2, bzj.ToString(), (bzj - stj).ToString());
                           
                            //Response.Write("<script>alert('" + bzj.ToString() + "')</script>");
                            //Response.Write("<script>alert('" + result + "')</script>");
                            DataTable dttui = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%退款通知%' and wxid=" + wxid + "");
                            if (dttui.Rows.Count > 0)
                            {
                                moban.TuiInfo(dttui.Rows[0]["mobanid"].ToString(), wxid, openid2, 3, (Convert.ToDouble(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDouble(dtspxxb.Rows[0]["三团价"].ToString())));
                            }


                            comfun.InsertBySQL("insert into WP_返利表 (openid,订单号,返利金额,返利时间) values('" + openid2 + "','" + ddbh2 + "'," + (Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString())) + ",'" + DateTime.Now + "')");
                            //   Response.Write("<script>alert('" + tuikuanjine + "')</script>");
                        }
                    }
                }
                else
                    if (nowcount >= 9)
                    {
                        if (dtfl.Rows.Count > 0)
                        {
                            if (dtfl.Rows.Count == 1)  //返9团 
                            {
                                DataTable dtspxxb = comfun.GetDataTableBySQL("select * from TM_商品表 a ,dt_manager b,wx_mp c where a.用户ID=b.id  and b.wxid=c.id and 编号='" + spbh2 + "' ");
                                if (dtspxxb.Rows.Count > 0)
                                {
                                    wxid = Convert.ToInt32(dtspxxb.Rows[0]["wxid"].ToString());

                                    //Response.Write("<script>alert('" + Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) + "')</script>");
                                    //Response.Write("<script>alert('" + Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString()) + "')</script>");
                                    //Response.Write("<script>alert('" + (Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString())) + "')</script>");
                                    //  decimal tuikuanjine = (Convert.ToDecimal(dtspxxb.Rows[0]["三团价"]) - Convert.ToDecimal(dtspxxb.Rows[0]["九团价"]));
                                    int jtj = Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["九团价"].ToString()) * 100));
                                    int bzj = Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) * 100));
                                    int stj = Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString()) * 100));
                                    string result = Refund.Run("", ddbh2, bzj.ToString(), (stj - jtj).ToString());
                                   
                                    DataTable dttui = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%退款通知%' and wxid=" + wxid + "");
                                    if (dttui.Rows.Count > 0)
                                    {
                                        moban.TuiInfo(dttui.Rows[0]["mobanid"].ToString(), wxid, openid2, 9, (Convert.ToDouble(dtspxxb.Rows[0]["三团价"].ToString()) - Convert.ToDouble(dtspxxb.Rows[0]["九团价"].ToString())));
                                    }
                                    //Response.Write("<script>alert('" + tuikuanjine + "')</script>");
                                    comfun.InsertBySQL("insert into WP_返利表 (openid,订单号,返利金额,返利时间) values('" + openid2 + "','" + ddbh2 + "'," + (Convert.ToDecimal(dtspxxb.Rows[0]["三团价"]) - Convert.ToDecimal(dtspxxb.Rows[0]["九团价"])) + ",'" + DateTime.Now + "')");

                                }
                            }

                        }
                        else                                       //返3团 
                        {
                            DataTable dtspxxb = comfun.GetDataTableBySQL("select * from TM_商品表 a ,dt_manager b,wx_mp c where a.用户ID=b.id  and b.wxid=c.id and 编号='" + spbh2 + "' ");
                            if (dtspxxb.Rows.Count > 0)
                            {
                                wxid = Convert.ToInt32(dtspxxb.Rows[0]["wxid"].ToString());
                                //    Response.Write("<script>alert('返3团 ')</script>");
                                //Response.Write("<script>alert('" + Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) + "')</script>");
                                //Response.Write("<script>alert('" + Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString()) + "')</script>");
                                //Response.Write("<script>alert('" + (Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString())) + "')</script>");
                                //  decimal tuikuanjine = (Convert.ToDecimal(dtspxxb.Rows[0]["本站价"]) - Convert.ToDecimal(dtspxxb.Rows[0]["三团价"]));
                                int bzj = Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) * 100));
                                int stj = Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString()) * 100));

                                string result = Refund.Run("", ddbh2, bzj.ToString(), (bzj - stj).ToString());
                            
                                DataTable dttui = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%退款通知%' and wxid=" + wxid + "");
                                if (dttui.Rows.Count > 0)
                                {
                                    moban.TuiInfo(dttui.Rows[0]["mobanid"].ToString(), wxid, openid2, 3, (Convert.ToDouble(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDouble(dtspxxb.Rows[0]["三团价"].ToString())));
                                }
                                comfun.InsertBySQL("insert into WP_返利表 (openid,订单号,返利金额,返利时间) values('" + openid2 + "','" + ddbh2 + "'," + (Convert.ToDecimal(dtspxxb.Rows[0]["本站价"]) - Convert.ToDecimal(dtspxxb.Rows[0]["三团价"])) + ",'" + DateTime.Now + "')");
                                //Response.Write("<script>alert('" + tuikuanjine + "')</script>");
                            }
                        }
                    }

                }

                #endregion

            



            }
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}