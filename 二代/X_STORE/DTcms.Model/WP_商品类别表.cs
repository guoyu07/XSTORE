 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_商品类别表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_商品类别表
	{
		public WP_商品类别表()
		{}
		#region Model
		private int _id;
		private string _类别名;
		private string _类别编号;
        private string _图片;
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
		public string 类别名
		{
			set{ _类别名=value;}
			get{return _类别名;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 类别编号
		{
			set{ _类别编号=value;}
			get{return _类别编号;}
		}

        public string 图片
        {
            set { _图片 = value; }
            get { return _图片; }
        }
		#endregion Model

	}
}

