using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_rankinfo
    {
        public int id = 0;
        public string name = "";//名称
        public int score = 0; //等级积分条件
        public int overdays = 0;//过期天数默认0长期有效
        public string des = "";//等级说明
        public int cardid = 0;//关联会员卡信息ID
        public DateTime create_time = DateTime.Now;//创建时间

        public B2C_rankinfo() { }
        public B2C_rankinfo(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        public B2C_rankinfo(string _cardid)
        {
            this.cardid = int.Parse(_cardid);
            this.LoadData();
        }
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_rankinfo where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else if (cardid != 0)
            {
                _sql += " and cardid=" + this.cardid;
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
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                score = Convert.IsDBNull(dr["score"]) ? 0 : Convert.ToInt32(dr["score"]);
                overdays = Convert.IsDBNull(dr["overdays"]) ? 0 : Convert.ToInt32(dr["overdays"]);
                des = Convert.IsDBNull(dr["des"]) ? "" : Convert.ToString(dr["des"]);
                cardid = Convert.IsDBNull(dr["cardid"]) ? 0 : Convert.ToInt32(dr["cardid"]);
                create_time = Convert.IsDBNull(dr["create_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["create_time"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        public void AddNew()
        {
            id = 0;
            name = "";
            score = 0;
            overdays = 0;
            des = "";
            cardid = 0;
            create_time = DateTime.Now;
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_rankinfo where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.name, this.score, this.overdays, this.des);
            }
            else
            {
                this.myInsertMethod(this.name, this.score, this.overdays, this.des, this.cardid, this.create_time);
            }
        }
        private void myUpdateMethod(int _id, string _name, int _score, int _overdays, string _des)
        {
            string sql = "update B2C_rankinfo set name=@name,score=@score,overdays=@overdays,des=@des where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@name", _name), 
                    new SqlParameter("@score", _score), 
                    new SqlParameter("@overdays", _overdays), 
                    new SqlParameter("@des", _des), 
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
        private void myInsertMethod(string _name, int _score, int _overdays, string _des, int _cardid, DateTime _create_time)
        {
            string sql = "insert into B2C_rankinfo (name,score,overdays,des,cardid,create_time) values (@name,@score,@overdays,@des,@cardid,@create_time)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@name", _name), 
                    new SqlParameter("@score",_score), 
                    new SqlParameter("@overdays", _overdays), 
                    new SqlParameter("@des",_des), 
                    new SqlParameter("@cardid", _cardid), 
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
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_rankinfo where id in (" + _ids + ")";
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
        /// <summary>
        /// 生成对应的等级信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="wid"></param>
        public static void OpenCard(int id) // , int wid
        {
            try
            {
                B2C_user_rank _bur = new B2C_user_rank();
                B2C_vipcard _bv = new B2C_vipcard(); //wid.ToString()
                if (_bv.id != 0)
                {
                    string _sql = "top(1) id";
                    string _where = "cardid in(select id from B2C_vipcard where is_open=1)"; //wid=" + wid + " and
                    DataTable dt = B2C_rankinfo.GetList(_sql, _where);
                    if (dt.Rows.Count == 1)
                    {
                        _bur.uid = id;
                        _bur.rankid = Convert.ToInt32(dt.Rows[0]["id"]);
                        _bur.card_number = _bv.pre_name + _bv.acc_card.ToString("00000");
                        _bur.Update();
                        _bv.acc_card = _bv.acc_card + 1;
                        _bv.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// VIP等级提升
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="wid"></param>
        public static void Upgrade(int uid, int wid)
        {
            try
            {
                string _sql = "ac_money";
                string _where = " ptid=1 and ac_money>0 and uid=" + uid;
                //找到积分的操作记录,并且是添加的记录，且和会员对应起来
                DataTable dt = B2C_AccOperate.GetList(_sql, _where);
                double item = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    item = item + Convert.ToDouble(dr["ac_money"]);
                }
                //找到特权和等级卡关联表
                B2C_user_rank _bur = new B2C_user_rank(uid.ToString());
                //找到特权关联表等级卡ID对应的等级信息
                B2C_rankinfo _br = new B2C_rankinfo(_bur.rankid);
                //找到会员卡信息
                B2C_vipcard _bv = new B2C_vipcard(wid.ToString());
                int _score = _br.score;
                _sql = "*";
                int _rankID = 0;
                _where = "cardid=" + _bv.id + "order by score desc";//根据会员卡ID找到对应的等级信息
                DataTable _dengji = B2C_rankinfo.GetList(_sql, _where);
                Dictionary<int, int> dic = new Dictionary<int, int>();
                foreach (DataRow dr in _dengji.Rows)
                {
                    if (Convert.ToDouble(dr["score"]) <= item)
                    {
                        _rankID = Convert.ToInt32(dr["id"]);
                        break;
                        //dic.Add(Convert.ToInt32(dr["id"]), Convert.ToInt32(item) - Convert.ToInt32(dr["score"]));
                    }
                }
                //dic.OrderBy(s => s.Value).Take(1);
                //foreach (int id in dic.Keys) {
                //    _rankID = id;
                //}
                _bur.rankid = _rankID;
                _bur.Update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string RankinfoName(int _id)
        {
            string _dengji_name = "未通过认证";
            string _sql = string.Format("select top 1 name from B2C_rankinfo where id=(select rankid from B2C_user_rank where uid={0})", _id);
            DataTable _dt = comfun.GetDataTableBySQL(_sql);
            if (_dt.Rows.Count > 0)
            {
                _dengji_name = _dt.Rows[0]["name"].ToString();
            }
            return _dengji_name;

        }
    }
}