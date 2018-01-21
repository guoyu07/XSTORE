using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DTcms.DBUtility;

namespace tdx.memb.man.Shop.OrdersManage
{
    public partial class saleChart : System.Web.UI.Page
    {
        private DataTable dt1;
        private DataTable dt2;
        protected string str = "";
        protected string strs = "";
        protected string strsm = "";
        public static DateTime starTime;
        public static DateTime endTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            endTime = DateTime.Now;
            starTime = new DateTime(endTime.Year, endTime.Month, 1);
            load(starTime, endTime);
        }

        public void load(DateTime starTime, DateTime endTime)
        {
            str = "";
            strs = "";
            strsm = "";
            dt1 = GetSaleNum(starTime, endTime);
            dt2 = GetSaleMoney(starTime, endTime);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (i == 0)
                {
                    strs += dt1.Rows[i]["日期"].ToString().Substring(dt1.Rows[i]["日期"].ToString().Length - 2, 2);
                    str += dt1.Rows[i]["订单数"].ToString();
                }
                else
                {
                    strs += "," + dt1.Rows[i]["日期"].ToString().Substring(dt1.Rows[i]["日期"].ToString().Length - 2, 2);
                    str += "," + dt1.Rows[i]["订单数"].ToString();
                }

            }

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (i == 0)
                {
                    strsm += dt2.Rows[i]["销售额"].ToString();
                }
                else
                {
                    strsm += "," + dt2.Rows[i]["销售额"].ToString();
                }
            }

            //Response.Write("<script language=javascript >function  chart1()</Script>");
        }

        public DataTable GetSaleNum(DateTime starTime, DateTime endTime)
        {
            return DbHelperSQL.Query(@"declare   @StartTime   as   datetime set   @StartTime= '" + starTime + " ' declare   @t   table(dDate   datetime)   while   @StartTime <= '" + endTime + " '  begin   insert   into   @t   select   @StartTime   set   @StartTime=Dateadd(day,1,@StartTime)  end select  CONVERT(varchar(100),a.dDate,23) as 日期,isnull(订单数,0) as 订单数 from    @t a left join (select CONVERT(varchar(100),支付时间,23) as 日期,count(订单编号) as 订单数 from WP_订单支付表  group by CONVERT(varchar(100),支付时间,23)) b on CONVERT(varchar(100),a.dDate,23)=b.日期 ").Tables[0];
        }

        public DataTable GetSaleMoney(DateTime starTime, DateTime endTime)
        {
            return DbHelperSQL.Query(@"declare   @StartTime   as   datetime  set   @StartTime= '" + starTime + "'  declare   @t   table(dDate   datetime)    while   @StartTime <= '" + endTime + " '  begin  insert   into   @t   select   @StartTime   set   @StartTime=Dateadd(day,1,@StartTime)  end  select  CONVERT(varchar(100),a.dDate,23) as 日期,isnull(销售额,0) as 销售额 from    @t a left join (select CONVERT(varchar(100),支付时间,23) as 日期,sum(支付金额) as 销售额 from WP_订单支付表  group by CONVERT(varchar(100),支付时间,23)) b on CONVERT(varchar(100),a.dDate,23)=b.日期 ").Tables[0];
        }

        private string where = " where 1=1 ";
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_start.Value) && !string.IsNullOrEmpty(txt_end.Value))
            {
                starTime = Convert.ToDateTime(txt_start.Value);
                endTime = Convert.ToDateTime(txt_end.Value);
                load(starTime, endTime);
            }

        }

        //导出订单销量
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {

            if (dt1.Rows.Count > 0)
            {
                DTcms.Common.Excel.DataTable4Excel(dt1, "订单销量");
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }

        //导出订单销售额
        protected void LBtn_Export_Click1(object sender, EventArgs e)
        {
            DataTable dt3 =
                DbHelperSQL.Query(@" declare   @StartTime   as   datetime  set   @StartTime= '" + starTime + "'  declare   @t   table(dDate   datetime)    while   @StartTime <= '" + endTime + " '  begin  insert   into   @t   select   @StartTime   set   @StartTime=Dateadd(day,1,@StartTime)  end  select  CONVERT(varchar(100),a.dDate,23) as 日期,isnull(销售额,0) as 销售额,isnull(运费,0) as 运费 from    @t a left join (select CONVERT(varchar(100),支付时间,23) as 日期,sum(支付金额) as 销售额 from WP_订单支付表  group by CONVERT(varchar(100),支付时间,23)) b on CONVERT(varchar(100),a.dDate,23)=b.日期 left join (select CONVERT(varchar(100),支付时间,23) as 日期,sum(运费) as 运费 from WP_订单支付表 x left join  WP_订单表 y on x.订单编号=y.订单编号 group by CONVERT(varchar(100),支付时间,23)) d on CONVERT(varchar(100),a.dDate,23)=d.日期 ").Tables[0];
            if (dt3.Rows.Count > 0)
            {
                DTcms.Common.Excel.DataTable4Excel(dt3, "订单销售额运费");
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }
















    }


}