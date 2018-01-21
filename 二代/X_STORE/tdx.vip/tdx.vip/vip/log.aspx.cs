using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.vip
{
    public partial class log : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string _wwv = "";
                    int flag = 0;
                    li_jine.Attributes.Remove("class");
                    li_jifen.Attributes.Remove("class");

                    
                    if (Request["devide"] != null)//用来判断点击了金额还是积分，进行不同的跳转
                    {
                        if (Request["devide"].ToString() == "1")//点击了积分
                        {
                            flag = 1;
                            li_jifen.Attributes.Add("class", "select");
                        }
                        else if (Request["devide"].ToString() == "2")//点击了金额
                        {
                            flag = 2;
                            li_jine.Attributes.Add("class", "select");
                        }
                    }
                    else
                    {
                        li_jine.Attributes.Add("class", "select");
                    }
                    if (Request["WWV"] != null)
                    {
                        _wwv = Request["WWV"].ToString();                        
                        string _sql = "select * from B2C_mem where M_card='" + _wwv + "' and cityID=" + Session["wID"].ToString();
                        DataTable _dt = comfun.GetDataTableBySQL(_sql);
                        if (_dt != null && _dt.Rows.Count > 0)
                        {
                            int _uid = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                            string _count = "select * from C2C_Account where uid=" + _uid + " and wid=" + Session["wID"].ToString() + " and ptid=2 order by id desc;";
                            _count += "select * from C2C_Account where uid=" + _uid + " and wid=" + Session["wID"].ToString() + " and ptid=1 order by id desc;";
                            DataSet ds = comfun.GetDataSetBySQL(_count);
                            DataTable dt1 = ds.Tables[0];
                            DataTable dt2 = ds.Tables[1];
                            if (dt1.Rows.Count > 0)
                            {
                                lt_jine.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2" + "'>金额:" + Convert.ToDouble(dt1.Rows[0]["ac_Amt"].ToString()).ToString("F2") + "</a>";
                            }
                            else
                            {
                                lt_jine.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2" + "'>金额:0.00</a>";
                            }
                            if (dt2.Rows.Count > 0)
                            {
                                lt_jifen.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1" + "'>积分:" + Convert.ToDouble(dt2.Rows[0]["ac_Amt"].ToString()).ToString("F2") + "</a>";
                            }
                            else
                            {
                                lt_jifen.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1" + "'>积分:0:00</a>";
                            }
                            GetLogInfo(_uid, flag);
                        }
                        else
                        {
                            lt_jine.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2" + "'>金额:0.00</a>";
                            lt_jifen.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1" + "'>积分:0:00</a>";
                        }

                    }
                    else if (Session["WWV"] != null)
                    {
                        _wwv = Session["WWV"].ToString();                       
                        string _sql = "select * from B2C_mem where M_card='" + _wwv + "' and cityID=" + Session["wID"].ToString();
                        DataTable _dt = comfun.GetDataTableBySQL(_sql);
                        if (_dt != null && _dt.Rows.Count > 0)
                        {
                            int _uid = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                            string _count = "select * from C2C_Account where uid=" + _uid + " and wid=" + Session["wID"].ToString() + " and ptid=2 order by id desc;";
                            _count += "select * from C2C_Account where uid=" + _uid + " and wid=" + Session["wID"].ToString() + " and ptid=1 order by id desc;";
                            DataSet ds = comfun.GetDataSetBySQL(_count);
                            DataTable dt1 = ds.Tables[0];
                            DataTable dt2 = ds.Tables[1];
                            if (dt1.Rows.Count > 0)
                            {
                                lt_jine.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2" + "'>金额:" + Convert.ToDouble(dt1.Rows[0]["ac_Amt"].ToString()).ToString("F2") + "</a>";
                            }
                            else
                            {
                                lt_jine.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2" + "'>金额:0.00</a>";
                            }
                            if (dt2.Rows.Count > 0)
                            {
                                lt_jifen.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1" + "'>积分:" + Convert.ToDouble(dt2.Rows[0]["ac_Amt"].ToString()).ToString("F2") + "</a>";
                            }
                            else
                            {
                                lt_jifen.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1" + "'>积分:0:00</a>";
                            }
                            GetLogInfo(_uid, flag);
                        }
                        else
                        {
                            lt_jine.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=2" + "'>金额:0.00</a>";
                            lt_jifen.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&WWV=" + _wwv + "&devide=1" + "'>积分:0:00</a>";
                        }
                    }
                    else
                    {
                        lt_jine.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&devide=2" + "'>金额:0.00</a>";
                        lt_jifen.Text = "<a href='log.aspx?WWX=" + Request["WWX"].ToString() + "&devide=1" + "'>积分:0.00</a>";
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "vip/log.cs",Session["wID"].ToString());
                }

            }
        }
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="_mem_id"></param>
        /// <param name="_falg"></param>
        private void GetLogInfo(int _mem_id, int _falg)
        {
            if (_falg == 1)//积分
            {
                GetJiFenLog(_mem_id);
            }
            else//否则全当做金额来处理
            {
                GetJinELog(_mem_id);
            }
        }
        /// <summary>
        /// 获取金额日志
        /// </summary>
        /// <param name="_mem_id"></param>
        private void GetJinELog(int _mem_id)
        {
            lt_log.Text = "";
            string result = "";
            string _sql = "select * from C2C_Account where uid="+_mem_id+" and wid="+Session["wID"].ToString()+" and ptid=2";
            DataTable dt=comfun.GetDataTableBySQL(_sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["cno"].ToString() == "赠送")//返现
                {
                    result += "\r\n<div class=\"lCashback\">";
                    result += "\r\n<span>" + Convert.ToDateTime(dr["ac_update"].ToString()).ToString("yyyy-MM-dd") + "</span><a>返现</a><i>￥"+Convert.ToDouble(dr["ac_money"].ToString()).ToString("F2")+"</i>";
                    result += "\r\n</div>";
                }
                else if (Convert.ToDouble(dr["ac_money"].ToString()) > 0)//充值
                {
                    result += "\r\n<div class=\"lRecharge\">";
                    result += "\r\n<span>" + Convert.ToDateTime(dr["ac_update"].ToString()).ToString("yyyy-MM-dd") + "</span><a>充值</a><i>￥" + Convert.ToDouble(dr["ac_money"].ToString()).ToString("F2") + "</i>";
                    result += "\r\n</div>";
                }
                else
                {
                    result += "\r\n<div class=\"lConsumption\">";
                    result += "\r\n<span>" + Convert.ToDateTime(dr["ac_update"].ToString()).ToString("yyyy-MM-dd") + "</span><a>消费</a><i>￥" + Convert.ToDouble(dr["ac_money"].ToString()).ToString("F2") + "</i>";
                    result += "\r\n</div>";
                }
                
            }
            lt_log.Text =result;
        }

        /// <summary>
        ///  获取积分日志 
        /// </summary>
        /// <param name="_mem_id"></param>
        private void GetJiFenLog(int _mem_id)
        {
            lt_log.Text = "";
            string result = "";
            string _sql = "select * from C2C_Account where uid=" + _mem_id + " and wid=" + Session["wID"].ToString() + " and ptid=1";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["cno"].ToString() == "赠送")//返现
                {
                    result += "\r\n<div class=\"lCashback\">";
                    result += "\r\n<span>" + Convert.ToDateTime(dr["ac_update"].ToString()).ToString("yyyy-MM-dd") + "</span><a>赠送积分</a><i>￥" + Convert.ToDouble(dr["ac_money"].ToString()).ToString("F2") + "</i>";
                    result += "\r\n</div>";
                }
                else if (Convert.ToDouble(dr["ac_money"].ToString()) > 0)//充值
                {
                    result += "\r\n<div class=\"lRecharge\">";
                    result += "\r\n<span>" + Convert.ToDateTime(dr["ac_update"].ToString()).ToString("yyyy-MM-dd") + "</span><a>充值积分</a><i>￥" + Convert.ToDouble(dr["ac_money"].ToString()).ToString("F2") + "</i>";
                    result += "\r\n</div>";
                }
                else
                {
                    result += "\r\n<div class=\"lConsumption\">";
                    result += "\r\n<span>" + Convert.ToDateTime(dr["ac_update"].ToString()).ToString("yyyy-MM-dd") + "</span><a>减少积分</a><i>￥" + Convert.ToDouble(dr["ac_money"].ToString()).ToString("F2") + "</i>";
                    result += "\r\n</div>";
                }

            }
            lt_log.Text = result;
        }
    }
}