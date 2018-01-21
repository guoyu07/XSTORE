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
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.appv
{
    public partial class honor_contactus : weixinAuth
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
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" /> ";
                lt_theme1.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssDetail/" + _theme[2] + "/detail.css\" /> ";
                lt_theme1.Text += "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/yisa_detail.css\" /> ";
                //lt_theme2.Text = _tdxWeixinArry[2];

                string _wwx = Request["wwx"] != null ? Request["wwx"].ToString().Trim() : "";
                string _wwv = Request["wwv"] != null ? Request["wwv"].ToString().Trim() : "";
                string _typeID = Request["typeID"] != null ? Request["typeID"].ToString().Trim() : "0";
                lt_proTitle.Text = "欢迎您参加“关注伊萨中国官方微信平台，100元京东购物卡免费送”活动 <br /> 请完整填写以下个人信息，点击“参与抽奖”按钮";
               
            }
        }

        //处理添加活动
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string _uname = uname.Value;
            string _ucompany = ucompany.Value;
            string _utel = utel.Value;
            string _umail = umail.Value;
            string _uaddr = uaddr.Value;

            string _wwx =Request["wwx"]!=null? Request["wwx"].ToString().Trim() : "";
            string _wwv = Request["wwv"] != null ? Request["wwv"].ToString().Trim() : "";
            string _typeID = Request["typeID"] != null ? Request["typeID"].ToString().Trim() : "0";

            DateTime today = System.DateTime.Now;
            DateTime beDay = Convert.ToDateTime("2014-06-01");
            DateTime afDay = Convert.ToDateTime("2014-07-31");

            if (today > afDay)
            {
                lt_result.Text = "抽奖活动已结束。请下次再来，谢谢。";
                return;
            }
            if (today < beDay)
            {
                lt_result.Text = "抽奖活动还未开始。请稍后再来，谢谢。";
                return;
            }
            if (string.IsNullOrEmpty(_uname) || string.IsNullOrEmpty(_ucompany) || string.IsNullOrEmpty(_utel) || string.IsNullOrEmpty(_umail))
            {
                lt_result.Text = "请确保您填写的个人信息须真实有效，以免影响奖品派发";
                return;
            }
            DataTable dt = comfun.GetDataTableBySQL("select * from b2c_mem where (m_name='" + _uname + "' or m_mobile='" + _utel + "' or M_carNo='" + _wwv + "') and cityID=" + Session["wID"].ToString().Trim());
            if (dt.Rows.Count > 0)
            {
                lt_result.Text = "每个人只能参加一次活动。";
                return;
            }
            B2C_mem bm = new B2C_mem();
            bm.M_name = _uname; 
            bm.M_truename = _ucompany;
            bm.M_tel = _utel;
            bm.M_mobile = _utel;
            bm.M_email = _umail;
            bm.M_addr = _uaddr;
            bm.M_CarNo = _wwv;
            //bm.cityID  = Convert.ToInt32(Session["wID"].ToString().Trim());

            try
            {
                bm.Update();
                Response.Redirect("honor_action2.aspx?typeid=" + _typeID + "&wwx=" + _wwx + "&wwv=" + _wwv);
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
            }
        }
    }
}
