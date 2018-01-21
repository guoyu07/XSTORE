using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database.Common_Pay.WeiXinPay;
using System.Data;

namespace Wx_NewWeb.Shop.pages
{
    public partial class stockDetail : System.Web.UI.Page
    {
        public static string manger_name = "";
        public static string cangkuid ="" ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hotel_area_h1.InnerText = Session["area_name"].ObjToStr();
              //  hotel_manger_area();
                hotel_list();
            }
        }
        //#region  读取经理所属区域 若有多个大区默认显示第一个
       
        //protected void hotel_manger_area()
        //{
        //   // manger_name = "111666";
        //    //经理openid 111666
        //    //     Response.Write("<Script Language=JavaScript>alert('"+hotel_id+"！');</Script>"); 
        //    // string sql = "select 用户权限 from WP_用户权限 where openid=111666 ";
        //    string user_id = "";
        //    if (Session["UserId"] != null)
        //    {

        //        user_id = Session["UserId"].ToString();
        //    }
        //    string sql = "select id,用户名 from WP_用户表 where id='" + user_id + "' ";

        //    DataTable dt_qylist = comfun.GetDataTableBySQL(sql);
        //    manger_name = dt_qylist.Rows[0]["用户名"].ObjToStr();

        //}
        //#endregion


        #region  读取所属区域下经理所管辖的酒店
        public static DataTable test = new DataTable();
        protected void hotel_list()
        {

            string user_id = "";
            if (Session["UserId"] != null)
            {
                user_id = Session["UserId"].ToString();
            }
            string sql = @"select WP_用户权限.id,用户id,仓库id,仓库名 from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id where 用户id='" + user_id + "' and wp_仓库表.isshow=1 ";
            DataTable dt_sql = comfun.GetDataTableBySQL(sql);
            string search = @"select sum(库存数) as 库存,仓库,库位id,真实姓名 from 视图在库表
left join WP_库位表 on WP_库位表.id=视图在库表.库位id
left join wp_用户权限 on wp_用户权限.仓库id=WP_库位表.仓库id
left join wp_用户表 on wp_用户权限.用户id=wp_用户表.id
where 视图在库表.库位id=75 and 角色id=1 and WP_库位表.isshow=1 and wp_用户表.isshow=1
group by 仓库,库位id,真实姓名";
            DataTable search_dt = comfun.GetDataTableBySQL(search);

            test = search_dt.Clone();//表结构赋值给test表
            object[] obj = new object[test.Columns.Count];
            for (int a_i = 0; a_i < dt_sql.Rows.Count; a_i++)
            {
                string sql_zt = @"select B.id as 库位id from WP_仓库表 A
left join WP_库位表 B on B.仓库id=A.id
left join WP_地区表 C on A.区域id=C.id
where A.IsShow=1 and  B.isShow=1 and B.库位名 like '%总台%' and A.id='" + dt_sql.Rows[a_i]["仓库id"] + "'";
                DataTable dt_zt = comfun.GetDataTableBySQL(sql_zt);
                if (dt_zt.Rows.Count > 0)
                {
                    int kwid = dt_zt.Rows[0]["库位id"].ObjToInt(0);
                    string dt_kc_ckm = @"select sum(库存数) as 库存,仓库,库位id,真实姓名 from 视图在库表
left join WP_库位表 on WP_库位表.id=视图在库表.库位id
left join wp_用户权限 on wp_用户权限.仓库id=WP_库位表.仓库id
left join wp_用户表 on wp_用户权限.用户id=wp_用户表.id
where 视图在库表.库位id='"+kwid+"' and 角色id=1 and WP_库位表.isshow=1 and wp_用户表.isshow=1 group by 仓库,库位id,真实姓名";
                    DataTable result = comfun.GetDataTableBySQL(dt_kc_ckm);//循环查询总库存 暂不细分产品 只计算总量
                    for (int cki = 0; cki < result.Rows.Count; cki++)
                    {
                        //循环插入test
                        result.Rows[cki].ItemArray.CopyTo(obj, 0);
                        test.Rows.Add(obj);
                        ViewState["test"] = test;
                    }
                }
                else
                {
                    Response.Write("<Script Language=JavaScript>alert(名下没有管辖酒店！');</Script>");
                }
            }
            //查询结果框架
//            string search = @"select sum(库存数) as 库存,仓库,库位id from 视图在库表
//where 库位id=75
//group by 仓库,库位id";
//            DataTable search_dt = comfun.GetDataTableBySQL(search);

//            test = search_dt.Clone();//表结构赋值给test表
//            object[] obj = new object[test.Columns.Count];
//            //数组分割
//            string[] ck = cangkuid.Split(new Char[] { ',' });
//            int  ck_num=ck.GetUpperBound(ck.Rank-1);
//            for (int i = 0; i < ck_num; i++)
//            {
//                string sql = @"select B.id as 库位id from WP_仓库表 A
//left join WP_库位表 B on B.仓库id=A.id
//left join WP_地区表 C on A.区域id=C.id
//where A.IsShow=1 and  B.isShow=1 and B.库位名 like '%总台%' and A.id='" + ck[i] + "'";
//                //读取总台库名下总台库id
//                DataTable dt_kw_id = comfun.GetDataTableBySQL(sql);
//                if (dt_kw_id.Rows.Count > 0)
//                {
//                    int kwid = dt_kw_id.Rows[0]["库位id"].ObjToInt(0);
//                    string dt_kc_ckm = @"select sum(库存数) as 库存,仓库,库位id from 视图在库表
//where 库位id='" + kwid + "' group by 仓库,库位id";
//                    DataTable result = comfun.GetDataTableBySQL(dt_kc_ckm);//循环查询总库存 暂不细分产品 只计算总量
//                    for (int cki = 0; cki < result.Rows.Count; cki++)
//                    {
//                        //循环插入test
//                        result.Rows[cki].ItemArray.CopyTo(obj, 0);
//                        test.Rows.Add(obj);
//                        ViewState["test"] = test;
//                    }
//                }
//                else
//                {
//                    Response.Write("<Script Language=JavaScript>alert(名下没有管辖酒店！');</Script>"); 
//                }

//            }
            stockDetail_rp.DataSource = (DataTable)ViewState["test"];
            stockDetail_rp.DataBind();
        }
        #endregion

        protected void chaxun_TextChanged(object sender, EventArgs e)
        {
             //ztk_id = Request["ztk_id"] != null ? Convert.ToInt32(Request["ztk_id"]) : 0;

            string search_txt = chaxun.Text.ObjToStr();
            DataView dv=new DataView(test);
            dv.RowFilter="仓库 like '%" + search_txt + "%'";

//            string sql = @"select sum(库存数) as 库存,仓库,库位id,视图在库表.品名,本站价,商品id from 视图在库表
//left join WP_商品表 on WP_商品表.id= 视图在库表.商品id
//where 库位id='" + ztk_id + "' and 视图在库表.品名 like '%" + search_txt + "%'  group by 仓库,库位id,视图在库表.品名,本站价,商品id";
//            DataTable dt = comfun.GetDataTableBySQL(sql);
            stockDetail_rp.DataSource = dv;
            stockDetail_rp.DataBind();
        }
    }
}