using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Creatrue.kernel;
using System.Data;
using System.Text;

namespace tdx.tp
{
    /// <summary>
    /// vote 的摘要说明
    /// </summary>
    public class vote : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = string.IsNullOrEmpty(context.Request["t"]) ? "" : context.Request["t"].ToString();
            switch (type)
            {
                case "vote":
                    addVote(context);
                    break;
                case "page":
                    page(context);
                    break;
                default:
                    break;
            }
            //context.Response.Write("Hello World");
        }
        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="context"></param>
        private void addVote(HttpContext context)
        {
            int vid = string.IsNullOrEmpty(context.Request["vid"]) ? 0 : Convert.ToInt32(context.Request["vid"].ToString());
            if (vid != 0)
            {
                if (HttpContext.Current.Session["wwv"] != null && HttpContext.Current.Session["wID"] != null)
                {
                    string _wwv = HttpContext.Current.Session["wwv"].ToString();
                    int _cityID = Convert.ToInt32(HttpContext.Current.Session["wID"].ToString());
                    string _ip = HttpContext.Current.Request.ServerVariables["Remote_addr"].ToString();

                    string sql = @"select bigpic_id from vote_Album where id=" + vid;
                    DataTable dt_ID = comfun.GetDataTableBySQL(sql);
                    if (dt_ID.Rows.Count > 0)
                    {
                        int _bigpic_id = Convert.ToInt32(dt_ID.Rows[0]["bigpic_id"]);
                        string insertSql = @"insert into vote_log (Album_id,vote_wwv,vote_ip,bigpic_id) values(" + vid + ",'" + _wwv + "','" + _ip + "'," + _bigpic_id + ")";
                        if (Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from vote_log where bigpic_id="+_bigpic_id+" and vote_wwv='" + _wwv + "'").Rows[0][0]) == 0)
                        {
                            comfun.InsertBySQL(insertSql);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="context"></param>
        private void page(HttpContext context)
        {

            int _id = Convert.ToInt32(context.Request["vid"]);
            string firstSql = @"select tb1.id,tb2.total,tb1.Album_name,tb1.Album_pic,tb1.Album_desc from(select id,[vote_Album].[Album_name], [vote_Album].[Album_pic], [vote_Album].[Album_desc]
from [vote_Album] where [vote_Album].[bigpic_id]=" + _id + ")as tb1 left join (select Album_id,count(*) as total from [vote_log] group by Album_id,bigpic_id having bigpic_id=" + _id + ") as tb2 on tb1.id=tb2.Album_id ";

            int _page = (context.Request["p"] != null ? Convert.ToInt32(context.Request["p"]) : 1);
            int pagesize = 5;
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from (" + firstSql + ") as tb").Rows[0][0]);
            int pageCount = 0;
            if (totalcount % pagesize == 0)
            {
                pageCount = totalcount / pagesize;
            }
            else
            {
                pageCount = totalcount / pagesize + 1;
            }
            if (pageCount > 1)
            {
                if (_page <= pageCount)
                {
                    string sql = @"with c as (select * from (" + firstSql + ") as tb ) select top " + pagesize * _page + " * from c order by total desc,id desc";//where rown > " + ((_page - 1) * pagesize).ToString() + " order by rown ";
                    DataTable dt = comfun.GetDataTableBySQL(sql);
                    StringBuilder htmlStr = new StringBuilder();
                    string Class = "cant";
                    if (Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from vote_log where bigpic_id="+_id+" and vote_wwv='" + context.Request["wwv"] + "'").Rows[0][0]) == 0)
                    {
                        Class = "";
                    }

                    var result = (from a in dt.AsEnumerable() select a).Skip((_page - 1) * pagesize);
                    foreach (var item in result)
                    {
                        int total = string.IsNullOrEmpty(item["total"].ToString()) ? 0 : Convert.ToInt32(item["total"]);
                        string id = item.Field<int>("id").ToString();
                        string Album_pic = item.Field<string>("Album_pic");
                        string Album_name = item.Field<string>("Album_name");
                        string Album_desc = item.Field<string>("Album_desc");

                        htmlStr.Append("<dl votenum='" + total + "' vid=" + id + ">");
                        htmlStr.Append("<dt><img src=" + Album_pic + " /><i>1</i></dt>");
                        htmlStr.Append("<dd><h1>" + Album_name + "</h1>");
                        htmlStr.Append("<h2>" + Album_desc + "</h2>");
                        htmlStr.Append("<p><i class='vote_index_barBg'><em class='vote_index_bar'></em></i><a href='javascript:void(0)' class=" + Class + ">投票</a></p> </dd></dl>");
                    }
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    htmlStr.Append("<dl votenum='" + dr["total"] + "' vid=" + dr["id"] + ">");
                    //    htmlStr.Append("<dt><img src=" + dr["Album_pic"] + " /><i>1</i></dt>");
                    //    htmlStr.Append("<dd><h1>" + dr["Album_name"] + "</h1>");
                    //    htmlStr.Append("<h2>" + dr["Album_desc"] + "</h2>");
                    //    htmlStr.Append("<p><i class='vote_index_barBg'><em class='vote_index_bar'></em></i><a href='javascript:void(0)' class="+Class+">投票</a></p> </dd></dl>");
                    //}
                    context.Response.Write(htmlStr.ToString());
                }
                else
                {
                    context.Response.Write("<div style='text-align:center; padding:8px;' id='isOver'>下面已经没有了<div>");
                }
            }
            else
            {
                context.Response.Write("<div style='text-align:center; padding:8px;' id='isOver'>下面已经没有了<div>");
            }

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}