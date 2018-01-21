using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.Weixin;

namespace Wx_NewWeb.Talk
{
    public partial class Talk_List : weixinAuth
    {
        public static string 图片 = "";
        public static string 名称 = "";
        public static string 主题数 = "";
        public static string 帖数 = "";
        public static string 类别号 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Talk_head1.Title = "微社区列表";
                if (!string.IsNullOrEmpty(Request["cno"]))
                {
                    类别号 = Request["cno"].ToString();
                    DataTable dt = DbHelperSQL.Query(@"select a.*,isnull(b.主题,0) as 主题,isnull(c.发帖数,0) as 发帖数 from  [dbo].[TK_发帖类别表] a left join (select c_parent,count(1) as 主题 from TK_发帖类别表 Group by c_parent) b on a.id=b.c_parent left join (select c_parent,count(1) as 发帖数 from [dbo].[TK_发帖表] a left join [TK_发帖类别表] b on a.类别号=b.类别编号 Group by c_parent) c on a.id=c.c_parent where a.c_parent=0 and a.类别编号='" + 类别号 + "'").Tables[0];
                    if (dt.Rows.Count>0)
                    {
                        图片 = dt.Rows[0]["图片"].ToString();
                        名称 = dt.Rows[0]["类别名"].ToString();
                        主题数 = dt.Rows[0]["主题"].ToString();
                        帖数 = dt.Rows[0]["发帖数"].ToString();

                        DataTable dtTieZi = DbHelperSQL.Query(@"
select a.*,b.wx昵称,b.wx头像 from TK_发帖表 a left join [dbo].[WP_会员表] b on a.openid=b.openid where a.类别号 in 
(select 类别编号 from TK_发帖类别表 where c_parent=(select top 1 id from TK_发帖类别表 where 类别编号='" + 类别号 + "')) order by 是否置顶 desc,创建时间 desc").Tables[0];
                        TalkTieZi.DataSource = dtTieZi;
                        TalkTieZi.DataBind();
                    }
                }
            }



        }

        protected void TalkTieZi_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rp = (Repeater)e.Item.FindControl("ListGoods");
                DataRowView drv = (DataRowView)e.Item.DataItem;
                //取得ID
                string 发帖表id = ((DataRowView)e.Item.DataItem).Row["id"].ToString();
                //根据获得ID读取数据
                rp.DataSource =
                    DbHelperSQL.Query(
                        "select top 3  a.*,b.wx昵称,b.wx头像 from [dbo].[TK_评论表] a left join [dbo].[WP_会员表] b on a.openid=b.openid where a.发帖表id='" + 发帖表id + "' order by a.评论时间 desc")
                        .Tables[0];
                rp.DataBind();

            }

        }


        protected string Getthem(string cno)
        {
            string val = "";
            DataTable dt = DbHelperSQL.Query("select * from [TK_发帖类别表] where 类别编号='" + cno + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                val = dt.Rows[0]["类别名"].ToString();
            }
            return val;
        }

        protected string GetTalknum(string id)
        { 
            string val = "";
            val = DbHelperSQL.GetSingle("select count (*) from [dbo].[TK_评论表] where 发帖表id='"+id+"'").ToString();  
            return val;
        }

        protected string Getcno(string id)
        {
            string val = "";
            DataTable dt = DbHelperSQL.Query("select * from [dbo].[TK_发帖表] where id='"+id+"'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                val = dt.Rows[0]["编号"].ToString();
            }
            return val;
        }

    }
}