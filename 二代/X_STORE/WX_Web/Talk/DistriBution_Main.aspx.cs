using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.Weixin;
using Creatrue.kernel;
using tdx.database;

namespace Wx_NewWeb.Talk
{
    public partial class DistriBution_Main : weixinAuth
    {
        public static string openid = "";
        public static int isactivea = -2;
        public static int id = 0;
        public static string Img = "";
        public static string name = "";
        public static string money = "";
        public static string team = "";
        protected decimal my_money = Convert.ToDecimal("0.00");
        protected string jsdkSignature = string.Empty;
        protected string nickName = string.Empty;
        protected string shareurl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            jsdkSignature = GetJsdkSignature(HttpContext.Current.Request.Url.AbsoluteUri.ToString());
            if (!IsPostBack)
            {
                DistriBution_head1.page = "分销中心";
                openid = Session["OpenId"] != null ? Session["OpenId"].ToString() : "";
                id = GetIdByOpenid(openid);
                DataTable dt_top = DbHelperSQL.Query(@"select top 1  a.*,b.*,c.mid,isnull( c.totalmoney,0) as totalmoney,(select count(1) from [dbo].[B2C_mem] where ParentID=b.id) as team from [WP_会员表] a left join [B2C_mem] B ON A.openid=B.openid
left join (select mid,sum(ac_money) as totalmoney from B2C_Account where cno in ('015','016') group by mid) c on b.id=c.mid
 where a.openid='" + openid + "'").Tables[0];
                if (dt_top.Rows.Count > 0)
                {
                    int.TryParse(dt_top.Rows[0]["M_isactive"].ToString(), out isactivea);
                    DB_top.DataSource = dt_top;
                    DB_top.DataBind();
                    nickName = dt_top.Rows[0]["wx昵称"].ToString();
                }
                this.myisactive.Value = isactivea.ToString();
                this.myopenid.Value = openid.ToString();
                shareurl = "http://hodo.china-mail.com.cn/Shop/index2.aspx";
            }
        }

        protected string Getmoney(string openid)
        {
            DataTable dt_money = comfun.GetDataTableBySQL("select top 1 a.ac_Amt from  B2C_Account a,B2C_mem  b where a.mid=b.id  and b.openid='" + openid + "' order by a.ac_regdate desc");
            if (dt_money.Rows.Count > 0)
            {
                my_money = Convert.ToDecimal(dt_money.Rows[0]["ac_Amt"].ToString());
            }
            return my_money.ToString();
        }

        public int GetIdByOpenid(string openid)
        {
            int a = 0;
            DataTable dt =
                DbHelperSQL.Query("select * from B2C_mem where openid='" + openid +
                                  "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                a = Convert.ToInt32(dt.Rows[0]["id"]);
            }
            return a;
        }

        private void liadinfo()
        {

        }

        protected void action_Click()
        {
            //if (isactivea == -2)
            //{
            //    string sql = " update B2C_mem set M_isactive=0 where  openid='" + openid + "'";
            //    int count = DbHelperSQL.ExecuteSql(sql);
            //    if (count > 0)
            //    {
            //        isactive.Value = "0";
            //        Response.Redirect("./DistriBution_Main.aspx");
            //    }
            //}  
        }
        public string GetJsdkSignature(string url)
        {
            string noncestr = "9hKgyCLgGZOgQmEI";
            int timestamp = 1421142450;
            Chat ch = new Chat();
            string ticket = ch.GetJsapi_Ticket();
            string string1 = "jsapi_ticket=" + ticket + "&noncestr=" + noncestr + "&timestamp=" + timestamp + "&url=" + url;
            string signature = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(string1, "SHA1");
            return signature.ToLower();
        }
    }
}