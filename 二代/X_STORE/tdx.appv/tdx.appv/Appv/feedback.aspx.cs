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
using tdx.database;

namespace tdx.appv
{
    public partial class feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
            string[] _tdxWeixinArry = _tdxWeixin.Split('|');
            lt_title.Text = _tdxWeixinArry[1];
            lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
            lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\">";
            lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/" + _tdxWeixinArry[2] + "/apps_main.css\" /> ";
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            string result = "";
            string _msg = txtContent.Value.Trim();
            string _tel = txtTel.Value.Trim();
            if (_msg.Length == 0)
            {
                result = "请输入留言内容";
                lt_result.Text = result;
                return;
            }
            if (_tel.Length == 0)
            {
                result = "请输入联系方式";
                lt_result.Text = result;
                return;
            }
            B2C_note bn = new B2C_note();
            bn.AddNew();
            bn.n_msg = _msg;
            bn.n_link = _tel;
            bn.n_title = _tel;

            try
            {
                bn.Update();
                result = "感谢您的留言.我们会尽快处理.";
            }
            catch (Exception ex)
            {
                result = "非常抱歉留言出错." + ex.Message ;
            }
            lt_result.Text = result;

        }
    }
}
