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

namespace tdx.memb.man.UserCenter
{
    public partial class B2C_tixian_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                B2C_mem mem = new B2C_mem();
                mem.GetDropListOfmem(this.drop_M_vip, "请选择会员");
                B2C_tixian tixian1 = new B2C_tixian();
                //tixian1.GetDropList(this.drop_M_vip, "请选择会员");//获取登录的酒店主的酒店房间类型
                int id = 0;
                if (Request["id"] != null)
                {

                    id = Convert.ToInt32(Request["id"]);
                    B2C_tixian tixian = new B2C_tixian(id);
                    drop_M_vip.SelectedIndex = tixian.mid;
                    txt_M_psw.Text = tixian.tx_money.ToString();
                    RadioButton1.Checked = true;
                }



            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int isactive = 0;
            string _jine = txt_M_psw.Text;
            int _mid = Convert.ToInt32(drop_M_vip.SelectedValue);

            B2C_mem bm = new B2C_mem(_mid);
            DataTable dt =
                DbHelperSQL.Query(
                    "select top 1 ac_amt from b2c_account where ptid=2 and b2c_account.mid="+_mid+" order by id desc").Tables[0];
            string _yue = "0";
            if (dt.Rows.Count>0)
            {
                _yue = dt.Rows[0][0].ToString();
            }


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

            if (Request["id"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Request["id"]);
                    //DataTable dt = comfun.GetDataTableBySQL("select id,b2c_level from B2C_config where id=" + id + " or b2c_level=" + Convert.ToInt32(txt_b2c_level.Text) + "");
                    //if (dt.Rows.Count > 1)
                    //{
                    //    Response.Write("<script language='javascript'>alert('存在相同的等级！');history.go(-1);</script>");
                    //}
                    //else
                    //{
                    B2C_tixian tixian = new B2C_tixian(id);
                    tixian.mid = _mid;
                    tixian.tx_money = Convert.ToDecimal(Convert.ToDouble(_jine) * (1 - apps._tixianZhekou));
                    tixian.isActive = isactive;
                    tixian.Update();
                    Response.Write("<script language='javascript'>alert('修改成功！');location.href='B2C_tixian_List.aspx';</script>");
                    Response.End();
                    //  }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else //新加
            {
                try
                {
                    //DataTable dt = comfun.GetDataTableBySQL("select b2c_level from B2C_config where b2c_level='" + txt_b2c_level.Text + "'");
                    //if (dt.Rows.Count <= 0)
                    //{
                    double _tixianMoney1 = Convert.ToDouble(_jine) * (1 - apps._tixianZhekou);
                    double _tixianMoney2 = Convert.ToDouble(_jine) * apps._tixianZhekou;

                    B2C_tixian tixian = new B2C_tixian();
                    tixian.AddNew();
                    tixian.mid = _mid;
                    tixian.tx_money = Convert.ToDecimal(_tixianMoney1);
                    tixian.isActive = isactive;
                    tixian.Update();

                    int yn = -1;

                    //扣款
                    B2C_Account ba = new B2C_Account();
                    ba.AddNew();
                    ba.ac_money = _tixianMoney1 * yn;
                    ba.mid = _mid;
                    ba.ptid = 2;
                    ba.cno = "005";
                    ba.ac_des = "提现";
                    ba.Update();

                    ba.AddNew();
                    ba.mid = _mid;
                    ba.ptid = 2;
                    ba.cno = "010"; //要看看提现手续费的科目编号 
                    ba.ac_money = _tixianMoney2 * yn;
                    ba.ac_des = "提现手续费";
                    ba.Update();


                    Response.Write("<script language='javascript'>alert('添加成功！');location.href='B2C_tixian_List.aspx';</script>");
                    Response.End();
                    //}
                    //else
                    //{
                    //    Response.Write("<script language='javascript'>alert('已存在该等级！');history.go(-1);</script>");
                    //}
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}