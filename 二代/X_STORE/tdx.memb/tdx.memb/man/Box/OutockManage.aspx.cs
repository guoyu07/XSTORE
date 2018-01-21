using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Box
{
    public partial class OutockManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bind();
            }
        }

        protected void bind()
        {
             string outrockid = string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"];
             string sql_Ostock = "select WP_仓库表.仓库名 as 仓库,WP_出库表.位置,WP_出库表.操作日期,WP_出库表.id,单据编号,WP_出库表.商品id,WP_商品表.品名,WP_商品表.本站价,WP_商品表.规格,WP_商品表.市场价,数量,出价,dt_manager.[user_name] as 出库人,总出价额,WP_出库表.库位id,WP_仓库表.id,WP_酒店表.id,出库类型,备注,视图在库表.库存数 from WP_出库表 left join WP_商品表 on WP_商品表.id= WP_出库表.商品id left join WP_库位表 on WP_库位表.id=WP_出库表.库位id left join WP_仓库表 on WP_仓库表.id=WP_库位表.仓库id left join WP_酒店表 on WP_酒店表.id=WP_仓库表.酒店id left join WP_地区表 on WP_地区表.id=WP_酒店表.区域id left join dt_manager on dt_manager.id=WP_出库表.操作id left join 视图在库表 on WP_出库表.商品id=视图在库表.商品id where 单据编号='" + outrockid + "'";
            DataTable dt = comfun.GetDataTableBySQL(sql_Ostock);
            this.Rp_Outocklist.DataSource = dt;
            this.Rp_Outocklist.DataBind();
            

        }
   
            
        
    }
}