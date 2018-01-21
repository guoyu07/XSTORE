using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTcms.DBUtility;
using System.Data;

namespace tdx.memb.tools
{
    /// <summary>
    /// myopera 的摘要说明
    /// </summary>
    public class myopera : IHttpHandler
    {
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.Params["type"];

            switch (type)
            { 
                case "getcount":
                    GetCount();
                    break;
            }
        }


        #region 1.0 获取网站统计信息 void GetCount()
        /// <summary>
        /// 获取网站统计信息
        /// </summary>
        void GetCount()
        {
            DataSet goods = DbHelperSQL.Query("select count(id) from B2C_Goods");//产品
            DataSet pages = DbHelperSQL.Query("select count(id) from B2C_tpage");//页面
            DataSet news = DbHelperSQL.Query("select count(id) from B2C_tmsg");//新闻
            DataSet pics = DbHelperSQL.Query("select count(id) from B2C_Honor");//图片
            DataSet wechat = DbHelperSQL.Query("select count(id) from wx_mp");//微信
            DataSet orders = DbHelperSQL.Query("select count(id) from B2C_orders");//订单

            string json = "{\"goods\":\"" + goods.Tables[0].Rows[0][0] + "\",\"pages\":\"" + pages.Tables[0].Rows[0][0]
                + "\",\"news\":\"" + news.Tables[0].Rows[0][0] + "\",\"pics\":\"" + pics.Tables[0].Rows[0][0] +
                "\",\"wechat\":\"" + wechat.Tables[0].Rows[0][0] + "\",\"orders\":\"" + orders.Tables[0].Rows[0][0] + "\"}";
            context.Response.Write(json);
        } 
        #endregion




        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}