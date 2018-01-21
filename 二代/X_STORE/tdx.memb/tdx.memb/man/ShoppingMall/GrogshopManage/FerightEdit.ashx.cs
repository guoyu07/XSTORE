using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdx.memb.man.ShoppingMall.FreightManage
{
    /// <summary>
    /// FerightEdit 的摘要说明
    /// </summary>
    public class FerightEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string A模板名称=context.Request["A模板名称"];
            string A计价方式 = context.Request["A计价方式"];
            string A运送方式 = context.Request["A运送方式"];
            //string A默认重量 = context.Request["A默认重量"];
            //string A默认元 = context.Request["A默认元"];
            //string A增重 = context.Request["A增重"];
            //string A增元 = context.Request["A增元"];
            string jsonstr = context.Request["jsonstr"];
            DTcms.Model.WP_FreightMain freightmain = new DTcms.Model.WP_FreightMain();
            DTcms.BLL.WP_FreightMain bll_freightmain = new DTcms.BLL.WP_FreightMain();
            DTcms.BLL.WP_FreightMainD bll_freightmainD = new DTcms.BLL.WP_FreightMainD();
            DTcms.Model.WP_FreightMainD freightmainD = new DTcms.Model.WP_FreightMainD();
            List<DTcms.Model.ferightMoedl> jsonlist = new List<DTcms.Model.ferightMoedl>();
            jsonlist = JSONToObject<List<DTcms.Model.ferightMoedl>>(jsonstr);
            freightmain.name = A模板名称;
            int insertid=bll_freightmain.Add(freightmain);//主表
            foreach (DTcms.Model.ferightMoedl m in jsonlist)
            {
               freightmainD.mainid = insertid;
               freightmainD.name = A模板名称;
               freightmainD.计价方式 = Convert.ToInt32(A计价方式);
               freightmainD.shouzhong = Convert.ToDecimal(m.j首重);
               freightmainD.shoujia= Convert.ToDecimal(m.j首费);
               freightmainD.xuzhong = Convert.ToDecimal(m.j续重);
               freightmainD.xujia = Convert.ToDecimal(m.j续费);
               freightmainD.运送方式 = m.j运送方式;
               freightmainD.areas = m.j地区;
               if (!string.IsNullOrEmpty(m.j地区))
               {
                   bll_freightmainD.Add(freightmainD);
               }
            }

            context.Response.Write("1");
        }


        public static T JSONToObject<T>(string jsonText)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                return jss.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.JSONToObject(): " + ex.Message);
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