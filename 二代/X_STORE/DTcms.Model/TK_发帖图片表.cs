using System;
namespace DTcms.Model
{
	/// <summary>
	/// TK_����ͼƬ��:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class TK_����ͼƬ��
	{
		public TK_����ͼƬ��()
		{}
		#region Model
		private int _id;
		private string _���;
		private string _����;
		private string _ͼƬ·��;
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
		public string ���
		{
			set{ _���=value;}
			get{return _���;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ����
		{
			set{ _����=value;}
			get{return _����;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ͼƬ·��
		{
			set{ _ͼƬ·��=value;}
			get{return _ͼƬ·��;}
		}
		#endregion Model

	}
}

