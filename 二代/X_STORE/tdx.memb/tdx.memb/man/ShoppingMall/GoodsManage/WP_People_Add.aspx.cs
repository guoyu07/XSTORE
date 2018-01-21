using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.BLL;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class WP_People_Add : System.Web.UI.Page
    {
        DTcms.BLL.WP_People BLLtt = new DTcms.BLL.WP_People();
        DTcms.Model.WP_People Modeltt = new DTcms.Model.WP_People();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        Modeltt = BLLtt.GetModel(id);
                        txtmc.Value = Modeltt.name;
                    }

                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "WP_People_Add.cs", Session["wID"].ToString());
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string _mc = comFunction.NoHTML(txtmc.Value);

                //if (_mc == "")
                //{
                //    lt_result.Text = "人员名称不能为空！";
                //    return;
                //}


                if (Request["id"] != null)
                {
                    try
                    {
                        Modeltt.name = _mc;
                        BLLtt.Update(Modeltt);
                        lt_result.Text = "修改成功.";

                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='WP_People_List.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
                else
                {
                    try
                    {
                        Modeltt.name = _mc;
                        BLLtt.Add(Modeltt);
                        lt_result.Text = "添加成功.";
                        lt_result.Text +=
                            "<script language='javascript'>setTimeout(function(){location.href='WP_People_List.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "WP_People_Add.cs", Session["wID"].ToString());
            }
        }
    }
}