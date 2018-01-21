using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.database.Common_Pay.WeiXinPay;
using Newtonsoft.Json;
namespace Wx_NewWeb.Shop.Distributer
{
    public partial class roomSatus : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    BindQR();
                    hotels();
                }
                catch (Exception ex)
                {
                    Log.WriteLog("类：roomSatus", "方法：Page_Load", "异常信息:" + ex.Message);
                }
                
            }

        }
        #region 初始化扫码参数
        public string apis = string.Empty;
        public string appId = string.Empty;
        public string timestamp = string.Empty;
        public string noncestr = string.Empty;
        public string signature = string.Empty;
        public WxPayData WXdata = new WxPayData();
        protected void BindQR() {
            try
            {
                JsApiPay jsApiPay = new JsApiPay(this);
                jsApiPay.openid = OpenId;
                //Log.WriteLog("页面：roomSatus", "方法：Page_Load", "OpenId：" + OpenId);
                WXdata = jsApiPay.GetJsApiParametersForQr();//获取H5调起JS API参数   
                appId = WxPayConfig.APPID;
                timestamp = WxPayApi.GenerateTimeStamp();
                noncestr = WxPayApi.GenerateNonceStr();
                signature = new WxPayData().MakeSign();
                apis = "scanQRCode";
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：roomSatus", "方法：BindQR", "异常信息：" + ex.Message);
            }
        
        }
        #endregion
        #region 查询某酒店下除总仓外所有库位
        public static string hotel_name = "";
        public static string hotel_address = "";
        string user_id = "";
        protected void hotels(){
            
            //if (Session["UserId"] != null)
            //{

            //    user_id = Session["UserId"].ToString();
            //}

            //string sql = "select id,用户id,仓库id from WP_用户权限 where 用户id='" + user_id + "' ";
            //DataTable dt = comfun.GetDataTableBySQL(sql);
            
            //int hotel_id = Convert.ToInt32(dt.Rows[0]["仓库id"]);//酒店id
            DataTable dt_hotel_message = comfun.GetDataTableBySQL("select 仓库名,详细地址 from wp_仓库表 where id='" + HotelId + "'");
            if (dt_hotel_message.Rows.Count > 0)
            {
                hotel_name = dt_hotel_message.Rows[0]["仓库名"].ObjToStr();
                hotel_address = dt_hotel_message.Rows[0]["详细地址"].ObjToStr();
            }
            else
            {
                hotel_name = "";
                hotel_address = "";
            }
            DataTable dt_rooms = comfun.GetDataTableBySQL("select 库位名,id,箱子MAC from wp_库位表 where 仓库id='" + HotelId + "' and 库位名 not like '%总台%' and 箱子MAC is not null and 箱子MAC <> '' and isshow=1");
            roomsatus_rp.DataSource = dt_rooms;
            roomsatus_rp.DataBind();

        }
        #endregion
        #region 获取房间状态
        public Dictionary<string,string> GetRoomStatus(int room_id,string boxmac) {

            string href = string.Format("../pages/roomGoods.aspx?kwid={0}&boxmac={1}", room_id, boxmac);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string sql = string.Format("SELECT 状态 FROM [tshop].[dbo].[WP_库位表] WHERE id={0}", room_id);
            Log.WriteLog("页面：roomStatus", "方法：GetRoomStatus", "sql:" + sql);
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                var goods_sql = string.Format(@"SELECT id FROM [WP_箱子表] WHERE 库位id = {0} AND 实际商品id = 0", room_id);
                DataTable goods_dt = comfun.GetDataTableBySQL(goods_sql);
                //1:正常，2：离线
                switch (dt.Rows[0][0].ObjToInt(0))
                {
                    case 1:
                        
                        if (goods_dt.Rows.Count > 0)
                        {
                            dic["class"] = "nep";
                            dic["href"] = href;
                            dic["icon"] = "<p class=\"label noEquipment\">配</p>";
                        }
                        else
                        {
                            dic["class"] = "";
                            dic["href"] = href;
                            dic["icon"] = "";
                        }
                        break;
                    case 2:
                        if (goods_dt.Rows.Count > 0)
                        {
                            dic["class"] = "ofl";
                            dic["href"] = href;
                            dic["icon"] = "<p class=\"label offLine\">配</p>";
                        }
                        else
                        {
                            dic["class"] = "ofl";
                            dic["href"] = "";
                            dic["icon"] = "<p class=\"label offLine\">离</p>";
                        }
                      
                        break;
                    default: break;
                }
            }
            else
            {
                dic["class"] = "";
                dic["href"] = "";
                dic["icon"] = "";
            }
            return dic;
        }
        #endregion
    }
}