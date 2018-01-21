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
    public partial class ms_OrderD_Mod : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    int _id = Convert.ToInt32(Request["id"]);

                    string _sql = "select *,(select ms_title from B2C_ms where id=ms_order_d.gid) as gname from ms_order_d where id=" + _id.ToString();
                    DataTable dt = comfun.GetDataTableBySQL(_sql);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        lblGoodsName.Text = dr["gname"].ToString();
                        txtPrice.Value = dr["od_price"].ToString();
                        txtQnt.Value = dr["od_num"].ToString();
                        txtAmt.Value = dr["od_amt"].ToString();
                        txtRemarks.Value = dr["od_des"].ToString();
                    }
                    dt.Dispose();
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
            decimal _od_price = txtPrice.Value == "" ? 0 : Convert.ToDecimal(txtPrice.Value);
            decimal _od_qnt = txtQnt.Value == "" ? 0 : Convert.ToDecimal(txtQnt.Value);
            decimal _od_amt = txtAmt.Value == "" ? 0 : Convert.ToDecimal(txtAmt.Value);
            string _od_des = comFunction.NoSt(txtRemarks.Value);

            if (Request["id"] != null)
            {
                try
                {
                    int _id = Convert.ToInt32(Request["id"]);
                    string _ono = "";
                    DataTable dt = comfun.GetDataTableBySQL("select ono from ms_order_d where id=" + _id.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        _ono = dt.Rows[0]["ono"].ToString().Trim();
                    }
                    dt.Dispose();

                    dt = comfun.GetDataTableBySQL("select sum(od_amt) as amt from ms_order_d where ono='" + _ono + "'");
                    string _odAmt = dt.Rows[0]["amt"].ToString().Trim();
                    //修改订单明细//修改订单金额
                    string _sql = "update ms_order_d set od_price=" + _od_price.ToString() + ",od_num=" + _od_qnt.ToString() + ",od_amt=" + _od_amt.ToString() + ",od_des='" + _od_des.Replace("'", "") + "' where id=" + _id.ToString();
                    _sql += ";\r\n" + "update ms_orders set o_amt=" + _odAmt + ",o_allamt=o_st_amt+" + _odAmt + " where o_no='" + _ono + "'";

                    comfun.UpdateBySQL(_sql);
                    Response.Write("<script language='javascript'>alert('修改成功！');location.href='ms_orders_Detail.aspx?ono=" + _ono + "';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script language='javascript'>alert('修改失败！');history.go(-1);</script>");
                }
            }
        }
    }
}