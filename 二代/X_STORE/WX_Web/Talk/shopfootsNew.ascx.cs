using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.Common;

namespace Wx_NewWeb.Talk
{
    public partial class shopfootsNew : System.Web.UI.UserControl
    {

        public string carhtml = "";
        public string openid = "";
        public string page = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
            string sql = "select * from wp_购物车 where openid='" + openid + "' and 是否结算=0";
            DataTable dtcar = comfun.GetDataTableBySQL(sql);
            int count = 0;
            if (dtcar != null && dtcar.Rows.Count > 0)
            {
                foreach (DataRow row in dtcar.Rows)
                {
                    count += Utils.ObjToInt(row["数量"], 0);
                }

            }
            carhtml += "<a href=\"../Shop/gouwuche.aspx?openid=" + openid + "\"  page_click_button=\"底部_购物车\"";
            carhtml += "  class=\"\" name=\"con\"><i class=\"new_icon\"><strong style=\"\">" + count + "</strong></i> <span>购物车</span></a>";
        }
    }

}