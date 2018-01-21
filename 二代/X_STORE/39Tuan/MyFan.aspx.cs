using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;

namespace Tuan
{
    public partial class MyFan : System.Web.UI.Page
    {
        Chat chat = new Chat();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["unionid"] != null)
                {
                    //  Response.Write("<script>alert('"+Request.Url.AbsoluteUri+"')</script>"); "http://hongdou.creatrue.net/tuan/myding.aspx"
                    string unionid = Request["unionid"].ToString();
                    DataTable dtdd = comfun.GetDataTableBySQL("select a.订单号 as ddbh,* from WP_返利表 a,TM_订单表 b,TM_订单子表 d,TM_商品表 c where b.订单编号=d.订单编号 and  a.订单号=b.订单编号 and d.商品编号=c.编号 and a.openid in (select openid from WP_会员表 where unionid='" + unionid + "')  order by 返利时间 desc ");
                    if (dtdd.Rows.Count > 0)
                    {

                        string str = "";
                        for (int i = 0; i < dtdd.Rows.Count; i++)
                        {
                            string img = "<img src=\"images/03.jpg\" />";
                            DataTable dtimg = comfun.GetDataTableBySQL("select top 1* from TM_商品图片表 where 商品编号='" + dtdd.Rows[i]["编号"].ToString() + "'");
                            if (dtimg.Rows.Count > 0)
                            {
                                img = "<img src=" + dtimg.Rows[0]["图片路径"].ToString() + " />";
                            }
                            str += "<div class=\"order_messgae_list\"><div class=\"wrap padd_10\">";
                            str += "<div class=\"title\">订单号：" + dtdd.Rows[i]["ddbh"].ToString() + "</div>";
                            str += " <div class=\"content clear\">";
                            str += "	<div class=\"fl pic\"><a href='DingInfo.aspx?attach=" + dtdd.Rows[i]["openid"] + ":" + dtdd.Rows[i]["ddbh"] + ":" + dtdd.Rows[i]["编号"] + "'>" + img + "</a></div>";
                            str += "   <div class=\"txt fl\"><a href='DingInfo.aspx?attach=" + dtdd.Rows[i]["openid"] + ":" + dtdd.Rows[i]["ddbh"] + ":" + dtdd.Rows[i]["编号"] + "'>" + (dtdd.Rows[i]["品名"].ToString().Length > 20 ? dtdd.Rows[i]["品名"].ToString().Substring(0, 19) + "......" : dtdd.Rows[i]["品名"].ToString()) + "</a></div>";
                            str += "   <div class=\"old_pic fr\">¥ " + dtdd.Rows[i]["三团价"].ToString() + "</div></div>";
                            str += "  <div class=\"price clear\"><div class=\"fl\"><span>实付：</span><strong>¥ " + dtdd.Rows[i]["三团价"].ToString() + "</strong></div>";
                            str += "<div class=\"fr\"><span>返利：</span><strong>¥ " + dtdd.Rows[i]["返利金额"].ToString() + "</strong></div></div>";
                            str += "</div></div><div class=\"hei_15\"></div>";

                        }

                        Literal1.Text = str;
                    }

                    else
                    {
                        Response.Redirect("emptyfan.aspx");

                    }
                }
                else
                {
                    //string str = HttpContext.Current.Request.Url.AbsolutePath;
                    //string strs = Path.GetFileName(str);
                    //string url = HttpContext.Current.Request.Url.Query;
                    //if (url.Equals(""))
                    //    url = "?1+1";
                    //Response.Redirect("TestGetInfo.aspx?back_url=" + (strs + url));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                // chat.GetCode(Request.Url.AbsoluteUri);
            }

        }
    }
}