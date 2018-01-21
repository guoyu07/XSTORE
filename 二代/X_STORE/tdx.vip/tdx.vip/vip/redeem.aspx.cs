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
    public partial class redeem : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string wid = "";
                if (Session["wID"] != null && Session["wID"].ToString() != "")
                {
                    wid = Session["wID"].ToString();
                    iwwv.Value = Request["WWV"];
                    iwwx.Value = Request["WWX"];
                    iwid.Value = wid;
                    string _sql = "SELECT * FROM B2C_Goods WHERE   (g_isdel = 0) AND (g_buytype = 2) AND (cityid = "+wid+")";//查询积分产品（未入回收站）
                    try
                    {
                        DataTable td = comfun.GetDataTableBySQL(_sql);
                        if (Request["WWV"] != null && Request["WWV"] != "")
                        {
                            string _sqlwwv = "select id from B2C_mem where M_card='" + Request["WWV"].ToString() + "'";
                            DataTable dtwwv = comfun.GetDataTableBySQL(_sqlwwv);
                            string _wwv = "";
                            if (dtwwv != null && dtwwv.Rows.Count > 0)
                            {
                                _wwv = dtwwv.Rows[0][0].ToString();
                            }
                            string _sqlyh = "select gid from B2C_orders where wid=" + wid + " and mid=" + _wwv + "";//查询一换购商品
                            DataTable td1 = comfun.GetDataTableBySQL(_sqlyh);
                            string nowtd = "";
                            if (td1 != null && td1.Rows.Count > 0)
                            {
                                foreach (DataRow dr in td1.Rows)
                                {
                                    nowtd += dr["gid"].ToString();
                                }
                                int index = nowtd.ToString().LastIndexOf(',');
                                nowtd = nowtd.Substring(0, index);
                            }
                            _sql = "select * from B2C_Goods where cityid=" + wid + " and g_buytype=2 and id in(" + nowtd + ")";
                            DataTable td2 = comfun.GetDataTableBySQL(_sql);
                            readNum.Text = td2.Rows.Count.ToString();
                        }
                        nowNum.Text = td.Rows.Count.ToString();
                        if (td != null && td.Rows.Count > 0)
                        {
                            JiFenGoods.Text = GetInfo(td);
                        }
                    }
                    catch (Exception ex)
                    {
                        comfun.ChuliException(ex, "tdxvip/vip/redeem.aspx", Session["wID"].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 输出信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetInfo(DataTable dt)
        {
            string info = "<ul>";
            foreach (DataRow dr in dt.Rows)
            {
                info += @"<li class='gocart' idnum='"+dr["id"]+"'><a><span><img src='" + dr["g_gif"] + "' /></span><i>" + Convert.ToDouble(dr["g_cent"]).ToString("f0") + "积分</i><em>" + dr["g_name"] + "</em></a></li>";
            }
            info += "</ul>";
            return info;
        }
    }
}