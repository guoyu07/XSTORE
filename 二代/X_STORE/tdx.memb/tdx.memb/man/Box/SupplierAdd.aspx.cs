using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Box
{
    public partial class SupplierAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //提交保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string company_name = txt_company_name.Text.Trim();
            string company_site = txt_company_site.Text.Trim();
            string contacts = txt_contacts.Text.Trim();
            string phono = txt_phono.Text.Trim();
            string postcode = txt_postcode.Text.Trim();
            string email = txt_email.Text.Trim();
            string www = txt_www.Text.Trim();
            if(company_name==""){
                MessageBox.Show(this, "请填写公司名称!");
              return;
            }
           if(company_site==""){
              MessageBox.Show(this,"请填写公司地址!");
              return;
            }
           if(contacts==""){
              MessageBox.Show(this,"请填写联系人!");
              return;
            }
           if(phono==""){
              MessageBox.Show(this,"请填写公司电话!");
              return;
            }
           if (!isPhone(phono))
           {
                MessageBox.Show(this, "请正确按照格式填写前台电话!");
                return;
            }
           if(postcode==""){
              MessageBox.Show(this,"请填写邮编!");
              return;

            }
           if (!Ispostcode(postcode))
           {
               MessageBox.Show(this,"请正确按照格式填写邮编!");
               return;
            }
            if(email==""){
                MessageBox.Show(this,"请填写电子邮箱!");
                return;
            }
            if(!IsEmail(email)){
                MessageBox.Show(this,"请按照正确格式填写邮箱!");
                return;
            }
            if (www == "")
            {
                MessageBox.Show(this, "请填写公司网址!!");
                return;
            }
            if (!IsWww(www))
            {
                MessageBox.Show(this,"请按照正确格式填写网址!");
                return;
            }
           string sql = @" insert into WP_客户资料 (是否供应商,公司名称,公司地址,联系人,电话,邮编,电子邮件,网址)values('1','" + company_name + "','" + company_site + "','" + contacts + "','" + phono + "','" + postcode +"','"+email+"','"+www+"')";
           int flag=comfun.InsertBySQL(sql);
           if (flag != 0)
           {
               MessageBox.ShowAndRedirect(this, "添加成功!", "SupplierList.aspx");
               return;
           }
           else {
               MessageBox.Show(this,"添加失败!");
               return;
           }
        }
        public bool isPhone(string input)
        {
            Regex regex = new Regex(@"^\d{3,4}-\d{7,8}$");
            return regex.IsMatch(input);
        }

        protected bool Ispostcode(string ss)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ss, @"^\d{6}$");
        }
        protected bool IsEmail(string ss) {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
              return regex.IsMatch(ss);
        }
        protected bool IsWww(string ss)
        {
            Regex regex = new Regex(@"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)?((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.[a-zA-Z]{2,4})(\:[0-9]+)?(/[^/][a-zA-Z0-9\.\,\?\'\\/\+&%\$#\=~_\-@]*)*$");
            return regex.IsMatch(ss);
        }

    }
}