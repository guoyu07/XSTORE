using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages.Manager
{
    public partial class RoomInfoList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
                #region 绑定的其他信息
                SortImgBtn.ImageUrl = "../../img/sort37.png";

                #endregion
            }
        }
        protected void PageInit(string sort = "SelledAmount desc")
        {
            try
            {
                //表框架
                string sql = string.Format(@"select * from (select WP_库位表.id,WP_库位表.仓库id,库位名,isnull(离线时长,99) as 离线时长,
(select sum(价格*数量) as 销售金额 from WP_订单子表 a left join WP_订单表 b on a.订单编号 = b.订单编号 where a.库位id = WP_库位表.id and b.state in(3,5) ) as SelledAmount,
(select top 1 时间  from [tshop].[dbo].[视图投放记录] where 投放库位id = WP_库位表.id order by 时间 desc) as 补货时间
from WP_库位表 
where WP_库位表.IsShow=1 and WP_库位表.仓库id={0} and 库位名 not like '%总台库%' and 库位名 not like '%总台%') A order by {1}", HotelInfo["id"].ObjToStr(), sort);
                DataTable dt = comfun.GetDataTableBySQL(sql);
                psy_rp.DataSource = dt;
                psy_rp.DataBind();
                room_count.InnerHtml = dt.Rows.Count.ObjToStr();
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：comprehensive", "方法：BindRoom", "异常信息：" + ex.Message);
                RedirectError("");
            }


        }
        #region 判断在线还是离线
        public string GetOnline(int kuweiid)
        {
            var sql = string.Format("SELECT 状态 FROM WP_库位表 WHERE id = {0}", kuweiid);
            var dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ObjToInt(0) == 1)
                {
                    return " <span class=\"online\">在线</span>";
                }
                else
                {
                    return "<span class=\"offline\">离线</span>";
                }
            }
            else
            {
                return "<span class=\"offline\">离线</span>";

            }
        }
        #endregion

        protected void SortImgBtn_OnClick(object sender, ImageClickEventArgs e)
        {
            var sort = SortImgBtn.Attributes["Sort"].ObjToStr();

            if (sort.Equals("down"))
            {
                SortImgBtn.Attributes["Sort"] = "up";
                SortImgBtn.ImageUrl = "../../img/sort33.png";
                PageInit("SelledAmount asc");
            }
            else
            {
                SortImgBtn.Attributes["Sort"] = "down";
                SortImgBtn.ImageUrl = "../../img/sort37.png";
                PageInit("SelledAmount desc");
            }
           
        }
    }
}