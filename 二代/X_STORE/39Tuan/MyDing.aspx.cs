using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tuan;
using System.IO;

namespace Tuan
{
    public partial class MyDing : System.Web.UI.Page
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

                    DataTable dtdd = comfun.GetDataTableBySQL("select distinct(d.订单编号) as ddbh,支付时间,总金额,b.openid as openid,本站价,三团价,数量,类型 from TM_订单支付表 a,TM_订单表 b,TM_订单子表 d,TM_商品表 c where b.订单编号=d.订单编号 and a.订单编号=b.订单编号 and d.商品编号=c.编号 and a.openid in  (select openid from WP_会员表 where unionid='" + unionid + "')  order by 支付时间 desc ");
                    if (dtdd.Rows.Count > 0)
                    {
                        string str = "";
                        for (int i = 0; i < dtdd.Rows.Count; i++)
                        {
                           

                            string sqllx = "select top 1* from TM_商品表 a,TM_订单表 b,TM_订单子表 c where a.编号=c.商品编号 and b.订单编号=c.订单编号 and  b.订单编号='" + dtdd.Rows[i]["ddbh"].ToString() + "'";
                            DataTable dtlx = comfun.GetDataTableBySQL(sqllx);
                            if (dtlx.Rows.Count > 0)
                            {
                                string img = "<img src=\"images/03.jpg\" />";
                                DataTable dtimg = comfun.GetDataTableBySQL("select top 1* from TM_商品图片表 where 商品编号='" + dtlx.Rows[0]["编号"].ToString() + "'");
                                if (dtimg.Rows.Count > 0)
                                {
                                    img = "<img src=" + dtimg.Rows[0]["图片路径"].ToString() + " />";
                                }
                                str += "<div class=\"order_messgae_list\"><div class=\"wrap padd_10\">";
                                str += "<div class=\"title\">订单号：" + dtdd.Rows[i]["ddbh"].ToString() + "</div>";
                                str += " <div class=\"content clear\">";
                                if (dtlx.Rows[0]["类型"].ToString().Equals("2"))
                                {
                                    str += "	<div class=\"fl pic\"><a href='DingInfo.aspx?attach=" + dtdd.Rows[i]["openid"] + ":" + dtdd.Rows[i]["ddbh"] + ":" + dtlx.Rows[0]["编号"] + "'>" + img + "</a></div>";
                                    str += "   <div class=\"txt fl\"><a href='DingInfo.aspx?attach=" + dtdd.Rows[i]["openid"] + ":" + dtdd.Rows[i]["ddbh"] + ":" + dtlx.Rows[0]["编号"] + "'>" + (dtlx.Rows[0]["品名"].ToString().Length > 20 ? dtlx.Rows[0]["品名"].ToString().Substring(0, 19) + "......" : dtlx.Rows[0]["品名"].ToString()) + "</a></div>";
                                    str += "   <div class=\"old_pic fr\">¥ " + dtlx.Rows[0]["三团价"].ToString() + "<em>×</em>" + dtdd.Rows[i]["数量"].ToString() + "</p></div></div>";
                               //     str += " <div class=\"more_thing\"><a href=\"#\">查看全部2件商品</a></div>";
                                    str += "	<div class=\"price clear\"><div class=\"fl\"><span>实付：</span><strong>¥ " + dtdd.Rows[i]["三团价"].ToString() + "</strong></div>";
                                    str += "   <div class=\"fr clear\"><a href='DingInfo.aspx?attach=" + dtdd.Rows[i]["openid"] + ":" + dtdd.Rows[i]["ddbh"] + ":" + dtlx.Rows[0]["编号"] + "'>详情</a></div>";//<a href="#">物流</a>
                                    str += "  </div></div></div><div class=\"hei_15\"></div>";
                                }
                                else
                                {
                                    string sqlgetcount = "select * from TM_订单表 a,TM_订单子表 b where a.订单编号=b.订单编号 and a.订单编号='" + dtdd.Rows[i]["ddbh"].ToString() + "'";
                                    DataTable dtgetcount = comfun.GetDataTableBySQL(sqlgetcount);
                                    int ct = 0;
                                    if (dtgetcount.Rows.Count > 0)
                                    {
                                        ct = dtgetcount.Rows.Count;
                                    }
                                    str += "	<div class=\"fl pic\"><a href='MyDingInfo.aspx?ddbh="+dtdd.Rows[i]["ddbh"] + "'>" + img + "</a></div>";
                                    str += "   <div class=\"txt fl\"><a href='MyDingInfo.aspx?ddbh=" + dtdd.Rows[i]["ddbh"] + "'>" + (dtlx.Rows[0]["品名"].ToString().Length > 20 ? dtlx.Rows[0]["品名"].ToString().Substring(0, 19) + "......" : dtlx.Rows[0]["品名"].ToString()) + "</a></div>";
                                    str += "   <div class=\"old_pic fr\">¥ " + dtdd.Rows[i]["三团价"].ToString() + "<em>×</em>" + dtdd.Rows[i]["数量"].ToString() + "</p></div></div>";
                                    if (ct>1)
                                    {
                                        str += " <div class=\"more_thing\"><a href='MyDingInfo.aspx?ddbh=" + dtdd.Rows[i]["ddbh"] + "'>查看全部" + ct + "件商品</a></div>";
                                    }

                                    str += "	<div class=\"price clear\"><div class=\"fl\"><span>实付：</span><strong>¥ " + dtdd.Rows[i]["总金额"].ToString() + "</strong></div>";
                                    str += "   <div class=\"fr clear\"><a href='MyDingInfo.aspx?ddbh=" + dtdd.Rows[i]["ddbh"] + "'>详情</a></div>";//<a href="#">物流</a>
                                    str += "  </div></div></div><div class=\"hei_15\"></div>";
                                } 
                            
                            } 

                        }

                        Literal1.Text = str;
                    }

                    else
                    {
                        Response.Redirect("emptymyding.aspx");
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
                // Response.Write("<script>alert('')</script>")
                // chat.GetCode(Request.Url.AbsoluteUri);
            }

        }
    }
}