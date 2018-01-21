using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DTcms.DBUtility;

namespace wpmemb.man.Shop.GoodsManage
{
    /// <summary>
    /// IsShow 的摘要说明
    /// </summary>
    public class IsShow : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(string.IsNullOrEmpty(context.Request["id"]) ? "-1" : context.Request["id"]);
            if (id > 0)
            {
                context.Response.Write(IsShows(id));
            }

        }

        public int IsShows(int id)
        {

            string strsql = "select * from dbo.WP_商品表  where id=" + id;
           
            DataTable dt = DbHelperSQL.Query(strsql).Tables[0];

            int ii=0;

            if (dt.Rows.Count > 0)
            {
                

                if (dt.Rows[0]["IsShow"].ToString() == "0")
                {
                    string sql = "update dbo.WP_商品表 set IsShow='1' where id=" + id;

                    int i = DbHelperSQL.ExecuteSql(sql);

                    if (i > 0)
                    {
                        ii = i;
                    }
                    else
                    {
                        ii = 0;
                    }
                }
                else 
                {
                    string sql = "update dbo.WP_商品表 set IsShow='0' where id=" + id;

                    int i = DbHelperSQL.ExecuteSql(sql);

                    if (i > 0)
                    {
                        ii = i;
                    }
                    else
                    {
                        ii = 0;
                    }
                }
            }
            return ii;

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