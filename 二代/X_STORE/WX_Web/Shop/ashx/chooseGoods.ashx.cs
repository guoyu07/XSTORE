using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;

namespace Wx_NewWeb.Shop.ashx
{
    /// <summary>
    /// chooseGoods 的摘要说明
    /// </summary>
    public class chooseGoods : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            errReg er = new errReg();
            try
            {

                int box_id = Utils.ObjToInt(context.Request["box_id"], 0);
                int old_GoodsId = Utils.ObjToInt(context.Request["old_GoodsId"], 0);
                int new_GoodsId = Utils.ObjToInt(context.Request["new_GoodsId"], 0);
                int user_id = Utils.ObjToInt(context.Request["user_id"], 0);
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                string sql_apply = @"select 品名 as text, id as value from wp_商品表 where isshow=1";
                DataTable dt_apply = comfun.GetDataTableBySQL(sql_apply);
                foreach (DataRow dr in dt_apply.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    foreach (DataColumn dc in dt_apply.Columns)
                    {
                        result.Add(dc.ColumnName, dr[dc].ToString());
                    }
                    list.Add(result);
                }
                er.state = 1;
                er.info = "请求成功";
                er.data = list;
                context.Response.Write(Utils.JsonSerialize(er));

            }
            catch (Exception ex)
            {
                er.state = 0;
                er.info = "请求失败";
                //   er.data = list;
                context.Response.Write(Utils.JsonSerialize(er));
            }
        }

        struct errReg
        {
            public int state;
            public string info;
            public List<Dictionary<string, object>> data;
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