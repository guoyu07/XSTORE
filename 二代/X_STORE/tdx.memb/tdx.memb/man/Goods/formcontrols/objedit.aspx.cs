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
    public partial class objedit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null)
                    {
                        DataTable dt = control_obj.GetList("*", "id=" + Request["id"].ToString());
                        if (dt.Rows.Count > 0)
                        {
                            name.Value = dt.Rows[0]["name"].ToString();
                            miaoshu.Value = dt.Rows[0]["des"].ToString();
                            t_urls.Value = dt.Rows[0]["urls"].ToString();
                        }

                    }
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/formcontrols/objedit.cs", Session["wID"].ToString());
                }
            }
        }

        protected void save(object sender, EventArgs e)
        {
            try
            {
                if (Request["id"] != null)
                {
                    control_obj ck = new control_obj(Convert.ToInt32(Request["id"].ToString()));
                    if (!string.IsNullOrEmpty(name.Value) && !string.IsNullOrEmpty(miaoshu.Value))
                    {
                        try
                        {
                            ck.name = name.Value;
                            ck.des = miaoshu.Value;
                            ck.urls = t_urls.Value.Trim();
                            ck.Update();
                            lt_result.Text = "修改成功";
                            Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                        }
                        catch (System.Exception ex)
                        {
                            lt_result.Text = "修改失败";
                        }

                    }
                    else
                    {
                        lt_result.Text = "两项均为必填项";
                    }
                }
                else
                {
                    control_obj ck = new control_obj();
                    if (!string.IsNullOrEmpty(name.Value) && !string.IsNullOrEmpty(miaoshu.Value))
                    {
                        try
                        {
                            ck.name = name.Value;
                            ck.des = miaoshu.Value;
                            ck.wid = Convert.ToInt32(Session["wid"].ToString());
                            ck.urls = t_urls.Value.Trim();
                            ck.Update();
                            lt_result.Text = "添加成功";
                            Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                        }
                        catch (System.Exception exe)
                        {
                            lt_result.Text = "添加失败";
                            comfun.ChuliException(exe, "man/formcontrols/objedit.cs", Session["wID"].ToString());
                        }

                    }
                    else
                    {
                        lt_result.Text = "两项均为必填项";
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/formcontrols/objedit.cs", Session["wID"].ToString());
            }
        }
    }
}