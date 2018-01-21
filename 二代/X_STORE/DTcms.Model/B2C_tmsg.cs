 
using System;
namespace DTcms.Model
{
	 
	[Serializable]
	public partial class B2C_tmsg
	{
		public B2C_tmsg()
		{}
		#region Model
		private int _id;
		private string _cno;
		private int _shopid=0;
		private string _t_title;
		private string _t_author;
		private string _t_source;
		private string _t_gif;
		private string _t_msg;
		private int _t_isurl=0;
		private string _t_url;
		private string _t_filename;
		private int _t_sort=99;
		private int _t_iflag=0;
		private int _t_cflag=0;
		private int _t_hits=0;
		private DateTime _t_wdate= DateTime.Now;
		private DateTime _regdate= DateTime.Now;
		private int _t_isactive=1;
		private int _t_isdel=0;
		private int _t_ishead=0;
		private int _t_ischead=0;
		private string _t_key;
		private string _t_des;
		private int _t_isf=0;
		private string _app_id;
		private string _file_id;
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
		public string cno
		{
			set{ _cno=value;}
			get{return _cno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_title
		{
			set{ _t_title=value;}
			get{return _t_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_author
		{
			set{ _t_author=value;}
			get{return _t_author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_source
		{
			set{ _t_source=value;}
			get{return _t_source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_gif
		{
			set{ _t_gif=value;}
			get{return _t_gif;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_msg
		{
			set{ _t_msg=value;}
			get{return _t_msg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_isurl
		{
			set{ _t_isurl=value;}
			get{return _t_isurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_url
		{
			set{ _t_url=value;}
			get{return _t_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_filename
		{
			set{ _t_filename=value;}
			get{return _t_filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_sort
		{
			set{ _t_sort=value;}
			get{return _t_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_iflag
		{
			set{ _t_iflag=value;}
			get{return _t_iflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_cflag
		{
			set{ _t_cflag=value;}
			get{return _t_cflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_hits
		{
			set{ _t_hits=value;}
			get{return _t_hits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime t_wdate
		{
			set{ _t_wdate=value;}
			get{return _t_wdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime regdate
		{
			set{ _regdate=value;}
			get{return _regdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_isactive
		{
			set{ _t_isactive=value;}
			get{return _t_isactive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_isdel
		{
			set{ _t_isdel=value;}
			get{return _t_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_isHead
		{
			set{ _t_ishead=value;}
			get{return _t_ishead;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_ischead
		{
			set{ _t_ischead=value;}
			get{return _t_ischead;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_key
		{
			set{ _t_key=value;}
			get{return _t_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string t_des
		{
			set{ _t_des=value;}
			get{return _t_des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int t_isF
		{
			set{ _t_isf=value;}
			get{return _t_isf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string app_id
		{
			set{ _app_id=value;}
			get{return _app_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string file_id
		{
			set{ _file_id=value;}
			get{return _file_id;}
		}
		#endregion Model

	}
}

