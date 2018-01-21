using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.database;
using tdx.database.database;
using tdx.Weixin;

namespace Wx_NewWeb.Talk
{
    public partial class DistriBution_TiXian : weixinAuth
    {
        public static string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DistriBution_head1.page = "提现申请";
            openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
        }

        protected void button_OnClick(object sender, EventArgs e)
        {
            int isactive = 0;
            string _jine = txt_M_psw.Value;

            int _mid = Convert.ToInt32(DbHelperSQL.Query("select top 1 id from B2C_mem where openid='"+openid+"'").Tables[0].Rows[0][0]);



            B2C_mem bm = new B2C_mem(_mid);
            DataTable dt =
                DbHelperSQL.Query(
                    "select top 1 ac_amt from b2c_account where ptid=2 and b2c_account.mid=" + _mid + " order by id desc").Tables[0];
            string _yue = "0";
            if (dt.Rows.Count > 0)
            {
                _yue = dt.Rows[0][0].ToString();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('申请失败，余额不足！');history.go(-1);</script>");
                Response.End();
                return;
            }


            //B2C_mem bm = new B2C_mem(_mid);
            //string _yue = bm._cent.ToString();

            if (Convert.ToDecimal(_jine) < 0)
            {
                Response.Write("<script language='javascript'>alert('金额不能为负数！');history.go(-1);</script>");
                Response.End();
                return;
            }
            else if (Convert.ToDecimal(_jine) == 0)
            {
                Response.Write("<script language='javascript'>alert('申请失败，提现金额不能为0！');history.go(-1);</script>");
                Response.End();
                return;
            }
            else if (Convert.ToDecimal(_yue) < Convert.ToDecimal(_jine))
            {
                Response.Write("<script language='javascript'>alert('申请失败，余额不足！');history.go(-1);</script>");
                Response.End();
                return;
            }

            appsConfig apps = new appsConfig();
            apps.init();


                try
                {
                    double _tixianMoney1 = Convert.ToDouble(_jine) * (1 - apps._tixianZhekou);
                    double _tixianMoney2 = Convert.ToDouble(_jine) * apps._tixianZhekou;

                    B2C_tixian tixian = new B2C_tixian();
                    tixian.AddNew();
                    tixian.mid = _mid;
                    tixian.tx_money = Convert.ToDecimal(_tixianMoney1);
                    tixian.isActive = isactive;
                    tixian.Update();

                    //扣款
                    B2C_Account ba = new B2C_Account();
                    ba.mid = _mid;
                    ba.ptid = 2;
                    ba.cno = "005";
                    ba.ac_money = _tixianMoney1*(-1);
                    ba.ac_des = "提现";
                    ba.Update();

                    ba.AddNew();
                    ba.mid = _mid;
                    ba.ptid = 2;
                    ba.cno = "010"; //要看看提现手续费的科目编号 
                    ba.ac_money = _tixianMoney2*(-1);
                    ba.ac_des = "提现手续费";
                    ba.Update();


                    Response.Write("<script language='javascript'>alert('申请成功！');location.href='DistriBution_Main.aspx';</script>");
                    Response.End();

                }
                catch (Exception ex)
                {
                    throw ex;
                }


        }


    }
}