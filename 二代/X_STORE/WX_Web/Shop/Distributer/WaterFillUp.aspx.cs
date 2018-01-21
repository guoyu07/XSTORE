using Creatrue.kernel;
using DTcms.Common;
using DTcms.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.Distributer
{
    public partial class WaterFillUp : BasePage
    {
        public string hotel_name = string.Empty;
        public string room_name = string.Empty;
        public List<int> position_list;
        public int kwid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
                OpenBox();
            }

        }
        protected void PageInit()
        {

            //获取当前mac的基本信息，房间，酒店等信息
            var selectSql = string.Format(@"
  select a.id as 房间id,仓库名 as 酒店名,库位名 as 房间名  from WP_库位表 a left join WP_仓库表 b on a.仓库id = b.id where 箱子MAC = '{0}'", BoxMac);
            var dt = comfun.GetDataTableBySQL(selectSql);
            if (dt.Rows.Count > 0)
            {
                hotel_name = dt.Rows[0]["酒店名"].ObjToStr();
                room_name = dt.Rows[0]["房间名"].ObjToStr();
                hotel_label.Text = hotel_name;
                room_label.Text = room_name;
                kwid = dt.Rows[0]["房间id"].ObjToInt(0);
                ViewState["kwId"] = kwid;
            }
        }
        protected void OpenBox()
        {
            //获取当前箱子中，商品价格低于一块钱的商品，获取格子信息，并拼接命令开箱
           var  selectSql = string.Format(@" select  convert(nvarchar(2),位置-1)+','
   from WP_箱子表 a left join WP_商品表 b on a.默认商品id = b.id where b.本站价 < 1 and 库位id = {0} and a.实际商品id = 0 FOR XML PATH('')", kwid);
            var dt = comfun.GetDataTableBySQL(selectSql);
            if (dt.Rows.Count > 0)
            {
                var position = dt.Rows[0][0].ObjToStr().TrimEnd(',');
                position_list = position.Split(',').ToList().Select(o => (o.ObjToInt(0) + 1)).ToList();
                ViewState["positionList"] = position_list;
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
           ,'{6}')", backNo, UserId, HotelId, kwid, position.TrimEnd(','), (int)EnumCommon.开箱单状态.待开箱, BoxMac);
                comfun.InsertBySQL(insert_sql);
                var rbh = new RemoteBoxHelper();
                rbh.OpenRemoteBox(BoxMac, backNo, position, 0x02);
            }
            else
            {
                Response.Write("<script>alert('暂无促销品补货任务');window.close();</script>");
                water_fillup.Visible = false;
            }

        }

        protected void water_fillup_ServerClick(object sender, EventArgs e)
        {
            position_list = (List<int>)ViewState["positionList"];
            kwid = (int)ViewState["kwId"];
            var postionStr = position_list.Select(o=>o.ToString()).Aggregate<string>((x, y) => x + ',' + y);
            var updateSql = string.Format(@"update WP_箱子表 set 实际商品id = 默认商品id where 库位id = {0} and 位置 in({1})", kwid, postionStr);
            comfun.UpdateBySQL(updateSql);
            Response.Write("<script>alert('补货成功');window.close();</script>");
            water_fillup.Visible = false;
            PageInit();
        }
    }
}