 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_订单表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_订单表
	{
		public WP_订单表()
		{}
		#region Model
		private int _id;
		private string _商品编号;
		private string _订单编号;
		private string _openid;
		private decimal? _价格=0M;
		private int? _数量=0;
		private decimal? _金额=0M;
		private DateTime? _下单时间= DateTime.Now;
		private string _推荐人openid;
		private string _推荐人订单号;
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
		public string 商品编号
		{
			set{ _商品编号=value;}
			get{return _商品编号;}
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
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 价格
		{
			set{ _价格=value;}
			get{return _价格;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 数量
		{
			set{ _数量=value;}
			get{return _数量;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 金额
		{
			set{ _金额=value;}
			get{return _金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 下单时间
		{
			set{ _下单时间=value;}
			get{return _下单时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 推荐人openid
		{
			set{ _推荐人openid=value;}
			get{return _推荐人openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 推荐人订单号
		{
			set{ _推荐人订单号=value;}
			get{return _推荐人订单号;}
		}
		#endregion Model

	}
}

