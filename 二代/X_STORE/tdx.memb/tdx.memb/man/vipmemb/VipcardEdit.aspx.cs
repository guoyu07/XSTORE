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

namespace tdx.memb.man.vipmemb
{
    public partial class VipcardEdit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 配置您的微信会员卡的样式";
                if (Session["wid"] != null)
                {
                    try
                    {
                        string _sql = "*";
                        string wid = Session["wid"].ToString();
                        B2C_vipcard _bv = new B2C_vipcard(wid);
                        if (_bv.id == 0)
                        {
                            //么有会员卡信息,添加一条默认会员卡信息
                            _bv.is_open = 1;
                            _bv.name = "会员卡";
                            _bv.pre_name = "0000";
                            _bv.acc_card = 1;
                            _bv.card_start = 1;
                            _bv.wid = Convert.ToInt32(wid);
                            _bv.create_time = DateTime.Now;
                            B2C_AccountConfig _ba;
                            _ba = new B2C_AccountConfig();
                            _ba.wid = Convert.ToInt32(wid);
                            _ba.category = 1;
                            _ba.opened = 1;//添加积分配置，默认开启
                            _ba.Update();
                            _ba = new B2C_AccountConfig();
                            _ba.wid = Convert.ToInt32(wid);
                            _ba.category = 2;
                            _ba.opened = 1;//添加钱包配置，默认开启
                            _ba.Update();
                            _bv.Update();
                        }
                        _bv = new B2C_vipcard(wid);
                        string _str = "select * from wx_config"; // where id=" + wid
                        DataTable _dt = comfun.GetDataTableBySQL(_str);
                        string _wwx = _dt.Rows[0]["wx_ID"].ToString();
                        lt_friendly.Text += "<br/>友情提示：会员卡入口地址:http://www.tdx.cn/appv/shownews.aspx?id=" + _bv.id.ToString() + "&wwx=" + _wwx;
                        if (_bv.is_open == 1)
                        {
                            is_open.Checked = true;
                        }
                        else
                        {
                            is_open.Checked = false;
                        }
                        name.Value = _bv.name;
                        //title_image.Value = _bv.title_image;
                        image.Src = _bv.title_image;
                        pre_name.Value = _bv.pre_name;
                        card_start.Value = _bv.card_start.ToString();
                        SetTJ();
                        no_getinfo.Value = _bv.no_getinfo;
                        card_info.Value = _bv.card_info;
                        string _where = "cardid=" + _bv.id;
                        DataTable dt = B2C_rankinfo.GetList(_sql, _where);
                        if (dt.Rows.Count > 0)
                        {
                        }
                        else
                        {
                            B2C_rankinfo _br = new B2C_rankinfo();
                            _br.name = "普通会员卡";
                            _br.score = 0;
                            _br.overdays = 0;
                            _br.des = "";
                            _br.cardid = _bv.id;
                            _br.create_time = DateTime.Now;
                            _br.Update();
                        }
                        _sql = "top(2) *";
                        _where = "wid=" + wid;
                        DataTable _item = B2C_AccountConfig.GetList(_sql, _where);//加载配置表信息
                        if (_item.Rows.Count < 1)
                        {
                            B2C_AccountConfig _ba;//没找到配置信息,添加默认配置信息
                            _ba = new B2C_AccountConfig();
                            _ba.wid = Convert.ToInt32(wid);
                            _ba.category = 1;
                            _ba.opened = 1;//添加积分配置，默认开启
                            _ba.Update();
                            _ba = new B2C_AccountConfig();
                            _ba.wid = Convert.ToInt32(wid);
                            _ba.category = 2;
                            _ba.opened = 1;//添加钱包配置，默认开启
                            _ba.Update();
                        }
                        else
                        {
                            foreach (DataRow dr in _item.Rows)
                            {
                                if (dr["category"].ToString().Equals("1"))
                                { //积分
                                    if (Convert.ToInt32(dr["opened"]) == 1)
                                    { //开启
                                        j_open.Checked = true;
                                    }
                                    else
                                    {
                                        j_open.Checked = false;
                                    }
                                }
                                else if (dr["category"].ToString().Equals("2"))
                                {
                                    if (Convert.ToInt32(dr["opened"]) == 1)
                                    { //开启
                                        m_open.Checked = true;
                                    }
                                    else
                                    {
                                        m_open.Checked = false;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        commonTool.Show_Have_Url(lt_result, "初始化失败!", "VipcardEdit.aspx", 0);
                        comfun.ChuliException(ex, "man/vipmemb/vipcardEdit.cs", Session["wID"].ToString());
                    }
                }
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            if (verify())
            {
                if (Session["wid"] != null)
                {
                    try
                    {
                        string wid = Session["wid"].ToString();
                        B2C_vipcard _bv = new B2C_vipcard(wid);
                        if (is_open.Checked)
                        {
                            _bv.is_open = 1;
                            //处理没有等级的会员信息
                        }
                        else
                        {
                            _bv.is_open = 0;
                        }
                        _bv.name = comFunction.NoHTML(name.Value);
                        string image = getImgUrl(title_image.Value);
                        if (!string.IsNullOrEmpty(image))
                        {
                            _bv.title_image = image;
                        }
                        _bv.pre_name = comFunction.NoHTML(pre_name.Value);
                        _bv.card_start = Convert.ToInt32(card_start.Value);
                        _bv.get_card_condition = 0;
                        _bv.no_getinfo = comFunction.NoHTML(no_getinfo.Value);
                        _bv.card_info = comFunction.NoHTML(card_info.Value);
                        _bv.Update();
                        B2C_AccountConfig _ba;
                        if (m_open.Checked)
                        {
                            _ba = new B2C_AccountConfig(2, Convert.ToInt32(wid));//加载对应的钱包信息
                            _ba.opened = 1;
                            _ba.Update();
                        }
                        else
                        {
                            _ba = new B2C_AccountConfig(2, Convert.ToInt32(wid));
                            _ba.opened = 0;
                            _ba.Update();
                        }
                        if (j_open.Checked)
                        {
                            _ba = new B2C_AccountConfig(1, Convert.ToInt32(wid));//加载对应的积分信息
                            _ba.opened = 1;
                            _ba.Update();
                        }
                        else
                        {
                            _ba = new B2C_AccountConfig(1, Convert.ToInt32(wid));//加载对应的积分信息
                            _ba.opened = 0;
                            _ba.Update();
                        }
                        if (is_open.Checked)
                        {
                            B2C_mem.CheckRankID(Convert.ToInt32(wid));
                        }
                        commonTool.Show_Have_Url(lt_result, "修改成功！", "VipcardEdit.aspx", 0);
                    }
                    catch (Exception ex)
                    {
                        commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);
                    }
                }
            }
        }
        internal void SetTJ()
        {
            ListItem lt;
            lt = new ListItem();
            lt.Value = "0";
            lt.Text = "普通用户";
            get_card_condition.Items.Add(lt);
        }
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
                    if (up.UploadPic(title_image) != 0)
                    {
                        _url_i = up.getTargetFilename();
                    }
                }
                finally { up = null; }
            }
            return _url_i;
        }
        internal bool verify()
        {
            bool isTrue = true;
            int _cs = 0;
            if (!int.TryParse(comFunction.NoHTML(card_start.Value.ToString()), out _cs))
            {
                if (_cs < 0)
                {
                    isTrue = false;
                    commonTool.Show_Have_Url(lt_result, "起始卡号必须大于等于0！", "", 1);


                }
                else
                {
                    isTrue = false;
                    commonTool.Show_Have_Url(lt_result, "起始卡号必须为数字！", "", 1);
                }
            }
            else
            {
                if (_cs < 0)
                {
                    isTrue = false;
                    commonTool.Show_Have_Url(lt_result, "起始卡号必须大于等于0！", "", 1);
                }
            }
            if (string.IsNullOrEmpty(comFunction.NoHTML(name.Value.Trim())))
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "会员卡名不能为空！", "", 1);
            }
            return isTrue;
        }
    }
}