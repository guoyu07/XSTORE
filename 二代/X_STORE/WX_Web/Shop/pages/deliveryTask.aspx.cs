using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using DTcms.Common;

namespace Wx_NewWeb.Shop.pages
{
    public partial class deliveryTask : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        #region 读取未投放记录
        protected void PageInit()
        {
            try
            {
                string bind_sql = string.Format(@"SELECT * FROM 视图投放记录  WHERE 投放仓库id = {0} AND 是否投放 = 0 AND IsShow = 1 ORDER BY 时间 DESC",HotelInfo["id"].ObjToInt(0));
                DataTable bind_dt = comfun.GetDataTableBySQL(bind_sql);
                //            DataTable test = new DataTable();
                //            test = search_dt.Clone();
                //            object[] obj = new object[test.Columns.Count];
                //            //复制表框架
                //            for (int i = 0; i < dt.Rows.Count; i++)
                //            {
                //                int ck_id = Convert.ToInt32(dt.Rows[i]["仓库id"]);//酒店id
                //                // string sql_hotels = "select 酒店全称,id,地址  from WP_酒店表 where id='" + hotel_id + "'";
                //                string sql_notes = @"select WP_投放任务.id,仓库名,酒店简称,库位名,时间 from WP_投放任务
                //left join WP_酒店表 on WP_酒店表.id=WP_投放任务.投放酒店id
                //left join WP_仓库表 on WP_仓库表.id=WP_投放任务.投放仓库id
                //left join WP_库位表 on WP_库位表.id=WP_投放任务.投放库位id
                //where WP_投放任务.IsShow=1 and 投放仓库id='" + ck_id + "' and 是否投放=0 ";
                //               DataTable dt_sql_notes = comfun.GetDataTableBySQL(sql_notes);
                //                if (dt_sql_notes.Rows.Count > 0)
                //                {
                //                    for (int a = 0; a < dt_sql_notes.Rows.Count;a++ )
                //                    {
                //                        dt_sql_notes.Rows[a].ItemArray.CopyTo(obj, 0);
                //                        test.Rows.Add(obj);//循环插入test 将结果
                //                    }
                //                }

                //            }
                task_rp.DataSource = bind_dt;
                task_rp.DataBind();
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：deliveryTask", "方法：PageInit", "异常：" + ex.Message);
                RedirectError(ex.Message);
            }
           
        }
        #endregion
    }
}