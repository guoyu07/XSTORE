using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Data;
using System.Web;
namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// addcart 的摘要说明
    /// </summary>
    public class addcart : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {

                errReg er = new errReg();
                context.Response.ContentType = "text/plain";
                string goods_id = context.Request["addgoodsid"].ToString();
                string weizhi = context.Request["addgoodsweizhi"].ToString();
                string kwid = context.Request["addgoodskwid"].ToString();
                string openid = HttpContext.Current.Session["OpenId"].ObjToStr();
                Log.WriteLog("接口：addcart", "方法：ProcessRequest", "openid：" + openid);
                string boxmac = HttpContext.Current.Session["boxmac"].ObjToStr();
                Log.WriteLog("接口：addcart", "方法：ProcessRequest", "boxmac：" + boxmac);
                string sql_ck = "select id as 库位id,仓库id from WP_库位表 where id='" + kwid + "'";
                DataTable dt_ck_sql = comfun.GetDataTableBySQL(sql_ck);
                string ck_id = dt_ck_sql.Rows[0]["仓库id"].ObjToStr();
                //查询购物车是否已存在
                string sql_search = "select * from wp_购物车 where 是否结算=0 and 仓库id='" + ck_id + "' and 库位id='" + kwid + "' and 位置='" + weizhi + "' and 箱子MAC='" + boxmac + "' and openid='" + openid + "'";
                DataTable dt_search = comfun.GetDataTableBySQL(sql_search);
                Log.WriteLog("接口：addcart", "方法：添加购物车的接口", "sql_search：" + sql_search);
                string sql_goods_about = "select 本站价 from wp_商品表 where id='" + goods_id + "'";
                DataTable dt_goods_about = comfun.GetDataTableBySQL(sql_goods_about);
                if (dt_search.Rows.Count > 0)//购物车已存在
                {
                    er.state = 0;
                    er.info = "请勿重复添加";
                    er.guid = Guid.NewGuid().ToString();
                }
                else
                {
                    comfun.InsertBySQL("insert into wp_购物车 (openid,商品id,单价,数量,是否结算,库位id,仓库id,箱子MAC,位置)values('" + openid + "','" + goods_id + "','" + dt_goods_about.Rows[0]["本站价"].ObjToDecimal(0) + "','1','0','" + kwid + "','" + ck_id + "','" + boxmac + "','" + weizhi + "')");
                    er.state = 1;
                    er.info = "添加成功";
                    er.guid = Guid.NewGuid().ToString();

                }
                
                //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("插入购物车数据", "", "insert into wp_购物车 (openid,商品id,单价,数量,是否结算,库位id,仓库id,箱子MAC,位置)values('" + openid + "','" + goods_id + "','" + dt_goods_about.Rows[0]["本站价"].ObjToDecimal(0) + "','1','0','" + kwid + "','" + ck_id + "','" + boxmac + "','" + weizhi + "')");
                string sql_cart = "select * from wp_购物车 where 是否结算=0 and 库位id = " + kwid + " and openid='" + openid + "'";
                Log.WriteLog("接口：addcart", "方法：ProcessRequest", "sql_cart：" + sql_cart);
                DataTable dt_cart = comfun.GetDataTableBySQL(sql_cart);
                int cart_nums = dt_cart.Rows.Count;
                er.count = cart_nums;
                context.Response.Write(Utils.JsonSerialize(er));

            }
            catch
            {
                errReg er = new errReg();
                er.state = 0;
                er.info = "未知错误";
                er.guid = Guid.NewGuid().ToString();
                context.Response.Write(Utils.JsonSerialize(er));
            }

        }
        struct errReg
        {
            public int state;
            public string info;
            public string guid;
            public int count;
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