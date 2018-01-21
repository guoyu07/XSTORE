using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.database;
using DTcms.Model;


namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class MoneyReport : System.Web.UI.Page
    {
        public string str = String.Empty;
        public string strs = String.Empty;
        public string sj1 = String.Empty;
        public string sj2 = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string mon = "";

                if (int.Parse(DateTime.Now.Month.ToString()) > 10)
                {
                    mon = "/" + DateTime.Now.Month.ToString();
                }
                else
                {
                    mon = "/0" + DateTime.Now.Month.ToString();
                }

                string day = "";
                if (int.Parse(DateTime.Now.Day.ToString()) > 10)
                {
                    day = "/" + DateTime.Now.Day.ToString();
                }
                else
                {
                    day = "/0" + DateTime.Now.Day.ToString();
                }



                Jxl.Value = DateTime.Now.Year.ToString() + mon + "/01";
                Jx2.Value = DateTime.Now.Year.ToString() + mon + day;
                OrdersShow();
            }

        }

        public void OrdersShow()
        {


            string strsql = "select  CONVERT(varchar(10) , 下单时间, 111 ) as 下单时间 from wp_订单表 where 订单编号 in (select 订单编号 from wp_订单支付表)   group by CONVERT(varchar(10) , 下单时间, 111 )";

            DataTable dt = DbHelperSQL.Query(strsql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strs += "'" + dt.Rows[i]["下单时间"] + "',";
                    string sql = "select SUM(总金额) as count from wp_订单表 where 订单编号 in (select 订单编号 from wp_订单支付表) and CONVERT(varchar(10) , 下单时间, 111 )='" + dt.Rows[i]["下单时间"] + "'";
                    DataTable dts = DbHelperSQL.Query(sql).Tables[0];
                    if (dts.Rows.Count > 0)
                    {
                        str += dts.Rows[0]["count"] + ",";
                    }
                }

                str = str.Substring(0, int.Parse(str.Length.ToString()) - 1);
                strs = strs.Substring(0, int.Parse(strs.Length.ToString()) - 1);
            }
            else
            {
                str = "0";
                strs = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        protected void sousuo_Click(object sender, EventArgs e)
        {
            ///添加  商家姓名搜索  2015.7.12
            if (txt_name.Value.Trim() != "")
            {
                string sqlname = "select  CONVERT(varchar(10) , 下单时间, 111 ) as 下单时间  from wp_订单表 where 订单编号 in (select 订单编号 from wp_订单支付表) and  商品编号 in(";
              
                sqlname += "select 编号 from dbo.WP_商品表 where  用户ID in (";
                sqlname += "select id  from  dt_manager where user_name='"+txt_name.Value.Trim()+"')) group by CONVERT(varchar(10) , 下单时间, 111 )";

                DataTable dt = DbHelperSQL.Query(sqlname).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strs += "'" + dt.Rows[i]["下单时间"] + "',";
                        string sql = "select count(*) as count from dbo.WP_订单表 where CONVERT(varchar(10) , 下单时间, 111 )='" + dt.Rows[i]["下单时间"] + "'";
                        DataTable dts = DbHelperSQL.Query(sql).Tables[0];
                        if (dts.Rows.Count > 0)
                        {
                            str += dts.Rows[0]["count"] + ",";
                        }
                    }
                    str = str.Substring(0, int.Parse(str.Length.ToString()) - 1);
                    strs = strs.Substring(0, int.Parse(strs.Length.ToString()) - 1);
                }
                else
                {
                    str = "0";
                    strs = DateTime.Now.ToString("yyyy/MM/dd");
                }

            }
            else
            {

                string strsql = "select  CONVERT(varchar(10) , 下单时间, 111 ) as 下单时间  from wp_订单表 where 订单编号 in (select 订单编号 from wp_订单支付表) and CONVERT(varchar(10) , 下单时间, 111 ) between '" + Jxl.Value.ToString().Replace("-", "/") + "' and '" + Jx2.Value.ToString().Replace("-", "/") + "'  group by CONVERT(varchar(10) , 下单时间, 111 )";

                DataTable dt = DbHelperSQL.Query(strsql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strs += "'" + dt.Rows[i]["下单时间"] + "',";
                        string sql = "select SUM(总金额) as count from wp_订单表 where 订单编号 in (select 订单编号 from wp_订单支付表)  and CONVERT(varchar(10) , 下单时间, 111 )='" + dt.Rows[i]["下单时间"] + "'";
                        DataTable dts = DbHelperSQL.Query(sql).Tables[0];
                        if (dts.Rows.Count > 0)
                        {
                            str += dts.Rows[0]["count"] + ",";
                        }
                    }

                    str = str.Substring(0, int.Parse(str.Length.ToString()) - 1);
                    strs = strs.Substring(0, int.Parse(strs.Length.ToString()) - 1);
                }
                else
                {
                    str = "0";
                    strs = DateTime.Now.ToString("yyyy/MM/dd");
                }
            }
        }
    }
}