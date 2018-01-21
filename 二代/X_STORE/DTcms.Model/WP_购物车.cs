/**  版本信息模板在安装目录下，可自行修改。
* WP_购物车.cs
*
* 功 能： N/A
* 类 名： WP_购物车
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016-04-13 16:41:40   N/A    初版
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
	/// WP_购物车:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_购物车
	{
		public WP_购物车()
		{}
		#region Model
		private int _id;
		private string _openid;
		private int _商品id;
		private decimal _单价=0M;
		private int _数量;
		private int _是否结算;
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
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int 商品id
		{
			set{ _商品id=value;}
			get{return _商品id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 单价
		{
			set{ _单价=value;}
			get{return _单价;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int 数量
		{
			set{ _数量=value;}
			get{return _数量;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int 是否结算
		{
			set{ _是否结算=value;}
			get{return _是否结算;}
		}
		#endregion Model

	}
}

