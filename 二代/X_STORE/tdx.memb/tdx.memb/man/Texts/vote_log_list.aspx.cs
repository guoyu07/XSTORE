using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Texts
{
    public partial class vote_log_list : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int _wid = Convert.ToInt32(Session["wID"]);
                    string sql = @"select id,[name] from vote_bigpic"; // where cityID=" + Session["wID"]
                    DataTable dt = comfun.GetDataTableBySQL(sql);
                    string result1 = "";
                    if (dt.Rows.Count > 0)
                    {
                        result1 += "\r\n";
                        result1 += " \r\n <table >";
                        result1 += " \r\n <tbody>";
                        result1 += "\r\n <tr>";
                        result1 += "\r\n <th >名称</th> ";
                        result1 += " \r\n <th >操作</th> ";
                        result1 += " \r\n </tr>";
                        //   B2C_AccOperate b2c_acc = new B2C_AccOperate();
                        foreach (DataRow dr in dt.Rows)
                        {
                            int _id = Convert.ToInt32(dr["id"].ToString());
                            result1 += " \r\n <tr>";

                            result1 += " \r\n <td >" + dr["name"].ToString() + "</td> ";
                            result1 += " \r\n<td ><a  class=\"btnGreen\" href=\"" + "vote_Log.aspx?id=" + dr["id"].ToString() + "\">查看结果</a></td>";
                            result1 += " \r\n </tr>";
                        }
                        result1 += " \r\n </tbody>";
                        result1 += " \r\n </table>";
                        bdList.Text = result1;
                    }
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/Texts/vote_log_list.cs", Session["wID"].ToString());
                }
            }
        }
    }
}