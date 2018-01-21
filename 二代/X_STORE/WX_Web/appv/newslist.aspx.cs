using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.Weixin;


namespace Wx_NewWeb
{
    public partial class newslist1 : weixinAuth
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');

                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');

                body_label.Text = "<body class=\"nei_body\">";

                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\" />";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\" />";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssIndex/" + _theme[0] + "/comm.css\" /> ";
                lt_theme1.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssList/" + _theme[1] + "/list.css\" /> ";

                string _cno = Request["cno"] != null ? Request["cno"].ToString().Trim() : "";
                string _page = Request["page"] != null ? Request["page"].ToString().Trim() : "1";
                string _postionID = Request["positionID"] != null ? Request["positionID"].ToString().Trim() : "";
                txtCno.Value = _cno;
                txtPage.Value = _page;
                wwv.Value = Request["WWV"] == null ? "" : Request["WWV"].ToString().Trim();

                string _sql = "";

                _sql = "select *,(select c_name from b2c_tclass where c_no=cno) as c_name from b2c_tmsg where cno='" +
                   _cno + "' and t_isactive=1 and t_isdel=0 order by t_sort,id desc";
                _sql += "; select * from b2c_tclass where c_no like '" + _cno + "%' and len(c_no)=" + (_cno.Length + 3) + " order by c_sort,c_id";

                DataSet ds = comfun.GetDataSetBySQL(_sql);
                string result = "";
                string result2 = "";


                if (ds.Tables[1].Rows.Count > 0)
                {

                    result += "<ul > \r\n";
                    foreach (DataRow dr2 in ds.Tables[1].Rows)
                    {

                        result += "<li id=\"l_item" + dr2["c_id"].ToString() + "\"> \r\n";
                        result += "\r\n<a href='newslist.aspx?cno=" + dr2["c_no"].ToString().Trim() + "&WWX=" + Request["WWX"].ToString().Trim() + "&WWV=" + (Request["WWV"] == null ? "" : Request["WWV"].ToString().Trim()) + "'>";
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
                    body_label.Text = "<body class=\"nei_body_list\">";
                }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    string istype = "";
                    string pic = "";
                    string title = "";
                    result += "\r\n";

                    result += "<h1> " + ds.Tables[0].Rows[0]["c_name"].ToString().Trim() + " </h1> \r\n";
                    result += "<ul> \r\n";
                    foreach (DataRow dr in ds.Tables[0].Rows)//此处li没加id
                    {

                        result += "<li> \r\n";
                        result += "\r\n<a href='shownews.aspx?id=" + dr["id"].ToString().Trim() + "&WWX=" + Request["WWX"].ToString().Trim() + "&WWV=" + (Request["WWV"] == null ? "" : Request["WWV"].ToString().Trim()) + "'>";
                        result += "      \r\n" + (string.IsNullOrEmpty(dr["t_gif"].ToString().Trim()) ? "" : "<img src='" + dr["t_gif"].ToString().Trim() + "' border='0' />") + "";
                        result += "      \r\n<h1>";
                        result += "     \r\n    " + (dr["t_title"].ToString().Trim().Length > 20 ? (dr["t_title"].ToString().Trim().Substring(0, 17) + "...") : dr["t_title"].ToString().Trim());
                        result += "     \r\n </h1>";
                        result += "</a>\r\n";
                        result += "</li> \r\n";

                    }
                    result += "</ul>\r\n";
                    result2 += "<h1 class=\"proTitle\" id=\"newslsit_more\">点击查看更多" + ds.Tables[0].Rows[0]["t_title"].ToString().Trim() + " 新闻</h1>";
                    body_label.Text = "<body class=\"nei_body_list2\">";
                }
                ds.Dispose();
                ds = null;

                if (_postionID != "")
                {
                    result += "<script language='javascript'>";
                    result += "$(function(){";
                    result += "     var _h = $(\"#" + _postionID + "\").offset().top;";
                    result += "   $(\"html,body\").animate({scrollTop:(_h -200)},1000); ";
                    result += "})";
                    result += "</script>";
                }

                lt_newslist.Text = result;
                //lt_newslist_more.Text = result2;
            }
        }
        private string GetMoney(string _money)
        {
            return string.Format("{0:F}", Convert.ToDouble(_money));
        }

    }
}