using System;
namespace DTcms.Model
{
    /// <summary>
    /// TK_���۱�:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public partial class TK_���۱�
    {
        public TK_���۱�()
        { }
        #region Model
        private int _id;
        private string _openid;
        private int? _������id;
        private string _��������;
        private DateTime? _����ʱ��;
        private string _��ע;
        private int? _�Ƿ���ʾ = 1;
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
        public int? ������id
        {
            set { _������id = value; }
            get { return _������id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ��������
        {
            set { _�������� = value; }
            get { return _��������; }
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
        public string ��ע
        {
            set { _��ע = value; }
            get { return _��ע; }
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
        public int? parentid
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        #endregion Model

    }
}

