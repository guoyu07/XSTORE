﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.appv
{
    public partial class index : weixinAuth
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
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" /> <link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/index.css\" /> ";

                lt_nichen.Text = _tdxWeixinArry[1];

                string result = "", result2 = "";
                string _sql = "select a_name,a_url,a_adgif,a_des from b2c_ads where cno='009' and a_isactive=1 and a_isdel=0 order by a_sort,id desc"; // and cityid=" + Session["wID"].ToString().Trim() + "
                _sql += ";select *  from b2c_menu where c_no like '001%' and c_level=2 and c_isactive=1 and c_isdel=0 order by c_sort,c_id desc"; // and cityid=" + Session["wID"].ToString().Trim() + "
                _sql += ";select * from  wx_config"; // where id=" + Session["wID"].ToString().Trim()
                DataSet ds = comfun.GetDataSetBySQL(_sql);
                int tmpi = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //result += "<table cellspacing='0' cellpadding='0' border='0'><tr> \r\n";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result += " <li> \r\n";
                        result += "     <a href='" + (string.IsNullOrEmpty(dr["a_url"].ToString()) ? "return false;" : dr["a_url"].ToString().Trim()) + "'><img src='" + dr["a_adgif"].ToString().Trim().Replace("all", "max") + "'  border='0'/></a>";
                        result += "        <div class=\"box_title\"> \r\n";
                        result += "         <h3>" + dr["a_name"].ToString().Trim() + "</h3> \r\n";
                        result += "         <p>" + dr["a_des"].ToString().Trim() + "</p></div> \r\n";
                        result += " </li> \r\n";

                        result2 += "<li " + (tmpi++ == 0 ? "class=\"on\"" : "") + "></li>\r\n";
                    }
                    //result += "</tr></table> \r\n";
                }
                lt_photolist.Text = result;
                lt_arrowpage.Text = result2;

                result = "";
                int i = 1;
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    string _curl = dr["c_url"].ToString().Trim();
                    if (!string.IsNullOrEmpty(_curl))
                    {
                        if (!(_curl.StartsWith("tel:")))
                        {
                            if (_curl.IndexOf("?") != -1)
                                _curl += "&";
                            else
                                _curl += "?";

                            _curl += "WWX={0}&wwv={1}";
                        }
                    }

                    result += " <li id=\"content_item" + (i++).ToString() + "\"> \r\n"; 
                    result += "     <div ><p><a href=\"" + _curl + "\"><img src='" + dr["c_gif"].ToString().Trim().Replace("all", "max") + "'  border='0'/></a></p><span>" + dr["c_name"].ToString().Trim() + "<em>" + dr["c_des"].ToString().Trim() + "</em></span></div>";                  
                    result += " </li> \r\n";
                }
                lt_GoodCate.Text = string.Format(result, Request["WWX"] != null ? Request["WWX"].ToString().Trim() : "", Request["WWV"] != null ? Request["WWV"].ToString().Trim() : "");//商品类别列表
                foreach (DataRow item in ds.Tables[2].Rows)
                {
                    tel.Text = "<a href=\"tel:" + item["M_tel"] + "\">" + item["M_tel"] + "</a>";
                }
                ////////////////////缺省
            }
        }
    }
}
