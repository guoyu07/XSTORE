 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_返利表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_返利表
	{
		public WP_返利表()
		{}
		#region Model
		private int _id;
		private string _openid;
		private string _订单号;
		private decimal? _返利金额=0M;
		private DateTime? _返利时间= DateTime.Now;
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
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 订单号
		{
			set{ _订单号=value;}
			get{return _订单号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 返利金额
		{
			set{ _返利金额=value;}
			get{return _返利金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 返利时间
		{
			set{ _返利时间=value;}
			get{return _返利时间;}
		}
		#endregion Model

	}
}

