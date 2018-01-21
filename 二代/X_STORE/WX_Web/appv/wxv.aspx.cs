using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using System.IO;
using System.Text;
using tdx.Weixin;

namespace Wx_NewWeb
{
    public partial class wxv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                weixin _wx = new weixin();
                string postStr = "";
                if (Request.HttpMethod.ToLower() == "post")
                {
                    Stream s = System.Web.HttpContext.Current.Request.InputStream;
                    byte[] b = new byte[s.Length];
                    s.Read(b, 0, (int)s.Length);
                    postStr = Encoding.UTF8.GetString(b);

                    if (!string.IsNullOrEmpty(postStr)) //请求处理
                    {
                        _wx.Handle(postStr);
                        //System.Web.HttpContext.Current.Response.Redirect("http://www.fsWeixin.com/helps/aboutus.html");
                        //任何直接跳转出界面都是不可行的。
                        //必须返回内容给接口,再从客户点击才能跳转出界面
                    }
                }
                else
                {
                    _wx.Auth();
                }

            }
        }
    }
}