using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DTcms.DAL
{
   public  class GoodsInfo
    {
       public Tuple<string, string> GetGoodsPrice(string _bianhao, string _typename)
       {
           string sql = " select  * from    GoodsPrice where typename='" + _typename + "' and 编号='" + _bianhao + "'";
           string 市场价="",本站价="";
          DataSet ds = DbHelperSQL.Query(sql);
          if (ds != null && ds.Tables.Count > 0)
          {
              市场价 = ds.Tables[0].Rows[0]["市场价"] == null ? "" : ds.Tables[0].Rows[0]["市场价"].ToString();
              本站价 = ds.Tables[0].Rows[0]["本站价"] == null ? "" : ds.Tables[0].Rows[0]["本站价"].ToString();
          }
          return new Tuple<string, string>(市场价, 本站价);
       }
       public int GetSaleNum(int _商品id, string _typename)
       {
           string sql = "select salenum  from   SaleCount where typename ='" + _typename + "'  and  商品id=" + _商品id + "";
           object obj = DbHelperSQL.GetSingle(sql);
           if (obj != null)
               return Convert.ToInt16(obj.ToString());
           else
               return 0;
       }
    }
}
