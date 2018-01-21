using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using tdx.kernel;

namespace tdx.database
{
    public class B2C_ZXZ
    {
        public int id = 0;
        public string ano = ""; //地区
        public string t_title = ""; //名称
        public string t_addr = "";  //地址
        public string t_tel = "";   //电话
        public string t_fax = "";   //传真
        public string t_linker = ""; //联系人
        public string t_des = ""; //描述
        public string t_sy = ""; //索引
        public int t_sort = 99; //排序
        public int t_isdel = 0;
        public DateTime t_wdate = System.DateTime.Now; //加入时间
        public DateTime regtime = System.DateTime.Now;  //录入时间

        public B2C_ZXZ() { }
        public B2C_ZXZ(int _id)
        {
            this.id = _id;
            this.Load();
        } 

        private void Load()
        {
            string sql = "select * from B2C_ZXZ where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_ZXZID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    ano = Convert.IsDBNull(dt.Rows[0]["ano"]) ? "" : Convert.ToString(dt.Rows[0]["ano"]);
                    t_title = Convert.IsDBNull(dt.Rows[0]["t_title"]) ? "" : Convert.ToString(dt.Rows[0]["t_title"]);
                    t_addr = Convert.IsDBNull(dt.Rows[0]["t_addr"]) ? "" : Convert.ToString(dt.Rows[0]["t_addr"]);
                    t_tel = Convert.IsDBNull(dt.Rows[0]["t_tel"]) ? "" : Convert.ToString(dt.Rows[0]["t_tel"]);
                    t_fax = Convert.IsDBNull(dt.Rows[0]["t_fax"]) ? "" : Convert.ToString(dt.Rows[0]["t_fax"]);
                    t_linker = Convert.IsDBNull(dt.Rows[0]["t_linker"]) ? "" : Convert.ToString(dt.Rows[0]["t_linker"]);
                    t_des = Convert.IsDBNull(dt.Rows[0]["t_des"]) ? "" : Convert.ToString(dt.Rows[0]["t_des"]);
                    t_sy = Convert.IsDBNull(dt.Rows[0]["t_sy"]) ? "" : Convert.ToString(dt.Rows[0]["t_sy"]);

                    t_wdate = Convert.IsDBNull(dt.Rows[0]["t_wdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["t_wdate"]);
                    t_sort = Convert.IsDBNull(dt.Rows[0]["t_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["t_sort"]);
                    t_isdel = Convert.IsDBNull(dt.Rows[0]["t_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_isdel"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_ZXZID：" + id + "不存在");
            }
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select * from B2C_ZXZ where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_ZXZID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    ano = Convert.IsDBNull(dt.Rows[0]["ano"]) ? "" : Convert.ToString(dt.Rows[0]["ano"]);
                    t_title = Convert.IsDBNull(dt.Rows[0]["t_title"]) ? "" : Convert.ToString(dt.Rows[0]["t_title"]); 
                    t_addr = Convert.IsDBNull(dt.Rows[0]["t_addr"]) ? "" : Convert.ToString(dt.Rows[0]["t_addr"]);
                    t_tel = Convert.IsDBNull(dt.Rows[0]["t_tel"]) ? "" : Convert.ToString(dt.Rows[0]["t_tel"]);
                    t_fax = Convert.IsDBNull(dt.Rows[0]["t_fax"]) ? "" : Convert.ToString(dt.Rows[0]["t_fax"]);
                    t_linker = Convert.IsDBNull(dt.Rows[0]["t_linker"]) ? "" : Convert.ToString(dt.Rows[0]["t_linker"]);
                    t_des = Convert.IsDBNull(dt.Rows[0]["t_des"]) ? "" : Convert.ToString(dt.Rows[0]["t_des"]);
                    t_sy = Convert.IsDBNull(dt.Rows[0]["t_sy"]) ? "" : Convert.ToString(dt.Rows[0]["t_sy"]); 
                    t_sort = Convert.IsDBNull(dt.Rows[0]["t_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["t_sort"]);
                    t_wdate = Convert.IsDBNull(dt.Rows[0]["t_wdate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["t_wdate"]); 
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]); 
                }
            }
            else
            {
                throw new NotSupportedException("B2C_ZXZID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _ano, string _t_title, string _t_addr, string _t_tel, string _t_fax, string _t_linker, string _t_des, string _t_sy, int _t_sort, DateTime _t_wdate)
        {
            try
            {
                string sql = "insert into B2C_ZXZ (ano,t_title,t_addr,t_tel,t_fax,t_linker,t_des,t_sy,t_sort,t_wdate) values (@ano,@t_title,@t_addr,@t_tel,@t_fax,@t_linker,@t_des,@t_sy,@t_sort,@t_wdate)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ano", _ano), 
                    new SqlParameter("@t_title", _t_title), 
                    new SqlParameter("@t_addr", _t_addr),
                    new SqlParameter("@t_tel", _t_tel),
                    new SqlParameter("@t_fax", _t_fax),
                    new SqlParameter("@t_linker", _t_linker),
                    new SqlParameter("@t_des", _t_des),
                    new SqlParameter("@t_sy", _t_sy),
                    new SqlParameter("@t_sort", _t_sort),
                    new SqlParameter("@t_wdate", _t_wdate)};

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
        private void myUpdate(int _id, string _ano, string _t_title, string _t_addr, string _t_tel, string _t_fax, string _t_linker, string _t_des, string _t_sy, int _t_sort, DateTime _t_wdate)
        {
            try
            {
                string sql = "update B2C_ZXZ set ano=@ano,t_title=@t_title,t_addr=@t_addr,t_tel=@t_tel,t_fax=@t_fax,t_linker=@t_linker,t_des=@t_des,t_sy=@t_sy,t_sort=@t_sort,t_wdate=@t_wdate where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@ano", _ano), 
                    new SqlParameter("@t_title", _t_title), 
                    new SqlParameter("@t_addr", _t_addr),
                    new SqlParameter("@t_tel", _t_tel),
                    new SqlParameter("@t_fax", _t_fax),
                    new SqlParameter("@t_linker", _t_linker),
                    new SqlParameter("@t_des", _t_des),
                    new SqlParameter("@t_sy", _t_sy),
                    new SqlParameter("@t_sort", _t_sort),
                    new SqlParameter("@t_wdate", _t_wdate)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary> 
        public static int myDel(int _cid)
        {
            int res = 0;
            string sql = "delete from B2C_ZXZ where id=" + _cid + "";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(ano,t_title,t_addr,t_tel,t_fax,t_linker,t_des,t_sy,t_sort,t_wdate);
            }
            else
            {
                this.myUpdate(id, ano, t_title, t_addr, t_tel, t_fax, t_linker, t_des, t_sy, t_sort, t_wdate);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0;
            ano = "";
            t_title = "";
            t_addr = "";
            t_tel = "";
            t_fax = "";
            t_linker = "";
            t_des = "";
            t_sy = "";
            t_sort = 99;
            t_isdel = 0;
            t_wdate = System.DateTime.Now;
            regtime = DateTime.Now; 
        }

        public static DataTable GetList(int _page, string _dzd, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from B2C_ZXZ where 1=1 and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_ZXZ where " + _sql + " order by id desc");
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
