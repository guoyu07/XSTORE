using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_user_rank
    {
        public int id = 0;
        public int uid = 0;  //对应的userID
        public int rankid = 0; //等级ID
        public DateTime create_time = DateTime.Now;  //创建时间
        public DateTime last_time = DateTime.Now;  //有效时间
        public string card_number = ""; //卡号
        public B2C_user_rank() { }
        public B2C_user_rank(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        //根据uid加载对应的信息
        public B2C_user_rank(string _uid)
        {
            this.uid = int.Parse(_uid);
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_user_rank where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else if (uid != 0)
            {
                _sql += " and uid=" + this.uid;
            }
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                uid = Convert.IsDBNull(dr["uid"]) ? 0 : Convert.ToInt32(dr["uid"]);
                rankid = Convert.IsDBNull(dr["rankid"]) ? 0 : Convert.ToInt32(dr["rankid"]);
                create_time = Convert.IsDBNull(dr["create_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["create_time"]);
                last_time = Convert.IsDBNull(dr["last_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["last_time"]);
                card_number = Convert.IsDBNull(dr["card_number"]) ? "" : Convert.ToString(dr["card_number"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.rankid);
            }
            else
            {
                this.myInsertMethod(this.uid, this.rankid, this.card_number, this.create_time, this.last_time);
            }
        }
        private void myUpdateMethod(int _id, int _rankid)
        {
            string sql = "update B2C_user_rank set rankid=@rankid where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@rankid", _rankid), 
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
        private void myInsertMethod(int _uid, int _rankid, string _card_number, DateTime _create_time, DateTime _last_timeuid)
        {
            string sql = "insert into B2C_user_rank (uid,rankid,card_number) values (@uid,@rankid,@card_number)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@uid", _uid), 
                     new SqlParameter("@rankid", _rankid),
                     new SqlParameter("@card_number", _card_number)
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
            uid = 0;
            rankid = 0;
            create_time = DateTime.Now;
            last_time = DateTime.Now;
            card_number = "";
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
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_user_rank where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}