 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_酒店表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_酒店表
	{
		public WP_酒店表()
		{}
		#region Model
		private int _id;
		private string _酒店全称;
		private string _酒店简称;
        private string _Logo;
        private int _区域id;
        private string _地址;
        private string _电话;
        private int _总数;
        private decimal _总额;
        private int _区域管理id;
        private int _酒店管理id;
        private Boolean _是否活跃;
        private Boolean _是否删除;
        private int _删除人id;
        private DateTime _删除时间;
        private DateTime _最后修改时间;
        private int _最后修改人id;
        private DateTime _创建时间;
        private int _创建人id;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 酒店全称
		{
			set{ _酒店全称=value;}
			get{return _酒店全称;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 酒店简称
		{
			set{ _酒店简称=value;}
			get{return _酒店简称;}
		}

        public string Logo
        {
            set { _Logo = value; }
            get { return _Logo; }
        }
        public int 区域id
        {
            set { _区域id =value;}
            get { return _区域id; }
        }
        public string 地址
        {
            set { _地址 = value; }
            get { return _地址; }
        }
        public string 电话
        {
            set { _电话 = value; }
            get { return _电话; }
        }
        public int 总数
        {
            set { _总数 = value; }
            get { return _总数; }
        }
        public decimal 总额
        {
            set { _总额 = value; }
            get { return _总额; }
        }

        public int 区域管理id
        {
            set { _区域管理id = value; }
            get { return _区域管理id; }
        }
        public int 酒店管理id
        {
            set { _酒店管理id = value; }
            get { return _酒店管理id; }
        }
        public Boolean 是否活跃
        {
            set { _是否活跃 = value; }
            get { return _是否活跃; }
        }
        public Boolean 是否删除
        {
            set { _是否删除 = value; }
            get { return _是否删除; }
        }
        public int 删除人id
        {
            set { _删除人id = value; }
            get { return _删除人id; }
        }
        public DateTime 删除时间
        {
            set { _删除时间 = value; }
            get { return _删除时间; }
        }
        public DateTime 最后修改时间
        {
            set { _最后修改时间 = value; }
            get { return _最后修改时间; }
        }
        public int 最后修改人id
        {
            set { _最后修改人id = value; }
            get { return _最后修改人id; }
        }
        public DateTime 创建时间
        {
            set { _创建时间 = value; }
            get { return _创建时间; }
        }
            public int 创建人id
        {
            set { _创建人id =value;}
            get { return _创建人id; }
        }


		#endregion Model

	}
}

