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
    public partial class prolist : tdx.Weixin.weixinAuth
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
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssIndex/" + _theme[0] + "/comm.css\" />";

                lt_theme1.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssList/" + _theme[1] + "/list.css\" />";

                string _cno = Request["cno"] != null ? Request["cno"].ToString().Trim() : "";
                string _page = Request["page"] != null ? Request["page"].ToString().Trim() : "1";
                string _postionID = Request["positionID"] != null ? Request["positionID"].ToString().Trim() : "";
                txtCno.Value = _cno;
                txtPage.Value = _page;

                string _sql = "";
                DataTable dt = null;
                string result = "";
                string result2 = "";
                _sql = "select * from b2c_category where c_no like '" + _cno + "%' and len(c_no)>" + _cno.Length + " and len(c_no)<="+ Convert.ToInt32((_cno.Length)+3)+" order by c_sort,c_id desc";
                _sql += ";\r\n select top " + (Convert.ToInt32(_page) * 10000).ToString().Trim() + " *,(select c_name from b2c_category where c_no=cno) as cname from b2c_goods where cno like '%" + _cno + "%' and g_isactive=1 and g_isdel=0  order by g_sort,id desc";
                DataSet ds = comfun.GetDataSetBySQL(_sql);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    result = "\r\n";
                    result += "<h1> 产品中心 </h1> \r\n";
                    if (Convert.ToInt32(_cno.Length) < 9)
                    {
                        result += "<ul class=\"prolist_pro\" > \r\n";
                    }
                    else
                    {
                        result += "<ul class=\"prolist_pro_more\" > \r\n";
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        result += "<li id=l_item\"" + dr["c_id"].ToString() + "\"> \r\n";
                        result += "\r\n<a href='prolist.aspx?cno=" + dr["c_no"].ToString().Trim() + "&WWX=" + _DefGuID + "'>";
                        //result += "<div> \r\n";
                        result += "     \r\n<img src='" + (string.IsNullOrEmpty(dr["c_gif"].ToString()) ? "images/nopic.png" : dr["c_gif"].ToString().Replace("all", "min")) + "' border='0' />";
                        result += "     \r\n    <h1>" + dr["c_name"].ToString().Trim() + "</h1>";
                        result += "     \r\n    <p>" + dr["c_des"].ToString().Trim() + "</p>";
                        //result += "     \r\n    <p class=\"clearW\"> </p>\r\n";                                           
                        //result += "</div> \r\n";
                        result += "</a>\r\n";
                        result += "</li>";
                    }
                    result += "</ul> \r\n";
                }
                else
                {
                    dt = ds.Tables[1];
                    result = "\r\n";
                    if (dt.Rows.Count > 0)
                    {
                        result += "\r\n";

                        result += "<h1> " + dt.Rows[0]["cname"].ToString().Trim() + " </h1> \r\n";
                        if (Convert.ToInt32(_cno.Length) < 9)
                        {
                            result += "<ul class=\"prolist_pro\" > \r\n";
                        }
                        else
                        {
                            result += "<ul class=\"prolist_pro_more\" > \r\n";
                        }
                       
                        foreach (DataRow dr in dt.Rows)
                        {
                            result += "<li id=l_item\"" + dr["id"].ToString() + "\"> \r\n";
                            result += "\r\n<a href='showpro.aspx?id=" + dr["id"].ToString().Trim() + "&WWX=" + _DefGuID + "'>";
                            //result += "<div> \r\n";
                            result += "     \r\n<img src='" + (string.IsNullOrEmpty(dr["g_gif"].ToString()) ? "images/nopic.png" : dr["g_gif"].ToString().Replace("all", "min")) + "' border='0' />";
                            result += "     \r\n    <h1>" + dr["g_name"].ToString().Trim() + "</h1>";
                            result += "     \r\n    <p>" + dr["g_des"].ToString().Trim() + "</p>";
                            //result += "     \r\n    <p class=\"clearW\"> </p>\r\n";                                           
                            //result += "</div> \r\n";
                            result += "</a>\r\n";
                            result += "</li>";
                        }
                        result += "</ul> \r\n";
                        result2 += "<h1 class=\"proTitle\" id=\"prolsit_more\">点击查看更多" + dt.Rows[0]["cname"].ToString().Trim() + " </h1>";
                    }
                }
                dt.Dispose();
                dt = null;

                if (_postionID != "")
                {
                    result += "<script language='javascript'>";
                    result += "$(function(){";
                    result += "     var _h = $(\"#" + _postionID + "\").offset().top;";
                    result += "   $(\"html,body\").animate({scrollTop:(_h -200)},1000); ";
                    result += "})";
                    result += "</script>";
                }

                lt_prolist.Text = result;
                //lt_prolist_more.Text = result2;
            }
        }
        private string GetMoney(string _money)
        {
            return string.Format("{0:F}", Convert.ToDouble(_money));
        }
    }
}