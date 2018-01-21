using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;


namespace Hzwx.DAL
{

    //public class sqldb
    //{
    //    public IDb Db { get; set; }
    //    public sqldb()
    //    {
    //        this.Db = new DbFactory().DriverNewDb();
    //    }
    //    public sqldb(int index)
    //    {
    //        switch (index)
    //        {
    //            case 0:
    //                this.Db = new DbFactory().DriverNewDb();
    //                break;
    //        }
    //    }
    //    public void OpenTrans(params ITrans[] dal)
    //    {
    //        foreach (ITrans item in dal)
    //        {
    //            item.Trans(this);
    //        }
    //    }
    //    public void Trans()
    //    {
    //        this.Db.Trans();
    //    }
    //    public bool Commit()
    //    {
    //        return this.Db.Commit();
    //    }
    //    public bool ExecuteSql(string Sql)
    //    {
    //        return this.Db.ExecuteSql(Sql);
    //    }
    //    public object Scalar(string Sql)
    //    {
    //        return this.Db.Scalar(Sql);
    //    }
    //    public int GetMaxID<T>(string KeyField)
    //    {
    //        string TableName = typeof(T).Name;
    //        return Db.GetMaxID(KeyField, TableName) + 1;
    //    }
    //    public bool Insert<T>(T Model)
    //    {
    //        string TableName = typeof(T).Name;
    //        return Insert<T>(TableName, Model);
    //    }
    //    public bool Insert<T>(string TableName, T Model)
    //    {
    //        SubTables t = new SubTables();
    //        SubFields f = new SubFields();
    //        PropertyInfo[] propertys = typeof(T).GetProperties();
    //        foreach (PropertyInfo property in propertys)
    //        {
    //            string name = property.Name;
    //            object value = property.GetValue(Model, null);
    //            Model.DescriptionAttribute attr = null;
    //            try
    //            {
    //                object[] objs = property.GetCustomAttributes(typeof(Model.DescriptionAttribute), true);
    //                attr = (objs[0] as Model.DescriptionAttribute);
    //            }
    //            catch (Exception)
    //            {
    //            }
    //            if (attr != null)
    //            {
    //                if (attr.IsKey)
    //                {
    //                    if (value.ObjToInt(0) <= 0)
    //                        value = Db.GetMaxID(name, TableName) + 1;
    //                }
    //            }
    //            f.Add(name, value);
    //        }
    //        t.Add(SubDbType.Insert, TableName, f, "");
    //        return this.Db.ExecuteSql(t);
    //    }
    //    public bool Insert(string TableName, object Model)
    //    {
    //        SubTables t = new SubTables();
    //        SubFields f = new SubFields();
    //        PropertyInfo[] propertys = Model.GetType().GetProperties();
    //        foreach (PropertyInfo property in propertys)
    //        {
    //            string name = property.Name;
    //            object value = property.GetValue(Model, null);
    //            f.Add(name, value);
    //        }
    //        t.Add(SubDbType.Insert, TableName, f, "");
    //        return this.Db.ExecuteSql(t);
    //    }
    //    public bool Update<T>(T Model, string WhereSql)
    //    {
    //        string TableName = typeof(T).Name;
    //        return Update(TableName, (object)Model, WhereSql);
    //    }
    //    public bool Update<T>(T Model, int keyID)
    //    {
    //        string TableName = typeof(T).Name;
    //        return Update<T>(TableName, (object)Model, keyID);
    //    }
    //    public bool Update<T>(object varModel, string WhereSql)
    //    {
    //        string TableName = typeof(T).Name;
    //        return Update(TableName, varModel, WhereSql);
    //    }
    //    public bool Update<T>(object varModel, int keyID)
    //    {
    //        string TableName = typeof(T).Name;
    //        return Update<T>(TableName, varModel, keyID);
    //    }
    //    public bool Update<T>(string TableName, T Model, string WhereSql)
    //    {
    //        return Update(TableName, (object)Model, WhereSql);
    //    }
    //    public bool Update<T>(string TableName, object varModel, int keyID)
    //    {
    //        string keySql = "";
    //        PropertyInfo[] propertys = typeof(T).GetProperties();
    //        foreach (PropertyInfo property in propertys)
    //        {
    //            string name = property.Name;
    //            Model.DescriptionAttribute attr = null;
    //            try
    //            {
    //                object[] objs = property.GetCustomAttributes(typeof(Model.DescriptionAttribute), true);
    //                attr = (objs[0] as Model.DescriptionAttribute);
    //            }
    //            catch (Exception)
    //            {
    //            }
    //            if (attr != null)
    //            {
    //                if (attr.IsKey)
    //                {
    //                    if (keyID > 0)
    //                    {
    //                        keySql = string.Format(" {0}={1} ", name, keyID + "");
    //                    }
    //                    break;
    //                }
    //            }
    //        }
    //        if (keySql != "")
    //        {
    //            return Update(TableName, varModel, keySql);
    //        }
    //        return false;
    //    }
    //    public bool Update(string TableName, object varModel, string WhereSql)
    //    {
    //        SubTables t = new SubTables();
    //        SubFields f = new SubFields();
    //        PropertyInfo[] propertys = varModel.GetType().GetProperties();
    //        foreach (PropertyInfo property in propertys)
    //        {
    //            string name = property.Name;
    //            object value = property.GetValue(varModel, null);

