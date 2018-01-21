using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Texts
{
    public partial class vote_Bigpic_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>在这里，编辑您的投票项目信息。";
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        DataTable Album = comfun.GetDataTableBySQL("select * from vote_bigpic where id=" + id);
                        _name.Value = Album.Rows[0]["name"].ToString();
                        Image1.ImageUrl = Album.Rows[0]["picurl"].ToString();
                        active.Value = Album.Rows[0]["isactive"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/vote_Bigpic_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string name = comFunction.NoHTML(_name.Value);
                string _picurl = _pic.Value;
                int _active = int.Parse(active.Value);
                //int cityID = int.Parse(Session["wID"].ToString());

                if (name == "" || name.Length > 200)
                {
                    lt_result.Text = "项目名称不能为空！且长度不可超过200";
                    return;
                }
                //添加图片
                if (_picurl != "")
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
                        if (up.UploadPicAsMul3(_pic) != 0)
                        {
                            _picurl = up.getTargetFilename();
                        }
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
                if (Request["id"] != null)
                {
                    try
                    {
                        int _id = Convert.ToInt32(Request["id"]);
                        DataTable Album = comfun.GetDataTableBySQL("select * from vote_bigpic where id=" + _id);
                        string updateSql = string.Empty;
                        if (_picurl != "")
                        {
                            updateSql = @"update vote_bigpic set name='" + name + "',picurl='" + _picurl + "',isactive=" + _active + " where id=" + _id;
                        }
                        else
                        {
                            updateSql = @"update vote_bigpic set name='" + name + "',isactive=" + _active + " where id=" + _id;
                        }
                        int iret = comfun.UpdateBySQL(updateSql);
                        if (iret == 1)
                        {
                            lt_result.Text = "修改成功！";
                        }
                        else
                        { lt_result.Text = "修改失败！"; }
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='vote_Bigpic_List.aspx';},300);</script>";

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
                        string insertSql = @"insert into vote_bigpic(name,picurl,isactive) " + //,cityID
                            "values('" + name + "','" + _picurl + "','" + _active + "')"; //," + cityID + "
                        int iret = comfun.InsertBySQL(insertSql);
                        if (iret == 1)
                        {
                            lt_result.Text = "添加成功！";
                        }
                        else
                        {
                            lt_result.Text = "添加失败！";
                        }
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='vote_Bigpic_List.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/vote_Bigpic_Add.cs", Session["wID"].ToString());
            }
        }
    }
}