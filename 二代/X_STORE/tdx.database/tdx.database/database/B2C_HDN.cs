using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Creatrue.kernel;

namespace tdx.database
{
    public class B2C_HDN
    {
        public int id = 0; 
		public int tid= 0;
        public string n_title = "";//留言标题
		public string n_name="";//称呼
        public string n_tel = "";//电话 
        public string n_ips = "";//留言IP   
        public DateTime regtime = System.DateTime.Now;//留言时间 
        //public int cityID = 1;//网站区分 

        public B2C_HDN() { }
        public B2C_HDN(int _id)
        {
            id = _id;
            this.LoadData();
        }      

        #region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select * ";
            _sql += " from B2C_HDN where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
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
                throw (new Exception("B2C_HDN取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_HDN没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
				tid = Convert.IsDBNull(dr["tid"]) ? 0 : Convert.ToInt32(dr["tid"]); 
                n_title = Convert.IsDBNull(dr["n_title"]) ? "" : Convert.ToString(dr["n_title"]);
				n_name = Convert.IsDBNull(dr["n_name"]) ? "" : Convert.ToString(dr["n_name"]);
				n_tel = Convert.IsDBNull(dr["n_tel"]) ? "" : Convert.ToString(dr["n_tel"]); 
                n_ips = Convert.IsDBNull(dr["n_ips"]) ? "" : Convert.ToString(dr["n_ips"]);   
                regtime = Convert.IsDBNull(dr["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dr["regtime"]); 
                //cityID = Convert.IsDBNull(dr["cityID"]) ? 1 : Convert.ToInt32(dr["cityID"]);
                

                dr = null;
            }
            dt.Dispose();
            dt = null;
        }

        private void myInsertMethod(string _tid, string _ntitle, string _nname,string _ntel,string _nips)
        {
            if (!string.IsNullOrEmpty(_nname) && !string.IsNullOrEmpty(_ntel))
            {
                n_name = _nname;
				n_tel = _ntel;
            }
            else
            {
                throw new NotSupportedException("请输入称呼和电话");
            }
            string sql = "insert into B2C_HDN (tid,n_title,n_name,n_tel,n_ips)";
            sql = sql + " values (@tid,@n_title,@n_name,@n_tel,@n_ips)";
            SqlParameter[] paras = new SqlParameter[] {  
                    new SqlParameter("@tid", _tid), 
                    new SqlParameter("@n_title", _ntitle),
					new SqlParameter("@n_name", _nname),
                    new SqlParameter("@n_tel", _ntel), 
                    new SqlParameter("@n_ips", _nips)};

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
        private void myUpdateMethod(string _tid, string _ntitle, string _nname,string _ntel,string _nips, int _id)
        {
            if (!string.IsNullOrEmpty(_nname) && !string.IsNullOrEmpty(_ntel))
            {
                n_name = _nname;
				n_tel = _ntel;
            }
            else
            {
                throw new NotSupportedException("请输入称呼和电话");
            }
            string sql = "update B2C_HDN set tid=@tid,n_title=@n_title,n_name=@n_name,n_tel=@n_tel,n_ips=@n_ips where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@tid", _tid), 
                    new SqlParameter("@n_title", _ntitle),
					new SqlParameter("@n_name", _nname),
                    new SqlParameter("@n_tel", _ntel), 
                    new SqlParameter("@n_ips", _nips),
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
                throw new NotSupportedException("没有取得留言ID号");
            }
            else
            {
                string sql = "delete from B2C_HDN where id=" + _id;

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
           tid = 0;
            n_title = "";
			n_name ="";
			n_tel ="";
            n_ips = "";  
            regtime = System.DateTime.Now; 
            //cityID = 1; 
        }
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.tid.ToString(), this.n_title,this.n_name,this.n_tel , this.n_ips,this.id);
            }
            else
            {
                this.myInsertMethod(this.tid.ToString(), this.n_title,this.n_name,this.n_tel , this.n_ips);
            }
        }
        public void Delete()
        {
            if (this.id != 0)
                this.myDeleteMethod(this.id);
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

            string sql = "delete from B2C_HDN where id in (" + _ids + ")";
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
       
        #endregion

        /// <summary>
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_HDN where " + _sql + " order by id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(int _currentpage, string _dzd, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from B2C_HDN where 1=1 and " + _sql + "";
            totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
            totalpage = totalcount / pagesize;
            if (totalpage < totalcount / pagesize)
            {
                totalpage = totalpage + 1;
            }

            beginItem = pagesize * (_currentpage - 1);
            endItem = pagesize * _currentpage - 1;
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_HDN where " + _sql + " order by id desc");
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


    }

}
