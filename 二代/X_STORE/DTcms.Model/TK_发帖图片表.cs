using System;
namespace DTcms.Model
{
	/// <summary>
	/// TK_发帖图片表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TK_发帖图片表
	{
		public TK_发帖图片表()
		{}
		#region Model
		private int _id;
		private string _编号;
		private string _标题;
		private string _图片路径;
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
		public string 编号
		{
			set{ _编号=value;}
			get{return _编号;}
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
		#endregion Model

	}
}

