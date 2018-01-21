using System;
using System.Collections.Generic;

using System.Text;

namespace DTcms.Model
{
    public class advert
    {
        public advert()
        { }

        public int id { set; get; }
        public string code { set; get; }
        public string name { set; get; }
        public string array { set; get; }
        public int types { set; get; }
        public string 类别号 { set; get; }
    }
    [Serializable]
    public class advert_pic:IComparable<advert_pic>
    {
        public string url { set; get; }
        public string pic { set; get; }
        public int ordernum { set; get; }
        public int CompareTo(advert_pic other)
        {
            if (other == null)
                return 1;
            int value = this.ordernum - other.ordernum;
            if (value == 0)
                value = this.ordernum - other.ordernum;
            return value;
        }
    }
}
