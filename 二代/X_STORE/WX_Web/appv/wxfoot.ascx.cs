using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

namespace Wx_NewWeb
{
    public partial class wxfoot : System.Web.UI.UserControl
    {
        public static string color = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tdxWeixin"] != null)
            {
                //快捷方式颜色以及是否存在
                string sqlcolor = "select * from wx_theme where cid=4 and isActive=1";
                DataTable dtcolor = comfun.GetDataTableBySQL(sqlcolor);
                if (dtcolor.Rows.Count > 0 && dtcolor != null)
                {
                    color = dtcolor.Rows[0]["t_theme"].ToString();
                    if(color=="red")
                    lt_color.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/wsite/red/wsite.css\" /> ";
                    else if(color=="blue")
                        lt_color.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/wsite/blue/wsite.css\" /> ";
                    else if (color == "orange")
                        lt_color.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/wsite/orange/wsite.css\" /> ";
                    else if(color=="black")
                        lt_color.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/wsite/black/wsite.css\" /> ";
                    else if(color=="green")
                        lt_color.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/images/wsite/green/wsite.css\" /> ";
                }
                else
                {
                    lt_color.Text = "";
                }





                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');

                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');

                lt_nichen.Text = DateTime.Now.Year.ToString() + _tdxWeixinArry[1];
                bool isend = false;//默认没有尾部
                /////////////////////////
                string result = "";

                string _sql = "select *  from b2c_menu where c_no like '003%' and c_level=2 and c_isactive=1 and c_isdel=0 order by c_sort,c_id desc"; //and cityid=" + Session["wID"].ToString().Trim() + "
                _sql += ";select m_name,m_tel,m_mobile,m_email,m_map,m_qq,wx_gntheme from b2c_worker where id=" + Session["wID"].ToString().Trim();
                DataSet ds = comfun.GetDataSetBySQL(_sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    isend = true;  //. 有尾部内容
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string _curl = ds.Tables[0].Rows[i]["c_url"].ToString().Trim();
                        if (!string.IsNullOrEmpty(_curl))
                        {
                            if (!(_curl.StartsWith("tel:")))
                            {
                                if (_curl.IndexOf("?") != -1)
                                    _curl += "&";
                                else
                                    _curl += "?";

                                _curl += "WWX={0}";
                            }
                        }
                        result += "<li id=\"foot_item" + (i + 1) + "\"><a href=\"" + _curl + "\"><img src=\"" + ds.Tables[0].Rows[i]["c_gif"].ToString().Trim().Replace("all", "max") + "\" border=\"0\" /><span>" + ds.Tables[0].Rows[i]["c_name"].ToString() + "</span></a></li>";
                    }
                    lt_menu.Text = string.Format(result, Request["WWX"] != null ? Request["WWX"].ToString().Trim() : "");


                }
                else
                {
                    result = "<li id=\"foot_item1\"><a href=\"index.aspx?WWX={1}\"><img src=\"/images/{0}/tb_others.png\" border=\"0\"  /><span>首页</span></a></li> ";
                    result += "  <li id=\"foot_item2\"><a href=\"tel:{0}?WWX={1}\"><img src=\"/images/{0}/tb_others3.png\" border=\"0\"  /><span>电话</span></a></li> ";
                    result += "  <li id=\"foot_item3\"><a href=\"honor_action.aspx?WWX={1}\"><img src=\"/images/{0}/tb_more.png\" border=\"0\" /><span>活动</span></a></li>";

                    //DataRow dr2 = ds.Tables[1].Rows[0];
                    //lt_menu.Text = string.Format(result, (dr2["m_mobile"].ToString().Trim() != "" ? dr2["m_mobile"].ToString().Trim() : dr2["m_tel"].ToString().Trim()), Request["WWX"] != null ? Request["WWX"].ToString().Trim() : "");
                }
                ////////////////////////////////////////////////////////////////
                //////   快捷方式 ////////
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow dr2 = ds.Tables[1].Rows[0];
                    lt_plus_tel.Text = string.Format("<a href=\"tel:{0}\"><span class=\"p-icon\"></span></a>", (dr2["m_mobile"].ToString().Trim() != "" ? dr2["m_mobile"].ToString().Trim() : dr2["m_tel"].ToString().Trim()));
                    lt_plus_map.Text = string.Format("<a href=\"{0}\"><span class=\"p-icon\"></span></a>", dr2["m_map"].ToString().Trim());
                    lt_plus_index.Text = string.Format("<a href=\"{0}\"><span class=\"p-icon\"></span></a>", "/" + dr2["wx_gntheme"].ToString().Trim() + "/index.aspx?wwx=" + (Request["WWX"] != null ? Request["WWX"].ToString().Trim() : "")); ;
                    lt_plus_qq.Text = string.Format("<a href=\"http://wpa.qq.com/msgrd?v=3&amp;uin={0}&amp;site=qq&amp;menu=yes\" target=\"_blank\"><span class=\"p-icon\"></span></a>", dr2["m_qq"].ToString().Trim()); ;
                }
                ds.Dispose();
            }

        }

    }
}