using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using weixinAuth = tdx.Weixin.weixinAuth;

namespace Wx_NewWeb.appv
{
    public partial class tpagelist : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');

                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');

                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\" />";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\" />";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssIndex/" + _theme[0] + "/comm.css\" /> ";
                lt_theme1.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssList/" + _theme[1] + "/list.css\" /> ";

                string _cno = Request["cno"] != null ? Request["cno"].ToString().Trim() : "";
                txtCno.Value = _cno;
                // and cityid=" + Session["wID"].ToString().Trim() + "                       
                string _sql = "select *,(select c_name from b2c_tpclass where c_no=cno) as cname from b2c_tpage where cno='" + _cno + "' order by g_sort,id desc"; //and  cityid=" + Session["wID"].ToString().Trim() + "
                // cityid=" + Session["wID"].ToString().Trim() + " and
                _sql += "; select * from b2c_tpclass where c_no like '" + _cno + "%' and len(c_no)=" + (_cno.Length + 3) + " order by c_sort,c_id";
                DataSet ds = comfun.GetDataSetBySQL(_sql);
                string result = "";
                string result2 = "";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    result += "<ul > \r\n";
                    foreach (DataRow dr2 in ds.Tables[1].Rows)
                    {

                        result += "<li id=l_item\"" + dr2["c_id"].ToString() + "\"> \r\n";
                        result += "\r\n<a href='tpagelist.aspx?cno=" + dr2["c_no"].ToString().Trim() + "&WWX=" + Request["WWX"].ToString().Trim() + "'>";
                        result += "      \r\n" + (string.IsNullOrEmpty(dr2["c_gif"].ToString().Trim()) ? "" : "<img src='" + dr2["c_gif"].ToString().Trim() + "' border='0' />") + "";
                        result += "      \r\n<h1>";
                        result += "     \r\n    " + (dr2["c_name"].ToString().Trim().Length > 20 ? (dr2["c_name"].ToString().Trim().Substring(0, 17) + "...") : dr2["c_name"].ToString().Trim());
                        result += "     \r\n </h1>";
                        result += "      \r\n<p>";
                        result += "     \r\n    " + (dr2["c_des"].ToString().Trim().Length > 40 ? (dr2["c_des"].ToString().Trim().Substring(0, 37) + "...") : dr2["c_des"].ToString().Trim());
                        result += "     \r\n </p>";
                        result += "</a>\r\n";
                        result += "</li> \r\n";

                    }
                    result += "</ul> \r\n";
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result += "\r\n";
                    result += "<h1> " + ds.Tables[0].Rows[0]["cname"].ToString().Trim() + " </h1> \r\n";
                    result += "<ul> \r\n";
                    foreach (DataRow dr in ds.Tables[0].Rows)//此处li没加id
                    {

                        result += "<li> \r\n";
                        result += "\r\n<a href='tpage.aspx?id=" + dr["id"].ToString().Trim() + "&WWX=" + Request["WWX"].ToString().Trim() + "'>";
                        result += "      \r\n" + (string.IsNullOrEmpty(dr["ggif"].ToString().Trim()) ? "" : "<img src='" + dr["ggif"].ToString().Trim() + "' border='0' />") + "";
                        result += "      \r\n<h1>";
                        result += "     \r\n    " + (dr["gtitle"].ToString().Trim().Length > 20 ? (dr["gtitle"].ToString().Trim().Substring(0, 17) + "...") : dr["gtitle"].ToString().Trim());
                        result += "     \r\n </h1>";
                        result += "</a>\r\n";
                        result += "</li> \r\n";

                    }
                    result += "</ul>\r\n";
                }
                ds.Dispose();
                ds = null;

                lt_newslist.Text = result;
            }
        }
    }
}