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
    public partial class ms_Orders_Detail : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = comfun.GetDataTableBySQL("select * from B2C_order_active");
                selFlag.DataSource = dt;
                selFlag.DataTextField = "a_name";
                selFlag.DataValueField = "id";
                selFlag.DataBind();

                DataTable dt2 = comfun.GetDataTableBySQL("select * from b2c_sendtype");
                selFlag2.DataSource = dt2;
                selFlag2.DataTextField = "st_name";
                selFlag2.DataValueField = "id";
                selFlag2.DataBind();

                string _ono = "";
                if (Request["ono"] != null)
                {
                    Session["ono"] = Request["ono"].ToString();
                    _ono = Request["ono"].ToString();
                }
                if (Session["ono"] != null)
                {
                    ms_orders bo = new ms_orders(_ono);

                    billId.Value = bo.id.ToString();//订单ID
                    lblBillNo.Text = bo.o_no.ToString();//订单号
                    lblTradeDate.Text = bo.o_date.ToString();//下单时间
                    lblTradeMan.Text = bo.mname.ToString();//下单人
                    selFlag2.Value = bo.o_stid.ToString();//配送方式 
                    lblSendCost.Text = bo.o_st_amt.ToString();//配送价格
                    lblRemarks.Text = bo.o_Des.ToString();//备注
                    lblCost.Text = bo.o_amt.ToString(); //金额
                    lblAllCost.Text = bo.o_allamt.ToString() + "(积分:" + bo.o_cent + ")"; //总金额

                    selFlag.Value = bo.aid.ToString();

                    DataTable dat = ms_orders.GetAddr(_ono);
                    if (dat.Rows.Count > 0)
                    {
                        lblConsignee.Text = dat.Rows[0]["a_name"].ToString();//收货人
                        lblAddress.Text = dat.Rows[0]["a_addr"].ToString() + dat.Rows[0]["a_addr2"].ToString();//地址
                        lblZipcode.Text = dat.Rows[0]["a_zip"].ToString();//邮编
                        lblTelephone.Text = dat.Rows[0]["a_tel"].ToString();//电话
                        lblCellphone.Text = dat.Rows[0]["a_mobile"].ToString();//手机
                        lblEmail.Text = dat.Rows[0]["a_senddate"].ToString();//Email 
                        lblRemarks.Text = lblRemarks.Text + dat.Rows[0]["a_des"].ToString();//Email 
                    }

                }
                ltrOrderDList.Text = GetOrderDetailList();
                ltrOrderLogList.Text = GetOrderLogList();
            }
        }
        /// <summary>
        /// 获取订单明细列表
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        private string GetOrderDetailList()
        {
            string _ono = "";
            string resultStr = "";
            if (Session["ono"] != null)
            {
                _ono = Session["ono"].ToString().Trim();
            }
            DataTable dat = ms_orders.GetDetailList(_ono);

            #region 获取订单明细信息

            resultStr += @"<table width=100% border=0 align=center cellpadding=0 cellspacing=0  class='borderTable'>";
            resultStr += @"       <tr>";
            resultStr += @"        <td height=25 align=center class=rb>选择</td>";
            resultStr += @"        <td align=center>品名</td>";
            resultStr += @"        <td align=center>数量</td>";
            resultStr += @"        <td align=center>价格</td>";
            resultStr += @"        <td align=center>金额</td>";
            resultStr += @"        <td align=center>积分</td>";
            resultStr += @"        <td align=center>总积分</td>";
            resultStr += @"        <td align=center>操作</td>";
            resultStr += @"       </tr>";
            foreach (DataRow dr in dat.Rows)
            {
                resultStr += @"        <tr>";
                resultStr += @"          <td align=center height=24><input type=checkbox name=""delbox"" value='" + dr["id"] + "' /></td>";
                resultStr += @"          <td align=center>" + dr["gname"] + "</td>";
                resultStr += @"          <td align=center>" + dr["od_num"] + "</td>";
                resultStr += @"          <td align=center>" + dr["od_price"] + "</td>";
                resultStr += @"          <td align=center>" + dr["od_amt"] + "</td>";
                resultStr += @"          <td align=center>" + dr["od_cent"] + "</td>";
                resultStr += @"          <td align=center>" + dr["od_allcent"] + "</td>";
                resultStr += @"          <td align=center><a href='ms_orderD_Mod.aspx?id=" + dr["id"] + "'>修改</a></td>";
                resultStr += @"        </tr>";
            }
            resultStr += @"</table>";

            #endregion

            return resultStr;
        }
        /// <summary>
        /// 获取订单处理记录列表
        /// </summary>
        /// <param name="_sqlStr"></param>
        /// <returns></returns>
        private string GetOrderLogList()
        {
            string _ono = "";
            string resultStr = "";
            if (Session["ono"] != null)
            {
                _ono = Session["ono"].ToString().Trim();
            }
            DataTable dat = ms_orders.GetLogsList(_ono);

            #region 获取订单处理记录信息
            resultStr += @"<table width=100% border=0 align=center cellpadding=0 cellspacing=0  class='borderTable'>";
            resultStr += @"       <tr>";
            resultStr += @"        <td height=30 align=""center"">订单状态</td>";
            resultStr += @"        <td align=""center"">操作人</td>";
            resultStr += @"        <td align=""center"">时间</td>";
            resultStr += @"        <td align=""center"">备注</td>";
            resultStr += @"       </tr>";
            foreach (DataRow dr in dat.Rows)
            {
                resultStr += @"        <tr>";
                resultStr += @"          <td align=""center"">" + dr["aname"] + "</td>";
                resultStr += @"          <td height=24 align=""center"">" + dr["ol_name"] + "</td>";
                resultStr += @"          <td align=""center"">" + dr["ol_date"] + "</td>";
                resultStr += @"          <td align=""center"">" + dr["ol_des"] + "</td>";
                resultStr += @"        </tr>";
            }
            resultStr += @"</table>";

            #endregion

            return resultStr;
        }

        #region 功能按钮

        /// <summary>
        /// 删除选中的记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            string delid = "0";
            string _ono = Session["ono"].ToString().Trim();
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                try
                {
                    ms_orders.deleteDetail(delid);
                    Response.Write("<script language='javascript'>alert('删除成功！');location.href='ms_orders_Detail.aspx?ono=" + Session["ono"].ToString().Trim() + "';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script language='javascript'>alert('删除失败！');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要删除的行！');history.go(-1);</script>");
            }
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFlag_ServerClick(object sender, EventArgs e)
        {
            if (Session["ono"] != null)
            {
                string _aid = selFlag.Value;
                string _ono = Session["ono"].ToString().Trim();
                string _sql = "";
                _sql += ms_orders.insertLogsSQL(_ono, "管理员", "", Convert.ToInt32(_aid));
                _sql += "update ms_orders set aid=" + _aid + " where o_no='" + _ono + "'";

                try
                {
                    comfun.UpdateBySQL(_sql);
                    Response.Write("<script language='javascript'>alert('更新订单状态成功！');location.href='ms_orders_Detail.aspx?ono=" + _ono + "';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script language='javascript'>alert('更新订单状态失败！');history.go(-1);</script>");
                }

            }
        }

        /// <summary>
        /// 更新配送方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFlag2_ServerClick(object sender, EventArgs e)
        {
            if (Session["ono"] != null)
            {
                string _stid = selFlag2.Value;
                string _ono = Session["ono"].ToString().Trim();
                string _stAmt = "0.0";

                DataTable dt = comfun.GetDataTableBySQL("select st_price from b2c_sendtype where id=" + _stid);
                if (dt.Rows.Count > 0)
                {
                    _stAmt = dt.Rows[0]["st_price"].ToString().Trim();
                }
                string _sql = "";
                _sql += "update ms_orders set o_stid=" + _stid + ",o_st_amt=" + _stAmt + ",o_allamt=o_amt+" + _stAmt + " where o_no='" + _ono + "'";

                try
                {
                    comfun.UpdateBySQL(_sql);
                    Response.Write("<script language='javascript'>alert('更新配送方式成功！');location.href='ms_orders_Detail.aspx?ono=" + _ono + "';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script language='javascript'>alert('更新配送方式失败！');history.go(-1);</script>");
                }

            }
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModBill_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ms_orders_Mod.aspx?ono=" + Session["ono"].ToString().Trim());
        }

        #endregion
    }
}