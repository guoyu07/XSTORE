using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdx.memb.man.Shop.FreightManage
{
    /// <summary>
    /// FerightEdit2 的摘要说明
    /// </summary>
    public class FerightEdit2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string A模板名称 = context.Request["A模板名称"];
            string A计价方式 = context.Request["A计价方式"];
            string A运送方式 = context.Request["A运送方式"];
            string jsonstr = context.Request["jsonstr"];
            DTcms.Model.WP_FreightMain freightmain = new DTcms.Model.WP_FreightMain();
            DTcms.BLL.WP_FreightMain bll_freightmain = new DTcms.BLL.WP_FreightMain();
            DTcms.BLL.WP_FreightMainD bll_freightmainD = new DTcms.BLL.WP_FreightMainD();
            DTcms.Model.WP_FreightMainD freightmainD = new DTcms.Model.WP_FreightMainD();
            List<DTcms.Model.ferightMoedl> jsonlist = new List<DTcms.Model.ferightMoedl>();
            jsonlist = JSONToObject<List<DTcms.Model.ferightMoedl>>(jsonstr);

            string[] Arryid = jsonlist[0].j地区.Split('?');//获取主键id
            string id = Arryid[1].ToString();//主键id 
           // freightmain.name = A模板名称;
           // int insertid = bll_freightmain.Add(freightmain);//主表
            string delid = "";
            foreach (DTcms.Model.ferightMoedl m in jsonlist)
            {
                string[] arry = m.j地区.Split('?');
              
                if (arry[1].ToString() == "-1")
                {
                    freightmainD.mainid = bll_freightmainD.GetModel(Convert.ToInt32(id)).mainid;//
                }
                else
                {
                    freightmainD = bll_freightmainD.GetModel(Convert.ToInt32(arry[1]));//id
                    delid += arry[1] + ",";
                }
              //  freightmainD.mainid = insertid;
                freightmainD.name = A模板名称;
                freightmainD.计价方式 = Convert.ToInt32(A计价方式);
                freightmainD.shouzhong = Convert.ToDecimal(m.j首重);
                freightmainD.shoujia = Convert.ToDecimal(m.j首费);
                freightmainD.xuzhong = Convert.ToDecimal(m.j续重);
                freightmainD.xujia = Convert.ToDecimal(m.j续费);
                freightmainD.运送方式 = m.j运送方式;
                freightmainD.areas = arry[0].ToString();//地区
                if (arry[1].ToString() != "-1")
                {
                    bll_freightmainD.Update(freightmainD);
                }
                else
                {
                   delid+= bll_freightmainD.Add(freightmainD)+",";
                }
            }
            delid = delid.Substring(0, delid.Length - 1);
            Del(delid,id);
            context.Response.Write("1");
        }



        private void Del(string delid,string id)
        {
            DTcms.BLL.WP_FreightMainD bll_freightmainD = new DTcms.BLL.WP_FreightMainD();
            string mainid = bll_freightmainD.GetModel(Convert.ToInt32(id)).mainid.ToString();
            int flag = comfun.DelbySQL("delete from [WP_FreightMainD] where mainid='" + mainid + "' and id not in(" + delid + ")");
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