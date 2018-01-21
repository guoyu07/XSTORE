 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_用户表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_用户表
	{
		public WP_用户表()
		{}
		#region Model
		private int _id;
		private string _用户名;
		private string _密码;
		private string _openid;
		private string _手机号;
		private string _微信昵称;
		private string _微信头像;
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
		public string 用户名
		{
			set{ _用户名=value;}
			get{return _用户名;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 密码
		{
			set{ _密码=value;}
			get{return _密码;}
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
		public string 手机号
		{
			set{ _手机号=value;}
			get{return _手机号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 微信昵称
		{
			set{ _微信昵称=value;}
			get{return _微信昵称;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 微信头像
		{
			set{ _微信头像=value;}
			get{return _微信头像;}
		}
		#endregion Model

	}
}

