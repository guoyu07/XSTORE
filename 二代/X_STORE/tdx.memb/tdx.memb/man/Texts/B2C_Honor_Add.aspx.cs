using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;
using Creatrue.Common;
using System.Data;

namespace tdx.memb.man.Texts
{
    public partial class B2C_Honor_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //userAuthentication(12);
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，编辑您的图片，如： 企业风采、企业场景等展示图片";
                    addWant.Text = "<a href=\"B2C_Hclass_Add.aspx\" class=\"linkAddType\">";
                    addWant.Text += "<asp:Image ID=\"Image2\" runat=\"server\" ImageUrl=\"/man/images4/wh.png\" />没有您想要的？点此添加</a>";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        daohang_Image.Text = commonTool.DaohangImage("daohang_11.jpg");
                        string beforeUrl = "../Texts/B2C_tmsg_Add.aspx?nav=true";
                        string nextUrl = "../Texts/FinishDaoHang.aspx?nav=true";
                        daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);
                        addWant.Text = "";
                    }
                    DataSet ds = comfun.GetDataSetBySQL("select * from B2C_Hclass where c_parent=0 order by c_id"); //  and cityID=" + Session["wID"].ToString().Trim() + "
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        B2C_Hclass.getOneClassTree(Convert.ToInt32(dr["c_id"]), cid);
                    }
                    ds.Dispose();
                    ds = null;

                    //t_author.Value = Convert.ToString(Session["admin_user"]);//作者，即当前登录用户
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_Honor goods = new B2C_Honor(id);
                        foreach (ListItem item in cid.Items)
                        {
                            if (item.Value == goods.cno)
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                        t_title.Value = goods.P_no;
                        t_author.Value = goods.P_name;
                        t_wdes.Value = goods.P_des;
                        Image1.ImageUrl = goods.P_url;
                        t_w_sort.Value = goods.P_sort.ToString();
                        t_wdate.Value = goods.P_wdate.ToString();
                        wtab.Value = goods.P_tab;
                        wrow.Value = goods.P_row;
                    }
                    else
                    {
                        t_w_sort.Value = "99";
                        foreach (ListItem item in cid.Items)
                        {
                            if (item.Value != "")
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                        t_wdate.Value = System.DateTime.Now.ToShortDateString();
                        if (null != Request["ptab"])
                            wtab.Value = Request["ptab"].ToString();
                        if (null != Request["prow"])
                            wrow.Value = Request["prow"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/B2C_Honor_Add.aspx", Session["wID"].ToString());
                }
            }
        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {

            try
            {
                string _cno = cid.Value;
                string _t_title = comFunction.NoHTML(t_title.Value); //文档号
                string _t_author = comFunction.NoHTML(t_author.Value); //文档名称
                string _t_source_url = ""; //文档路径
                string _t_wdes = comFunction.NoHTML(t_wdes.Value);//简介
                int _t_wsort = 99;
                bool _parse = int.TryParse(t_w_sort.Value, out _t_wsort);
                if (!_parse)
                    _t_wsort = 99;

                string _t_wdate = comFunction.NoHTML(t_wdate.Value); //建档时间
                string _wtab = comFunction.NoHTML(wtab.Value);//关联表格
                string _wrow = comFunction.NoHTML(wrow.Value);//关联字段
                if (_cno == "")
                {
                    lt_result.Text = "必须选择相册类别！";
                    return;

                }
                if (_t_author == "")
                {
                    lt_result.Text = "图片名称不能为空！";
                    return;
                }
                if (_t_author.Length > 200)
                {
                    lt_result.Text = "图片名称的字符数不能超过200！";
                    return;
                }
                if (_t_wdes.Length > 300)
                {
                    lt_result.Text = "简介的字符数不能超过300！";
                    return;
                }

                //判断是否上传...
                string _t_source_file = comFunction.NoHTML(t_source_file.Value.Trim());
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
                string _t_ftype = "";
                string _t_fweight = "";
                if (_t_source_url.Trim() != "")
                {
                    System.IO.FileInfo f = new System.IO.FileInfo(Server.MapPath("/") + _t_source_url);
                    _t_ftype = f.Name.Substring(f.Name.LastIndexOf(".") + 1, f.Name.Length - f.Name.LastIndexOf(".") - 1).ToLower();
                    _t_fweight = (f.Length / 1000) + "K";
                }


                if (Request["id"] != null)
                {
                    try
                    {
                        B2C_Honor goods = new B2C_Honor(Convert.ToInt32(Request["id"]));
                        goods.cno = _cno;
                        goods.P_no = _t_title;
                        goods.P_name = _t_author;
                        if (_t_source_url != "")
                        {
                            goods.P_url = _t_source_url;
                        }
                        goods.P_ftype = _t_ftype;
                        goods.P_fweight = _t_fweight;
                        goods.P_des = _t_wdes;
                        goods.P_sort = _t_wsort;
                        goods.P_tab = _wtab;
                        goods.P_row = _wrow;
                        goods.P_wdate = Convert.ToDateTime(_t_wdate);

                        goods.Update();
                        lt_result.Text = "修改成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        {
                            return;
                        }
                        else
                        {
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Honor_List.aspx';},300);</script>";
                        }
                    }
                    catch
                    {
                        lt_result.Text = "修改失败！";
                    }
                }
                else
                {
                    try
                    {
                        B2C_Honor goods = new B2C_Honor();
                        goods.AddNew();
                        goods.cno = _cno;
                        goods.P_no = _t_title;
                        goods.P_name = _t_author;
                        goods.P_url = _t_source_url;
                        goods.P_ftype = _t_ftype;
                        goods.P_fweight = _t_fweight;
                        goods.P_des = _t_wdes;
                        goods.P_sort = _t_wsort;
                        goods.P_tab = _wtab;
                        goods.P_row = _wrow;
                        goods.P_wdate = Convert.ToDateTime(_t_wdate);

                        goods.Update();
                        lt_result.Text = "添加成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Honor_List.aspx';},300);</script>";

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = "添加失败！" + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2C_Honor_Add.aspx", Session["wID"].ToString());
            }
        }
    }
}