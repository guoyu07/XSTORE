using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_card_action
    {
        public int id = 0;
        public DateTime create_time = DateTime.Now;//创建时间
        public DateTime star_time = DateTime.Now;//创建时间
        public DateTime end_time = DateTime.Now;//创建时间

        public int is_long = 0;
        public int cardid = 0;
        public string name = "";
        public string des = "";

        public B2C_card_action() { }
        public B2C_card_action(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        //public B2C_group_fran(string _wid)
        //{
        //    this.wid = int.Parse(_wid);
        //    this.LoadData();
        //}
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_card_action where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 1)
            {
                throw (new Exception("B2C_vipcard取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_vipcard没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                is_long = Convert.IsDBNull(dr["is_long"]) ? 0 : Convert.ToInt32(dr["is_long"]);
                cardid = Convert.IsDBNull(dr["cardid"]) ? 0 : Convert.ToInt32(dr["cardid"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                des = Convert.IsDBNull(dr["des"]) ? "" : Convert.ToString(dr["des"]);
                create_time = Convert.IsDBNull(dr["create_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["create_time"]);
                star_time = Convert.IsDBNull(dr["star_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["star_time"]);
                end_time = Convert.IsDBNull(dr["end_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["end_time"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(id, is_long, cardid, name, des, star_time, end_time);
            }
            else
            {
                this.myInsertMethod(is_long, cardid, name, des, star_time, end_time);
            }
        }
        private void myUpdateMethod(int _id, int _is_long, int _cardid, string _name, string _des, DateTime _star_time, DateTime _end_time)
        {
            string sql = "update B2C_card_action set is_long=@is_long,cardid=@cardid,name=@name, des=@des ,star_time=@star_time, end_time=@end_time where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@is_long", _is_long), 
                    new SqlParameter("@cardid", _cardid),
                     new SqlParameter("@name", _name),
                      new SqlParameter("@des", _des),
                          new SqlParameter("@end_time", _end_time),
                      new SqlParameter("@star_time", _star_time),
                    new SqlParameter("@id",_id)};

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        private void myInsertMethod(int _is_long, int _cardid, string _name, string _des, DateTime _star_time, DateTime _end_time)
        {
            string sql = "insert into B2C_card_action (is_long,cardid,name,des,star_time,end_time) values (@is_long,@cardid,@name,@des,@star_time,@end_time)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@is_long", _is_long), 
                    new SqlParameter("@cardid", _cardid),
                     new SqlParameter("@name", _name), 
                    new SqlParameter("@des", _des),
                        new SqlParameter("@end_time", _end_time),
                      new SqlParameter("@star_time", _star_time)
                    };
            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public void AddNew()
        {
            id = 0;
            is_long = 0;//公众号id
            cardid = 0;
            create_time = DateTime.Now;//创建时间
            star_time = DateTime.Now;//创建时间
            end_time = DateTime.Now;//创建时间
            name = "";
            des = "";
        }
        //public static int delete(string _ids)
        //{
        //    int result = 0;

        //    string sql = "delete from B2C_vipcard where id in (" + _ids + ")";
        //    try
        //    {
        //        comfun.UpdateBySQL(sql);
        //        result = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = 0;
        //        throw ex;
        //    }
        //    return result;
        //}
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_card_action where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}