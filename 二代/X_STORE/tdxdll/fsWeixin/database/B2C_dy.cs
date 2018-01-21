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
    public class B2C_dy
    {
        public int id = 0;                     //编号，自增
        public string dy_title = ""; //标题  
        public string dy_content = "";           //页面内容 
        public string dy_msg = "";//内容
        public string dy_msg2 = "";//内容
        public int dy_cent = 0;//送多少积分
        public DateTime dy_bdate = System.DateTime.Now; //开始时间
        public DateTime dy_edate = System.DateTime.Now;//结束时间
        public int dy_isactive = 1;//启停
        public int dy_isdel = 0;//是否删除  
        DateTime regtime = DateTime.Now;       //录入时间   

        public B2C_dy() { }
        public B2C_dy(int _id)
        {
            id = _id;
            this.load();
        }
        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select * from B2C_dy where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_dyID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    dy_title = Convert.IsDBNull(dt.Rows[0]["dy_title"]) ? "" : Convert.ToString(dt.Rows[0]["dy_title"]);
                    dy_content = Convert.IsDBNull(dt.Rows[0]["dy_content"]) ? "" : Convert.ToString(dt.Rows[0]["dy_content"]);
                    dy_msg = Convert.IsDBNull(dt.Rows[0]["dy_msg"]) ? "" : Convert.ToString(dt.Rows[0]["dy_msg"]);
                    dy_msg2 = Convert.IsDBNull(dt.Rows[0]["dy_msg2"]) ? "" : Convert.ToString(dt.Rows[0]["dy_msg2"]);
                    dy_cent = Convert.IsDBNull(dt.Rows[0]["dy_cent"]) ? 0 : Convert.ToInt32(dt.Rows[0]["dy_cent"]);
                    dy_bdate = Convert.IsDBNull(dt.Rows[0]["dy_bdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["dy_bdate"]);
                    dy_edate = Convert.IsDBNull(dt.Rows[0]["dy_edate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["dy_edate"]);
                    dy_isactive= Convert.IsDBNull(dt.Rows[0]["dy_isactive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["dy_isactive"]);
                    dy_isdel= Convert.IsDBNull(dt.Rows[0]["dy_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["dy_isdel"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_dyID：" + id + "不存在");
            }

        }

        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _dy_title, string _dy_content, string _dy_msg, string _dy_msg2, int _dy_cent, DateTime _dy_bdate, DateTime _dy_edate)
        {
            try
            {
                string sql = "insert into B2C_dy (dy_title,dy_content,dy_msg,dy_msg2,dy_cent,dy_bdate,dy_edate) values (@dytitle,@dycontent,@dymsg,@dymsg2,@dycent,@dybdate,@dyedate)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@dytitle", _dy_title), 
                    new SqlParameter("@dycontent", _dy_content), 
                    new SqlParameter("@dymsg", _dy_msg),
                    new SqlParameter("@dymsg2", _dy_msg2),
                    new SqlParameter("@dycent", _dy_cent),
                    new SqlParameter("@dybdate", _dy_bdate),
                    new SqlParameter("@dyedate", _dy_edate)};

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
        private void myUpdate(int _id, string _dy_title, string _dy_content, string _dy_msg, string _dy_msg2, int _dy_cent, DateTime _dy_bdate, DateTime _dy_edate)
        {
            try
            {
                string sql = "update B2C_dy set  dy_title=@dytitle,dy_content=@dycontent,dy_msg=@dymsg,dy_msg2=@dymsg2,dy_cent=@dycent,dy_bdate=@dybdate,dy_edate=@dyedate where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                     new SqlParameter("@dytitle", _dy_title), 
                    new SqlParameter("@dycontent", _dy_content), 
                    new SqlParameter("@dymsg", _dy_msg),
                    new SqlParameter("@dymsg2", _dy_msg2),
                    new SqlParameter("@dycent", _dy_cent),
                    new SqlParameter("@dybdate", _dy_bdate),
                    new SqlParameter("@dyedate", _dy_edate)};

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
            string sql = "delete from B2C_dy where id=" + _cid + "";
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
                this.myInsert(dy_title,dy_content,dy_msg,dy_msg2,dy_cent,dy_bdate,dy_edate);
            }
            else
            {
                this.myUpdate(id, dy_title, dy_content, dy_msg, dy_msg2, dy_cent, dy_bdate, dy_edate);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0;
            dy_title = "";
            dy_content = "";
            dy_msg = "";
            dy_msg2 = "";
            dy_cent = 0;
            dy_bdate = System.DateTime.Now;
            dy_edate = System.DateTime.Now;
            dy_isactive = 1;
            dy_isdel = 0;  
            regtime = DateTime.Now;
        }

        public static DataTable GetList(int _page, string _dzd, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from B2C_dy where 1=1 and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_dy where " + _sql + " order by id desc");
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
         
        public static string insertASQL(string _gu, string _dyid, string _ips,string _mid)
        {
            string _sql = "insert into b2c_dy_a(gu,dyid,ips,mid) values('{0}','{1}','{2}',{3})";
            _sql = string.Format(_sql, _gu, _dyid, _ips,_mid);

            return _sql;
        }

        public static string insertDSQL(string _gu, string _sid, string _svd, string _des)
        {
            string _sql = "insert into b2c_dy_sd(agu,sid,svd,svd_des) values('{0}','{1}','{2}','{3}')";
            _sql = string.Format(_sql, _gu, _sid, _svd,_des);

            return _sql;
        }

        //获取题目列表
        public static DataTable GetSList(int _tid,string _sql2)
        {
            string _sql = "select *,(select count(id) from b2c_dy_sv where sid=b2c_dy_s.id) as vcount from b2c_dy_s where dyid=" + _tid.ToString() + " and " + _sql2 + " order by t_sort,id";
            return comfun.GetDataTableBySQL(_sql);
        }

        //获取答案列表
        public static DataTable GetVList(int _sid,string _sql2)
        {
            string _sql = "select * from b2c_dy_SV where sid=" + _sid.ToString() + " and " + _sql2 + " order by v_sort,id";
            return comfun.GetDataTableBySQL(_sql);
        }

        public static void insertS(int _dyid,string _title,int _cid,int _sort)
        {
            try
            {
                string sql = "insert into B2C_dy_S (dyid,t_title,t_cid,t_sort) values (" + _dyid.ToString() + ",@stitle," + _cid.ToString() + "," + _sort.ToString() + ")";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@stitle", _title)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        public static void insertV(int _sid,string _vtitle,string _vmsg,int _vsort)
        {
            try
            {
                string sql = "insert into B2C_dy_SV (sid,v_title,v_msg,v_sort) values (" + _sid.ToString() + ",@vtitle,@vmsg," + _vsort.ToString() + ")";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@vtitle", _vtitle),new SqlParameter("@vmsg", _vmsg)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        public static void delS(string _ids)
        {
            try
            {
                comfun.UpdateBySQL("delete from b2c_dy_s where id in (" + _ids + ")");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void delSV(string _ids)
        {
            try
            {
                comfun.UpdateBySQL("delete from b2c_dy_sV where id in (" + _ids + ")");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void delS(int _dyid)
        {
            try
            {
                comfun.UpdateBySQL("delete from b2c_dy_s where dyid=" + _dyid.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void delSV(int _sid)
        {
            try
            {
                comfun.UpdateBySQL("delete from b2c_dy_sV where sid=" + _sid.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
