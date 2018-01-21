using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DTcms.DBUtility
{
    public enum SubFieldType
    {
        i_Bit,
        i_Datetime,
        i_Ntext,
        i_Nvarchar,
        i_Int,
        i_Bigint,
        i_Money,
        i_Binary,
        i_Image,
        i_Float,
    }
    public enum SubDbType
    {
        /// <summary>
        /// 添加
        /// </summary>
        Insert,
        /// <summary>
        /// 修改
        /// </summary>
        Update,
        /// <summary>
        /// 删除
        /// </summary>
        Delete,
        /// <summary>
        /// 自定义Sql
        /// </summary>
        Sql,
        /// <summary>
        /// 存储过程
        /// </summary>
        Stored 
    }
    public class SubFields
    {
        private ArrayList _Name;
        private ArrayList _Value;
        private ArrayList _Size;
        private ArrayList _Type;
        public SubFields()
        {
            _Name = new ArrayList();
            _Value = new ArrayList();
            _Size = new ArrayList();
            _Type = new ArrayList();
        }
        public int Count()
        {
            return _Name.Count;
        }
        public string Name(int index)
        {
            return _Name[index].ToString();
        }
        public object Value(int index)
        {
            return _Value[index];
        }
        public int Size(int index)
        {
            return Convert.ToInt32(_Size[index].ToString());
        }
        public string Type(int index)
        {
            return _Type[index].ToString().Split(new char[] { '_' })[1];
        }

        public void Add(string Name, object Value, int Size, SubFieldType Type)
        {
            bool isAdd = true;
            switch (Type)
            {
                case SubFieldType.i_Int:
                    if (Convert.ToInt32(Value) == -1)
                    {
                        isAdd = false;
                    }
                    break;
                case SubFieldType.i_Datetime:
                    if (Convert.ToDateTime(Value) == DateTime.MinValue)
                    {
                        isAdd = false;
                    }
                    break;
                default:
                    if (Value == null)
                    {
                        isAdd = false;
                    }
                    break;
            }
            if (isAdd)
            {
                _Name.Add(Name);
                _Value.Add(Value);
                _Size.Add(Size);
                _Type.Add(Type);
            }
        }
    }
    public partial class SubTables
    {
        //private ArrayList _db;
        private ArrayList _DbType;
        private ArrayList _Tables;
        private ArrayList _Fields;
        private ArrayList _Where;
        public SubTables()
        {
            //_db = new ArrayList();
            _DbType = new ArrayList();
            _Tables = new ArrayList();
            _Fields = new ArrayList();
            _Where = new ArrayList();
        }
        public int Count()
        {
            return _Tables.Count;
        }
        public SubDbType DbType(int index)
        {
            return (SubDbType)_DbType[index];
        }
        public string Tables(int index)
        {
            return _Tables[index].ToString();
        }
        public SubFields Fields(int index)
        {
            return (SubFields)_Fields[index];
        }
        public string Where(int index)
        {
            return _Where[index].ToString();
        }
        public void Add(SubDbType DbType, string Tables, SubFields Fields, string Where)
        {
            _DbType.Add(DbType);
            _Tables.Add(Tables);
            _Fields.Add(Fields);
            _Where.Add(Where);
        }
        public void Insert(string Tables, SubFields Fields)
        {
            _DbType.Add(SubDbType.Insert);
            _Tables.Add(Tables);
            _Fields.Add(Fields);
            _Where.Add("");
        }
        public void Update(string Tables, SubFields Fields, string Where)
        {
            _DbType.Add(SubDbType.Update);
            _Tables.Add(Tables);
            _Fields.Add(Fields);
            _Where.Add(Where);
        }
        public void Delete(string Tables, string Where)
        {
            _DbType.Add(SubDbType.Delete);
            _Tables.Add(Tables);
            _Fields.Add(new SubFields());
            _Where.Add(Where);
        }
        public void Delete(string Tables, SubFields Fields, string Where)
        {
            _DbType.Add(SubDbType.Delete);
            _Tables.Add(Tables);
            _Fields.Add(Fields);
            _Where.Add(Where);
        }
        //public void Add(IDb db, SubDbType DbType, string Tables, SubFields2 Fields, string Where)
        //{
        //    _db.Add(db);
        //    _DbType.Add(DbType);
        //    _Tables.Add(Tables);
        //    _Fields.Add(Fields);
        //    _Where.Add(Where);
        //}
    }
}
