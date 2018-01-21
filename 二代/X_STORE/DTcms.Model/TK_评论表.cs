using System;
namespace DTcms.Model
{
    /// <summary>
    /// TK_评论表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TK_评论表
    {
        public TK_评论表()
        { }
        #region Model
        private int _id;
        private string _openid;
        private int? _发帖表id;
        private string _评论内容;
        private DateTime? _评论时间;
        private string _备注;
        private int? _是否显示 = 1;
        private int? _parentid = 0;
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
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 发帖表id
        {
            set { _发帖表id = value; }
            get { return _发帖表id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 评论内容
        {
            set { _评论内容 = value; }
            get { return _评论内容; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 评论时间
        {
            set { _评论时间 = value; }
            get { return _评论时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
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
        public int? parentid
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        #endregion Model

    }
}

