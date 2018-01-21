using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using tdx.Weixin;
using System.Data;
using System.Text;
using Creatrue.kernel;
using Creatrue.Common;


namespace tdx.vip
{
    public partial class vip_Goods_Show : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["wID"] != null)
                    {
                        DataTable dt = B2C_Goods.GetList(" * ", " g_buytype=1 and g_isdel=0 and cityid=" + Session["wID"].ToString());
                        if (dt.Rows.Count > 0)
                        {
                            StringBuilder outSb = new StringBuilder();
                            foreach (DataRow dr in dt.Rows)
                            {
                                outSb.Append("<li><a href='#'>");
                                outSb.Append("<img src=" + dr["g_gif"] + " />");
                                outSb.Append("<span><i>优惠价：" + dr["g_price_S"] + "</i></span>");
                                outSb.Append("</a><input type='button' value='我要订购' onclick=getmsg(" + dr["id"] + ",'" + Request["WWX"].ToString() + "') /></li>");
                            }
                            vip_goods.Text = outSb.ToString();
                        }

                        DataTable Deldt = B2C_Goods.GetList(" * ", " g_buytype=1 and g_isdel=1 and cityid=" + Session["wID"].ToString());
                        if (Deldt.Rows.Count > 0)
                        {
                            StringBuilder deloutSb = new StringBuilder();
                            foreach (DataRow dr in Deldt.Rows)
                            {
                                deloutSb.Append("<li><a href='#'>");
                                deloutSb.Append("<img src=" + dr["g_gif"] + " />");
                                deloutSb.Append("<span><i>优惠价：" + dr["g_price_S"] + "</i></span>");
                                deloutSb.Append("</a></li>");
                            }
                            vip_goods_del.Text = deloutSb.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}