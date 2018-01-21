using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace tdx.memb.man.Talking
{
    public partial class advert_operateTalkLunBo : System.Web.UI.Page
    {
        private DTcms.BLL.advert bll = new DTcms.BLL.advert();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Action();
                bind_pics();
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
                        this.txtcode.Text = src.code;
                        this.txtname.Text = src.name;
                        this.btnUpdate.Visible = true;
                        try
                        {
                            this.ViewState["pics"] = DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(src.array);
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
                TextBox url = (this.rptlist1.Items[i].FindControl("url") as TextBox);
                TextBox pic = (this.rptlist1.Items[i].FindControl("pic") as TextBox);
                TextBox txt_ordernum = (this.rptlist1.Items[i].FindControl("txt_ordernum") as TextBox);
                int order = 99;
                int.TryParse(txt_ordernum.Text.Trim(), out order);
                DTcms.Model.advert_pic _pic = new DTcms.Model.advert_pic()
                {
                    url = url.Text.Trim(),
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
                ordernum = 99
            };
            pics.Add(_pic);
            this.ViewState["pics"] = pics;
            bind_pics();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            List<DTcms.Model.advert_pic> pics = Pics();
            pics.RemoveAt(item.ItemIndex);
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
            src.name = this.txtname.Text.Trim();
            src.array = DTcms.Common.Utils.JsonSerialize(Pics());
            src.types = 2;
            bool result = bll.Add(src);
            if (result)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('添加成功');location.href='advert_manageTalkLunBo.aspx'", true);
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
            src.id = ID;
            bool result = bll.Update(src);
            if (result)
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('修改成功');location.href='advert_manageTalkLunBo.aspx'", true);
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('修改过程中发生错误啦')", true);
            }
        }
    }
}