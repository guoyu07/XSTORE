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

namespace tdx.memb.man.vipmemb
{
    public partial class WalletEdit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    //编辑
                    pay.Checked = true;
                    int id = Convert.ToInt32(Request["id"]);//找到编辑对应的钱包ID
                    B2C_wallet _bw = new B2C_wallet(id);
                    SetRank(_bw.rankid);
                    if (_bw.payorcost == 1)
                    {
                        pay.Checked = true;
                    }
                    if (_bw.payorcost == -1)
                    {
                        cost.Checked = true;
                    }
                    star_time.Value = _bw.star_time.ToString("yyyy-MM-dd");
                    end_time.Value = _bw.end_time.ToString("yyyy-MM-dd");
                    if (_bw.is_fandian == 0)
                    {
                        is_fandian.Checked = false;
                        isBfb2.InnerText = "元";
                        //isYuan1.Style.Add(HtmlTextWriterStyle.Display, "block");
                        //isYuan2.Style.Add(HtmlTextWriterStyle.Display, "block");
                        //isBfb1.Attributes.Add("display", "block");
                        ////isBfb1.Style.Add(HtmlTextWriterStyle.Display, "none");
                        //isBfb1.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                    else
                    {
                        is_fandian.Checked = true;
                        isBfb2.InnerText = "%";
                        //isYuan1.Style.Add(HtmlTextWriterStyle.Display, "none");
                        //isYuan2.Style.Add(HtmlTextWriterStyle.Display, "none");
                        //isBfb1.Style.Add(HtmlTextWriterStyle.Display, "block");
                        //isBfb1.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                    amount.Value = _bw.amount.ToString();
                    give_amount.Value = _bw.give_amount.ToString();
                    if (_bw.is_add == 1)
                    {
                        is_add.Checked = true;
                    }
                    des.Value = _bw.des;
                }
                else
                {
                    //添加
                    pay.Checked = true;
                    SetRank();
                    this.star_time.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    this.end_time.Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }
        }
        internal void SetRank(int id)
        {
            hf.Value = id.ToString();
            ListItem li;
            int wid = Convert.ToInt32(Session["wid"]);
            string _sql = "*";
            string _where = "cardid in(select id from B2C_vipcard where wid=" + wid + ")";
            DataTable dt = B2C_rankinfo.GetList(_sql, _where);
            foreach (DataRow dr in dt.Rows)
            {

                li = new ListItem();
                li.Value = dr["id"].ToString();
                li.Text = dr["name"].ToString();
                if (id == Convert.ToInt32(dr["id"]))
                {
                    li.Selected = true;
                }
                rankid.Items.Add(li);
            }
        }
        internal void SetRank()
        {
            ListItem li;
            int wid = Convert.ToInt32(Session["wid"]);
            string _sql = "*";
            string _where = "cardid in(select id from B2C_vipcard where wid=" + wid + ")";
            DataTable dt = B2C_rankinfo.GetList(_sql, _where);
            int index = 0;
            foreach (DataRow dr in dt.Rows)
            {
                li = new ListItem();
                li.Value = dr["id"].ToString();
                li.Text = dr["name"].ToString();
                if (index == 0)
                {
                    li.Selected = true;
                    hf.Value = dr["id"].ToString();
                    index++;
                }
                rankid.Items.Add(li);
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            if (verify())
            {
                if (Request["id"] != null && Session["wid"] != null)
                {
                    try
                    {
                        //编辑
                        B2C_wallet _bw = new B2C_wallet(Convert.ToInt32(Request["id"]));
                        if (pay.Checked)
                        {
                            _bw.payorcost = 1;
                        }
                        if (cost.Checked)
                        {
                            _bw.payorcost = -1;
                        }
                        _bw.amount = Convert.ToDouble(amount.Value);
                        _bw.give_amount = Convert.ToDouble(give_amount.Value);
                        if (is_add.Checked)
                        {
                            _bw.is_add = 1;
                        }
                        else
                        {
                            _bw.is_add = 0;
                        }
                        if (is_fandian.Checked == true)
                        {
                            _bw.is_fandian = 1;
                            if (_bw.give_amount <= 0 || _bw.give_amount > 100)
                            {
                                lt_result.Text = "选择返点时,返还额度必须在0到100之间(即返还0%到100%之间)";
                                return;
                            }
                        }
                        else
                        {
                            _bw.is_fandian = 0;
                        }
                        _bw.star_time = Convert.ToDateTime(star_time.Value);
                        _bw.end_time = Convert.ToDateTime(end_time.Value);
                        _bw.rankid = Convert.ToInt32(hf.Value);
                        _bw.des = comFunction.NoSt(des.Value);

                        _bw.Update();
                        commonTool.Show_Have_Url(lt_result, "修改成功！", "Wallet.aspx", 0);
                    }
                    catch
                    {
                        commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);

                    }
                }
                else if (Session["wid"] != null)
                {
                    //添加
                    try
                    {
                        B2C_wallet _bw = Get_wallet();
                        _bw.wid = Convert.ToInt32(Session["wid"]);
                        if (_bw.is_fandian == 1)
                        {
                            if (_bw.give_amount <= 0 || _bw.give_amount > 100)
                            {
                                lt_result.Text = "选择返点时,返还额度必须在0到100之间(即返还0%到100%之间)";
                                return;
                            }
                        }
                        _bw.Update();
                        commonTool.Show_Have_Url(lt_result, "添加成功！", "Wallet.aspx", 0);
                    }
                    catch
                    {
                        commonTool.Show_Have_Url(lt_result, "添加失败！", "", 1);
                    }
                }
            }
        }
        internal B2C_wallet Get_wallet()
        {
            B2C_wallet _bw = new B2C_wallet();
            if (pay.Checked)
            {
                _bw.payorcost = 1;
            }
            if (cost.Checked)
            {
                _bw.payorcost = -1;
            }
            _bw.amount = Convert.ToDouble(amount.Value);
            _bw.rankid = Convert.ToInt32(hf.Value);
            _bw.give_amount = Convert.ToDouble(give_amount.Value);
            if (is_add.Checked)
            {
                _bw.is_add = 1;
            }
            if (is_fandian.Checked == true)
            {
                _bw.is_fandian = 1;

            }
            else
            {
                _bw.is_fandian = 0;
            }
            _bw.star_time = Convert.ToDateTime(star_time.Value);
            _bw.end_time = Convert.ToDateTime(end_time.Value);
            _bw.category = 2;
            _bw.des = des.Value;
            return _bw;
        }
        internal bool verify()
        {
            bool isTrue = true;
            double amount = 0;
            double give_amount = 0;
            if (!double.TryParse(comFunction.NoHTML(this.amount.Value.ToString()), out amount))
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "产生的费用输入不规范！", "", 1);

            }
            else if (!double.TryParse(comFunction.NoHTML(this.give_amount.Value.ToString()), out give_amount))
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "返还额度输入不规范！", "", 1);
            }
            else if (amount < 0)
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "产生的费用不能为负数！", "", 1);
            }
            else if (give_amount < 0)
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "返还额度不能为负数！", "", 1);
            }
            else if (string.IsNullOrEmpty(star_time.Value) || string.IsNullOrEmpty(end_time.Value))
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "开始时间和结束时间不能为空！", "", 1);
            }
            else if (Convert.ToDateTime(star_time.Value) > Convert.ToDateTime(end_time.Value))
            {
                isTrue = false;
                commonTool.Show_Have_Url(lt_result, "开始时间不能大于结束时间！", "", 1);
            }
            return isTrue;
        }
    }
}