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
    /// <summary>
    /// 优惠券
    /// </summary>
    public class B2C_YHQ
    {
        public int id = 0;           //编号
        public int mID = 0;      //所属商户
        public string cno = "";
        public string bno = "";
        public string Y_name = "";    //名称
        public string Y_gif = "";     //代表图片 
        public string Y_msg = ""; 
        public int Y_isactive = 1;
        public int Y_isdel = 0;
        public int Y_Sort = 999;
        public int Y_isHead = 0;
        public int Y_isCHead = 0;
        public int Y_hits = 0;
        public DateTime regdate = DateTime.Now;
        public int cityID = 0;


        public B2C_YHQ() { }
        public B2C_YHQ(int _id)
        {
            id = _id;
            this.load();
        }
        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select * from B2C_YHQ where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_YHQID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    mID = Convert.IsDBNull(dt.Rows[0]["mID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["mID"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    bno = Convert.IsDBNull(dt.Rows[0]["bno"]) ? "" : Convert.ToString(dt.Rows[0]["bno"]);
                    Y_name = Convert.IsDBNull(dt.Rows[0]["Y_name"]) ? "" : Convert.ToString(dt.Rows[0]["Y_name"]);
                    Y_gif = Convert.IsDBNull(dt.Rows[0]["Y_gif"]) ? "" : Convert.ToString(dt.Rows[0]["Y_gif"]); 
                    Y_msg = Convert.IsDBNull(dt.Rows[0]["Y_msg"]) ? "" : Convert.ToString(dt.Rows[0]["Y_msg"]); 
                    Y_isactive = Convert.IsDBNull(dt.Rows[0]["Y_isactive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["Y_isactive"]);
                    Y_isdel = Convert.IsDBNull(dt.Rows[0]["Y_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["Y_isdel"]);
                    Y_Sort = Convert.IsDBNull(dt.Rows[0]["Y_Sort"]) ? 999 : Convert.ToInt32(dt.Rows[0]["Y_Sort"]);
                    Y_isHead = Convert.IsDBNull(dt.Rows[0]["Y_isHead"]) ? 0 : Convert.ToInt32(dt.Rows[0]["Y_isHead"]);
                    Y_isCHead = Convert.IsDBNull(dt.Rows[0]["Y_isCHead"]) ? 0 : Convert.ToInt32(dt.Rows[0]["Y_isCHead"]);
                    Y_hits = Convert.IsDBNull(dt.Rows[0]["Y_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["Y_hits"]); 
                    regdate = Convert.IsDBNull(dt.Rows[0]["regdate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regdate"]);
                    cityID = Convert.IsDBNull(dt.Rows[0]["cityid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityid"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_YHQID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(int _mID,string _cno,string _bno, string _Y_name, string _Y_gif, string _Y_msg,  int _Y_isactive, int _Y_isdel, int _Y_Sort, int _Y_isHead, int _Y_isCHead, int _Y_hits)
        {
            try
            {
                string sql = "insert into B2C_YHQ (mID,cno,bno, Y_name, Y_gif,  Y_msg,  Y_isactive, Y_isdel, Y_Sort, Y_isHead, Y_isCHead, Y_hits) values (@mID,@cno,@bno, @Y_name, @Y_gif, @Y_msg,  @Y_isactive, @Y_isdel, @Y_Sort, @Y_isHead, @Y_isCHead, @Y_hits)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@mID", _mID), 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@bno", _bno), 
                    new SqlParameter("@Y_name", _Y_name), 
                    new SqlParameter("@Y_gif", _Y_gif),
                    new SqlParameter("@Y_msg", _Y_msg),
                    new SqlParameter("@Y_isactive", _Y_isactive),
                    new SqlParameter("@Y_isdel", _Y_isdel),
                    new SqlParameter("@Y_Sort", _Y_Sort),
                    new SqlParameter("@Y_isHead", _Y_isHead),
                    new SqlParameter("@Y_isCHead", _Y_isCHead),
                    new SqlParameter("@Y_hits", _Y_hits)};

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
        private void myUpdate(int _id, int _mID, string _cno, string _bno, string _Y_name, string _Y_gif, string _Y_msg, int _Y_isactive, int _Y_isdel, int _Y_Sort, int _Y_isHead, int _Y_isCHead, int _Y_hits)
        {
            try
            {
                string sql = "update B2C_YHQ set mID=@mID,cno=@cno,bno=@bno, Y_name=@Y_name, Y_gif=@Y_gif,  Y_msg=@Y_msg,  Y_isactive=@Y_isactive, Y_isdel=@Y_isdel, Y_Sort=@Y_Sort, Y_isHead=@Y_isHead, Y_isCHead=@Y_isCHead, Y_hits=@Y_hits  where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                   new SqlParameter("@mID", _mID), 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@bno", _bno), 
                    new SqlParameter("@Y_name", _Y_name), 
                    new SqlParameter("@Y_gif", _Y_gif),
                    new SqlParameter("@Y_msg", _Y_msg),
                    new SqlParameter("@Y_isactive", _Y_isactive),
                    new SqlParameter("@Y_isdel", _Y_isdel),
                    new SqlParameter("@Y_Sort", _Y_Sort),
                    new SqlParameter("@Y_isHead", _Y_isHead),
                    new SqlParameter("@Y_isCHead", _Y_isCHead),
                    new SqlParameter("@Y_hits", _Y_hits)};

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
            string sql = "delete from B2C_YHQ where id=" + _cid + "";
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
                this.myInsert(mID,cno,bno, Y_name, Y_gif,  Y_msg,  Y_isactive, Y_isdel, Y_Sort, Y_isHead, Y_isCHead, Y_hits);
            }
            else
            {
                this.myUpdate(id, mID, cno, bno, Y_name, Y_gif, Y_msg, Y_isactive, Y_isdel, Y_Sort, Y_isHead, Y_isCHead, Y_hits);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0;           
            mID = 0;
            cno = "";
            bno = "";
            Y_name = "";    
            Y_gif = "";  
            Y_msg = ""; 
            Y_isactive = 1;
            Y_isdel = 0;
            Y_Sort = 999;
            Y_isHead = 0;
            Y_isCHead = 0;
            Y_hits = 0; 
            regdate = DateTime.Now;
            cityID = 0;
            
        }
        #region 设置按钮功能
        /// <summary>
        /// 设置是否启用
        /// </summary>
        /// <param name="_cid"></param>
        public static int setY_isactive(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_YHQ set Y_isactive= -1 * (Y_isactive - 1) where id in ('" + _cid + "')");
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
        public static int setY_isdel(string _cid)
        {
            try
            {
                return comfun.UpdateBySQL("update B2C_YHQ set Y_isdel= -1 * (Y_isdel - 1) where id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 设置首页推荐
        /// </summary>
        /// <param name="_cid"></param>
        /// <returns></returns>
        public static int setY_isHead(string _cid)
        {
            try
            {
                return comfun.UpdateBySQL("update B2C_YHQ set Y_isHead= -1 * (Y_isHead - 1) where id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 设置分页推荐
        /// </summary>
        /// <param name="_cid"></param>
        /// <returns></returns>
        public static int setY_isCHead(string _cid)
        {
            try
            {
                return comfun.UpdateBySQL("update B2C_YHQ set Y_isCHead= -1 * (Y_isCHead - 1) where id in ('" + _cid + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        /// <summary>
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(string _dzd, string _tname, string _sql, int _ipage)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from " + _tname + " where " + _sql + " order by y_sort,id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetList(string dzd2,string _dzd, string _tname, string _sql,int _ipage)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL(dzd2 + "select " + _dzd + " from " + _tname + " where " + _sql + " order by y_sort,id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetShopList(string _mname)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select *,(select c_name from b2c_category where c_no=b2c_yhq.cno) as cname,(select c_name from B2C_brand where c_no=b2c_yhq.bno) as bname from b2c_YHQ where (select m_name from b2c_mem where b2c_mem.id=b2c_yhq.mid)='" + _mname + "' and y_isactive=1 and y_isdel=0 order by y_sort,id desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
