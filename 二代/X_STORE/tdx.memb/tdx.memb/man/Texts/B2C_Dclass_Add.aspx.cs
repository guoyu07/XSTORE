using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using tdx.database.database;
using System.Data;

namespace tdx.memb.man.Texts
{
    public partial class B2C_Dclass_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    int id = Convert.ToInt32(Request["id"]);
                    B2C_Dclass tt = new B2C_Dclass(id);
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
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            string _mc = txtmc.Value;
            string _gif = txtgif.Value;
            string _url = txturl.Value;
            int _px = Convert.IsDBNull(txtpx.Value) ? 99 : Convert.ToInt32(txtpx.Value);
            string _ms = txtms.Value;
            int classparent = Convert.IsDBNull(class_parent.Value) ? 0 : Convert.ToInt32(class_parent.Value);
            int classlevel = Convert.IsDBNull(class_level.Value) ? 1 : Convert.ToInt32(class_level.Value);
            //添加下载
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
            DataTable dt = B2C_Dclass.GetList(_dzd, _sql);

            if (Request["id"] != null)
            {
                try
                {
                    if (dt.Rows.Count <= 1)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_Dclass tt = new B2C_Dclass(id);
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
                        Response.Write("<script language='javascript'>alert('修改成功！');location.href='B2C_Dclass_List.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('已经存在相同的类别名称！');history.go(-1);</script>");
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
                        B2C_Dclass tt = new B2C_Dclass();
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
                        Response.Write("<script language='javascript'>alert('添加成功！');location.href='B2C_Dclass_List.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('已经存在相同的类别名称！');history.go(-1);</script>");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}