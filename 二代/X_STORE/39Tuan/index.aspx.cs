using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tuan;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using WxPayAPI;
using System.Collections;

namespace Tuan
{
    public partial class index : System.Web.UI.Page
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
        public string openid = "";
        public string picli = "";
        public string otheropenid = "";
        public string otherddbh = "";
        Chat chat = new Chat();
        public string pin = "";
        public string signature = "";
        public string timestamp = "";
        public string nonceStr = "";
        public string appid = "";
        public string picurl = "";
        public string unionid = "";
        public string ddbh=WxPayApi.GenerateOutTradeNo().ToString();
        public static string spbhurl { set; get; }
        public static int wxid { set; get; }
        public string lx = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            #region "原有正确代码"
            //if (Request["openid"] != null && Request["name"] != null && Request["headimg"] != null)
            //{
            //    unionid = Request["unionid"].ToString();
            //    if (Request["attach"] != null)
            //    {
            //        string pin = Request["attach"];
            //        string[] a = pin.Split(':');
            //        otheropenid = a[0].ToString();
            //        otherddbh = a[1].ToString();
            //        spbh = a[2].ToString();
            //        spbhurl = a[2].ToString();
            //        if (a.Length > 3)
            //        {
            //            wxid = Convert.ToInt32(a[3].ToString());
            //            chat.wxid = wxid;
            //            appid = chat.appid();
            //            //Response.Write("<script>alert('" + wxid + "')</script>");
            //            //Response.Write("<script>alert('" + appid + "')</script>");
            //            WXJSSDK jssdk = new WXJSSDK(chat.appid(), chat.secret());
            //            Hashtable hs = jssdk.getSignPackage();
            //             signature = hs["signature"].ToString();
            //             timestamp = hs["timestamp"].ToString();
            //             nonceStr = hs["nonceStr"].ToString();
            //             //Response.Write("<script>alert(location.href.split('#')[0])</script>");
            //             //Response.Write("<script>alert('" + hs["appId"].ToString() + "," + hs["nonceStr"].ToString() + "," + hs["timestamp"].ToString() + "," + hs["url"].ToString() + "," + hs["signature"].ToString() + "," + hs["rawString"].ToString() + "')</script>");
                         
            //        }
            //        else
            //        {
            //            chat.wxid = 0;
            //            appid = chat.appid();
            //            //Response.Write("<script>alert('" + wxid + "')</script>");
            //            //Response.Write("<script>alert('" + appid + "')</script>");
            //            WXJSSDK jssdk = new WXJSSDK(chat.appid(), chat.secret());
            //            Hashtable hs = jssdk.getSignPackage();
            //            signature = hs["signature"].ToString(); 
            //            timestamp = hs["timestamp"].ToString();
            //            nonceStr = hs["nonceStr"].ToString();
            //            //Response.Write("<script>alert(location.href.split('#')[0])</script>");
            //            //Response.Write("<script>alert('" + hs["appId"].ToString() + "," + hs["nonceStr"].ToString() + "," + hs["timestamp"].ToString() + "," + hs["url"].ToString() + "," + hs["signature"].ToString() + "," + hs["rawString"].ToString() + "')</script>");
            //            ////Response.Write("<script>alert('" + timestamp + "')</script>"); 
            //            //Response.Write("<script>alert('" + hs["url"].ToString() + "')</script>");
            //            //Response.Write("<script>alert('" + signature + "')</script>");
            //        }

            //        pagebind(spbh);
            //        //     Response.Write("<script>alert('" + wxid + "')</script>");
            //        //   WxPayConfig.main();
            //        // Response.Write("<script>alert('" + WxPayConfig.APPID + "')</script>");
            //    }
            //    else
            //    {
            //        pagebind(spbh);
            //        //Response.Write("<script>alert('链接失效！')</script>");
            //    }

            //    userbind();
            //    string userPhonetype = " IOS";
            //    try
            //    {
                    
