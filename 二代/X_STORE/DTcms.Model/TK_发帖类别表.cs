using System;
namespace DTcms.Model
{
    /// <summary>
    /// TK_��������:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public partial class TK_��������
    {
        public TK_��������()
        { }
        #region Model
        private int _id;
        private string _�����;
        private string _�����;
        private string _ͼƬ;
        private string _c_url;
        private int? _c_sort = 99;
        private string _c_des;
        private int? _c_isactive = 1;
        private int? _c_isdel = 0;
        private DateTime? _regtime;
        private int? _c_parent = 0;
        private int? _c_level = 1;
        private int? _c_child = 0;
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
        public string �����
        {
            set { _����� = value; }
            get { return _�����; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string �����
        {
            set { _����� = value; }
            get { return _�����; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ͼƬ
        {
            set { _ͼƬ = value; }
            get { return _ͼƬ; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string c_url
        {
            set { _c_url = value; }
            get { return _c_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? c_sort
        {
            set { _c_sort = value; }
            get { return _c_sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string c_des
        {
            set { _c_des = value; }
            get { return _c_des; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? c_isactive
        {
            set { _c_isactive = value; }
            get { return _c_isactive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? c_isdel
        {
            set { _c_isdel = value; }
            get { return _c_isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? regtime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? c_parent
        {
            set { _c_parent = value; }
            get { return _c_parent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? c_level
        {
            set { _c_level = value; }
            get { return _c_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? c_child
        {
            set { _c_child = value; }
            get { return _c_child; }
        }
        #endregion Model

    }
}

