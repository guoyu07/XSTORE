using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;

namespace Wx_NewWeb.Message
{
    public partial class WeixinHeads : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _tdxWeixin = Session["wpWeixin"].ToString().Trim();
            string[] _tdxWeixinArry = _tdxWeixin.Split('|');
            string wwx = Request["WWX"] != null ? Request["WWX"].ToString().Trim() : "";
            if (string.IsNullOrEmpty(wwx))
            {
                wwx = _tdxWeixinArry[3] != null ? _tdxWeixinArry[3].Trim() : "";
            }
            bool ishead = false;//默认没有头部
            ///////////////////////////////现在先判断头部有没有存在内容
            string result = "";
            DataTable dt = comfun.GetDataTableBySQL("select *  from b2c_menu where c_no like '002%' and c_level=2 and c_isactive=1 and c_isdel=0 order by c_sort,c_id desc"); // and cityid=" + Session["wID"].ToString().Trim() + "
            if (dt.Rows.Count > 0)
            {
                ishead = true;  //. 有头部内容
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string _curl = dt.Rows[i]["c_url"].ToString().Trim();
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
                    string fxjs = "";
                    if (dt.Rows[i]["c_name"].ToString() == "分享")
                    {
                        fxjs = "  onclick=\"document.getElementById('mcover').style.display='block';\"  ";
                        _curl = "";
                    }
                    else
                    {


                        _curl = "href=\"" + _curl + "\"";




                    }
                    result += "<li " + fxjs + " id=\"head_item" + (i + 1) + "\"><a " + _curl + "><img src=\"" + dt.Rows[i]["c_gif"].ToString().Trim().Replace("all", "max") + "\" border=\"0\" /><span>" + dt.Rows[i]["c_name"].ToString() + "</span></a></li>";
                }
                lt_menu.Text = string.Format(result, wwx);

            }
            else
            {
                result = "<li id=\"head_item1\"><a href=\"/appv/index.aspx?WWX={1}\"><img src=\"../../images/cssIndex/{0}/menu_home.png\" border=\"0\" /><span>首页</span></a></li>";
                result += "<li id=\"head_item2\" onclick=\"NavigationShow()\"><a ><img src=\"../../images/cssIndex/{0}/menu_down.png\" border=\"0\" /><span>菜单</span></a></li>";
                result += "<li id=\"head_item3\"><a href=\"javascript:history.go(-1);\"><img src=\"../../images/cssIndex/{0}/menu_back.png\" border=\"0\" /><span>返回</span></a></li>";

                lt_menu.Text = string.Format(result, _tdxWeixinArry[2], wwx);

                lt_menu2.Text = "";
                DataTable dtmenu = comfun.GetDataTableBySQL("select *  from b2c_menu where c_no like '001%' and c_level=2 and c_isactive=1 and c_isdel=0 order by c_sort,c_id desc"); // and cityid=" + Session["wID"].ToString().Trim() + "
                foreach (DataRow drmenu in dtmenu.Rows)
                {
                    string _curl = drmenu["c_url"].ToString().Trim();
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
                   // lt_menu2.Text += "<li><a href=\"" + _curl + "\">" + drmenu["c_name"].ToString() + "</a></li>";

                }
               // lt_menu2.Text = string.Format(lt_menu2.Text, wwx);

            }
            
        }



    }
}
