 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;

namespace tdx.memb.man.Tuan.Tixian
{
    public partial class B2C_tixian_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
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

            //B2C_mem bm = new B2C_mem(_mid);
            string _yue = "0";// bm._cent.ToString(); 

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

           

            if (Request["id"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Request["id"]);
                   
                    B2C_tixian tixian = new B2C_tixian(id);
                    tixian.mid = _mid;
                    tixian.tx_money = Convert.ToDecimal(Convert.ToDouble(_jine));
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
                    
                   double _tixianMoney1 = Convert.ToDouble(_jine)  ; 

                    B2C_tixian tixian = new B2C_tixian();  
                    tixian.AddNew();
                    tixian.mid = _mid;
                    tixian.tx_money = Convert.ToDecimal(_tixianMoney1);
                    tixian.isActive = isactive;
                    tixian.Update(); 


                    Response.Write("<script language='javascript'>alert('添加成功！');location.href='B2C_tixian_List.aspx';</script>");
                    Response.End();
                     
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
