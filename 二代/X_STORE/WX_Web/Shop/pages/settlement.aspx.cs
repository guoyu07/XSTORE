using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class settlement : BasePage
    {
        public string start_time = string.Empty;
        public string end_time = string.Empty;
        public int data_type = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            start_time = Request.QueryString["start_time"].ObjToStr();
            end_time = Request.QueryString["end_time"].ObjToStr();
            data_type = Request.QueryString["data_type"].ObjToInt(0);
            
            if (!IsPostBack)
            {
                PageInit();
               
                //pagesA();
                //pagesB();
                //wait();
            }
        
            //pagesA();
            //pagesB();
            //wait();
        }
       
        public decimal A_price = 0;
        public int A_sum = 0;
        public decimal B_price = 0;
        public int B_sum = 0;
        public decimal wait_price = 0;
        public int wait_sum = 0;
        protected void PageInit()
        {
            //yestlement.DataSource = FindJieSuan(2,start_time,end_time, out A_sum,out A_price);
            //yestlement.DataBind();

            notlement.DataSource = FindJieSuan( start_time, end_time, out B_sum, out B_price);
            notlement.DataBind();

            //wait_rp.DataSource = FindJieSuan(1, start_time, end_time, out wait_sum, out wait_price);
            //wait_rp.DataBind();

            data_type_input.Value = data_type.ObjToStr();
            start_date_label.InnerText = string.IsNullOrEmpty(start_time) ? "-起始时间-" : start_time;
            end_date_label.InnerText = string.IsNullOrEmpty(end_time) ? "-截止时间-" : end_time;
        }

        protected DataTable FindJieSuan( string start_time,string end_time, out int sum, out decimal price)
        {
            sum = 0;
            price = 0;
            string where_sql = " 1=1";
            if (!string.IsNullOrEmpty(start_time))
            {
                where_sql += string.Format(" and convert(nvarchar(10),a.下单时间,120) >= '{0}'", start_time);
            }
            if (!string.IsNullOrEmpty(end_time))
	        {
                where_sql += string.Format(" and convert(nvarchar(10),a.下单时间,120) <= '{0}'", end_time);
	        }
            var sql = string.Format(@"  select id,max(品名)as 品名,max(编码) as 编码,sum(总数) as 总数,sum(总价) as 总价 from(
  select c.id,c.编码,c.品名
  ,A.数量 as 总数,(isnull(a.价格,0)*a.数量)as 总价 
  from wp_订单子表 a
left join wp_商品表 c on c.id=A.商品id
left join wp_订单表 d on a.订单编号 = d.订单编号
where a.仓库id={0}  and  d.state in(2,3,5) and {1} and a.价格>1
) e group by id
order by 总数 desc", HotelInfo["id"].ObjToInt(0), where_sql);
            var dt = comfun.GetDataTableBySQL(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                sum += dr["总数"].ObjToInt(0);
                price += dr["总价"].ObjToDecimal(0);
            }
            return dt;

        }

    }
}