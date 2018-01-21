using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Msgbox;
using DTcms.DBUtility;
using DTcms.Model;
using tdx.database;
using tdx.Weixin;

namespace Wx_NewWeb.Talk
{
    public partial class Talk_HuiFu : weixinAuth
    {
        protected static string openid = "";

        public static int 发帖表id = 0; 
        TK_评论表 tk评论表=new TK_评论表();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
                if (!string.IsNullOrEmpty(Request["id"]))
                {

                   发帖表id = Convert.ToInt32(Request["id"]);

//                    DataTable dtTieZi = DbHelperSQL.Query(@"
//select top 1 a.*,b.wx昵称,b.wx头像 from TK_发帖表 a left join [dbo].[WP_会员表] b on a.openid=b.openid where a.ID ='" + 发帖表id + "' order by 是否置顶 desc,创建时间 desc").Tables[0];
//                    TalkTieZi.DataSource = dtTieZi;
//                    TalkTieZi.DataBind();

//                    DataTable dtPingLun = DbHelperSQL.Query("select a.*,b.wx昵称,b.wx头像 from [dbo].[TK_评论表] a left join [dbo].[WP_会员表] b on a.openid=b.openid where a.发帖表id='" + 发帖表id + "' order by a.评论时间 desc").Tables[0];
//                    RepeaterPingLun.DataSource = dtPingLun;
//                    RepeaterPingLun.DataBind();

                }
            }
        }

        //protected void button_OnClick(object sender, EventArgs e)
        //{
        //    tk评论表.openid = openid;
        //    tk评论表.发帖表id = 发帖表id;
        //    tk评论表.评论内容 = textarea_jj.Value;
        //    tk评论表.评论时间 = DateTime.Now;

        //    int sp = new DTcms.BLL.TK_评论表().Add(tk评论表);

        //    if (sp > 0)
        //    {
        //        //MessageBox.ShowAndRedirect(this, "发表成功！", "Talk_Detail.aspx?BH='" + new DTcms.BLL.TK_发帖表().GetModel(发帖表id).编号 + "'");
        //        Response.Write("<script language='javascript'>alert('发表成功！');location.href='Talk_Detail.aspx?BH=" + new DTcms.BLL.TK_发帖表().GetModel(发帖表id).编号 + "';</script>");
        //        Response.End();

        //    }
        //    else
        //    {
        //        MessageBox.Show(this, "发表失败！");
        //    }
        //}
    }
}