/**  版本信息模板在安装目录下，可自行修改。
* WP_FreightMainD.cs
*
* 功 能： N/A
* 类 名： WP_FreightMainD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016-04-08 18:24:01   N/A    初版
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
	/// WP_FreightMainD:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_FreightMainD
	{
        public WP_FreightMainD()
        { }
        #region Model
        private int _id;
        private int? _mainid;
        private int? _计价方式;
        private string _name;
        private decimal? _shouzhong;
        private decimal? _shoujia;
        private decimal? _xuzhong;
        private decimal? _xujia;
        private string _areas;
        private string _运送方式;
        private DateTime? _createtime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? mainid
        {
            set { _mainid = value; }
            get { return _mainid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 计价方式
        {
            set { _计价方式 = value; }
            get { return _计价方式; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? shouzhong
        {
            set { _shouzhong = value; }
            get { return _shouzhong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? shoujia
        {
            set { _shoujia = value; }
            get { return _shoujia; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? xuzhong
        {
            set { _xuzhong = value; }
            get { return _xuzhong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? xujia
        {
            set { _xujia = value; }
            get { return _xujia; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areas
        {
            set { _areas = value; }
            get { return _areas; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 运送方式
        {
            set { _运送方式 = value; }
            get { return _运送方式; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}

