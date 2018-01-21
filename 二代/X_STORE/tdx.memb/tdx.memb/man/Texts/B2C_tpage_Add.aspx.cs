using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using tdx.database;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.Texts
{
    public partial class B2C_tpage_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //workAuthentication(263) 
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 编辑您的页面内容。";
                    add_leib.Text = "<a href=\"B2C_TPageClass_Add.aspx\" class=\"linkAddType\">";
                    add_leib.Text += "<asp:Image ID=\"Image1\" runat=\"server\" ImageUrl=\"/man/images4/wh.png\"  />没有您想要的？点此添加</a>";
                    string _sql = "select top(3) * from B2C_tpage order by id"; // cityID=" + Session["wID"].ToString().Trim() + "
                    DataTable _tpage = comfun.GetDataTableBySQL(_sql);
                    DataTable classidArry1 = comfun.GetDataTableBySQL("select * from B2C_tpclass where c_parent=0 order by c_id"); // and cityID=" + Session["wID"].ToString().Trim() + "
                    //初始化类别选择框
                    foreach (DataRow dr in classidArry1.Rows)
                    {
                        B2C_tpage.getOneClassTree(Convert.ToInt32(dr["c_id"]), ss_cid);
                    }
                    classidArry1.Dispose();
                    classidArry1 = null;
                    if (Request["id"] != null)
                    {
                        if (Request["nav"] != null && Request["nav"].ToString().Equals("true"))
                        {
                            //简介
                            add_leib.Text = "";
                            ltHead.Text = commonTool.DaohangImage("daohang_8.jpg");
                            ltFoot.Text = commonTool.DaohangButton("../Sets/B2C_menu_Add.aspx?nav=true&parent=1&level=2", "../Goods/B2C_Goods_Add.aspx?&nav=true", "../Goods/B2C_Goods_Add.aspx?&nav=true");
                        }
                        B2C_tpage cate = new B2C_tpage(Convert.ToInt32(Request["id"]));

                        txt_gtitle.Value = cate.gtitle;
                        txt_gfile.Value = cate.gfile;
                        txtbody.Value = cate.gcontent;
                        foreach (ListItem item in ss_cid.Items)
                        {
                            if (item.Value == cate.cno)
                                item.Selected = true;
                        }
                        t_title.Value = cate.g_title;
                        t_keyword.Value = cate.g_key;
                        t_des.Value = cate.g_des;
                        t_url.Value = cate.g_url;
                        t_r1.Value = cate.g_r1;
                        t_r2.Value = cate.g_r2;
                        txt_g_sort.Value = cate.g_sort.ToString();
                        Image1.ImageUrl = cate.ggif;

                        if (cate.g_isSys > 0)
                        {
                            txt_gtitle.Attributes.Add("readonly", "readonly");
                            ss_cid.Attributes.Add("readonly", "readonly");
                        }
                    }
                    else
                    {
                        if (Request["nav"] != null && Request["nav"].ToString().Equals("true"))
                        {
                            //简介
                            add_leib.Text = "";
                            ltHead.Text = commonTool.DaohangImage("daohang_8.jpg");
                            ltFoot.Text = commonTool.DaohangButton("../Sets/B2C_menu_Add.aspx?nav=true&parent=1&level=2", "../Goods/B2C_Goods_Add.aspx?&nav=true", "../Goods/B2C_Goods_Add.aspx?&nav=true");

                            string _id = _tpage.Rows[0]["id"].ToString();
                            B2C_tpage cate = new B2C_tpage(Convert.ToInt32(_id));
                            txt_gtitle.Value = cate.gtitle;
                            txt_gfile.Value = cate.gfile;
                            txtbody.Value = cate.gcontent;
                            ss_cid.Items.FindByValue(cate.cno).Selected = true;
                            t_title.Value = cate.g_title;
                            t_keyword.Value = cate.g_key;
                            t_des.Value = cate.g_des;
                            t_url.Value = cate.g_url;
                            t_r1.Value = cate.g_r1;
                            t_r2.Value = cate.g_r2;
                            txt_g_sort.Value = cate.g_sort.ToString();
                            Image1.ImageUrl = cate.ggif;
                            if (cate.g_isSys > 0)
                            {
                                txt_gtitle.Attributes.Add("readonly", "readonly");
                                ss_cid.Attributes.Add("readonly", "readonly");
                            }
                        }

                    }
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/texts/B2C_tpage_Add.cs", Session["wID"].ToString());
                }
            }
        }

        protected void Button1_ServerClick(System.Object sender, System.EventArgs e)
        {
            //workAuthentication(263)
            //'  添加类别
            //int _newid = 0;
            //if (pageid.Value != "")
            //{
            //    _newid = Convert.ToInt32(pageid.Value);
            //}
            try
            {
                string _gtitle = comFunction.NoHTML(txt_gtitle.Value);
                string _gfile = comFunction.NoHTML(txt_gfile.Value);
                string _gcontent = txtbody.Value;
                int _views = 0;
                string _cid = ss_cid.Value;
                int _t_isurl = 0;

                string _t_url = comFunction.NoHTML(t_url.Value);
                string _t_title = comFunction.NoHTML(t_title.Value);
                string _t_key = t_keyword.Value;
                string _t_des = comFunction.NoHTML(t_des.Value);

                string _t_r1 = t_r1.Value;
                string _t_r2 = t_r2.Value;
                int _t_g_sort = 99;
                bool _parse = int.TryParse(txt_g_sort.Value, out _t_g_sort);
                if (!_parse)
                    _t_g_sort = 99;
                //

                if (_gtitle.Trim() == "")
                {
                    lt_result.Text = "请输入标题";
                    return;
                }
                if (_gcontent.Trim() == "")
                {
                    lt_result.Text = "请输入内容";
                    return;
                }
                if (_gtitle.Length > 255)
                {
                    lt_result.Text = "标题的字符数不能超过255！";
                    return;
                }
                string _t_gif = t_gif.Value;
                if (_t_gif != "")
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
                        if (up.UploadPic(t_gif) != 0)
                        {
                            _t_gif = up.getTargetFilename();
                        }
                    }
                    finally { up = null; }
                }

                if (Request["id"] != null)
                {
                    try
                    {
                        B2C_tpage cate = new B2C_tpage(Convert.ToInt32(Request["id"]));

                        cate.gtitle = _gtitle;
                        cate.gfile = _gfile;
                        cate.gcontent = _gcontent;
                        cate.cno = _cid;
                        cate.g_isurl = _t_isurl;
                        cate.g_url = _t_url;
                        cate.g_title = _t_title;
                        cate.g_key = _t_key;
                        cate.g_des = _t_des;
                        cate.g_r1 = _t_r1;
                        cate.g_r2 = _t_r2;
                        cate.g_sort = _t_g_sort;
                        if (_t_gif != "")
                        {
                            cate.ggif = _t_gif;
                        }

                        cate.Update();
                        lt_result.Text = "修改成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_tpage_List.aspx';},300);</script>";
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

                        B2C_tpage cate = new B2C_tpage();
                        cate.Addnew();

                        cate.gtitle = _gtitle;
                        cate.gfile = _gfile;
                        cate.gcontent = _gcontent;
                        cate.cno = _cid;
                        cate.g_isurl = _t_isurl;
                        cate.g_url = _t_url;
                        cate.g_title = _t_title;
                        cate.g_key = _t_key;
                        cate.g_des = _t_des;
                        cate.g_r1 = _t_r1;
                        cate.g_r2 = _t_r2;
                        cate.g_sort = _t_g_sort;
                        cate.ggif = _t_gif;

                        cate.Update();
                        lt_result.Text = "增加成功！";//修改过
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_tpage_List.aspx';},300);</script>";

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/texts/B2C_tpage_Add.cs", Session["wID"].ToString());
            }
        }
    }
}