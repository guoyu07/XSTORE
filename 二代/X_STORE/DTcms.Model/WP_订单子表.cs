/**  版本信息模板在安装目录下，可自行修改。
* WP_订单子表.cs
*
* 功 能： N/A
* 类 名： WP_订单子表
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016-04-13 16:41:39   N/A    初版
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
	/// WP_订单子表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_订单子表
	{
		public WP_订单子表()
		{}
		#region Model
		private int _id;
		private int? _商品id;
		private string _订单编号;
		private decimal? _价格=0M;
		private int? _数量=0;
		private string _推荐人openid;
		private string _推荐人订单号;
		private string _备注;
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
		public int? 商品id
		{
			set{ _商品id=value;}
			get{return _商品id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 订单编号
		{
			set{ _订单编号=value;}
			get{return _订单编号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 价格
		{
			set{ _价格=value;}
			get{return _价格;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 数量
		{
			set{ _数量=value;}
			get{return _数量;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 推荐人openid
		{
			set{ _推荐人openid=value;}
			get{return _推荐人openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 推荐人订单号
		{
			set{ _推荐人订单号=value;}
			get{return _推荐人订单号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 备注
		{
			set{ _备注=value;}
			get{return _备注;}
		}
		#endregion Model

	}
}

