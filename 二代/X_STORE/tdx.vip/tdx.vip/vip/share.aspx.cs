using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using System.Text;
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.vip
{
    public partial class share : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //11
                    if (Session["wID"] != null)
                    {
                        DataTable dt = B2C_share.GetList(" * ", " t_isactive=1 and cityID=" + Session["wID"]);
                        StringBuilder outSb = new StringBuilder();
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                outSb.Append("<li><a href='#'><span>");
                                outSb.Append("<img src=" + dr["t_gif"].ToString().Replace("all","min") + " /></span><em>" + dr["t_title"] + "</em>");
                                outSb.Append("<i>分享后获得" + dr["t_ischead"] + "积分</i></a></li>");
                            }
                            vip_share_now.Text = outSb.ToString();
                        }

                        DataTable dtmid = comfun.GetDataTableBySQL("select id from B2C_mem where M_card='" + Request["wwv"] + "'");
                        if (dtmid.Rows.Count > 0)
                        {
                            DataTable Deldt = B2C_share.GetList(" * ", " t_isactive=0 and cityID=" + dtmid.Rows[0][0]);
                            StringBuilder deloutSb = new StringBuilder();
                            if (Deldt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in Deldt.Rows)
                                {
                                    deloutSb.Append("<li><a href='#'><span>");
                                    deloutSb.Append("<img src=" + dr["t_gif"] + " /></span><em>" + dr["t_title"] + "</em>");
                                    deloutSb.Append("<i>分享后获得" + dr["t_ischead"] + "积分</i></a></li>");
                                }
                                vip_share_history.Text = deloutSb.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "vip/share.aspx.cs", Session["wID"].ToString());
                }
            }
        }
    }
}