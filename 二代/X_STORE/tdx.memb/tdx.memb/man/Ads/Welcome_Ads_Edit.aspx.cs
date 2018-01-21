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

namespace tdx.memb.man.Ads
{
    public partial class Welcome_Ads_Edit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小贴士：</span> 在这里，设置网友关注您的公众号时推送的信息，如右图所示。";
                    int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);

                    txtWID.Value = _wid.ToString();

                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        daohang_Image.Text = commonTool.DaohangImage("daohang_2.jpg");
                        string beforeUrl = "../Sets/wx_mp_add.aspx?nav=true";//../Ads/B2C_ADS_Add2.aspx?nav=true&cno=009
                        string nextUrl = "../Sets/B2C_menu2_Add.aspx?nav=true";
                        daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);
                        string _sql = "select top 1 * from wx_mp order by id"; // where wid=" + Session["wID"].ToString() + "
                        DataTable _daoHang = comfun.GetDataTableBySQL(_sql);
                        if (_daoHang != null && _daoHang.Rows.Count > 0)
                        {
                            _wid = Convert.ToInt32(_daoHang.Rows[0]["id"].ToString());
                        }
                    }
                    //                                   and cno='001'              where wid=" + Session["wID"].ToString().Trim() + "     
                    string sql = " (1=1) and cno='001' ";
                    string dzd = " *,(select c_name from B2C_AdClass where B2C_AdClass.c_no=B2C_ADS.cno)as cname ";
                    bindnolist();

                    DataTable bigTable = B2C_ads.getlist(dzd, sql);
                    if (bigTable.Rows.Count > 0)
                    {
                        int _id = 0;
                        _id = Convert.ToInt32(bigTable.Rows[0]["id"].ToString());
                        if (_wid == 0)
                        {
                            commonTool.Show_Have_Url(lt_result, "请先选择具体要操作的公众号！", "/sets/wx_mp_list.aspx", 0);
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
                                commonTool.Show_Have_Url(lt_result, "请先选择具体要操作的公众号！", "/sets/wx_mp_list.aspx", 0);
                                return;
                            }
                        }


                        int id = 0;
                        if (_id != 0)
                        {
                            id = _id;
                            B2C_ads ads = new B2C_ads(id);
                            //selno.Value = ads.cno;
                            selno.Disabled = true;
                            txtname.Value = ads.a_name;
                            Image1.ImageUrl = ads.a_gif;
                            txturl.Value = ads.a_url;
                            txtsort.Value = Convert.IsDBNull(ads.a_sort) ? "" : Convert.ToString(ads.a_sort);
                            txtdes.Value = ads.a_des;

                            if (ads.a_isSys > 1)
                            {
                                txturl.Attributes.Add("readonly", "readonly");
                                txtname.Attributes.Add("readonly", "readonly");
                                selno.Attributes.Add("readonly", "readonly");
                            }
                        }
                        else
                        {
                            selno.Value = "001";
                            selno.Disabled = true;
                        }
                        if (Request["cno"] != null)
                        {
                            string cno = Request["cno"].ToString();
                            selno.Value = cno;
                            selno.Disabled = true;
                        }
                    }
                    else
                    {
                        selno.Value = "001";
                        selno.Disabled = true;
                        txtWID.Value = _wid.ToString();
                        wx_mp wxmp = new wx_mp(_wid);
                        lt_mp.Text = wxmp.wx_nichen;
                    }
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/Ads/Welcome_Ads_Edit.cs", Session["wID"].ToString());
                }
            }
        }


        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            string _sno = "001";// comFunction.NoHTML(selno.Value);
            string _name = comFunction.NoHTML(txtname.Value);
            string _fimg = fileimg.Value;
            string _url = txturl.Value == "" ? "http://www.tdx.cn/appv/index.aspx" : txturl.Value;
            DateTime _stime = DateTime.Now;
            DateTime _otime = DateTime.Now;
            int _sort = Convert.IsDBNull(txtsort.Value) ? 0 : Convert.ToInt32(txtsort.Value);
            string _des = comFunction.NoSt(txtdes.Value);
            int _wid = Convert.ToInt32(txtWID.Value);

            string sql = " (1=1) and cno='001'";// where wid=" + Session["wID"].ToString().Trim() + " and cityid in (select id from wx_mp)
            string dzd = " *,(select c_name from B2C_AdClass where B2C_AdClass.c_no=B2C_ADS.cno)as cname ";

            DataTable bigTable = B2C_ads.getlist(dzd, sql);
            int _id = 0;
            if (bigTable.Rows.Count > 0)
                _id = Convert.ToInt32(bigTable.Rows[0]["id"].ToString());

            if (_name.Trim() == "")
            {
                lt_result.Text = "请输入名称！";
                return;
            }
            if (txtname.Value.Length > 50)
            {
                lt_result.Text = "标题字符数不能超过50!";
                return;
            }
            //if (_sno.Trim() == "")
            //{
            //    lt_result.Text = "请选择类别！";
            //    return;
            //}
            if (txturl.Value.Length > 1000)
            {
                lt_result.Text = "链接字符的长度不能超过1000！";
                return;
            }
            if (txtdes.Value.Length > 500)
            {
                lt_result.Text = "描述不能超过500个字符!";
                return;
            }
            //添加图片
            if (_fimg != "")
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
                    if (up.UploadPic(fileimg) != 0)
                    {
                        _fimg = up.getTargetFilename();
                    }
                }
                catch (Exception ex)
                {
                    lt_result.Text = ex.Message;
                }
            }

            try
            {
                if (_id != 0)
                {
                    //修改模式

                    B2C_ads ads = new B2C_ads(_id);
                    //ads.cno = _sno;
                    ads.a_name = _name;
                    if (_fimg != "")
                    {
                        ads.a_gif = _fimg;
                        ads.a_adgif = _fimg;
                    }
                    ads.a_url = _url;
                    ads.a_btime = _stime;
                    ads.a_etime = _otime;
                    ads.a_sort = _sort;
                    ads.a_des = _des;
                    //ads.cityID = _wid;
                    ads.Update();
                    lt_result.Text = "修改成功！";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        return;
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Welcome_Ads_Edit.aspx?wid=" + _wid.ToString() + "';},300);</script>";

                }
                else
                {
                    //新加要进行安全认证;否则，给别人随便乱加关键词
                    //进行安全控制。即关键词id、所有人wid和session["wID"]要一直
                    DataTable dt = comfun.GetDataTableBySQL("select id from wx_mp where id=" + _wid.ToString().Trim());//+ " and wid=" + Session["wID"].ToString().Trim()

                    if (dt.Rows.Count == 0)
                    {
                        lt_result.Text = "不能越权操作公众号！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_keys_List.aspx?wid=" + _wid.ToString() + "';},300);</script>";
                        return;
                    }

                    //添加模式
                    B2C_ads adss = new B2C_ads();
                    adss.addNew();
                    adss.cno = _sno;
                    adss.a_name = _name;
                    if (_fimg != "")
                    {
                        adss.a_gif = _fimg;
                        adss.a_adgif = _fimg;
                    }
                    else
                    {
                        lt_result.Text = "请选择广告图片";
                        return;
                    }
                    adss.a_url = _url;
                    adss.a_btime = _stime;
                    adss.a_etime = _otime;
                    adss.a_sort = _sort;
                    adss.a_des = _des;
                    //adss.cityID = _wid;
                    adss.Update();
                    lt_result.Text = "添加成功！";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        return;
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Welcome_Ads_Edit.aspx?wid=" + _wid.ToString() + "';},300);</script>";

                }
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
                comfun.ChuliException(ex, "man/Ads/Welcome_Ads_Edit.cs", Session["wID"].ToString());
            }
        }
        //绑定广告位置信息
        private void bindnolist()
        {
            try
            {
                DataTable ds = comfun.GetDataTableBySQL("select c_name,c_no from b2c_adclass where c_isactive=1 order by c_no desc");
                selno.DataSource = ds.DefaultView;
                selno.DataTextField = "c_name";
                selno.DataValueField = "c_no";
                selno.DataBind();
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Ads/Welcome_Ads_Edit.cs", Session["wID"].ToString());
            }
        }
    }
}