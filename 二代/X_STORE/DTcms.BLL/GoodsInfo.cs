using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.BLL
{
   public  class GoodsInfo
    {
       DTcms.DAL.GoodsInfo dal = new DAL.GoodsInfo();
       /// <summary>
       /// 根据编号与商品类别（WP or TM），取得市场价与本站价的范围
       /// </summary>
       /// <param name="_bianhao"></param>
       /// <param name="_typename"></param>
       /// <returns>Tuple<市场价,本站价></returns>
       public Tuple<string,string> GetGoodsPrice(string _bianhao,string _typename)
       {
           return dal.GetGoodsPrice(_bianhao, _typename);
       }
       /// <summary>
       /// 取得商品已售数量
       /// </summary>
       /// <param name="_商品id"></param>
       /// <param name="_typename"></param>
       /// <returns></returns>
       public int GetSaleNum(int _商品id, string _typename)
       {
           return dal.GetSaleNum(_商品id, _typename);
 
       }
    }

}
