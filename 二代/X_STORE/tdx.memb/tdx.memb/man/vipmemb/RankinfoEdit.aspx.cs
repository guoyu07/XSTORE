using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.vipmemb
{
    public partial class RankinfoEdit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 配置您的微信会员卡等级。";
                    over.Style.Add(HtmlTextWriterStyle.Display, "none");
                    if (Request["id"] != null)
                    {
                        //编辑
                        int id = Convert.ToInt32(Request["id"]);//找到编辑VIP等级的钱包ID
                        B2C_rankinfo _br = new B2C_rankinfo(id);
                        name.Value = _br.name;
                        score.Value = _br.score.ToString();
                        overdays.Value = _br.overdays.ToString();
                        des.Value = _br.des;
                    }
                    else
                    {
                        //添加
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/RankinfoEdit.cs", Session["wID"].ToString());
                }
                //    if (Request["index"] != null)
                //    {
                //        jifen.Style.Add(HtmlTextWriterStyle.Display, "none");
                //    }
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (Request["id"] != null)
                {
                    try
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        string _score = comFunction.NoHTML(score.Value);
                        string _overdays = comFunction.NoHTML(overdays.Value);
                        B2C_rankinfo _br = new B2C_rankinfo(id);
                        _br.name = comFunction.NoHTML(name.Value);
                        if (_br.name == "")
                        {
                            lt_result.Text = "名称不能为空！";
                            return;
                        }
                        if (_score == "")
                        {
                            lt_result.Text = "等级积分条件不能为空！";
                            return;
                        }
                        if (_overdays == "")
                        {
                            lt_result.Text = "过期天数不能为空！";
                            return;
                        }
                        int _Score = 0;
                        bool _isTrue = true;
                        _isTrue = int.TryParse(_score, out _Score);
                        if (!_isTrue)
                        {
                            lt_result.Text = "等级积分条件必须为大于0的整数！";
                            return;
                        }
                        else if (_Score < 0)
                        {
                            lt_result.Text = "等级积分条件必须为大于0的整数！";
                            return;
                        }
                        _br.score = _Score;
                        int _Over = 20;
                        _isTrue = true;
                        _isTrue = int.TryParse(overdays.Value, out _Over);
                        if (!_isTrue)
                        {
                            lt_result.Text = "过期天数必须为大于0的整数！";
                            return;
                        }
                        else if (_Over < 0)
                        {
                            lt_result.Text = "过期天数必须为大于0的整数！";
                            return;
                        }

                        _br.overdays = _Over;
                        _br.des = comFunction.NoHTML(des.Value);
                        _br.Update();
                        commonTool.Show_Have_Url(lt_result, "修改成功！", "Rankinfo.aspx", 0);
                    }
                    catch
                    {
                        commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);
                    }
                }
                else
                {//添加钱包规则
                    try
                    {
                        if (Session["wid"] != null)
                        {
                            B2C_vipcard _bv = new B2C_vipcard(Session["wid"].ToString());
                            B2C_rankinfo _br = new B2C_rankinfo();
                            string _score = comFunction.NoHTML(score.Value);
                            string _overdays = comFunction.NoHTML(overdays.Value);
                            _br.name = comFunction.NoHTML(name.Value);
                            if (_br.name == "")
                            {
                                lt_result.Text = "名称不能为空！";
                                return;
                            }
                            if (_score == "")
                            {
                                lt_result.Text = "等级积分条件不能为空！";
                                return;
                            }
                            if (_overdays == "")
                            {
                                lt_result.Text = "过期天数不能为空！";
                                return;
                            }
                            int _Score = 0;
                            bool _isTrue = true;
                            _isTrue = int.TryParse(_score, out _Score);
                            if (!_isTrue)
                            {
                                lt_result.Text = "等级积分条件必须为大于0的整数！";
                                return;
                            }
                            else if (_Score < 0)
                            {
                                lt_result.Text = "等级积分条件必须为大于0的整数！";
                                return;
                            }
                            _br.score = _Score;
                            int _Over = 20;
                            _isTrue = true;
                            _isTrue = int.TryParse(overdays.Value, out _Over);
                            if (!_isTrue)
                            {
                                lt_result.Text = "过期天数必须为大于0的整数！";
                                return;
                            }
                            else if (_Over < 0)
                            {
                                lt_result.Text = "过期天数必须为大于0的整数！";
                                return;
                            }

                            _br.overdays = _Over;
                            _br.des = comFunction.NoHTML(des.Value);
                            _br.cardid = _bv.id;//Convert.ToInt32(Request["cardId"]);
                            _br.Update();
                            commonTool.Show_Have_Url(lt_result, "添加成功！", "Rankinfo.aspx", 0);
                        }
                        else
                        {
                            commonTool.Show_Have_Url(lt_result, "添加失败,请重试！", "", 1);
                        }
                    }
                    catch
                    {
                        commonTool.Show_Have_Url(lt_result, "添加失败！", "", 1);

                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/RankinfoEdit.cs", Session["wID"].ToString());
            }

        }
        internal bool verify()
        {
            bool isTrue = true;
            int temp = 0;
            if (!int.TryParse(score.Value, out temp))
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "积分必须为大于0的整数！", "", 1);
            }
            else if (temp < 0)
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "积分必须为大于0的整数！", "", 1);
            }
            else if (string.IsNullOrEmpty(name.Value.Trim()))
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "等级名称不能为空！", "", 1);
            }
            return isTrue;
        }
    }
}