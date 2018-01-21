using System;
using System.Data;
using System.Data.SqlClient;
using Creatrue.kernel;

namespace tdx.database
{
    public class TM_jian
    {
        public int id = 0;
        public int c_id = 0;
        public string j_title = "";
        public decimal j_Tmoney = 0;
        public decimal j_Dmoney = 0;
        public DateTime j_Bdate = DateTime.Now;
        public DateTime j_Edate = DateTime.Now;
        public DateTime regtime = DateTime.Now; 

       #region " No Parameter "
        public TM_jian()
        {
        }
        #endregion

        #region " With Parameter "
        public TM_jian(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        private void LoadData()
        {
            string _sql = "SELECT * ";
            _sql += " FROM TM_jian WHERE id = " + id;

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("TM_jian：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    c_id = Convert.IsDBNull(dt.Rows[0]["c_id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_id"]);

                    j_title = Convert.IsDBNull(dt.Rows[0]["j_title"]) ? "" : Convert.ToString(dt.Rows[0]["j_title"]);
                    j_Tmoney = Convert.IsDBNull(dt.Rows[0]["j_Tmoney"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["j_Tmoney"]);
                    j_Dmoney = Convert.IsDBNull(dt.Rows[0]["j_Dmoney"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["j_Dmoney"]);
                    j_Bdate = Convert.IsDBNull(dt.Rows[0]["j_Bdate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["j_Bdate"]);
                    j_Edate = Convert.IsDBNull(dt.Rows[0]["j_Edate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["j_Edate"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
   
                }
            }
            else
            {
                throw new NotSupportedException("TM_jian：" + id + "不存在");
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        private void MyInsertMethod(int _c_id,string _jtitle, decimal _j_Tmoney, decimal _j_Dmoney, DateTime _j_Bdate,DateTime _j_Edate)
        {

            string queryString = " INSERT INTO TM_jian (c_id,j_title,j_Tmoney,j_Dmoney,j_Bdate,j_Edate)";
            queryString += " VALUES (@c_id,@jtitle,@jTmoney,@jDmoney,@jBdate,@jEdate)";
            SqlParameter[] paras = new SqlParameter[] { 

                new SqlParameter("@c_id", _c_id),
                new SqlParameter("@jtitle", _jtitle),
            new SqlParameter("@jTmoney",_j_Tmoney),
            new SqlParameter("@jDmoney",_j_Dmoney),
            new SqlParameter("@jBdate",_j_Bdate),
            new SqlParameter("@jEdate",_j_Edate) 
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

        private void MyUpdateMethod(int _id,int _c_id, string _jtitle, decimal _j_Tmoney, decimal _j_Dmoney, DateTime _j_Bdate, DateTime _j_Edate)
        {
            string queryString = "UPDATE TM_jian SET c_id=@c_id, j_title=@jtitle,j_Tmoney=@jTmoney,j_Dmoney=@jDmoney,j_Bdate=@jBdate,j_Edate=@jEdate WHERE id =" + _id;
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@jtitle", _jtitle),
            new SqlParameter("@c_id", _c_id),
            new SqlParameter("@jTmoney",_j_Tmoney),
            new SqlParameter("@jDmoney",_j_Dmoney),
            new SqlParameter("@jBdate",_j_Bdate),
            new SqlParameter("@jEdate",_j_Edate) 
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
            c_id = 0;
            j_title = "";
            j_Tmoney = 0;
            j_Dmoney = 0;
            j_Bdate = DateTime.Now;
            j_Edate = DateTime.Now;
            regtime = DateTime.Now; 
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(c_id,j_title,j_Tmoney,j_Dmoney,j_Bdate,j_Edate);
            }
            else
            {
                this.MyUpdateMethod(id,c_id,j_title, j_Tmoney, j_Dmoney, j_Bdate, j_Edate);
            }
        }

        public static int Delete(int _id)
        {
            try
            {
                return comfun.DelByInt("TM_jian", "id", _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("TM_jian：" + _id + "删除失败");
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

            string sql = "delete from TM_jian where id in (" + _ids + ")";
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
            string sql = "select count(*) from TM_jian where 1=1 and " + _sql ;
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
            {//
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
