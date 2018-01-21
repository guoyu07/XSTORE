using Creatrue.kernel;
using DTcms.Common;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// changeALL 的摘要说明
    /// </summary>
    public class changeALL : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            errReg er = new errReg();
            context.Response.ContentType = "text/plain";
           // context.Response.Write("Hello World");
            string user_id = context.Session["UserId"].ObjToStr();
            user_id = "17";
            string sql_rooms = @"select B.id,b.库位名 from WP_仓库表 A
left join wp_库位表 b on b.仓库id=A.id
left join wp_箱子表 c on c.库位id=b.id
left join wp_出库表 d on d.库位id=b.id
left join wp_用户权限 E on e.仓库id=A.id
where e.用户id='" + user_id + "' and d.库位id is null and (DateDiff(dd,d.操作日期,getdate())<=30 or d.操作日期 is null ) group by  B.id,b.库位名";
            JavaScriptSerializer js = new JavaScriptSerializer();
            //Getdata()替换成你的获取数据的函数
            DataTable dt_rooms = comfun.GetDataTableBySQL(sql_rooms);
            string jsonString = js.Serialize(dt_rooms);
            er.state = 1;
            er.info = "申请已发送";
            er.guid = jsonString;
            context.Response.Write(Utils.JsonSerialize(er));

        }
        struct errReg
        {
            public int state;
            public string info;
            public string guid;
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