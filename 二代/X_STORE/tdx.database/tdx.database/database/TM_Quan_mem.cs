using System;
using System.Data;
using System.Data.SqlClient;
using Creatrue.kernel;

namespace tdx.database
{
    public class TM_Quan_mem
    {
        public int id = 0;
        public int qid = 0;
        public int qnum = 0;
        public int mid = 0;
        public string openid = "";
        public DateTime regtime = DateTime.Now; 

       #region " No Parameter "
        public TM_Quan_mem()
        {
        }
        #endregion

        #region " With Parameter "
        public TM_Quan_mem(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        private void LoadData()
        {
            string _sql = "SELECT * ";
            _sql += " FROM TM_Quan_mem WHERE id = " + id;

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("TM_Quan_mem：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    mid = Convert.IsDBNull(dt.Rows[0]["mid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mid"]);
                    openid = Convert.IsDBNull(dt.Rows[0]["openid"]) ? "" : Convert.ToString(dt.Rows[0]["openid"]);
                    qid = Convert.IsDBNull(dt.Rows[0]["qid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["qid"]);
                    qnum = Convert.IsDBNull(dt.Rows[0]["qnum"]) ? 0 : Convert.ToInt32(dt.Rows[0]["qnum"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
   
                   
                }
            }
            else
            {
                throw new NotSupportedException("TM_Quan_mem：" + id + "不存在");
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        private void MyInsertMethod(int _qid,int _qnum,int _mid,string _openid)
        {

            string queryString = " INSERT INTO TM_Quan_mem (qid,qnum,mid,openid)";
            queryString += " VALUES (@qid,@qnum,@mid,@openid)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@qid", _qid),
                new SqlParameter("@qnum", _qnum), 
                new SqlParameter("@mid", _mid),
                new SqlParameter("@openid",_openid) 
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

        private void MyUpdateMethod(int _id, int _qid, int _qnum, int _mid, string _openid)
        {
            string queryString = "UPDATE TM_Quan_mem SET qid=@qid,qnum=@qnum,mid=@mid,openid=@openid WHERE id =" + _id;
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@qid", _qid),
                new SqlParameter("@qnum", _qnum),
                new SqlParameter("@mid", _mid),
             new SqlParameter("@openid",_openid) 
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
            qid = 0;
            qnum = 0;
            mid = 0;
            openid = ""; 
            regtime = DateTime.Now; 
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(qid,qnum,mid, openid);
            }
            else
            {
                this.MyUpdateMethod(id, qid, qnum, mid, openid);
            }
        }

        public static int Delete(int _id)
        {
            try
            {
                return comfun.DelByInt("TM_Quan_mem", "id", _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("TM_Quan_mem：" + _id + "删除失败");
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

            string sql = "delete from TM_Quan_mem where id in (" + _ids + ")";
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
            string sql = "select count(*) from TM_Quan_mem where 1=1 and " + _sql ;
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
