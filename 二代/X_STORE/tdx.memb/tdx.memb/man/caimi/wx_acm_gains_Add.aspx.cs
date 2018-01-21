using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;

namespace tdx.memb.man.caimi
{
    public partial class wx_acm_gains_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>在这里，编辑您的奖品信息。";
            if (!IsPostBack)
            {
                try
                {
                    string _acid = Request["acid"] != null ? Request["acid"].ToString() : "0";

                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        wx_acm_action_gains tt = new wx_acm_action_gains(id);
                        gname.Value = tt.g_name;
                        Image1.ImageUrl = tt.g_gif;
                        gdes.Value = tt.g_cont;
                        gnum.Value = tt.g_num.ToString();
                        gper.Value = tt.g_per.ToString();
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/goods/wx_acm_gains_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _g_name = comFunction.NoHTML(gname.Value);
                string _g_cont = comFunction.NoHTML(gdes.Value);
                string _g_num = comFunction.NoHTML(gnum.Value);
                string _g_per = comFunction.NoHTML(gper.Value);
                string _g_gif = ggif.Value;

                if (_g_name == "")
                {
                    lt_result.Text = "奖品名称不能为空！";
                    return;
                }
                if (_g_name.Length > 200)
                {
                    lt_result.Text = "奖品名称字符数不能超过200！";
                    return;
                }

                //添加图片
                if (_g_gif != "")
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
                        if (up.UploadPicAsMul3(ggif) != 0)
                        {
                            _g_gif = up.getTargetFilename();
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
                        wx_acm_action_gains tt = new wx_acm_action_gains(_id);
                        tt.g_name = _g_name;
                        tt.g_num = Convert.ToInt32(_g_num);
                        tt.g_cont = _g_cont;
                        tt.g_per = Convert.ToDouble(_g_per);
                        if (_g_gif != "")
                        {
                            tt.g_gif = _g_gif;
                        }

                        tt.Update();

                        lt_result.Text = "修改成功！";

                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_gains_List.aspx';},300);</script>";


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
                        wx_acm_action_gains tt = new wx_acm_action_gains();
                        tt.Addnew();
                        tt.g_name = _g_name;
                        tt.g_num = Convert.ToInt32(_g_num);
                        tt.g_cont = _g_cont;
                        tt.g_per = Convert.ToDouble(_g_per);
                        if (_g_gif != "")
                        {
                            tt.g_gif = _g_gif;
                        }
                        tt.Update();

                        lt_result.Text = "添加成功！";

                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_gains_List.aspx';},300);</script>";


                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/goods/wx_acm_gains_Add.cs", Session["wID"].ToString());
            }
        }

    }
}