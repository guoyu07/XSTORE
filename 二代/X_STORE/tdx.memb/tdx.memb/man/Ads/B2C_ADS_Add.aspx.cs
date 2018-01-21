using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using tdx.database.database;

namespace tdx.memb.man.Ads
{
    public partial class B2C_ADS_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);
                txtWID.Value = _wid.ToString();

                bindnolist();
                int id = 0;
                if (Request["id"] != null)
                {
                    id = Convert.ToInt32(Request["id"]);
                    B2C_ads_web ads = new B2C_ads_web(id);
                    selno.Value = ads.cno;
                    txtname.Value = ads.a_name;
                    Image1.ImageUrl = ads.a_gif;
                    txturl.Value = ads.a_url;
                    txtsort.Value = Convert.IsDBNull(ads.a_sort) ? "" : Convert.ToString(ads.a_sort);
                    txtdes.Value = ads.a_des;

                    if (ads.a_isSys > 0)
                    {
                        txturl.Attributes.Add("readonly", "readonly");
                        txtname.Attributes.Add("readonly", "readonly");
                        selno.Attributes.Add("readonly", "readonly");
                    }
                }
                if (Request["cno"] != null)
                {
                    string cno = Request["cno"].ToString();
                    selno.Value = cno;
                }
            }
        }
        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            string _sno = selno.Value;
            string _name = txtname.Value;
            string _fimg = fileimg.Value;
            string _url = txturl.Value;
            DateTime _stime = DateTime.Now;
            DateTime _otime = DateTime.Now;
            int _sort = Convert.IsDBNull(txtsort.Value) ? 0 : Convert.ToInt32(txtsort.Value);
            string _des = txtdes.Value;
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

            try
            {
                if (Request["id"] != null)
                {
                    //修改模式
                    int id = Convert.ToInt32(Request["id"]);
                    B2C_ads_web ads = new B2C_ads_web(id);
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
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ads_List.aspx?wid=" + _wid.ToString() + "';},300);</script>";

                }
                else
                {

                    //添加模式
                    B2C_ads_web adss = new B2C_ads_web();
                    adss.addNew();
                    adss.cno = _sno;
                    adss.a_name = _name;
                    if (_fimg != "")
                    {
                        adss.a_gif = _fimg;
                        adss.a_adgif = _fimg;
                    }
                    //else
                    //{
                    //    lt_result.Text = "请选择广告图片";
                    //    return; 
                    //}
                    adss.a_url = _url;
                    adss.a_btime = _stime;
                    adss.a_etime = _otime;
                    adss.a_sort = _sort;
                    adss.a_des = _des;
                    //adss.cityID = _wid;
                    adss.Update();
                    lt_result.Text = "添加成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ads_List.aspx?wid=" + _wid.ToString() + "';},300);</script>";

                }
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
            }
        }
        //绑定广告位置信息
        private void bindnolist()
        {
            DataTable ds = comfun.GetDataTableBySQL("select (c_name+'('+cast(c_width as varchar(8))+'*'+cast(c_height as varchar(8))+')') as c_name,c_no from b2c_adclass_web where c_isactive=1 order by c_no desc");
            selno.DataSource = ds.DefaultView;
            selno.DataTextField = "c_name";
            selno.DataValueField = "c_no";
            selno.DataBind();
        }
    }
}