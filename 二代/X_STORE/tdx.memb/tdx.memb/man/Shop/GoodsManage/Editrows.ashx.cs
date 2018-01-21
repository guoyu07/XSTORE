using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creatrue.kernel;
using DTcms.Common;

namespace tdx.memb.man.Shop.GoodsManage
{
    /// <summary>
    /// Editrows 的摘要说明
    /// </summary>
    public class Editrows : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string bianhao = context.Request["bianhao"];
            string AddorEdit = context.Request["AddorEdit"];
            //string leibie = context.Request["leibie "];
            //string pinming = context.Request["pinglun"];
            //string danwei = context.Request["danwei"];
            //string kucun = context.Request["kucun"];
            //string yunfeimoban = context.Request["yunfeimoban"];
            //string Bdate = context.Request["Bdate"];
            //string Edate = context.Request["Edate"];
            //string isshow = context.Request["isshow"];
            //string fenxiaolv = context.Request["fenxiaolv"];
            ////string yunfei = context.Request["yunfei"];
            //string baoyou = context.Request["baoyou"];
            List<DTcms.Model.jsonModel> jsonlist = new List<DTcms.Model.jsonModel>();
            DTcms.Model.WP_商品表 goods = new DTcms.Model.WP_商品表();
            DTcms.BLL.WP_商品表 bll_goods = new DTcms.BLL.WP_商品表();
             string jsonstr=context.Request["jsonstr"];
             jsonlist = JSONToObject<List<DTcms.Model.jsonModel>>(jsonstr);
             Random rd = new Random();
             int flag = 0;
            string ids="";//不删除的商品id
             foreach (DTcms.Model.jsonModel m in jsonlist)
             {
                 string[] id_编号 = m.j编号new.Split('?');
                 if (id_编号[1] != "-1")
                 {
                     goods = bll_goods.GetModel(Convert.ToInt32(id_编号[1]));
                     ids+=id_编号[1]+",";
                 }
                 goods.编号 = bianhao;
                 goods.编号new = id_编号[0];
                 goods.规格 = m.j规格;
                 goods.重量 =Utils.StrToDecimal(m.j重量,0);
                 goods.市场价 = Utils.StrToDecimal(m.j市场价,0);
                 goods.本站价 = Utils.StrToDecimal(m.j本站价,0);
                 goods.库存数量 = Utils.StrToInt(m.j库存,0);
                 goods.IsShow = 1;
                 if (id_编号[1] != "-1")
                 {
                     if (bll_goods.Update(goods))
                     {
                         flag = 1;
                     }
                 }
                 else
                 {
                     ids += bll_goods.Add(goods)+",";
                     flag = 1;
                 } 
             }

             if (AddorEdit != "1")//编辑是0新增是1
             {
                 ids=ids.Substring(0,ids.Length-1);
                 Del(bianhao,ids);
             }

             if (flag > 0)
             {
                 context.Response.Write("1");
             }
             else
             {
                 context.Response.Write("0");
             }
        }

        private void Del(string cno,string ids)
        {
           int count= comfun.UpdateBySQL("update [dbo].[WP_商品表] set IsShow='0' where 编号='" + cno + "' and id not in(" + ids + ")");
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