using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.vipmemb
{
    public partial class JiFen_log : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int _wid = Convert.ToInt32(Session["wid"]);
                if (Request["id"] != null)
                {
                    DataTable _dt = comfun.GetDataTableBySQL("select * from B2C_mem where id=" + Request["id"].ToString());
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        lt_biaoti.Text = " 会员--" + _dt.Rows[0]["M_name"].ToString();
                    }

                    int _id = Convert.ToInt32(Request["id"].ToString());
                    string _sql = " ptid,ac_money,ac_regdate,ac_des";
                    string _where = string.Format(" wid={0} and uid={1} and ptid=1 order by id desc", _wid, _id);
                    DataTable dt = B2C_AccOperate.GetList(_sql, _where);
                    string result1 = "";
                    result1 += "\r\n";
                    result1 += " \r\n <table >";
                    result1 += " \r\n <tbody>";
                    result1 += "\r\n<tr>";
                    result1 += "\r\n<th>类型</th>";
                    result1 += "\r\n<th>相关行为</th>";
                    result1 += "\r\n<th>时间</th>";
                    result1 += "\r\n<th>备注</th>";
                    result1 += "\r\n</tr>";

                    foreach (DataRow dr in dt.Rows)
                    {
                        result1 += "\r\n <tr>";
                        result1 += " \r\n <td >" + "积分" + "</td> ";
                        if (Convert.ToDouble(dr["ac_money"].ToString()) >= 0)
                            result1 += " \r\n  <td>" + "积分充值:" + Convert.ToDouble(dr["ac_money"].ToString()).ToString("F2") + "</td> ";
                        else
                            result1 += " \r\n  <td>" + "积分消费:" + ((-1) * Convert.ToDouble(dr["ac_money"].ToString())).ToString("F2") + "</td> ";
                        result1 += " \r\n <td>" + dr["ac_regdate"].ToString() + "</td> ";
                        result1 += " \r\n <td>" + dr["ac_des"].ToString() + "</td> ";
                        result1 += " \r\n </tr>";
                    }
                    result1 += " \r\n </tbody>";
                    result1 += " \r\n </table>";
                    ylList1.Text = result1;
                }
            }
        }


    }
}