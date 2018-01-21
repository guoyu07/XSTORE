using System;
namespace DTcms.Model
{
    /// <summary>
    /// TK_发帖表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TK_发帖表
    {
        public TK_发帖表()
        { }
        #region Model
        private int _id;
        private string _编号;
        private string _类别号;
        private string _名称;
        private string _内容;
        private DateTime? _创建时间 = DateTime.Now;
        private string _openid;
        private int? _是否显示 = 1;
        private int? _是否置顶 = 0;
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
        public string 编号
        {
            set { _编号 = value; }
            get { return _编号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 类别号
        {
            set { _类别号 = value; }
            get { return _类别号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 名称
        {
            set { _名称 = value; }
            get { return _名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 内容
        {
            set { _内容 = value; }
            get { return _内容; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 创建时间
        {
            set { _创建时间 = value; }
            get { return _创建时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 是否显示
        {
            set { _是否显示 = value; }
            get { return _是否显示; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 是否置顶
        {
            set { _是否置顶 = value; }
            get { return _是否置顶; }
        }
        #endregion Model

    }
}

