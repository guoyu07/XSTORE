using Creatrue.Common.Msgbox;
using Creatrue.Common.EmailPlus;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.BLL;
using System.Data.SqlClient;

namespace tdx.memb.man.manager
{
    public partial class VipAdd : DTcms.Web.UI.ManagePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rolechoose();
                genderchoose();
            }
        }
        public void genderchoose()
        {
            string sql = "select id,gender from t_user_gender";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            Gender.DataTextField = "gender";
            Gender.DataValueField = "id";
            this.Gender.DataSource = dt;
            Gender.DataBind();
        }
        public void rolechoose()
        {//分配角色
            string sql = "select id,DisplayName from t_Roles";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            role.DataValueField = "id";
            role.DataTextField = "Displayname";
            this.role.DataSource = dt;
            role.DataBind();
        }
        public int paswd()
        {  //确认密码
            int a = 0;
            string pswda = pwdmm.Text;
            string pswdb = repassword.Text;
            if (pswda == pswdb)
            {
                about.Text = "密码相同";
                return a = 1;

            }
            else
            {
                about.Text = "请重新输入";
                return a = 0;
            }
        }
        //邮箱确认
        public int  emailadd()
        {
            int b = 0;
            if (Regexlib.IsValidEmail(emailaddress.Text.Trim()))
            {
                aboutemail.Text = "";
                return b = 1;
            }
            else
            {
                aboutemail.Text = "输入的不是有效的邮件地址格式";
                return b = 0;
            }
        }

        //用户名确认
        public int  usernamere()
        {
            int c = 0;
            string un = username.Text;
            string sql = "select*from t_users where username='" + un + "'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count != 0)
            {
                userabout.Text = "用户名已存在";
             return  c = 0;
            }
            else { 
                userabout.Text = ""; 
                return c = 1; 
            }


        }
        protected void btnSubmit_Click2(object sender, EventArgs e)
        {
            int a = paswd();//密码
            int b = emailadd();
            //用户名确认
            int c = 0;
            string un = username.Text;
            string sql = "select*from t_users where username='" + un + "'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count != 0)
            {
                userabout.Text = "用户名已存在";
                c = 0;
            }
            else { userabout.Text = ""; c = 1; }
            int rol = Convert.ToInt32(role.SelectedItem.Value);
            int gend = Convert.ToInt32(Gender.SelectedItem.Value);
            if (a == 1 && b == 1 && c == 1)
            {
                string newsql = "insert into t_Users (UserName,Gender,WechatAccessTokenExpiresIn,IsMobileConfirmed,Consumes,TotalPrice,RegTime,LoginTime,LoginTimes,Name,Surname,[Password],IsEmailConfirmed,IsActive,EmailAddress,IsDeleted,CreationTime) values('" + username.Text + "','" + gend + "','0','False','0','0',getdate(),getdate(),'0','" + name.Text + "','" + surname.Text + "','" + pwdmm.Text + "','true','true','" + emailaddress.Text + "','false',getdate())";
                DataSet we = comfun.GetDataSetBySQL(newsql);
                string idsql ="select id from t_Users where UserName='" + username.Text + "'and EmailAddress='" + emailaddress.Text + "'";
                //DataSet user_id = comfun.GetDataSetBySQL(Convert.ToInt32(idsql));
                DataSet idsql_dt = comfun.GetDataSetBySQL(idsql);
                Session["xxx"]=idsql_dt.Tables[0].Rows[0]["id"].ToString().Trim();
                int user_id = Convert.ToInt32(Session["xxx"].ToString());
                string roles = "insert into t_User_Roles (TenantId,UserId,RoleId,CreationTime,CreatorUserId) values ('1','"+user_id+"','"+rol+"',GETDATE(),'')";
                DataSet all = comfun.GetDataSetBySQL(roles);
               MessageBox.ShowAndRedirect(this,"添加成功!", "VipList.aspx");


            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }
        }
    }
}