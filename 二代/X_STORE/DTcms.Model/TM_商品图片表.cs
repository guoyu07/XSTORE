/**  版本信息模板在安装目录下，可自行修改。
* TM_商品图片表.cs
*
* 功 能： N/A
* 类 名： TM_商品图片表
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016-04-11 19:49:24   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace DTcms.Model
{
	/// <summary>
	/// TM_商品图片表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TM_商品图片表
	{
		public TM_商品图片表()
		{}
		#region Model
		private int _id;
		private string _商品编号;
		private string _标题;
		private string _图片路径;
		private int? _序号;
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
		/// 序号值低，优先级高
		/// </summary>
		public int? 序号
		{
			set{ _序号=value;}
			get{return _序号;}
		}
		#endregion Model

	}
}

