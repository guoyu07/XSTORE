using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace tdx.memb.man.HotelWarehouse
{
    /// <summary>
    /// AreaCode 的摘要说明
    /// </summary>
    public class AreaCode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string test = context.Request["qh"].ObjToStr();
            string ss = "";
            if(test!=""){
                string sql = @"select id from WP_地区表 where 是否删除=0 and 区号='"+test+"'";
                DataTable dt = new comfun().GetDataTable(sql);
                if(dt.Rows.Count>0){
                    ss = "区号已存在!";
                }
            }
            //return ss;
            var result_str = Newtonsoft.Json.JsonConvert.SerializeObject(new { state = 0, info = ss });
            context.Response.Write(result_str);
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