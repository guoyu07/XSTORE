﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.DBUtility;

namespace tdx.memb.man.Shop
{
    public partial class advert_operateReMai : System.Web.UI.Page
    {
        private DTcms.BLL.advert bll = new DTcms.BLL.advert();
        public int typeid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                goodstype();

                this.Action();
                bind_pics();
            }
        }

        private void goodstype()
        {
            string sql = " select c_id,c_no as 类别编号,c_name as 类别名 from dbo.WP_category where c_parent=0 order by c_id asc";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["类别名"] = "所有分类";
            row["类别编号"] = "-1";
            dt.Rows.InsertAt(row, 0);
            if (dt.Rows.Count > 0)
            {

                dr_types.DataSource = dt.DefaultView;
                dr_types.DataTextField = "类别名";
                dr_types.DataValueField = "类别编号";

                dr_types.DataBind();

            }

        }

        private void Action()
        {
            string Act = DTRequest.GetQueryString("Act");
            string[] ActArray = Utils.SplitString(Act, ",", 2);
            int ID = DTRequest.GetQueryInt("ID", -1);
            switch (ActArray[0])
            {
                case "Add":


                    this.btnInsert.Visible = true;
                    break;
                case "Edit":
                    this.txtcode.Enabled = false;
                    DTcms.Model.advert src = bll.GetModel(ID);
                    if (src != null)
                    {
                        typeid = src.id;
                        dr_types.SelectedValue = src.类别号;
                        this.txtcode.Text = src.code;
                        this.txtname.Text = src.name;
                        this.btnUpdate.Visible = true;
                        try
                        {
                            List<DTcms.Model.advert_pic> ss = DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(src.array);
                            ss.Sort();
                            this.ViewState["pics"] = ss;
                            this.bind_pics();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    break;
            }
        }

        private void bind_pics()
        {
            this.rptlist1.DataSource = this.ViewState["pics"];
            this.rptlist1.DataBind();
        }

        public List<DTcms.Model.advert_pic> Pics()
        {
            List<DTcms.Model.advert_pic> pics = new List<DTcms.Model.advert_pic>();
            for (int i = 0; i < this.rptlist1.Items.Count; i++)
            {
                TextBox txturl;
                string myurl = "";
                txturl = (this.rptlist1.Items[i].FindControl("url") as TextBox);
                myurl = txturl.Text;

                TextBox pic = (this.rptlist1.Items[i].FindControl("pic") as TextBox);
                TextBox txt_ordernum = (this.rptlist1.Items[i].FindControl("txt_ordernum") as TextBox);
                int order = 9;
                int.TryParse(txt_ordernum.Text.Trim(), out order);
                DTcms.Model.advert_pic _pic = new DTcms.Model.advert_pic()
                {
                    url = myurl,
                    pic = pic.Text.Trim(),
                    ordernum = order
                };
                pics.Add(_pic);
            }
            this.ViewState["pics"] = pics;
            return pics;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<DTcms.Model.advert_pic> pics = Pics();
            DTcms.Model.advert_pic _pic = new DTcms.Model.advert_pic()
            {
                url = "",
                pic = "",
                ordernum = 9
            };
            pics.Add(_pic);
            pics.Sort();
            this.ViewState["pics"] = pics;
            bind_pics();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            List<DTcms.Model.advert_pic> pics = Pics();
            pics.RemoveAt(item.ItemIndex);
            pics.Sort();
            this.ViewState["pics"] = pics;
            bind_pics();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtcode.Text))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('代码不能为空')", true);
                return;
            }
            if (string.IsNullOrEmpty(this.txtname.Text))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('名称不能为空')", true);
                return;
            }
            DTcms.Model.advert src = new DTcms.Model.advert();
            src.code = this.txtcode.Text.Trim();
            src.name = this.txtname.Text.Trim(); src.array = DTcms.Common.Utils.JsonSerialize(Pics());
            src.类别号 = dr_types.SelectedValue;
            src.types = 1;bool result = bll.Add(src);
            if (result)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('添加成功');location.href='advert_manageReMai.aspx'", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "2", "alert('添加过程中发生错误啦')", true);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtcode.Text))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('代码不能为空')", true);
                return;
            }
            if (string.IsNullOrEmpty(this.txtname.Text))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('名称不能为空')", true);
                return;
            }
            int ID = DTRequest.GetQueryInt("ID", -1);
            DTcms.Model.advert src = new DTcms.Model.advert();
            src.code = this.txtcode.Text.Trim();
            src.name = this.txtname.Text.Trim();
            src.array = DTcms.Common.Utils.JsonSerialize(Pics());
            src.类别号 = dr_types.SelectedValue;
            src.id = ID;
            src.types = 1;
            bool result = bll.Update(src);
            if (result)
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('修改成功');location.href='advert_manageReMai.aspx'", true);
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('修改过程中发生错误啦')", true);
            }
        }
    }
}