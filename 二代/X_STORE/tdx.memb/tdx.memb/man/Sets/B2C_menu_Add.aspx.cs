using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.Common;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.Sets
{
    public partial class B2C_menu_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>在这里设置您的微官网首页显示的栏目（包括栏目图标、栏目名称、跳转连接等），如右图。<br/><span class='tipsTitle'>特别提醒：</span>  栏目图标是否需要，根据您选择的网站模板的来决定。";

                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        daohang_Image.Text = commonTool.DaohangImage("daohang_7.jpg");
                        string beforeUrl = "../Ads/B2C_ADS_Add3.aspx?nav=true";
                        string nextUrl = "../Texts/B2C_tpage_Add.aspx?nav=true";
                        daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);

                    }

                    lt_funcSelectBox.Text = commonTool.funcSelectBox("");

                    DataTable dt = comfun.GetDataTableBySQL("select * from b2c_menu where c_parent=0 and c_isactive=1 and c_isdel=0");// and cityid=" + Session["wID"].ToString().Trim()
                    class_parent.DataSource = dt;
                    class_parent.DataTextField = "c_name";
                    class_parent.DataValueField = "c_id";
                    class_parent.DataBind();

                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_menu tt = new B2C_menu(id);
                        txtmc.Value = tt.c_name;
                        Image1.ImageUrl = tt.c_gif;
                        txturl.Value = tt.c_url;
                        txtpx.Value = Convert.IsDBNull(tt.c_sort) ? "" : Convert.ToString(tt.c_sort);
                        txtms.Value = tt.c_des;
                        class_parent.Value = Convert.ToString(tt.c_parent);//Convert.IsDBNull(tt.c_parent) ? "" : Convert.ToString(tt.c_parent);
                        class_level.Value = Convert.IsDBNull(tt.c_level) ? "" : Convert.ToString(tt.c_level);


                    }
                    else
                    {
                        if (Request["parent"] != null)
                        {
                            class_parent.Value = Request["parent"].ToString();
                        }
                        if (Request["level"] != null)
                        {
                            class_level.Value = Request["level"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/sets/B2C_menu_Add.cs", Session["wID"].ToString());
                }
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            string _mc = comFunction.NoHTML(txtmc.Value);
            string _gif = txtgif.Value;
            string _url = comFunction.NoSt(txturl.Value);
            int _px = 1;
            bool _parse = int.TryParse(txtpx.Value, out _px);
            if (!_parse)
                _px = 1;
            string _ms = comFunction.NoSt(txtms.Value);
            int classparent = Convert.IsDBNull(class_parent.Value) ? 0 : Convert.ToInt32((string.IsNullOrEmpty(class_parent.Value) ? "0" : class_parent.Value));
            int classlevel = Convert.IsDBNull(class_level.Value) ? 1 : Convert.ToInt32((string.IsNullOrEmpty(class_level.Value) ? "1" : class_level.Value));

            if (_mc == "")
            {
                lt_result.Text = "栏目名称不能为空！";
                return;
            }
            if (_url == "")
            {
                lt_result.Text = "  跳转链接不能为空！";
                return;
            }
            if (_mc.Length > 200)
            {
                lt_result.Text = "栏目名称字符数不能超过200！";
                return;
            }
            if (_url.Length > 1000)
            {
                lt_result.Text = "链接URL字符数不能超过1000！";
                return;
            }
            if (_ms.Length > 500)
            {
                lt_result.Text = "描述字符数不能超过500！";
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
                    if (up.UploadPicAsMul(txtgif) != 0)
                    {
                        _gif = up.getTargetFilename();
                    }
                    else
                        _gif = "";
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

                    int id = Convert.ToInt32(Request["id"]);
                    B2C_menu tt = new B2C_menu(id);
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
                    lt_result.Text = "修改成功.";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        return;
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_menu_List.aspx';},300);</script>";

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

                    B2C_menu tt = new B2C_menu();
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
                    lt_result.Text = "添加成功.";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        return;
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_menu_List.aspx';},300);</script>";


                }
                catch (Exception ex)
                {
                    lt_result.Text = ex.Message;
                }
            }

        }
    }
}