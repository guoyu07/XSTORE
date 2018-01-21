using System;
using Creatrue.kernel;
using System.Data;
using tdx.database.Common_Pay.WeiXinPay;

namespace tdx.database.database
{
    public class B2C_inq
    {
        string connectionString = consts.constr;
        public int id = 0;
        public DateTime regtime = System.DateTime.Now;
        //提交IP
        public string Ips = "";
        //提交来源网址
        public string i_url = "";
        //提交者系统
        public string i_system = "";
        //提交者浏览器
        public string i_IE = "";
        //提交者语言
        public string i_lang = "";

        //那类型提交
        public string cname = "";
        //提交标题
        public string i_title = "";
        //提交内容
        public string i_content = "";
        //提交Email
        public string i_email = "";
        //称呼
        public string i_name = "";
        //电话
        public string i_tel = "";

        //查看次数
        public int i_isV = 0;
        //最新查看时间，缺省是2000-1-1，表示未回复过
        public DateTime i_Vtime = System.DateTime.Parse("2000-01-01");
        //回复次数
        public int i_isR = 0;
        //回复时间，缺省是2000-1-1，表示未回复过
        public DateTime i_Rtime = System.DateTime.Parse("2000-01-01");


        #region " No Parameter "
        public B2C_inq()
        {
        }
        #endregion

        #region " With Parameter "
        public B2C_inq(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        #region " Private Function "
        private void LoadData()
        {
            DataTable dt = comfun.GetDataTableBySQL("SELECT * FROM b2c_inq  WHERE (id = " + id + ")");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("b2c_inq：" + id + "不唯一");
                }
                else
                {
                    id = (Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]));
                    cname = (Convert.IsDBNull(dt.Rows[0]["cname"]) ? "" : Convert.ToString(dt.Rows[0]["cname"]));
                    i_title = (Convert.IsDBNull(dt.Rows[0]["i_title"]) ? "" : dt.Rows[0]["i_title"].ToString());
                    i_content = (Convert.IsDBNull(dt.Rows[0]["i_content"]) ? "" : dt.Rows[0]["i_content"].ToString());
                    i_email = (Convert.IsDBNull(dt.Rows[0]["i_email"]) ? "" : dt.Rows[0]["i_email"].ToString());
                    i_tel = (Convert.IsDBNull(dt.Rows[0]["i_tel"]) ? "" : dt.Rows[0]["i_tel"].ToString());
                    i_name = (Convert.IsDBNull(dt.Rows[0]["i_name"]) ? "" : dt.Rows[0]["i_name"].ToString());

