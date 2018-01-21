using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DTcms.DBUtility;

namespace wpmemb.man.Shop.GoodsManage
{
    /// <summary>
    /// YesOrNo 的摘要说明
    /// </summary>
    public class YesOrNo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(string.IsNullOrEmpty(context.Request["id"]) ? "-1" : context.Request["id"]);
            if (id > 0)
            {
                context.Response.Write(YesNO(id));
            }

        }

        public int YesNO(int id)
        {

            string strsql = "select * from dbo.WP_商品表  where id=" + id;

            DataTable dt = DbHelperSQL.Query(strsql).Tables[0];

            int ii = 0;

            if (dt.Rows.Count > 0)
            {


                if (dt.Rows[0]["是否上架"].ToString() == "0")
                {
                    //string sql = "update dbo.WP_商品表 set 是否上架='1' where id=" + id;
                    string sql = "update dbo.WP_商品表 set 是否上架='1' where 编号 in (select 编号 from WP_商品表 where id=" + id+")" ;

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
                    //string sql = "update dbo.WP_商品表 set 是否上架='0' where id=" + id;
                    string sql = "update dbo.WP_商品表 set 是否上架='0' where 编号 in (select 编号 from WP_商品表 where id=" + id + ")";

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