using System;
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
    public partial class photolist : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');

                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');
                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\"/>";
                lt_description.Text ="<meta name=\"description\" content=\""+ _tdxWeixinArry[1]+"\"/>";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" /> ";
                lt_theme.Text += "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssDetail/" + _theme[2] + "/detail.css\" /> ";
                string result = "",result2="";
               
                string _cno = Request["cno"] == null ? "" : Request["cno"].ToString();
                //                                                                    and cityid=" + Session["wID"].ToString().Trim() + "
                string _sql = _cno == "" ? "select p_name,p_url,p_des from b2c_honor where p_isactive=1 and p_isdel=0 order by p_sort,id desc" : "select p_name,p_url,p_des from b2c_honor where p_isactive=1 and p_isdel=0 and cno=" + _cno + " order by p_sort,id desc;"; //and cityid=" + Session["wID"].ToString().Trim() + " 
                _sql += _cno == "" ? "" : "select * from B2C_Hclass where c_no=" + _cno + ";";
                DataSet ds = comfun.GetDataSetBySQL(_sql);
                DataTable dt = ds.Tables[0];
                if (ds.Tables.Count >= 2)
                    h_title.Text = "<h1>"+ds.Tables[1].Rows[0]["c_name"].ToString()+"</h1>";
                else
                    h_title.Text = "<h1>相册</h1>";

                int tmpi = 0;
                if (dt.Rows.Count > 0)
                {
                    //result += "<table cellspacing='0' cellpadding='0' border='0'><tr> \r\n";
                    foreach (DataRow dr in dt.Rows)
                    {
                        result += " <li> \r\n";
                        result += "     <a  href=\"" + dr["p_url"].ToString().Trim() + "\"><img src='" + dr["p_url"].ToString().Trim().Replace("all", "max") + "'  border='0'  style=\"width:100%;\" /></a>";
                        result += "        <div class=\"box_title\"> \r\n";
                        result += "         <h3>" + dr["p_name"].ToString().Trim() + "</h3> \r\n";
                        result += "         <p>" + dr["p_des"].ToString().Trim() + "</p></div> \r\n";
                        result += " </li> \r\n";

                        result2+="<li "+ (tmpi++ ==0?"class=\"on\"":"") + "></li>\r\n";
                    }
                    //result += "</tr></table> \r\n";
                }
                else
                {
                    result += "<p align='center'> 您还没有设置自己的相册 </p>\r\n";
                }
                dt.Dispose();

                lt_photolist.Text = result;
                lt_arrowpage.Text = result2;
            }
        }
    }
}
