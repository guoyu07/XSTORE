using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.Common;
using Creatrue.kernel;

namespace tdx.memb.man.Texts
{
    public partial class wx_keys_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lt_friendly.Text = "<span class='tipsTitle'>小贴士：</span> 在这里，可以设置网友在您的公众号里发送关键词时，对应的自动回复内容。从而实现自动客服功能";
                if (Request["nav"] != null && Request["nav"].ToString() == "true")
                {
                    // DataTable _dt=comfun.GetDataTableBySQL("select top 1 * from wx_mp order by id desc");
                    int wx_wid = Convert.ToInt32(Session["wid"]);
                    daohang_Image.Text = commonTool.DaohangImage("11.jpg");
                    //string.Format("select top 1 * from wx_mp where wid={0} order by id desc", Session["wid"])
                    DataTable _dt = comfun.GetDataTableBySQL("select top 1 * from wx_mp order by id desc"); 

                    string beforeUrl = "../Sets/welConfig.aspx?nav=true";
                    string nextUrl = "../Sets/B2C_menu2_Add.aspx?nav=true&parent=0&level=1";
                    if (_dt.Rows.Count > 0 && _dt.Rows[0]["wx_cid"].ToString() == "1")
                        nextUrl = "../Sets/B2C_menu2_Add.aspx?nav=true&parent=0&level=1";
                    else
                        nextUrl = "../Texts/FinishDaoHang.aspx?nav=true";
                    daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);
                }

                int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);

                if (_wid == 0)
                {
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        //string.Format("select top 1 * from wx_mp where wid={0} order by id desc", Session["wid"])
                        DataTable _dt = comfun.GetDataTableBySQL("select top 1 * from wx_mp order by id desc");
                        if (_dt.Rows.Count == 0)
                        {
                            string na = "?nav=true";
                            Response.Write("<script language='javascript'>alert('请添加具体要操作的公众号！');location.href='../Sets/wx_dh_mp_sys.aspx" + na + "';</script>");
                        }
                        else
                        {
                            int wx_id = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                            string beforeUrl = "../Sets/welConfig.aspx?nav=true";
                            string nextUrl = string.Format("../Sets/B2C_menu2_Add.aspx.aspx?nav=true&parent=0&level=1&wid={0}", wx_id);
                            daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);
                            Response.Write("<script language='javascript'>location.href='../Texts/wx_keys_Add.aspx?wid=" + wx_id + "&nav=" + "true" + "';</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('请先选择具体要操作的公众号！');location.href='/Texts/wx_mp_list.aspx';</script>");

                    }
                    return;

                }
                else
                {
                    try
                    {
                        wx_mp wxmp = new wx_mp(_wid);
                        lt_mp.Text = wxmp.wx_nichen;
                        txtWID.Value = _wid.ToString();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script language='javascript'>alert('请先选择具体要操作的公众号！" + ex.Message.Replace("'", "") + "');location.href='/sets/wx_mp_list.aspx';</script>");
                        return;
                    }
                }

                //workAuthentication(263) 
                DataTable dt = comfun.GetDataTableBySQL("select * from wx_keys_f order by id");
                ss_fid.DataSource = dt;
                ss_fid.DataTextField = "f_name";
                ss_fid.DataValueField = "id";
                ss_fid.DataBind();

                //初始化类别选择框  
                if (Request["id"] != null)
                {
                    wx_keys cate = new wx_keys(Convert.ToInt32(Request["id"]));

                    //pageid.Value = cate.id.ToString();
                    txt_gtitle.Value = cate.k_words;
                    des.Value = cate.k_answer;
                    txtKURL.Value = cate.k_url;
                    //img.Src = cate.k_image;
                    _msg.Value = cate.k_content;
                    //des2.Value = cate.k_answer;
                    //sort.Value = cate.k_sort;
                    //URL.Value = cate.k_url2;
                    //k_des3.Value = cate.k_des;
                    if (!string.IsNullOrEmpty(cate.k_url))
                    {
                        rd_type1.Checked = false;
                        rd_type2.Checked = false;
                        rd_type3.Checked = true;
                        rd_type4.Checked = false;
                        lt_result.Text = "<script language='javascript'> $(function(){$('#d1').hide();$('#d2').hide();$('#d3').show();});$('#d4').hide();</script>";
                    }
                    else if (cate.fid != 0)
                    {
                        rd_type1.Checked = false;
                        rd_type2.Checked = true;
                        rd_type3.Checked = false;
                        rd_type4.Checked = false;
                        ss_fid.Value = cate.fid.ToString();
                        lt_result.Text = "<script language='javascript'> $(function(){$('#d1').hide();$('#d2').show();$('#d3').hide();});$('#d4').hide();</script>";
                    }
                    else if (!string.IsNullOrEmpty(cate.k_image) && !string.IsNullOrEmpty(cate.k_content))
                    {
                        rd_type1.Checked = false;
                        rd_type2.Checked = false;
                        rd_type3.Checked = false;
                        rd_type4.Checked = true;
                        lt_result.Text = "<script language='javascript'> $(function(){$('#d1').hide();$('#d2').hide();$('#d3').hide();$('#d4').show();});</script>";
                    }
                    else if (string.IsNullOrEmpty(cate.k_image))
                    {
                        rd_type1.Checked = true;
                        rd_type2.Checked = false;
                        rd_type3.Checked = false;
                        rd_type4.Checked = false;
                    }

                    if (cate.k_isSys > 0)
                    {
                        txt_gtitle.Attributes.Add("readonly", "readonly");
                        des.Attributes.Add("readonly", "readonly");
                        ss_fid.Attributes.Add("readonly", "readonly");
                        txtKURL.Attributes.Add("readonly", "readonly");
                    }
                }
            }

            hfwid.Value = string.IsNullOrEmpty(Request["wid"]) ? "" : Request["wid"].ToString();
            if (string.IsNullOrEmpty(hfGuid.Value))
            {
                hfGuid.Value = Guid.NewGuid().ToString();
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
            string _gtitle = comFunction.NoHTML(txt_gtitle.Value);
            string _des = comFunction.NoSt(des.Value);
            int _fid = 0;
            string imgUrl = "";
            string _content = "";
            //string _sort = sort.Value;
            string _k_url2 = "";
            //string _k_des3 = k_des3.Value;
            if (rd_type2.Checked == true)
                _fid = Convert.ToInt32(ss_fid.Value);
            //if (rd_type4.Checked == true)
            //{
            //    //图文信息
            //    //处理图片
            //    //imgUrl = getImgUrl(title_image.Value);
            //    _content = _msg.Value;
            //    //_des = des2.Value;
            //    //_k_url2 = URL.Value;
            //    //_k_des3 = k_des3.Value;
            //}
            int _wid = Convert.ToInt32(txtWID.Value);

            if (_gtitle.Trim() == "")
            {
                lt_result.Text = "请输入关键词";

                return;
            }
            if (_fid == 0 && _des.Trim() == "")
            {
                lt_result.Text = "请输入内容";
                return;
            }
            if (string.IsNullOrEmpty(_content) && rd_type4.Checked == true)
            {
                lt_result.Text = "请输入内容: " + _content;
                return;
            }
            if (string.IsNullOrEmpty(_des.Trim()) && rd_type4.Checked == true)
            {
                lt_result.Text = "请输入描述: " + _des;
                return;
            }
            if (!commonTool.RemindMessageLengh(lt_result, des.Value.Length, 300, "内容最多不能超过300字！", ""))
                return;
            if (!commonTool.RemindMessageLengh(lt_result, txtKURL.Value.Length, 500, "链接最多不能超过500个字符！", ""))
                return;

            if (Request["id"] != null)
            {
                try
                {
                    wx_keys cate = new wx_keys(Convert.ToInt32(Request["id"])); //此时已经进行过安全处理
                    cate.k_words = _gtitle;
                    cate.k_answer = _des;
                    cate.fid = _fid;
                    cate.cityID = _wid;
                    if (!string.IsNullOrEmpty(imgUrl))
                        cate.k_image = imgUrl;
                    cate.k_content = _content;
                    //cate.k_sort = _sort;
                    cate.k_url2 = _k_url2;
                    //cate.k_des = _k_des3;
                    cate.Update();
                    lt_result.Text = "修改成功！";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        return;
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_keys_List.aspx?wid=" + _wid.ToString() + "';},300);</script>";
                    return;

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
                    //新加要进行安全认证;否则，给别人随便乱加关键词
                    //进行安全控制。即关键词id、所有人wid和session["wID"]要一直
                    DataTable dt = comfun.GetDataTableBySQL("select id from wx_mp where id=" + _wid.ToString().Trim()); // + " and wid=" + Session["wID"].ToString().Trim()

                    if (dt.Rows.Count == 0)
                    {
                        lt_result.Text = "不能越权操作公众号！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_keys_List.aspx?wid=" + _wid.ToString() + "';},300);</script>";
                        return;
                    }
                    wx_keys cate = new wx_keys();
                    cate.Addnew();
                    cate.k_words = _gtitle;
                    cate.k_answer = _des;
                    cate.fid = _fid;
                    cate.cityID = _wid;
                    cate.k_image = imgUrl;
                    cate.k_content = _content;
                    //cate.k_sort = _sort;
                    cate.k_url2 = _k_url2;
                    //cate.k_des = _k_des3;
                    cate.Update();
                    lt_result.Text = "添加成功！";
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        return;
                    else
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_keys_List.aspx?wid=" + _wid.ToString() + "';},300);</script>";
                    return;
                }
                catch (Exception ex)
                {
                    lt_result.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 处理图片
        /// </summary>
        /// <param name="_url_i">上传URL</param>
        /// <returns>服务器保存URL</returns>
        private string getImgUrl(string _url_i)
        {
            if (_url_i != "")
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
                    //if (up.UploadPic(title_image) != 0)
                    //{
                    //    _url_i = up.getTargetFilename();
                    //}
                }
                finally { up = null; }
            }
            return _url_i;
        }

        private void setHidden()
        {
            if (rd_type4.Checked == true)
            {
                lt_result.Text += "<script language='javascript'>d1.style.display='none';d2.style.display='none';d3.style.display='none';d4.style.display='';</script>";
            }
            else if (rd_type3.Checked == true)
            {
                lt_result.Text += "<script language='javascript'>d1.style.display='none';d2.style.display='none';d3.style.display='';d4.style.display='none';</script>";
            }
            else if (rd_type2.Checked == true)
            {
                lt_result.Text += "<script language='javascript'>d1.style.display='none';d2.style.display='';d3.style.display='none';d4.style.display='none';</script>";
            }
            else
            {
                lt_result.Text += "<script language='javascript'>d1.style.display='';d2.style.display='none';d3.style.display='none';d4.style.display='none';</script>";
            }
        }
    }
}