
using System;
namespace DTcms.Model
{
    /// <summary>
    /// t_Users:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_Users_Roles
    {
        public t_Users_Roles()
        { }
        #region Model
        private int _id;
        private int _Tenantid;
        private int _Userid;
        private int _Roleid;
        private DateTime _CreationTime;
        private int _CreatorUserid;
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        public int Tenantid
        {
            set { _Tenantid = value; }
            get { return _Tenantid; }
        }
        public int Userid { set { _Userid = value; } get { return _Userid; } }
        public int Roleid
        {
            set { _Roleid = value; }
            get { return _Roleid; }
        }

        public DateTime CreationTime
        {
            set { _CreationTime = value; }
            get { return _CreationTime; }
        }
        public int CreatorUserid
        {
            set { _CreatorUserid = value; }
            get { return _CreatorUserid; }
        }

        #endregion Model




    }
}

