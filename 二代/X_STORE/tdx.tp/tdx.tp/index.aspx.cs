using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using Creatrue.kernel;
using Creatrue.Common;
using tdx.database;
using tdx.Weixin;
using System.Data;
using System.Text;

namespace tdx.tp
{
    public partial class index : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request["wwv"]==null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(),"Startup","<script type='text/javascript'>alert('请先关注此公众号再进行投票！');</script>");
                }
                if (Request["id"] != null && Request["wwv"] != null && Request["wwx"] != null)
                {
                    int _id = Convert.ToInt32(Request["id"]);

                    DataTable dtbigpic = comfun.GetDataTableBySQL("select picurl from vote_bigpic where isactive=1 and id=" + _id);
                    if (dtbigpic.Rows.Count > 0)
                    {
                        bigpic.ImageUrl = dtbigpic.Rows[0]["picurl"].ToString();

                        string sql = @"select top 5 tb1.id,tb2.total,tb1.Album_name,tb1.Album_pic,tb1.Album_desc
from(select id,[vote_Album].[Album_name],
       [vote_Album].[Album_pic],
       [vote_Album].[Album_desc]
from [vote_Album] where [vote_Album].[bigpic_id]=" + _id + ")as tb1 left join (select Album_id,count(*) as total from [vote_log] group by Album_id,bigpic_id having bigpic_id=" + _id + ") as tb2 on tb1.id=tb2.Album_id order by tb2.total desc,tb1.id desc";
                        DataTable dtInfo = comfun.GetDataTableBySQL(sql);
                        DataTable dtnum = comfun.GetDataTableBySQL("select count(*) from vote_log where bigpic_id=" + _id);
                        int num = 0;
                        if (dtnum.Rows.Count > 0)
                        {
                            num = Convert.ToInt32(dtnum.Rows[0][0]);
                        }

                        StringBuilder htmlStr = new StringBuilder();
                        string Class = "cant";
                        if (Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from vote_log where bigpic_id="+_id+" and vote_wwv='" + Request["wwv"] + "'").Rows[0][0]) == 0)
                        {
                            Class = "";
                        }
                        if (dtInfo.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtInfo.Rows)
                            {
                                htmlStr.Append("<dl votenum='" + dr["total"] + "' vid=" + dr["id"] + ">");
                                htmlStr.Append("<dt><img src=" + dr["Album_pic"] + " /><i>1</i></dt>");
                                htmlStr.Append("<dd><h1>" + dr["Album_name"] + "</h1>");
                                htmlStr.Append("<h2>" + dr["Album_desc"] + "</h2>");
                                htmlStr.Append("<p><i class='vote_index_barBg'><em class='vote_index_bar'></em></i><a href='javascript:void(0)' class=" + Class + ">投票</a></p> </dd></dl>");
                            }
                            ListInfo.Text = "<div class='vote_index_list' votesum='" + num + "' page='1'>" + htmlStr.ToString() + "</div>";
                        }
                    }
                }
            }
        }
    }
}