using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using System.Web.UI.HtmlControls;
using Creatrue.Common.Msgbox;
using DTcms.DBUtility;
using tdx.database.Common_Pay.WeiXinPay;

namespace Wx_NewWeb.Shop.Buyer
{
    public partial class cart : BasePage
    {

        private decimal _totalprice;

        public decimal TotalPrice
        {
            get {
                if (_totalprice == new decimal())
                {
                     string sql_price = "select isnull(sum( 单价),0) as 单价  from WP_购物车 where openid='" + OpenId + "' and 是否结算=0";
                    DataTable dt_price = comfun.GetDataTableBySQL(sql_price);

                    _totalprice = dt_price.Rows[0]["单价"].ObjToDecimal(0);
                }
                return _totalprice;
            
            }
        
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cart_list();
            }
      
        }

        protected void cart_list()
        {
            try
            {
                //Log.WriteLog("页面：cart", "方法：cart_list", "进入");
                string sql_cart_list = @"select WP_购物车.id,商品id,品名,单价,数量,isnull(图片路径,'') as 图片路径
from WP_购物车 
join WP_商品表 on WP_商品表.id=WP_购物车.商品id
left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号
where openid='" + OpenId + "' and 是否结算=0";
                //Log.WriteLog("页面：cart", "方法：cart_list", "sql_cart_list:" + sql_cart_list);
                DataTable dt_sql_cart_list = comfun.GetDataTableBySQL(sql_cart_list);

                if (dt_sql_cart_list.Rows.Count > 0)  //如果购物车有内容，显示正常的购物车列表
                {
                    has.Style["display"] = "block";
                    emp.Style["display"] = "none";
                }
                else//否则显示空
                {
                    has.Style["display"] = "none";
                    emp.Style["display"] = "block";
                }

                cart_rp.DataSource = dt_sql_cart_list;
                cart_rp.DataBind();
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：cart", "方法：cart_list", "异常信息：" + ex.Message);
                throw;
            }
            
        
        }
        #region  订单提交
        protected void submit_order_Click(object sender, EventArgs e)
        {
            try
            {
                string order_no = GetOrderNo();
                //Log.WriteLog("页面：cart", "方法：submit_order_Click", "订单编号：" + order_no);
                string sql_good = @"select WP_购物车.id,库位id,仓库id,位置,商品id,品名,单价,数量 
from WP_购物车 
left join WP_商品表 on WP_商品表.id=WP_购物车.商品id
where openid='" + OpenId + "' and 是否结算=0";
                var begin_exsql = " Begin Tran ";
                var exsql = string.Empty;
                var end_sql = @" If @@ERROR>0
                                Rollback Tran  
                            Else
                                Commit Tran
                            Go";
                //Log.WriteLog("页面：cart", "方法：submit_order_Click", "Sql：" + sql_good);
                DataTable dt_good = comfun.GetDataTableBySQL(sql_good);
                decimal total_price = 0;
               
                //查询购物车中商品
                for (int i = 0; i < dt_good.Rows.Count; i++)
                {
                    //Log.WriteLog("页面：cart", "方法：submit_order_Click", "进入for循环");
                    //  插入订单子表
                    var price = dt_good.Rows[i]["单价"].ObjToDecimal(0);
                    exsql += string.Format(@"
 INSERT INTO [WP_订单子表]
           ([商品id]
           ,[订单编号]
           ,[价格]
           ,[数量]
           ,[下单时间]
           ,[库位id]
           ,[仓库id]
           ,[位置]
           ,[结算状态])
VALUES
           ({0}
           ,'{1}'
           ,'{2}'
           ,'{3}'
           ,'{4}'
           ,'{5}'
           ,'{6}'
           ,'{7}'
           ,'{8}')", dt_good.Rows[i]["商品id"].ObjToStr(), order_no, price, 1, DateTime.Now, dt_good.Rows[i]["库位id"].ObjToStr(), dt_good.Rows[i]["仓库id"].ObjToStr(), dt_good.Rows[i]["位置"].ObjToStr(), 0);
                    //                comfun.InsertBySQL(@"insert into wp_订单子表 (商品id,订单编号,价格,数量,下单时间,库位id,仓库id,位置,结算状态) 
                    //                values ('" + dt_good.Rows[i]["商品id"].ObjToStr() + "','" + order_no + "','" + price + "',1,getdate(),'" + dt_good.Rows[i]["库位id"].ObjToStr() + "','" + dt_good.Rows[i]["仓库id"].ObjToStr() + "','" + dt_good.Rows[i]["位置"].ObjToStr() + "',0)");
                    total_price += price;
                    //Log.WriteLog("页面：cart", "方法：submit_order_Click", "exsql：" + exsql);
                }
                //Log.WriteLog("页面：cart", "方法：submit_order_Click", "出循环：");
                exsql += string.Format(@"
 INSERT INTO  [WP_订单表] ([订单编号]
           ,[总金额]
           ,[应付款]
           ,[下单时间]
           ,[openid]
           ,[state]
           ,[is_offline])
VALUES
           ('{0}'
           ,'{1}'
           ,'{2}'
           ,'{3}'
           ,'{4}'
           ,'{5}'
           ,'{6}')", order_no, total_price, total_price, DateTime.Now, OpenId, 0,IsOffline);

                var b = comfun.UpdateBySQL(begin_exsql + exsql + end_sql);
                if (b > 0 )
                {
                    //Log.WriteLog("页面：cart", "方法：submit_order_Click", "更新成功" );
                    var redirect_url = "../pages/payCenter.aspx?order=" + order_no;
                    Response.Redirect(redirect_url,false);
                    return;
                }
                else
                {
                    //Log.WriteLog("页面：cart", "方法：submit_order_Click", "更新失败");
                    RedirectError("保存失败");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：cart", "方法：submit_order_Click", "异常信息：" + ex.Message);
                RedirectError(ex.Message);
            }
        }
        #endregion
    }
}