using Creatrue.kernel;
using DTcms.Common;
using DTcms.DBUtility;
using System;
using System.Data;
using System.Web;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// buynow 的摘要说明
    /// </summary>
    public class buynow : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //Log.WriteLog("接口：buynow","方法：processrequest","进入了接口");
                context.Response.ContentType = "text/plain";
                //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("buynow", "buynow", "buynow");
                errReg er = new errReg();
                string goods_id = context.Request["addgoodsid"].ObjToStr();
                string weizhi = context.Request["addgoodsweizhi"].ObjToStr();
                string kwid = context.Request["addgoodskwid"].ObjToStr();
                string openid = context.Request["openid"].ObjToStr();
                bool is_offline = string.IsNullOrEmpty(context.Session["is_offline"].ObjToStr()) ? false:true; 
                //bool is_offline = false; 
                string sql_ck = "select id as 库位id,仓库id from WP_库位表 where id='" + kwid + "'";
                Log.WriteLog("接口：buynow", "方法：ProcessRequest", "sql_ck：" + sql_ck);
                DataTable dt_ck_sql = comfun.GetDataTableBySQL(sql_ck);
                if (dt_ck_sql.Rows.Count == 0)
                {
                     context.Response.Write(new { state = 0, info = "酒店不存在" });
                    return;
                }
                string ck_id = dt_ck_sql.Rows[0]["仓库id"].ObjToStr();
                string order_no = BasePage.GetOrderNo();
                string sql = @"select A.id,A.品名,A.规格,A.单位,A.重量,A.市场价,A.本站价,A.库存数量,A.限购数量,A.是否单样,B.描述,C.图片路径 from WP_商品表  A
left join WP_商品详情表 B on A.编号=B.商品编号
left join WP_商品图片表 C on A.编号=C.商品编号
where A.id='" + goods_id + "'";

                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt.Rows.Count == 0)
                {
                    context.Response.Write(new { state = 0, info = "商品不存在" });
                    return;
                }
                string goods_name = dt.Rows[0]["品名"].ObjToStr();
                string goods_miaoshu = dt.Rows[0]["描述"].ObjToStr();
                string goods_guige = dt.Rows[0]["规格"].ObjToStr();
                decimal goods_benzhanjia = dt.Rows[0]["本站价"].ObjToDecimal(0);
                //查询购物车中商品
                //插入订单子表
                var begin_exsql = " Begin Tran ";
                var exsql = string.Empty;
                var end_sql = @" If @@ERROR>0
                                Rollback Tran  
                            Else
                                Commit Tran
                            Go";
                exsql += @" INSERT INTO WP_订单表 ([订单编号],[总金额],[应付款],[下单时间],[openid],[state],[is_offline]) VALUES('" + order_no + "','" + goods_benzhanjia + "','" + goods_benzhanjia + "',getdate(),'" + openid + "',0,'" + is_offline + "')";
                exsql += " insert into wp_订单子表 (商品id,订单编号,价格,数量,库位id,仓库id,位置,下单时间,结算状态) values ('" + goods_id + "','" + order_no + "','" + goods_benzhanjia + "',1,'" + kwid + "','" + ck_id + "','" + weizhi + "',getdate(),0)";
                comfun.InsertBySQL(begin_exsql + exsql + end_sql);
                er.state = 1;
                er.info = "添加成功";
                er.guid = "payCenter.aspx?goods_id=" + goods_id + "&order=" + order_no;
                context.Response.Write(Utils.JsonSerialize(er));
            }
            catch(Exception ex)
            {
                Log.WriteLog("接口：buynow", "方法：processrequest", "异常信息：" + ex.Message);
                errReg er = new errReg();
                er.state = 0;
                er.info = "未知错误";
                er.guid = Guid.NewGuid().ObjToStr();
                context.Response.Write(Utils.JsonSerialize(er));
            }

        }
        struct errReg
        {
            public int state;
            public string info;
            public string guid;
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