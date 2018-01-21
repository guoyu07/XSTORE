using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Creatrue.kernel;

namespace tdx.database
{
    public class TM_jian_log
    {
        public int id = 0;
        public int mid = 0;
        public string openid = "";
        public int jid = 0;
        public string jtitle = "";
        public string orderNo = "";
        public decimal orderMoney = 0;
        public decimal orderJMoney = 0;
        public DateTime regtime = DateTime.Now;

        #region " No Parameter "
        public TM_jian_log()
        {
        }
        #endregion

        #region " With Parameter "
        public TM_jian_log(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        private void LoadData()
        {
            string _sql = "SELECT * ";
            _sql += ",(select j_title from TM_jian where tm_jian.id=tm_jian_log.jid) as j_title";
            _sql += " FROM TM_jian_log WHERE id = " + id;

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("TM_jian_log：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    mid = Convert.IsDBNull(dt.Rows[0]["mid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mid"]);
                    openid = Convert.IsDBNull(dt.Rows[0]["openid"]) ? "" : Convert.ToString(dt.Rows[0]["openid"]);
                    jid = Convert.IsDBNull(dt.Rows[0]["jid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["jid"]);
                    jtitle = Convert.IsDBNull(dt.Rows[0]["j_title"]) ? "" : Convert.ToString(dt.Rows[0]["j_title"]);
                    orderNo = Convert.IsDBNull(dt.Rows[0]["orderNo"]) ? "" : Convert.ToString(dt.Rows[0]["orderNo"]);
                    orderMoney = Convert.IsDBNull(dt.Rows[0]["orderMoney"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["orderMoney"]);
                    orderJMoney = Convert.IsDBNull(dt.Rows[0]["orderJMoney"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["orderJMoney"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);

                }
            }
            else
            {
                throw new NotSupportedException("TM_jian_log：" + id + "不存在");
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        private void MyInsertMethod(int _mid, string _openid, int _jid, string _orderNo, decimal _orderMoney, decimal _orderJMoney)
        {

            string queryString = " INSERT INTO TM_jian_log (mid,openid,jid,orderNo,orderMoney,orderJmoney)";
            queryString += " VALUES (@mid,@openid,@jid,@orderNo,@orderMoney,@orderJmoney)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@mid", _mid),
                new SqlParameter("@openid", _openid),
                new SqlParameter("@jid", _jid),
                new SqlParameter("@orderNo", _orderNo),
            new SqlParameter("@orderMoney",_orderMoney),
            new SqlParameter("@orderJmoney",_orderJMoney)
            };
            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        private void MyUpdateMethod(int _id, int _mid, string _openid, int _jid, string _orderNo, decimal _orderMoney, decimal _orderJMoney)
        {
            string queryString = "UPDATE TM_jian_log SET mid=@mid,openid=@openid,jid=@jid,orderNo=@orderNo,orderMoney=@orderMoney,orderJmoney=@orderJmoney WHERE id =" + id;
            SqlParameter[] paras = new SqlParameter[] { 
           new SqlParameter("@mid", _mid),
                new SqlParameter("@openid", _openid),
                new SqlParameter("@jid", _jid),
                new SqlParameter("@orderNo", _orderNo),
            new SqlParameter("@orderMoney",_orderMoney),
            new SqlParameter("@orderJmoney",_orderJMoney)
            };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        #region " 添加、修改、删除 "
        public void AddNew()
        {
            id = 0;
            mid = 0;
            openid = "";
            jid = 0;
            jtitle = "";
            orderNo = "";
            orderMoney = 0; 
            regtime = DateTime.Now; 
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(mid,openid,jid,orderNo,orderMoney ,orderJMoney );     
            }
            else
            {
                this.MyUpdateMethod(id, mid, openid, jid, orderNo, orderMoney, orderJMoney);     
            }
        }

        public static int Delete(int _id)
        {
            try
            {
                return comfun.DelByInt("TM_jian_log", "id", _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("TM_jian_log：" + _id + "删除失败");
            }
        }




        #endregion


        /// <summary>
        /// 一次彻底删除一组监控
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from TM_jian_log where id in (" + _ids + ")";
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
        /// 读取表数据
        /// </summary>
        /// <param name="_sql"></param>
        /// <returns></returns>
        public static DataTable GetList(int _page, string _dzd, string _tname, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;
            if (_page <= 0)
            {
                _page = 0 + 1;
            }
            string sql = "select count(*) from TM_jian_log where 1=1 and " + _sql;
            totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
            totalpage = totalcount / pagesize;
            if (totalcount % pagesize != 0)
            {
                totalpage = totalpage + 1;
            }
            else if (totalpage == 0)
            {
                totalpage = 1;
            }

            beginItem = pagesize * (_page - 1);
            endItem = pagesize * _page - 1;
            if (endItem > (totalcount - 1))
            {
                endItem = totalcount - 1;
            }

            if (beginItem < 0)
            {
                beginItem = 0;
            }
            try
            {
                DataTable dt = comfun.GetDataTableBySQL("select " + _dzd + " from " + _tname + " where " + _sql + " order by id desc");
                DataTable dt2 = dt.Clone();
                if (dt.Rows.Count > 0)
                {
                    for (int i = beginItem; i <= endItem; i++)
                    {
                        dt2.ImportRow(dt.Rows[i]);
                    }
                }
                return dt2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
