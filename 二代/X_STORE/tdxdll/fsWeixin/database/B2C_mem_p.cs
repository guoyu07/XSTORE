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
    public class B2C_mem_p
    {
        public int id = 0;           //编号
        public int mID = 0;    //商户ID
        public string mname = "";//会员用户名
        public string sp_name = ""; //图片名称
        public string sp_max = "";     //详细介绍
        public string sp_min = "";     //厨师介绍
        public int sp_sort = 99;        //获奖情况
      
        public B2C_mem_p() { }

        public B2C_mem_p(int _id)
        {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *,(select m_name from b2c_mem where b2c_mem.id=b2c_mem_p.mid) as mname from B2C_mem_p where id=" + id;

            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_mem_p：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    mID = Convert.IsDBNull(dt.Rows[0]["mID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mID"]);
                    mname = Convert.IsDBNull(dt.Rows[0]["mname"]) ? "" : Convert.ToString(dt.Rows[0]["mname"]);
                    sp_name = Convert.IsDBNull(dt.Rows[0]["sp_name"]) ? "" : Convert.ToString(dt.Rows[0]["sp_name"]);
                    sp_max = Convert.IsDBNull(dt.Rows[0]["sp_max"]) ? "" : Convert.ToString(dt.Rows[0]["sp_max"]);
                    sp_min = Convert.IsDBNull(dt.Rows[0]["sp_min"]) ? "" : Convert.ToString(dt.Rows[0]["sp_min"]);
                    sp_sort = Convert.IsDBNull(dt.Rows[0]["sp_sort"]) ? 999 : Convert.ToInt32(dt.Rows[0]["sp_sort"]); 
                }
            }
            else
            {
                throw new NotSupportedException("B2C_mem_p" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        public void myInsert(int _mID,string _sp_name, string _sp_max, string _sp_min, int _sp_sort)
        {
            if (_mID != 0)
            {
                mID = _mID;
            }
            else
            {
                throw new NotSupportedException("请输入会员名称");
            } 
            try
            {

                string sql = "insert into B2C_mem_p (mID,sp_name,sp_max,sp_min,sp_sort) values (@mID,@sp_name,@sp_max,@sp_min,@sp_sort)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@mID", _mID),
                    new SqlParameter("@sp_name", _sp_name), 
                    new SqlParameter("@sp_max", _sp_max), 
                    new SqlParameter("@sp_min",_sp_min), 
                    new SqlParameter("@sp_sort", _sp_sort)};
                    
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
        public void myUpdate(int _id, int _mID, string _sp_name, string _sp_max, string _sp_min, int _sp_sort)
        {
            if (_mID != 0)
            {
                mID = _mID;
            }
            else
            {
                throw new NotSupportedException("请输入会员用户名");
            }

            try
            {
                string sql = "update B2C_mem_p set  mID=@mID,sp_name=@sp_name,sp_max=@sp_max,sp_min=@sp_min,sp_sort=@sp_sort where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@mID", _mID),
                    new SqlParameter("@sp_name", _sp_name), 
                    new SqlParameter("@sp_max", _sp_max), 
                    new SqlParameter("@sp_min",_sp_min), 
                    new SqlParameter("@sp_sort", _sp_sort)};
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
        public static void myDel(int _id)
        {

            if (_id == 0)
            {
                throw new NotSupportedException("没有取得ID号");
            }
            else
            {
                string sql = "delete from B2C_mem_p where id=" + _id;
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

        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(mID,sp_name,sp_max,sp_min,sp_sort);
            }
            else
            {
                this.myUpdate(id, mID, sp_name, sp_max, sp_min, sp_sort);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void AddNew()
        {
            id = 0;           //编号
            mID = 0;    //商户ID\
            mname = "";
            sp_name = "";
            sp_max = "";     //详细介绍
            sp_min = "";     //厨师介绍
            sp_sort = 0;        //获奖情况
           
        }


        public static DataTable getshoplist()
        {
            DataTable dt = null;
            string sql = "select B2C_mem_p.*,(select B2C_mem.m_name from  B2C_mem  where  B2C_mem.id=B2C_mem_p.mID  ) as mname  from B2C_mem_p";
            try
            {
                dt = comfun.GetDataTableBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public static DataTable getshoplist(int _id)
        {
            DataTable dt = null;
            string sql = "select B2C_mem_p.*,(select B2C_mem.m_name from  B2C_mem  where  B2C_mem.id=B2C_mem_p.mID  ) as mname from B2C_mem_p where mID =" + _id;
            try
            {
                dt = comfun.GetDataTableBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable getshoplist(string _mname)
        {
            DataTable dt = null;
            string sql = "select B2C_mem_p.*,(select B2C_mem.m_name from  B2C_mem  where  B2C_mem.id=B2C_mem_p.mID  ) as mname from B2C_mem_p where (select B2C_mem.m_name from  B2C_mem  where  B2C_mem.id=B2C_mem_p.mID  )='" + _mname + "'";
            try
            {
                dt = comfun.GetDataTableBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public static DataTable getlist(int _id)
        {
            DataTable dt = null;
            string sql = "select B2C_mem_p.*,(select B2C_mem.m_name from  B2C_mem  where  B2C_mem.id=B2C_mem_p.mID  ) as mname from B2C_mem_p where id=" + _id;
            try
            {
                dt = comfun.GetDataTableBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}

