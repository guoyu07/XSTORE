using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Goods
{
    public partial class B2C_Orders_Mod : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["ono"] != null)
                {
                    string _ono = Request["ono"].ToString();
                    B2C_orders order = new B2C_orders(_ono);

                    lblBillNo.Text = order.o_no;//订单号
                    lblmem.Text = order.mname;//订货人
                    txtYF.Value = order.o_st_amt.ToString();//运费 
                    txtAmtOld.Value = order.o_amt.ToString();//订单金额
                    txtAmt.Value = order.o_allamt.ToString();//总金额
                    txtCent.Value = order.o_cent.ToString();//总积分
                    txtRemarks.Value = order.o_Des.ToString();//备注 

                    DataTable dat = B2C_orders.GetAddr(_ono);
                    if (dat.Rows.Count > 0)
                    {
                        DataRow dr = dat.Rows[0];
                        txtConsignee.Value = dr["a_name"].ToString().Trim();//收货人
                        txtDetailAddr.Value = dr["a_addr2"].ToString().Trim();//地址
                        txtZipcode.Value = dr["a_zip"].ToString().Trim();//邮编
                        txtTelephone.Value = dr["a_tel"].ToString().Trim();//电话
                        txtMobile.Value = dr["a_mobile"].ToString().Trim();//手机 
                        txtSendDate.Value = dr["a_SendDate"].ToString().Trim();//配送时间
                    }

                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            #region 赋值
            string _o_linker = txtConsignee.Value;//收货人
            string _o_addr = txtDetailAddr.Value;//地址
            string _o_zip = txtZipcode.Value;//邮编
            string _o_tel = txtTelephone.Value;//电话
            string _o_mobile = txtMobile.Value;//手机 
            decimal _o_yf = txtYF.Value == "" ? 0 : Convert.ToDecimal(txtYF.Value);//运费
            decimal _o_amt = txtAmtOld.Value == "" ? 0 : Convert.ToDecimal(txtAmtOld.Value);//订单金额
            decimal _o_allamt = txtAmt.Value == "" ? 0 : Convert.ToDecimal(txtAmt.Value);//总金额 
            decimal _o_cent = txtCent.Value == "" ? 0 : Convert.ToDecimal(txtCent.Value);//总积分 

            string _o_SendDate = txtSendDate.Value;//送货时间
            string _od_des = comFunction.NoSt(txtRemarks.Value);//备注

            #endregion

            #region 执行修改

            if (Request["ono"] != null) //修改
            {
                try
                {
                    string _ono = Request["ono"].ToString().Trim();

                    string _sql = "update b2c_orders set o_amt=" + _o_amt + ",o_st_amt=" + _o_yf + ",o_allamt=" + _o_allamt + ",o_cent=" + _o_cent + ",o_des='" + _od_des.Replace("'", "") + "' where o_no='" + _ono + "'";
                    _sql += ";\r\n " + B2C_orders.insertAddrSQL(_ono, _o_linker, "", _o_addr, _o_zip, _o_tel, _o_mobile, _o_SendDate, _od_des);


                    comfun.UpdateBySQL(_sql);
                    Response.Write("<script language='javascript'>alert('修改成功！');location.href='B2C_Orders_Detail.aspx?ono=" + _ono + "';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script language='javascript'>alert('修改失败！');history.go(-1);</script>");
                }
            }

            #endregion
        }
    }
}