    //            Model.DescriptionAttribute attr = null;
    //            try
    //            {
    //                object[] objs = property.GetCustomAttributes(typeof(Model.DescriptionAttribute), true);
    //                attr = (objs[0] as Model.DescriptionAttribute);
    //            }
    //            catch (Exception)
    //            {
    //            }
    //            bool flag = true;
    //            if (attr != null)
    //            {
    //                if (attr.IsKey) flag = false;
    //            }
    //            if (flag)
    //                f.Add(name, value);
    //        }
    //        t.Add(SubDbType.Update, TableName, f, WhereSql);
    //        return this.Db.ExecuteSql(t);
    //    }
    //    public bool Delete<T>(string WhereSql)
    //    {
    //        string TableName = typeof(T).Name;
    //        return Delete(TableName, WhereSql);
    //    }
    //    public bool Delete(string TableName, string WhereSql)
    //    {
    //        SubTables t = new SubTables();
    //        t.Add(SubDbType.Delete, TableName, new SubFields(), WhereSql);
    //        return this.Db.ExecuteSql(t);
    //    }
    //    private string Date(string input)
    //    {
    //        string ProviderName = Db.ProviderName;
    //        switch (ProviderName)
    //        {
    //            case "System.Data.OleDb":
    //                return string.Format("Format({0},\"yyyyMMdd\")", input);
    //            case "System.Data.SqlClient":
    //                return string.Format("Convert(varchar(20),{0}, 112)", input);
    //            default:
    //                return string.Format("Convert(varchar(20),{0}, 112)", input);
    //        }
    //    }
    //    private SubFields WhereFields(StringBuilder where, bool IsLike, params object[] Fields)
    //    {
    //        SubFields f = new SubFields();
    //        object[] _fields = Fields;
    //        if (_fields != null)
    //        {
    //            //判断是否偶数参数
    //            if (_fields.Length % 2 != 0) return f;

    //            //条件参数
    //            for (int i = 0; i < _fields.Length; i += 2)
    //            {
    //                string[] array = _fields[i].ToString().Split(' ');
    //                string name = array[0].Trim();
    //                string name_2 = array[0].Trim().Replace(".", "_");
    //                string tag = array.Length == 2 ? array[1].ToLower().Trim() : "";
    //                object value = _fields[i + 1];

    //                //模糊
    //                if (IsLike)
    //                {
    //                    if (value == null || value.ObjToStr().Trim() == "") continue;
    //                }
    //                else
    //                {
    //                    if (value == null) value = "";
    //                }

