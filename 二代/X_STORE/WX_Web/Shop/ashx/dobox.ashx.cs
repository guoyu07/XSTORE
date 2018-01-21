using Creatrue.kernel;
using System.Data;
using System.Web;
using DTcms.Common.Helper;
using Znhx.Creatrue.Helper;
namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// dobox 的摘要说明
    /// </summary>
    public class dobox : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                string state = context.Request["state"].ToString();
                string boxid = context.Request["box_id"].ToString();
                string sql = @"
select 位置,箱子MAC from wp_箱子表 
left join wp_商品表  on wp_箱子表.实际商品id=wp_商品表.id
left join wp_库位表 on Wp_箱子表.库位id=wp_库位表.id
where wp_箱子表.id='" + boxid + "'";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (state == "openbox")
                {
                    //var rbh = new RemoteBoxHelperNew();
                    var rbh = new RemoteBoxHelper();
                    for (int i = 0; i < 3; i++)
                    {
                        rbh.OpenRemoteBox("" + dt.Rows[0]["箱子MAC"].ObjToStr() + "",, "" + (dt.Rows[0]["位置"].ObjToInt(0) - 1).ObjToStr() + "");
                    }
                    context.Response.Write("开箱成功");
                }
                else if (state == "emptybox")
                {
                    comfun.UpdateBySQL("update wp_箱子表 set 实际商品id=0 where id='" + boxid + "'");
                    context.Response.Write("已设为空箱");
                }
                else
                {
                    context.Response.Write("功能开发中");
                }

            }
            catch
            {

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