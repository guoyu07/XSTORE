using System;
namespace DTcms.Model
{
    /// <summary>
    /// TK_������:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public partial class TK_������
    {
        public TK_������()
        { }
        #region Model
        private int _id;
        private string _���;
        private string _����;
        private string _����;
        private string _����;
        private DateTime? _����ʱ�� = DateTime.Now;
        private string _openid;
        private int? _�Ƿ���ʾ = 1;
        private int? _�Ƿ��ö� = 0;
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
        public string ���
        {
            set { _��� = value; }
            get { return _���; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ����
        {
            set { _���� = value; }
            get { return _����; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ����
        {
            set { _���� = value; }
            get { return _����; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ����
        {
            set { _���� = value; }
            get { return _����; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ����ʱ��
        {
            set { _����ʱ�� = value; }
            get { return _����ʱ��; }
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
        public int? �Ƿ���ʾ
        {
            set { _�Ƿ���ʾ = value; }
            get { return _�Ƿ���ʾ; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? �Ƿ��ö�
        {
            set { _�Ƿ��ö� = value; }
            get { return _�Ƿ��ö�; }
        }
        #endregion Model

    }
}

