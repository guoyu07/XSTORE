using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.manager
{
    public partial class WXUsersEdit : System.Web.UI.Page
    {
        string id = DTRequest.GetQueryString("id").ObjToStr();//接收的参数

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                if (id != "-1")//修改
                {
                    sel_user(" and a.id="+id);
                }
                bind_role();
            }
           
        }

        protected void bind_role() {
            string sql = "select id,角色类型 from WP_用户角色 ";
            DataTable dtb = comfun.GetDataTableBySQL(sql);
            if (dtb.Rows.Count > 0)
            {
                ddlRoleId.DataSource = dtb;
                ddlRoleId.DataTextField = "角色类型";
                ddlRoleId.DataValueField = "id";
                ddlRoleId.DataBind();
            }
            ddlRoleId.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        protected void sel_user(string where_sql) {
            string sel_sql = @"select a.id,用户名,密码,openid,手机号,真实姓名,QQ,Email,微信昵称,微信头像,角色id,角色类型 from WP_用户表 a left join WP_用户角色 b on a.角色id=b.id where 1=1 " + where_sql;
            DataTable dt=comfun.GetDataTableBySQL(sel_sql);
          
         
            if(dt.Rows.Count>0){
                txt_name.Text=dt.Rows[0]["用户名"].ObjToStr();
                txt_pwd.Text = dt.Rows[0]["密码"].ObjToStr();
                txt_again_pwd.Text = dt.Rows[0]["密码"].ObjToStr();
                txt_openid.Text = dt.Rows[0]["openid"].ObjToStr();
                txt_phono.Text = dt.Rows[0]["手机号"].ObjToStr();
                txt_real_name.Text = dt.Rows[0]["真实姓名"].ObjToStr();
                txt_qq.Text = dt.Rows[0]["QQ"].ObjToStr();
                txt_email.Text = dt.Rows[0]["Email"].ObjToStr();
                txt_wx_nick.Text = dt.Rows[0]["微信昵称"].ObjToStr();
                ddlRoleId.SelectedValue = dt.Rows[0]["角色id"].ObjToStr();
                rptManagementAttachList.DataSource = dt;
                rptManagementAttachList.DataBind();
            }
          
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            string role_lx = ddlRoleId.SelectedValue;
            string name = txt_name.Text.ObjToStr();
            string pwd = txt_pwd.Text.ObjToStr();
            string openid = txt_openid.Text.ObjToStr();
            string phono = txt_phono.Text.ObjToStr();
            string real_name = txt_real_name.Text.ObjToStr();
            string qq = txt_qq.Text.ObjToStr();
            string email = txt_email.Text.ObjToStr();
            string wx_nick = txt_wx_nick.Text.ObjToStr();
            if(role_lx=="0"){
                MessageBox.Show(this, "请选择权限!");
                return;
            }
            if(name==""){
                MessageBox.Show(this,"请填写用户名");
                return;
            }
            if (!txt_name_sel())
            { //true 用户名不存在 ,false用户名存在
                return;
            }
            
            if (pwd == "")
            {
                MessageBox.Show(this, "请填写密码");
                return;
            }
            if (name == "")
            {
                MessageBox.Show(this, "请验证密码!");
                return;
            }
            if (!txt_again_pwd_sel())
            {//true 一致，flase不一致
                return;
            }
            if(openid==""){
                openid = " ";
            }
            if(phono==""){
                phono = " ";
            }
            if(wx_nick==""){
                wx_nick = " ";
            }
            if (real_name == "")
            {
                real_name = " ";
            }
            if (qq == "")
            {
                qq = " ";
            }
            if (email == "")
            {
                email = " ";
            }
            //图片
            string[] albumArr1 = DTRequest.GetFormString("hid_photo_name").Split(',');
            string str = " ";
            if (albumArr1 != null && albumArr1.Length >0&& albumArr1[0] != "")
            {
                string str1 = string.Join(",", albumArr1);
                // str = str1.Substring(2, 40);
                List<string> list_str = str1.Split(new char[]{'|'},StringSplitOptions.RemoveEmptyEntries).ToList();
                if (list_str.Count <= 1)
                {
                    str = string.Empty;
                }
                else
                {
                    str = list_str[1];
                }
               
            }
            else
            {
                MessageBox.Show(this, "请先上传图片！"); return;
            }

          
            int flag=0;
            //图片
            if(id!="-1"){//-1新增 
                string sql = @"update WP_用户表 set 用户名='" + name + "',密码='" + pwd + "',openid='" + openid + " ',手机号='" + phono + "',真实姓名='" + real_name + "',QQ='" + qq + "',Email='" + email + "',微信昵称='" + wx_nick + "',微信头像='" + str + "',角色id='" + role_lx + "' where id=" + id;
                flag = comfun.UpdateBySQL(sql);
            }
            else
            {
                string sql = @"insert into WP_用户表 (用户名,密码,openid,手机号,真实姓名,QQ,Email,微信昵称,微信头像,角色id)values('" + name + "','" + pwd + "','" + openid + "','" + phono + "','" + real_name + "','" + qq + "','" + email + "','" + wx_nick + "','" + str + "','" + role_lx + "')";
                flag = comfun.InsertBySQL(sql);
            }
            if (flag > 0)
            {
                MessageBox.ShowAndRedirect(this, "操作成功", "WX_users.aspx");
            }
            else
            {
                MessageBox.Show(this, "操作失败");
                return;
            }
        }

    
        //用户名值改变
        protected bool txt_name_sel()
        {
            if (id != "-1")
            {//修改
                string name = txt_name.Text;
                string name_sql = @"select id from WP_用户表 where 用户名='" + name + "' and id!=" + id;
                DataTable dt = comfun.GetDataTableBySQL(name_sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(this, "用户名已存在!");
                    return false;
                }
                return true;
            }
            else {
                string name = txt_name.Text;
                string name_sql = @"select id from WP_用户表 where 用户名='" + name + "'";
                DataTable dt = comfun.GetDataTableBySQL(name_sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(this, "用户名已存在!");
                    return false;
                }
                return true;
            
            }
            
        }

        //验证密码值改变
        protected bool txt_again_pwd_sel()
        {
            string pwd = txt_pwd.Text;
            string again_pwd = txt_again_pwd.Text;
            if (pwd != again_pwd)
            {
                MessageBox.Show(this,"密码不一致，请重新输入");
                return false;
            }
            return true;
        }

    }
}