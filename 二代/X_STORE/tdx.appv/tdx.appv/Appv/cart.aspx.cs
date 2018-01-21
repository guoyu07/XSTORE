using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using tdx.database;
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.appv
{
    public partial class cart : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');
                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = _tdxWeixinArry[1];
                lt_description.Text = _tdxWeixinArry[1];
                lt_theme.Text = _tdxWeixinArry[2]; 
                
                string _cno = Request["cno"] != null ? Request["cno"].ToString().Trim() : "";
                string _page = Request["page"] != null ? Request["page"].ToString().Trim() : "1"; 
                string _wwx = Request["wwx"] != null ? Request["wwx"].ToString().Trim() : ""; 

                #region "购物车内容"
                if (Session[orderAuth.getOrderCookieKey()] != null)
                {
                    DataTable dt = (DataTable)Session[orderAuth.getOrderCookieKey()];
                    string result = "";
                    decimal _totalje = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        result += "<div class=\"OrderItem\" id=\"OrderItem_" + dr["guid"].ToString() + "\"> \r\n";
                        result += "     \r\n<div class=\"img\"><img src='" + (string.IsNullOrEmpty(dr["g_gif"].ToString()) ? "images/nopic.png" : dr["g_gif"].ToString().Replace("all", "min")) + "' border='0' /></div>";
                       
                        result += "     \r\n <div class=\"txt\">";
                        result += "     \r\n    <h3>" + dr["g_name"].ToString().Trim() + "</h3>";  
                        result += "             <p class=\"orderItem_num\">      <input type=\"range\"  min=\"1\" max=\"15\" value=\"" + dr["g_num"].ToString().Trim() + "\" id=\"proItemCart_orderNum_" + dr["guid"].ToString().Trim() + "\" data-highlight=\"true\" data-popup-enabled=\"true\" onchange=\"setOrderNum('" + dr["guid"].ToString().Trim() + "'," + dr["g_price"].ToString().Trim() + ");\"/></p>";
                        result += "     \r\n    <p class=\"clear1\"></p>";  
                        result += "     \r\n    <p class=\"orderItem_btn\"><span class=\"price\" id=\"xj_" + dr["guid"].ToString().Trim() + "\">￥" + GetMoney(dr["g_amt"].ToString().Trim()) + "</span> </p>";
                        result += "     \r\n    <p class=\"ButtonDiv\"><a onClick=\"ModToCart('" + dr["guid"].ToString().Trim() + "');" + "\"><img src=\"/Appv/images/" + _tdxWeixinArry[2] + "/btnMod.png\" id=\"btn_cart_Mod_" + dr["guid"].ToString() + "\" border=\"0\"/></a></p> ";
                        result += "     \r\n    <p class=\"ButtonDiv\"><a onClick=\"DelToCart('" + dr["guid"].ToString().Trim() + "');" + "\"><img src=\"/Appv/images/" + _tdxWeixinArry[2] + "/btnDel.png\" id=\"btn_cart_Del_" + dr["guid"].ToString() + "\" border=\"0\"/></a></p> ";
                        result += "     \r\n </div>";
                        result += "</div> \r\n";

                        _totalje += Convert.ToDecimal(dr["g_amt"].ToString().Trim());
                    }
                    result += "<div class=\"OrderItem\"> \r\n";
                    result += "     \r\n<div class=\"img\"></div>"; 
                    result += "     \r\n <div class=\"txt\">";
                    result += "     \r\n    <p class=\"orderItem_btn\">总计:</span> </p>";
                    result += "     \r\n    <p class=\"orderItem_btn\"> <span class=\"price\" id=\"zj_cart\">￥" + GetMoney(_totalje.ToString()) + "</span> </p>";  
                    result += "     \r\n </div>";
                    result += "</div> \r\n";
                    dt.Dispose();
                    dt = null;

                    lt_goodlist.Text = result;
                }
                else
                {
                    lt_goodlist.Text = "您还未选购任何商品";
                }
                #endregion

                #region "收货人信息"
                if (Session[memAuth.getMemCookieKey()] != null)
                {
                    int _mid = Convert.ToInt32(Session[memAuth.getMemCookieKey() + "_ID"].ToString().Trim());
                    DataTable dt = B2C_orders.GetAddr(_mid);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        txtSHR.Value = dr["a_name"].ToString().Trim();
                        txtDZ.Value = dr["a_addr2"].ToString().Trim();
                        txtTel.Value = dr["a_mobile"].ToString().Trim();
                        string adate = dr["a_senddate"].ToString().Trim();  
                        txtDes.Value = dr["a_des"].ToString().Trim();
                    }
                    dt.Dispose();
                    dt = null;
                }
                #endregion
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string _cno = Request["cno"] != null ? Request["cno"].ToString().Trim() : "";
            string _page = Request["page"] != null ? Request["page"].ToString().Trim() : "1";
            string _ID = Request["id"] != null ? Request["id"].ToString().Trim() : "0";

            string _name = txtSHR.Value.ToString().Trim();
            string _addr = txtDZ.Value.ToString().Trim();
            string _zip = "";
            string _tel = txtTel.Value.ToString().Trim();
            string _mobile = "";
            string _sendDate = "正常";// Request["txtTime"].ToString().Trim();
            string _des = txtDes.Value.ToString().Trim();
            string _stid = "6";

            if (string.IsNullOrEmpty(_name))
            {
                lt_msg.Text = "请输入收货人信息";
                return;
            }
            if (string.IsNullOrEmpty(_addr))
            {
                lt_msg.Text = "请输入收货地址";
                return;
            }
            if (string.IsNullOrEmpty(_tel))
            {
                lt_msg.Text = "请输入电话";
                return;
            }

            if (Session[orderAuth.getOrderCookieKey()] != null)
            {
                DataTable dt = (DataTable)Session[orderAuth.getOrderCookieKey()]; 
                try
                {
                    string _ono = comEncrypt.GetDateRndNumber();
                    int _mid = 0;
                    if (Session["mID"] != null)
                    {
                        _mid = Convert.ToInt32(Session["mID"].ToString());
                    }
                    int _wID = 0;
                    if (Session["wID"] != null)
                    {
                        _wID = Convert.ToInt32(Session["wID"].ToString());
                    }

                    string _gid = "";
                    string _oDes = "";
                    decimal _oamt = 0;
                    decimal _allcent = 0;

                    string _sql = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        _sql += ";\r\n" + B2C_orders.insertDetailSQL(_ono, Convert.ToInt32(dr["guid"]), Convert.ToDecimal(dr["g_price"]), Convert.ToDecimal(dr["g_num"]), Convert.ToDecimal(dr["g_amt"]), Convert.ToDecimal(dr["g_cent"]), Convert.ToDecimal(dr["g_allcent"]), dr["g_des"].ToString());
                        _gid += dr["guid"].ToString() + ",";
                        _oamt += Convert.ToDecimal(dr["g_amt"]);
                        _allcent += Convert.ToDecimal(dr["g_allcent"]);
                    }


                    _sql += ";\r\n" + B2C_orders.insertSQL(_mid, Convert.ToInt32(Session["wid"].ToString()), _gid, _oDes, 0, 0, _oamt, _oamt, _allcent, _ono);
                     
                    _sql += ";\r\n " + B2C_orders.insertAddrSQL(_ono, _name, "", _addr, _zip, _tel, _mobile, _sendDate, _des);

                    comfun.UpdateBySQL(_sql);
                    Session[orderAuth.getOrderCookieKey()] = null;  
                    lt_msg.Text = "感谢您的订购,请牢记您的订单号码：" + _ono + ".";
                    return;   
                }
                catch (Exception ex)
                { 
                    lt_msg.Text = "订单保存失败：" + ex.Message + ".";
                    return; 
                } 
            }
            lt_msg.Text = "购物车为空";
            return;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string _cno = Request["cno"] != null ? Request["cno"].ToString().Trim() : "";
            string _page = Request["page"] != null ? Request["page"].ToString().Trim() : "1";
            string _wwx = Request["wwx"] != null ? Request["wwx"].ToString().Trim() : "";
            Response.Redirect("prolist.aspx?wwx=" + _wwx + "&cno=" + _cno + "&page=" + _page );
            return;
        }

        private string GetMoney(string _money)
        {
            return string.Format("{0:F}", Convert.ToDouble(_money));
        }
    }
}
