using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Creatrue.kernel;
using DTcms.DBUtility;
using DTcms.Common;
using DTcms.Common.Helper;

namespace Wx_NewWeb.Shop.pages
{
    public partial class roomDetail : BasePage
    {
        public string room_name = "";
        public string psy_name = "";
        string no_img = "/shop/img/no-image.jpg";//默认图片
        public int room_id = 0;
        public string mac = string.Empty;

        DataTable test2 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();

            }
        }
        private int _kuweiid;
        protected int KuWeiId
        {
            get {
                if (_kuweiid == 0)
                {
                    _kuweiid = Request["kwid"].ObjToInt(0);
                }
                return _kuweiid;
            }
        }
        protected void PageInit()
        {
            
            if (!IsPostBack)
            {
                int kw_id = Request["kwid"] != null ? Convert.ToInt32(Request["kwid"]) : 0;
                room_id = kw_id;
                string sql_room = @"select 用户名,a.库位名,a.箱子MAC,b.仓库名 from wp_库位表 a
left join wp_仓库表 b on b.id=a.仓库id
left join wp_用户权限 c on c.仓库id=b.id
left join wp_用户表 d on d.id=c.用户id
where a.id='" + kw_id + "' and d.角色id=3";
                DataTable dt_rooms = comfun.GetDataTableBySQL(sql_room);
                for (int i = 0; i < dt_rooms.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        psy_name = dt_rooms.Rows[i]["用户名"].ObjToStr();
                        room_name = dt_rooms.Rows[i]["仓库名"].ObjToStr() + "-" + dt_rooms.Rows[i]["库位名"].ObjToStr();
                        mac = dt_rooms.Rows[i]["箱子MAC"].ObjToStr();
                    }
                    else
                    {
                        psy_name += "、" + dt_rooms.Rows[i]["用户名"].ObjToStr();
                    }
                }
                string sql = @"select top 12 WP_箱子表.id as 箱子id,WP_商品表.编码,库位id,位置,默认商品id,
(SELECT 品名 FROM WP_商品表 WHERE id =默认商品id ) as 默认商品品名,
(SELECT 本站价 FROM WP_商品表 WHERE id =默认商品id ) as 默认商品价格,
(SELECT 编码 FROM WP_商品表 WHERE id =默认商品id ) as 默认商品编码,
(SELECT b.图片路径 FROM  [tshop].[dbo].[WP_商品表] A LEFT JOIN [tshop].[dbo].[WP_商品图片表] B ON A.编号 = B.商品编号 WHERE A.id = 默认商品id) AS 默认图片路径,
实际商品id,WP_商品表.本站价,wp_商品图片表.图片路径 ,WP_商品表.品名 as 实际商品品名 
from WP_箱子表 left join WP_商品表 on WP_商品表.id=实际商品id left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号  where 库位id='" + kw_id + "' and WP_箱子表.status=1 order by 位置 asc";
                Log.WriteLog("页面：mySpace", "方法：goods", "sql：" + sql);
                DataTable dt = comfun.GetDataTableBySQL(sql);
                string sql_rexiao = @"select 商品id,视图出库表.品名,WP_商品表.编码,本站价,图片路径 from 视图出库表
left join WP_商品表 on  视图出库表.商品id=wp_商品表.id
left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号
group by 商品id,视图出库表.品名,本站价,图片路径,WP_商品表.编码 order by count(商品id) desc,max(操作日期) desc ";
                DataTable dt_rexiao = comfun.GetDataTableBySQL(sql_rexiao);
                string rexiao_id = "0";
                string rexiao_name = "";
                string rexiao_price = "0";
                string rexiao_img = "0";
                string rexiao_code = "";
                List<int> deleteIndex = new List<int>();
                if (dt_rexiao.Rows.Count > 0)
                {
                    rexiao_id = dt_rexiao.Rows[0]["商品id"].ObjToStr();
                    rexiao_name = dt_rexiao.Rows[0]["品名"].ObjToStr();
                    rexiao_price = dt_rexiao.Rows[0]["本站价"].ObjToStr();
                    rexiao_img = dt_rexiao.Rows[0]["图片路径"].ObjToStr();
                    rexiao_code = dt_rexiao.Rows[0]["编码"].ObjToStr();
                    Log.WriteLog("页面：mySpace", "方法：goods", "rexiao_id：" + rexiao_id);
                }
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    int str = dt.Rows[a]["默认商品id"].ObjToInt(0);
                    if (str == 0)
                    {
                        //dt.Rows[a]["实际商品id"] = rexiao_id;
                        //dt.Rows[a]["实际商品品名"] = rexiao_name;
                        //dt.Rows[a]["本站价"] = rexiao_price;
                        //dt.Rows[a]["图片路径"] = rexiao_img;
                        //dt.Rows[a]["编码"] = rexiao_code;
                        deleteIndex.Add(a);
                        continue;
                    }

                    if (dt.Rows[a]["实际商品id"].ObjToInt(0) == 0)
                    {
                        Log.WriteLog("页面：mySpace", "方法：goods", "a" + a);
                        dt.Rows[a]["实际商品品名"] = dt.Rows[a]["默认商品品名"];
                        dt.Rows[a]["本站价"] = dt.Rows[a]["默认商品价格"].ObjToDecimal(0);
                        dt.Rows[a]["图片路径"] = dt.Rows[a]["默认图片路径"];
                        dt.Rows[a]["编码"] = dt.Rows[a]["默认商品编码"];
                    }

                    if (string.IsNullOrEmpty(dt.Rows[a]["图片路径"].ObjToStr()))
                    {
                        dt.Rows[a]["图片路径"] = no_img;
                    }
                }
                for (int i = deleteIndex.Count - 1; i >= 0; i--)
                {
                    dt.Rows[deleteIndex[i]].Delete();
                }
                dt.AcceptChanges();
                box_rp.DataSource = dt;
                box_rp.DataBind();
            }

            var msg = string.Empty;
            if (!Check(out msg))
            {
                return;
            }
            //空格开箱
            RoomOpenBox();
           
        }
        protected void RoomOpenBox()
        {
            #region 将已卖的商品开箱
            try
            {
                var sql = string.Format(@"SELECT WP_商品表.id,品名,编号new AS 编号,补货商品.箱子位置 AS 位置,补货商品.箱子MAC, wp_商品图片表.图片路径 FROM (SELECT * FROM 视图获取投放商品id WHERE  投放库位id = {0}) AS 补货商品 
LEFT JOIN WP_商品表 ON 补货商品.最新商品id = WP_商品表.id
LEFT JOIN  wp_商品图片表 on wp_商品图片表.商品编号=WP_商品表.编号", KuWeiId);
                Log.WriteLog("页面：roomDetail", "方法：PageInit", "sql：" + sql);
                var dt = comfun.GetDataTableBySQL(sql);
                if (dt.Rows.Count > 0)
                {
                    OpenBox(dt);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：roomDetail", "方法：PageInit", "异常信息：" + ex.Message);
                RedirectError(ex.Message);
            }
            #endregion

        }
        public string link_ul(int goods_id)
        {
            Log.WriteLog("类：roomGoods", "方法：link_ul", "进入了方法");
            Log.WriteLog("类：roomGoods", "方法：link_ul", "goods_id：" + goods_id);
            if (goods_id == 0)
            {
                Log.WriteLog("类：roomGoods", "方法：link_ul", "display:block;");
                return "display:block;";
            }
            else
            {
                Log.WriteLog("类：roomGoods", "方法：link_ul", "display:none;");
                //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("----------------", "myspace-link_detal", "../pages/detail.aspx?goods_id=" + goods_id + "&weizhi=" + weizhi + "&kwid=" + kwid + "");
                return "display:none;";
            }
        }
        private void OpenBox(DataTable dt) {

            var rbh = new RemoteBoxHelper();
            var mac = string.Empty;
            var postion_list = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    mac = dt.Rows[i]["箱子MAC"].ObjToStr();
                }
                postion_list += (dt.Rows[i]["位置"].ObjToInt(0) - 1).ObjToStr() + ",";
            }
            try
            {

                var backNo = GetBackNo();
                var insert_sql = string.Format(@"INSERT INTO [dbo].[WP_补货单]
           ([OrderNo]
           ,[Operator]
           ,[HotelId]
           ,[RoomId]
           ,[Position]
           ,[Status]
           ,[Mac])
     VALUES
           ('{0}'
           ,{1}
           ,{2}
           ,{3}
           ,'{4}'
           ,{5}
           ,'{6}')", backNo, UserId,HotelId,KuWeiId,postion_list.TrimEnd(','), (int)EnumCommon.开箱单状态.待开箱,mac);
                comfun.InsertBySQL(insert_sql);
                Log.WriteLog("页面：roomDetail", "方法：OpenBox", "mac：" + mac);
                Log.WriteLog("页面：roomDetail", "方法：OpenBox", "postion_list：" + postion_list.TrimEnd(','));
                rbh.OpenRemoteBox("" + mac + "", backNo.Substring(1, backNo.Length - 1), "" + postion_list.TrimEnd(',') + "",0x02);
            }
            catch(Exception ex)
            {
                Log.WriteLog("页面：roomDetail", "方法：OpenBox", "异常信息：" + ex.Message);
                RedirectError("配货失败");
            }

        }

        protected void redirect_link(string msg)
        {
            var href_url = string.Empty;
            switch ((EnumCommon.角色权限)UserInfo["角色id"])
            {
                case EnumCommon.角色权限.经理:
                case EnumCommon.角色权限.区域经理:
                    href_url = "hotelManager.aspx";
                    break;
                case EnumCommon.角色权限.前台:
                    href_url = "../Distributer/disMyself.aspx";
                    break;
                case EnumCommon.角色权限.财务:

                case EnumCommon.角色权限.集团经理:

                case EnumCommon.角色权限.集团财务:

                case EnumCommon.角色权限.后台财务:

                case EnumCommon.角色权限.后台管理员:

                default:
                    break;
            }
            Response.Write(string.Format("<script>alert('{1}');window.location.href='{0}'</script>", href_url, msg));
        }
        protected bool Check(out string msg) {
            #region 判断是否需要补货
            var kw_sql = string.Format(@"select id from WP_箱子表 where 库位id ={0} and 实际商品id = 0", KuWeiId);
            var kw_dt = comfun.GetDataTableBySQL(kw_sql);
            if (kw_dt.Rows.Count == 0)
            {
                msg = "无需补货";
                return false;
            }
            #endregion
            #region 判断当前房间是否取货，如果没有取货怎提示请先取货

            var quhuo_sql = string.Format(@"select * from WP_取货记录表 where 用户id={0} and 补货的房间id={1} and 是否补货完成={2}",
                UserId, KuWeiId, 0);
            var quhuo_dt = comfun.GetDataTableBySQL(quhuo_sql);
            if (quhuo_dt.Rows.Count == 0)
            {
                msg = "请先取货";
                return false;
            }
            msg = string.Empty;
            return true;
            #endregion
        }

        #region 补货开箱
        protected void openBox_ServerClick(object sender, EventArgs e)
        {
            RoomOpenBox();
        }
        #endregion

        #region 补货完成
        protected void finish_button_Click(object sender, EventArgs e)
        {
            try
            {
                var msg = string.Empty;
                if (!Check(out msg))
                {
                    redirect_link(msg);
                    return;
                }
                var sql = string.Format(@"SELECT WP_商品表.id,WP_商品表.本站价,品名,编号new AS 编号,补货商品.箱子位置 AS 位置, wp_商品图片表.图片路径 FROM (SELECT * FROM 视图获取投放商品id WHERE 投放仓库id = {0} AND 投放库位id = {1}) AS 补货商品 
LEFT JOIN WP_商品表 ON 补货商品.最新商品id = WP_商品表.id
LEFT JOIN  wp_商品图片表 on wp_商品图片表.商品编号=WP_商品表.编号", HotelInfo["id"].ObjToInt(0), KuWeiId);
                var dt = comfun.GetDataTableBySQL(sql);
                //获取需要更新的商品id
                var begin_exsql = " Begin Tran ";
                var exsql = string.Empty;
                var end_sql = @" If @@ERROR>0
                                Rollback Tran  
                            Else
                                Commit Tran
                            Go";

                foreach (DataRow item in dt.Rows)
                {
                    var goods_id = item["id"].ObjToInt(0);
                    var price = item["本站价"].ObjToDecimal(0);
                    var position = item["位置"].ObjToInt(0);
                    //获取总仓的id，用于总仓的出库
                    var room_sql = string.Format("SELECT id FROM [dbo].[WP_库位表] WHERE 库位名 LIKE '%总台%' AND 仓库id = {0}", HotelInfo["id"].ObjToInt(0));
                    var room_dt = comfun.GetDataTableBySQL(room_sql);
                    if (room_dt.Rows.Count == 0)
                    {
                        RedirectError("总仓没了");
                        return;
                    }
                    var root_room = room_dt.Rows[0][0].ObjToInt(0);

                    #region 入库表扣除总台的库存减一
                    string out_num = "OutS" + DateTime.Now.ToString("yyyyMMdd") + DbHelperSQL.Query(@"select right('00000'+cast(a.num+1 as  varchar(50)),5) from (select count(1) as num from [dbo].[WP_出库表] where CONVERT(varchar(100),操作日期,23)=CONVERT(varchar(100),GETDATE(),23)) a").Tables[0].Rows[0][0].ToString();
                    exsql += string.Format(@" INSERT INTO [dbo].[WP_出库表] ([单据编号],[商品id],[数量],[出价],[总出价额],[操作日期],[库位id],[位置],[操作id],[出库类型])
                                VALUES('{0}','{1}','{2}','{3}','{3}',GETDATE(),'{4}','{5}','{6}',{7})", out_num, goods_id, 1, price, root_room, 1, UserId, (int)EnumCommon.出库类型.手机出库);
                    #endregion

                    #region 入库表库位库存加1，如果根据仓库id，库位id，位置查询结果如果没有记录则新增一条，如果有记录则更新数量加1
                    string ins_num = "InS" + DateTime.Now.ToString("yyyyMMdd") + DbHelperSQL.Query(@"select right('00000'+cast(a.num+1 as  varchar(50)),5) from (select count(1) as num from [dbo].[WP_入库表] where CONVERT(varchar(100),操作日期,23)=CONVERT(varchar(100),GETDATE(),23)) a").Tables[0].Rows[0][0].ToString();
                    exsql += string.Format(@" INSERT INTO [dbo].[WP_入库表] ([单据编号],[商品id],[数量],[进价],[总进价额],[操作日期],[库位id],[位置],[操作id],[入库类型])
                                VALUES('{0}','{1}','{2}','{3}','{3}',GETDATE(),'{4}','{5}','{6}',{7})", ins_num, goods_id, 1, price, KuWeiId, position, UserId, (int)EnumCommon.入库类型.手机入库);
                    #endregion

                    #region 更新箱子信息
                    exsql += string.Format(@" UPDATE WP_箱子表 SET 实际商品id={0} WHERE  库位id='{1}' and 位置='{2}'", goods_id, KuWeiId, position);
                    #endregion

                    #region 更新取货记录表
                    exsql += string.Format(@" UPDATE WP_取货记录表 SET 是否补货完成=1 WHERE  用户id='{0}' and 补货的房间id='{1}'", UserId, KuWeiId);
                    #endregion

                    #region 更新配送任务，并标记为已配货
                    exsql += string.Format(@" UPDATE WP_投放任务 SET 是否投放=1,user_id={3} WHERE 投放仓库id='{0}' and 投放库位id='{1}' and 箱子位置='{2}'", HotelInfo["id"].ObjToInt(0), KuWeiId, position, UserId);
                    #endregion
                }
                Log.WriteLog("页面：roomDetail", "方法：finish_button_Click", "ExSql:" + begin_exsql + exsql + end_sql);
                var b = SqlDataHelper.ExecuteCommand(begin_exsql + exsql + end_sql);
                Log.WriteLog("页面：roomDetail", "方法：finish_button_Click", "b：" + b);
                if (b > 0)
                {
                    Response.Redirect("roomsPickUp.aspx", false);
                    return;
                }
                else
                {
                    Response.Write("<script>alert('配货失败!');window.location.href='roomsPickUp.aspx'</script>");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：roomDetail", "方法：finish_button_Click", "异常信息：" + ex.Message);
                RedirectError("配货失败");
            }

        }
        #endregion



    }
}