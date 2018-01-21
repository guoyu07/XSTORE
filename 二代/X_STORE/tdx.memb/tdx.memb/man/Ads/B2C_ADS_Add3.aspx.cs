using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.Ads
{
    public partial class B2C_ADS_Add3 : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 如果您选择的模板需要设置背景图片，请在此设置";
                    int _wid = (Session["wid"] != null ? Convert.ToInt32(Session["wid"]) : 0);
                    string _sql = "select * from B2C_ADS where cno like '%010%' order by id desc"; // and cityID=" + _wid + "
                    DataTable _dt = comfun.GetDataTableBySQL(_sql);

                    txtWID.Value = _wid.ToString();
                    bindnolist();
                    int id = 0;

                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        daohang_Image.Text = commonTool.DaohangImage("daohang_6.jpg");
                        string beforeUrl = "../Ads/B2C_ADS_Add2.aspx?nav=true&cno=009";
                        string nextUrl = "../Sets/B2C_menu_Add.aspx?nav=true&parent=1&level=2";
                        daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);
                    }
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        id = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                        B2C_ads ads = new B2C_ads(id);
                        txt.Value = ads.cno;
                        txtname.Value = ads.a_name;
                        Image1.ImageUrl = ads.a_gif;
                        txturl.Value = ads.a_url;
                        txtsort.Value = Convert.IsDBNull(ads.a_sort) ? "" : Convert.ToString(ads.a_sort);
                        txtdes.Value = ads.a_des;

                        if (ads.a_isSys > 0)
                        {
                            txturl.Attributes.Add("readonly", "readonly");
                            txtname.Attributes.Add("readonly", "readonly");
                            txt.Attributes.Add("readonly", "readonly");
                        }
                    }
                    if (Request["cno"] != null)
                    {
                        string cno = Request["cno"].ToString();
                        txt.Value = cno;
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/ads/B2C_ADS_Add3.cs", Session["wID"].ToString());
                }
            }
        }
        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            string _sno = txt.Value;
            string _name = comFunction.NoHTML(txtname.Value);
            string _fimg = fileimg.Value;
            string _url = comFunction.NoHTML(txturl.Value);
            DateTime _stime = DateTime.Now;
            DateTime _otime = DateTime.Now;
            int _sort = Convert.IsDBNull(txtsort.Value) ? 0 : Convert.ToInt32(txtsort.Value);
            string _des = comFunction.NoSt(txtdes.Value);
            int _wid = Convert.ToInt32(txtWID.Value);

            if (_name.Trim() == "")
            {
                lt_result.Text = "请输入名称";
                return;
            }
            if (_sno.Trim() == "")
            {
                lt_result.Text = "请选择类别";
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
            string _sql = "select * from B2C_ADS where cno like '%010%' order by id desc"; // and cityID=" + _wid + "
            DataTable _dt = comfun.GetDataTableBySQL(_sql);
            try
            {
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    //修改模式
                    int id = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                    B2C_ads ads = new B2C_ads(id);
                    ads.cno = _sno;
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
                    {
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ADS_Add3.aspx?nav=true';},300);</script>";

                    }
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ADS_Add3.aspx';},300);</script>";

                }
                else
                {

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
                    {
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ADS_Add3.aspx?nav=true';},300);</script>";

                    }
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ADS_Add3.aspx';},300);</script>";

                }
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
                comfun.ChuliException(ex, "man/ads/B2C_ADS_Add3.cs", Session["wID"].ToString());
            }
        }
        //绑定广告位置信息
        private void bindnolist()
        {
            try
            {
                DataTable ds = comfun.GetDataTableBySQL("select c_name,c_no from b2c_adclass where c_no like '010%' and c_isactive=1 order by c_no desc");
                selno.DataSource = ds.DefaultView;
                selno.DataTextField = "c_name";
                selno.DataValueField = "c_no";
                selno.DataBind();
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/ads/B2C_ADS_Add3.cs", Session["wID"].ToString());
            }
        }


        protected void btnsave_DeleteClick(object sender, EventArgs e)
        {
            try
            {
                string _sql = "delete from B2C_ADS where cno like '%010%'"; // and cityID=" + Session["wid"].ToString()
                comfun.DelbySQL(_sql);
                lt_result.Text = "删除成功！";
                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ADS_Add3.aspx';},300);</script>";
            }
            catch (Exception ex)
            {

                lt_result.Text = "删除失败！";
                comfun.ChuliException(ex, "man/ads/B2C_ADS_Add3.cs", Session["wID"].ToString());
            }

        }
    }
}