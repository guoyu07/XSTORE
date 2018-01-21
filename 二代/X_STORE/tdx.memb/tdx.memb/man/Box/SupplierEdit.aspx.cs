using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Box
{
    public partial class SupplierEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                string id = string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"];
                area(id);
            }
        }

        protected void area(string id) {
            string sql = @"select * from WP_客户资料 where 编号='"+id+"'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if(dt.Rows.Count>0){
                txt_company_name.Text = dt.Rows[0]["公司名称"].ObjToStr();
                txt_company_site.Text = dt.Rows[0]["公司地址"].ObjToStr();
                txt_contacts.Text = dt.Rows[0]["联系人"].ObjToStr();
                txt_phono.Text = dt.Rows[0]["电话"].ObjToStr();
                txt_postcode.Text = dt.Rows[0]["邮编"].ObjToStr();
            }
        }

        //提交保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
                string id = string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"];
            string company_name = txt_company_name.Text.Trim();
            string company_site = txt_company_site.Text.Trim();
            string contacts = txt_contacts.Text.Trim();
            string phono = txt_phono.Text.Trim();
            string postcode = txt_postcode.Text.Trim();
            if (company_name == "")
            {
                MessageBox.Show(this, "请填写公司名称!");
                return;
            }
            if (company_site == "")
            {
                MessageBox.Show(this, "请填写公司地址!");
                return;
            }
            if (contacts == "")
            {
                MessageBox.Show(this, "请填写联系人!");
                return;
            }
            if (phono == "")
            {
                MessageBox.Show(this, "请填写公司电话!");
                return;
            }
            if (!isPhone(phono))
            {
                MessageBox.Show(this, "请正确按照格式填写电话!");
                return;
            }
            if (postcode == "")
            {
                MessageBox.Show(this, "请填写邮编!");
                return;

            }
            if (!Ispostcode(postcode))
            {
                MessageBox.Show(this, "请正确按照格式填写邮编!");
                return;
            }

            string sql = @" update WP_客户资料 set 公司名称='" + company_name + "',公司地址='" + company_site + "',联系人='" + contacts + "',电话='" + phono + "',邮编='" + postcode + "' where 编号='"+id+"'";
            int flag = comfun.InsertBySQL(sql);
            if (flag != 0)
            {
                MessageBox.ShowAndRedirect(this, "添加成功!", "SupplierList.aspx");
                return;
            }
            else
            {
                MessageBox.Show(this, "添加失败!");
                return;
            }
        }
        public bool isPhone(string input)
        {
            //Regex regex = new Regex(@"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
            Regex regex = new Regex(@"^\d{3,4}-\d{7,8}$");
            return regex.IsMatch(input);
        }

        protected bool Ispostcode(string ss)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ss, @"^\d{6}$");
        }
    }
}