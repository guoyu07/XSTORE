using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;

namespace tdx.memb.man.vipmemb
{
    public partial class VIP_Share_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>在这里，编辑您的会员分享信息。";
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_share bShare = new B2C_share(id);
                        name.Value = bShare.t_title;
                        name.Disabled = true;
                        ischead.Value = bShare.t_ischead.ToString();
                        ischead.Disabled = true;
                        unit2.Value = bShare.t_isactive.ToString();
                        Image1.ImageUrl = bShare.t_gif;
                        _msg.Value = bShare.t_msg;
                        t_bdate.Value = bShare.t_bdate.ToString();
                        t_edate.Value = bShare.t_edate.ToString();
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/VIP_Share_Add.cs", Session["wID"].ToString());
                }
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _t_title = comFunction.NoHTML(name.Value);
                int _t_isactive = int.Parse(unit2.Value);
                string _t_gif = gif.Value;
                string _t_msg = comFunction.NoSt(_msg.Value);
                string _t_ischead = ischead.Value;
                string _t_bdate = t_bdate.Value;
                string _t_edate = t_edate.Value;
                //int _t_cityID = int.Parse(Session["wID"].ToString());

                if (_t_title == "")
                {
                    lt_result.Text = "标题不能为空！";
                    return;
                }
                if (_t_title.Length > 200)
                {
                    lt_result.Text = "标题字符数不能超过200！";
                    return;
                }
                if (_t_ischead == "")
                {
                    lt_result.Text = "标题不能为空！";
                    return;
                }

                //添加图片
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
                        if (up.UploadPicAsMul3(gif) != 0)
                        {
                            _t_gif = up.getTargetFilename();
                        }
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
                        int _id = Convert.ToInt32(Request["id"]);
                        B2C_share share = new B2C_share(_id);
                        share.id = _id;
                        share.t_title = _t_title;
                        share.t_isactive = _t_isactive;
                        share.t_ischead = int.Parse(_t_ischead);
                        if (_t_gif != "")
                        {
                            share.t_gif = _t_gif;
                        }
                        share.t_msg = _t_msg;
                        share.t_bdate = Convert.ToDateTime(_t_bdate);
                        share.t_edate = Convert.ToDateTime(_t_edate);
                        //share.cityID = _t_cityID;
                        share.Update();

                        lt_result.Text = "修改成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='VIP_Share_List.aspx';},300);</script>";


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
                        B2C_share share = new B2C_share();
                        share.AddNew();
                        share.t_title = _t_title;
                        share.t_isactive = _t_isactive;
                        share.t_ischead = int.Parse(_t_ischead);
                        share.t_gif = _t_gif;
                        share.t_msg = _t_msg;
                        //share.cityID = _t_cityID;
                        share.t_bdate = Convert.ToDateTime(_t_bdate);
                        share.t_edate = Convert.ToDateTime(_t_edate);

                        if (_t_gif != "")
                        {
                            share.t_gif = _t_gif;
                        }

                        share.Update();

                        lt_result.Text = "添加成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='VIP_Share_List.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/VIP_Share_Add.cs", Session["wID"].ToString());
            }
        }
        private string result(string num)
        {
            string result = string.Empty;
            switch (num)
            {
                case "0":
                    result = "否";
                    break;
                case "1":
                    result = "是";
                    break;
            }
            return result;
        }
    }
}