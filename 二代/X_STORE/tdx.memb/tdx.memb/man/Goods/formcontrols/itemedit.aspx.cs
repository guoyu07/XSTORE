using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.formcontrols
{
    public partial class itemedit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null && Request["objid"] != null)
                    {


                        if (Request["iid"] != null)
                        {
                            DataTable dt = control_value.GetList("*", "id=" + Request["iid"].ToString());
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["is_select"].ToString() == "1")
                                {
                                    xuanzhong.Checked = true;
                                }
                                else
                                {
                                    xuanzhong.Checked = false;
                                }
                                name.Value = dt.Rows[0]["value"].ToString();
                                sort.Value = dt.Rows[0]["sort"].ToString();
                            }
                            else
                            {

                                lt_result.Text = "请选择正确的项目";
                                Response.Write("<script language='javascript'>location.href='controlitem.aspx?id=" + Request["id"].ToString() + "&objid=" + Request["objid"].ToString() + "';</script>");
                                return;
                            }



                        }
                        else
                        {
                            sort.Value = "99";
                            name.Value = "项目名称";

                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                        return;
                    }
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/formcontrols/itemedit.cs", Session["wID"].ToString());
                }
            }

        }

        protected void save(object sender, EventArgs e)
        {
            try
            {
                if (Request["iid"] != null)
                {
                    control_value cv = new control_value(Convert.ToInt32(Request["iid"].ToString()));
                    if (!string.IsNullOrEmpty(name.Value) && !string.IsNullOrEmpty(sort.Value))
                    {
                        cv.value = name.Value;
                        int.TryParse(sort.Value, out cv.sort);
                        cv.is_select = xuanzhong.Checked ? 1 : 0;
                        cv.Update();
                        lt_result.Text = "修改成功";
                        Response.Write("<script language='javascript'>location.href='controlitem.aspx?id=" + Request["id"].ToString() + "&objid=" + Request["objid"].ToString() + "';</script>");
                    }
                }
                else
                {
                    if (Request["id"] != null)
                    {
                        if (!string.IsNullOrEmpty(name.Value) && !string.IsNullOrEmpty(sort.Value))
                        {
                            control_value ncv = new control_value();
                            ncv.value = name.Value;
                            int.TryParse(sort.Value, out ncv.sort);
                            ncv.is_select = xuanzhong.Checked ? 1 : 0;
                            ncv.key_id = Convert.ToInt32(Request["id"].ToString());
                            ncv.Update();
                            lt_result.Text = "添加成功";
                            Response.Write("<script language='javascript'>location.href='controlitem.aspx?id=" + Request["id"].ToString() + "&objid=" + Request["objid"].ToString() + "';</script>");
                        }
                        else
                        {
                            lt_result.Text = "请必须填写姓名和排序";
                        }
                    }
                    else
                    {
                        lt_result.Text = "非法访问";
                        Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/formcontrols/itemedit.cs", Session["wID"].ToString());
            }

        }
    }
}