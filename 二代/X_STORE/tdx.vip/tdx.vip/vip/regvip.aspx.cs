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
using System.Text.RegularExpressions;
using tdx.Weixin;

namespace tdx.vip
{
    public partial class regvip : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request["WWV"] != null)
                    {
                        string _sql = "select * from B2C_mem where M_card='" + Request["WWV"].ToString() + "' and cityID=" + Session["wID"].ToString();
                        DataTable dt = comfun.GetDataTableBySQL(_sql);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            Response.Write("<script language='javascript'>location.href='../vip/myhome.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + Request["WWV"].ToString() + "';</script>");
                        }
                        else
                        {
                            GetInfo();
                        }

                    }
                    else if (Session["WWV"] != null)
                    {
                        string _sql = "select * from B2C_mem where M_card='" + Session["WWV"].ToString() + "' and cityID=" + Session["wID"].ToString();
                        DataTable dt = comfun.GetDataTableBySQL(_sql);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            Response.Write("<script language='javascript'>location.href='../vip/myhome.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + Session["WWV"].ToString() + "';</script>");
                        }
                        else
                        {
                            GetInfo();
                        }
                    }
                    else
                    {
                        GetInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "tdxvip/vip/regvip.aspx", Session["wID"].ToString());
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        private void GetInfo()
        {
            try
            {
                int _wid = Convert.ToInt32(Session["wID"].ToString());
                string _sql = "select * from B2C_vipcard where wid=" + _wid + ";";//对应的会员说明
                _sql += "select  * from B2C_wallet where isdel<>1 and wid=" + _wid + " order by category;";//钱包规则和积分规则
                _sql += "select * from B2C_Franchises where group_id in (" + "select id from B2C_group_fran where wid=" + _wid + ");";
                DataSet ds = comfun.GetDataSetBySQL(_sql);
                DataTable dtDes = ds.Tables[0];
                DataTable dtRule = ds.Tables[1];
                DataTable dtSpecial = ds.Tables[2];

                cardDes.Text = GetDes(dtDes);//会员卡说明
                cardRule.Text = GetRule(dtRule);//规则
                cardSpecial.Text = GetSpecial(dtSpecial);//特权

            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "tdxvip/vip/regvip.aspx", Session["wID"].ToString());
            }

        }
        /// <summary>
        /// 获取说明
        /// </summary>
        /// <param name="_dt"></param>
        /// <returns></returns>
        private string GetDes(DataTable _dt)
        {
            string resultDes = "";
            foreach (DataRow dr in _dt.Rows)
            {
                resultDes += "\r\n";
                resultDes += "\r\n<p>";
                resultDes += "\r\n" + dr["card_info"].ToString();
                resultDes += "\r\n</p>";
            }
            return resultDes;
        }
        /// <summary>
        /// 获取规则
        /// </summary>
        /// <param name="_dt"></param>
        /// <returns></returns>
        private string GetRule(DataTable _dt)
        {
            string resultRule = "";
            foreach (DataRow dr in _dt.Rows)
            {
                resultRule += "\r\n";
                resultRule += "\r\n<p>";
                if (dr["is_fandian"].ToString() == "1")
                {
                    resultRule += dr["payorcost"].ToString() == "1" ? "充值" + dr["amount"].ToString() + "元，返点" + dr["give_amount"].ToString() + "%。" : "消费" + dr["amount"].ToString() + "元，返点" + dr["give_amount"].ToString() + "%。";
                }
                else
                {
                    if (dr["payorcost"].ToString() == "1")
                    {
                        resultRule += dr["category"].ToString() == "1" ? "充值" + dr["amount"].ToString() + "元，赠送" + dr["give_amount"].ToString() + "积分。" : "充值" + dr["amount"].ToString() + "元，赠送" + dr["give_amount"].ToString() + "元。";
                    }
                    else
                    {
                        resultRule += dr["category"].ToString() == "1" ? "消费" + dr["amount"].ToString() + "元，赠送" + dr["give_amount"].ToString() + "积分。" : "消费" + dr["amount"].ToString() + "元，赠送" + dr["give_amount"].ToString() + "元。";
                    }
                }
                resultRule += "\r\n</p>";
            }
            return resultRule;
        }
        /// <summary>
        /// 获取特权
        /// </summary>
        /// <param name="_dt"></param>
        /// <returns></returns>
        private string GetSpecial(DataTable _dt)
        {
            string resultSpecial = "";
            foreach (DataRow dr in _dt.Rows)
            {
                resultSpecial += "\r\n";
                resultSpecial += "\r\n<p>";
                resultSpecial += "\r\n" + dr["des"].ToString();
                resultSpecial += "\r\n</p>";
            }
            return resultSpecial;
        }
        /// <summary>
        /// 提交注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Submit(object sender, EventArgs e)
        {
            try
            {
                B2C_mem bm = new B2C_mem();
                bm.AddNew();
                B2C_PeopleInfo bp = new B2C_PeopleInfo();
                bp.AddNew();
                bp.weiName = M_wx.Value;
                bm.M_name = M_name.Value;
                bm.M_mobile = M_mobile.Value;
                bm.M_QQ = M_QQ.Value;
                bm.M_IDCard = M_wx.Value;
                if (bm.M_name == "")
                {
                    Response.Write("<script language='javascript'>alert('姓名不能为空！');</script>");
                    return;
                }
                else if (bm.M_mobile == "")
                {
                    Response.Write("<script language='javascript'>alert('手机不能为空！');</script>");
                    return;
                }
                else if (!commonTool.IsMobilePhone(bm.M_mobile))
                {
                    Response.Write("<script language='javascript'>alert('手机输入不合法！');</script>");
                    return;
                }
                else if (bm.M_QQ == "")
                {
                    Response.Write("<script language='javascript'>alert('QQ不能为空！');</script>");
                    return;
                }
                else if (!IsNumber(bm.M_QQ) || (bm.M_QQ.Trim().Length < 4 && bm.M_QQ.Trim().Length > 14))
                {
                    Response.Write("<script language='javascript'>alert('QQ输入不合法！');</script>");
                    return;
                }
                else if (bm.M_IDCard == "")
                {
                    Response.Write("<script language='javascript'>alert('微信号不能为空！');</script>");
                    return;
                }
                else
                {
                    if (Request["WWV"] != null || Session["WWV"] != null)
                    {
                        string _wwv = Request["WWV"] == null ? Session["WWV"].ToString() : Request["WWV"].ToString();
                        bm.M_card = _wwv;
                        bm.cityID = Convert.ToInt32(Session["wID"].ToString());
                        bm.Update();

                        string _sql = "select top 1 * from B2C_mem order by id desc";
                        DataTable _dt = comfun.GetDataTableBySQL(_sql);
                        int _mem_id = Convert.ToInt32(_dt.Rows[0]["id"].ToString());

                        B2C_rankinfo.OpenCard(_mem_id, Convert.ToInt32(Session["wID"].ToString()));
                        bp.wwv = _wwv;
                        bp.memb_id = _mem_id;
                        bp.Update();
                        Response.Write("<script language='javascript'>alert('注册成功！');location.href='../vip/myhome.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "';</script>");

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('无法获取到您的微信信息,注册失败！');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "tdxvip/vip/regvip.aspx", Session["wID"].ToString());
            }

        }

        private bool IsNumber(String strNumber)
        {

            Regex objNotNumberPattern = new Regex("[^0-9.-]");

            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");

            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");

            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";

            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";

            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&

             !objTwoDotPattern.IsMatch(strNumber) &&

             !objTwoMinusPattern.IsMatch(strNumber) &&

             objNumberPattern.IsMatch(strNumber);

        }

    }
}