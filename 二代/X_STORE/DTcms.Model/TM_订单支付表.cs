 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// TM_订单支付表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TM_订单支付表
	{
		public TM_订单支付表()
		{}
		#region Model
		private int _id;
		private string _订单编号;
		private string _支付方式;
		private decimal? _支付金额=0M;
		private string _openid;
		private DateTime? _支付时间= DateTime.Now;
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
		public string 支付方式
		{
			set{ _支付方式=value;}
			get{return _支付方式;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 支付金额
		{
			set{ _支付金额=value;}
			get{return _支付金额;}
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
		public DateTime? 支付时间
		{
			set{ _支付时间=value;}
			get{return _支付时间;}
		}
		#endregion Model

	}
}

