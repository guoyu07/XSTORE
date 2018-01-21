using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.Common;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Sets
{
    public partial class B2C_menu2_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>您可以在此给您的公众号设置自定义菜单。如右图所示。";
                    lt_friendly.Text += "<br/>点击菜单可以连接本站内容，也可跳转至站外连接。";
                    lt_friendly.Text += "<br/>点击菜单时弹出说明信息（如右图）。通过此种方式，帮助您统计浏览者微信信息。";

                    int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        int wx_wid = Convert.ToInt32(Session["wid"]);
                        daohang_Image.Text = commonTool.DaohangImage("daohang_3.jpg");
                        string beforeUrl = "../Ads/Welcome_Ads_Edit.aspx?nav=true";//../Texts/wx_keys_Add.aspx?nav=true
                        string nextUrl = "../Sets/wxConfig_mb.aspx?nav=true";//FinishDaoHang.aspx?nav=true
                        daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);

                        string levels = "1";
                        string _sql = "select top 1 * from wx_mp where wid=" + Session["wID"].ToString() + " order by id";
                        DataTable _daoHang = comfun.GetDataTableBySQL(_sql);
                        //如果存在公众号
                        if (_daoHang != null && _daoHang.Rows.Count > 0)
                        {
                            _wid = Convert.ToInt32(_daoHang.Rows[0]["id"].ToString());

                            string superSQL = " c_level=" + levels + " and cityid=" + _wid;
                            string _dzd = " *,(select c_name from B2C_menu2 as bm where bm.c_id=B2C_menu2.c_parent and bm.cityID=B2C_menu2.cityID) as cname   ";

                            DataTable dt = B2C_menu2.GetList(_dzd, superSQL);
                            if (dt != null && dt.Rows.Count > 0)//存在公众号菜单，则跳转到下一步
                            {
                                lt_result.Text = "<script language='javascript'>setTimeout(function(){location.href='../Sets/wxConfig_mb.aspx?nav=true';},300);</script>";
                            }
                        }
                    }

                    if (_wid == 0)
                    {
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        {
                            DataTable _dt = comfun.GetDataTableBySQL(string.Format("select top 1 * from wx_mp where wid={0} order by id desc", Session["wid"]));
                            if (_dt.Rows.Count == 0)
                            {
                                string na = "?nav=true";
                                lt_result.Text = "请添加具体要操作的公众号！";
                                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../Sets/wx_dh_mp_sys.aspx" + na + "';},300);</script>";
                            }
                            else
                            {

                                int wx_id = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                                string beforeUrl = string.Format("../Ads/Welcome_Ads_Edit.aspx?nav=true&wid={0}", wx_id);
                                string nextUrl = "../Sets/wxConfig_mb.aspx?nav=true";
                                daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);
                                Response.Write("<script language='javascript'>location.href='../Sets/B2C_menu2_Add.aspx?wid=" + wx_id + "&nav=true&parent=0&level=1" + "';</script>");

                            }
                        }
                        else
                        {
                            lt_result.Text = "请先选择具体要操作的公众号！";
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../Sets/wx_mp_list.aspx';},300);</script>";
                        }
                        return;
                    }
                    else
                    {
                        try
                        {
                            wx_mp wxmp = new wx_mp(_wid);
                            lt_mp.Text = wxmp.wx_nichen;
                        }
                        catch (Exception ex)
                        {
                            lt_result.Text = "请先选择具体要操作的公众号！";
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../Sets/wx_mp_list.aspx';},300);</script>";
                            return;
                        }
                    }

                    lt_funcSelectBox.Text = commonTool.funcSelectBox("");
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_menu2 tt = new B2C_menu2(id);
                        txtmc.Value = tt.c_name;
                        Image1.ImageUrl = tt.c_gif;
                        txturl.Value = tt.c_url;
                        txtpx.Value = Convert.IsDBNull(tt.c_sort) ? "" : Convert.ToString(tt.c_sort);
                        txtms.Value = tt.c_des;
                        class_parent.Value = Convert.ToString(tt.c_parent);//Convert.IsDBNull(tt.c_parent) ? "" : Convert.ToString(tt.c_parent);                   
                        class_level.Value = Convert.IsDBNull(tt.c_level) ? "" : Convert.ToString(tt.c_level);

                        try
                        {
                            B2C_menu2 parent_cate = new B2C_menu2(Convert.ToInt32(tt.c_parent));
                            parentname.Text = parent_cate.c_name;
                            parent_cate = null;
                        }
                        catch (Exception ex)
                        {
                            parentname.Text = "";
                        }

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
                        try
                        {
                            if (Request["parent"] != null)
                            {
                                int parentID = Convert.ToInt32(Request["parent"]);
                                B2C_menu2 parent_cate = new B2C_menu2(parentID);
                                parentname.Text = parent_cate.c_name;
                                parent_cate = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            parentname.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/sets/B2C_menu2_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);
                if (Request["nav"] != null && Request["nav"].ToString() == "true")
                {
                    string _sql = "select top 1 * from wx_mp where wid=" + Session["wID"].ToString() + " order by id";
                    DataTable _daoHang = comfun.GetDataTableBySQL(_sql);
                    if (_daoHang != null && _daoHang.Rows.Count > 0)
                    {
                        _wid = Convert.ToInt32(_daoHang.Rows[0]["id"].ToString());
                    }
                }

                if (_wid == 0)
                {
                    lt_result.Text = "请先选择具体要操作的公众号！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../Sets/wx_mp_list.aspx';},300);</script>";
                    return;
                }
                else
                {
                    try
                    {
                        wx_mp wxmp = new wx_mp(_wid);
                        lt_mp.Text = "公众号: " + wxmp.wx_nichen;
                    }
                    catch (Exception ex)
                    {
                        //Response.Write("<script language='javascript'>alert('请先选择具体要操作的公众号！" + ex.Message.Replace("'", "") + "');location.href='/sets/wx_mp_list.aspx';</script>");
                        lt_result.Text = "请先选择具体要操作的公众号！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../Sets/wx_mp_list.aspx';},300);</script>";
                        return;
                    }
                }


                string _mc = comFunction.NoHTML(txtmc.Value);
                string _gif = txtgif.Value;
                string _url = comFunction.NoSt(txturl.Value);
                int _px = 1;
                int.TryParse(txtpx.Value, out _px);
                string _ms = comFunction.NoSt(txtms.Value);
                int classparent = string.IsNullOrEmpty(class_parent.Value) ? 0 : Convert.ToInt32(class_parent.Value);
                int classlevel = string.IsNullOrEmpty(class_level.Value) ? 1 : Convert.ToInt32(class_level.Value);

                if (_mc == "")
                {
                    lt_result.Text = "菜单名称不能为空！";
                    return;
                }
                if (_mc.Length > 200)
                {
                    lt_result.Text = "菜单名称字数不能超过200！";
                    return;
                }
                if (_url.Length > 2000)
                {
                    lt_result.Text = "链接字符数不能超过2000！";
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
                        B2C_menu2 tt = new B2C_menu2(id);
                        tt.c_id = id;

                        tt.c_name = _mc;
                        tt.c_url = _url;
                        if (_gif != "")
                        {
                            tt.c_gif = _gif;
                        }
                        tt.c_sort = _px;
                        tt.c_des = _ms;
                        tt.cityid = _wid;
                        tt.Update();
                        lt_result.Text = "修改成功.";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_menu2_List.aspx?wid=" + _wid + "';},300);</script>";

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
                        if (string.IsNullOrEmpty(_gif))
                        {
                            lt_result.Text = "必须上传图片！";
                            return;
                        }

                        B2C_menu2 tt = new B2C_menu2();
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
                        tt.cityid = _wid;
                        tt.Update();
                        lt_result.Text = "添加成功.";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_menu2_List.aspx?wid=" + _wid + "';},300);</script>";

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/sets/B2C_menu2_Add.cs", Session["wID"].ToString());
            }
        }
    }
}