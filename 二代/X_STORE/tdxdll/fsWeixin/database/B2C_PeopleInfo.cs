using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tdx.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    /// <summary>
    /// 日志操作类
    /// </summary>
    public class B2C_PeopleInfo
    {
        public int id = 0;

        public string wwv = "";
        public string nicheng = "";
        public string fakeID = "";
        public string weiName = "";
        public string xingbie = "";
        public string shengfen = "";

        public string chengshi = "";
        public string touxiang = "";
        public string guanzhutime = DateTime.Now.ToString();
        public string yuyan = "";

        public int memb_id = 0;

        public B2C_PeopleInfo() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id">id或memb_id</param>
        /// <param name="flag">1标识id ，2表示memb_id</param>
        public B2C_PeopleInfo(int _id, int flag)
        {
            if (flag == 1)
            {
                id = _id;
            }
            else if (flag == 2)
                memb_id = _id;
            this.load();
        }
        public B2C_PeopleInfo(string _wwv)
        {
            wwv = _wwv;
            this.load();
        }

        private void load()
        {
            string sql = "";
            if (id != 0)
            {
                sql = "select * from B2C_PeopleInfo where id=" + id + "";
            }
            else if (memb_id != 0)
                sql = "select * from B2C_PeopleInfo where memb_id=" + memb_id + "";
            else if (wwv != "")
                sql = "select * from B2C_PeopleInfo where wwv=" + wwv + "";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
               

                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);

                    wwv = Convert.IsDBNull(dt.Rows[0]["wwv"]) ? "" : Convert.ToString(dt.Rows[0]["wwv"]);
                    nicheng = Convert.IsDBNull(dt.Rows[0]["nicheng"]) ? "" : Convert.ToString(dt.Rows[0]["nicheng"]);
                    fakeID = Convert.IsDBNull(dt.Rows[0]["fakeID"]) ? "" : Convert.ToString(dt.Rows[0]["fakeID"]);
                    weiName = Convert.IsDBNull(dt.Rows[0]["weiName"]) ? "" : Convert.ToString(dt.Rows[0]["weiName"]);
                    xingbie = Convert.IsDBNull(dt.Rows[0]["xingbie"]) ? "" : Convert.ToString(dt.Rows[0]["xingbie"]);
                    shengfen = Convert.IsDBNull(dt.Rows[0]["shengfen"]) ? "" : Convert.ToString(dt.Rows[0]["shengfen"]);
                    chengshi = Convert.IsDBNull(dt.Rows[0]["chengshi"]) ? "" : Convert.ToString(dt.Rows[0]["chengshi"]);
                    touxiang = Convert.IsDBNull(dt.Rows[0]["touxiang"]) ? "" : Convert.ToString(dt.Rows[0]["touxiang"]);
                    guanzhutime = Convert.IsDBNull(dt.Rows[0]["guanzhutime"]) ? "" : Convert.ToString(dt.Rows[0]["guanzhutime"]);
                    yuyan = Convert.IsDBNull(dt.Rows[0]["yuyan"]) ? "" : Convert.ToString(dt.Rows[0]["yuyan"]);
                    memb_id = Convert.IsDBNull(dt.Rows[0]["memb_id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["memb_id"]);
                
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        public void myInsert(string _wwv, string _nicheng, string _fakeID, string _weiName, string _xingbie, string _shengfen, string _chengshi, string _touxiang, string _guanzhutime, string _yuyan, int _memb_id)
        {
            try
            {
                string sql = "insert into B2C_PeopleInfo (wwv,nicheng,fakeID,weiName,xingbie,shengfen,chengshi,touxiang,guanzhutime,yuyan,memb_id) values (@wwv,@nicheng,@fakeID,@weiName,@xingbie,@shengfen,@chengshi,@touxiang,@guanzhutime,@yuyan,@memb_id)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wwv", _wwv), 
                    new SqlParameter("@nicheng", _nicheng),
                    new SqlParameter("@fakeID", _weiName),
                    new SqlParameter("@weiName", _weiName), 
                    new SqlParameter("@xingbie", _xingbie),
                    new SqlParameter("@shengfen",  _shengfen),
                    new SqlParameter("@chengshi", _chengshi),
                    new SqlParameter("@touxiang", _touxiang),
                    new SqlParameter("@guanzhutime", _guanzhutime),
                    new SqlParameter("@yuyan", _yuyan),
                    new SqlParameter("@memb_id", _memb_id)
                };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }


        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_PeopleInfo where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        /// <summary>
        /// 修改一条新的记录
        /// </summary>
        private void myUpdate(int _id, string _wwv, string _nicheng, string _fakeID, string _weiName, string _xingbie, string _shengfen, string _chengshi, string _touxiang, string _guanzhutime, string _yuyan, int _memb_id)
        {
            try
            {
                string sql = "update B2C_PeopleInfo set wwv=@wwv,nicheng=@nicheng,fakeID=@fakeID,weiName=@weiName,xingbie=@xingbie,shengfen=@shengfen,chengshi=@chengshi,touxiang=@touxiang,guanzhutime=@guanzhutime,yuyan=@yuyan,memb_id=@memb_id  where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wwv", _wwv), 
                    new SqlParameter("@nicheng", _nicheng),
                    new SqlParameter("@fakeID", _weiName),
                    new SqlParameter("@weiName", _weiName), 
                    new SqlParameter("@xingbie", _xingbie),
                    new SqlParameter("@shengfen",  _shengfen),
                    new SqlParameter("@chengshi", _chengshi),
                    new SqlParameter("@touxiang", _touxiang),
                    new SqlParameter("@guanzhutime", _guanzhutime),
                    new SqlParameter("@yuyan", _yuyan),
                    new SqlParameter("@memb_id", _memb_id)
                };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }


        /// <summary>
        /// 修改一条新的记录
        /// </summary>



        /// <summary>
        /// 删除一条数据
        /// </summary> 
        public static int myDel(int _id)
        {
            string sql = "delete from B2C_PeopleInfo where id=" + _id + "";
            try
            {
                return comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(wwv, nicheng, fakeID, weiName, xingbie, shengfen, chengshi, touxiang, guanzhutime, yuyan, memb_id);
            }
            else
            {
                this.myUpdate(id, wwv, nicheng, fakeID, weiName, xingbie, shengfen, chengshi, touxiang, guanzhutime, yuyan, memb_id);
            }
        }
        /// <summary>
        /// 添加默认方法
        /// </summary>
        public void AddNew()
        {
            id = 0;

            wwv = "";
            nicheng = "";
            fakeID = "";
            weiName = "";
            xingbie = "";
            shengfen = "";

            chengshi = "";
            touxiang = "";
            guanzhutime = DateTime.Now.ToString();
            yuyan = "";
            memb_id = 0;
        }





    }
}