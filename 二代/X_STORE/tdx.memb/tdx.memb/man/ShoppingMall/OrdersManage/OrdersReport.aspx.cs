using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.database;

namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class OrdersReport : System.Web.UI.Page
    {
        public string str = String.Empty;
        public string strs = String.Empty;
        private string sj1 = String.Empty;
        private string sj2 = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string mon = "";
                string day = "";
                if (int.Parse(DateTime.Now.Month.ToString()) > 10)
                {
                    mon = "/" + DateTime.Now.Month.ToString();
                }
                else
                {
                    mon = "/0" + DateTime.Now.Month.ToString();
                }

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
            string strsql = "select  CONVERT(varchar(10) , 下单时间, 111 ) as 下单时间 from dbo.WP_订单表  group by CONVERT(varchar(10) , 下单时间, 111 )";

            DataTable dt = DbHelperSQL.Query(strsql).Tables[0];
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

        protected void sousuo_Click(object sender, EventArgs e)
        {  ///添加  商家姓名搜索  2015.7.12
            if (txt_name.Value.Trim() != "")
            {
                string sqlname = "select  CONVERT(varchar(10) , 下单时间, 111 ) as 下单时间 from dbo.WP_订单表 where 商品编号 in(";
                sqlname += "select 编号 from dbo.WP_商品表 where  用户ID in (select id  from  dt_manager where user_name='" + txt_name.Value.Trim() + "'))  group by CONVERT(varchar(10) , 下单时间, 111 ) ";

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
                sj1 = (Jxl.Value.ToString().Equals("") ? DateTime.Now.AddDays(1 - DateTime.Now.Day).ToShortDateString() : Jxl.Value.ToString());
                sj2 = (Jx2.Value.ToString().Equals("") ? DateTime.Now.ToShortDateString() : Jx2.Value.ToString());
                Jxl.Value = sj1.Replace("-", "/");
                Jx2.Value = sj2.Replace("-", "/");
                string strsql = "select  CONVERT(varchar(10) , 下单时间, 111 ) as 下单时间 from dbo.WP_订单表 where CONVERT(varchar(10) , 下单时间, 111 ) between '" + Jxl.Value.ToString() + "' and '" + Jx2.Value.ToString() + "'  group by CONVERT(varchar(10) , 下单时间, 111 )";

                DataTable dt = DbHelperSQL.Query(strsql).Tables[0];
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

        }
    }
}