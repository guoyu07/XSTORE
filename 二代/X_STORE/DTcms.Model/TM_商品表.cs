/**  版本信息模板在安装目录下，可自行修改。
* TM_商品表.cs
*
* 功 能： N/A
* 类 名： TM_商品表
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016-04-18 14:51:25   N/A    初版
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
	/// TM_商品表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TM_商品表
	{
		public TM_商品表()
		{}
		#region Model
		private int _id;
		private int? _用户id=0;
		private string _编号;
		private string _编号new;
		private string _类别号;
		private string _品名;
		private string _规格;
		private string _单位;
		private decimal? _重量=0M;
		private int? _序号=99;
		private decimal? _市场价=0M;
		private decimal? _本站价=0M;
		private decimal? _三团价=0M;
		private decimal? _九团价=0M;
		private DateTime? _上架时间= DateTime.Now;
		private DateTime? _下架时间= DateTime.Now;
		private DateTime? _录入时间= DateTime.Now;
		private int? _库存数量=0;
		private int? _限购数量;
		private decimal? _分销率;
		private int? _isshow;
		private int? _是否上架;
		private int _类型=2;
		private int _critical_value=0;
		private int _istuan=0;
		private decimal _折扣率=0M;
		private int _是否卖家承担运费=0;
		private decimal _满多少包邮=0M;
		private int? _运费模板;
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
		public int? 用户ID
		{
			set{ _用户id=value;}
			get{return _用户id;}
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
		public string 编号new
		{
			set{ _编号new=value;}
			get{return _编号new;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 类别号
		{
			set{ _类别号=value;}
			get{return _类别号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 品名
		{
			set{ _品名=value;}
			get{return _品名;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 规格
		{
			set{ _规格=value;}
			get{return _规格;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 单位
		{
			set{ _单位=value;}
			get{return _单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 重量
		{
			set{ _重量=value;}
			get{return _重量;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 序号
		{
			set{ _序号=value;}
			get{return _序号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 市场价
		{
			set{ _市场价=value;}
			get{return _市场价;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 本站价
		{
			set{ _本站价=value;}
			get{return _本站价;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 三团价
		{
			set{ _三团价=value;}
			get{return _三团价;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 九团价
		{
			set{ _九团价=value;}
			get{return _九团价;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 上架时间
		{
			set{ _上架时间=value;}
			get{return _上架时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 下架时间
		{
			set{ _下架时间=value;}
			get{return _下架时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 录入时间
		{
			set{ _录入时间=value;}
			get{return _录入时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 库存数量
		{
			set{ _库存数量=value;}
			get{return _库存数量;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 限购数量
		{
			set{ _限购数量=value;}
			get{return _限购数量;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 分销率
		{
			set{ _分销率=value;}
			get{return _分销率;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 是否上架
		{
			set{ _是否上架=value;}
			get{return _是否上架;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int 类型
		{
			set{ _类型=value;}
			get{return _类型;}
		}
		/// <summary>
		/// 临界值(当数量大于等于这个值时使用批发价)
		/// </summary>
		public int critical_value
		{
			set{ _critical_value=value;}
			get{return _critical_value;}
		}
		/// <summary>
		/// 0-团购；1-秒杀
		/// </summary>
		public int isTuan
		{
			set{ _istuan=value;}
			get{return _istuan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 折扣率
		{
			set{ _折扣率=value;}
			get{return _折扣率;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int 是否卖家承担运费
		{
			set{ _是否卖家承担运费=value;}
			get{return _是否卖家承担运费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 满多少包邮
		{
			set{ _满多少包邮=value;}
			get{return _满多少包邮;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 运费模板
		{
			set{ _运费模板=value;}
			get{return _运费模板;}
		}
		#endregion Model

	}
}

