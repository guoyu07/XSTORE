using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using DTcms.DBUtility;
using DTcms.Common;
using DTcms.Model;
using System.Web.UI.HtmlControls;

namespace tdx.memb.man.Shop.GoodsManage
{
    public partial class GropshopList : System.Web.UI.Page
    {
        DTcms.BLL.WP_商品表 spbll = new DTcms.BLL.WP_商品表();
        protected internal siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        public static int td;

        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                sousuo();
            }

        }
        #endregion

        #region 4.0 删除 +void btnDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList1.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    string del = "delete  from  WP_FreightMain where   id=" + id;
                    comfun.DelbySQL(del);
                    //MessageBox.Show(this, "删除成功！");
                }
            }
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='FerightList.aspx'", true);
        }
        #endregion

        #region 前台判断是否显示
        /// <summary>
        /// 前台判断是否显示
        /// </summary>
        /// <returns></returns>
        public string isshow()
        {
            DTcms.BLL.manager dtbll = new DTcms.BLL.manager();

            string s = String.Empty;
            try
            {
                int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ToString()) ? "-1" : Session["dtid"].ToString());

                if (dtid > 0)
                {
                    DataTable dtdt = dtbll.GetList(0, " id=" + dtid, "id").Tables[0];
                    if (dtdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtdt.Rows.Count; i++)
                        {
                            if (dtdt.Rows[i]["user_name"].ToString() == "admin")
                            {

                                s = " <th width=\"6%\">当前状态</th>";

                            }

                        }
                    }
                }

            }
            catch (Exception)
            {

                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();


            }

            return s;

        }
        #endregion

        #region 搜索  2015.7.12
        private void sousuo()
        {
            string sql = "select 酒店名称,地区,电话,总数,业绩,区域经理,酒店经理 from 酒店_区域";
            DataTable dt = comfun.GetDataTableBySQL(sql);

            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.rptList1.DataSource = pdsList;
            this.rptList1.DataBind();
        }
        #endregion
        //分页改变时
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
    }
}




