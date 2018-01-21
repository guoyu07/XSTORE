using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tuan;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using Creatrue.kernel;
using System.IO;
using WxPayAPI;

namespace Tuan
{
    public partial class DingInfo : System.Web.UI.Page
    {
        public string bzprice = "";
        public string sanprice = "";
        public string jiuprice = "";
        public string title = "";
        public string scprice = "";
        public string spxq = "";
        public string spts = "";
        public string zysx = "";
        public string zzzm = "";
        public string ppjs = "";
        public string pic = "";
        public string spbh = "";
        public string picli = "";
        public int nowcount = 0;
        public string nowper = "";
        public string openid = "";
        public string otheropenid = "";
        public string otherddbh = "";
        public string unionid = "";
        public static int wxid { set; get; }

        Chat chat = new Chat();
        MoBanMessage moban = new MoBanMessage();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Request["openid"] != null&&Request["unionid"]!=null)
            {
                unionid = Request["unionid"].ToString();
                openid = Request["openid"].ToString();
                if (Request["attach"] != null)
                {
                    string pin = Request["attach"].ToString();
                    string[] a = pin.Split(':');
                    otheropenid = a[0].ToString();
                    otherddbh = a[1].ToString();
                    string spbh2 = a[2].ToString();
                    if (a.Length > 3)
                    {
                        wxid = Convert.ToInt32(a[3].ToString());
                    }

                    if (openid.Equals(otheropenid))  //如果自己的OPENID和该订单的OPENID相同
                    {
                        pagebind();
                    }
                    else
                    {

                        DataTable ddxq = comfun.GetDataTableBySQL("select * from TM_订单表,a TM_订单子表 b where a.订单编号=b.订单编号 and  a.订单编号='" + otherddbh + "'");
                       
                       
                        if (ddxq.Rows.Count > 0)
                        {
                            Response.Redirect("TestGetInfo.aspx?back_url=index.aspx?attach=" + otheropenid + ":" + otherddbh + ":" + ddxq.Rows[0]["商品编号"].ToString() + ":"+wxid+"", false);
                        }
                        else
                        {
                            Response.Redirect("TestGetInfo.aspx?back_url=index.aspx?attach=" + otheropenid + ":" + otherddbh + "::"+wxid+"", false);
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('无效页面！')</script>");
                    Response.Redirect("MyDing.aspx", false);
                }
            }
            else
            {
                string url = HttpContext.Current.Request.Url.Query;
                if (Request["attach"] != null)
                {
                    string pin = Request["attach"];
                    string[] a = pin.Split(':');
                    otheropenid = a[0].ToString();
                    otherddbh = a[1].ToString();
                    spbh = a[2].ToString();
                    DataTable dtsp = comfun.GetDataTableBySQL("select * from TM_商品表 a ,dt_manager b,wx_mp c where a.用户ID=b.id  and b.wxid=c.id and 编号='" + spbh + "' ");
                    if (dtsp.Rows.Count > 0)
                    {
                        if (url.Equals(""))
                            url = "?1+1";
                        else
                        {
                            if(a.Length>3)
                            { 

                            }
                            else
                            { 
                            url += ":" + dtsp.Rows[0]["wxid"].ToString() + "";
                            wxid = Convert.ToInt32(dtsp.Rows[0]["wxid"].ToString());
                            }
                            //  Session["wxid"] = dtsp.Rows[0]["wxid"].ToString();
                        }
                    }
                }
                else
                {
                    if (url.Equals(""))
                        url = "?1+1";
                }
                string str = HttpContext.Current.Request.Url.AbsolutePath;
                string strs = Path.GetFileName(str);


                Response.Redirect("TestGetInfo.aspx?back_url=" + (strs + url),false);
                //    Response.Write("TestGetInfo.aspx?back_url=" + (strs + url));
            }
        }


        #region 页面内容显示 /////////////////////////////////////////////pagebind()
        void pagebind()
        {
            string pin = Request["attach"];
            string[] a = pin.Split(':');
            string openid2 = a[0].ToString();
            string ddbh2 = a[1].ToString();
            string spbh2 = a[2].ToString();

            DataTable dtdd = comfun.GetDataTableBySQL("select * from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and  a.订单编号='" + ddbh2 + "'");
            if (dtdd.Rows.Count > 0)
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
                       if(dtmopay.Rows.Count>0)
                       {
                           moban.payinfo(dtmopay.Rows[0]["mobanid"].ToString(), Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()), openid2, spxx.Rows[0]["品名"].ToString(), Convert.ToDouble(dtdd.Rows[0]["价格"].ToString()));
                       }
                            DataTable dtinfo = comfun.GetDataTableBySQL("select * from WP_订单地址表 where id in (select 地址ID from WP_地址表 where 订单编号='" + ddbh2 + "')");
                            if (dtinfo.Rows.Count > 0)
                            {
                             

                                DataTable dtmo = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%新订单通知%' and wxid=" + Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()) + "");
                                if(dtmo.Rows.Count>0)
                                { 
                                moban.newding(dtmo.Rows[0]["mobanid"].ToString(),Convert.ToInt32(dtmanager.Rows[0]["wxid"].ToString()),dtmanager.Rows[0]["openid"].ToString(), ddbh2, spbh2, Convert.ToDouble(dtdd.Rows[0]["价格"].ToString()), DateTime.Now.ToString(), dtinfo.Rows[0]["手机号"].ToString(), dtinfo.Rows[0]["收货人"].ToString());
                                }
                            }

                        }
                        comfun.InsertBySQL("insert into TM_订单支付表 (订单编号,支付方式,支付金额,openid,支付时间) values('" + ddbh2 + "','微信支付'," + Convert.ToDecimal(dtdd.Rows[0]["价格"].ToString()) + ",'" + openid2 + "','" + DateTime.Now + "')");
                    }
                } 
                #region 团员
                DataTable dttj = comfun.GetDataTableBySQL("select * from TM_订单表 a ,TM_订单子表 b where a.订单编号=b.订单编号 and  a.订单编号 in (select 订单编号 from TM_订单支付表) and 推荐人订单号='" + ddbh2 + "'");
                nowcount = dttj.Rows.Count+1;
                DataTable dtfl = comfun.GetDataTableBySQL("select * from WP_返利表 where openid='" + openid2 + "' and 订单号='" + ddbh2 + "'");
               if(nowcount>=3&&nowcount<9)
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
                           int bzj =Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["本站价"].ToString()) * 100));
                           int stj = Convert.ToInt32((Convert.ToDecimal(dtspxxb.Rows[0]["三团价"].ToString()) * 100));

                           string result = Refund.Run("", ddbh2, bzj.ToString(), (bzj - stj).ToString());
                           Response.Write("<script>alert(" + result + ")</script>");
                           //Response.Write("<script>alert('" + bzj.ToString() + "')</script>");
                           //Response.Write("<script>alert('" + result + "')</script>");
                           DataTable dttui = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%退款通知%' and wxid="+wxid+"");
                           if(dttui.Rows.Count>0)
                           { 
                           moban.TuiInfo(dttui.Rows[0]["mobanid"].ToString(),wxid,openid2, 3, (Convert.ToDouble(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDouble(dtspxxb.Rows[0]["三团价"].ToString())));
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
                                   Response.Write("<script>alert(" + result + ")</script>");
                                    DataTable dttui = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%退款通知%' and wxid="+wxid+"");
                                    if (dttui.Rows.Count > 0)
                                    {
                                        moban.TuiInfo(dttui.Rows[0]["mobanid"].ToString(), wxid,openid2, 9, (Convert.ToDouble(dtspxxb.Rows[0]["三团价"].ToString()) - Convert.ToDouble(dtspxxb.Rows[0]["九团价"].ToString())));
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

                                 string result = Refund.Run("", ddbh2, bzj.ToString(), (bzj-stj).ToString());
                                 Response.Write("<script>alert(" + result + ")</script>");
                                  DataTable dttui = comfun.GetDataTableBySQL("select * from TM_momessage where name like '%退款通知%' and wxid="+wxid+"");
                                  if (dttui.Rows.Count > 0)
                                  {
                                      moban.TuiInfo(dttui.Rows[0]["mobanid"].ToString(), wxid, openid2, 3, (Convert.ToDouble(dtspxxb.Rows[0]["本站价"].ToString()) - Convert.ToDouble(dtspxxb.Rows[0]["三团价"].ToString())));
                                  }
                                        comfun.InsertBySQL("insert into WP_返利表 (openid,订单号,返利金额,返利时间) values('" + openid2 + "','" + ddbh2 + "'," + (Convert.ToDecimal(dtspxxb.Rows[0]["本站价"]) - Convert.ToDecimal(dtspxxb.Rows[0]["三团价"])) + ",'" + DateTime.Now + "')");
                               //Response.Write("<script>alert('" + tuikuanjine + "')</script>");
                           }
                       }
                   }
              

                DataTable dtme = comfun.GetDataTableBySQL("select * from WP_会员表 where openid='" + openid + "'");
                if (dtme.Rows.Count > 0)
                {
                    tuanyuan.Text += "<li><img src=" + dtme.Rows[0]["wx头像"].ToString() + "  /><span class=\"s02\">" + dtme.Rows[0]["wx昵称"].ToString() + "</span></li>";
                }
                if (nowcount == 1)
                {
                    nowper = "2%";
                }
                else
                {
                    nowper = (nowcount * 11) + "%";
                }
                if (dttj.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dttj.Rows.Count; i++)
                    {
                       
                        DataTable dtuserinfo = comfun.GetDataTableBySQL("select * from WP_会员表 where openid='" + dttj.Rows[i]["openid"].ToString() + "'");
                        if (dtuserinfo.Rows.Count > 0)
                        { 
                        tuanyuan .Text+= "<li><img src=" + dtuserinfo.Rows[0]["wx头像"].ToString() + "  /><span class=\"s02\">" + dtuserinfo.Rows[0]["wx昵称"].ToString() + "</span></li>";
                        }
                    }
                   
                }
                
                #endregion

                DataTable dt = comfun.GetDataTableBySQL("select * from TM_商品表 where 编号='"+dtdd.Rows[0]["商品编号"].ToString()+"'");
                if (dt.Rows.Count > 0)
                {
                    title = dt.Rows[0]["品名"].ToString();
                   
                    spbh = dt.Rows[0]["编号"].ToString();
                    bzprice = dt.Rows[0]["本站价"].ToString();
                    scprice = dt.Rows[0]["市场价"].ToString();
                    sanprice = dt.Rows[0]["三团价"].ToString();
                    jiuprice = dt.Rows[0]["九团价"].ToString();
                    DataTable dtpic = comfun.GetDataTableBySQL("select * from TM_商品图片表 where 商品编号='" + spbh + "'");
                    DataTable dtxq = comfun.GetDataTableBySQL("select * from TM_商品详情表 where 商品编号='" + spbh + "'");
                    if (dtpic.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtpic.Rows.Count; i++)
                        {
                            pic += "<li><img src='" + dtpic.Rows[i]["图片路径"].ToString() + "'></li>";
                            if (i == 0)
                            {
                                picli += "<li class=\"on\"></li>";
                            }
                            else {
                                picli += "<li></li>";
                            }
                        }
                    }
                    else
                    {
                        pic = "<li><img src='images/03.jpg'></li>";   //没有图片
                        picli = "<li class=\"on\"></li>";
                    }
                    if (dtxq.Rows.Count > 0)
                    {
                        spxq = dtxq.Rows[0]["描述"].ToString();
                        spts = dtxq.Rows[0]["特点"].ToString();
                        zysx = dtxq.Rows[0]["注意事项"].ToString();
                        zzzm = dtxq.Rows[0]["资质证明"].ToString();
                        ppjs = dtxq.Rows[0]["品牌介绍"].ToString();
                    }
                
            }
            else
            {
                Response.Write("<script>alert('该订单不存在！')</script>");
                Response.Redirect("myding.aspx");
            }
           
            

            }
        }
        #endregion

    }
}