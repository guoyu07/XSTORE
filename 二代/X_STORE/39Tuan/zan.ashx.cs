using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Wx_NewWeb.Message
{
    /// <summary>
    /// zan 的摘要说明
    /// </summary>
    public class zan : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int nid = int.Parse(string.IsNullOrEmpty(context.Request["nid"]) ? "" : context.Request["nid"]);

            string iszan = string.IsNullOrEmpty(context.Request["iszan"]) ? "" : context.Request["iszan"];

            int uid = int.Parse(string.IsNullOrEmpty(context.Request["uid"]) ? "" : context.Request["uid"]);

            context.Response.Write(ubindn(nid, iszan, uid));

        }


        public string ubindn(int nid, string iszan, int uid)
        {
            string iss = String.Empty;

            DTcms.BLL.WP_UbindN ubindnbll = new DTcms.BLL.WP_UbindN();

            DTcms.Model.WP_UbindN ubindnmodel = new DTcms.Model.WP_UbindN();

            //判断存不存在
            DataTable dt = ubindnbll.GetList("  UserID=" + uid + "  and  NewsID=" + nid).Tables[0];
            
            if (dt.Rows.Count > 0)//存在更新
            {
                if (iszan == "True")//iszan=True 更新为False
                {
                    ubindnmodel.id = int.Parse(dt.Rows[0]["id"].ToString());
                    ubindnmodel.IsZan = false;
                    ubindnmodel.NewsID = nid;
                    ubindnmodel.UserID = uid;

                    bool b = ubindnbll.Update(ubindnmodel);
                    if (b)
                    {
                        iss = "False";
                    }

                }
                else //iszan=False  更新为True
                {
                    ubindnmodel.id = int.Parse(dt.Rows[0]["id"].ToString());
                    ubindnmodel.IsZan = true;
                    ubindnmodel.NewsID = nid;
                    ubindnmodel.UserID = uid;

                    bool b = ubindnbll.Update(ubindnmodel);
                    if (b)
                    {
                        iss = "True";
                    }
                }
            }
            else //不存在添加
            {
                ubindnmodel.IsZan = true;
                ubindnmodel.NewsID = nid;
                ubindnmodel.UserID = uid;

                int i = ubindnbll.Add(ubindnmodel);
                if (i>0)
                { 
                    iss = "True";
                }
            }


            return iss;
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