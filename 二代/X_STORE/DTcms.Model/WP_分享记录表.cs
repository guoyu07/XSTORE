 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_分享记录表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_分享记录表
	{
		public WP_分享记录表()
		{}
		#region Model
		private int _id;
		private string _分享人openid;
		private string _订单编号;
		private DateTime? _分享时间= DateTime.Now;
		private int? _浏览次数=0;
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
		public DateTime? 分享时间
		{
			set{ _分享时间=value;}
			get{return _分享时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 浏览次数
		{
			set{ _浏览次数=value;}
			get{return _浏览次数;}
		}
		#endregion Model

	}
}

