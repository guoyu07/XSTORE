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
using DTcms.Common;

namespace tdx.memb.man.UserCenter
{
    public partial class SetBaoYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                baoyouleixing();
                getbaomoney();
            }
        }

        private void baoyouleixing()
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("name", typeof(string));
            dt1.Rows.Add(1, "江浙沪包邮");
            dt1.Rows.Add(2, "全国包邮");
            drp_photo.DataSource = dt1;
            drp_photo.DataTextField = "name";
            drp_photo.DataValueField = "id";
            drp_photo.DataBind();

        }

        private string getbaomoney()
        {
            string sql = "select top 1  baomoney ,begintime,endtime,baoyou,weight from   BaoYou ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != null)
            {
                this.txt_baomoney.Text = dt.Rows[0]["baomoney"].ToString();
                this.txt_starttime.Value = dt.Rows[0]["begintime"].ToString();
                this.txt_endtime.Value = dt.Rows[0]["endtime"].ToString();
                this.txt_baoweight.Text = Utils.ObjToDecimal(dt.Rows[0]["weight"], 0).ToString();
                drp_photo.SelectedValue = dt.Rows[0]["baoyou"].ToString();
                return this.txt_baomoney.Text;
            }
            return "";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string sqlnew = "select count(1) from   BaoYou ";
            int countnew = 0;
            int.TryParse(DbHelperSQL.GetSingle(sqlnew).ToString(), out countnew);
            string ffxx = this.txt_baomoney.Text;
            DateTime starttime;
            DateTime endtime;
            DateTime.TryParse(this.txt_starttime.Value, out starttime);
            DateTime.TryParse(this.txt_endtime.Value, out endtime);
            int baoyou = Convert.ToInt32(drp_photo.SelectedValue);
            string sql;
            if (countnew <= 0)
                sql = " insert  into  BaoYou  values(1," + ffxx + ","+Utils.ObjToDecimal(txt_baoweight.Text,0)+",'" + DateTime.Now + "','" + starttime + "','" + endtime + "'," + baoyou + ")";
            else
                sql = " update   BaoYou  set  baomoney=" + ffxx + ",weight=" + Utils.ObjToDecimal(txt_baoweight.Text,0)+ ",begintime='" + starttime + "'," + "endtime='" + endtime + "',baoyou=" + baoyou + " ";
            int count = DbHelperSQL.ExecuteSql(sql);
            if (count > 0)
                MessageBox.ShowAndRedirect(this, "设置成功！", "");
            else
                MessageBox.ShowAndRedirect(this, "设置失败！", "");
        }
    }
}