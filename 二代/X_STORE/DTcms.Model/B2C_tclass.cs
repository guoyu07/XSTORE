 
using System;
namespace DTcms.Model
{
 
	[Serializable]
	public partial class B2C_tclass
	{
		public B2C_tclass()
		{}
		#region Model
		private int _c_id;
		private string _c_no;
		private string _c_name;
		private string _c_gif;
		private string _c_url;
		private int _c_sort=99;
		private string _c_des;
		private int _c_isactive=1;
		private int _c_isdel=0;
		private DateTime _regtime= DateTime.Now;
		private int _c_parent=0;
		private int _c_level=1;
		private int _c_child=0;
		/// <summary>
		/// 
		/// </summary>
		public int c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_no
		{
			set{ _c_no=value;}
			get{return _c_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_name
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_gif
		{
			set{ _c_gif=value;}
			get{return _c_gif;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_url
		{
			set{ _c_url=value;}
			get{return _c_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int c_sort
		{
			set{ _c_sort=value;}
			get{return _c_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_des
		{
			set{ _c_des=value;}
			get{return _c_des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int c_isactive
		{
			set{ _c_isactive=value;}
			get{return _c_isactive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int c_isdel
		{
			set{ _c_isdel=value;}
			get{return _c_isdel;}
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
		public int c_parent
		{
			set{ _c_parent=value;}
			get{return _c_parent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int c_level
		{
			set{ _c_level=value;}
			get{return _c_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int c_child
		{
			set{ _c_child=value;}
			get{return _c_child;}
		}
		#endregion Model

	}
}

