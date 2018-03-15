using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XStore.Entity.Model
{
    public class ShareModel
    {

        public int orderId { get; set; }
        //private string product { get; set; }// 商品名
        public int income { get; set; }// 分润
        public string cause { get; set; }// 分润理由
        public string date { get; set; }
        public int type { get; set; }
    }

}
