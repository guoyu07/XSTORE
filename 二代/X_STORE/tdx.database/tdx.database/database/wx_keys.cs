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
using Creatrue.kernel;


namespace tdx.database
{
    public class wx_keys
    {
        public int id = 0;                     //编号，自增 
        public string k_words = "";             //问题关键词
        public string k_answer = "";           //回答内容
        public int fid = 0;//是否功能函数
        public string fname = "";//
        public string k_url = "";// 是否外部取数据地址
        public int k_level = 0;                //层级
        public int k_isdel = 0;                 //是否删除
        public int k_isSys = 0;//是否系统
        public int cityID = 0;                 //城市ID，目前缺省为1，不用编辑
        public string k_image = "";//图文信息图片
        public string k_content = "";//内容信息
        public string k_sort = "99";//排序信息
        public string k_url2 = "";//URL信息
        public string k_des = "";//描述信息
        public string guid = "";//组标识

        public wx_keys() { }
        public wx_keys(int _id)
        {
            id = _id;
            this.load();
        }

        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select *,(select f_name from wx_keys_f where id=fid) as fname from wx_keys where id=" + id + " and cityid in (select id from wx_mp)"; // where wid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + "
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("wx_keysID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    k_words = Convert.IsDBNull(dt.Rows[0]["k_words"]) ? "" : Convert.ToString(dt.Rows[0]["k_words"]);
                    k_answer = Convert.IsDBNull(dt.Rows[0]["k_answer"]) ? "" : Convert.ToString(dt.Rows[0]["k_answer"]);
                    fname = Convert.IsDBNull(dt.Rows[0]["fname"]) ? "" : Convert.ToString(dt.Rows[0]["fname"]);
                    fid = Convert.IsDBNull(dt.Rows[0]["fid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["fid"]);
                    k_url = Convert.IsDBNull(dt.Rows[0]["k_url"]) ? "" : Convert.ToString(dt.Rows[0]["k_url"]);
                    k_level = Convert.IsDBNull(dt.Rows[0]["k_level"]) ? 0 : Convert.ToInt32(dt.Rows[0]["k_level"]);
                    k_isdel = Convert.IsDBNull(dt.Rows[0]["k_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["k_isdel"]);
                    k_isSys = Convert.IsDBNull(dt.Rows[0]["k_isSys"]) ? 0 : Convert.ToInt32(dt.Rows[0]["k_isSys"]);
                    cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["cityID"]);
                    k_image = Convert.IsDBNull(dt.Rows[0]["k_image"]) ? "" : Convert.ToString(dt.Rows[0]["k_image"]);
                    k_content = Convert.IsDBNull(dt.Rows[0]["k_content"]) ? "" : Convert.ToString(dt.Rows[0]["k_content"]);
                    k_sort = Convert.IsDBNull(dt.Rows[0]["k_sort"]) ? "" : Convert.ToString(dt.Rows[0]["k_sort"]);
                    k_url2 = Convert.IsDBNull(dt.Rows[0]["k_url2"]) ? "" : Convert.ToString(dt.Rows[0]["k_url2"]);
                    k_des = Convert.IsDBNull(dt.Rows[0]["k_des"]) ? "" : Convert.ToString(dt.Rows[0]["k_des"]);
                    guid = Convert.IsDBNull(dt.Rows[0]["guid"]) ? "" : Convert.ToString(dt.Rows[0]["guid"]);
                }
            }
            else
            {
                throw new NotSupportedException("wx_keysID：" + id + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _kwords, string _kanswer, int _klevel, int _cityID, int _fid, string _kurl, string _k_image, string _k_content, string _k_sort, string _k_url2, string _k_des,string _guid)
        {
            try
            {
                string sql = "insert into wx_keys (k_words,k_answer,k_level,cityID,fid,k_url,k_image,k_content,k_sort,k_url2,k_des,guid) values (@kwords,@kanswer,@klevel,@cityID,@fid,@kurl,@k_image,@k_content,@k_sort,@k_url2,@k_des,@guid)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@kwords", _kwords), 
                    new SqlParameter("@kanswer", _kanswer), 
                    new SqlParameter("@klevel", _klevel), 
                    new SqlParameter("@cityID", _cityID), 
                    new SqlParameter("@fid", _fid),
                    new SqlParameter("@k_image", _k_image),
                    new SqlParameter("@k_content", _k_content),
                    new SqlParameter("@kurl", _kurl),
                    new SqlParameter("@k_sort",_k_sort),
                    new SqlParameter("@k_url2",_k_url2),
                    new SqlParameter("@k_des",_k_des),
                    new SqlParameter("@guid",_guid)
                };

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
        private void myUpdate(int _id, string _kwords, string _kanswer, int _klevel, int _fid, string _kurl, string _k_image, string _k_content, string _k_sort, string _k_url2, string _k_des,string _guid)
        {
            try
            {
                string sql = "update wx_keys set k_words=@kwords,k_answer=@kanswer,k_level=@klevel,fid=@fid,k_url=@kurl,k_image=@k_image,k_content=@k_content,k_sort=@k_sort,k_url2=@k_url2,k_des=@k_des,guid=@guid where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@kwords", _kwords), 
                    new SqlParameter("@kanswer", _kanswer), 
                    new SqlParameter("@klevel", _klevel), 
                    new SqlParameter("@fid", _fid), 
                    new SqlParameter("@kurl", _kurl),
                    new SqlParameter("@k_image", _k_image),
                    new SqlParameter("@k_content", _k_content),
                    new SqlParameter("@k_sort",_k_sort),
                    new SqlParameter("@k_url2",_k_url2),
                    new SqlParameter("@k_des",_k_des),
                    new SqlParameter("@guid",_guid)
                };

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
            // where wid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + "
            string sql = "delete from wx_keys where k_isSys=0 and cityid in (select id from wx_mp) and id=" + _cid + "";
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
                this.myInsert(k_words, k_answer, k_level, cityID, fid, k_url,k_image,k_content,k_sort,k_url2,k_des,guid);
            }
            else
            {
                this.myUpdate(id, k_words, k_answer, k_level, fid, k_url, k_image, k_content, k_sort,k_url2,k_des,guid);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0;
            k_words = "";
            k_answer = "";
            k_level = 0;
            fid = 0;
            fname = "";
            k_url = "";
            k_isSys = 0;
            cityID = 0;
            k_image = "";
            k_content = "";
            k_sort = "99";
            k_url2 = "";
            k_des = "";
            guid = "";
        }

        /// <summary>
        /// 此处为条件查询
        /// </summary>
        public static DataTable GetList(int _page, string _dzd, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from wx_keys where 1=1 and " + _sql + " ";
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from wx_keys where " + _sql + " order by id desc");
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

        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from wx_keys where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
