using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using DTcms.Common;
namespace Wx_NewWeb.Shop.Distributer
{
    public partial class PickUp : BasePage
    {
        string no_img = "/shop/img/no-image.jpg";//默认图片
        public string totalId;

        public string TotalId
        {
            get
            {
                if (string.IsNullOrEmpty(totalId))
                {
                    totalId = Request.QueryString["totalId"].ObjToStr().TrimEnd(',');
                }
                return totalId;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PageInit();
                //pickup();
            }
        }
        protected void PageInit()
        {
            try
            {
                if (UserInfo["角色id"].ObjToInt(0) == 1)
                {
                    foot_div.Visible = false;
                }
                var sql = string.Format(@"select count(b.id) as 数量,max(b.id) as 商品id, max(ISNULL(b.品名,'')) as 品名,max(ISNULL(c.图片路径,'{0}')) as 图片路径,max(ISNULL(b.编码,'')) AS 编码 from WP_箱子表 a 
left join WP_商品表 b on a.默认商品id = b.id 
left join WP_商品图片表 c on b.编码 = c.商品编号
left join WP_库位表 d on a.库位id = d.id
where a.库位id in({1}) and 默认商品id != 0 and d.库位名 not like '%总台%' and a.IsShow = 1 and d.IsShow = 1 and b.IsShow = 1
group by b.id", no_img, TotalId);
                var dt = comfun.GetDataTableBySQL(sql);
                Rp_pickup.DataSource = dt;
                Rp_pickup.DataBind();
                if (dt.Rows.Count > 0)
                {
                    pickUp.Visible = true;
                    noTask.Visible = false;
                }
                else
                {
                    pickUp.Visible = false;
                    noTask.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：PickUp", "方法：PageInit", "异常信息：" + ex.Message);
                RedirectError(ex.Message);
            }
        }
//        #region  取货列表，同一酒店下相同商品已合并
//        public static int a = 0;
//        protected void pickup()
//        {
//            //读取热销商品
//            string rexiao = @"select 商品id,视图出库表.品名,图片路径,isnull(Max(编号new),'') as 编号 from 视图出库表 
//left join wp_商品表 on 视图出库表.商品id=wp_商品表.id
//left join WP_商品图片表 on  wp_商品表.编号=wp_商品图片表.商品编号
// group by 商品id,视图出库表.品名,图片路径 order by count(商品id) desc,max(操作日期) desc  ";
//            DataTable dt_rexiao = comfun.GetDataTableBySQL(rexiao);
//            string rexiao_id = dt_rexiao.Rows[0]["商品id"].ObjToStr();
//            string rexiao_name = dt_rexiao.Rows[0]["品名"].ObjToStr();
//            string rexiao_img = dt_rexiao.Rows[0]["图片路径"].ObjToStr();
//            //string rexiao_name = "select 品名 from WP_商品表 where id='" + rexiao_id + "'";
//            //DataTable dt_rexiao_name = comfun.GetDataTableBySQL(rexiao_name);
//            //读取负责酒店
//            #region
//            string sql = "select 仓库id  from WP_用户权限 where 用户id='" + UserId + "' ";
//            DataTable dt = comfun.GetDataTableBySQL(sql);
//            //   string Jurisdiction = dt.Rows[0]["用户权限"].ObjToStr();
//            //    string[] J = Jurisdiction.Split(new Char[] { ',' });
//            //查询结果框架
//            string search = @"select 默认商品id,图片路径, count(*) as 数量,品名,库位名,isnull(Max(编号new),'') as 编号  from  WP_箱子表 
//left join WP_商品表 on WP_箱子表.默认商品id=WP_商品表.id 
//left join WP_库位表 on WP_箱子表.库位id=WP_库位表.id
//left join wp_商品图片表 on wp_商品图片表.商品编号=WP_商品表.编号
//where WP_箱子表.IsShow=1 and 实际商品id=0 group by 图片路径,默认商品id,品名,库位名";
//            DataTable search_dt = comfun.GetDataTableBySQL(search);
//            DataTable test = new DataTable();
//            test = search_dt.Clone();
//            object[] obj = new object[test.Columns.Count];
//            //复制表框架
//            string kw_where = "1=1";
//            //  int new_J = J.GetUpperBound(J.Rank - 1);
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                int ck_id = Convert.ToInt32(dt.Rows[i]["仓库id"]);//酒店id
//                //查询酒店下所有库位  即房间除总仓外
//                string sql_Jurisdiction = "select id as 房间id,仓库id,库位名,箱子号,箱子MAC,IsShow   from WP_库位表 where IsShow=1 and 库位名  not like '%总台%' and 仓库id='" + ck_id + "'";
//                DataTable dt_J = comfun.GetDataTableBySQL(sql_Jurisdiction);
//                for (int r = 0; r < dt_J.Rows.Count; r++)
//                {
//                    // 遍历整个酒店下所有房间 筛选出 实际商品为空的位置
//                    if (kw_where == "1=1")
//                    {
//                        kw_where = " 库位id='" + dt_J.Rows[r]["房间id"].ObjToInt(0) + "'";
//                        a = 3;
//                    }
//                    else
//                    {
//                        kw_where += "or 库位id='" + dt_J.Rows[r]["房间id"].ObjToInt(0) + "'";
//                    }
//                }
//            }
//            #endregion
//            //查询需补货的箱子中 是否有默认商品id 若没有 则推荐热销
//            string sql_kw = @"select 默认商品id,图片路径, count(*) as 数量,品名,isnull(Max(编号new),'') as 编号,库位名  
//from  WP_箱子表 
//left join WP_商品表 on WP_箱子表.默认商品id=WP_商品表.id 
//left join WP_库位表 on WP_箱子表.库位id=WP_库位表.id
//left join wp_商品图片表 on wp_商品图片表.商品编号=WP_商品表.编号
//where WP_箱子表.IsShow=1 and 实际商品id=0 and (" + kw_where + ") group by 默认商品id,图片路径,品名,库位名";
//            DataTable dt_box = comfun.GetDataTableBySQL(sql_kw);
//            for (int b = 0; b < dt_box.Rows.Count; b++)
//            {
//                dt_box.Rows[b].ItemArray.CopyTo(obj, 0);
//                test.Rows.Add(obj);
//                ViewState["test"] = test;
//            }

//            int rexiao_row = 0;
//            int aa = 0;
//            int[] a_int = new int[] { };
//            List<int> a_list = a_int.ToList();
//            //定义一个List<int>集合
//            for (int mr = 0; mr < test.Rows.Count; mr++)//查询是否有默认商品 若无 则对test 进行合并计算
//            {
//                string mr_id = test.Rows[mr]["默认商品id"].ObjToStr();

//                if (mr_id.ObjToInt(0) == 0)
//                {
//                    if (aa == 0)
//                    {
//                        test.Rows[mr]["默认商品id"] = rexiao_id;
//                        test.Rows[mr]["品名"] = rexiao_name;
//                        test.Rows[mr]["图片路径"] = rexiao_img;
//                        aa = 3;
//                        rexiao_row = mr;
//                    }
//                    else
//                    {
//                        int num = test.Rows[rexiao_row]["数量"].ObjToInt(0) + test.Rows[mr]["数量"].ObjToInt(0);
//                        // test.Rows.RemoveAt(mr);
//                        a_list.Add(mr);
//                        // removerows = InsertNumber(removerows, mr);
//                        test.Rows[rexiao_row]["数量"] = num;
//                    }
//                }
//            }
//            a_int = a_list.ToArray();//将list 重新转换成数组
//            for (int listi = a_int.Length; listi > 0; listi--)
//            {
//                test.Rows.RemoveAt(a_int[listi - 1]);
//            }
//            for (int img_num = 0; img_num < test.Rows.Count; img_num++)
//            {
//                if (string.IsNullOrEmpty(test.Rows[img_num]["图片路径"].ObjToStr()))
//                {
//                    test.Rows[img_num]["图片路径"] = no_img;
//                }
//            }
//            Rp_pickup.DataSource = test;
//            Rp_pickup.DataBind();
//        }
//        #endregion
        protected void markSure_OnServerClick(object sender, EventArgs e)
        {
            var begin_exsql = " Begin Tran ";
            var exsql = string.Empty;
            var end_sql = @" If @@ERROR>0
                                Rollback Tran  
                            Else
                                Commit Tran
                            Go";
            var list = TotalId.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(o=>o.ObjToInt(0)).ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                exsql += string.Format(@" insert into WP_取货记录表(用户id,补货的房间id,是否补货完成) values ({0},{1},{2})", UserId,
                    list[i], 0);
            }
            Log.WriteLog("页面：PickUp", "方法：markSure_OnServerClick", "sql：" + begin_exsql + exsql + end_sql);
            var b = SqlDataHelper.ExecuteCommand(begin_exsql + exsql + end_sql);
            if (b != 0)
            {
                markSure.Visible = false;
                Response.Write(string.Format("<script>alert('取货成功');window.location.href='../pages/roomsPickUp.aspx'</script>"));

            }
            else
            {
                Response.Write("<script>alert('取货失败')</script>");
            }

        }
    }
}