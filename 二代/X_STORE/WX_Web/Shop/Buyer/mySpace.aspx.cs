using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.DBUtility;
using Creatrue.kernel;
using System.Web.UI.HtmlControls;
using tdx.Weixin;
using Creatrue.Common.Msgbox;
using tdx.database.Common_Pay.WeiXinPay;
using Newtonsoft.Json;

namespace Wx_NewWeb.Shop.Buyer
{
    public partial class mySpace : BasePage
    {

        DataTable test2 = new DataTable();
        string no_img = "/shop/img/no-image.jpg";//默认图片
        string no_goods = "/shop/img/nogoods.jpg";
        
        #region 库位
        private DataRow _kuwei;
        protected DataRow KuWei
        {
            get
            {
                if (_kuwei == null)
                {
          
                    var sql = string.Format("SELECT * FROM [WP_库位表] WHERE 箱子MAC = '{0}'",BoxMac);
                    Log.WriteLog("页面：mySpace", "方法：PageLoad", "sql:" + sql);
                    var dt = comfun.GetDataTableBySQL(sql);
                    if (dt.Rows.Count > 0)
	                {
		                _kuwei = dt.Rows[0];
	                }
                    else
                    {
                        RedirectError("");
                    }
                    
                   
                }
                return _kuwei;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!IsOffline)
                //{
                    
                //}
                Log.WriteLog("页面：mySpace", "方法：PageLoad", "状态：" + KuWei["状态"].ObjToInt(0));
                if (KuWei["状态"].ObjToInt(0) == 2)//离线
                {
                    Response.Redirect(string.Format("../pages/noPower.aspx?boxmac = {0}", BoxMac), false);
                    return;
                }
                else
                {
                    goods();
                }
            }
        }

