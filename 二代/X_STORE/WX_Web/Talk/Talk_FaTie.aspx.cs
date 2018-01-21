using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Msgbox;
using DTcms.DBUtility;
using DTcms.Model;
using tdx.Weixin;

namespace Wx_NewWeb.Talk
{
    public partial class Talk_FaTie : weixinAuth
    {
        protected static string openid = "";

        public static string 类别号 = "";
        DTcms.Model.TK_发帖表 tk发帖表=new TK_发帖表();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
                if (!string.IsNullOrEmpty(Request["cno"]))
                {
                    类别号 = Request["cno"].ToString();
                    DataTable dtLeiBie = DbHelperSQL.Query(@"
                    select * from [dbo].[TK_发帖类别表] where c_parent in (select id from [TK_发帖类别表] where 类别编号='" + 类别号 + "') order by id asc").Tables[0];
                    DataRow row = dtLeiBie.NewRow();
                    row["类别名"] = "请选择主题";
                    row["类别编号"] = "-1";
                    dtLeiBie.Rows.InsertAt(row, 0);
                    if (dtLeiBie.Rows.Count > 0)
                    {
                        drp_type.DataSource = dtLeiBie.DefaultView;
                        drp_type.DataTextField = "类别名";
                        drp_type.DataValueField = "类别编号";
                        drp_type.DataBind();
                    }

                }
            }
        }

        protected string Gettheme()
        {
            string val = "";
            DataTable dt = DbHelperSQL.Query("select * from [TK_发帖类别表] where 类别编号='" + 类别号 + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                val = dt.Rows[0]["类别名"].ToString();
            }
            return val;
        }

        //protected void button_OnClick(object sender, EventArgs e)
        //{
        //    tk发帖表.编号 = GeteRandomNumber(15);
        //    tk发帖表.类别号 = drp_type.SelectedValue;
        //    tk发帖表.名称 = title.Value;
        //    tk发帖表.内容 = textarea_jj.Value;
        //    tk发帖表.创建时间 = DateTime.Now;
        //    tk发帖表.openid = openid;
        //    tk发帖表.是否显示 = 1;
        //    tk发帖表.是否置顶 = 0;

        //    int sp = new DTcms.BLL.TK_发帖表().Add(tk发帖表);

        //    if (sp > 0)
        //    {
        //        //MessageBox.ShowAndRedirect(this, "发表成功！",
        //        //    "Talk_List.aspx?cno='" + 类别号+ "'");
        //        Response.Write("<script language='javascript'>alert('申请成功！');location.href='Talk_List.aspx?cno=" + 类别号 + "';</script>");
        //        Response.End();
        //    }
        //    else
        //    {
        //        MessageBox.Show(this, "发表失败！");
        //    }
        //}


        #region 生成 商品编号 随机数
        public char[] random = {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };

        public string GeteRandomNumber(int Length)
        {
            StringBuilder randomstr = new StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                randomstr.Append(random[rd.Next(62)]);
            }
            return randomstr.ToString();
        }

        #endregion


    }
}