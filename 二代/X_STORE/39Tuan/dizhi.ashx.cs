using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DTcms.DBUtility;
using Creatrue.kernel;

namespace Tuan
{
    /// <summary>
    /// dizhi 的摘要说明
    /// </summary>
    public class dizhi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
               
                string type = context.Request["type"].ToString();
                if(type.Equals("add"))
                {
                    string openid = context.Request["openid"].ToString();
                    string ddbh = context.Request["ddbh"].ToString();
                    string name = context.Request["name"].ToString();
                    string tel = context.Request["tel"].ToString();
                    string address = context.Request["address"].ToString();
                    string sheng = context.Request["sheng"].ToString();
                    string shi = context.Request["shi"].ToString();
                    string qu = context.Request["qu"].ToString();
                    string moren = context.Request["moren"].ToString();
                    if (moren.Equals("1"))
                    {
                        comfun.UpdateBySQL("update WP_订单地址表 set 是否为默认地址=0 where 订单编号='" + openid + "'");
                    }
                    else
                    {

                    }
                    string sql = "insert into WP_订单地址表(订单编号,省,市,区,详细地址,手机号,收货人,是否为默认地址)  values ('" + openid + "','" + sheng + "','" + shi + "','" + qu + "','" + address + "','" + tel + "','" + name + "'," + Convert.ToInt32(moren) + ")  ";

               
                int rows = DbHelperSQL.ExecuteSql(sql.ToString());
             
                if (rows>0)
                {
                    string sqlstr = "select top(1)* from WP_订单地址表 where 订单编号='" + openid + "' order by 是否为默认地址  desc ";

                    DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
                   
                    if (dt.Rows.Count>0)
                    {
                   context.Response.Write(int.Parse(dt.Rows[0]["id"].ToString()));
                    }

                }
                }
                else if (type.Equals("edit"))
                {
                    string openid = context.Request["openid"].ToString();
                    string ddbh = context.Request["ddbh"].ToString();
                    string name = context.Request["name"].ToString();
                    string tel = context.Request["tel"].ToString();
                    string address = context.Request["address"].ToString();
                    string sheng = context.Request["sheng"].ToString();
                    string shi = context.Request["shi"].ToString();
                    string qu = context.Request["qu"].ToString();
                    string moren = context.Request["moren"].ToString();

                    int  id =Convert.ToInt32(context.Request["id"].ToString());
                    if (moren.Equals("1"))
                    {
                        comfun.UpdateBySQL("update WP_订单地址表 set 是否为默认地址=0 where 订单编号='" + openid + "'");
                    }
                    else
                    { 
                    
                    }
                    comfun.UpdateBySQL("update WP_订单地址表 set 订单编号='" + openid + "',收货人='" + name + "',省='" + sheng + "',市='" + shi + "',区='" + qu + "',详细地址='" + address + "',手机号='" + tel + "',是否为默认地址='" + moren + "' where id=" + id + "");
                    context.Response.Write(id);
                }
                else if (type.Equals("del"))
                {
                    string openid = context.Request["openid"].ToString();
                    int id = Convert.ToInt32(context.Request["id"].ToString());
                    comfun.DelbySQL("delete from WP_订单地址表 where id=" + id + "");

                    string sqlstr = "select top(1)* from WP_订单地址表 where 订单编号='" + openid + "' order by 是否为默认地址  desc ";

                    DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
                    string s = "";
                    if (dt.Rows.Count > 0)
                    {
                        string name = dt.Rows[0]["收货人"].ToString();
                        string tel = dt.Rows[0]["手机号"].ToString();
                        string sheng = dt.Rows[0]["省"].ToString();
                        string shi = dt.Rows[0]["市"].ToString();
                        string qu = dt.Rows[0]["区"].ToString();
                        string address = dt.Rows[0]["详细地址"].ToString();
                        //  string s = "<div class=\"shr clear\"><span class=\"fl\">收货人：" + name + "</span><span class=\"fr\">" + tel + "</span></div><div class=\"shaddress\">收货地址：" + sheng + shi + qu + address + "</div>";
                       s = "<div class=\"address_list\"><div class=\"wrap padd_10\"><div class=\"yuana\" ><div class=\"top_a clear\"><span class=\"name\">收货人：" + name + "</span><span class=\"tel\">" + tel + "</span></div><div class=\"bot_a\">收货地址：" + sheng + shi + qu + address + "</div></div></div></div>";
                    }
                    else
                    {
                        s = "<div class=\"shr clear newadd\"><span class=\"fl\">新增收货地址信息</span></div>";
                    
                    }
                    context.Response.Write(s);
                    }
                
                
                
            }
            catch (Exception)
            {
                context.Response.Write("<script>alert('请完善收获信息！')</script>");
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