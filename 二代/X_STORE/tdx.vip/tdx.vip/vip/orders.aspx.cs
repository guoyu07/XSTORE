using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using System.Data;
using tdx.Weixin;

namespace tdx.vip
{
    public partial class orders : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _wwv = "";
                int flag = 0;//标识订单的状态：正在进行或已结束
                li_now.Attributes.Remove("class");
                li_end.Attributes.Remove("class");

                if (Request["devide"] != null)
                {
                    if (Request["devide"].ToString() == "1")//正在
                    {
                        flag = 1;
                        li_now.Attributes.Add("class", "select");
                    }
                    else if (Request["devide"].ToString() == "2")//已结束
                    {
                        flag = 2;
                        li_end.Attributes.Add("class", "select");
                    }
                }
                else
                {
                    li_now.Attributes.Add("class", "select");
                }
                if (Request["WWV"] != null)
                {
                    _wwv = Request["WWV"].ToString();                    
                    string _sql = "select * from B2C_mem where M_card='" + _wwv + "' and cityID=" + Session["wID"].ToString();
                    DataTable _dt = comfun.GetDataTableBySQL(_sql);
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        int _uid = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                        string _count = "select * from B2C_orders where mid=" + _uid + " and wid=" + Session["wID"].ToString() + " and aid<5;";
                        _count += "select * from B2C_orders where mid=" + _uid + " and wid=" + Session["wID"].ToString() + " and aid>=5;";
                        DataSet ds = comfun.GetDataSetBySQL(_count);
                        DataTable dt1 = ds.Tables[0];
                        DataTable dt2 = ds.Tables[1];
                        lt_now.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1'>正在:" + dt1.Rows.Count + "</a>";
                        lt_end.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2'>已结束:" + dt2.Rows.Count + "</a>";
                        GetOrderList(_uid, flag);
                    }
                    else
                    {
                        lt_now.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1'>正在:0</a>";
                        lt_end.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2'>已结束:0</a>";
                    }
                }
                else if (Session["WWV"] != null)
                {
                    _wwv = Request["WWV"].ToString();                   
                    string _sql = "select * from B2C_mem where M_card='" + _wwv + "' and cityID=" + Session["wID"].ToString();
                    DataTable _dt = comfun.GetDataTableBySQL(_sql);
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        int _uid = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                        string _count = "select * from B2C_orders where mid=" + _uid + " and wid=" + Session["wID"].ToString() + " and aid<5;";
                        _count += "select * from B2C_orders where mid=" + _uid + " and wid=" + Session["wID"].ToString() + " and aid>=5;";
                        DataSet ds = comfun.GetDataSetBySQL(_count);
                        DataTable dt1 = ds.Tables[0];
                        DataTable dt2 = ds.Tables[1];
                        lt_now.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1'>正在:" + dt1.Rows.Count + "</a>";
                        lt_end.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2'>已结束:" + dt2.Rows.Count + "</a>";
                        GetOrderList(_uid, flag);
                    }
                    else
                    {
                        lt_now.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1'>正在:0</a>";
                        lt_end.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2'>已结束:0</a>";
                    }
                }
                else
                {
                    lt_now.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1'>正在:0</a>";
                    lt_end.Text = "<a href='orders.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2'>已结束:0</a>";
                }

            }
        }
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="mem_id"></param>
        private void GetOrderList(int mem_id,int _flag)
        {

            string _sql =_flag==2? "select * from B2C_orders where mid="+mem_id+" and wid="+Session["wID"].ToString()+" and aid>=5":"select * from B2C_orders where mid="+mem_id+" and wid="+Session["wID"].ToString()+" and aid<5";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            string result = "";
            foreach (DataRow dr in dt.Rows)
            {
                result += "\r\n <div class=\"oOrderItemTitle\">";
                result += "\r\n<span>" + Convert.ToDateTime(dr["o_date"].ToString()).ToString("yyyy-MM-dd") + "</span><i>￥"+Convert.ToDouble(dr["o_allamt"].ToString()).ToString("F2")+"</i>";
                result += "\r\n</div>";

                string _ono = dr["o_no"].ToString();
                string[] _gid = dr["gid"].ToString().Split(',');
                #region 下拉内容                
                result +="\r\n<div class=\"oOrderItemConetnt\">";
                //订单日志
                result += "\r\n<div class=\"oLog\">";
               
                result += "\r\n" + GetOrderLog(_ono);
                result += "\r\n</div>";

                //商品
                result += "\r\n<div class=\"oGoods\">";
                result += "\r\n"+GetOrderGoods(_ono,_gid);
                result += "\r\n</div>";
                result += "\r\n</div>";
                #endregion
            }
            od_list.Text = result;
        }
        /// <summary>
        /// 获取订单日志
        /// </summary>
        /// <param name="_ono"></param>
        /// <returns></returns>
        private string GetOrderLog(string _ono)
        {
            string _result = "";
            string _sql = "select * from B2C_order_log where ono='"+_ono+"';";
            _sql+="select * from B2C_order_active where id in (select aid from B2C_order_log where ono='"+_ono+"');";
            DataSet ds=comfun.GetDataSetBySQL(_sql);
            DataTable dt = ds.Tables[0];
            DataTable dt_active=ds.Tables[1];
            Dictionary<int,string> _dic=new Dictionary<int,string>();
            foreach(DataRow dr in dt_active.Rows)
            {
                if(!_dic.Keys.Contains(Convert.ToInt32(dr["id"].ToString())))
                {
                    _dic.Add(Convert.ToInt32(dr["id"].ToString()),dr["a_name"].ToString());
                }
            }

            foreach (DataRow dr in dt.Rows)
            {
                _result += "<p>";
                _result += "\r\n<span>" + Convert.ToDateTime(dr["ol_date"].ToString()).ToString("yyyy-MM-dd") + "<i>" + Convert.ToDateTime(dr["ol_date"].ToString()).ToString("HH:mm:ss") + "</i></span><em>" + _dic[Convert.ToInt32(dr["aid"].ToString())]+ "</em>";
                _result += "</p>";
            }
            return _result;
        }

        /// <summary>
        /// 获取订单的商品
        /// </summary>
        /// <param name="_ono"></param>
        /// <returns></returns>
        private string GetOrderGoods(string _ono,string[] gid)
        {
            string _result = "";
            foreach (string _gid in gid)
            {
                if (_gid != "")
                {
                    string _sql = "select top 1 * from B2C_Goods where id=" + _gid + ";";
                    _sql += "select top 1 * from B2C_order_d where ono='" + _ono + "' and gid=" + _gid + ";";
                    DataSet ds = comfun.GetDataSetBySQL(_sql);
                    DataTable dt_g = ds.Tables[0];
                    DataTable dt_od = ds.Tables[1];
                    if (dt_g.Rows.Count > 0 && dt_od.Rows.Count > 0)
                    {
                        _result += "\r\n <p>";
                        _result += "\r\n<a>";
                        _result += "\r\n<img src=\"" + dt_g.Rows[0]["g_gif"].ToString() + "\" /></a><span>";
                        _result += dt_g.Rows[0]["g_name"].ToString() + "</span><em>";
                        _result += Convert.ToDouble(dt_od.Rows[0]["od_num"].ToString()).ToString("F2") + "*";
                        _result += Convert.ToDouble(dt_od.Rows[0]["od_price"].ToString()).ToString("F2") + "</em>";
                        _result += "\r\n</p>";
                    }
                }
            }
            return _result;
        }



    }
}