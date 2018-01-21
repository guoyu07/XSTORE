using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_vipcard
    {
        public int id = 0;
        public int is_open = 1;//是否开启
        public int wid = 0;//公众号id
        public string name = "";//名称
        public string title_image = ""; //标题图
        public string pre_name = "";//卡号前缀
        public int card_start = 1;//起始卡号
        public int acc_card = 0;//当前累加到的数
        public int get_card_condition = 0;//领取条件暂时默认0为关注用户
        public string no_getinfo = "";//未领取的会员卡提示信息
        public DateTime create_time = DateTime.Now;//创建时间
        public string card_info = "";//会员卡提示信息

        public B2C_vipcard() { }
        public B2C_vipcard(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        public B2C_vipcard(string _wid)
        {
            this.wid = int.Parse(_wid);
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_vipcard where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else if (wid != 0)
            {
                _sql += " and wid=" + this.wid;
            }
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if(dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                is_open = Convert.IsDBNull(dr["is_open"]) ? 1 : Convert.ToInt32(dr["is_open"]);
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                title_image = Convert.IsDBNull(dr["title_image"]) ? "" : Convert.ToString(dr["title_image"]);
                pre_name = Convert.IsDBNull(dr["pre_name"]) ? "" : Convert.ToString(dr["pre_name"]);
                card_start = Convert.IsDBNull(dr["card_start"]) ? 0 : Convert.ToInt32(dr["card_start"]);
                acc_card = Convert.IsDBNull(dr["acc_card"]) ? 0 : Convert.ToInt32(dr["acc_card"]);
                get_card_condition = Convert.IsDBNull(dr["get_card_condition"]) ? 0 : Convert.ToInt32(dr["get_card_condition"]);
                no_getinfo = Convert.IsDBNull(dr["no_getinfo"]) ? "" : Convert.ToString(dr["no_getinfo"]);
                create_time = Convert.IsDBNull(dr["create_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["create_time"]);
                card_info = Convert.IsDBNull(dr["card_info"]) ? "" : Convert.ToString(dr["card_info"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.is_open, this.name, this.title_image, this.pre_name, this.card_start, this.get_card_condition, this.no_getinfo, this.card_info, this.acc_card);
            }
            else
            {
                this.myInsertMethod(this.is_open, this.wid, this.name, this.title_image, this.pre_name, this.card_start, this.get_card_condition, this.no_getinfo, this.card_info);
            }
        }
        private void myUpdateMethod(int _id, int _is_open, string _name, string _title_image, string _pre_name, int _card_start, int _get_card_condition, string _no_getinfo, string _card_info, int _acc_card)
        {
            string sql = "update B2C_vipcard set is_open=@is_open,name=@name,title_image=@title_image,pre_name=@pre_name,card_start=@card_start,get_card_condition=@get_card_condition,no_getinfo=@no_getinfo,card_info=@card_info,acc_card=@acc_card where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@is_open", _is_open), 
                    new SqlParameter("@name", _name), 
                    new SqlParameter("@title_image", _title_image), 
                    new SqlParameter("@pre_name", _pre_name), 
                    new SqlParameter("@card_start", _card_start), 
                    new SqlParameter("@get_card_condition", _get_card_condition), 
                    new SqlParameter("@no_getinfo", _no_getinfo), 
                    new SqlParameter("@card_info", _card_info), 
                    new SqlParameter("@acc_card", _acc_card), 
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
        private void myInsertMethod(int _is_open, int _wid, string _name, string _title_image, string _pre_name, int _card_start, int _get_card_condition, string _no_getinfo, string _card_info)
        {
            string sql = "insert into B2C_vipcard (is_open,wid,name,title_image,pre_name,card_start,get_card_condition,no_getinfo,card_info,create_time) values (@is_open,@wid,@name,@title_image,@pre_name,@card_start,@get_card_condition,@no_getinfo,@card_info,@create_time)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@is_open", _is_open), 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@name", _name), 
                    new SqlParameter("@title_image", _title_image), 
                    new SqlParameter("@pre_name", _pre_name), 
                    new SqlParameter("@card_start", _card_start), 
                    new SqlParameter("@get_card_condition", _get_card_condition), 
                    new SqlParameter("@no_getinfo", _no_getinfo), 
                    new SqlParameter("@card_info", _card_info),
                    new SqlParameter("@acc_card", _card_start), 
                    new SqlParameter("@create_time", DateTime.Now), 
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
            is_open = 1;//是否开启
            wid = 0;//公众号id
            name = "";//名称
            title_image = ""; //标题图
            pre_name = "";//卡号前缀
            card_start = 1;//起始卡号
            acc_card = 0;//当前累加到的数
            get_card_condition = 0;//领取条件暂时默认0为关注用户
            no_getinfo = "";//未领取的会员卡提示信息
            create_time = DateTime.Now;//创建时间
            card_info = "";//会员卡提示信息
        }
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_vipcard where id in (" + _ids + ")";
            try
            {
                comfun.UpdateBySQL(sql);
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_vipcard where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}