using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class remind : BasePage
    {

        public int QianTai=  0;
        public int FangJian = 0;
        public int PingTai = 0;
        public int JiuDian = 0;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        protected void PageInit() {
            BindSale();//前台送货
            BindAddGoods();//补货
            BindGetGoods();//酒店收货
            BindBroadcast();//绑定信息通知
        }
        private void BindSale() {
            var sql = string.Format("SELECT * FROM [视图前台送货] WHERE 仓库id = {0}", HotelInfo["id"].ObjToInt(0));
            DataTable dt = comfun.GetDataTableBySQL(sql);
            QianTai = dt.Rows.Count;
            sale_repter.DataSource = dt;
            sale_repter.DataBind();
        }
        private void BindAddGoods() {
            var sql = string.Format(@"SELECT TOP 1
CONVERT(varchar(10),时间,120) as date,
(select COUNT(*) from dbo.WP_投放任务 B where CONVERT(varchar(10),B.时间,120) <= CONVERT(varchar(10),A.时间,120) and 投放仓库id = {0} and 是否投放 = 0) AS productNum
FROM  dbo.WP_投放任务 A WHERE 投放库位id IN (SELECT id FROM WP_库位表 WHERE 仓库id ={0} ) GROUP BY CONVERT(varchar(10),时间,120) ORDER BY CONVERT(varchar(10),时间,120) DESC
", HotelInfo["id"].ObjToInt(0));
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                FangJian = dt.Rows[0]["productNum"].ObjToInt(0);
            }
           
            add_goods_repter.DataSource = dt;
            add_goods_repter.DataBind();
        }
        protected int GetRoomNum(string date) {
            var sql = string.Format("SELECT 投放库位id FROM  dbo.WP_投放任务 WHERE CONVERT(varchar(10),时间,120) <= '{0}' AND  投放仓库id = {1} and 是否投放 = 0 GROUP BY 投放库位id", date, HotelInfo["id"].ObjToInt(0));
            var dt = comfun.GetDataTableBySQL(sql);
            return dt.Rows.Count;
        }
        private void BindGetGoods() {
            //state 4为已发货
//            var sql = string.Format(@"SELECT A.订单编号,MAX(isnull(A.物流单号,'')) AS 物流单号,MAX(A.下单时间) as 下单时间,MAX(isnull(A.物流公司,'')) AS 物流公司,SUM(isnull(B.数量,0)) as 数量, 
//MAX(ISNULL(C.[仓库名],'')) AS 酒店名称
//FROM [tshop].[dbo].[WP_订单表] A LEFT JOIN [dbo].[WP_订单子表] B 
//ON A.订单编号 = B.订单编号 LEFT JOIN  WP_仓库表 C ON B.仓库id = C.id WHERE state = {0} GROUP BY A.订单编号", 3);
            var sql = string.Format("SELECT * FROM WP_酒店收货提醒 WHERE 仓库id = {0}", HotelInfo["id"].ObjToStr());
            DataTable dt = comfun.GetDataTableBySQL(sql);
            JiuDian = dt.Rows.Count;
            get_goods_repter.DataSource = dt;
            get_goods_repter.DataBind();
        }
        private void BindBroadcast()
        {
            var sql = string.Format("SELECT * FROM WP_重要消息推送表 ORDER BY createtime DESC");
            DataTable dt = comfun.GetDataTableBySQL(sql);
            PingTai = dt.Rows.Count;
            broadcast_repter.DataSource = dt;
            broadcast_repter.DataBind();
        }

    }
}