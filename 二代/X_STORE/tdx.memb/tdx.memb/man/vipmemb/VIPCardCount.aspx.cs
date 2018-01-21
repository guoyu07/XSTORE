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
    public partial class VIPCardCount : workAuth
    {
        public int wid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["wid"] != null)
                {
                    wid = Convert.ToInt32(Session["wid"]);
                    //                                                              where cityID=" + Session["wid"] + "
                    string _sql = "select count(id) from B2C_user_rank where uid in(select id from B2C_mem) and create_time>='" + DateTime.Now.ToString("yyyy-MM-dd 00:00") + "' and create_time<'" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00") + "';";
                    _sql += "select count(id) from B2C_mem"; // where cityID=" + Session["wid"]
                    DataSet _ds = comfun.GetDataSetBySQL(_sql);
                    GetChart();
                    string result1 = "";
                    result1 += "\r\n";
                    result1 += " \r\n <table>";
                    result1 += " \r\n <tbody>";
                    result1 += "\r\n <tr>";
                    result1 += "\r\n <th>日期</th> ";
                    result1 += "\r\n <th >新增会员卡用户数</th> ";
                    result1 += "\r\n <th>会员卡用户总数</th> ";
                    result1 += " \r\n </tr>";
                    if (_ds.Tables[0].Rows.Count > 0 && _ds.Tables[1].Rows.Count > 0)
                    {
                        result1 += "\r\n <tr>";
                        result1 += "\r\n <td >" + DateTime.Now.ToString("yyyy-MM-dd") + "</td> ";
                        result1 += "\r\n <td>" + _ds.Tables[0].Rows[0][0] + "</td> ";
                        result1 += "\r\n <td>" + _ds.Tables[1].Rows[0][0] + "</td> ";
                        result1 += " \r\n </tr>";
                    }
                    result1 += " \r\n </tbody>";
                    result1 += " \r\n </table>";
                    ylList.Text = result1;
                }
            }
        }
        //获得走势图
        private void GetChart()
        {
            DateTime _now = DateTime.Now;
            int mouth = DateTime.DaysInMonth(_now.Year, _now.Month);//获取当前月有多少天
            //                                                                       where cityID=" + Session["wid"] + "
            string _sql = "select * from B2C_user_rank where uid in(select id from B2C_mem) and create_time<'" + DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd 00:00") + "' and create_time>'" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00") + "'";
            DataTable _dt = comfun.GetDataTableBySQL(_sql);
            string item = "";
            //DataTable _copyDt=_dt.Clone();
            //for (int i = 0; i < _dt.Rows.Count; i++) {
            //    _copyDt.ImportRow(_dt.Rows[i]);
            //}
            DataView _dv;
            for (int i = 0; i < mouth; i++)
            {
                DataTable _cp = new DataTable();
                _dv = new DataView(_dt);
                string _str = " create_time>='" + DateTime.Now.ToString("yyyy-MM-" + (i + 1) + " 00:00") + "' and create_time<='" + DateTime.Now.ToString("yyyy-MM-" + (i + 1) + " 23:59:59") + "'";
                _dv.RowFilter = _str;
                _cp = _dv.ToTable();
                if (i != mouth - 1)
                {
                    item += (i + 1) + "," + _cp.Rows.Count + "-";
                }
                else
                {
                    item += (i + 1) + "," + _cp.Rows.Count;
                }
            }
            _hf.Value = item;
        }
    }
}