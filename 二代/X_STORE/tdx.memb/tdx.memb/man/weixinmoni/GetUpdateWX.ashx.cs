using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
//using tdx.memb.weixinmoni;
using System.Text;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.weixinmoni
{
    /// <summary>
    /// GetUpdateWX 的摘要说明
    /// </summary>
    public class GetUpdateWX : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {


                string _r = context.Request["r"] != null ? context.Request["r"].ToString() : "";
                if (string.IsNullOrEmpty(_r))
                {
                    context.Response.Write("请选择分组再刷新");
                }
                else
                {
                    List<SingleGroup> allgroupdata = new List<SingleGroup>();
                    Dictionary<string, ListItem> dsl = (Dictionary<string, ListItem>)context.Session["weixinlistitem"];
                    weixinfun.getEachGroupInfo(_r, dsl[_r].Value, dsl[_r].Text, ref allgroupdata);
                    StringBuilder nr = new StringBuilder();
                    StringBuilder nrsql = new StringBuilder();
                    string _wid = HttpContext.Current.Session["wid"].ToString();
                    foreach (SingleGroup sin in allgroupdata)
                    {

                        for (int i = 0; i < sin.groupdata.Count; i++)
                        {

                            //nr.Append(string.Format("@fake_id={0},@nick_name={1},@remark_name={2},@group_id={3}\n", sin.groupdata[i]["id"].ToString(), sin.groupdata[i]["nick_name"].ToString(), sin.groupdata[i]["remark_name"].ToString(), sin.group_name));
                            SqlParameter[] paras = new SqlParameter[] { 
                              new SqlParameter("@fake_id", sin.groupdata[i]["id"].ToString()),
                              new SqlParameter("@nick_name", sin.groupdata[i]["nick_name"].ToString()),
                              new SqlParameter("@remark_name", sin.groupdata[i]["remark_name"].ToString()),
                              new SqlParameter("@group_name", sin.group_name),
                              new SqlParameter("@CityID",_wid)
                            };
                            string cmdstr0 = "select * from wx_userInfo where fake_id='" + sin.groupdata[i]["id"].ToString().Trim() + "' and cityID=" + _wid;
                            DataTable dt = comfun.GetDataTableBySQL(cmdstr0);
                            comfun con = new comfun();
                            if (dt.Rows.Count > 0)
                            {
                                string gengxin = "Update wx_userInfo  set nick_name =@nick_name,remark_name=@remark_name,group_name=@group_name where fake_id=@fake_id and    cityID=@cityID";
                                con.ExecuteNonQuery(gengxin, paras);
                            }
                            else
                            {
                                string cmdstr = "insert into wx_userInfo values(@fake_id,@nick_name,@remark_name,@group_name,'',@cityID,'')";
                                con.ExecuteNonQuery(cmdstr, paras);
                            }

                        }
                    }

                    context.Response.Write("更新完毕");
                }

            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message.ToString());
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