 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_浏览记录表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_浏览记录表
	{
		public WP_浏览记录表()
		{}
		#region Model
		private int _id;
		private string _浏览人openid;
		private string _分享人openid;
		private string _订单编号;
		private DateTime? _浏览时间= DateTime.Now;
		private string _ip;
		private string _设备型号;
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
		public string 浏览人openid
		{
			set{ _浏览人openid=value;}
			get{return _浏览人openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 分享人openid
		{
			set{ _分享人openid=value;}
			get{return _分享人openid;}
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
		public DateTime? 浏览时间
		{
			set{ _浏览时间=value;}
			get{return _浏览时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 设备型号
		{
			set{ _设备型号=value;}
			get{return _设备型号;}
		}
		#endregion Model

	}
}

