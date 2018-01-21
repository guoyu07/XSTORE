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
    public partial class Rankinfo : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>配置您的微信会员卡等级";
                    if (Session["wid"] != null)
                    {
                        string _sql = "*";
                        int wid = Convert.ToInt32(Session["wid"]);
                        string _where = "wid=" + wid;
                        B2C_vipcard _bv = new B2C_vipcard(wid.ToString());
                        //addCard.HRef = "RankinfoEdit.aspx?cardId=" + _bv.id;
                        _where = " cardid=" + _bv.id + "order by id";
                        DataTable dt = B2C_rankinfo.GetList(_sql, _where);
                        string result1 = "";
                        if (dt.Rows.Count > 0)
                        {
                            result1 += "\r\n";
                            result1 += " \r\n <table>";
                            result1 += " \r\n <tbody>";
                            result1 += "\r\n <tr>";
                            result1 += "\r\n <th >名称</th> ";
                            result1 += "\r\n <th>等级积分条件</th> ";

                            result1 += " \r\n <th >创建时间</th> ";
                            result1 += " \r\n <th >修改</th> ";
                            result1 += " \r\n </tr>";
                            int index = 0;
                            foreach (DataRow dr in dt.Rows)
                            {
                                result1 += " \r\n <tr>";
                                result1 += " \r\n  <td >" + Convert.ToString(dr["name"]) + "</td> ";
                                result1 += " \r\n  <td >累计积分大于" + Convert.ToString(dr["score"]) + "</td> ";

                                result1 += " \r\n  <td >" + Convert.ToDateTime(dr["create_time"]).ToString("yyyy-MM-dd") + "</td> ";
                                if (index == 0)
                                {
                                    result1 += " \r\n<td ><a href=\"" + "RankinfoEdit.aspx?id=" + dr["id"].ToString() + "&index=1\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                                    index++;
                                }
                                else
                                {
                                    result1 += " \r\n<td ><a href=\"" + "RankinfoEdit.aspx?id=" + dr["id"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                                }
                                result1 += " \r\n </tr>";
                            }
                            result1 += " \r\n </tbody>";
                            result1 += " \r\n </table>";
                            ylList.Text = result1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/rankinfo.cs", Session["wID"].ToString());
                }
            }
        }
    }
}