    //                //name in      (字符型,整型)
    //                //name between (时间)
    //                //name like    (字符)
    //                //name <>      (整型)
    //                if (value.GetType() == typeof(DateTime[]))
    //                {
    //                    DateTime[] time = (DateTime[])value;
    //                    if (time[0] != DateTime.MinValue && time[1] != DateTime.MinValue)
    //                    {
    //                        where.AppendFormat(" And {0}>= @{1}_T1 And {0}<= @{1}_T2 ", Date(name), name_2);
    //                        f.Add("" + name_2 + "_T1", time[0].ToString("yyyyMMdd"));
    //                        f.Add("" + name_2 + "_T2", time[1].ToString("yyyyMMdd"));
    //                    }
    //                    else if (time[0] == DateTime.MinValue && time[1] != DateTime.MinValue)
    //                    {
    //                        where.AppendFormat(" And {0}<= @{1}_T2 ", Date(name), name_2);
    //                        f.Add("" + name_2 + "_T2", time[1].ToString("yyyyMMdd"));
    //                    }
    //                    else if (time[0] != DateTime.MinValue && time[1] == DateTime.MinValue)
    //                    {
    //                        where.AppendFormat(" And {0}>= @{1}_T1", Date(name), name_2);
    //                        f.Add("" + name_2 + "_T1", time[0].ToString("yyyyMMdd"));
    //                    }
    //                }
    //                else if (value.GetType() == typeof(DateTime))
    //                {
    //                    DateTime time = (DateTime)value;
    //                    if (time != DateTime.MinValue)
    //                    {
    //                        where.AppendFormat(" And Convert(varchar(100), {0}, 112)=@{1} ", name, name_2);
    //                        f.Add(name_2, time.ToString("yyyyMMdd"));
    //                    }
    //                }
    //                else if (
    //                    value.GetType() == typeof(int)
    //                    || value.GetType() == typeof(Int64))
    //                {
    //                    switch (tag)
    //                    {
    //                        case "in":       // in
    //                            where.AppendFormat(" And {0} in ({1})", name, value);
    //                            break;
    //                        case "<>":       // 不等于
    //                            where.AppendFormat(" And {0}<>@{1} ", name, name_2);
    //                            f.Add(name_2, value);
    //                            break;
    //                        default:
    //                            if (IsLike)
    //                            {
    //                                if ((value.GetType() == typeof(int) && (int)value != 0)
    //                                    || (value.GetType() == typeof(Int64) && (Int64)value != 0))
    //                                {
    //                                    where.AppendFormat(" And {0}=@{1} ", name, name_2);
    //                                    f.Add(name_2, value);
    //                                }
    //                            }
    //                            else
    //                            {
    //                                where.AppendFormat(" And {0}=@{1} ", name, name_2);
    //                                f.Add(name_2, value);
    //                            }
    //                            break;
    //                    }
    //                }
    //                else if (value.GetType() == typeof(string))
    //                {
    //                    switch (tag)
    //                    {
    //                        case "in":       // in
    //                            where.AppendFormat(" And {0} in ({1})", name, value);
    //                            break;
    //                        case "like":     // 模糊
    //                            where.AppendFormat(" And {0} like '%'+@{1}+'%'", name, name_2);
    //                            f.Add(name_2, value);
    //                            break;
    //                        case "sql":      // 条件sql
    //                            where.AppendFormat(" And {0}{1}", name, value);
    //                            break;
    //                        case "<>":       // 不等于
    //                            where.AppendFormat(" And {0}<>@{1} ", name, name_2);
    //                            f.Add(name_2, value);
    //                            break;
    //                        default:         // 默认
    //                            if (IsLike)
    //                            {
    //                                where.AppendFormat(" And {0} like '%'+@{1}+'%'", name, name_2);
    //                            }
    //                            else
    //                            {
    //                                where.AppendFormat(" And {0}=@{1} ", name, name_2);
    //                            }
    //                            f.Add(name_2, value);
    //                            break;
    //                    }
    //                }
    //            }
    //        }
    //        return f;
    //    }
    //    public List<T> FindToList<T>(string FullSql)
    //    {
    //        return this.Db.DataTableList<T>(FullSql, new SubFields());
    //    }
    //    public List<T> FindToList<T>(string WhereSql, string OrderField, object[] WhereField)
    //    {
    //        string TableName = typeof(T).Name;
    //        StringBuilder where = new StringBuilder();
    //        if (WhereSql == null || WhereSql == "") WhereSql = "";
    //        {
    //            if (WhereSql != "")
    //            {
    //                if (WhereSql.Trim().Length > 3 && WhereSql.Trim().Substring(0, 3).ToLower() == "and")
    //                {
    //                    where.Append(WhereSql);
    //                }
    //                else
    //                {
    //                    where.Append(" and " + WhereSql);
    //                }
    //            }
    //        }
    //        SubFields f = WhereFields(where, true, WhereField);

    //        StringBuilder Sql = new StringBuilder();
    //        Sql.Append(" select * ");
    //        Sql.Append(" from " + TableName + " ");
    //        Sql.Append(" where 1=1 ");

