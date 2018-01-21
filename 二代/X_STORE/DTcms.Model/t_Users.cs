 
using System;
namespace DTcms.Model
{
	/// <summary>
	/// t_Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Users
	{
		public t_Users()
		{}
		#region Model
		private int _id;
        private string _nickname;
        private int _gender;
        private string _wechatopenid;
		private string _wechatAccesstoken;
		private int _wechataccesstokenExpiresIn;
		private string _wechatRefreshToken;
        private DateTime _wechattokencreatime;
        private int _areaid;
        private string _province;
        private string _city;
        private string _country;
        private string _headImgurl;
        private string _mobile;
        private Boolean _IsMobileConfirmed;
        private int _consumes;
        private decimal _totalprice;
        private DateTime _regtime;
        private string _regipaddress;
        private DateTime _logintime;
        private int _logintimes;
        private string _loginipaddress;
        private string _authenticationsource;
        private string _name;
        private string _surname;
        private string _password;
        private Boolean _IsEmailconfiremed;
        private string _emailcofirmationcode;
        private string _passwordresetcode;
        private Boolean _IsActive;
        private string _username;
        private int _tenantid;
        private string _emailaddress;
        private DateTime _lastlogintime;
        private Boolean _isdeleted;
        private int _deleteruserid;
        private DateTime _deletiontime;
        private DateTime _lastmodificationtime;
        private int _lastmodifieruserid;
        private DateTime _creationtime;
        private int _creatoruserid;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        public string nickname 
        { 
            set { _nickname = value; } 
            get { return _nickname; }
        }
        public int gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        public string wechatopenid
        {
            set { _wechatopenid = value; }
            get { return _wechatopenid; }
        }
        public string wechatAccesstoken
        {
            set { _wechatAccesstoken = value; }
            get { return _wechatAccesstoken; }
        }
        public int wechataccesstokenExpiresIn
        {
            set { _wechataccesstokenExpiresIn = value; }
            get { return _wechataccesstokenExpiresIn; }
        }
        public string wechatRefreshToken
        {
            set { _wechatRefreshToken = value; }
            get { return _wechatRefreshToken; }
        }
        public DateTime wechattokencreatime
        {
            set { _wechattokencreatime = value; }
            get { return _wechattokencreatime; }
        }
        public int areaid
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        public string province
        {
            set { _province = value; }
            get { return _province; }
        }
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        public string country
        {
            set { _country = value; }
            get { return _country; }
        }
        public string headImgurl
        {
            set { _headImgurl = value; }
            get { return _headImgurl; }
        }
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        public Boolean IsMobileConfirmed
        {
            set { _IsMobileConfirmed = value; }
            get { return _IsMobileConfirmed; }
        }
        public int consumes
        {
            set { _consumes = value; }
            get { return _consumes; }
        }
        public decimal totalprice
        {
            set { _totalprice = value; }
            get { return _totalprice; }
        }
        public DateTime regtime
        { set { _regtime = value; }
            get { return _regtime; }
        }
        public string regipaddress
        {
            set { _regipaddress = value; }
            get { return _regipaddress; }
        }
        public DateTime logintime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        public int logintimes
        {
            set { _logintimes = value; }
            get { return _logintimes; }
        }
        public string loginipaddress
        {
            set { _loginipaddress = value; }
            get { return _loginipaddress; }
        }
        public string authenticationsource
        {
            set { _authenticationsource = value; }
            get { return _authenticationsource; }
        }
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public string surname
        {
            set { _surname = value; }
            get { return _surname; }
        }
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        public Boolean IsEmailconfiremed
        {
            set { _IsEmailconfiremed = value; }
            get { return _IsEmailconfiremed; }
        }
        public string emailcofirmationcode
        {
            set { _emailcofirmationcode = value; }
            get { return _emailcofirmationcode; }
        }
        public string passwordresetcode
        {
            set { _passwordresetcode = value; }
            get { return _passwordresetcode; }
        }
        public Boolean IsActive
        {
            set { _IsActive = value; }
            get { return _IsActive; }
        }
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        public int tenantid
        {
            set { _tenantid = value; }
            get { return _tenantid; }
        }
        public string emailaddress
        {
            set { _emailaddress = value; }
            get { return _emailaddress; }
        }
        public DateTime lastlogintime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        public Boolean isdeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        public int deleteruserid
        {
            set { _deleteruserid = value; }
            get { return _deleteruserid; }
        }
        public DateTime deletiontime
        {
            set { _deletiontime = value; }
            get { return _deletiontime; }
        }
        public DateTime lastmodificationtime
        {
            set { _lastmodificationtime = value; }
            get { return _lastmodificationtime; }
        }
        public int lastmodifieruserid
        {
            set { _lastmodifieruserid = value; }
            get { return _lastmodifieruserid; }
        }
        public DateTime creationtime
        {
            set { _creationtime = value; }
            get { return _creationtime; }
        }
        public int creatoruserid
        {
            set { _creatoruserid = value; }
            get { return _creatoruserid; }
        }

		#endregion Model




	}
}

