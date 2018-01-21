using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.manager
{
    public partial class WX_users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                sel_users("");
                sel_jd();//绑定酒店查询
            }
        }

        protected void sel_jd() {
            string jd_sql = @" select id,仓库名 from WP_仓库表 where IsShow=1";
            DataTable dt=comfun.GetDataTableBySQL(jd_sql);
            if(dt.Rows.Count>0){
                rcb_jd.DataSource = dt;
                rcb_jd.DataBind();
            }
        }
        //查所有用户
        protected void sel_users(string where_sql) {
            string sel_sql = @"select  a.id  from WP_用户表 a left join WP_用户角色 b on a.角色id=b.id left join WP_用户权限 c on a.id=c.用户id where a.IsShow=1" + where_sql + " group by a.id ";
            DataTable dta=comfun.GetDataTableBySQL(sel_sql);
            dta.Columns.Add("用户名", typeof(string));
            dta.Columns.Add("密码", typeof(string));
            dta.Columns.Add("openid", typeof(string));
            dta.Columns.Add("手机号", typeof(string));
            dta.Columns.Add("真实姓名", typeof(string));
            dta.Columns.Add("QQ", typeof(string));
            dta.Columns.Add("Email", typeof(string));
            dta.Columns.Add("微信昵称", typeof(string));
            dta.Columns.Add("微信头像", typeof(string));
            dta.Columns.Add("角色id", typeof(string));
            dta.Columns.Add("角色类型", typeof(string));
            if(dta.Rows.Count>0){
                for (int i = 0; i < dta.Rows.Count; i++)
                {
                    string sql = @"select top 1 用户名,密码,openid,手机号,真实姓名,QQ,Email,微信昵称,微信头像,a.角色id,b.角色类型 
  from WP_用户表 a left join WP_用户角色 b on a.角色id=b.id left join WP_用户权限 c on a.id=c.用户id where a.IsShow=1 and a.id=" + dta.Rows[i]["id"] + where_sql;
                    DataTable dt = comfun.GetDataTableBySQL(sql);
                    if(dt.Rows.Count>0){
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            dta.Rows[i]["用户名"] = dt.Rows[j]["用户名"].ObjToStr();
                            dta.Rows[i]["密码"] = dt.Rows[j]["密码"].ObjToStr();
                            dta.Rows[i]["openid"] = dt.Rows[j]["openid"].ObjToStr();
                            dta.Rows[i]["手机号"] = dt.Rows[j]["手机号"].ObjToStr();
                            dta.Rows[i]["真实姓名"] = dt.Rows[j]["真实姓名"].ObjToStr();
                            dta.Rows[i]["QQ"] = dt.Rows[j]["QQ"].ObjToStr();
                            dta.Rows[i]["Email"] = dt.Rows[j]["Email"].ObjToStr();
                            dta.Rows[i]["微信昵称"] = dt.Rows[j]["微信昵称"].ObjToStr();
                            dta.Rows[i]["微信头像"] = dt.Rows[j]["微信头像"].ObjToStr();
                            dta.Rows[i]["角色id"] = dt.Rows[j]["角色id"].ObjToStr();
                            dta.Rows[i]["角色类型"] = dt.Rows[j]["角色类型"].ObjToStr();
                        }
                      
                    }
                }

            }

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
        protected void sousuo() {
            string name = txt_name.Text.ObjToStr();//用户名
            string phono = txt_tp.Text.ObjToStr();//手机号
            string hotel = rcb_jd.SelectedValue;//酒店
            string where_sql = "";
            if (name != "" && name != null)
            {
                where_sql += " and 用户名 like '%" + name + "%' ";
            }
            if (phono != "" && phono != null)
            {
                where_sql += " and 手机号 like '%" + phono + "%' ";
            }

            if(hotel!=""){
                where_sql += " and  库位id="+hotel;
            }
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
            int flag=0;
            for (int i = 0; i < Rp_users.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_users.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_users.Items[i].FindControl("chkId");
                if (cb.Checked)//选中了
                {
                    string del_sql = @"update WP_用户表 set IsShow =0 where id="+id;
                     flag=comfun.UpdateBySQL(del_sql);

                }
            }
            if (flag==0)
            {
                MessageBox.Show(this, "删除失败！");
            }
            else { 
            MessageBox.ShowAndRedirect(this, "删除成功！", "WX_users.aspx");
            }
        }


    }
}