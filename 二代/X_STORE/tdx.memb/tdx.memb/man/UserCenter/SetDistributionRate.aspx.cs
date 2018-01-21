using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.DBUtility;
using tdx.database;

namespace tdx.memb.man.UserCenter
{
    public partial class SetDistributionRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_fenxiao.Text = getrate();
            }
        }

        private string getrate()
        {
            string sql = "select top 1  rate  from   DistributionRate ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != null)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string fx = getrate();
            string ffxx = this.txt_fenxiao.Text;
            string sql;
            if (string.IsNullOrEmpty(fx))
                sql = " insert  into  DistributionRate  values(1," + ffxx + ",'" + DateTime.Now + "')";
            else
                sql = " update   DistributionRate  set  rate=" + ffxx;
            int count = DbHelperSQL.ExecuteSql(sql);
            if (count > 0)
                MessageBox.ShowAndRedirect(this, "设置成功！", "");
            else
                MessageBox.ShowAndRedirect(this, "设置失败！", "");
        }
    }
}