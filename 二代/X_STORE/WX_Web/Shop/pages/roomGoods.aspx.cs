using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Creatrue.kernel;
using DTcms.Common;
using DTcms.Common.Helper;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class roomGoods : BasePage
    {
        public string room_name = "";
        public string psy_name = "";
        string no_img = "/shop/img/no-image.jpg";//默认图片
        public int room_id = 0;
        DataTable test = new DataTable();
        DataTable test2 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int kw_id = Request["kwid"] != null ? Convert.ToInt32(Request["kwid"]) : 0;
                room_id=kw_id;
                string sql_room = string.Format(@"select 用户名,a.库位名 from wp_库位表 a
left join wp_仓库表 b on b.id=a.仓库id
left join wp_用户权限 c on c.仓库id=b.id
left join wp_用户表 d on d.id=c.用户id
where a.id={0} and d.id = {1}", kw_id, UserId);
                DataTable dt_rooms = comfun.GetDataTableBySQL(sql_room);
                for (int i = 0; i < dt_rooms.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        psy_name = dt_rooms.Rows[i]["用户名"].ObjToStr();
                    }
                    else
                    {
                        psy_name += "、" + dt_rooms.Rows[i]["用户名"].ObjToStr();
                    }
                }
                room_name = dt_rooms.Rows[0]["库位名"].ObjToStr();

                string search = string.Format(@"select top 12 WP_箱子表.id as 箱子id,库位id,位置,默认商品id,默认商品品名='',默认商品价格='',默认图片路径='',默认商品编码='',实际商品id,WP_商品表.本站价,wp_商品图片表.图片路径 ,WP_商品表.品名 as 实际商品品名,WP_商品表.编码 as 实际商品编码
from WP_箱子表 left join WP_商品表 on WP_商品表.id=实际商品id 
left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号  
where 库位id={0} and WP_箱子表.isshow=1 order by 位置 asc ", kw_id.ObjToInt(0));
                //Log.WriteLog("页面：mySpace", "方法：goods", "Sql：" + search);
                DataTable search_dt = comfun.GetDataTableBySQL(search);
                DataTable test = new DataTable();
                test = search_dt.Clone();
                object[] obj = new object[test.Columns.Count];
  
                string sql = "select top 12 WP_箱子表.id as 箱子id,库位id,位置,默认商品id,(SELECT 品名 FROM WP_商品表 WHERE id =默认商品id ) as 默认商品品名,(SELECT 本站价 FROM WP_商品表 WHERE id =默认商品id ) as 默认商品价格,(SELECT b.图片路径 FROM  [tshop].[dbo].[WP_商品表] A LEFT JOIN [tshop].[dbo].[WP_商品图片表] B ON A.编号 = B.商品编号 WHERE A.id = 默认商品id) AS 默认图片路径,(SELECT 编码 FROM WP_商品表 WHERE id =默认商品id ) as 默认商品编码,实际商品id,WP_商品表.本站价,wp_商品图片表.图片路径 ,WP_商品表.品名 as 实际商品品名,WP_商品表.编码 as 实际商品编码 from WP_箱子表 left join WP_商品表 on WP_商品表.id=实际商品id left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号  where 库位id='" + kw_id + "' and WP_箱子表.status=1 order by 位置 asc";
                Log.WriteLog("页面：mySpace", "方法：goods", "sql：" + sql);
                DataTable dt = comfun.GetDataTableBySQL(sql);
                string sql_rexiao = @"select 商品id,视图出库表.品名,WP_商品表.编码,本站价,图片路径 from 视图出库表
left join WP_商品表 on  视图出库表.商品id=wp_商品表.id
left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号
group by 商品id,视图出库表.品名,本站价,图片路径,编码 order by count(商品id) desc,max(操作日期) desc ";
                Log.WriteLog("页面：mySpace", "方法：goods", "1：");
                DataTable dt_rexiao = comfun.GetDataTableBySQL(sql_rexiao);
                string rexiao_id = "0";
                string rexiao_name = "";
                string rexiao_price = "0";
                string rexiao_img = "0";
                string rexiao_code = "";
                Log.WriteLog("页面：mySpace", "方法：goods", "2：");
                if (dt_rexiao.Rows.Count > 0)
                {

                    rexiao_id = dt_rexiao.Rows[0]["商品id"].ObjToStr();
                    rexiao_name = dt_rexiao.Rows[0]["品名"].ObjToStr();
                    rexiao_code = dt_rexiao.Rows[0]["编码"].ObjToStr();
                    rexiao_price = dt_rexiao.Rows[0]["本站价"].ObjToStr();
                    rexiao_img = dt_rexiao.Rows[0]["图片路径"].ObjToStr();
                    Log.WriteLog("页面：mySpace", "方法：goods", "rexiao_id：" + rexiao_id);
                }

                Log.WriteLog("页面：mySpace", "方法：goods", "3：");
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    Log.WriteLog("页面：mySpace", "方法：goods", "3："+a);
                    dt.Rows[a].ItemArray.CopyTo(obj, 0);
                    Log.WriteLog("页面：mySpace", "方法：goods", "4：" + a);
                    test.Rows.Add(obj);
                    Log.WriteLog("页面：mySpace", "方法：goods", "xxx：" + dt.Rows[a]["默认商品id"].ObjToStr());
                    int str = dt.Rows[a]["默认商品id"].ObjToInt(0);
                    Log.WriteLog("页面：mySpace", "方法：goods", "4：" + a);
                    Log.WriteLog("页面：mySpace", "方法：goods", "5：" + a);
                    if (str == 0)
                    {
                        test.Rows[a]["实际商品id"] = rexiao_id;
                        test.Rows[a]["实际商品品名"] = rexiao_name;
                        test.Rows[a]["本站价"] = rexiao_price;
                        test.Rows[a]["实际商品编码"] = rexiao_code;
                        test.Rows[a]["图片路径"] = rexiao_img;
                    }
                    Log.WriteLog("页面：mySpace", "方法：goods", "6：" + a);
                    if (dt.Rows[a]["实际商品id"].ObjToInt(0) == 0)
                    {
                        Log.WriteLog("页面：mySpace", "方法：goods", "a" + a);
                        test.Rows[a]["实际商品品名"] = test.Rows[a]["默认商品品名"];
                        test.Rows[a]["本站价"] = test.Rows[a]["默认商品价格"];
                        test.Rows[a]["实际商品编码"] = test.Rows[a]["默认商品编码"];
                        test.Rows[a]["图片路径"] = test.Rows[a]["默认图片路径"];
                    }
                    Log.WriteLog("页面：mySpace", "方法：goods", "7：" + a);
                    if (string.IsNullOrEmpty(test.Rows[a]["图片路径"].ObjToStr()))
                    {
                        test.Rows[a]["图片路径"] = no_img;
                    }
                }
                Log.WriteLog("类：roomGoods", "方法：link_ul", "test：" + JsonConvert.SerializeObject(test));
                box_rp.DataSource = test;
                box_rp.DataBind();


            }
        }
        public string link_ul(int goods_id)
        {
            Log.WriteLog("类：roomGoods","方法：link_ul","进入了方法");
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
        private void OpenAllBox()
        {

            var rbh = new RemoteBoxHelper();

            var postion_list = "0,1,2,3,4,5,6,7,8,9,10,11";
            var boxmac = Request.QueryString["boxmac"].ObjToStr();
            try
            {
                rbh.OpenRemoteBox("" + boxmac + "", "", "" + postion_list + "");
              
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：roomDetail", "方法：OpenBox", "异常信息：" + ex.Message);
                RedirectError("配货失败");
            }

        }
        protected void SingleOpenBoxClick(object sender,EventArgs e)
        {
            Log.WriteLog("类：roomGoods", "方法：SingleOpenBoxClick", "在进行单个位置的开箱检查");
            var roleId = UserInfo["角色id"].ObjToInt(0);
            if (roleId != 1 && roleId != 4)
            {
                return;
            }
            var position = ((HtmlAnchor)sender).Attributes["position"].ObjToInt(0) - 1;

            OpenSingleBox(position);
        }
        protected void makeSure_ServerClick(object sender, EventArgs e)
        {
            Log.WriteLog("类：roomGoods","方法：makeSure_ServerClick","在进行开箱检查");
            OpenAllBox();
        }
        protected void OpenSingleBox(int position)
        {

            var rbh = new RemoteBoxHelper();

            var boxmac = Request.QueryString["boxmac"].ObjToStr();
            Log.WriteLog("类：roomGoods", "方法：OpenSingleBox", "boxmac："+ boxmac);
            Log.WriteLog("类：roomGoods", "方法：OpenSingleBox", "position：" + position);
            try
            {
                rbh.OpenRemoteBox("" + boxmac + "", "", "" + position + "");
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：roomDetail", "方法：OpenBox", "异常信息：" + ex.Message);
                RedirectError("配货失败");
            }
        }
        protected void finishCheck_Click(object sender, EventArgs e)
        {
            //返回房间列表页面
            Response.Redirect("../Distributer/roomSatus.aspx",false);
            return;
        }
    }
}