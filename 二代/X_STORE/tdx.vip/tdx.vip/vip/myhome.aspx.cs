using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using tdx.Weixin;

namespace tdx.vip
{
    public partial class myhome : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request["WWV"] != null)
                {
                    My_Order.Text = "<a href=\"orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + Request["WWV"].ToString() + "\">我的订单 </a>";
                    My_bill.Text = "<a href='####'>我的账单</a>";
                    My_convert.Text = "<a href='####'>我的兑换</a>";
                    My_cheap.Text = "<a href='coupon.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + Request["WWV"].ToString() + "''>我的优惠券</a>";
                    string _wwv = Request["WWV"].ToString();
                    cardShow(_wwv);
                    GetInfo();
                }
                else if (Session["WWV"] != null)
                {
                    My_Order.Text = "<a href=\"orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + Session["WWV"].ToString() + "\">我的订单 </a>";
                    My_bill.Text = "<a href='####'>我的账单</a>";
                    My_convert.Text = "<a href='####'>我的兑换</a>";
                    My_cheap.Text = "<a href='coupon.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + Session["WWV"].ToString() + "''>我的优惠券</a>";
                    string _wwv = Session["WWV"].ToString();
                    cardShow(_wwv);
                    GetInfo();

                }
                else
                {
                    moneyHave.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&devide=2" + "'><span>金额</span>0.00</span></a>";
                    jifenHave.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&devide=1" + "'><span>积分</span><span>0</span></a>";
                }
            }
        }

        private void cardShow(string _wwv)
        {
            string _sql = "select * from B2C_mem where M_card='" + _wwv + "' and cityID=" + Session["wID"].ToString()+";";
            _sql += "select * from B2C_worker where id="+Session["wID"].ToString()+";";
            _sql += "select * from B2C_vipcard where wid="+Session["wID"].ToString();
            DataSet _ds = comfun.GetDataSetBySQL(_sql);
            DataTable _dt = _ds.Tables[0];
            DataTable _dt_w = _ds.Tables[1];
            DataTable _dt_card = _ds.Tables[2];
            if (_dt != null && _dt.Rows.Count > 0)
            {
                B2C_user_rank _bur = new B2C_user_rank(_dt.Rows[0]["id"].ToString());
                cardSh.Text = "会员名:" + _dt.Rows[0]["M_name"].ToString();
                bianhao.Text = "编号：" + _bur.card_number;
                cardRanfo.Text = B2C_rankinfo.RankinfoName(Convert.ToInt32(_dt.Rows[0]["id"].ToString()));                
                if (_dt_card != null && _dt_card.Rows.Count > 0)
                {
                    imgHead.Src = _dt_card.Rows[0]["title_image"].ToString();
                }
                string _sql1 = "select top 1 * from C2C_Account where uid=" + _dt.Rows[0]["id"].ToString() + " and ptid=2 order by id desc;";
                _sql1 += "select top 1 * from C2C_Account where uid=" + _dt.Rows[0]["id"].ToString() + " and ptid=1 order by id desc;";
                DataSet ds = comfun.GetDataSetBySQL(_sql1);
                DataTable dt_money = ds.Tables[0];
                DataTable dt_jifen = ds.Tables[1];
                if (dt_money != null && dt_money.Rows.Count > 0)
                {
                    moneyHave.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString()+ "&WWV=" + _wwv + "&devide=2" + "'><span>金额</span>" + dt_money.Rows[0]["ac_Amt"].ToString() + "</span></a>";
                }
                else
                {
                    moneyHave.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2" + "'><span>金额</span>0.00</span></a>";
                }
                if (dt_jifen != null && dt_jifen.Rows.Count > 0)
                {
                    jifenHave.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1" + "'><span>积分</span><span>" + Convert.ToDouble(dt_jifen.Rows[0]["ac_Amt"].ToString()).ToString("F0") + "</span></a>";
                }
                else
                {
                    jifenHave.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1" + "'><span>积分</span><span>0</span></a>";
                }

            }
            else
            {
                //Response.Write("<script language='javascript'>location.href='../"+_dt_w.Rows[0]["wx_GNTheme"].ToString()+"/index.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "';</script>");
                Response.Write("<script language='javascript'>location.href='regvip.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "';</script>");
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
                if (dr["payorcost"].ToString() == "1")
                {
                    if (dr["category"].ToString() == "1")
                    {
                        resultRule += "充值" + dr["amount"].ToString() + "元，赠送" + dr["give_amount"].ToString() + "积分。";
                    }
                    else
                    {
                        resultRule += "充值" + dr["amount"].ToString() + "元，赠送" + dr["give_amount"].ToString() + "元。";
                    }
                }
                else
                {
                    if (dr["category"].ToString() == "1")
                    {
                        resultRule += "消费" + dr["amount"].ToString() + "元，赠送" + dr["give_amount"].ToString() + "积分。";
                    }
                    else
                    {
                        resultRule += "消费" + dr["amount"].ToString() + "元，赠送" + dr["give_amount"].ToString() + "元。";
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

    }
}