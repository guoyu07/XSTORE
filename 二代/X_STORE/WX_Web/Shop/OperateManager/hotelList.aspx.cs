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
    public partial class hotelList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hotelabout();
            }
        }

        public static DataTable test = new DataTable();
        #region 读取酒店名称，房间数，配送员数量
        protected void hotelabout()
        {
            //通过openid 查询权限
            //oNzt30u1MVqtY77iTr1FF3DixDxE///1
            //string qx_sql = "select 区域经理 from WP_用户表 where openid='oNzt30u1MVqtY77iTr1FF3DixDxE'";
            //DataTable dt_qx = comfun.GetDataTableBySQL(qx_sql);
            //if (Convert.ToBoolean(dt_qx.Rows[0]["区域经理"]) == true)
            //{
            //    //确认为经理，查询其所管理的区域下所有酒店 由于表关系
            //    string 
            // //   area_lbl.Text=
            //}.
            string user_id = "";
            if (Session["UserId"] != null)
            {

                user_id = Session["UserId"].ToString();
            }
         //   user_id = "16";
            string qy_sql = "select 仓库id from WP_用户权限 where 用户id='"+user_id+"'";
            DataTable dt_qylist = comfun.GetDataTableBySQL(qy_sql);
            //如果有超过1个省 则选择第一个省
            string sql_show = @"select WP_地区表.名称,WP_地区表.id
from WP_仓库表
left join wp_酒店表 on wp_酒店表.id=wp_仓库表.酒店id
left join WP_地区表 on WP_地区表.id=wp_酒店表.区域id 
where WP_仓库表.id ='"+dt_qylist.Rows[0]["仓库id"].ObjToStr()+"' and WP_仓库表.IsShow=1 and wp_酒店表.IsShow=1 ";
            DataTable dt_show = comfun.GetDataTableBySQL(sql_show);
            area_lbl.Text = dt_show.Rows[0]["名称"].ToString();
            //查询结果框架
//            string search = @"select count(库位名) as 房间数量,酒店全称 from WP_库位表
//left join WP_仓库表 on WP_库位表.仓库id=WP_仓库表.id
//left join WP_酒店表 on WP_酒店表.id=WP_仓库表.酒店id
//group by 酒店全称";
            string search = @"select count(A.id) as rooms  ,count(B.id) as members,仓库名,c.id,Logo from WP_库位表 A
left join WP_用户权限 B on b.仓库id=A.id
left join wp_仓库表 c on c.id=a.仓库id
left join wp_用户表 d on d.id=b.用户id
left join wp_酒店表 e on e.Id=c.酒店id
where c.id='79' group by 仓库名,c.id,Logo";
            DataTable search_dt = comfun.GetDataTableBySQL(search);
            test = search_dt.Clone();
            object[] obj = new object[test.Columns.Count];
            //复制表框架
            //通过权限查旗下酒店
          
          //  string hotel_sql = "select id,酒店全称,酒店简称,Logo,区域id,地址 from WP_酒店表 where isshow=1 and 区域id='" + qy[0] + "' ";
          //  DataTable dt_hotel_sql = comfun.GetDataTableBySQL(hotel_sql);
            for (int i = 0; i < dt_qylist.Rows.Count; i++)
            {
                //模糊数据插入
                string sql_list = @"select count(A.id) as rooms  ,count(B.id) as members,仓库名,c.id,Logo from WP_库位表 A
left join WP_用户权限 B on b.仓库id=A.id
left join wp_仓库表 c on c.id=a.仓库id
left join wp_用户表 d on d.id=b.用户id
left join wp_酒店表 e on e.Id=c.酒店id
where c.id='" + dt_qylist.Rows[i]["仓库id"].ObjToStr() + "' group by 仓库名,c.id,Logo";
                DataTable dt_list = comfun.GetDataTableBySQL(sql_list);
                for (int b = 0; b < dt_list.Rows.Count; b++)
                {
                    dt_list.Rows[b].ItemArray.CopyTo(obj, 0);
                    test.Rows.Add(obj);
                   // ViewState["test"] = test;
                }
                //对模糊数据进行校正
                string psy_nums = @"select count(B.id) as members,仓库名 from WP_库位表 A
left join WP_用户权限 B on b.仓库id=A.id
left join wp_仓库表 c on c.id=a.仓库id
left join wp_用户表 d on d.id=b.用户id
where A.id='" + dt_qylist.Rows[i]["仓库id"].ObjToStr() + "' and d.角色id=3  and  A.isshow=1 and C.isshow=1 and d.isshow=1 group by 仓库名";
                string rooms = @"select count(A.id) as rooms from WP_库位表 A
left join WP_用户权限 B on b.仓库id=A.id
left join wp_仓库表 c on c.id=a.仓库id
where A.仓库id='" + dt_qylist.Rows[i]["仓库id"].ObjToStr() + "' and A.isshow=1 and C.isshow=1";
                DataTable dt_psy_nums = comfun.GetDataTableBySQL(psy_nums);
                DataTable dt_rooms = comfun.GetDataTableBySQL(rooms);
                if (dt_rooms.Rows.Count > 0)
                {
                    test.Rows[i]["rooms"] = dt_rooms.Rows[0]["rooms"].ObjToInt(0); 

                }
                else
                {
                    test.Rows[i]["rooms"] = 0;
                }
                if (dt_psy_nums.Rows.Count > 0)
                {
                    test.Rows[i]["members"] = dt_psy_nums.Rows[0]["members"].ObjToInt(0);
                    test.Rows[i]["仓库名"] = dt_psy_nums.Rows[0]["仓库名"].ObjToStr();
                }
                else
                {
                    test.Rows[i]["members"] = 0;
                    //test.Rows[i]["仓库名"] = dt_psy_nums.Rows[0]["仓库名"].ObjToStr();
                }
          
                     
            }
            ViewState["test"] = test;

            hotel_list.DataSource = (DataTable)ViewState["test"];

            hotel_list.DataBind();








            //area_span.InnerText = dt_show.Rows[0]["名称"].ToString();

            //查询结果框架
            //  string search = @"select id,酒店全称,酒店简称,Logo,区域id,地址 from WP_酒店表";
            //  DataTable search_dt = comfun.GetDataTableBySQL(search);
            //  DataTable test = new DataTable();
            //  test = search_dt.Clone();
            //  object[] obj = new object[test.Columns.Count];
            //  //复制表框架
            ////  int new_qy = qy.GetUpperBound(qy.Rank - 1) + 1;
            //  int new_qy = qy.GetUpperBound(0) + 1;
            //  for (int i = 0; i < new_qy; i++)
            //  {
            //      Response.Write("<Script Language=JavaScript>console.log('" + qy[i] + "！');</Script>");
            //      string hotel_sql = "select id,酒店全称,酒店简称,Logo,区域id,地址 from WP_酒店表 where isshow=1 and 区域id='"+qy[i]+"' ";
            //      DataTable dt_hotel_sql = comfun.GetDataTableBySQL(hotel_sql);
            //       for (int r = 0; r < dt_hotel_sql.Rows.Count; r++)
            //  {
            //       dt_hotel_sql.Rows[r].ItemArray.CopyTo(obj, 0);
            //          test.Rows.Add(obj);
            //          ViewState["test"] = test;
            //  }

        }
        #endregion

        protected void hotel_search_TextChanged(object sender, EventArgs e)
        {

            string search_txt = hotel_search.Text.ObjToStr();
            DataView dv = new DataView(test);
            dv.RowFilter = "仓库名 like '%" + search_txt + "%'";
            hotel_list.DataSource = dv;
            hotel_list.DataBind();
        }
    }
}