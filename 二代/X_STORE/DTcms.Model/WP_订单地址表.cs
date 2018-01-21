 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_订单地址表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_订单地址表
	{
		public WP_订单地址表()
		{}
		#region Model
		private int _id;
		private string _订单编号;
		private string _省;
		private string _市;
		private string _区;
		private string _商圈;
		private string _详细地址;
		private string _手机号;
		private string _收货人;
		private string _备注;
        private int _是否为默认地址;
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
		public string 订单编号
		{
			set{ _订单编号=value;}
			get{return _订单编号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 省
		{
			set{ _省=value;}
			get{return _省;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 市
		{
			set{ _市=value;}
			get{return _市;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 区
		{
			set{ _区=value;}
			get{return _区;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 商圈
		{
			set{ _商圈=value;}
			get{return _商圈;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 详细地址
		{
			set{ _详细地址=value;}
			get{return _详细地址;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 手机号
		{
			set{ _手机号=value;}
			get{return _手机号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 收货人
		{
			set{ _收货人=value;}
			get{return _收货人;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 备注
		{
			set{ _备注=value;}
			get{return _备注;}
		}
		#endregion Model
        public int 是否为默认地址
        {
            set { _是否为默认地址 = value; }
            get { return _是否为默认地址; }
        }

        //是否删除
        public int is_del { set; get; }
	}
}

