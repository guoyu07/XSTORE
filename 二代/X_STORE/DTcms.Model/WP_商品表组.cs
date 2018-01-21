using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// WP_商品表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WP_商品表组
    {
        public int 商品Id
        {
            get { return 商品Id; }
            set { 商品Id = value; }
        }
        public int 商品组合Id {
            get{ return 商品组合Id;}
            set { 商品组合Id = value; }
        }
        public int 数量
        {
            get { return 数量; }
            set { 数量 = value; }
        }



    }
}