    //        if (where.ToString() != "")
    //            Sql.Append(" " + where.ToString() + " ");

    //        if (OrderField != null && OrderField != "")
    //            Sql.Append(" order by " + OrderField + " ");

    //        return this.Db.DataTableList<T>(Sql.ToString(), f);
    //    }
    //    public List<T> FindToList<T>(string ShowField, string Tables, string WhereSql, string OrderField, object[] WhereField)
    //    {
    //        StringBuilder where = new StringBuilder();
    //        if (ShowField == null || ShowField == "") ShowField = "*";
    //        where.Append(this.WhereSql(WhereSql));
    //        SubFields f = WhereFields(where, true, WhereField);

    //        StringBuilder Sql = new StringBuilder();
    //        Sql.Append(" select " + ShowField + " ");
    //        Sql.Append(" from " + Tables + " ");
    //        Sql.Append(" where 1=1 ");

    //        if (where.ToString() != "")
    //            Sql.Append(" " + where.ToString() + " ");

    //        if (OrderField != "")
    //            Sql.Append(" order by " + OrderField + " ");

    //        return this.Db.DataTableList<T>(Sql.ToString(), f);
    //    }
    //    public T FindToObject<T>(string FullSql)
    //    {
    //        return (T)this.Db.DataTableObject<T>(FullSql, new SubFields());
    //    }
    //    public T FindToObject<T>(string WhereSql, object[] WhereField)
    //    {
    //        string TableName = typeof(T).Name;
    //        StringBuilder where = new StringBuilder();
    //        where.Append(this.WhereSql(WhereSql));
    //        SubFields f = WhereFields(where, true, WhereField);

    //        StringBuilder Sql = new StringBuilder();
    //        Sql.Append(" select top 1 * ");
    //        Sql.Append(" from " + TableName + " ");
    //        Sql.Append(" where 1=1 ");

    //        if (where.ToString() != "")
    //            Sql.Append(" " + where.ToString() + " ");

    //        return (T)this.Db.DataTableObject<T>(Sql.ToString(), f);
    //    }
    //    public T FindToObject<T>(string ShowField, string Tables, string WhereSql, string OrderField, object[] WhereField)
    //    {
    //        if (ShowField == null || ShowField == "") ShowField = "*";

    //        StringBuilder where = new StringBuilder();
    //        where.Append(this.WhereSql(WhereSql));
    //        SubFields f = WhereFields(where, true, WhereField);

    //        StringBuilder Sql = new StringBuilder();
    //        Sql.Append(" select top 1 " + ShowField + " ");
    //        Sql.Append(" from " + Tables + " ");
    //        Sql.Append(" where 1=1 ");

    //        if (where.ToString() != "")
    //            Sql.Append(" " + where.ToString() + " ");

    //        if (OrderField != "")
    //            Sql.Append(" order by " + OrderField + " ");

    //        return (T)this.Db.DataTableObject<T>(Sql.ToString(), f);
    //    }
    //    public DataTable DataTable(string Sql)
    //    {
    //        return this.Db.DataTable(Sql);
    //    }
    //    public DataTable DataTable(int PageSize, int PageIndex, string FullSql, string OrderField, out int RecordCount)
    //    {
    //        RecordCount = Convert.ToInt32(Db.Scalar(Common.PagingHelper.CreateCountingSql(FullSql)));
    //        return Db.DataTable(Common.PagingHelper.CreatePagingSql(RecordCount, PageSize, PageIndex, FullSql, OrderField));
    //    }
    //    public DataTable DataTable<T>(int PageSize, int PageIndex, string ShowFields, string WhereSql, string OrderField, out int RecordCount, params object[] WhereField)
    //    {
    //        string TableName = typeof(T).Name;
    //        StringBuilder where = new StringBuilder();
    //        where.Append(this.WhereSql(WhereSql));
    //        SubFields f = WhereFields(where, true, WhereField);

    //        StringBuilder Sql = new StringBuilder();
    //        Sql.Append(" select ");
    //        if (ShowFields != null && ShowFields.ToString() != "")
    //        {
    //            Sql.Append(" " + ShowFields + " ");
    //        }
    //        else
    //        {
    //            Sql.Append(" * ");
    //        }
    //        Sql.Append(" from " + TableName + " ");
    //        Sql.Append(" where 1=1 ");

