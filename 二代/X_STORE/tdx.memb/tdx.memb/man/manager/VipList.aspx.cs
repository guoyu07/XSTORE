using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using System.Data.SqlClient;
using Wuqi.Webdiyer;
namespace tdx.memb.man.manager
{
    public partial class VipList : DTcms.Web.UI.ManagePage
    {
        DTcms.BLL.t_Users hybll = new DTcms.BLL.t_Users();


        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //vipinfoList();
               // bind();
                bindsql("");
            }
        }
        #endregion
        private void bindsql( string where_sql)
        {

           // DTcms.BLL.WP_酒店表 jd = new DTcms.BLL.WP_酒店表();
            string sql = "select id,username,surname+Name as xingming,nickname ,gender,totalprice,creationtime,EmailAddress from t_users where isdeleted='false' " + where_sql + " order by id desc";
            // SqlDataAdapter sqlda = new SqlDataAdapter("select * from customers", jd);
            DataTable dt = comfun.GetDataTableBySQL(sql);
            //  sql.Fill(ds);
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.AspNetPager1.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.AspNetPager1.PageSize = 10;
            this.Rp_VipInfo.DataSource = pdsList;
            this.Rp_VipInfo.DataBind();
        }





        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindsql("");
        }


        //点击搜素
        protected void lb_sousuo_Click(object sender, EventArgs e)
        {
            string where_sql="";
            string username=txt_user_ame.Text.ObjToStr();
            string xm= txt_xm.Text.ObjToStr();
            string nickname= txt_nick_name.Text.ObjToStr();
            if(username==""){
                where_sql +=" and username like '%"+username+"%'";
            }
            if(xm==""){
                where_sql+=" and xingming like '%"+xm+"%'";
            }
            if(nickname==""){
                   where_sql+=" and nickname like '%"+nickname+"%'";
            }
            bindsql(where_sql);
        }

        #region 4.0 删除 +void btnDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Rp_VipInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_VipInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_VipInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bool res = hybll.Delete(id);
                    if (res)
                    {
                        MessageBox.ShowAndRedirect(this, "删除成功！", "VipList.aspx");
                    }
                    else {
                        MessageBox.Show(this,"删除失败!");
                    }
                }
            }
            
        }
        #endregion
    }
}

       

 

        