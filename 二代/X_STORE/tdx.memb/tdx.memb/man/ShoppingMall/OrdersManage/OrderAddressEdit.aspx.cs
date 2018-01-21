using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using Creatrue.Common.Msgbox;
using tdx.database;
using DTcms.Model;


namespace tdx.memb.man.ShoppingMall.OrdersManage
{
    public partial class OrderAddressEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {///2015.7.12 添加
                string id = string.IsNullOrEmpty(Request["id"]) ? "0" : Request["id"];

                if (id != "0")
                {
                    getlist(id);
                }

            }
        }

        private void getlist(string id)
        {
            string sql = "select  *  from dbo.WP_订单地址表  where id in(select 地址ID from dbo.WP_地址表  where 地址ID='" + id + "') ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                txt_shouhuoren.Text = dt.Rows[0]["收货人"].ToString();
                txt_telephone.Text = dt.Rows[0]["手机号"].ToString();
                txt_sheng.Text = dt.Rows[0]["省"].ToString();
                txt_shi.Text = dt.Rows[0]["市"].ToString();
                txt_qu.Text = dt.Rows[0]["区"].ToString();
                txt_address.Value = dt.Rows[0]["详细地址"].ToString();
                txt_openid.Value = dt.Rows[0]["订单编号"].ToString();
                txt_id.Value = dt.Rows[0]["id"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DTcms.BLL.WP_订单地址表 dzbll = new DTcms.BLL.WP_订单地址表();
            DTcms.Model.WP_订单地址表 dzmodel = new DTcms.Model.WP_订单地址表();


            if (txt_shouhuoren.Text.Trim() == "")
            {
                MessageBox.Show(this, "收货人不能为空！"); return;
            }
            if (txt_telephone.Text.Trim().Length != 11)
            {
                MessageBox.Show(this, "手机号不正确"); return;

            }
            if (txt_sheng.Text.Trim() == "")
            {
                MessageBox.Show(this, "不能为空！"); return;
            }
            if (txt_shi.Text.Trim() == " ")
            {
                MessageBox.Show(this, "不能为空！"); return;
            }
            if (txt_qu.Text.Trim() == "")
            {
                MessageBox.Show(this, "不能为空！"); return;
            }
            if (txt_address.Value.Trim() == "")
            {
                MessageBox.Show(this, "不能为空！"); return;
            }

            dzmodel.收货人 = txt_shouhuoren.Text.Trim();
            dzmodel.手机号 = txt_telephone.Text.Trim();
            dzmodel.省 = txt_sheng.Text.Trim();
            dzmodel.市 = txt_shi.Text.Trim();
            dzmodel.区 = txt_qu.Text.Trim();
            dzmodel.详细地址 = txt_address.Value.Trim();
            dzmodel.订单编号 = txt_openid.Value.Trim();
            dzmodel.id = int.Parse(txt_id.Value.Trim());

           bool b= dzbll.Update(dzmodel);
           if (b)
           {
               MessageBox.ShowAndRedirect(this, "更新成功！", "OrderAddressList.aspx?openid=" + txt_openid.Value.Trim() + "");
           }

        }
    }
}