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
    public partial class Voucher_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>在这里，编辑您的代金卷信息。";
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        C2C_voucher c_voucher = new C2C_voucher(id);
                        num.Value = c_voucher.v_num.ToString();
                        amount.Value = c_voucher.v_amount.ToString();
                        amount.Disabled = true;
                        deduction.Value = c_voucher.v_deduction.ToString();
                        deduction.Disabled = true;
                        start_time.Value = c_voucher.v_start_time.ToString("yyyy-MM-dd");
                        start_time.Disabled = true;
                        end_time.Value = c_voucher.v_end_time.ToString("yyyy-MM-dd");
                        end_time.Disabled = true;
                        isactive.Value = c_voucher.v_isactive.ToString();
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
                string _num = num.Value;
                string _amount = amount.Value;
                string _deduction = deduction.Value;
                string _start_time = start_time.Value;
                string _end_time = end_time.Value;
                int _isactive = int.Parse(isactive.Value);
                int _wid = int.Parse(Session["wID"].ToString());

                if (_num == "" || int.Parse(_num) == 0)
                {
                    lt_result.Text = "发行量必须大于0";
                    return;
                }
                if (_amount == "" || int.Parse(_amount) == 0)
                {
                    lt_result.Text = "使用金额条件必须大于0";
                    return;
                }
                if (_deduction == "" || int.Parse(_deduction) == 0)
                {
                    lt_result.Text = "抵扣金额必须大于0";
                    return;
                }
                if (_start_time == "")
                {
                    lt_result.Text = "开始时间不可为空";
                    return;
                }

                if (_end_time == "" || (Convert.ToDateTime(_end_time) - Convert.ToDateTime(_start_time)).TotalSeconds < 0)
                {
                    lt_result.Text = "结束时间不可为空,且结束时间必须大于开始时间";
                    return;
                }
                if (Request["id"] != null)
                {
                    try
                    {
                        int _id = Convert.ToInt32(Request["id"]);
                        C2C_voucher voucher = new C2C_voucher(_id);
                        voucher.id = _id;
                        if (voucher.v_num <= int.Parse(_num))
                        {
                            voucher.v_num = int.Parse(_num);
                        }
                        else
                        {
                            lt_result.Text = "使用金额条件必须大于等于当前数值";
                            return;
                        }
                        voucher.v_amount = int.Parse(_amount);
                        voucher.v_deduction = int.Parse(_deduction);
                        voucher.v_start_time = Convert.ToDateTime(_start_time);
                        voucher.v_end_time = Convert.ToDateTime(_end_time);
                        voucher.v_isactive = _isactive;
                        voucher.wid = _wid;
                        voucher.Update();
                        lt_result.Text = "修改成功!";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Voucher_List.aspx';},300);</script>";

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
                        C2C_voucher voucher = new C2C_voucher();
                        voucher.AddNew();
                        voucher.v_num = int.Parse(_num);
                        voucher.v_amount = int.Parse(_amount);
                        voucher.v_deduction = int.Parse(_deduction);
                        voucher.v_start_time = Convert.ToDateTime(_start_time);
                        voucher.v_end_time = Convert.ToDateTime(_end_time);
                        voucher.v_isactive = _isactive;
                        voucher.wid = _wid;
                        voucher.Update();
                        lt_result.Text = "修改成功!";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Voucher_List.aspx';},300);</script>";

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
    }
}