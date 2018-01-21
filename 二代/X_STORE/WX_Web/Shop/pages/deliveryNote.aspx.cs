using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using DTcms.Common;
using Newtonsoft.Json;

namespace Wx_NewWeb.Shop.pages
{
    public partial class deliveryNote : BasePage
    {
        public int total_num;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
                //note_access();
            }
        }
        #region
        protected void PageInit()
        {
            try
            {
                string bind_sql = string.Format(@"SELECT * FROM 视图投放记录 WHERE user_id={0} AND 是否投放 = 1 AND IsShow = 1 ORDER BY 时间 DESC", UserId);
                DataTable bind_dt = comfun.GetDataTableBySQL(bind_sql);
                Log.WriteLog("类：deliveryNote", "方法：pageInit", "bind_dt:" + JsonConvert.SerializeObject(bind_dt));
                
                total_num = bind_dt.Rows.Count;
                rp_note.DataSource = bind_dt;
                rp_note.DataBind();
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：deliveryTask", "方法：PageInit", "异常：" + ex.Message);
                RedirectError(ex.Message);
            }

        }
        #endregion
        
    }
}