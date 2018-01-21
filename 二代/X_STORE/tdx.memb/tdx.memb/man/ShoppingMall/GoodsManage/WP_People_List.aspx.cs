using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.BLL;
using DTcms.DBUtility;
using tdx.database;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class WP_People_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {

                    DataTable dt = DbHelperSQL.Query("select * from WP_People order by  createtime desc ").Tables[0];
                    Rp_UserInfo.DataSource = dt;
                    Rp_UserInfo.DataBind();

                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Shop/GoodsManage/WP_People_List.cs", Session["wID"].ToString());
                }
            }
        }



        #region 删除
        protected void delBtn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
                {
                    int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                    CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                    if (cb.Checked)
                    {
                        try
                        {
                            new WP_People().Delete(id);

                        }
                        catch (Exception)
                        {
                            lt_result.Text = "删除失败！";
                            return;
                        }
                    }
                    lt_result.Text = "删除成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='WP_People_List.aspx';},300);</script>";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Shop/GoodsManage/WP_People_List.cs", Session["wID"].ToString());
            }
        }
        #endregion

    }
}