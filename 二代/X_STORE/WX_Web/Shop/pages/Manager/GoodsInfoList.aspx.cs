using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages.Manager
{
    public partial class GoodsInfoList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        protected void PageInit()
        {
            var all_sql = string.Format(@" 
declare @s int
  set @s = {0}
select * from (
  select b.本站价,b.编码,b.品名,isnull(c.图片路径,'') as 图片路径,
(select sum(isnull(WP_订单子表.数量,0)) as 累计销售 from WP_订单子表 left join WP_订单表  on WP_订单表.订单编号 = WP_订单子表.订单编号  where WP_订单子表.仓库id = {0} and WP_订单子表.商品id = b.id and WP_订单表.state in(3,5)) as 累计销售,
    (select (sum(isnull(WP_入库表.数量,0))-sum(isnull(WP_出库表.数量,0))) as kucuncount from WP_入库表 left join WP_出库表 on WP_入库表.库位id = WP_出库表.库位id and WP_入库表.商品id =WP_出库表.商品id where WP_入库表.库位id in (SELECT id FROM [tshop].[dbo].[WP_库位表] where 库位名 = '总台' and 仓库id = @s ) and WP_入库表.商品id = b.id group by WP_入库表.商品id,WP_出库表.商品id ) as 前台库存
  ,(select 
  sum(isnull(WP_入库表.数量,0)) as rukucount 
  from WP_入库表 
  left join WP_出库表 
  on WP_入库表.库位id = WP_出库表.库位id 
  and WP_入库表.商品id =WP_出库表.商品id 
  where WP_入库表.库位id in 
  (SELECT id FROM [tshop].[dbo].[WP_库位表] where 库位名 not in('总台','总台库') and 仓库id = @s) 
  and WP_入库表.商品id = b.id) as 房间库存
    ,(select 
  sum(isnull(WP_出库表.数量,0)) as chukucount 
  from WP_入库表 
  left join WP_出库表 
  on WP_入库表.库位id = WP_出库表.库位id 
  and WP_入库表.商品id =WP_出库表.商品id 
  where WP_出库表.库位id in 
  (SELECT id FROM [tshop].[dbo].[WP_库位表] where 库位名 not in('总台','总台库') and 仓库id = @s) 
  and WP_出库表.商品id = b.id) as 销量
  from  WP_商品表 b left join WP_商品图片表 c on b.编号 =c.商品编号
  where b.id in(select 商品id from [dbo].[视图在库表] a where a.库位id in(select id from WP_库位表 where 仓库id = @s))
) H order by 累计销售 desc", HotelInfo["id"].ObjToInt(0));
            Log.WriteLog("类：comprehensive_hm", "方法：BindGoods", "all_sql：" + all_sql);
            var dt = comfun.GetDataTableBySQL(all_sql);

            var room_product_count = 0;

            Log.WriteLog("类：comprehensive_hm", "方法：BindGoods", "dt：" + Newtonsoft.Json.JsonConvert.SerializeObject(dt));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                Log.WriteLog("类：comprehensive_hm", "方法：BindGoods", "dr" + i + "：");

                //qiantai_product_count += dr["前台库存"].ObjToInt(0);
                room_product_count += dr["房间库存"].ObjToInt(0);
                //sale_count += dr["销量"].ObjToInt(0);
            }

            goods_rp.DataSource = dt;
            goods_rp.DataBind();
            goods_count.InnerText = (dt.Rows.Count).ObjToStr();
        }
    }
}