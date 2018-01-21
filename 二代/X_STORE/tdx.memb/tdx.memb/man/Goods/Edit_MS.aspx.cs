using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.Goods
{
    public partial class Edit_MS : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小贴士：</span> 在这里编辑或添加你的微秒杀项目";
                    if (Request["id"] != null)
                    {
                        int id = 0;
                        if (int.TryParse(Request["id"].ToString(), out id))
                        {
                            B2C_MS bt = new B2C_MS(id);
                            ms_title.Value = bt.ms_title;
                            ms_tiaojian.Value = bt.ms_tiaojian.ToString();
                            ms_price_m.Value = bt.ms_price_m.ToString("F2");
                            ms_price_t.Value = bt.ms_price_t.ToString("F2");
                            ms_AMT_xn.Value = bt.ms_AMT_xn.ToString();
                            ms_AMT_max.Value = bt.ms_AMT_max.ToString();
                            ms_AMT_per.Value = bt.ms_AMT_per.ToString("F0");
                            ms_AMT_have.Value = bt.ms_AMT_have.ToString("F0");
                            ms_Bdate.Value = bt.ms_Bdate.ToString("yyyy-MM-dd HH:mm:ss");
                            ms_Edate.Value = bt.ms_Edate.ToString("yyyy-MM-dd HH:mm:ss");
                            ms_Qdate.Value = bt.ms_Qdate.ToString("yyyy-MM-dd HH:mm:ss");
                            ms_des.Value = bt.ms_des.ToString();
                            ms_tip.Value = bt.ms_tip.ToString();
                            ms_Gname.Value = bt.ms_Gname.ToString();
                            ms_gif_show.ImageUrl = bt.ms_gif.ToString();
                            ms_gif2_show.ImageUrl = bt.ms_gif2.ToString();
                            ms_gif3_show.ImageUrl = bt.ms_gif3.ToString();
                            ms_flv.Value = bt.ms_flv.ToString();
                            ms_msg.Value = bt.ms_msg.ToString();
                            ms_dp.Value = bt.ms_dp.ToString();
                            ms_tg.Value = bt.ms_tg.ToString();
                        }


                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/Edit_MS.cs", Session["wID"].ToString());
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
                        if (string.IsNullOrEmpty(comFunction.NoHTML(ms_title.Value)))
                        {
                            lt_result.Text = "请填写秒杀项目名称！";
                            return;
                        }
                        if (comFunction.NoHTML(ms_title.Value).Length > 255)
                        {
                            lt_result.Text = "秒杀项目名称的字数不能超过255！";
                            return;
                        }
                        if (comFunction.NoHTML(ms_des.Value).Length > 300)
                        {
                            lt_result.Text = "简介的字数不能超过300！";
                            return;
                        }

                        B2C_MS bt = new B2C_MS(Convert.ToInt32(Request["id"]));
                        //     bt.wID = wid;
                        bt.ms_title = comFunction.NoHTML(ms_title.Value);
                        bt.ms_tiaojian = IntParseInput(0, comFunction.NoHTML(ms_tiaojian.Value));
                        bt.ms_price_m = DouParseInput(0, comFunction.NoHTML(ms_price_m.Value));
                        bt.ms_price_t = DouParseInput(0, comFunction.NoHTML(ms_price_t.Value));
                        bt.ms_AMT_xn = IntParseInput(0, comFunction.NoHTML(ms_AMT_xn.Value));
                        bt.ms_AMT_max = IntParseInput(0, comFunction.NoHTML(ms_AMT_max.Value));
                        bt.ms_AMT_per = DouParseInput(0, comFunction.NoHTML(ms_AMT_per.Value));
                        bt.ms_AMT_have = DouParseInput(0, comFunction.NoHTML(ms_AMT_have.Value));
                        if (ms_Bdate.Value != "")
                            bt.ms_Bdate = Convert.ToDateTime(ms_Bdate.Value);
                        if (ms_Edate.Value != "")
                            bt.ms_Edate = Convert.ToDateTime(ms_Edate.Value);
                        if (ms_Qdate.Value != "")
                            bt.ms_Qdate = Convert.ToDateTime(ms_Qdate.Value);

                        bt.ms_des = comFunction.NoHTML(ms_des.Value);
                        bt.ms_tip = comFunction.NoHTML(ms_tip.Value);
                        bt.ms_Gname = comFunction.NoHTML(ms_Gname.Value);


                        string _t_gifjieshu = ms_gif.Value;//结束图片
                        if (_t_gifjieshu != "")
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
                                if (up.UploadPic(ms_gif) != 0)
                                {
                                    _t_gifjieshu = up.getTargetFilename();
                                    bt.ms_gif = _t_gifjieshu;
                                }
                            }
                            finally { up = null; }
                        }
                        string _t_gifjieshu1 = ms_gif2.Value;//结束图片
                        if (_t_gifjieshu1 != "")
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
                                if (up.UploadPic(ms_gif2) != 0)
                                {
                                    _t_gifjieshu1 = up.getTargetFilename();
                                    bt.ms_gif2 = _t_gifjieshu1;
                                }
                            }
                            finally { up = null; }
                        }
                        string _t_gifjieshu12 = ms_gif3.Value;//结束图片
                        if (_t_gifjieshu12 != "")
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
                                if (up.UploadPic(ms_gif3) != 0)
                                {
                                    _t_gifjieshu12 = up.getTargetFilename();
                                    bt.ms_gif3 = _t_gifjieshu12;
                                }
                            }
                            finally { up = null; }
                        }

                        bt.ms_flv = comFunction.NoHTML(ms_flv.Value);
                        bt.ms_msg = comFunction.NoHTML(ms_msg.Value);
                        bt.ms_dp = comFunction.NoHTML(ms_dp.Value);
                        bt.ms_tg = comFunction.NoHTML(ms_tg.Value);
                        bt.Update();
                        commonTool.Show_Have_Url(lt_result, "修改成功！", "Action_MsList.aspx?wid=" + Session["wID"].ToString(), 0);
                    }
                    catch (System.Exception ex)
                    {
                        string exd = ex.Message;
                        commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);
                    }
                }
                else
                {
                    try
                    {
                        int wid = Convert.ToInt32(Session["wID"].ToString());
                        //
                        if (string.IsNullOrEmpty(comFunction.NoHTML(ms_title.Value)))
                        {
                            lt_result.Text = "请填写秒杀项目名称！";
                            return;
                        }
                        if (comFunction.NoHTML(ms_title.Value).Length > 255)
                        {
                            lt_result.Text = "秒杀项目名称的字数不能超过255！";
                            return;
                        }
                        if (comFunction.NoHTML(ms_des.Value).Length > 300)
                        {
                            lt_result.Text = "简介的字数不能超过300！";
                            return;
                        }
                        B2C_MS bt = new B2C_MS();
                        bt.AddNew();

                        //typeid 暂时没有
                        bt.wID = wid;
                        bt.ms_title = comFunction.NoHTML(ms_title.Value);
                        bt.ms_tiaojian = IntParseInput(0, comFunction.NoHTML(ms_tiaojian.Value));
                        bt.ms_price_m = DouParseInput(0, comFunction.NoHTML(ms_price_m.Value));
                        bt.ms_price_t = DouParseInput(0, comFunction.NoHTML(ms_price_t.Value));
                        bt.ms_AMT_xn = IntParseInput(0, comFunction.NoHTML(ms_AMT_xn.Value));
                        bt.ms_AMT_max = IntParseInput(0, comFunction.NoHTML(ms_AMT_max.Value));
                        bt.ms_AMT_per = DouParseInput(0, comFunction.NoHTML(ms_AMT_per.Value));
                        bt.ms_AMT_have = DouParseInput(0, comFunction.NoHTML(ms_AMT_have.Value));
                        if (ms_Bdate.Value != "")
                            bt.ms_Bdate = Convert.ToDateTime(ms_Bdate.Value);
                        if (ms_Edate.Value != "")
                            bt.ms_Edate = Convert.ToDateTime(ms_Edate.Value);
                        if (ms_Qdate.Value != "")
                            bt.ms_Qdate = Convert.ToDateTime(ms_Qdate.Value);

                        bt.ms_des = comFunction.NoHTML(ms_des.Value);
                        bt.ms_tip = comFunction.NoHTML(ms_tip.Value);
                        bt.ms_Gname = comFunction.NoHTML(ms_Gname.Value);


                        string _t_gifjieshu = ms_gif.Value;//结束图片
                        if (_t_gifjieshu != "")
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
                                if (up.UploadPic(ms_gif) != 0)
                                {
                                    _t_gifjieshu = up.getTargetFilename();
                                    bt.ms_gif = _t_gifjieshu;
                                }
                            }
                            finally { up = null; }
                        }
                        string _t_gifjieshu1 = ms_gif2.Value;//结束图片
                        if (_t_gifjieshu1 != "")
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
                                if (up.UploadPic(ms_gif2) != 0)
                                {
                                    _t_gifjieshu1 = up.getTargetFilename();
                                    bt.ms_gif2 = _t_gifjieshu1;
                                }
                            }
                            finally { up = null; }
                        }
                        string _t_gifjieshu12 = ms_gif3.Value;//结束图片
                        if (_t_gifjieshu12 != "")
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
                                if (up.UploadPic(ms_gif3) != 0)
                                {
                                    _t_gifjieshu12 = up.getTargetFilename();
                                    bt.ms_gif3 = _t_gifjieshu12;
                                }
                            }
                            finally { up = null; }
                        }

                        bt.ms_flv = comFunction.NoHTML(ms_flv.Value);
                        bt.ms_msg = comFunction.NoHTML(ms_msg.Value);
                        bt.ms_dp = comFunction.NoHTML(ms_dp.Value);
                        bt.ms_tg = comFunction.NoHTML(ms_tg.Value);
                        bt.Update();
                        commonTool.Show_Have_Url(lt_result, "添加成功！", "Action_MsList.aspx?wid=" + Session["wID"].ToString(), 0);

                    }
                    catch (System.Exception ex)
                    {
                        commonTool.Show_Have_Url(lt_result, "添加失败！", "", 1);
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/Edit_MS.cs", Session["wID"].ToString());
            }
        }
        /// <summary>
        /// 将输入值转换为整数，不符合条件转换为默认值
        /// </summary>
        /// <param name="_moren"></param>
        /// <param name="_input"></param>
        /// <returns></returns>
        private int IntParseInput(int _moren, string _input)
        {
            int.TryParse(_input, out _moren);
            int _intRet = _moren;
            return _intRet;
        }

        /// <summary>
        /// 将输入值转换为double，不符合条件转换为默认值
        /// </summary>
        /// <param name="_moren"></param>
        /// <param name="_input"></param>
        /// <returns></returns>
        private double DouParseInput(double _moren, string _input)
        {
            double.TryParse(_input, out _moren);
            double _douRet = _moren;
            return _douRet;
        }
    }
}