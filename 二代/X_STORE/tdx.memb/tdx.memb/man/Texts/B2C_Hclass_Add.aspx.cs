using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;
using System.Data;

namespace tdx.memb.man.Texts
{
    public partial class B2C_Hclass_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 编辑您的图片类别，如：企业风采、企业场景等。";
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_Hclass tt = new B2C_Hclass(id);
                        txtmc.Value = tt.c_name;
                        Image1.ImageUrl = tt.c_gif;
                        txturl.Value = tt.c_url;
                        txtpx.Value = Convert.IsDBNull(tt.c_sort) ? "" : Convert.ToString(tt.c_sort);
                        txtms.Value = tt.c_des;
                        class_parent.Value = Convert.IsDBNull(tt.c_parent) ? "" : Convert.ToString(tt.c_parent);
                        class_level.Value = Convert.IsDBNull(tt.c_level) ? "" : Convert.ToString(tt.c_level);
                    }
                    else
                    {
                        if (Request["parent"] != null)
                        {
                            class_parent.Value = Request["parent"];
                        }
                        if (Request["level"] != null)
                        {
                            class_level.Value = Request["level"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/B2C_Hclass_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _mc = comFunction.NoHTML(txtmc.Value);
                string _gif = txtgif.Value;
                string _url = comFunction.NoHTML(txturl.Value);
                int _px = 99;
                bool _parse = int.TryParse(txtpx.Value, out _px);
                if (!_parse)
                    _px = 99;
                string _ms = comFunction.NoSt(txtms.Value);
                int classparent = Convert.IsDBNull(class_parent.Value) ? 0 : Convert.ToInt32(class_parent.Value);
                int classlevel = Convert.IsDBNull(class_level.Value) ? 1 : Convert.ToInt32(class_level.Value);

                if (_mc == "")
                {
                    lt_result.Text = "类别名称不能为空!";
                    return;
                }
                if (_mc.Length > 200)
                {
                    lt_result.Text = "类别名称的字符数不能超过200！";
                    return;
                }

                if (_ms.Length > 300)
                {
                    lt_result.Text = "描述字符数不能超过300！";
                    return;
                }
                //添加图片

                if (_gif != "")
                {
                    comUpload up = new comUpload();
                    up.clearFileType();
                    up.addFileType("jpg");
                    up.addFileType("jpeg");
                    up.addFileType("gif");
                    up.addFileType("png");
                    up.addFileType("bmp");

                    try
                    {
                        if (up.UploadPic(txtgif) != 0)
                        {
                            _gif = up.getTargetFilename();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                string _dzd = " c_name ";
                string _sql = " c_name='" + _mc + "'";
                DataTable dt = B2C_Hclass.GetList(_dzd, _sql);

                if (Request["id"] != null)
                {
                    try
                    {
                        if (dt.Rows.Count <= 1)
                        {
                            int id = Convert.ToInt32(Request["id"]);
                            B2C_Hclass tt = new B2C_Hclass(id);
                            tt.c_id = id;

                            tt.c_name = _mc;
                            tt.c_url = _url;
                            if (_gif != "")
                            {
                                tt.c_gif = _gif;
                            }
                            tt.c_sort = _px;
                            tt.c_des = _ms;
                            tt.Update();
                            lt_result.Text = "修改成功！";
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Hclass_List.aspx';},300);</script>";
                        }
                        else
                        {
                            lt_result.Text = "已经存在相同的类别名称！";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    try
                    {
                        if (dt.Rows.Count <= 0)
                        {
                            B2C_Hclass tt = new B2C_Hclass();
                            tt.Addnew();
                            tt.c_parent = classparent;
                            tt.c_level = classlevel;
                            tt.c_name = _mc;
                            tt.c_url = _url;
                            if (_gif != "")
                            {
                                tt.c_gif = _gif;
                            }
                            tt.c_sort = _px;
                            tt.c_des = _ms;
                            tt.Update();
                            lt_result.Text = "添加成功！";
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Hclass_List.aspx';},300);</script>";
                        }
                        else
                        {
                            lt_result.Text = "已经存在相同的类别名称！";
                        }
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2C_Hclass_Add.cs", Session["wID"].ToString());
            }
        }
    }
}