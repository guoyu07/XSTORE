using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using tdx.database;

namespace tdx.memb.man.actions
{
    public partial class Action_Passed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int wid = 0;
                //if (Session["wID"] != null)
                //{
                //    int.TryParse(Session["wID"].ToString(), out wid);
                //}

                string dzd = " *,(select ac_name from wx_actions where id=wx_action.typeid) as acname  ";
                string sql = string.Format(" ac_edate<'{1}'", DateTime.Now.ToString(), DateTime.Now.ToString()); //wid={0} and wid, 
                lb_prolist.Text = prolist(dzd, sql, 1);
            }
        }

        private string prolist(string _dzd, string _sql, int _pageIndex)
        {
            string str = "";
            str += @"<table >";
            str += @"    <tr>";
            str += @"       <th >类型</th>";
            str += @"       <th >活动名称</th>";
            str += @"       <th >开始时间</th>";
            str += @"       <th >结束时间</th>";
            str += @"    </tr>";
            str += @"        ";
            int currentPage = 1;
            if (Request["page"] != null)
            {
                currentPage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = Wx_action.GetList(_dzd, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                //int _typeID = Convert.ToInt32(dr["typeid"].ToString());
                //string _actionsSql = "select top 1 * from wx_actions where id=" + _typeID.ToString();
                //DataTable _tabActions = comfun.GetDataTableBySQL(_actionsSql);
                //if (_tabActions.Rows.Count > 0)
                //{
                str += @"        <tr>";
                str += @"          <td >" + dr["acname"].ToString() + "</td>";
                str += @"          <td >" + dr["ac_title"].ToString() + "</td>";
                str += @"          <td >" + dr["ac_bdate"] + "</td>";
                str += @"          <td >" + dr["ac_edate"] + "</td>";
                str += @"        </tr>";
                //}
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }
    }
}