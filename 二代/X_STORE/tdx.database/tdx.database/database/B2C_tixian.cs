using System;
using System.Data;
using System.Data.SqlClient;
using Creatrue.kernel;

namespace tdx.database
{
    public class B2C_tixian
    {
        public int id = 0;
        public int mid = 0;
        public decimal tx_money = 0;
        public DateTime regtime = DateTime.Now;
        public int isActive = 0;

       #region " No Parameter "
        public B2C_tixian()
        {
        }
        #endregion

        #region " With Parameter "
        public B2C_tixian(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        private void LoadData()
        {
            string _sql = "SELECT * ";
            _sql += " FROM B2C_tixian WHERE id = " + id;

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_tixian：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    mid = Convert.IsDBNull(dt.Rows[0]["mid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mid"]);
                    tx_money = Convert.IsDBNull(dt.Rows[0]["tx_money"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["tx_money"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                    isActive = Convert.IsDBNull(dt.Rows[0]["isActive"]) ? 0 : Convert.ToInt32(dt.Rows[0]["isActive"]);
                   
                }
            }
            else
            {
                throw new NotSupportedException("B2C_tixian：" + id + "不存在");
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        private void MyInsertMethod(int _mid, decimal _tx_money, int _isActive)
        {

            string queryString = " INSERT INTO B2C_tixian (mid,tx_money,isActive)";
            queryString += " VALUES (@mid,@tx_money,@isActive)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@mid", _mid),
            new SqlParameter("@tx_money",_tx_money),
            new SqlParameter("@isActive",_isActive)
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

        private void MyUpdateMethod(int _id, int _mid, decimal _tx_money, int _isActive)
        {
            string queryString = "UPDATE B2C_tixian SET mid=@mid,tx_money=@tx_money,isActive=@isActive WHERE id =" + id;
            SqlParameter[] paras = new SqlParameter[] { 
           new SqlParameter("@mid", _mid),
            new SqlParameter("@tx_money",_tx_money),
            new SqlParameter("@isActive",_isActive)
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
            tx_money = 0;
            regtime = DateTime.Now;
            isActive = 0;
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(mid, tx_money,isActive);
            }
            else
            {
                this.MyUpdateMethod(id, mid, tx_money, isActive);
            }
        }

        public static int Delete(int _id)
        {
            try
            {
                return comfun.DelByInt("B2C_tixian", "id", _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("B2C_tixian：" + _id + "删除失败");
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

            string sql = "delete from B2C_tixian where id in (" + _ids + ")";
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
            string sql = "select count(*) from B2C_tixian where 1=1 and " + _sql ;
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
