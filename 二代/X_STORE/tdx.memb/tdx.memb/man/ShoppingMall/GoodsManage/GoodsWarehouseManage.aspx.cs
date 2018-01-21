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
using System.Text;
using System.Collections;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class GoodsWarehouseManage : System.Web.UI.Page
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
            string sql = " select  酒店id,酒店全称,仓库id,仓库,库位id,库位 from 视图库位表 where 1=1 " + condition;
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if(dt.Rows.Count>0){
                //增加几个列
                dt.Columns.Add("默认商品", typeof(string));
                dt.Columns.Add("箱子id", typeof(string));
                dt.Columns.Add("箱子", typeof(string));
                dt.Columns.Add("mac", typeof(string));
                dt.Columns.Add("位置", typeof(string));
                dt.Columns.Add("实际商品", typeof(string));
                DataTable dt1;
                DataTable dt2;
                for(int i=0;i<dt.Rows.Count;i++){
                    string sql1 =@"select B.品名 as 默认商品,A.id as 箱子id,A.箱子号 as 箱子,A.箱子mac as mac,A.位置 as 位置 from WP_箱子表 as A left join dbo.WP_商品表 as B ON A.默认商品id = B.id where 1=1 and 库位id="+dt.Rows[i]["库位id"]+condition;
                    string sql2 = @"select B.品名 as 实际商品,A.id as 箱子id,A.箱子号 as 箱子,A.箱子mac as mac,A.位置 from WP_箱子表 as A left join dbo.WP_商品表 as B ON A.实际商品id = B.id where 1=1 and 库位id=" + dt.Rows[i]["库位id"] + condition;
                    dt1 = comfun.GetDataTableBySQL(sql1);
                    dt2 = comfun.GetDataTableBySQL(sql2);
                    if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                    {
                            dt.Rows[i]["默认商品"] = dt1.Rows[i]["默认商品"];
                            dt.Rows[i]["实际商品"] = dt2.Rows[i]["实际商品"];
                            dt.Rows[i]["箱子id"] = dt1.Rows[i]["箱子id"];
                            dt.Rows[i]["箱子"] = dt1.Rows[i]["箱子"];
                            dt.Rows[i]["mac"] = dt1.Rows[i]["mac"];
                            dt.Rows[i]["位置"] = dt1.Rows[i]["位置"];
                        
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
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string sql = "";

            DataTable dt1 = comfun.GetDataTableBySQL(sql);

            if (dt1.Rows.Count > 0)
            {
                DTcms.Common.Excel.DataTable4Excel(dt1, "仓位表");
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }
        #endregion

        /// <summary>
        /// 点击搜索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            //获取几个框的值
            string name_value=ddlA_is_name.SelectedValue.ToString();
            string txt_name=this.txt_mingcheng.Text.Trim();
            string txt_mac = this.txt_mac.Text.Trim();
           // string txt_warehouse = ddlA_is_self.Text.ToString();
            //判断是否为空
            if (name_value != "0" && txt_name != "")
            {
                switch (name_value)      //1=酒店    2=仓库   3=仓位
                {
                    case "1":
                        _where += " and 酒店 like " + txt_name;
                        break;
                    case "2":
                        _where += " and 仓库 like " + txt_name;
                        break;
                    case "3":
                        _where += " and 仓位 like " + txt_name;
                        break;
                    default:
                        break;
                }
            }
            else if (txt_name!=""){
                _where += " and 酒店 like " + txt_name;
            }
            if(txt_mac!=""){
                _where += " and mac like " + txt_mac;
            }
            //if(txt_warehouse!=""){
            //    _where += " and 仓库 like "+txt_warehouse;
            //}
            ClassList(_where);
        }

        ///// <summary>
        /////动态绑定下拉框 
        ///// </summary>
        //protected void ddl_store_val (){
        //    DataTable dt=ClassList(" order by 仓库");
        //    if(dt.Rows.Count>0){
        //        for(int i=0;i<dt.Rows.Count;i++){
        //             string 仓库 = dt.Rows[i]["仓库"].ObjToStr();
        //           // ddlA_is_self.Items.Add(new ListItem("value",仓库)); //绑定下拉框控件
        //        }
        //    }
            
            
        //}
            
        ///// <summary>
        ///// 下拉框值改变
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //  protected void ddlA_is_self_SelectedIndexChanged(object sender, EventArgs e)
        //{
        
        //}

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
                int id = Convert.ToInt32(((HiddenField)sptList1.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)sptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DTcms.BLL.WP_商品图片表 sptpbll = new DTcms.BLL.WP_商品图片表();

                    DTcms.BLL.WP_商品详情表 spxqbll = new DTcms.BLL.WP_商品详情表();

                    DTcms.BLL.WP_商品表 spbll = new DTcms.BLL.WP_商品表();

                    DbHelperSQL.GetSingle(" Update WP_商品表 set IsShow=0 where id=" + id + " ");

                    MessageBox.Show(this, "删除成功！");

                }
            }
            //用户列表显示
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
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
            ClassList("");
        }
        #endregion

  

    }
}