    //        if (where.ToString() != "")
    //            Sql.Append(" " + where.ToString() + " ");

    //        RecordCount = Convert.ToInt32(Db.Scalar(Common.PagingHelper.CreateCountingSql(Sql.ToString())));
    //        return Db.DataTable(Common.PagingHelper.CreatePagingSql(RecordCount, PageSize, PageIndex, Sql.ToString(), OrderField), f);
    //    }
    //    public DataTable DataTable(int PageSize, int PageIndex, string ShowFields, string Tables, string WhereSql, string OrderField, out int RecordCount, params object[] WhereField)
    //    {
    //        StringBuilder where = new StringBuilder();
    //        where.Append(this.WhereSql(WhereSql));
    //        SubFields f = WhereFields(where, true, WhereField);

    //        StringBuilder Sql = new StringBuilder();
    //        Sql.Append(" select " + ShowFields + " ");
    //        Sql.Append(" from " + Tables + " ");
    //        Sql.Append(" where 1=1 ");

    //        if (where.ToString() != "")
    //            Sql.Append(" " + where.ToString() + " ");

    //        RecordCount = Convert.ToInt32(Db.Scalar(Common.PagingHelper.CreateCountingSql(Sql.ToString())));
    //        return Db.DataTable(Common.PagingHelper.CreatePagingSql(RecordCount, PageSize, PageIndex, Sql.ToString(), OrderField), f);
    //    }
    //    public DataTable TopRow(int Top, string ShowFields, string Tables, string WhereSql, string OrderField, params object[] WhereField)
    //    {
    //        StringBuilder where = new StringBuilder();
    //        where.Append(this.WhereSql(WhereSql));
    //        SubFields f = WhereFields(where, true, WhereField);

    //        StringBuilder Sql = new StringBuilder();
    //        Sql.Append(" select ");
    //        if (Top > 0)
    //        {
    //            Sql.Append(" top " + Top + " ");
    //        }
    //        if (ShowFields != null && ShowFields.ToString() != "")
    //        {
    //            Sql.Append(" " + ShowFields + " ");
    //        }
    //        else
    //        {
    //            Sql.Append(" * ");
    //        }
    //        Sql.Append(" from " + Tables + " ");
    //        Sql.Append(" where 1=1 ");

    //        if (where.ToString() != "")
    //            Sql.Append(" " + where.ToString() + " ");


    //        if (OrderField != null && OrderField.ToString() != "")
    //            Sql.Append(" " + OrderField.ToString() + " ");

    //        return Db.DataTable(Sql.ToString(), f);
    //    }
    //    public DataTable TopRow<T>(int Top, string ShowFields, string WhereSql, string OrderField, params object[] WhereField)
    //    {
    //        string TableName = typeof(T).Name;

    //        StringBuilder where = new StringBuilder();
    //        where.Append(this.WhereSql(WhereSql));
    //        SubFields f = WhereFields(where, true, WhereField);

    //        StringBuilder Sql = new StringBuilder();
    //        Sql.Append(" select ");
    //        if (Top > 0)
    //        {
    //            Sql.Append(" top " + Top + " ");
    //        }
    //        if (ShowFields != null && ShowFields.ToString() != "")
    //        {
    //            Sql.Append(" " + ShowFields + " ");
    //        }
    //        else
    //        {
    //            Sql.Append(" * ");
    //        }
    //        Sql.Append(" from " + TableName + " ");
    //        Sql.Append(" where 1=1 ");

    //        if (where.ToString() != "")
    //            Sql.Append(" " + where.ToString() + " ");

    //        if (OrderField != null && OrderField.ToString() != "")
    //            Sql.Append(" " + OrderField.ToString() + " ");

    //        return Db.DataTable(Sql.ToString(), f);
    //    }
    //    private string WhereSql(string WhereSql)
    //    {
    //        if (WhereSql == null || WhereSql == "") WhereSql = "";
    //        {
    //            if (WhereSql != "")
    //            {
    //                if (WhereSql.Trim().Length > 3 && WhereSql.Trim().Substring(0, 3).ToLower() == "and")
    //                {
    //                    return WhereSql;
    //                }
    //                else
    //                {
    //                    return " and " + WhereSql;
    //                }
    //            }
    //        }
    //        return "";
    //    }
    //}
}
