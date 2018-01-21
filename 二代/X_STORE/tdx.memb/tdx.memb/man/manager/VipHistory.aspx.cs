using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace tdx.memb.man.manager
{
    public partial class VipHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sel_users("");
                //sel_jd();//绑定酒店查询
            }
        }

        //protected void sel_jd()
        //{
        //    string jd_sql = @" select id,仓库名 from WP_仓库表 where IsShow=1";
        //    DataTable dt = comfun.GetDataTableBySQL(jd_sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        rcb_jd.DataSource = dt;
        //        rcb_jd.DataBind();
        //    }
        //}
        //查所有用户
        protected void sel_users(string where_sql)
        {
            string sel_sql = @"select id,openid,用户名,密码,手机号,真实姓名,QQ,Email,微信昵称,微信头像 from WP_用户历史表 where 1=1 " + where_sql;
            DataTable dta = comfun.GetDataTableBySQL(sel_sql);

            bound(dta);

        }

        //绑定分页控件
        public void bound(DataTable dt)
        {
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.Rp_users.DataSource = pdsList;
            this.Rp_users.DataBind();
        }

        //点击搜索
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected void sousuo()
        {
            string name = txt_name.Text.ObjToStr();//用户名
            string phono = txt_tp.Text.ObjToStr();//手机号
            //string hotel = rcb_jd.SelectedValue;//酒店
            string where_sql = "";
            if (name != "" && name != null)
            {
                where_sql += " and 用户名 like '%" + name + "%' ";
            }
            if (phono != "" && phono != null)
            {
                where_sql += " and 手机号 like '%" + phono + "%' ";
            }

            //if (hotel != "")
            //{
            //    where_sql += " and  库位id=" + hotel;
            //}
            sel_users(where_sql);
        }

        //分页值改变
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int flag = 0;
            for (int i = 0; i < Rp_users.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_users.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_users.Items[i].FindControl("chkId");
                if (cb.Checked)//选中了
                {
                    string del_sql = @"update WP_用户表 set IsShow =0 where id=" + id;
                    flag = comfun.UpdateBySQL(del_sql);

                }
            }
            if (flag == 0)
            {
                MessageBox.Show(this, "删除失败！");
            }
            else
            {
                MessageBox.ShowAndRedirect(this, "删除成功！", "WX_users.aspx");
            }
        }


    }
}