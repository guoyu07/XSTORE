using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_PingLun:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_PingLun
	{
		public WP_PingLun()
		{}
		#region Model
		private int _id;
		private int _userid;
		private int _newsid;
		private string _pcontent;
		private DateTime _pcreatedate;
		private string _remark;
		private bool _isview= false;
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
		public string PContent
		{
			set{ _pcontent=value;}
			get{return _pcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime PCreateDate
		{
			set{ _pcreatedate=value;}
			get{return _pcreatedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReMark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsView
		{
			set{ _isview=value;}
			get{return _isview;}
		}
		#endregion Model

	}
}

