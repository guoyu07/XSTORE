using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Creatrue.kernel;

namespace tdx.database
{
    public class TM_Quan
    {
        public int id = 0;
        public string q_title = "";
        public decimal q_Tmoney = 0;
        public decimal q_money = 0;
        public decimal q_Getmoney = 0;
        public int q_num = 0;
        public DateTime q_Bdate = DateTime.Now;
        public DateTime q_Edate = DateTime.Now;
        public DateTime regtime = DateTime.Now;
        public int types = 0;

        #region " No Parameter "
        public TM_Quan()
        {
        }
        #endregion

        #region " With Parameter "
        public TM_Quan(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        private void LoadData()
        {
            string _sql = "SELECT * ";
            _sql += " FROM TM_Quan WHERE id = " + id;

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("TM_Quan：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    q_title = Convert.IsDBNull(dt.Rows[0]["q_title"]) ? "" : Convert.ToString(dt.Rows[0]["q_title"]);
                    q_Tmoney = Convert.IsDBNull(dt.Rows[0]["q_Tmoney"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["q_Tmoney"]);
                    q_Getmoney = Convert.IsDBNull(dt.Rows[0]["q_Getmoney"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["q_Getmoney"]);
                    q_money = Convert.IsDBNull(dt.Rows[0]["q_money"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["q_money"]);
                    q_num = Convert.IsDBNull(dt.Rows[0]["q_num"]) ? 0 : Convert.ToInt32(dt.Rows[0]["q_num"]);
                    q_Bdate = Convert.IsDBNull(dt.Rows[0]["q_Bdate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["q_Bdate"]);
                    q_Edate = Convert.IsDBNull(dt.Rows[0]["q_Edate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["q_Edate"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                    types = Convert.IsDBNull(dt.Rows[0]["types"]) ? 0 : Convert.ToInt32(dt.Rows[0]["types"]);

                }
            }
            else
            {
                throw new NotSupportedException("TM_Quan：" + id + "不存在");
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        private void MyInsertMethod(string _qtitle, decimal _qTmoney, decimal _qGetoney, decimal _qmoney, int _qnum, DateTime _qBdate, DateTime _qEdate, int _types)
        {

            string queryString = " INSERT INTO TM_Quan(q_title,q_Tmoney,q_Getmoney,q_money,q_num,q_Bdate,q_Edate,types)";
            queryString += " VALUES (@qtitle,@_qTmoney,@_qgetoney,@qmoney,@qnum,@qBdate,@qEdate,@types)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@qtitle", _qtitle),
                            new SqlParameter("@_qTmoney",_qTmoney),
                            new SqlParameter("@_qgetoney",_qGetoney),
            new SqlParameter("@qmoney",_qmoney),
            new SqlParameter("@qnum",_qnum),
            new SqlParameter("@qBdate",_qBdate),
            new SqlParameter("@qEdate",_qEdate),
                        new SqlParameter("@types",_types)
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

        private void MyUpdateMethod(int _id, string _qtitle, decimal _qTmoney, decimal _qGetoney, decimal _qmoney, int _qnum, DateTime _qBdate, DateTime _qEdate, int _types)
        {
            string queryString = "UPDATE TM_Quan SET q_title=@qtitle,q_Tmoney=@qTmoney,q_Getmoney=@_qGetoney,q_money=@qmoney,q_num=@qnum,q_Bdate=@qBdate,q_Edate=@qEdate,types=@types WHERE id =" + _id;
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@qtitle", _qtitle),
                        new SqlParameter("@qTmoney",_qTmoney),
                        new SqlParameter("@_qGetoney",_qGetoney),
            new SqlParameter("@qmoney",_qmoney),
            new SqlParameter("@qnum",_qnum),
            new SqlParameter("@qBdate",_qBdate),
            new SqlParameter("@qEdate",_qEdate),
                        new SqlParameter("@types",_types)
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
            q_title = "";
            q_Tmoney = 0;
            q_Getmoney = 0;
            q_money = 0;
            q_num = 0;
            q_Bdate = DateTime.Now;
            q_Edate = DateTime.Now;
            regtime = DateTime.Now;
            types = 0;

        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(q_title, q_Tmoney, q_Getmoney, q_money, q_num, q_Bdate, q_Edate,types);
            }
            else
            {
                this.MyUpdateMethod(id, q_title, q_Tmoney, q_Getmoney, q_money, q_num, q_Bdate, q_Edate,types);
            }
        }

        public static int Delete(int _id)
        {
            try
            {
                return comfun.DelByInt("TM_Quan", "id", _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("TM_Quan：" + _id + "删除失败");
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

            string sql = "delete from TM_Quan where id in (" + _ids + ")";
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
            string sql = "select count(*) from TM_Quan where 1=1 and " + _sql;
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
