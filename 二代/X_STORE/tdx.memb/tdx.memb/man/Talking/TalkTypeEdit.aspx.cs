using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.Model;
using tdx.database;
using WP_category = tdx.database.TK_发帖类别表;

namespace tdx.memb.man.Talking
{
    public partial class TalkTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    string _sql = "select top(3) * from B2C_tpage order by id"; // where cityID=" + Session["wID"].ToString().Trim() + "
                    DataTable _tpage = comfun.GetDataTableBySQL(_sql);
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        database.TK_发帖类别表 tt = new database.TK_发帖类别表(id);
                        txtmc.Value = tt.类别名;
                        imgupFirstScreenPicture.Src = tt.图片;
                        txturl.Value = tt.c_url;
                        txtpx.Value = Convert.IsDBNull(tt.c_sort) ? "99" : Convert.ToString(tt.c_sort);
                        txtms.Value = tt.c_des;
                        class_parent.Value = Convert.IsDBNull(tt.c_parent) ? "" : Convert.ToString(tt.c_parent);
                        class_level.Value = Convert.IsDBNull(tt.c_level) ? "" : Convert.ToString(tt.c_level);
                        try
                        {
                            database.WP_category parent_cate = new database.WP_category(Convert.ToInt32(tt.c_parent));
                            parent_cate = null;
                        }
                        catch (Exception ex)
                        {
                            ;// lt_result.Text = ex.Message;  
                        }
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
                        try
                        {
                            if (Request["parent"] != null)
                            {
                                int parentID = Convert.ToInt32(Request["parent"]);
                                database.WP_category parent_cate = new database.WP_category(parentID);
                                parent_cate = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            // lt_result.Text = ex.Message;  
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "TalkTypeEdit.cs", Session["wID"].ToString());
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string _t_source_url = ""; //文档路径
            try
            {
                string _mc = comFunction.NoHTML(txtmc.Value);
                string _t_source_file = Creatrue.kernel.comFunction.NoHTML(t_source_file.Value.Trim());
                if (_t_source_file != "")
                {
                    comUpload up = new comUpload();
                    up.clearFileType();//支持pdf、doc、xls、docx、xlsx、jpg、gif
                    up.addFileType("jpg");
                    up.addFileType("gif");
                    up.addFileType("jpeg");
                    up.addFileType("png");
                    up.addFileType("bmp");

                    try
                    {
                        if (up.UploadPic(t_source_file) != 0)
                        {
                            _t_source_file = up.getTargetFilename();
                            _t_source_url = _t_source_file;
                        }
                    }
                    finally { up = null; }
                }
                string _url = comFunction.NoHTML(txturl.Value);
                int _px = 99;
                int.TryParse(string.IsNullOrEmpty(txtpx.Value) ? "99" : Convert.ToString(txtpx.Value), out _px);
                string _ms = comFunction.NoHTML(txtms.Value);
                int classparent = Convert.IsDBNull(class_parent.Value) ? 0 : Convert.ToInt32(class_parent.Value);
                int classlevel = Convert.IsDBNull(class_level.Value) ? 1 : Convert.ToInt32(class_level.Value);

                if (_mc == "")
                {
                    lt_result.Text = "类别名称不能为空！";
                    return;
                }
                if (_mc.Length > 200)
                {
                    lt_result.Text = "类别名称字符数不能超过200！";
                    return;
                }
                if (_ms.Length > 300)
                {
                    lt_result.Text = "描述字符数不能超过200！";
                    return;
                }

                if (Request["id"] != null)
                {
                    try
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        database.TK_发帖类别表 tt = new database.TK_发帖类别表(id);
                        tt.id = id;

                        tt.类别名 = _mc;
                        tt.c_url = _url;
                        if (_t_source_url != "")
                        {
                            tt.图片 = _t_source_url;
                        }
                        tt.c_sort = _px;
                        tt.c_des = _ms;
                        tt.Update();
                        lt_result.Text = "修改成功.";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='TalkTypeList.aspx';},300);</script>";

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
                        if (_t_source_url == "")
                        {
                            MessageBox.Show(this, "请先上传图片！"); return;}
                        database.TK_发帖类别表 tt = new database.TK_发帖类别表();
                        tt.Addnew();
                        tt.c_parent = classparent;
                        tt.c_level = classlevel;
                        tt.类别名 = _mc;
                        tt.c_url = _url;
                        if (_t_source_url != "")
                        {
                            tt.图片 = _t_source_url;
                        }
                        tt.c_sort = _px;
                        tt.c_des = _ms;
                        tt.Update();
                        lt_result.Text = "添加成功.";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='TalkTypeList.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "TalkTypeEdit.cs", Session["wID"].ToString());
            }
        }
    }
}