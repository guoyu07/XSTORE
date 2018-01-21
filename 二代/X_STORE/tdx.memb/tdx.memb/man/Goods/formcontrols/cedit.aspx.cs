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
    public partial class cedit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null && Request["objid"] != null)
                    {
                        DataTable dt = control_key.GetList("*", "id=" + Request["id"].ToString());
                        if (dt.Rows.Count > 0)
                        {
                            DataTable dtDict = control_dict.GetList("id,name", "id=" + dt.Rows[0]["type_id"].ToString());
                            if (dtDict.Rows.Count > 0)
                            {
                                leixing.Text = dtDict.Rows[0]["name"].ToString();
                            }
                            name.Value = dt.Rows[0]["name"].ToString();
                            sort.Value = dt.Rows[0]["sort"].ToString();
                            //  xiugaianniu.Text = "<a href=\"" + "cedit.aspx?wid=" + Request["wid"].ToString() + "&id=" + dt.Rows[0]["id"].ToString() + "\">修改表单信息</a>";
                        }
                        else
                        {
                            //没找到就回到之前的链接
                            lt_result.Text = "请正确选择要编辑的表单项";
                            Response.Write("<script language='javascript'>location.href='controlsList.aspx?id=" + Request["objid"].ToString() + "';</script>");
                            return;

                        }



                    }
                    else
                    {
                        if (Request["objid"] != null)
                        {
                            lt_result.Text = "请正确选择要编辑的表单项";
                            Response.Write("<script language='javascript'>location.href='controlsList.aspx?id=" + Request["objid"].ToString() + "';</script>");
                            return;
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                            return;
                        }


                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "memb/formcontrols/cedit.cs", Session["wID"].ToString());
                }
            }
        }

        protected void save(object sender, EventArgs e)
        {

            try
            {
                if (Request["id"] != null && Request["objid"] != null)
                {
                    control_key ck = new control_key(Convert.ToInt32(Request["id"].ToString()));
                    if (!string.IsNullOrEmpty(name.Value) && !string.IsNullOrEmpty(sort.Value))
                    {
                        try
                        {
                            ck.name = name.Value;
                            int.TryParse(sort.Value, out ck.sort);
                            ck.Update();
                            lt_result.Text = "修改成功";
                            Response.Write("<script language='javascript'>location.href='controlsList.aspx?id=" + Request["objid"].ToString() + "';</script>");
                        }
                        catch (System.Exception exe)
                        {
                            comfun.ChuliException(exe, "memb/formcontrols/cedit.cs", Session["wID"].ToString());
                            lt_result.Text = "修改失败";
                            Response.Write("<script language='javascript'>location.href='controlsList.aspx?id=" + Request["objid"].ToString() + "';</script>");
                        }

                    }
                }
                else
                {
                    if (Request["objid"] != null)
                    {
                        lt_result.Text = "请正确选择要编辑的表单项";
                        Response.Write("<script language='javascript'>location.href='controlsList.aspx?id=" + Request["objid"].ToString() + "';</script>");
                        return;
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                        return;
                    }


                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "memb/formcontrols/cedit.cs", Session["wID"].ToString());
            }
        }
    }
}