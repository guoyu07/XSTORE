using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_UbindN:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_UbindN
	{
		public WP_UbindN()
		{}
		#region Model
		private int _id;
		private int _userid;
		private int _newsid;
		private bool _iszan= false;
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
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsZan
		{
			set{ _iszan=value;}
			get{return _iszan;}
		}
		#endregion Model

	}
}

