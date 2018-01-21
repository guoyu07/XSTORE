 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_NewsInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_NewsInfo
	{
		public WP_NewsInfo()
		{}
		#region Model
		private int _id;
		private string _title;
		private DateTime _createdate= DateTime.Now;
		private string _newscontent;
		private int _writerid;
		private bool _isview= false;
		private bool _isliu;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int WriterID
		{
			set{ _writerid=value;}
			get{return _writerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsView
		{
			set{ _isview=value;}
			get{return _isview;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsLiu
		{
			set{ _isliu=value;}
			get{return _isliu;}
		}
		#endregion Model

	}
}