            //        //request用户手机的 User-Agent
            //        string userAgent = Request.ServerVariables.Get("HTTP_USER_AGENT");
            //        //把userAgent中取得的信息拆分
            //        string[] agent = userAgent.Split(';');
            //        if (agent.Length > 2)
            //        {
            //            userPhonetype = agent[2];
            //            //      userPhonetype=userPhonetype.Replace(" ", "");
            //        }
            //    }
            //    catch (Exception)
            //    {
                    
                    
            //    }
         
            //    if (otherddbh != "" && otheropenid != "")
            //    {
            //        try
            //        {

                  
            //       // string IP = Page.Request.UserHostAddress;
            //        string IP = Request.ServerVariables["REMOTE_ADDR"];
            //        comfun.InsertBySQL("insert into TM_浏览记录表  (浏览人openid,分享人openid,订单编号,浏览时间,IP,设备型号) values('" + openid + "','" + otheropenid + "','" + otherddbh + "','" + DateTime.Now + "','" + IP + "','" + userPhonetype + "')");
            //        DataTable dtfx = comfun.GetDataTableBySQL("select * from TM_分享记录表 where 分享人openid='" + otheropenid + "' and 订单编号='" + otherddbh + "'");
            //        if (dtfx.Rows.Count > 0)
            //        {   //修改
            //            int count=Convert.ToInt32(dtfx.Rows[0]["浏览次数"].ToString());

            //            comfun.UpdateBySQL("update TM_分享记录表 set 浏览次数=" + (count + 1) + " where id=" + Convert.ToInt32(dtfx.Rows[0]["id"].ToString()) + "");
            //        }
            //        else
            //        { //添加
            //            comfun.InsertBySQL("insert into TM_分享记录表 values ('" + otheropenid + "','" + otherddbh + "','" + DateTime.Now + "',0)");
            //        }
            //        }
            //        catch (Exception)
            //        {

                       
            //        }
            //    }
            //    else
            //    {
            //        //Response.Write("<script>alert('"+openid+"')</script>");
            //        // Response.Write("<script>alert('" + IP + "')</script>");
            //        //Response.Write("<script>alert('"+userPhonetype+"')</script>");(浏览人openid,分享人openid,订单编号,浏览时间,IP,设备型号)

            //        //string IP = Page.Request.UserHostAddress;
            //        try
            //        {

                  
            //        string IP = Request.ServerVariables["REMOTE_ADDR"];
            //        comfun.InsertBySQL("insert into TM_浏览记录表  values('" + openid + "','','','" + DateTime.Now + "','" + IP + "','" + userPhonetype + "')");
               
            //          }
            //        catch (Exception)
            //        {
                        
                    
            //        }
            //    }
            //}
            //else
            //{
            //    string url = HttpContext.Current.Request.Url.Query;
            //    if (Request["attach"] != null)
            //    {
            //        string pin = Request["attach"];
            //        string[] a = pin.Split(':');
            //        otheropenid = a[0].ToString();
            //        otherddbh = a[1].ToString();
            //        spbh = a[2].ToString();

            //        DataTable dtsp = comfun.GetDataTableBySQL("select * from TM_商品表 a ,dt_manager b,wx_mp c where a.用户ID=b.id  and b.wxid=c.id and 编号='" + spbh + "' ");
            //        if (dtsp.Rows.Count > 0)
            //        {
            //            if (url.Equals(""))
            //                url = "?1+1";
            //            else
            //            {
            //                url += ":" + dtsp.Rows[0]["wxid"].ToString() + "";
            //                wxid = Convert.ToInt32(dtsp.Rows[0]["wxid"].ToString());

            //                //  Session["wxid"] = dtsp.Rows[0]["wxid"].ToString();
            //            }
            //        }

            //    }
            //    else
            //    {
            //        if (url.Equals(""))
            //            url = "?1+1";
            //    }
            //    string str = HttpContext.Current.Request.Url.AbsolutePath;
            //    string strs = Path.GetFileName(str);
                

            //    Response.Redirect("TestGetInfo.aspx?back_url=" + (strs + url));
            //}

            #endregion

            string pin = Request["attach"].ToString().Replace("::","");
            pagebind(pin);

