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
    public partial class MyAddress : System.Web.UI.Page
    {
        Chat chat = new Chat();

        public string unionid = "";
        public string openid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["unionid"] != null)
                {
                    //  Response.Write("<script>alert('"+Request.Url.AbsoluteUri+"')</script>"); "http://hongdou.creatrue.net/tuan/myding.aspx"
                    unionid = Request["unionid"].ToString();
                    string sql = "select * from dbo.WP_订单地址表 where id in(";
                    sql += "select 地址ID from WP_地址表 where openid in (select openid from WP_会员表 where unionid='" + unionid + "')) order by 是否为默认地址 desc ";
                    DataTable dtadd = comfun.GetDataTableBySQL(sql);
                    if (dtadd.Rows.Count > 0)
                    {
                        string str = "";
                        for (int i = 0; i < dtadd.Rows.Count; i++)
                        {
                            str += "<div class=\"address_list\"><div class=\"wrap padd_10\"><a href=\"AddressManage.aspx?id="+dtadd.Rows[i]["id"].ToString()+"\">";
                            str += "<div class=\"top_a clear\"><span class=\"name\">"+dtadd.Rows[i]["收货人"].ToString()+"</span><span class=\"tel\">"+dtadd.Rows[i]["手机号"].ToString()+"</span></div>";
                            str += "<div class=\"bot_a\">";
                            if(dtadd.Rows[i]["是否为默认地址"].ToString().Equals("1"))
                            { 
                            str += "<span>[默认]</span>";
                            }
                            str += "" + dtadd.Rows[i]["省"].ToString() + "" + dtadd.Rows[i]["市"].ToString() + "" + dtadd.Rows[i]["区"].ToString() + "" + dtadd.Rows[i]["详细地址"].ToString() + "</div>";
                            str += "  </a>  </div></div><div class=\"hei_15\"></div>";
                        }
                        Literal1.Text = str;
                    }

                    else
                    {
                 

                    }
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

        public void cgaddress(int id)
        {
            //comfun.UpdateBySQL("update ");
        }
    }
}