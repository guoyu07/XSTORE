using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;
using System.Data;
using Creatrue.Common;

namespace tdx.memb.man.Texts
{
    public partial class B2C_tmsg_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    addWant.Text = "<a href=\"B2C_tclass_Add.aspx\" class=\"linkAddType\">";
                    addWant.Text += "<asp:Image ID=\"Image2\" runat=\"server\" ImageUrl=\"/man/images4/wh.png\"  />没有您想要的？点此添加</a>";
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，编辑您的图文类的信息，如： 新闻动态、行业资讯、技术资料等。";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        addWant.Text = "";
                        daohang_Image.Text = commonTool.DaohangImage("daohang_10.jpg");
                        string beforeUrl = "../Goods/B2C_Goods_Add.aspx?nav=true";
                        string downUrl = "../Texts/B2C_Honor_Add.aspx?nav=true";
                        daohang_Button.Text = commonTool.DaohangButton(beforeUrl, downUrl, downUrl);
                    }
                    // and cityID=" + Session["wID"].ToString().Trim() + "                       where cityID=" + Session["wID"].ToString().Trim() + "       
                    DataSet ds = comfun.GetDataSetBySQL("select * from b2c_tclass where c_parent=0 order by c_id; select t_source from b2c_tmsg group by t_source");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        B2C_tmsg.getOneClassTree(Convert.ToInt32(dr["c_id"]), cid);
                    }
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        t_source2.Items.Add(new ListItem(dr["t_source"].ToString(), dr["t_source"].ToString()));
                    }
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_tmsg goods = new B2C_tmsg(id);
                        cid.Items.FindByValue(goods.cno).Selected = true;
                        Image1.ImageUrl = goods.t_gif;
                        t_title.Value = goods.t_title;
                        t_author.Value = goods.t_author;
                        t_source.Value = goods.t_source;
                        t_keyword.Value = goods.t_key;
                        t_des.Value = goods.t_des;
                        t_sort.Value = Convert.IsDBNull(goods.t_sort) ? "" : Convert.ToString(goods.t_sort);
                        t_msg.Value = goods.t_msg;
                        url.Value = goods.t_url;
                        t_filename.Value = goods.t_filename;
                    }
                    else
                    {
                        t_sort.Value = "99";
                        foreach (ListItem item in cid.Items)
                        {
                            if (item.Value != "")
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/B2C_tmsg_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _cid = cid.Value;
                string _t_title = comFunction.NoHTML(t_title.Value);
                string _t_author = comFunction.NoHTML(t_author.Value);
                string _t_source = comFunction.NoHTML(t_source.Value);
                string _t_key = comFunction.NoHTML(t_keyword.Value);
                string _t_des = comFunction.NoHTML(t_des.Value);
                int _sort = 99;
                bool _parse = int.TryParse(t_sort.Value, out  _sort);
                if (!_parse)
                    _sort = 99;
                string _t_sort = _sort.ToString();
                string _t_msg = comFunction.NoSt(t_msg.Value);
                string _t_filename = t_filename.Value;
                int _t_isUrl = 0;
                string _t_url = comFunction.NoHTML(url.Value);
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
                if (_cid.Trim() == "")
                {
                    lt_result.Text = "请选择类别！";
                    return;
                }
                if (_t_title.Trim() == "")
                {
                    lt_result.Text = "请输入标题！";
                    return;
                }
                if (_t_msg.Trim() == "")
                {
                    lt_result.Text = "请输入内容！";
                    return;
                }
                if (_t_title.Length > 255)
                {
                    lt_result.Text = "标题的字符数不能超过255！";
                    return;
                }
                if (_t_author.Length > 10)
                {
                    lt_result.Text = "作者的字符数不能超过10！";
                    return;
                }
                if (_t_source.Length > 10)
                {
                    lt_result.Text = "出处的字符数不能超过10！";
                    return;
                }
                if (_t_des.Length > 255)
                {
                    lt_result.Text = "简介的字符数不能超过255！";
                    return;
                }

                if (Request["id"] != null)
                {
                    try
                    {
                        B2C_tmsg goods = new B2C_tmsg(Convert.ToInt32(Request["id"]));
                        goods.cno = _cid;
                        goods.t_title = _t_title;
                        goods.t_author = _t_author;
                        goods.t_source = _t_source;
                        goods.t_key = _t_key;
                        goods.t_des = _t_des;
                        if (_t_gif != "")
                        {
                            goods.t_gif = _t_gif;
                        }
                        goods.t_msg = _t_msg;
                        goods.t_filename = _t_filename;
                        goods.t_isUrl = _t_isUrl;
                        goods.t_url = _t_url;
                        goods.t_sort = Convert.ToInt32(_t_sort);

                        goods.Update();
                        lt_result.Text = "修改成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_tmsg_List.aspx';},300);</script>";
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
                        B2C_tmsg goods = new B2C_tmsg();
                        goods.AddNew();
                        goods.cno = _cid;
                        goods.t_title = _t_title;
                        goods.t_author = _t_author;
                        goods.t_source = _t_source;
                        goods.t_key = _t_key;
                        goods.t_des = _t_des;
                        goods.t_gif = _t_gif;
                        goods.t_msg = _t_msg;

                        goods.t_filename = _t_filename;
                        goods.t_isUrl = _t_isUrl;
                        goods.t_url = _t_url;
                        goods.t_sort = Convert.ToInt32(_t_sort);

                        goods.Update();
                        lt_result.Text = "添加成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_tmsg_List.aspx';},300);</script>";

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2C_tmsg_Add.cs", Session["wID"].ToString());
            }
        }
    }
}