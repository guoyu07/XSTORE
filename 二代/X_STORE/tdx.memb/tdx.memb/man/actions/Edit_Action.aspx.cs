using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.actions
{
    public partial class Edit_Action : workAuth
    {
        string ksPic = "";//开始图片
        string jsPic = "";//结束图片
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 编辑您的微活动信息，如： 大转盘、刮刮乐等。";
                    int _typeid = 0;
                    if (Request["id"] != null)
                    {
                        int id = 0;
                        if (int.TryParse(Request["id"].ToString(), out id))
                        {

                            Wx_action wa = new Wx_action(id);
                            t_title.Value = wa.ac_title;
                            kaishiimg.Src = wa.ac_b_gif;
                            t_jieshutupiandizhi.Src = wa.ac_e_gif;
                            t_hdjianjie.Value = wa.ac_des;
                            t_kaishi.Value = wa.ac_bdate.ToString("yyyy-MM-dd");
                            t_jieshu.Value = wa.ac_edate.ToString("yyyy-MM-dd");
                            t_djxinxi.Value = wa.ac_dj_info;
                            t_jshuodonggonggao.Value = wa.ac_end_title;
                            t_ydjsz.Value = wa.ac_jp_one;
                            t_edjsz.Value = wa.ac_jp_two;
                            t_sdjsz.Value = wa.ac_jp_three;
                            t_zjxinxi.Value = wa.ac_zj_info;
                             t_msg.Value = wa.ac_end_des;
                            t_ydjsl.Value = wa.ac_jp_one_num.ToString();
                            t_edjsl.Value = wa.ac_jp_two_num.ToString();
                            t_sdjsl.Value = wa.ac_jp_three_num.ToString();
                            t_cfxinxi.Value = wa.ac_cf_info;
                            ////////////////////////////////////////
                            //wa.wid = 0; //暂时用0测试
                            //wa.hits = 0;
                            //wa.views = 0;
                            t_yjhdrs.Value = wa.ac_totlenum.ToString();

                            t_yxcimgr.Value = wa.ac_men_num.ToString();


                            _typeid = wa.typeid;
                            AddSelect(_typeid);
                        }


                    }
                    else
                        AddSelect(_typeid);
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/actions/Edit_Action.cs", Session["wID"].ToString());
                }

            }
        }

        private void AddSelect(int _leibie)
        {
            try
            {
                string _sql = "select * from wx_actions";
                DataTable _tab = comfun.GetDataTableBySQL(_sql);
                if (_tab.Rows.Count > 0)
                {
                    ListItem list = new ListItem();
                    list.Value = "--请选择活动类型--";
                    list.Text = "--请选择活动类型--";
                    if (_leibie == 0)
                        list.Selected = true;
                    Action_leibie.Items.Add(list);
                    for (int i = 0; i < _tab.Rows.Count; i++)
                    {
                        ListItem _list = new ListItem();
                        _list.Value = _tab.Rows[i]["id"].ToString();
                        _list.Text = _tab.Rows[i]["ac_name"].ToString();
                        if (_leibie == Convert.ToInt32(_tab.Rows[i]["id"].ToString()))
                            _list.Selected = true;
                        Action_leibie.Items.Add(_list);
                    }

                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/actions/Edit_Action.cs", Session["wID"].ToString());
            }
        }

        protected void btn_baocun_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Wx_action wa;
                if (Request["id"] != null)
                    wa = new Wx_action(Convert.ToInt32(Request["id"]));
                else
                {
                    wa = new Wx_action();
                    wa.AddNew();
                }

                int shuliang = 0;
                bool _ret = int.TryParse(t_yxcimgr.Value, out shuliang);
                if (!_ret)
                    shuliang = 1;
                if (shuliang < 1 || shuliang > 5)
                {
                    lt_result.Text = "每个人最多抽奖次数只能在1-5之间！";
                    return;
                }
                if (Request["Action_leibie"] != null && Request["Action_leibie"] == "--请选择活动类型--")
                {
                    lt_result.Text = "请选择活动类型";
                    return;
                }
                if (Request["Action_leibie"] != null && Request["Action_leibie"].ToString() != "--请选择活动类型--")
                {
                    int _type = Convert.ToInt32(Request["Action_leibie"].ToString());
                    string _typeSql = "select * from wx_actions where id=" + _type.ToString();
                    DataTable _tab = comfun.GetDataTableBySQL(_typeSql);
                    if (_tab.Rows.Count > 0)
                        wa.typeid = Convert.ToInt32(_tab.Rows[0]["id"].ToString());
                }

                wa.ac_title = comFunction.NoHTML(t_title.Value);
                wa.ac_des = t_hdjianjie.Value;
                if (t_kaishi.Value == "")
                    wa.ac_bdate = DateTime.Now;
                else
                    wa.ac_bdate = Convert.ToDateTime(t_kaishi.Value);
                if (t_jieshu.Value == "")
                    wa.ac_edate = DateTime.Now.AddDays(3.0);
                else
                    wa.ac_edate = Convert.ToDateTime(t_jieshu.Value);
                wa.ac_dj_info = comFunction.NoHTML(t_djxinxi.Value);
                wa.ac_end_title = comFunction.NoHTML(t_jshuodonggonggao.Value);
                wa.ac_jp_one = comFunction.NoHTML(t_ydjsz.Value);
                wa.ac_jp_two = comFunction.NoHTML(t_edjsz.Value);
                wa.ac_jp_three = comFunction.NoHTML(t_sdjsz.Value);
                wa.ac_zj_info = comFunction.NoHTML(t_zjxinxi.Value);
                wa.ac_end_des = t_msg.Value;
                int _ac_jp_one_num = 0;
                _ret = int.TryParse(t_ydjsl.Value, out _ac_jp_one_num);
                if (!_ret)
                    _ac_jp_one_num = 0;
                wa.ac_jp_one_num = _ac_jp_one_num;

                int _ac_jp_two_num = 0;
                _ret = int.TryParse(comFunction.NoHTML(t_edjsl.Value), out _ac_jp_two_num);
                if (!_ret)
                    _ac_jp_two_num = 0;
                wa.ac_jp_two_num = _ac_jp_two_num;

                int _ac_jp_three_num = 0;
                _ret = int.TryParse(comFunction.NoHTML(t_sdjsl.Value), out _ac_jp_three_num);
                if (!_ret)
                    _ac_jp_three_num = 0;
                wa.ac_jp_three_num = _ac_jp_three_num;

                wa.ac_cf_info = t_cfxinxi.Value;
                //wa.wid = Session["wid"] != null ? Convert.ToInt32(Session["wID"]) : 0; //暂时用0测试

                wa.hits = 0;
                wa.views = 0;

                int _ac_totlenum = 0;
                _ret = int.TryParse(comFunction.NoHTML(t_yjhdrs.Value), out _ac_totlenum);
                if (!_ret)
                    _ac_totlenum = 0;
                wa.ac_totlenum = _ac_totlenum;

                wa.ac_men_num = shuliang;
                if (!RemindMessageEmpty(wa.ac_title, "活动名称不能为空！"))
                    return;
                if (!RemindMessageLengh(wa.ac_title.Length, 50, "活动名称字数不能超过50！"))
                    return;

                if (!RemindMessageEmpty(wa.ac_dj_info, "兑奖信息不能为空！"))
                    return;
                if (!RemindMessageLengh(wa.ac_dj_info.Length, 100, "兑奖信息字数不能超过100！"))
                    return;

                if (!RemindMessageEmpty(wa.ac_zj_info, "中奖提示不能为空！"))
                    return;
                if (!RemindMessageLengh(wa.ac_zj_info.Length, 255, "中奖字数不能超过255！"))
                    return;

                if (!RemindMessageEmpty(wa.ac_cf_info, "重复抽奖回复不能为空！"))
                    return;
                if (!RemindMessageLengh(wa.ac_cf_info.Length, 255, "重复抽奖回复字数不能超过255！"))
                    return;

                if (!RemindMessageEmpty(wa.ac_end_title, "活动结束公告主题不能为空！"))
                    return;
                if (!RemindMessageLengh(wa.ac_end_title.Length, 50, "活动结束公告主题字数不能超过50！"))
                    return;
                if (!RemindMessageEmpty(wa.ac_jp_one, "一等奖名称不能为空！"))
                    return;
                if (!RemindMessageLengh(wa.ac_jp_one.Length, 50, "一等奖名称字数不能超过50！"))
                    return;
                if (!RemindMessageEmpty(t_ydjsl.Value, "一等奖数量不能为空！"))
                    return;
                if (!RemindMessageLengh(t_ydjsl.Value.Length, 50, "一等奖数量字数不能超过50！"))
                    return;
                if (!RemindMessageEmpty(t_yjhdrs.Value, "预计活动人数不能为空！"))
                    return;
                if (!RemindMessageLengh(t_yjhdrs.Value.Length, 50, "预计活动人数的字数不能超过50！"))
                    return;

                if (!RemindMessageEmpty(t_yxcimgr.Value, "每人最多允许抽奖次数！"))
                    return;
                if (!RemindMessageLengh(t_yxcimgr.Value.Length, 50, "每人最多允许抽奖次数的字数不能超过50！"))
                    return;

                string _t_gifkaishi = t_kaishidizhi.Value; //开始图片
                if (_t_gifkaishi != "")
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
                        if (up.UploadPic(t_kaishidizhi) != 0)
                        {
                            _t_gifkaishi = up.getTargetFilename();
                            wa.ac_b_gif = _t_gifkaishi;
                        }
                    }
                    finally { up = null; }
                }
                string _t_gifjieshu = jieshufile.Value;//结束图片
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
                        if (up.UploadPic(jieshufile) != 0)
                        {
                            _t_gifjieshu = up.getTargetFilename();
                            wa.ac_e_gif = _t_gifjieshu;
                        }
                    }
                    finally { up = null; }
                }

                if (Request["id"] != null)
                {
                    try
                    {
                        //if (DateTime.Now > wa.ac_bdate)
                        //{
                        //    Show_Have_Url("对不起活动已经开始不能修改！", "", 1);
                        //    return;
                        //}

                        wa.Update();
                        Show_Have_Url("修改成功！", "TurntableList.aspx?wid=" + Session["wID"].ToString(), 0);
                    }
                    catch (System.Exception ex)
                    {
                        Show_Have_Url("修改失败！", "", 1);
                    }
                }
                else
                {
                    try
                    {

                        //图片开始暂时不能 wa.ac_b_gif = t_kaishidizhi =jieshufile  ac_e_gif
                        //typeid 暂时没有                   

                        wa.Update();
                        Show_Have_Url("添加成功！", "TurntableList.aspx?wid=" + Session["wID"].ToString(), 0);

                    }
                    catch (System.Exception ex)
                    {
                        Show_Have_Url("添加失败！", "", 1);
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/actions/Edit_Action.cs", Session["wID"].ToString());
            }
        }
        /// <summary>
        /// lt_result显示信息
        /// </summary>
        /// <param name="_str"></param>
        /// <param name="_url"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private string Show_Have_Url(string _str, string _url, int flag)
        {
            lt_result.Text = _str;
            if (flag == 0)
                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='" + _url + "';},300);</script>";
            string ret = lt_result.Text;
            return ret;
        }
        /// <summary>
        /// 输入文字提示
        /// </summary>
        /// <param name="_input"></param>
        /// <param name="_str"></param>
        /// <param name="_url"></param>
        private bool RemindMessageEmpty(string _input, string _str)
        {
            bool ret = true;

            if (_input == "")
            {
                Show_Have_Url(_str, "", 1);
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// 输入长度提示
        /// </summary>
        /// <param name="_realLength"></param>
        /// <param name="_length"></param>
        /// <param name="_str"></param>
        /// <param name="_url"></param>
        private bool RemindMessageLengh(int _realLength, int _length, string _str)
        {
            bool ret = true;
            if (_realLength > _length)
            {
                Show_Have_Url(_str, "", 1);
                ret = false;

            }
            return ret;
        }
    }
}