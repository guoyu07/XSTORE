 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// WP_会员表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WP_会员表
	{
		public WP_会员表()
		{}
		#region Model
		private int _id;
		private string _openid;
		private string _wx昵称;
		private string _wx头像;
		private string _手机号;
        private string _password;
        private string _email;
        private string _qq;
        private string _sex;
        private int _jifen;
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

        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string wx昵称
		{
			set{ _wx昵称=value;}
			get{return _wx昵称;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wx头像
		{
			set{ _wx头像=value;}
			get{return _wx头像;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 手机号
		{
			set{ _手机号=value;}
			get{return _手机号;}
		}

        public string email
        {
            set { _email = value; }
            get { return _email; }
        }

        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }

        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }

        //积分
        public int jifen
        {
            set { _jifen = value; }
            get { return _jifen; }
        }

		#endregion Model




	}
}

