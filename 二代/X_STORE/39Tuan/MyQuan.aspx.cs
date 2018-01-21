using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;

namespace Tuan
{
    public partial class MyQuan : System.Web.UI.Page
    {
        Chat chat = new Chat();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["unionid"] != null)
                {
                    //  Response.Write("<script>alert('"+Request.Url.AbsoluteUri+"')</script>"); "http://hongdou.creatrue.net/tuan/myding.aspx"
                    string unionid = Request["unionid"].ToString();
                    DataTable dtdd = comfun.GetDataTableBySQL("select q_title,qnum,q_Bdate,q_Edate,(select count(id) from tm_quan_mem_log where qmid=tm_quan_mem.id) as yishiyong from tm_quan_mem,tm_quan where tm_quan.id=tm_quan_mem.qid unionid='" + unionid + "' order by tm_quan.id desc ");
                    if (dtdd.Rows.Count > 0)
                    {

                        string str = "";
                        for (int i = 0; i < dtdd.Rows.Count; i++)
                        { 
                            str += "<div class=\"order_messgae_list\"><div class=\"wrap padd_10\">";
                            str += "<div class=\"title\">" + dtdd.Rows[i]["q_title"].ToString() + "(" + dtdd.Rows[i]["q_Bdate"].ToString() + "~" + dtdd.Rows[i]["q_Edate"].ToString() + ")" + "</div>";
                            str += " <div class=\"content clear\">"; 
                            str += "   <div class=\"txt fl\"> 已使用：" +   dtdd.Rows[i]["yishiyong"].ToString()  + " </div>";
                            str += "   <div class=\"old_pic fr\"> 总数量：" + dtdd.Rows[i]["qnum"].ToString() + "</div></div>";
                            
                            str += "</div></div><div class=\"hei_15\"></div>";

                        }

                        Literal1.Text = str;
                    }

                    //else
                    //{
                    //    Response.Redirect("emptyfan.aspx");

                    //}
                }
                else
                {
                    //string str = HttpContext.Current.Request.Url.AbsolutePath;
                    //string strs = Path.GetFileName(str);
                    //string url = HttpContext.Current.Request.Url.Query;
                    //if (url.Equals(""))
                    //    url = "?1+1";
                    //Response.Redirect("TestGetInfo.aspx?back_url=" + (strs + url));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                // chat.GetCode(Request.Url.AbsoluteUri);
            }

        }
    }
}