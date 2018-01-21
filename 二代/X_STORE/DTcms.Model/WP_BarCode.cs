using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    public class WP_BarCode
    {
        public WP_BarCode() { }
        #region Model
        private int _id;
        private string _barcode;
        private DateTime _createtime;
        private DateTime _bindtime;
        private int _kuweiid;
        private int _hotelid;
        private int _hasbind;
        private string _url;
        /// <summary>
        /// id
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// IMEI号
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime BindTime
        {
            set { _bindtime = value; }
            get { return _bindtime; }
        }
        /// <summary>
        /// 房间id
        /// </summary>
        public int KuWeiId
        {
            set { _kuweiid = value; }
            get { return _kuweiid; }
        }
        /// <summary>
        /// 酒店id
        /// </summary>
        public int HotelId
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 是否绑定
        /// </summary>
        public int HasBind
        {
            set { _hasbind = value; }
            get { return _hasbind; }
        }

        /// <summary>
        /// 二维码地址
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        #endregion Model
    }
}