        //   public static string test = "../pages/detail.aspx?goods_id=<%#Eval('实际商品id')%>";
        protected void goods()
        {
            try
            {
                //Log.WriteLog("页面：mySpace", "方法：goods", "进入");
                //  Session["Openid"] = "o8eAHwHbkUqC54iWdndgwukUi6S0";
                //Session["boxmac"]="861853031342827";861853031328511.
                // Session["boxmac"] = "861853031485105";

                //商品列表
                //var rbh = new RemoteBoxHelperNew();o8eAHwM94iBA0GGYsh8tnJ1pmuM8
                //rbh.OpenRemoteBox("861853031328511", "1,2");
                //先写死 库位id=63 箱子mac=789456  代表着 1002房间 下的 智能货箱
                //通过箱子地址查询房间号即库位id 

                //   openid="o8eAHwHbkUqC54iWdndgwukUi6S0";
                //boxmac="861853031342827";
                if (KuWei == null)
                {
                    RedirectError("房间不存在");
                }
                string search = string.Format(@"select top 12 WP_箱子表.id as 箱子id,库位id,位置,默认商品id,默认商品品名='',默认商品价格='',默认图片路径='',实际商品id,WP_商品表.本站价,wp_商品图片表.图片路径 ,WP_商品表.品名 as 实际商品品名 
from WP_箱子表 left join WP_商品表 on WP_商品表.id=实际商品id 
left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号  
where 库位id={0} and WP_箱子表.isshow=1 order by 位置 asc  ", KuWei["id"].ObjToInt(0));
                //Log.WriteLog("页面：mySpace", "方法：goods", "Sql：" + search);
                DataTable search_dt = comfun.GetDataTableBySQL(search);
                DataTable test = new DataTable();
                test = search_dt.Clone();
                test2 = search_dt.Clone();
                object[] obj = new object[test.Columns.Count];
                object[] obj2 = new object[test2.Columns.Count];
                //复制表框架
                //string sql_kw = "select id as 库位id,仓库id from WP_库位表 where 箱子MAC='" + BoxMac + "'";
                //DataTable dt_kw = comfun.GetDataTableBySQL(sql_kw);
                //Log.WriteLog("", "客户", sql_kw);
                //int kwid = dt_kw.Rows[0]["库位id"].ObjToInt(0);
                string sql = "select top 12 WP_箱子表.id as 箱子id,库位id,位置,默认商品id,(SELECT 品名 FROM WP_商品表 WHERE id =默认商品id ) as 默认商品品名,(SELECT 本站价 FROM WP_商品表 WHERE id =默认商品id ) as 默认商品价格,(SELECT b.图片路径 FROM  [tshop].[dbo].[WP_商品表] A LEFT JOIN [tshop].[dbo].[WP_商品图片表] B ON A.编号 = B.商品编号 WHERE A.id = 默认商品id) AS 默认图片路径,实际商品id,WP_商品表.本站价,wp_商品图片表.图片路径 ,WP_商品表.品名 as 实际商品品名 from WP_箱子表 left join WP_商品表 on WP_商品表.id=实际商品id left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号  where 库位id='" + KuWei["id"].ObjToInt(0) + "' and WP_箱子表.status=1 order by 位置 asc";
                Log.WriteLog("页面：mySpace", "方法：goods", "sql：" + sql);
                DataTable dt = comfun.GetDataTableBySQL(sql);
                string sql_rexiao = @"select 商品id,视图出库表.品名,本站价,图片路径 from 视图出库表
left join WP_商品表 on  视图出库表.商品id=wp_商品表.id
left join wp_商品图片表 on wp_商品表.编号=wp_商品图片表.商品编号
group by 商品id,视图出库表.品名,本站价,图片路径 order by count(商品id) desc,max(操作日期) desc ";
                DataTable dt_rexiao = comfun.GetDataTableBySQL(sql_rexiao);
                string rexiao_id = "0";
                string rexiao_name = "";
                string rexiao_price = "0";
                string rexiao_img = "0";
                if (dt_rexiao.Rows.Count > 0)
                {
                    rexiao_id = dt_rexiao.Rows[0]["商品id"].ObjToStr();
                    rexiao_name = dt_rexiao.Rows[0]["品名"].ObjToStr();
                    rexiao_price = dt_rexiao.Rows[0]["本站价"].ObjToStr();
                    rexiao_img = dt_rexiao.Rows[0]["图片路径"].ObjToStr();
                    Log.WriteLog("页面：mySpace", "方法：goods", "rexiao_id：" + rexiao_id);
                }                
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    dt.Rows[a].ItemArray.CopyTo(obj, 0);
                    dt.Rows[a].ItemArray.CopyTo(obj2, 0);
                    test.Rows.Add(obj);
                    test2.Rows.Add(obj2);
                    int str = dt.Rows[a]["默认商品id"].ObjToInt(0);
                    if (str == 0)
                    {
                        test.Rows[a]["实际商品id"] = rexiao_id;
                        test.Rows[a]["实际商品品名"] = rexiao_name;
                        test.Rows[a]["本站价"] = rexiao_price;
                        test.Rows[a]["图片路径"] = rexiao_img; 
                    }
                    if (dt.Rows[a]["实际商品id"].ObjToInt(0) == 0 && !IsOffline)
                    {
                        test.Rows[a]["实际商品id"] = 0;
                        test.Rows[a]["实际商品品名"] = test.Rows[a]["默认商品品名"];
                        test.Rows[a]["本站价"] = test.Rows[a]["默认商品价格"];
                        test.Rows[a]["图片路径"] = test.Rows[a]["默认图片路径"]; 
                    }
                    else if (dt.Rows[a]["实际商品id"].ObjToInt(0) == 0 && IsOffline)
                    {
                        Log.WriteLog("页面：mySpace", "方法：goods", "a" + a);
                        test.Rows[a]["实际商品id"] = test.Rows[a]["默认商品id"];
                        test.Rows[a]["实际商品品名"] = test.Rows[a]["默认商品品名"];
                        test.Rows[a]["本站价"] = test.Rows[a]["默认商品价格"];
                        test.Rows[a]["图片路径"] = test.Rows[a]["默认图片路径"]; 
                    }
                   
                    if (string.IsNullOrEmpty(test.Rows[a]["图片路径"].ObjToStr()))
                    {
                        test.Rows[a]["图片路径"] = no_img;
                    }
                }
                Log.WriteLog("页面：mySpace", "方法：goods", "test数量:" + test.Rows.Count);
                Log.WriteLog("页面：mySpace", "方法：goods", "test:" + JsonConvert.SerializeObject(test));
                goods_list.DataSource = test;
                goods_list.DataBind();
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：mySpace", "方法：PageLoad", "异常信息：" + ex.Message);
                throw;
            }
            
        }
        protected string list_li(int goods_id, int weizhi, int kwid)
        {
            //try {
            //    for (int i = 0; i < test2.Rows.Count; i++)
            //    {
            //        int wz = test2.Rows[i]["位置"].ObjToInt(0);
            //        int kw_id = test2.Rows[i]["库位id"].ObjToInt(0);
            //        int now_good_id=test2.Rows[i]["实际商品id"].ObjToInt(0);
            //        if (wz == weizhi && kw_id == kwid)
            //        {
            //            if(now_good_id!=goods_id)
            //            {
            //                return "kong";
            //            }
            //            else
            //            {
            //                return "";
            //            }
            //        }
            //    }
            //}
            //catch { }
            if (goods_id == 0 && !IsOffline)
            {
                return "kong";
            }
            else
            {
                //tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("----------------", "myspace-link_detal", "../pages/detail.aspx?goods_id=" + goods_id + "&weizhi=" + weizhi + "&kwid=" + kwid + "");
                return "";
            }
        }
        protected string link_detail(int goods_id, int weizhi, int kwid)
        {
            if (goods_id == 0 && !IsOffline)
            {
                return "#";
            }
            else
            {
                //Log.WriteLog("页面：mySpace","方法：link_detail","url:"+"../pages/detail.aspx?goods_id=" + goods_id + "&weizhi=" + weizhi + "&kwid=" + kwid + "");
               // tdx.database.Common_Pay.WeiXinPay.Log.WriteLog("----------------", "myspace-link_detal", "../pages/detail.aspx?goods_id=" + goods_id + "&weizhi=" + weizhi + "&kwid=" + kwid + "");
                return "../pages/detail.aspx?goods_id=" + goods_id + "&weizhi=" + weizhi + "&kwid=" + kwid + "";
            }

        }

    }
}