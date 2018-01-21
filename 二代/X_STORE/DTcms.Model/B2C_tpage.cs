 
using System;
namespace DTcms.Model
{
	 
	[Serializable]
	public partial class B2C_tpage
	{
		public B2C_tpage()
		{}
		#region Model
		private int _id;
		private string _cno;
		private int _shopid=0;
		private string _gtitle;
		private string _gcontent;
		private string _gfile;
		private string _ggif;
		private int _g_isurl=0;
		private string _g_url;
		private string _g_title;
		private string _g_key;
		private string _g_des;
		private int _g_sort=99;
		private int _g_hits=0;
		private DateTime _regtime= DateTime.Now;
		private string _g_r1;
		private string _g_r2;
		private int _g_issys=0;
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
		public string gtitle
		{
			set{ _gtitle=value;}
			get{return _gtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gcontent
		{
			set{ _gcontent=value;}
			get{return _gcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gfile
		{
			set{ _gfile=value;}
			get{return _gfile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ggif
		{
			set{ _ggif=value;}
			get{return _ggif;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int g_isurl
		{
			set{ _g_isurl=value;}
			get{return _g_isurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string g_url
		{
			set{ _g_url=value;}
			get{return _g_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string g_title
		{
			set{ _g_title=value;}
			get{return _g_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string g_key
		{
			set{ _g_key=value;}
			get{return _g_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string g_des
		{
			set{ _g_des=value;}
			get{return _g_des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int g_sort
		{
			set{ _g_sort=value;}
			get{return _g_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int g_hits
		{
			set{ _g_hits=value;}
			get{return _g_hits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime regtime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string g_r1
		{
			set{ _g_r1=value;}
			get{return _g_r1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string g_r2
		{
			set{ _g_r2=value;}
			get{return _g_r2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int g_isSys
		{
			set{ _g_issys=value;}
			get{return _g_issys;}
		}
		#endregion Model

	}
}