            //userbind();
        }


        #region 页面内容显示 /////////////////////////////////////////////pagebind()
        void pagebind(string ddbh)
        {
            string sql = "";
            if (ddbh != "")
            {
                sql = "select * from TM_商品表 where isshow=1 and 是否上架=1 and 下架时间>convert(varchar(50),'" + DateTime.Now + "',120)  and 编号='" + ddbh + "'";
            }
            else
            {
                sql = "select top 1 * from TM_商品表 where isshow=1 and 是否上架=1 and 下架时间>convert(varchar(50),'" + DateTime.Now + "',120)  ";
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                lx = dt.Rows[0]["类型"].ToString();
                title = dt.Rows[0]["品名"].ToString();
                Session["body"] = title;
                spbh = dt.Rows[0]["编号"].ToString();
                bzprice = dt.Rows[0]["本站价"].ToString();
                scprice = dt.Rows[0]["市场价"].ToString();
                sanprice = dt.Rows[0]["三团价"].ToString();
                jiuprice = dt.Rows[0]["九团价"].ToString();
                DataTable dtpic = comfun.GetDataTableBySQL("select * from TM_商品图片表 where 商品编号='" + spbh + "'");
                DataTable dtxq = comfun.GetDataTableBySQL("select * from TM_商品详情表 where 商品编号='" + spbh + "'");
                if (dtpic.Rows.Count > 0)
                {
                    picurl = dtpic.Rows[0]["图片路径"].ToString();
                    for (int i = 0; i < dtpic.Rows.Count; i++)
                    {
                        pic += "<li><img src='" + dtpic.Rows[i]["图片路径"].ToString() + "'></li>";
                        if (i == 0)
                        {
                            picli += "<li class=\"on\"></li>";
                        }
                        else
                        {
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
                string sql1 = "";
                if (ddbh != "")
                {
                    sql1 = "select * from TM_商品表 where 编号='" + ddbh + "'";
                }
                else
                {
                    sql1 = "select top 1* from TM_商品表 order by id desc";
                }
                DataTable dt1 = comfun.GetDataTableBySQL(sql1);
                if (dt1.Rows.Count > 0)
                {
                    title = dt1.Rows[0]["品名"].ToString();
                    spbh = dt1.Rows[0]["编号"].ToString();
                    bzprice = dt1.Rows[0]["本站价"].ToString();
                    scprice = dt1.Rows[0]["市场价"].ToString();
                    sanprice = dt1.Rows[0]["三团价"].ToString();
                    jiuprice = dt1.Rows[0]["九团价"].ToString();
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
                            else
                            {
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
                //按钮
                ding.Value = "本团已结束";
                ding.Disabled = true;

            }
        }
        #endregion


        #region 用户微信信息插入表
        void userbind()
        {
            string name = "";
            string headimg = "";
            int wxid = 0;
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
                    wxid = Convert.ToInt32(dtsp.Rows[0]["wxid"].ToString());
                }
            }
            else
            {

            }
            if (Request["openid"] != null)
            {
                openid = Request["openid"].ToString();
                name = Request["name"].ToString();
                headimg = Request["headimg"].ToString();
            }
            DataTable dtuser = comfun.GetDataTableBySQL("select * from WP_会员表 where openid='" + openid + "'");
            if (dtuser.Rows.Count > 0)
            {
                if (wxid == 0)
                    wxid = 1;
                comfun.UpdateBySQL("update WP_会员表 set openid='" + openid + "',wx昵称='" + name + "',wx头像='" + headimg + "',手机号='" + dtuser.Rows[0]["手机号"].ToString() + "',wxid=" + wxid + ",unionid='"+Request["unionid"].ToString()+"' where id=" + Convert.ToInt32(dtuser.Rows[0]["id"].ToString()) + "");


            }
            else
            {
                if (wxid == 0)
                    wxid = 1;
                comfun.InsertBySQL("insert into WP_会员表(openid,wx昵称,wx头像,手机号,wxid,unionid) values ('" + openid + "','" + name + "','" + headimg + "',''," + wxid + ",'"+Request["unionid"].ToString()+"')");
            }
        }
        #endregion



    }
}