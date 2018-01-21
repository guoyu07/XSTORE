using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DTcms.DBUtility;

namespace Tuan
{
    /// <summary>
    /// RefreshDizhi 的摘要说明
    /// </summary>
    public class RefreshDizhi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string unionid = context.Request["unionid"].ToString();

            string sql = "select * from dbo.WP_订单地址表 where 订单编号 in(";
            sql += "select openid from WP_会员表 where unionid='" + unionid + "') order by 是否为默认地址 desc ";
            string s = String.Empty;

            string ss = String.Empty;

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                ss = "<li class=\"clear\"><div id=sp" + dt.Rows[0]["id"] + "><div class=\"address_list2\"><div class=\"padd_10 clear\"><a class=\"tc fl\" href='javascript:;' onclick=\"qiehuandizhi(" + dt.Rows[0]["id"] + ")\"><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[0]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[0]["手机号"].ToString() + "</span></div><div class=\"bot_a\"><span>[默认]</span>收货地址：" + dt.Rows[0]["省"].ToString() + dt.Rows[0]["市"].ToString() + dt.Rows[0]["区"].ToString() + dt.Rows[0]["详细地址"].ToString() + "</div></a><a class=\"fr mody\" href=\"javascript:;\" onclick=\"edit(" + dt.Rows[0]["id"].ToString() + ")\"><img src=\"images/edit01.png\"/></a></div></div></div></li>";
              if(dt.Rows.Count>1)
              { 
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                  //  s = "<div class=\"shr clear tc\"><span class=\"fl\">收货人：" + dt.Rows[0]["收货人"].ToString() + "</span><span class=\"fr\">" + dt.Rows[0]["手机号"].ToString() + "</span></div><div class=\"shaddress\">收货地址：" + dt.Rows[0]["省"].ToString() + dt.Rows[0]["市"].ToString() + dt.Rows[0]["区"].ToString() + dt.Rows[0]["详细地址"].ToString() + "</div>";
                  //  ss += "<li class=\"clear\"><a class=\"tc\" href='javascript:;' onclick=\"qiehuandizhi(" + dt.Rows[i]["id"] + ")\"><div id=sp" + dt.Rows[i]["id"] + "><div class=\"shr clear tc\"><span class=\"fl\">收货人：" + dt.Rows[i]["收货人"].ToString() + "</span><span class=\"fr\">" + dt.Rows[i]["手机号"].ToString() + "</span></div><div class=\"shaddress\">收货地址：" + dt.Rows[i]["省"].ToString() + dt.Rows[i]["市"].ToString() + dt.Rows[i]["区"].ToString() + dt.Rows[i]["详细地址"].ToString() + "</div></div></a><a href=\"javascript:;\" onclick=\"edit(" + dt.Rows[i]["id"].ToString() + ")\">修改</a></li>";
               //     ss += "<li class=\"clear\"><a class=\"tc\" href='javascript:;' onclick=\"qiehuandizhi(" + dt.Rows[i]["id"] + ")\"><div id=sp" + dt.Rows[i]["id"] + "><div class=\"address_list\"><div class=\"wrap padd_10\"><div class=\"yuana\" ><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[i]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[i]["手机号"].ToString() + "</span></div><div class=\"bot_a\">收货地址：" + dt.Rows[i]["省"].ToString() + dt.Rows[i]["市"].ToString() + dt.Rows[i]["区"].ToString() + dt.Rows[i]["详细地址"].ToString() + "</div></div></div></div></div></a><a href=\"javascript:;\" onclick=\"edit(" + dt.Rows[i]["id"].ToString() + ")\">修改</a></li>";
                    ss += "<li class=\"clear\"><div id=sp" + dt.Rows[i]["id"] + "><div class=\"address_list2\"><div class=\"padd_10 clear\"><a class=\"tc fl\" href='javascript:;' onclick=\"qiehuandizhi(" + dt.Rows[i]["id"] + ")\"><div class=\"top_a clear\"><span class=\"name\">收货人：" + dt.Rows[i]["收货人"].ToString() + "</span><span class=\"tel\">" + dt.Rows[i]["手机号"].ToString() + "</span></div><div class=\"bot_a\">收货地址：" + dt.Rows[i]["省"].ToString() + dt.Rows[i]["市"].ToString() + dt.Rows[i]["区"].ToString() + dt.Rows[i]["详细地址"].ToString() + "</div></a><a class=\"fr mody\" href=\"javascript:;\" onclick=\"edit(" + dt.Rows[i]["id"].ToString() + ")\"><img src=\"images/edit01.png\"/></a></div></div></div></li>";
                }
              }
            }
            else
            {
         
                ss = "";
            }
            context.Response.Write(ss);
             
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