using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;



namespace Wx_NewWeb.Shop.OperateManager
{
    public partial class home : System.Web.UI.Page
    {
        public static int area_id = 0;
        public string user_img = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string user_id = "";
                if (Session["UserId"] != null)
                {

                    user_id = Session["UserId"].ToString();
                }
              //  user_id = "16";
                Session["UserId"] = user_id;
               // user_id_span.InnerText = user_id;
                string sql_user_img = @"select wx头像 from wp_会员表 where openid='" + Session["OpenId"].ObjToStr() + "'";
                DataTable user_dt = comfun.GetDataTableBySQL(sql_user_img);
                user_img = user_dt.Rows[0]["wx头像"].ObjToStr();

                string sql = "select WP_用户权限.id as id,用户id,仓库id,真实姓名 from WP_用户权限 left join wp_用户表 on wp_用户表.id=wp_用户权限.用户id where 用户id='" + user_id + "'";
                DataTable dt_qylist = comfun.GetDataTableBySQL(sql);
                #region   //表框架
                string search = @"select 酒店全称,名称,b.区域id from wp_仓库表  A
left join wp_酒店表 B on A.酒店id=b.id
left join wp_地区表 c on c.id=b.区域id
where A.IsShow=1 and b.isshow=1 and A.id=79";
                DataTable search_dt = comfun.GetDataTableBySQL(search);
                DataTable test = new DataTable();
                test = search_dt.Clone();        
                object[] obj = new object[test.Columns.Count];
                //框架结束
                #endregion
                for (int i = 0; i < dt_qylist.Rows.Count; i++)
                {
                    string sql_hotels = @"select 酒店全称,名称,b.区域id from wp_仓库表  A
left join wp_酒店表 B on A.酒店id=b.id
left join wp_地区表 c on c.id=b.区域id
where A.IsShow=1 and b.isshow=1 and A.id='" + dt_qylist.Rows[i]["仓库id"].ObjToStr() + "'";
                    DataTable dt_hotels = comfun.GetDataTableBySQL(sql_hotels);
                    if(dt_hotels.Rows.Count>0){
                        for (int b = 0; b < dt_hotels.Rows.Count; b++)
                        {
                            dt_hotels.Rows[b].ItemArray.CopyTo(obj, 0);
                            test.Rows.Add(obj);
                        }
                        
                    }
                }
                if (test.Rows.Count > 0)
                {
                    user_name_p.InnerText = dt_qylist.Rows[0]["真实姓名"].ObjToStr();

                    hotel_span.InnerText = test.Rows[0]["酒店全称"].ObjToStr();
                    area_id = test.Rows[0]["区域id"].ObjToInt(0);
                    Session["area_name"] = test.Rows[0]["酒店全称"].ObjToStr(); 
                }
                else
                {
                    user_name_p.InnerText = "暂无管辖范围,暂定为无锡市";
                    hotel_span.InnerText = "暂无";
                    area_id = 4;//
                    Session["area_name"] = "暂无管辖范围,暂定为无锡市";
                }
             
            }
        }
    }
}