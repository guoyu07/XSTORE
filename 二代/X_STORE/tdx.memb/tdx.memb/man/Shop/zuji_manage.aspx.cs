using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Shop
{
    public partial class zuji_manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                advertinfoList();
            }
        }

        private void advertinfoList()
        {
            string where=" where 1=1 ";
            if (txt_starttime.Value!=""&&txt_endtime.Value!="")
            {
                 where= "where createtime between '" + txt_starttime.Value+" 00:00:00.000" + "' and '" + txt_endtime.Value+" 23:59:59.000" + "'";
            }

            DataTable dt = comfun.GetDataTableBySQL("select num,(select 品名 from WP_商品表 c where c.id=t.goodsid) as name from (select goodsid,count(openid) as num from WP_足迹 "+where+" group by goodsid )t order by num desc ");

            this.rptList1.DataSource = dt.DefaultView;
            this.rptList1.DataBind();


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            advertinfoList();
        }


    }
}