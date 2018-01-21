--酒店销售top50排行
select top 50 * from (
select  a.仓库名,b.*,
isnull((select count(*) from WP_库位表 where 仓库id = a.id and 库位名 not like '%总台%'),1) as 房间数
,(b.当日销售额/(select count(*) from WP_库位表 where 仓库id = a.id and 库位名 not like '%总台%')) as 日均房
 from WP_仓库表 a join 
 ( select sum(价格*数量) as 当日销售额,sum(数量) as 销量,库位id,convert(nvarchar(10),WP_订单表.下单时间,120) as 单日 from WP_订单子表 join WP_订单表 on WP_订单表.订单编号 = WP_订单子表.订单编号 where WP_订单表.state in(3,5) group by 库位id,convert(nvarchar(10),WP_订单表.下单时间,120))b
 on a.id = b.库位id where (select count(*) from WP_库位表 where 仓库id = a.id and 库位名 not like '%总台%') > 0 ) c order by 日均房 desc

 --房间销售top50排行
 select top 50 a.库位名 as 房间名,(select 仓库名 from WP_仓库表 where id = a.仓库id) as 酒店名,b.*
 from WP_库位表 a join 
 ( select sum(价格*数量) as 当日销售额,sum(数量) as 销量,库位id,convert(nvarchar(10),WP_订单表.下单时间,120) as 单日 from WP_订单子表 join WP_订单表 on WP_订单表.订单编号 = WP_订单子表.订单编号 where WP_订单表.state in(3,5) group by 库位id,convert(nvarchar(10),WP_订单表.下单时间,120)) b
 on a.id = b.库位id order by 当日销售额 desc




 select *,WP_订单表.state from WP_订单子表 join WP_订单表 on WP_订单表.订单编号 = WP_订单子表.订单编号 where 库位id = 1405 and WP_订单表.state in(3,5)
 select * from WP_库位表 where 库位名 = '8201' and 仓库id = 104
 select * from WP_仓库表 where 仓库名 = '卡米诺主题酒店莱茵广场店'
 select * from WP_商品表 where id in(116
,113
,114
,1117)