                    regtime = (Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]));
                    Ips = (Convert.IsDBNull(dt.Rows[0]["Ips"]) ? "" : dt.Rows[0]["Ips"].ToString());
                    i_url = (Convert.IsDBNull(dt.Rows[0]["i_url"]) ? "" : dt.Rows[0]["i_url"].ToString());
                    i_system = (Convert.IsDBNull(dt.Rows[0]["i_system"]) ? "" : dt.Rows[0]["i_system"].ToString());
                    i_IE = (Convert.IsDBNull(dt.Rows[0]["i_IE"]) ? "" : dt.Rows[0]["i_IE"].ToString());
                    i_lang = (Convert.IsDBNull(dt.Rows[0]["i_lang"]) ? "" : dt.Rows[0]["i_lang"].ToString());

                    i_isV = (Convert.IsDBNull(dt.Rows[0]["i_isV"]) ? 0 : Convert.ToInt32(dt.Rows[0]["i_isV"]));
                    i_Vtime = (Convert.IsDBNull(dt.Rows[0]["i_Vtime"]) ? System.DateTime.Parse("2000-01-01") : Convert.ToDateTime(dt.Rows[0]["i_Vtime"]));
                    i_isR = (Convert.IsDBNull(dt.Rows[0]["i_isR"]) ? 0 : Convert.ToInt32(dt.Rows[0]["i_isR"]));
                    i_Rtime = (Convert.IsDBNull(dt.Rows[0]["i_Rtime"]) ? System.DateTime.Parse("2000-01-01") : Convert.ToDateTime(dt.Rows[0]["i_Rtime"]));

                }
            }
            else
            {
                throw new NotSupportedException("b2c_inq：" + id + "不存在");
            }
        }

        private int MyInsertMethod(string _ips, string _iurl, string _isystem, string _iie, string _ilang, string _cname, string _ititle, string _icontent, string _iemail, string _iname,
        string _itel)
        {

            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

            string queryString = "INSERT INTO [b2c_inq] ([ips],[i_url],[i_system],[i_ie],[i_lang],[cname],[i_title],[i_content],[i_email],[i_name],[i_tel]) VALUES (";
            queryString += "@ips,@i_url,@i_system,@i_ie,@i_lang,@cname,@i_title,@i_content,@i_email,@i_name,@i_tel)";
            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandText = queryString;
            dbCommand.Connection = dbConnection;

            System.Data.IDataParameter dbParam_g_fac = new System.Data.SqlClient.SqlParameter();
            dbParam_g_fac.ParameterName = "@ips";
            dbParam_g_fac.Value = _ips;
            dbParam_g_fac.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_fac);
            System.Data.IDataParameter dbParam_g_keyword = new System.Data.SqlClient.SqlParameter();
            dbParam_g_keyword.ParameterName = "@i_url";
            dbParam_g_keyword.Value = _iurl;
            dbParam_g_keyword.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_keyword);
            System.Data.IDataParameter dbParam_g_des = new System.Data.SqlClient.SqlParameter();
            dbParam_g_des.ParameterName = "@i_system";
            dbParam_g_des.Value = _isystem;
            dbParam_g_des.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_des);
            System.Data.IDataParameter dbParam_g_gif = new System.Data.SqlClient.SqlParameter();
            dbParam_g_gif.ParameterName = "@i_ie";
            dbParam_g_gif.Value = _iie;
            dbParam_g_gif.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_gif);
            System.Data.IDataParameter dbParam_g_price_M = new System.Data.SqlClient.SqlParameter();
            dbParam_g_price_M.ParameterName = "@i_lang";
            dbParam_g_price_M.Value = _ilang;
            dbParam_g_price_M.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_price_M);
            System.Data.IDataParameter dbParam_cno = new System.Data.SqlClient.SqlParameter();
            dbParam_cno.ParameterName = "@cname";
            dbParam_cno.Value = _cname;
            dbParam_cno.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_cno);
            System.Data.IDataParameter dbParam_bno = new System.Data.SqlClient.SqlParameter();
            dbParam_bno.ParameterName = "@i_title";
            dbParam_bno.Value = _ititle;
            dbParam_bno.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_bno);
            System.Data.IDataParameter dbParam_g_name = new System.Data.SqlClient.SqlParameter();
            dbParam_g_name.ParameterName = "@i_content";
            dbParam_g_name.Value = _icontent;
            dbParam_g_name.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_name);
            System.Data.IDataParameter dbParam_g_unit = new System.Data.SqlClient.SqlParameter();
            dbParam_g_unit.ParameterName = "@i_email";
            dbParam_g_unit.Value = _iemail;
            dbParam_g_unit.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_unit);
            System.Data.IDataParameter dbParam_g_type = new System.Data.SqlClient.SqlParameter();
            dbParam_g_type.ParameterName = "@i_name";
            dbParam_g_type.Value = _iname;
            dbParam_g_type.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_type);
            System.Data.IDataParameter dbParam_g_tel = new System.Data.SqlClient.SqlParameter();
            dbParam_g_tel.ParameterName = "@i_tel";
            dbParam_g_tel.Value = _itel;
            dbParam_g_tel.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_tel);


            int rowsAffected = 0;
            dbConnection.Open();
            try
            {
                rowsAffected = dbCommand.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }

            return rowsAffected;
        }

        private int MyUpdateMethod(string _ips, string _iurl, string _isystem, string _iie, string _ilang, string _cname, string _ititle, string _icontent, string _iemail, string _iname,
        string _itel, int id)
        {

            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

            string queryString = "UPDATE [b2c_inq] SET [ips]=@ips,[i_url]=@i_url,[i_system]=@i_system,[i_ie]=@i_ie,[i_lang]=@i_lang,[cname]=@cname,[i_title]=@i_title,[i_content]=@i_content,[i_email]=@i_email,[i_name]=@i_name,[i_tel]=@i_tel WHERE ([id] = @id)";
            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandText = queryString;
            dbCommand.Connection = dbConnection;

            System.Data.IDataParameter dbParam_g_fac = new System.Data.SqlClient.SqlParameter();
            dbParam_g_fac.ParameterName = "@ips";
            dbParam_g_fac.Value = _ips;
            dbParam_g_fac.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_fac);
            System.Data.IDataParameter dbParam_g_keyword = new System.Data.SqlClient.SqlParameter();
            dbParam_g_keyword.ParameterName = "@i_url";
            dbParam_g_keyword.Value = _iurl;
            dbParam_g_keyword.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_keyword);
            System.Data.IDataParameter dbParam_g_des = new System.Data.SqlClient.SqlParameter();
            dbParam_g_des.ParameterName = "@i_system";
            dbParam_g_des.Value = _isystem;
            dbParam_g_des.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_des);
            System.Data.IDataParameter dbParam_g_gif = new System.Data.SqlClient.SqlParameter();
            dbParam_g_gif.ParameterName = "@i_ie";
            dbParam_g_gif.Value = _iie;
            dbParam_g_gif.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_gif);
            System.Data.IDataParameter dbParam_g_price_M = new System.Data.SqlClient.SqlParameter();
            dbParam_g_price_M.ParameterName = "@i_lang";
            dbParam_g_price_M.Value = _ilang;
            dbParam_g_price_M.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_price_M);
            System.Data.IDataParameter dbParam_id = new System.Data.SqlClient.SqlParameter();
            dbParam_id.ParameterName = "@id";
            dbParam_id.Value = id;
            dbParam_id.DbType = System.Data.DbType.Int32;
            dbCommand.Parameters.Add(dbParam_id);
            System.Data.IDataParameter dbParam_cno = new System.Data.SqlClient.SqlParameter();
            dbParam_cno.ParameterName = "@cname";
            dbParam_cno.Value = _cname;
            dbParam_cno.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_cno);
            System.Data.IDataParameter dbParam_bno = new System.Data.SqlClient.SqlParameter();
            dbParam_bno.ParameterName = "@i_title";
            dbParam_bno.Value = _ititle;
            dbParam_bno.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_bno);
            System.Data.IDataParameter dbParam_g_name = new System.Data.SqlClient.SqlParameter();
            dbParam_g_name.ParameterName = "@i_content";
            dbParam_g_name.Value = _icontent;
            dbParam_g_name.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_name);
            System.Data.IDataParameter dbParam_g_unit = new System.Data.SqlClient.SqlParameter();
            dbParam_g_unit.ParameterName = "@i_email";
            dbParam_g_unit.Value = _iemail;
            dbParam_g_unit.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_unit);
            System.Data.IDataParameter dbParam_g_type = new System.Data.SqlClient.SqlParameter();
            dbParam_g_type.ParameterName = "@i_name";
            dbParam_g_type.Value = _iname;
            dbParam_g_type.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_type);
            System.Data.IDataParameter dbParam_g_tel = new System.Data.SqlClient.SqlParameter();
            dbParam_g_tel.ParameterName = "@i_tel";
            dbParam_g_tel.Value = _itel;
            dbParam_g_tel.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_g_tel);

            int rowsAffected = 0;
            dbConnection.Open();
            try
            {
                rowsAffected = dbCommand.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }

            return rowsAffected;
        }
        #endregion

        #region " 添加、修改、删除 "
        public void AddNew()
        {
            id = 0;
            cname = "";
            i_title = "";
            i_content = "";
            i_email = "";
            i_name = "";
            i_tel = "";

            Ips = "";
            regtime = System.DateTime.Now;
            i_url = "";
            i_system = "";
            i_IE = "";
            i_lang = "";

            i_isR = 0;
            i_Rtime = System.DateTime.Parse("2000-01-01");
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(this.Ips, this.i_url, this.i_system, this.i_IE, this.i_lang, this.cname, this.i_title, this.i_content, this.i_email, this.i_name,
                this.i_tel);
            }
            else
            {
                this.MyUpdateMethod(this.Ips, this.i_url, this.i_system, this.i_IE, this.i_lang, this.cname, this.i_title, this.i_content, this.i_email, this.i_name,
                this.i_tel, id);
            }
        }

        public void Delete()
        {
            try
            {
                comfun.DelByInt("b2c_inq", "id", id);
            }
            catch (Exception ex)
            {
                Log.WriteLog("b2c_inq", "删除失败", ex.ObjToStr());
                throw new NotSupportedException("b2c_inq：" + id + "删除失败");
            }
        }

        #endregion

        #region " 设置查看次数、回复次数等 "
        public void setView()
        {
            try
            {
                comfun.UpdateBySQL("update b2c_inq set i_isV=i_isV+1,i_Vtime=Now() where id=" + id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public void setReply()
        {
            try
            {
                comfun.UpdateBySQL("update b2c_inq set i_isR=i_isR+1,i_Rtime=Now() where id=" + id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region "共享方法"
        public static DataTable inqlist(string sql)
        {
            DataTable proTable = comfun.GetDataTableBySQL(sql);
            return proTable;
        }
        public static DataTable topInq(string sql)
        {
            DataTable proTable = comfun.GetDataTableBySQL(sql);
            return proTable;
        }

        public static DataTable inqlist(string _sql, int _pageIndex)
        {
            //Dim _querysql As String = "with c as (select row_number() over(order by id desc) as rown,* from b2c_inq where 1=1 and " & _sql & ") select top " & consts.pagesize_Txt & " * from c where rown > " & (_pageIndex - 1) * consts.pagesize_Txt
            //Return comfun.GetDataTableBySQL(_querysql)
            //修改成适应Access数据库
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from b2c_inq where 1=1 and " + _sql;
            totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
            totalpage = totalcount / pagesize;
            if (totalpage < totalcount / pagesize)
            {
                totalpage = totalpage + 1;
            }
            beginItem = pagesize * (_pageIndex - 1);
            endItem = pagesize * _pageIndex - 1;
            if (endItem > (totalcount - 1))
            {
                endItem = totalcount - 1;
            }
            if (beginItem < 0)
            {
                beginItem = 0;
            }

            sql = "select * from b2c_inq where 1=1 and " + _sql + " order by id desc";

            DataTable dt = comfun.GetDataTableBySQL(sql);

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
        public static DataTable inqlist(int _page, string _dzd, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from B2C_inq where 1=1 and " + _sql + " and 1=1";
            totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
            totalpage = totalcount / pagesize;
            if (totalpage < totalcount / pagesize)
            {
                totalpage = totalpage + 1;
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_inq where " + _sql + " and 1=1 order by id desc");
                DataTable dt2 = proTable.Clone();
                for (int i = beginItem; i <= endItem; i++)
                {
                    dt2.ImportRow(proTable.Rows[i]);
                }
                return dt2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete(string _ids)
        {
            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "Delete from B2c_inq where id in (" + _ids + ")";
            dbCommand.Connection = dbConnection;

            dbConnection.Open();
            try
            {
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("彻底删除操作失败");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static void Viewed(string _ids)
        {
            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "update B2c_inq set i_isV = i_isV + 1,i_Vtime = getDate() where id in (" + _ids + ")";
            dbCommand.Connection = dbConnection;

            dbConnection.Open();
            try
            {
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("查看设置操作失败");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static void Replyed(string _ids)
        {
            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "update B2c_inq set i_isR = i_isR + 1,i_Rtime = getDate() where id in (" + _ids + ")";
            dbCommand.Connection = dbConnection;

            dbConnection.Open();
            try
            {
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("回复设置操作失败");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        #endregion


        public static DataTable GetList(int _currentpage, string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_inq where " + _sql + " and 1=1 order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_inq where id in (" + _ids + ")";
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
    }
}
