using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.Common;
using Creatrue.kernel;
using System.Text;
using System.Data;

namespace tdx.memb.man.Ads
{
    public partial class B2C_ADS_Add2 : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>如果您选择的模板需要幻灯片，请在此设置幻灯片图片";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        daohang_Image.Text = commonTool.DaohangImage("daohang_5.jpg");
                        string beforeUrl = "../Sets/wxConfig_mb.aspx?nav=true";
                        string nextUrl = "../Ads/B2C_ADS_Add3.aspx?nav=true";
                        daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);
                    }

                    int _wid = (Session["wid"] != null ? Convert.ToInt32(Session["wid"]) : 0);
                    txtWID.Value = _wid.ToString();
                    if (_wid > 0)
                    {
                        //查询出幻灯片然后输出
                        GetImags(_wid);
                    }
                    bindnolist();
                    lt_funcSelectBox.Text = commonTool.funcSelectBox("");
                    int id = 0;
                    if (Request["id"] != null)
                    {
                        id = Convert.ToInt32(Request["id"]);
                        B2C_ads ads = new B2C_ads(id);
                        txt.Value = ads.cno;
                        txtname.Value = ads.a_name;
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

                    comfun.ChuliException(ex, "man/ads/B2C_ADS_Add2.cs", Session["wID"].ToString());
                }
            }
        }
        /// <summary>
        /// 获取当前所有图片资源
        /// </summary>
        /// <param name="wid"></param>
        protected void GetImags(int wid)
        {
            try
            {
                string sql = " (1=1) and cno like '009%'"; // and (cityID=" + wid + " or cityID in (select id from wx_mp where cityID=" + wid + ")) 
                string dzd = " *,(select c_name from B2C_AdClass where B2C_AdClass.c_no=B2C_ADS.cno)as cname ";
                StringBuilder sbStr = new StringBuilder();
                DataTable bigTable = B2C_ads.getlist(dzd, sql);
                if (bigTable.Rows.Count > 0)
                {
                    for (int i = 0; i < bigTable.Rows.Count; i++)
                    {
                        sbStr.Append("<li id=\"wximgobjet" + i + "\">");
                        sbStr.Append("<img src=\"" + bigTable.Rows[i]["a_adgif"].ToString().Trim() + "\">");
                        string attr = "";
                        attr += " ads_id=\"" + bigTable.Rows[i]["id"].ToString().Trim() + "\" ";
                        attr += " ads_name=\"" + bigTable.Rows[i]["a_name"].ToString().Trim() + "\" ";
                        attr += " ads_url=\"" + bigTable.Rows[i]["a_url"].ToString().Trim() + "\" ";
                        attr += " ads_sort=\"" + bigTable.Rows[i]["a_sort"].ToString().Trim() + "\" ";
                        attr += " ads_pic=\"" + bigTable.Rows[i]["a_adgif"].ToString().Trim() + "\" ";
                        sbStr.Append("<div class=\"ads_edit\" " + attr + " ><a href=\"javascript:void(0)\" class=\"infoEdit\">编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:void(0)\" class=\"infoDelete\">删除</a></div>");
                        sbStr.Append("<div class=\"ads_name\">" + bigTable.Rows[i]["a_name"].ToString() + "</div>");
                        //sbStr.Append("<div class=\"imgBg\" style=\"background:url( " + bigTable.Rows[i]["a_adgif"].ToString() + " ) no-repeat  scroll 50% 50%\">");
                        //sbStr.Append("<a href=\"javascript:void(0)\" class=\"infoEdit\">编辑</a>");
                        sbStr.Append("</li>");
                        //sbStr.Append("<input class=\"wximgobjet" + i + "\" type=\"hidden\" name=\"hidden\" _title=\"" + bigTable.Rows[i]["a_name"].ToString() +
                        //   "\" _pic=\"" + bigTable.Rows[i]["a_adgif"].ToString() +
                        //   "\" _sort=\"" + bigTable.Rows[i]["a_sort"].ToString() + "\" _url=\"" + bigTable.Rows[i]["a_url"].ToString() + "\" _itemid=\"" + bigTable.Rows[i]["id"].ToString() + "\"></div></div>");
                    }
                    images.Text = sbStr.ToString();
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/ads/B2C_ADS_Add2.cs", Session["wID"].ToString());
            }
        }
        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            int _widd = (Session["wid"] != null ? Convert.ToInt32(Session["wid"]) : 0);


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
            if (!commonTool.RemindMessageLengh(lt_result, _name.Length, 50, "名称不能超过50个字符！", ""))
                return;
            if (!commonTool.RemindMessageLengh(lt_result, _url.Length, 200, "跳转链接不能超过200个字符！", ""))
                return;
            if (!commonTool.RemindMessageLengh(lt_result, _des.Length, 300, "描述不能超过300个字！", ""))
                return;


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
                if (string.IsNullOrEmpty(itemId.Value))
                {
                    //修改模式
                    int id = Convert.ToInt32(Request["id"]);
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
                    if (_widd > 0)
                    {
                        GetImags(_widd);
                    }
                    lt_result.Text = "修改成功！";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        return;
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ADS_List2.aspx';},300);</script>";

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
                    if (_widd > 0)
                    {
                        GetImags(_widd);
                    }
                    lt_result.Text = "添加成功！";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        return;
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_ADS_List2.aspx';},300);</script>";

                }
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
                comfun.ChuliException(ex, "man/ads/B2C_ADS_Add2.cs", Session["wID"].ToString());
            }
        }
        //绑定广告位置信息
        private void bindnolist()
        {
            try
            {
                DataTable ds = comfun.GetDataTableBySQL("select c_name,c_no from b2c_adclass where c_no like '009%' and c_isactive=1 order by c_no desc");
                selno.DataSource = ds.DefaultView;
                selno.DataTextField = "c_name";
                selno.DataValueField = "c_no";
                selno.DataBind();
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/ads/B2C_ADS_Add2.cs", Session["wID"].ToString());
            }
        }
    }
}