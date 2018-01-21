 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_商品图片表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_商品图片表
	{
		public WP_商品图片表()
		{}
		#region Model
		private int _id;
		private string _商品编号;
		private string _标题;
		private string _图片路径;
        private int _序号;
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
		public string 标题
		{
			set{ _标题=value;}
			get{return _标题;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 图片路径
		{
			set{ _图片路径=value;}
			get{return _图片路径;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int 序号
        {
            set { _序号 = value; }
            get { return _序号; }
        }
		#endregion Model

	}
}

