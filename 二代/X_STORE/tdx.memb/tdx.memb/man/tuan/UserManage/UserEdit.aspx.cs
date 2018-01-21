using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Model;
using DTcms.BLL;
using System.Data;
using Creatrue.Common.Msgbox;
using Creatrue.kernel;

namespace tdx.memb.man.Tuan.UserManage
{
    public partial class UserEdit : DTcms.Web.UI.ManagePage
    {
        DTcms.BLL.manager yhbll = new DTcms.BLL.manager();

        DTcms.Model.manager yhmodel = new DTcms.Model.manager();

      
        public static int ids;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                if (id > 0)
                {
                    ids = id;
                    showuser(id);
                }

            }
        }
        public void showuser(int id)
        {

            DataTable dt = yhbll.GetList(" id=" + id).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txt_Name.Text = dt.Rows[0]["user_name"].ToString();
                
                txt_openid.Text = dt.Rows[0]["openid"].ToString();
                txt_Telephone.Text = dt.Rows[0]["telephone"].ToString();
                txt_address.Text = dt.Rows[0]["address"].ToString();
                txt_mima.Text = dt.Rows[0]["password"].ToString();
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            yhmodel.password = txt_mima.Text;
            yhmodel.telephone = txt_Telephone.Text;
            yhmodel.address = txt_address.Text;
            yhmodel.user_name = txt_Name.Text;
            yhmodel.openid = txt_openid.Text;
           
            if (ids > 0)
            {
                yhmodel.id = ids;

                bool b = yhbll.Update(yhmodel);

                if (b)
                {
                    MessageBox.ShowAndRedirect(this, "修改成功！", "UserList.aspx");
                    ids = -1;
                }
            }
            else 
            {
                int i=yhbll.Add(yhmodel);
                if (i>0)
                {
                    MessageBox.ShowAndRedirect(this, "添加成功！", "UserList.aspx"); 
                }
            }
        }
    }
}