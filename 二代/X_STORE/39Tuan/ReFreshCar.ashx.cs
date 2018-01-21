using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Creatrue.kernel;

namespace Tuan
{
    /// <summary>
    /// ReFreshCar 的摘要说明
    /// </summary>
    public class ReFreshCar : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string openid = context.Request["openid"].ToString();
           
           
                string str = "";
                string sqlcar = "select * from TM_购物车 where openid='" + openid + "' and 是否结算=0";
                DataTable dtcar = comfun.GetDataTableBySQL(sqlcar);
                if (dtcar.Rows.Count > 0)
                {

                    for (int i = 0; i < dtcar.Rows.Count; i++)
                    {

                        string spxq = "select * from TM_商品表 a ,dt_manager b ,wx_mp c where a.用户ID=b.id and b.wxid=c.id and a.编号='" + dtcar.Rows[i]["商品编号"].ToString() + "'";
                        DataTable dtspxq = comfun.GetDataTableBySQL(spxq);
                        if (dtspxq.Rows.Count > 0)
                        {
                            string img = "";
                            string sqlimg = "select * from TM_商品图片表 where 商品编号='" + dtspxq.Rows[0]["编号"].ToString() + "'";
                            DataTable dtimg = comfun.GetDataTableBySQL(sqlimg);
                            if (dtimg.Rows.Count > 0)
                            {
                                img = dtimg.Rows[0]["图片路径"].ToString();
                            }

                            str += "<div class=\"hei_15\"></div><div class=\"cart_list\"><div class=\"wrap padd_10\">";
                            str += "<div class=\"content clear\"><div class=\"fl check\">";
                            str += "<input class=\"check\" name=\"che\" id=" + dtcar.Rows[i]["id"].ToString() + " onclick=\"leijia(" + dtcar.Rows[i]["id"].ToString() + ")\"  type=\"checkbox\"/></div>";
                            str += "<div class=\"fl pic\"><a href=\"index.aspx?attach=::" + dtspxq.Rows[0]["编号"].ToString() + ":" + dtspxq.Rows[0]["wxid"].ToString() + "\"><img src=" + img + " /></a></div>";
                            str += "<div class=\"fl txt\"><a href=\"index.aspx?attach=::" + dtspxq.Rows[0]["编号"].ToString() + ":" + dtspxq.Rows[0]["wxid"].ToString() + "\">" + (dtspxq.Rows[0]["品名"].ToString().Length > 20 ? dtspxq.Rows[0]["品名"].ToString().Substring(0, 20) + "..." : dtspxq.Rows[0]["品名"].ToString()) + "</a>";
                            str += "</div>"; //<div class=\"specification\"><span>浅麻灰</span><span>90</span></div>
                            str += "<div class=\"fr old_pic\"><p>¥" + dtcar.Rows[i]["单价"].ToString() + "</p><p id=\"pcount\" class=\"num pcount\"><em>×</em>" + dtcar.Rows[i]["数量"].ToString() + "</p>";
                            str += "<div id=\"dcount\" runat=\"server\" style=\"display:none\" class=\"add_del clear dcount\">";
                            str += "<a id=\"jian" + i + "\" onclick=\"count('jian', buy_num" + dtcar.Rows[i]["id"].ToString() + ")\" class=\"but_reduce\">-</a><input name=\"buycount\" type=\"text\" id=\"buy_num" + dtcar.Rows[i]["id"].ToString() + "\" value=" + dtcar.Rows[i]["数量"].ToString() + " /><a onclick=\"count('jia', buy_num" + dtcar.Rows[i]["id"].ToString() + ")\" id=\"jia" + i + "\" class=\"but_add\">+</a>";
                            str += "</div></div></div></div></div>";
                        }

                    }
                }
                context.Response.Write(str);
            
          
          
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