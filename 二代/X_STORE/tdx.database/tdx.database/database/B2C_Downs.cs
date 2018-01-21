using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database.database
{
    public class B2C_Downs
    {
        public int id = 0;
        public string P_no = "";//文档记录号
        public string P_tab = "";//关联表名
        public string P_row = "";//关联字段
        public string P_name = "";//文档名称
        public string P_gif = "";//代表图片
        public string P_url = "";//文档地址url
        public string P_des = "";//简单描述
        public string P_ftype = "";//文档的类型
        public string P_fweight = ""; //文档大小
        public int P_sort = 99;//排序
        public string cno = "";//客户记录号
        public DateTime P_wdate = System.DateTime.Now;//输入日期        
        public int P_isactive = 1;//是否启用
        public int P_isdel = 0;//是否删除
        public int P_hits = 0;//浏览次数
        public DateTime regdate = System.DateTime.Now;//操作时间
        //public int cityID = 0;//网站区分

        //便于显示的字段内容
        public string isactivename = "启动";
        public string isdelname = "否";
        public string cname = "";//类别名称

        public B2C_Downs() { }
        public B2C_Downs(int _id)
        {
            id = _id;
            this.LoadData();
        }
        public B2C_Downs(string _wno)
        {
            P_no = _wno;
            id = 0;
            this.LoadData();
        }

        #region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select *,(select c_name from B2C_Dclass as c where c.c_no=B2C_Downs.cno) as cname";
            _sql += " from B2C_Downs where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else if (this.P_no != "")
            {
                _sql += " and P_no='" + this.P_no.Trim() + "'"; //and  cityid=" + 0
            }
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 1)
            {
                throw (new Exception("B2C_Downs取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_Downs没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                P_tab = Convert.IsDBNull(dr["P_tab"]) ? "" : Convert.ToString(dr["P_tab"]);
                P_row = Convert.IsDBNull(dr["P_row"]) ? "" : Convert.ToString(dr["P_row"]);
                P_no = Convert.IsDBNull(dr["P_no"]) ? "" : Convert.ToString(dr["P_no"]);
                P_name = Convert.IsDBNull(dr["P_name"]) ? "" : Convert.ToString(dr["P_name"]);
                P_gif = Convert.IsDBNull(dr["P_gif"]) ? "" : Convert.ToString(dr["P_gif"]);
                P_url = Convert.IsDBNull(dr["P_url"]) ? "" : Convert.ToString(dr["P_url"]);
                P_ftype = Convert.IsDBNull(dr["P_ftype"]) ? "" : Convert.ToString(dr["P_ftype"]);
                P_fweight = Convert.IsDBNull(dr["P_fweight"]) ? "" : Convert.ToString(dr["P_fweight"]);
                P_des = Convert.IsDBNull(dr["P_des"]) ? "" : Convert.ToString(dr["P_des"]);
                P_sort = Convert.IsDBNull(dr["P_sort"]) ? 99 : Convert.ToInt32(dr["P_sort"]);

                cno = Convert.IsDBNull(dr["cno"]) ? "" : Convert.ToString(dr["cno"]);
                cname = Convert.IsDBNull(dr["cname"]) ? "" : Convert.ToString(dr["cname"]);

                P_wdate = Convert.IsDBNull(dr["P_wdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["P_wdate"]);

                P_isactive = Convert.IsDBNull(dr["P_isactive"]) ? 1 : Convert.ToInt32(dr["P_isactive"]);
                P_isdel = Convert.IsDBNull(dr["P_isdel"]) ? 0 : Convert.ToInt32(dr["P_isdel"]);
                P_hits = Convert.IsDBNull(dr["P_hits"]) ? 0 : Convert.ToInt32(dr["P_hits"]);

                regdate = Convert.IsDBNull(dr["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regdate"]);
                //cityID = Convert.IsDBNull(dr["cityID"]) ? 1 : Convert.ToInt32(dr["cityID"]);
                //
                isactivename = (P_isactive == 1 ? "启动" : "停止");
                isdelname = (P_isdel == 1 ? "是" : "否");

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(string _wtab, string _wrow, string _wno, string _wname, string _wgif, string _wurl, string _wdes, string _wftype, string _wfweight, int _wsort, string _cno, DateTime _wdate)
        {
            //if (!string.IsNullOrEmpty(_wname))
            //{
            //    P_name = _wname; 
            //}
            //else
            //{
            //    throw new NotSupportedException("请输入图片名称");
            //}
            string sql = "insert into B2C_Downs (P_tab,P_row,P_no,P_name,P_gif,P_url,P_des,P_ftype,P_fweight,P_sort,cno,P_wdate)"; //,cityID
            sql = sql + " values (@P_tab,@P_row,@P_no,@P_name,@p_gif,@P_url,@P_des,@P_ftype,@P_fweight,@P_sort,@cno,@P_wdate)"; //,@cityID
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@P_tab", _wtab), 
                    new SqlParameter("@P_row", _wrow), 
                    new SqlParameter("@P_no", _wno), 
                    new SqlParameter("@P_name", _wname),
                    new SqlParameter("@P_gif", _wgif),
                    new SqlParameter("@P_url", _wurl),
                    new SqlParameter("@P_des", _wdes),
                    new SqlParameter("@P_ftype", _wftype),
                    new SqlParameter("@P_fweight", _wfweight),
                    new SqlParameter("@P_sort", _wsort),
                    new SqlParameter("@cno", _cno),
                    new SqlParameter("@P_wdate", _wdate)}; //,new SqlParameter("@cityID", this.cityID)

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
        private void myUpdateMethod(string _wtab, string _wrow, string _wno, string _wname, string _wgif, string _wurl, string _wdes, string _wftype, string _wfweight, int _wsort, string _cno, DateTime _wdate, int _id)
        {
            //if (!string.IsNullOrEmpty(_wname))
            //{
            //    P_name = _wname;
            //}
            //else
            //{
            //    throw new NotSupportedException("请输入文档名称");
            //}
            string sql = "update B2C_Downs set P_tab=@P_tab,P_row=@P_row,P_no=@P_no,P_name=@P_name,P_gif=@P_gif,P_url=@P_url,P_des=@P_des,P_ftype=@P_ftype,P_fweight=@P_fweight,P_sort=@P_sort,cno=@cno,P_wdate=@P_wdate where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@P_tab", _wtab), 
                    new SqlParameter("@P_row", _wrow), 
                    new SqlParameter("@P_no", _wno), 
                    new SqlParameter("@P_name", _wname),
                    new SqlParameter("@P_gif", _wgif), 
                    new SqlParameter("@P_url", _wurl),
                    new SqlParameter("@P_des", _wdes),
                    new SqlParameter("@P_ftype", _wftype),
                    new SqlParameter("@P_fweight", _wfweight),
                    new SqlParameter("@P_sort", _wsort),
                    new SqlParameter("@cno", _cno),
                    new SqlParameter("@P_wdate", _wdate),
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
        private void myDeleteMethod(int _id)
        {
            if (_id == 0)
            {
                throw new NotSupportedException("没有取得文档ID号");
            }
            else
            {
                string sql = "delete from B2C_Downs where id=" + _id;

                try
                {
                    comfun.UpdateBySQL(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region "公有方法"
        public void AddNew()
        {
            id = 0;
            P_tab = "";
            P_row = "";
            P_no = "";
            P_name = "";
            P_gif = "";
            P_url = "";
            P_des = "";
            P_ftype = "";
            P_fweight = "";
            P_sort = 99;
            cno = "";
            cname = "";

            P_wdate = System.DateTime.Now;

            P_isactive = 1;
            P_isdel = 0;
            P_hits = 0;
            regdate = System.DateTime.Now;
            //cityID = 0;

            isactivename = "启动";
            isdelname = "未";
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.P_tab, this.P_row, this.P_no, this.P_name, this.P_gif, this.P_url, this.P_des, this.P_ftype, this.P_fweight, this.P_sort, this.cno, this.P_wdate, this.id);
            }
            else
            {
                this.myInsertMethod(this.P_tab, this.P_row, this.P_no, this.P_name, this.P_gif, this.P_url, this.P_des, this.P_ftype, this.P_fweight, this.P_sort, this.cno, this.P_wdate);
            }
        }
        public void Delete()
        {
            if (this.id != 0)
                this.myDeleteMethod(this.id);
        }
        public void updateHits()
        {
            if (this.id != 0)
            {
                try
                {
                    comfun.UpdateBySQL("update B2C_Downs set P_hits=P_hits+1 where id=" + this.id);
                }
                finally { }
            }
        }
        #endregion

        #region "静态方法"
        /// <summary>
        /// 一次彻底删除一组文档资料
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_Downs where id in (" + _ids + ")";
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
        /// 设置是否启用
        /// </summary>
        /// <param name="_cid"></param>
        public static int setIsActive(string _ids)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Downs set P_isactive= -1 * (P_isActive - 1) where id in (" + _ids + ")");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 设置是否删除
        /// </summary>
        /// <param name="_cid"></param>
        public static int setIsDel(string _ids)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Downs set P_isdel= -1 * (P_isdel - 1) where id in ('" + _ids + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion

        /// <summary>
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Downs where 1=1 and " + _sql + " order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(int _currentpage, string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Downs where  1=1 and " + _sql + " order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


    }
}
