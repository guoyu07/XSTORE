using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Aop.Api.Domain;
using Creatrue.kernel;
using Jayrock.Json.Conversion.Converters;

namespace Wx_NewWeb.Shop.pages
{
    public partial class achievement : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }

        }


        public decimal Atoatal = 0;

        public decimal Btoatal = 0;
        public decimal Ctoatal = 0;
        public decimal Dtoatal = 0;
        public decimal Etoatal = 0;
        public decimal Ftotal = 0;
        public string hsale = string.Empty;
        public string daysale = string.Empty;
        public string weeksale = string.Empty;
        public string monthsale = string.Empty;
        public string yearsale = string.Empty;
        protected void PageInit()
        {
            DateTime the_Date = new DateTime(DateTime.Now.Year, 1, 1);//本年的第一天
            TimeSpan tt = the_Date.AddYears(1) - the_Date;//求出本年有几天
            var nowday = DateTime.Now.Day;
            var find_sql = string.Format("select top 1 DATEDIFF ( dd ,a.下单时间, getdate() ) as day  from  WP_订单子表 a left join WP_订单表 b on a.订单编号 = b.订单编号 where a.仓库id = {0} and b.state = 3 order by b.下单时间 ", HotelId);
            var find_dt = comfun.GetDataTableBySQL(find_sql);
            var day = 0;
            if (find_dt.Rows.Count > 0)
            {
                day = find_dt.Rows[0][0].ObjToInt(0);
            }
            if (day == 0)
            {
                day = 1;
            }
            FindState(HotelId, "CONVERT(varchar(7),下单时间,120) = CONVERT(varchar(7),dateadd(mm,-1,getdate()),120)", "32-DAY(dateadd(mm,-1,getdate())+32-DAY(dateadd(mm,-1,getdate()))) ", out hsale);
            Today.DataSource = FindDt("CONVERT(varchar(7),d.下单时间,120) = CONVERT(varchar(7),dateadd(mm,-1,getdate()),120)", HotelInfo["id"].ObjToInt(0), out Atoatal);
            Today.DataBind();
            FindState(HotelId, "CONVERT(varchar(10),下单时间,120) = CONVERT(varchar(10),dateadd(DD,-1,getdate()),120)", "1", out daysale);
            Yestoday.DataSource = FindDt("CONVERT(varchar(10),d.下单时间,120) = CONVERT(varchar(10),dateadd(DD,-1,getdate()),120)", HotelInfo["id"].ObjToInt(0), out Ftotal);
            Yestoday.DataBind();
            var weekday = day > 7 ? 7 : day;
            FindState(HotelId, "DateDiff(dd,下单时间,getDate())<=7", weekday.ObjToStr(), out weeksale);
            AWeek.DataSource = FindDt("DateDiff(dd,d.下单时间,getDate())<=7", HotelInfo["id"].ObjToInt(0), out Btoatal);
            AWeek.DataBind();
            //如果第一单到目前为止的天数大于当前的天数，则取当前天数，否则取实际的天数
            var monthday = day > nowday ? nowday : day;
            FindState(HotelId, "DateDiff(mm,下单时间,getDate())<=0", monthday.ObjToStr(), out monthsale);
            Amounth.DataSource = FindDt("DateDiff(mm,d.下单时间,getDate())<=0", HotelInfo["id"].ObjToInt(0), out Ctoatal); ;//
            Amounth.DataBind();
            //如果第一单到目前为止天数大于今年的元旦到目前的天数，那么取
            var yearday = day - (DateTime.Now - the_Date).Days > 0 ? (DateTime.Now - the_Date).Days : day;
            FindState(HotelId, "DateDiff(yy,下单时间,getDate())<=0", "(" + yearday + ")", out yearsale);
            Ayear.DataSource = FindDt("DateDiff(yy, d.下单时间, getDate()) <= 0", HotelInfo["id"].ObjToInt(0), out Dtoatal); ;
            Ayear.DataBind();
            AllGoods.DataSource = FindDt("1=1", HotelInfo["id"].ObjToInt(0), out Etoatal);
            AllGoods.DataBind();
        }


        protected DataTable FindDt(string date_where, int hotel_id, out decimal total)
        {
            total = 0;
            var sql = string.Format(@"  select id,max(品名)as 品名,max(编码) as 编码,sum(总数) as 总数,sum(总价) as 总价 from(
  select c.id,c.编码,c.品名
  ,A.数量 as 总数,(isnull(a.价格,0)*a.数量)as 总价 
  from wp_订单子表 a
left join wp_商品表 c on c.id=A.商品id
left join wp_订单表 d on a.订单编号 = d.订单编号
where a.仓库id={0}  and  d.state =3 and {1}and a.价格>1
) e group by id
order by 总数 desc", HotelInfo["id"].ObjToInt(0), date_where);
            var dt = comfun.GetDataTableBySQL(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                total += dr["总价"].ObjToDecimal(0);
            }
            return dt;
        }


    }
}