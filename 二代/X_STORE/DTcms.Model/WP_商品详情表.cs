 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_商品详情表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_商品详情表
	{
		public WP_商品详情表()
		{}
		#region Model
		private int _id;
		private string _商品编号;
		private string _描述;
		private string _特点;
		private string _注意事项;
		private string _资质证明;
		private string _品牌介绍;
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
		public string 商品编号
		{
			set{ _商品编号=value;}
			get{return _商品编号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 描述
		{
			set{ _描述=value;}
			get{return _描述;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 特点
		{
			set{ _特点=value;}
			get{return _特点;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 注意事项
		{
			set{ _注意事项=value;}
			get{return _注意事项;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 资质证明
		{
			set{ _资质证明=value;}
			get{return _资质证明;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 品牌介绍
		{
			set{ _品牌介绍=value;}
			get{return _品牌介绍;}
		}
		#endregion Model

	}
}

