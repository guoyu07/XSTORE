using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;

namespace tdx.memb.man.Goods
{
    public partial class Edit_Team : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 编辑您的团购项目。";
                    if (Request["id"] != null)
                    {
                        int id = 0;
                        if (int.TryParse(Request["id"].ToString(), out id))
                        {
                            B2C_Team bt = new B2C_Team(id);
                            tm_title.Value = bt.tm_title;

                            tm_tiaojian.Value = bt.tm_tiaojian.ToString();
                            tm_tiaojian2.Value = bt.tm_tiaojian2.ToString();
                            tm_price_m.Value = bt.tm_price_m.ToString("F2");
                            tm_price_t.Value = bt.tm_price_t.ToString("F2");
                            tm_AMT_xn.Value = bt.tm_AMT_xn.ToString();
                            tm_AMT_min.Value = bt.tm_AMT_min.ToString();
                            tm_AMT_max.Value = bt.tm_AMT_max.ToString();
                            tm_AMT_per.Value = bt.tm_AMT_per.ToString("F0");
                            tm_AMT_have.Value = bt.tm_AMT_have.ToString("F0");
                            tm_Bdate.Value = bt.tm_Bdate.ToString("yyyy-MM-dd HH:mm:ss");
                            tm_Edate.Value = bt.tm_Edate.ToString("yyyy-MM-dd HH:mm:ss");
                            tm_Qdate.Value = bt.tm_Qdate.ToString("yyyy-MM-dd HH:mm:ss");
                            tm_des.Value = bt.tm_des.ToString();
                            tm_tip.Value = bt.tm_tip.ToString();
                            tm_Gname.Value = bt.tm_Gname.ToString();
                            //tm_gif.Value = bt.tm_gif.ToString();
                            //tm_gif2.Value = bt.tm_gif2.ToString();
                            //tm_gif3.Value = bt.tm_gif3.ToString();
                            tm_flv.Value = bt.tm_flv.ToString();
                            tm_msg.Value = bt.tm_msg.ToString();
                            tm_dp.Value = bt.tm_dp.ToString();
                            tm_tg.Value = bt.tm_tg.ToString();
                        }


                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/Edit_Team.cs", Session["wID"].ToString());
                }

            }
        }
        protected void btn_baocun_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (Request["id"] != null)
                {
                    try
                    {
                        //int wid = Convert.ToInt32(Request["wid"]);
                        //
                        if (string.IsNullOrEmpty(comFunction.NoHTML(tm_title.Value)))
                        {
                            lt_result.Text = "请此次团购名称！";
                            return;
                        }
                        if (comFunction.NoHTML(tm_title.Value).Length > 255)
                        {
                            lt_result.Text = "团购名称的字符数不能超过255！";
                            return;
                        }
                        if (comFunction.NoHTML(tm_des.Value).Length > 300)
                        {
                            lt_result.Text = "简介的字符数不能超过255！";
                            return;
                        }

                        B2C_Team bt = new B2C_Team(Convert.ToInt32(Request["id"]));
                        //     bt.wID = wid;
                        bt.tm_title = comFunction.NoHTML(tm_title.Value);
                        int _tm_tiaojian = 0;
                        int.TryParse(comFunction.NoHTML(tm_tiaojian.Value), out _tm_tiaojian);
                        bt.tm_tiaojian = _tm_tiaojian;// Convert.ToInt32(string.IsNullOrEmpty(tm_tiaojian.Value) ? "0" : );
                        int _tm_tiaojian2 = 0;
                        int.TryParse(comFunction.NoHTML(tm_tiaojian2.Value), out _tm_tiaojian2);
                        bt.tm_tiaojian2 = _tm_tiaojian2;

                        double _tm_price_m = 0;
                        double.TryParse(comFunction.NoHTML(tm_price_m.Value), out _tm_price_m);
                        bt.tm_price_m = _tm_price_m;

                        double _tm_price_t = 0;
                        double.TryParse(comFunction.NoHTML(tm_price_t.Value), out _tm_price_t);
                        bt.tm_price_t = _tm_price_t;

                        int _tm_AMT_xn = 0;
                        int.TryParse(comFunction.NoHTML(tm_AMT_xn.Value), out _tm_AMT_xn);
                        bt.tm_AMT_xn = _tm_AMT_xn;

                        int _tm_AMT_min = 0;
                        int.TryParse(comFunction.NoHTML(tm_AMT_min.Value), out _tm_AMT_min);
                        bt.tm_AMT_min = _tm_AMT_min;

                        int _tm_AMT_max = 0;
                        int.TryParse(comFunction.NoHTML(tm_AMT_max.Value), out _tm_AMT_max);
                        bt.tm_AMT_max = _tm_AMT_max;

                        double _tm_AMT_per = 0;
                        double.TryParse(comFunction.NoHTML(tm_AMT_per.Value), out _tm_AMT_per);
                        bt.tm_AMT_per = _tm_AMT_per;

                        double _tm_AMT_have = 0;
                        double.TryParse(comFunction.NoHTML(tm_AMT_have.Value), out _tm_AMT_have);
                        bt.tm_AMT_have = _tm_AMT_have;
                        if (tm_Bdate.Value != "")
                            bt.tm_Bdate = Convert.ToDateTime(tm_Bdate.Value);
                        if (tm_Edate.Value != "")
                            bt.tm_Edate = Convert.ToDateTime(tm_Edate.Value);
                        if (tm_Qdate.Value != "")
                            bt.tm_Qdate = Convert.ToDateTime(tm_Qdate.Value);

                        bt.tm_des = comFunction.NoHTML(tm_des.Value);
                        bt.tm_tip = comFunction.NoHTML(tm_tip.Value);
                        bt.tm_Gname = comFunction.NoHTML(tm_Gname.Value);

                        comUpload up = new comUpload();
                        up.clearFileType();
                        up.addFileType("jpg");
                        up.addFileType("jpeg");
                        up.addFileType("gif");
                        up.addFileType("png");
                        up.addFileType("bmp");

                        string _t_gifjieshu = tm_gif.Value;//结束图片
                        if (_t_gifjieshu != "")
                        {
                            try
                            {
                                if (up.UploadPic(tm_gif) != 0)
                                {
                                    _t_gifjieshu = up.getTargetFilename();
                                    bt.tm_gif = _t_gifjieshu;
                                }
                            }
                            finally { ; }
                        }
                        string _t_gifjieshu1 = tm_gif2.Value;//结束图片
                        if (_t_gifjieshu1 != "")
                        {

                            try
                            {
                                if (up.UploadPic(tm_gif2) != 0)
                                {
                                    _t_gifjieshu1 = up.getTargetFilename();
                                    bt.tm_gif2 = _t_gifjieshu1;
                                }
                            }
                            finally { ; }
                        }
                        string _t_gifjieshu12 = tm_gif3.Value;//结束图片
                        if (_t_gifjieshu12 != "")
                        {
                            try
                            {
                                if (up.UploadPic(tm_gif3) != 0)
                                {
                                    _t_gifjieshu12 = up.getTargetFilename();
                                    bt.tm_gif3 = _t_gifjieshu12;
                                }
                            }
                            finally { up = null; }
                        }

                        bt.tm_flv = tm_flv.Value;
                        bt.tm_msg = tm_msg.Value;
                        bt.tm_dp = tm_dp.Value;
                        bt.tm_tg = tm_tg.Value;
                        bt.Update();
                        lt_result.Text = "修改成功！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Action_TeamList.aspx?wid=" + Session["wID"].ToString() + "';},300);</script>";
                    }
                    catch (System.Exception ex)
                    {
                        lt_result.Text = "修改失败！";
                    }
                }
                else
                {
                    try
                    {
                        int wid = Convert.ToInt32(Session["wID"]);
                        //
                        if (string.IsNullOrEmpty(comFunction.NoHTML(tm_title.Value)))
                        {
                            lt_result.Text = "请此次团购名称！";
                            return;
                        }
                        if (comFunction.NoHTML(tm_title.Value).Length > 255)
                        {
                            lt_result.Text = "团购名称的字符数不能超过255！";
                            return;
                        }
                        if (comFunction.NoHTML(tm_des.Value).Length > 300)
                        {
                            lt_result.Text = "简介的字符数不能超过255！";
                            return;
                        }

                        B2C_Team bt = new B2C_Team();
                        bt.AddNew();

                        //typeid 暂时没有
                        bt.wID = wid;
                        bt.tm_title = comFunction.NoHTML(tm_title.Value);
                        int _tm_tiaojian = 0;
                        int.TryParse(comFunction.NoHTML(tm_tiaojian.Value), out _tm_tiaojian);
                        bt.tm_tiaojian = _tm_tiaojian;// Convert.ToInt32(string.IsNullOrEmpty(tm_tiaojian.Value) ? "0" : );
                        int _tm_tiaojian2 = 0;
                        int.TryParse(comFunction.NoHTML(tm_tiaojian2.Value), out _tm_tiaojian2);
                        bt.tm_tiaojian2 = _tm_tiaojian2;

                        double _tm_price_m = 0;
                        double.TryParse(comFunction.NoHTML(tm_price_m.Value), out _tm_price_m);
                        bt.tm_price_m = _tm_price_m;

                        double _tm_price_t = 0;
                        double.TryParse(comFunction.NoHTML(tm_price_t.Value), out _tm_price_t);
                        bt.tm_price_t = _tm_price_t;

                        int _tm_AMT_xn = 0;
                        int.TryParse(comFunction.NoHTML(tm_AMT_xn.Value), out _tm_AMT_xn);
                        bt.tm_AMT_xn = _tm_AMT_xn;

                        int _tm_AMT_min = 0;
                        int.TryParse(comFunction.NoHTML(tm_AMT_min.Value), out _tm_AMT_min);
                        bt.tm_AMT_min = _tm_AMT_min;

                        int _tm_AMT_max = 0;
                        int.TryParse(comFunction.NoHTML(tm_AMT_max.Value), out _tm_AMT_max);
                        bt.tm_AMT_max = _tm_AMT_max;

                        double _tm_AMT_per = 0;
                        double.TryParse(comFunction.NoHTML(tm_AMT_per.Value), out _tm_AMT_per);
                        bt.tm_AMT_per = _tm_AMT_per;

                        double _tm_AMT_have = 0;
                        double.TryParse(comFunction.NoHTML(tm_AMT_have.Value), out _tm_AMT_have);
                        bt.tm_AMT_have = _tm_AMT_have;
                        if (tm_Bdate.Value != "")
                            bt.tm_Bdate = Convert.ToDateTime(tm_Bdate.Value);
                        if (tm_Edate.Value != "")
                            bt.tm_Edate = Convert.ToDateTime(tm_Edate.Value);
                        if (tm_Qdate.Value != "")
                            bt.tm_Qdate = Convert.ToDateTime(tm_Qdate.Value);

                        bt.tm_des = comFunction.NoHTML(tm_des.Value);
                        bt.tm_tip = comFunction.NoHTML(tm_tip.Value);
                        bt.tm_Gname = comFunction.NoHTML(tm_Gname.Value);

                        comUpload up = new comUpload();
                        up.clearFileType();
                        up.addFileType("jpg");
                        up.addFileType("jpeg");
                        up.addFileType("gif");
                        up.addFileType("png");
                        up.addFileType("bmp");
                        string _t_gifjieshu = tm_gif.Value;//结束图片
                        if (_t_gifjieshu != "")
                        {
                            try
                            {
                                if (up.UploadPic(tm_gif) != 0)
                                {
                                    _t_gifjieshu = up.getTargetFilename();
                                    bt.tm_gif = _t_gifjieshu;
                                }
                            }
                            finally { ; }
                        }
                        string _t_gifjieshu1 = tm_gif2.Value;//结束图片
                        if (_t_gifjieshu1 != "")
                        {
                            try
                            {
                                if (up.UploadPic(tm_gif2) != 0)
                                {
                                    _t_gifjieshu1 = up.getTargetFilename();
                                    bt.tm_gif2 = _t_gifjieshu1;
                                }
                            }
                            finally { ; }
                        }
                        string _t_gifjieshu12 = tm_gif3.Value;//结束图片
                        if (_t_gifjieshu12 != "")
                        {

                            try
                            {
                                if (up.UploadPic(tm_gif3) != 0)
                                {
                                    _t_gifjieshu12 = up.getTargetFilename();
                                    bt.tm_gif3 = _t_gifjieshu12;
                                }
                            }
                            finally { up = null; }
                        }

                        bt.tm_flv = tm_flv.Value;
                        bt.tm_msg = tm_msg.Value;
                        bt.tm_dp = tm_dp.Value;
                        bt.tm_tg = tm_tg.Value;
                        bt.Update();
                        lt_result.Text = "添加成功！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Action_TeamList.aspx?wid=" + Session["wID"].ToString() + "';},300);</script>";

                    }
                    catch (System.Exception ex)
                    {
                        lt_result.Text = "添加失败！";
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/Edit_Team.cs", Session["wID"].ToString());
            }
        }
    }
}