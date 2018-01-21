using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Text;
using System.Data;
using System.Linq;
using Creatrue.kernel;

namespace tdx.memb.man.PrintSheet
{
    public partial class PrintOrder : DevExpress.XtraReports.UI.XtraReport
    {
        string ordernum;
        string ordertype;
        public PrintOrder(string _ordernum,string _ordertype)
        {
            InitializeComponent();
            ordernum = _ordernum;
            ordertype = _ordertype;
            LoadInfo();
        }


        private void LoadInfo()
        {
            StringBuilder sbhtml = new StringBuilder();
            if (ordertype.Equals("TM"))
            {
                sbhtml.Append("\r\n    select *,总金额+运费-总支付金额 as 优惠金额 from (   ");
                sbhtml.Append("\r\n       select ROW_NUMBER() over (order by a.商品id asc ) as 序号,b.编号new,b.品名 as 商品名称 ");
                sbhtml.Append("\r\n    ,b.规格,a.数量,a.订单编号,b.本站价 as 单价,(select 运费 from [dbo].[TM_订单表] where [TM_订单表].订单编号=a.订单编号) as 运费,(select 总金额 from [dbo].[TM_订单表] where [TM_订单表].订单编号=a.订单编号) as 总金额    ");
                sbhtml.Append("\r\n     ,isnull((select 应付款 from [dbo].[TM_订单表] where [TM_订单表].订单编号=a.订单编号),0)+ (select isnull(sum(ac_money),0) from B2C_Account where orderNo=a.订单编号 and cno='017') as 总支付金额     ");
                sbhtml.Append("\r\n    from TM_订单子表 a left join TM_商品表 b on a.商品id=b.id ) t  ");
                if (!string.IsNullOrEmpty(ordernum))
                {
                    sbhtml.Append("\r\n  where  订单编号='" + ordernum + "'");
                }
            }
            else
            {
                sbhtml.Append("\r\n    select *,总金额+运费-总支付金额 as 优惠金额 from (   ");
                sbhtml.Append("\r\n       select ROW_NUMBER() over (order by a.商品id asc ) as 序号,b.编号new,b.品名 as 商品名称 ");
                sbhtml.Append("\r\n    ,b.规格,a.数量,a.订单编号,b.本站价 as 单价,(select 运费 from [dbo].[WP_订单表] where [WP_订单表].订单编号=a.订单编号) as 运费, (select 总金额 from [dbo].[WP_订单表] where [WP_订单表].订单编号=a.订单编号) as 总金额   ");
                sbhtml.Append("\r\n     ,isnull((select 应付款 from [dbo].[WP_订单表] where [WP_订单表].订单编号=a.订单编号),0)+ (select isnull(sum(ac_money),0) from B2C_Account where orderNo=a.订单编号 and cno='017') as 总支付金额     ");
                sbhtml.Append("\r\n    from WP_订单子表 a left join WP_商品表 b on a.商品id=b.id ) t  ");
                if (!string.IsNullOrEmpty(ordernum))
                {
                    sbhtml.Append("\r\n  where  订单编号='" + ordernum + "'");
                }
            }
            DataTable dt = comfun.GetDataTableBySQL(sbhtml.ToString());
            //this.Cell_Freight.DataBindings.Add("Text", dt, "运费");
            //this.Cell_GoodsName.DataBindings.Add("Text", dt, "商品名称");
            //this.Cell_GuiGe.DataBindings.Add("Text", dt, "规格");
            //this.Cell_Number.DataBindings.Add("Text", dt, "数量");
            //this.Cell_Price.DataBindings.Add("Text", dt, "单价");
            //this.Cell_SumPrice.DataBindings.Add("Text", dt, "总支付金额");
            //this.Cell_XuHao.DataBindings.Add("Text", dt, "序号");
            //this.Cell_YouHui.DataBindings.Add("Text", dt, "优惠金额");

            if (dt == null || dt.Rows.Count < 1) return;
            var dtEnum = dt.AsEnumerable();
            var query = dtEnum.Select(p => new
            {
                Cell_运费 = p["运费"],
                Cell_商品名称 = p["商品名称"],
                Cell_规格 = p["规格"],
                Cell_数量 = p["数量"],
                Cell_单价 = p["单价"],
                Cell_总支付金额 = p["总支付金额"],
                Cell_优惠金额 = p["优惠金额"],
                Cell_序号 = p["编号new"] 
            }).ToList();
            if (query == null || query.Count == 0) return;
            for (int i = 1; i <= query.Count; i++)
            {
                var xrRow = xrTable1.InsertRowBelow(xrTable1.Rows[i - 1]);
                xrRow.Cells[0].Text = query[i - 1].Cell_序号.ToString();
                xrRow.Cells[2].Text = query[i - 1].Cell_规格.ToString();
                xrRow.Cells[1].Text = query[i - 1].Cell_商品名称.ToString();
                xrRow.Cells[3].Text = query[i - 1].Cell_数量.ToString();
                xrRow.Cells[4].Text = query[i - 1].Cell_单价.ToString();
                //xrRow.Cells[5].Text = query[i - 1].Cell_运费.ToString();
                //xrRow.Cells[6].Text = query[i - 1].Cell_优惠金额.ToString();
                //xrRow.Cells[7].Text = query[i - 1].Cell_总支付金额.ToString();
                if (i==1)
                {
                    Cell_Freight.Text = query[i - 1].Cell_运费.ToString();
                    Cell_YouHui.Text = query[i - 1].Cell_优惠金额.ToString();
                    Cell_SumPrice.Text = query[i - 1].Cell_总支付金额.ToString();
 
                }
            }

            StringBuilder sbinfo = new StringBuilder();
            sbinfo.Append("\r\n  select t1.*,t2.收货人,t2.收货地址,t2.手机号,convert(varchar(50),下单时间,20) as 下单时间 from  (select  订单编号 ,下单时间,   ");
            sbinfo.Append("\r\n  (select top 1    M_name  from   [dbo].[B2C_mem]  where  openid=WP_订单表.openid) as 买家姓名 from  [dbo].[WP_订单表]    ");
            sbinfo.Append("\r\n  union all select  订单编号 ,下单时间, (select top 1   M_name  from   [dbo].[B2C_mem]  where  openid=TM_订单表.openid)  as 买家姓名   ");
            sbinfo.Append("\r\n  from  [dbo].[TM_订单表] ) t1  left join (select   收货人,WP_地址表.订单编号, 手机号,  省+市+区+isnull(商圈,'')+详细地址 as 收货地址   ");
            sbinfo.Append("\r\n  from [dbo].[WP_订单地址表]  left join [dbo].[WP_地址表] on WP_订单地址表.id=WP_地址表.地址id) t2  ");
            sbinfo.Append("\r\n  on t1.订单编号=t2.订单编号  where  t1.订单编号='" + ordernum + "'");
            DataTable dtt = comfun.GetDataTableBySQL(sbinfo.ToString());
            //订单编号	下单时间	买家姓名	收货地址	手机号	下单时间if (dtt != null && dtt.Rows.Count > 0)
            {
                this.lbl_编号.Text = dtt.Rows[0]["订单编号"] != null ? dtt.Rows[0]["订单编号"].ToString() : "未知";
                this.lbl_联系地址.Text = dtt.Rows[0]["收货地址"] != null ? dtt.Rows[0]["收货地址"].ToString() : "未知";
                this.lbl_联系电话.Text = dtt.Rows[0]["手机号"] != null ? dtt.Rows[0]["手机号"].ToString() : "未知";
                this.lbl_买家姓名.Text = dtt.Rows[0]["收货人"] != null ? dtt.Rows[0]["收货人"].ToString() : "未知";
                this.lbl_下单时间.Text = dtt.Rows[0]["下单时间"] != null ? dtt.Rows[0]["下单时间"].ToString() : "未知";
            }
        }
    }
}
