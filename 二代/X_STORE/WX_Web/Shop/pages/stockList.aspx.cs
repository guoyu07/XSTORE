using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;

namespace Wx_NewWeb.Shop.pages
{
    public partial class stockList : System.Web.UI.Page
    {
        public static int ztk_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ztk_id = Request["ztk_id"] != null ? Convert.ToInt32(Request["ztk_id"]) : 0;
                if (ztk_id==0)
                {
                    totalkclist();
                }
                else
                {
                    jdkclist();
                }
            }
        }
        #region 加载酒店库存
        protected void jdkclist()
        {
            ztk_id = Request["ztk_id"] != null ? Convert.ToInt32(Request["ztk_id"]) : 0;
            string sql = @"select sum(库存数) as 库存,仓库,库位id,视图在库表.品名,本站价,商品id,图片路径 from 视图在库表
left join WP_商品表 on WP_商品表.id= 视图在库表.商品id
left join wp_商品图片表 on Wp_商品表.编号=wp_商品图片表.商品编号
where 库位id='"+ztk_id+"' group by 仓库,库位id,视图在库表.品名,本站价,商品id,图片路径";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            totalstock_rp.DataSource=dt;
            totalstock_rp.DataBind();
        }
        #endregion
        #region 加载区域下总库存
        protected void totalkclist()
        {
            string user_id = "";
            if (Session["UserId"] != null)
            {

                user_id = Session["UserId"].ToString();
            }
            string qy_sql = @"select WP_用户权限.id,用户id,仓库名,库位名,WP_库位表.id as 库位id
from WP_用户权限
left join WP_仓库表 on wp_用户权限.仓库id=WP_仓库表.id 
left join WP_库位表 on WP_库位表.仓库id=WP_仓库表.id
where 库位名 like '%总台%' and 用户id='" + user_id + "'";
            DataTable dt_kw = comfun.GetDataTableBySQL(qy_sql);
            //表框架
            string search = @"select sum(库存数) as 库存,仓库,库位id,视图在库表.品名,本站价,商品id,图片路径 from 视图在库表
left join WP_商品表 on WP_商品表.id= 视图在库表.商品id
left join wp_商品图片表 on wp_商品表.编号=WP_商品图片表.商品编号
where 库位id='75' group by 仓库,库位id,视图在库表.品名,本站价,商品id,图片路径";
            DataTable search_dt = comfun.GetDataTableBySQL(search);
            DataTable test = new DataTable();
            test = search_dt.Clone();
            object[] obj = new object[test.Columns.Count];
            for (int a_i = 0; a_i < dt_kw.Rows.Count; a_i++)
            {
                if (a_i == 0)
                {
                    string sql = @"select sum(库存数) as 库存,仓库,库位id,视图在库表.品名,本站价,商品id,图片路径 from 视图在库表
left join WP_商品表 on WP_商品表.id= 视图在库表.商品id
left join wp_商品图片表 on wp_商品表.编号=WP_商品图片表.商品编号
where 库位id='" + dt_kw.Rows[a_i]["库位id"] + "' group by 仓库,库位id,视图在库表.品名,本站价,商品id,图片路径";
                    DataTable dt_sql = comfun.GetDataTableBySQL(sql);
                    if (dt_sql.Rows.Count > 0)
                    {
                        for (int b_i = 0; b_i < dt_sql.Rows.Count; b_i++)
                        {
                            dt_sql.Rows[b_i].ItemArray.CopyTo(obj, 0);
                            test.Rows.Add(obj);//循环插入test 将结果
                        }
                    }
                }
                else
                {
                    string sql = @"select sum(库存数) as 库存,仓库,库位id,视图在库表.品名,本站价,商品id,图片路径 from 视图在库表
left join WP_商品表 on WP_商品表.id= 视图在库表.商品id
left join wp_商品图片表 on wp_商品表.编号=WP_商品图片表.商品编号
where 库位id='" + dt_kw.Rows[a_i]["库位id"] + "' group by 仓库,库位id,视图在库表.品名,本站价,商品id,图片路径";
                    DataTable dt_sql = comfun.GetDataTableBySQL(sql);
                    if (dt_sql.Rows.Count > 0)
                    {
                        for (int c_i = 0; c_i < dt_sql.Rows.Count; c_i++)
                        {
                            int sp_id = dt_sql.Rows[c_i]["商品id"].ObjToInt(0);
                          //  string sp_name = dt_sql.Rows[c_i]["品名"].ObjToStr();
                            for (int d_i = 0; d_i < test.Rows.Count; d_i++)
                            {
                                int sp_id2 = test.Rows[d_i]["商品id"].ObjToInt(0);
                              //  string sp_name2 = test.Rows[d_i]["品名"].ObjToStr();
                                if (sp_id != sp_id2)
                                {
                                    break;
                                }
                                else
                                {
                                    test.Rows[d_i]["库存"] = test.Rows[d_i]["库存"].ObjToInt(0) + dt_sql.Rows[c_i]["库存"].ObjToInt(0);
                                    //for (int e_i = 0; e_i < test.Rows.Count; e_i++)
                                    //{
                                    //    if(sp_id2!=(test.Rows[e_i]["商品id"].ObjToInt(0)))
                                    //    {
                                    //        dt_sql.Rows[c_i].ItemArray.CopyTo(obj, 0);
                                    //        test.Rows.Add(obj);
                                    //    }
                                    //}

                                }
                            }
                        }
                    }
                }
            }

//            int qyid_id = Request["qyid"] != null ? Convert.ToInt32(Request["qyid"]) : 0;
//            string sql_zc = @"select A.id as 酒店id,A.酒店全称,A.区域id,c.库位名,E.品名,sum(D.数量) as 库存,e.本站价,D.商品id
//from WP_酒店表 A
//left join WP_仓库表 B on B.酒店id=A.id
//left join WP_库位表 C on C.仓库id=B.id
//left join WP_入库表 D on D.库位id=C.id
//left join WP_商品表 E on D.商品id=E.id
//where A.区域id='" + qyid_id + "' and A.isshow=1 and B.IsShow=1 and C.IsShow=1 and 库位名 like '%总台%' and 数量 is not null group by A.id,A.酒店全称,A.区域id,c.库位名,E.品名,e.本站价,D.商品id order by D.商品id asc";
//            DataTable zc = comfun.GetDataTableBySQL(sql_zc);
            totalstock_rp.DataSource = test;
            totalstock_rp.DataBind();

            //string qy_sql = @"select * from WP_酒店表 where 区域id='"+qyid_id+"' and isshow=1";
            //DataTable dt_qy_sql = comfun.GetDataTableBySQL(qy_sql);
            //int test_about = 0;
            //string where = "";
            //for (int a = 0; a < dt_qy_sql.Rows.Count ; a++)
            //{
                
            //    //if (test_a == 0)
            //    //{
            //    //    where+="";
            //    //    test_a = 333;
            //    //}
            //}




           // string sql = @"select sum(库存数) as 库存,仓库,库位id,视图在库表.品名,本站价,商品id from 视图在库表
//left join WP_商品表 on WP_商品表.id= 视图在库表.商品id
//where 库位id='" + ztk_id + "' group by 仓库,库位id,视图在库表.品名,本站价,商品id";
            //DataTable dt = comfun.GetDataTableBySQL(sql);
            //totalstock_rp.DataSource = dt;
            //totalstock_rp.DataBind();
        }
        #endregion
        #region 搜索功能
        protected void search_TextChanged(object sender, EventArgs e)
        {
            ztk_id = Request["ztk_id"] != null ? Convert.ToInt32(Request["ztk_id"]) : 0;
            if (ztk_id==0)
            {
                string search_txt = chaxun.Text.ObjToStr();
                int qyid_id = Request["qyid"] != null ? Convert.ToInt32(Request["qyid"]) : 0;
                string sql_zc = @"select A.id as 酒店id,A.酒店全称,A.区域id,c.库位名,E.品名,sum(D.数量) as 库存,e.本站价,D.商品id,f.图片路径
from WP_酒店表 A
left join WP_仓库表 B on B.酒店id=A.id
left join WP_库位表 C on C.仓库id=B.id
left join WP_入库表 D on D.库位id=C.id
left join WP_商品表 E on D.商品id=E.id
left join wp_商品图片表 F on F.商品编号=e.编号
where A.区域id='" + qyid_id + "'and E.品名 like '%" + search_txt + "%' and A.isshow=1 and B.IsShow=1 and C.IsShow=1 and 库位名 like '%总台%' and 数量 is not null group by A.id,A.酒店全称,A.区域id,c.库位名,E.品名,e.本站价,D.商品id,f.图片路径  order by D.商品id asc";
                DataTable zc = comfun.GetDataTableBySQL(sql_zc);
                totalstock_rp.DataSource = zc;
                totalstock_rp.DataBind();
            }
            else
            {
                string search_txt = chaxun.Text.ObjToStr();
                string sql = @"select sum(库存数) as 库存,仓库,库位id,视图在库表.品名,本站价,商品id,图片路径 from 视图在库表
left join WP_商品表 on WP_商品表.id= 视图在库表.商品id
left join wp_商品图片表 on Wp_商品表.编号=wp_商品图片表.商品编号
where 库位id='" + ztk_id + "' and 视图在库表.品名 like '%" + search_txt + "%'  group by 仓库,库位id,视图在库表.品名,本站价,商品id,图片路径 ";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                totalstock_rp.DataSource = dt;
                totalstock_rp.DataBind();
            }

        }
        #endregion
    }
}