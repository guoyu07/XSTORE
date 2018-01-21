using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxPayAPI;
using _39Tuan;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using wp.kernel;
using System.Data;

namespace _39Tuan
{
    public partial class CheckInfo : System.Web.UI.Page
    {
        Chat chat = new Chat();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
            if (Request["code"] != null)
            {
               
                if (Request["openid"] == null)
                {
                    Response.Write("<script>alert('该页面不存在')</script>");
                }
                else
                {

                   
                   string pin = Request["openid"];
                   string[] a = pin.Split(':');
                   string openid2 = a[0].ToString();
                   string ddbh2 = a[2].ToString();
                   string openid = chat.Openid("http://www.china-mail.com.cn/39tuan/tuan/CheckInfo.aspx");
                    
                   if (openid.Equals(openid2))  //如果自己的OPENID和该订单的OPENID相同
                    {
                        
                       DataTable dtsp=comfun.GetDataTableBySQL("select * from wp_订单表 where 订单编号='"+ddbh2+"' and openid='"+openid2+"'");
                       if(dtsp.Rows.Count>0)
                       {
                           DataTable dtddzf = comfun.GetDataTableBySQL("select * from wp_订单支付表 where 订单编号='" + ddbh2 + "' and openid='" + openid2 + "'");
                           if (dtddzf.Rows.Count > 0)
                           {
                               Session["openid2"] = openid2;
                               Session["ddbh2"] = ddbh2;
                               Response.Redirect("index.aspx");

                           }
                           else
                           { 
                           comfun.InsertBySQL("insert into wp_订单支付表 (订单编号,支付方式,支付金额,openid,支付时间) values('" + ddbh2 + "','微信支付'," + Convert.ToDecimal(dtsp.Rows[0]["金额"].ToString()) + ",'" + openid2 + "','" + DateTime.Now + "')");

                           } 
                           textshare.Text = "感谢您购买，赶快分享到朋友圈，邀请好友购买！";
                          
                       }
                       
                    }
                    else //不同
                    {
                       // textshare.Text = "请到首页购买物品后进行分享！";

                        //Session["openid2"] = openid2;
                        //Session["ddbh2"] = ddbh2;
                        string spbh = "";
                           DataTable dtsp=comfun.GetDataTableBySQL("select * from wp_订单表 where 订单编号='"+ddbh2+"' and openid='"+openid2+"'");
                           if (dtsp.Rows.Count > 0)
                           {
                               spbh = dtsp.Rows[0]["商品编号"].ToString();
                           }
                        Response.Redirect("index.aspx?attach="+openid2+":"+ddbh2+":"+spbh+"");
                        //Response.Write(Session["openid2"]+"<br/>");
                        
                        //Response.Write(Session["ddbh2"]);
                    }





                }
            }
            else
            {
                if (Request["openid"] == null)
                {

                    chat.GetCode("http://www.china-mail.com.cn/39tuan/tuan/CheckInfo.aspx");
                }
                else
                {
                    string pin = Request["openid"];
                    string[] a = pin.Split(':');
                    string openid2 = a[0].ToString();
                    string ddbh2 = a[2].ToString();

                    chat.GetCode("http://www.china-mail.com.cn/39tuan/tuan/CheckInfo.aspx?openid=" + openid2 + ":" + ddbh2 + "");
                }
               

            }

            }
        }
    }
}