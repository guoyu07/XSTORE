 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// B2C_photo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class B2C_photo
	{
		public B2C_photo()
		{}
		#region Model
		private int _id;
		private string _p_tab;
		private string _p_row;
		private string _p_no;
		private string _cno;
		private string _p_name;
		private string _p_url;
		private string _p_url2;
		private string _p_des;
		private string _p_ftype;
		private string _p_fweight;
		private int _p_sort=99;
		private DateTime _p_wdate= DateTime.Now;
		private int _p_hits=0;
		private int _p_isactive=1;
		private int _p_isdel=0;
		private DateTime _regdate= DateTime.Now;
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
		public string P_tab
		{
			set{ _p_tab=value;}
			get{return _p_tab;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_row
		{
			set{ _p_row=value;}
			get{return _p_row;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_no
		{
			set{ _p_no=value;}
			get{return _p_no;}
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
		public string P_name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_url
		{
			set{ _p_url=value;}
			get{return _p_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_url2
		{
			set{ _p_url2=value;}
			get{return _p_url2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_des
		{
			set{ _p_des=value;}
			get{return _p_des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_ftype
		{
			set{ _p_ftype=value;}
			get{return _p_ftype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_fweight
		{
			set{ _p_fweight=value;}
			get{return _p_fweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int P_sort
		{
			set{ _p_sort=value;}
			get{return _p_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime P_wdate
		{
			set{ _p_wdate=value;}
			get{return _p_wdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int P_hits
		{
			set{ _p_hits=value;}
			get{return _p_hits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int P_isactive
		{
			set{ _p_isactive=value;}
			get{return _p_isactive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int P_isdel
		{
			set{ _p_isdel=value;}
			get{return _p_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime regdate
		{
			set{ _regdate=value;}
			get{return _regdate;}
		}
		#endregion Model

	}
}

