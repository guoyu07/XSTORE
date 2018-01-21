using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Box
{
    public partial class BoxGoods : System.Web.UI.Page
    {
        public string _where = " ";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ClassList("");//分页数据
                //ddl_store_val();
            }
        }


        #region 读取分页数据2017.4.21
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="_where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        protected DataTable ClassList(string condition)
        {
            //仓库id，仓库，酒店id,酒店，库位,默认商品,实际商品，箱子id,箱子mac
            string sql = " select  酒店id,酒店全称,仓库id,仓库,库位id,库位,箱子id,mac,位置 from 视图库位表 where 酒店IsShow=1 and 仓库IsShow=1 and 库位IsShow=1 and 箱子IsShow=1 " + condition;
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                //增加几个列
                dt.Columns.Add("默认商品", typeof(string));
                dt.Columns.Add("实际商品", typeof(string));
                DataTable dt1;
                DataTable dt2;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql1 = @"select 品名 as 默认商品 from WP_箱子表 A left join WP_商品表 B on A.默认商品id=B.id where 1=1 and 库位id=" + dt.Rows[i]["库位id"] + " and 位置=" + dt.Rows[i]["位置"];
                    string sql2 = @"select 品名 as 实际商品 from WP_箱子表 A left join WP_商品表 B on A.实际商品id=B.id where 1=1 and 库位id=" + dt.Rows[i]["库位id"] + " and 位置=" + dt.Rows[i]["位置"];
                    dt1 = comfun.GetDataTableBySQL(sql1);
                    dt2 = comfun.GetDataTableBySQL(sql2);
                    if (dt1.Rows.Count > 0)
                    {
                        dt.Rows[i]["默认商品"] = dt1.Rows[0]["默认商品"];

                    }
                    else
                    {
                        dt.Rows[i]["默认商品"] = " ";
                    }
                    if (dt2.Rows.Count > 0)
                    {
                        dt.Rows[i]["实际商品"] = dt2.Rows[0]["实际商品"];
                    }
                    else
                    {
                        dt.Rows[i]["实际商品"] = " ";
                    }
                }

            }

            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.sptList1.DataSource = pdsList;
            this.sptList1.DataBind();
            return dt;

        }
        #endregion

        #region Excel导出功能
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void LBtn_Export_Click(object sender, EventArgs e)
        //{
        //    string sql = "";

        //    DataTable dt1 = comfun.GetDataTableBySQL(sql);

        //    if (dt1.Rows.Count > 0)
        //    {
        //        DTcms.Common.Excel.DataTable4Excel(dt1, "仓位表");
        //    }
        //    else
        //        Response.Write("<script>alert('导出失败，没有数据')</script>");

        //}
        #endregion

        /// <summary>
        /// 点击搜索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected void sousuo() {
            //获取几个框的值
            string name_value = ddlA_is_name.SelectedValue.ToString();
            string txt_name = this.txt_mingcheng.Text.Trim();
            string txt_mac = this.txt_mac.Text.Trim();
            // string txt_warehouse = ddlA_is_self.Text.ToString();
            //判断是否为空
            if (name_value != "0" && txt_name != "")
            {
                switch (name_value)      //1=酒店    2=仓库   3=仓位
                {
                    case "1":
                        _where += " and 酒店全称 like '%" + txt_name + "%'";
                        break;
                    case "2":
                        _where += " and 仓库 like '%" + txt_name + "%'";
                        break;
                    case "3":
                        _where += " and 仓位 like '%" + txt_name + "%'";
                        break;
                    default:
                        break;
                }
            }
            else if (txt_name != "")
            {
                _where += " and 酒店全称 like '%" + txt_name + "%'";
            }
            if (txt_mac != "")
            {
                _where += " and mac like '%" + txt_mac + "%'";
            }
            ClassList(_where);
        }

        #region 4.0 删除 +void btnDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < sptList1.Items.Count; i++)
            {
                string box_id = ((HiddenField)sptList1.Items[i].FindControl("hidId")).Value;
                CheckBox cb = (CheckBox)sptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {

                    DbHelperSQL.GetSingle(" Update WP_箱子表 set IsShow=0 where id=" + box_id);

                    MessageBox.Show(this, "删除成功！");

                }
            }
            //用户列表显示
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='BoxGoods.aspx'", true);
        }
        #endregion

        #region  分页值改变时
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
        #endregion

    }
}