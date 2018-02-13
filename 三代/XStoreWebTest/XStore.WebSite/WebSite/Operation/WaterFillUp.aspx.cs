using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XStore.Common;
using XStore.Common.Helper;
using XStore.Entity;
using XStore.Entity.Model;

namespace XStore.WebSite.WebSite.Operation
{
    public partial class WaterFillUp : MacPage
    {
        #region 酒店信息
        private Hotel _hotelInfo;
        public Hotel hotelInfo
        {
            get
            {
                if (_hotelInfo == null)
                {
                    if (Session[Constant.HotelId].ObjToInt(0) == 0)
                    {
                        var hotelId = Request.QueryString[Constant.HotelId].ObjToInt(0);
                        if (hotelId != 0)
                        {
                            _hotelInfo = context.Query<Hotel>().FirstOrDefault(o => o.id == hotelId);
                            Session[Constant.HotelId] = _hotelInfo.id;
                        }
                        else
                        {
                            _hotelInfo = context.Query<Hotel>().LeftJoin<UserHotel>((a, b) => a.id == b.hotels_id).Where((a, b) => b.user_username.Equals(userInfo.username)).Select((a, b) => new Hotel
                            {
                                id = a.id,
                                hotel_name = a.hotel_name,
                                simple_name = a.simple_name,
                                address = a.address
                            }).FirstOrDefault();
                            Session[Constant.HotelId] = _hotelInfo.id;
                        }
                    }
                    else
                    {
                        var hotelId = Session[Constant.HotelId].ObjToInt(0);
                        _hotelInfo = context.Query<Hotel>().FirstOrDefault(o => o.id == hotelId);
                    }

                }
                return _hotelInfo;
            }
        }
        #endregion
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

           
        }
        protected void OpenBox()
        {
            var proidList = context.Query<Cell>()
                .LeftJoin<Product>((a,b)=>a.product_id==b.id)
                .Where((a,b) => a.part == 0 && a.mac.Equals(cabinet.mac)&& !a.product_id.HasValue && b.price1<=100)
                .Select((a,b) => a.pos)
                .ToList();
            if (proidList.Count == 0)
            {
                proidList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            if (proidList.Count>0)
            {
                ViewState["positionList"] = proidList;

                var requestUrl = string.Format(Constant.YunApi + "test/back/start?mac={0}&username={1}", cabinet.mac, userInfo.username);
                LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "backNoRequestUrl：" + requestUrl);
                var response = JsonConvert.DeserializeObject<BackNoResponse>(Utils.HttpGet(requestUrl));
                LogHelper.WriteLogs(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "backNoResponse：" + JsonConvert.SerializeObject(response));
                if (!response.operationStatus.Equals("SUCCESS"))
                {
                    MessageBox.Show(this, "system_alert", "补货单生成失败");
                    return;
                }
                ViewState["BackNo"] = response.operationMessage;

                var rbh = new RemoteBoxHelper();
                //var posStr = proidList.Aggregate<int>((x, y) => x.ObjToStr() + "," + y.ObjToStr());
                //rbh.OpenRemoteBox(cabinet.mac, response.operationMessage, posStr, 0x02);
            }
            else
            {
                MessageBox.Show(this, "system_alert", "暂无促销品补货任务");
                return;
            }
        }

        protected void water_fillup_ServerClick(object sender, EventArgs e)
        {
            //position_list = (List<int>)ViewState["positionList"];
            //kwid = (int)ViewState["kwId"];
            //var postionStr = position_list.Select(o => o.ToString()).Aggregate<string>((x, y) => x + ',' + y);
            //var updateSql = string.Format(@"update WP_箱子表 set 实际商品id = 默认商品id where 库位id = {0} and 位置 in({1})", kwid, postionStr);
            //comfun.UpdateBySQL(updateSql);
            //Response.Write("<script>alert('补货成功');window.close();</script>");
            //water_fillup.Visible = false;
            //PageInit();
        }
    }
}