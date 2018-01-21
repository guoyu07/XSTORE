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
using System.Text;
using tdx.kernel;

namespace tdx.database
{
    /// <summary>
    /// 产品表
    /// </summary>
    public class zagt_Goods
    {
        #region *****构造函数*****
        public zagt_Goods()
        { }
        public zagt_Goods(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion


        public int id = 0;
        public string cno = string.Empty;//产品编号
        public string orderNo = string.Empty;//订单编号
        public string g_name = string.Empty;//产品名称
        public int g_sort = 0;//排序
        public string g_des = string.Empty;//简述
        public double g_price_S = 0;//基础价格
        public double g_price_M = 0;//市场价格
        public double g_cent = 0;//积分
        public int g_parent = 0;//父产品id
        public int g_isactive = 0;//是否上架
        public int g_isdel = 0;//是否删除
        public DateTime g_wdate = System.DateTime.Now;//上架时间
        public int g_hits = 0;//点击次数
        public DateTime regtime = System.DateTime.Now;//添加时间
        public int cityID = 0;


        private void LoadData()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from zagt_Goods where id={0}", id);

            DataTable dt = comfun.GetDataTableBySQL(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? string.Empty : Convert.ToString(dt.Rows[0]["cno"]);
                orderNo = Convert.IsDBNull(dt.Rows[0]["orderNo"]) ? string.Empty : Convert.ToString(dt.Rows[0]["orderNo"]);
                g_name = Convert.IsDBNull(dt.Rows[0]["g_name"]) ? string.Empty : Convert.ToString(dt.Rows[0]["g_name"]);
                g_sort = Convert.IsDBNull(dt.Rows[0]["g_sort"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_sort"]);
                g_des = Convert.IsDBNull(dt.Rows[0]["g_des"]) ? string.Empty : Convert.ToString(dt.Rows[0]["g_des"]);
                g_price_S = Convert.IsDBNull(dt.Rows[0]["g_price_S"]) ? 0 : Convert.ToDouble(dt.Rows[0]["g_price_S"]);
                g_price_M = Convert.IsDBNull(dt.Rows[0]["g_price_M"]) ? 0 : Convert.ToDouble(dt.Rows[0]["g_price_M"]);
                g_cent = Convert.IsDBNull(dt.Rows[0]["g_cent"]) ? 0 : Convert.ToDouble(dt.Rows[0]["g_cent"]);
                g_parent = Convert.IsDBNull(dt.Rows[0]["g_parent"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_parent"]);
                g_isactive = Convert.IsDBNull(dt.Rows[0]["g_isactive"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_isactive"]);
                g_isdel = Convert.IsDBNull(dt.Rows[0]["g_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_isdel"]);
                g_wdate = Convert.IsDBNull(dt.Rows[0]["g_wdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["g_wdate"]);
                g_hits = Convert.IsDBNull(dt.Rows[0]["g_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_hits"]);
                regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                cityID = Convert.IsDBNull(dt.Rows[0]["cityID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["cityID"]);
            }
            else
            {
                throw new NotSupportedException("zagt_Goods：" + id + "不存在");
            }
        }

        private void MyInsertMethod(string _cno, string _g_name, int _g_sort, string _g_des, double _g_price_S, double _g_price_M, double _g_cent, int _g_parent, int _g_isactive, int _g_isdel, int _g_hits, int _cityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into zagt_Goods (cno,g_name,g_sort,g_des,g_price_S,g_price_M,g_cent,g_parent,g_isactive,g_isdel,g_hits,cityID) ");
            strSql.Append(" values (@cno,@g_name,@g_sort,@g_des,@g_price_S,@g_price_M,@g_cent,@g_parent,@g_isactive,@g_isdel,@g_hits,@cityID)");
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@cno",_cno),
            new SqlParameter("@g_name",_g_name),
            new SqlParameter("@g_sort",_g_sort),
            new SqlParameter("@g_des",_g_des),
            new SqlParameter("@g_price_S",_g_price_S),
            new SqlParameter("@g_price_M",_g_price_M),
            new SqlParameter("@g_cent",_g_cent),
            new SqlParameter("@g_parent",_g_parent),
            new SqlParameter("@g_isactive",_g_isactive),
            new SqlParameter("@g_isdel",_g_isdel),
            new SqlParameter("@g_hits",_g_hits),
            new SqlParameter("@cityID",_cityID)
            };
            //paras[0].Value = _cno;
            //paras[1].Value = _g_name;
            //paras[2].Value = g_sort;
            //paras[3].Value = _g_des;
            //paras[4].Value =_g_price_S;
            //paras[5].Value = _g_price_M;
            //paras[6].Value = _g_parent;
            //paras[7].Value = _g_isactive;
            //paras[8].Value = _g_isdel;
            //paras[9].Value = _g_hits;
            //paras[10].Value = _cityID;
            try
            {
                new comfun().ExecuteNonQuery(strSql.ToString(), paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        private void MyUpdateMethod(int _id, string _cno,  string _g_name, int _g_sort, string _g_des, double _g_price_S, double _g_price_M, double _g_cent, int _g_parent, int _g_isactive, int _g_isdel,DateTime _g_wdate, int _g_hits)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_Goods set cno=@cno,g_name=@g_name,g_sort=@g_sort,g_des=@g_des,g_price_S=@g_price_S,g_price_M=@g_price_M,g_cent=@g_cent,g_parent=@g_parent,g_isactive=@g_isactive,g_isdel=@g_isdel,g_wdate=@g_wdate where id=@id");
            SqlParameter[] paras = new SqlParameter[] { 
                 new SqlParameter("@cno",_cno),
            new SqlParameter("@g_name",_g_name),
            new SqlParameter("@g_sort",_g_sort),
            new SqlParameter("@g_des",_g_des),
            new SqlParameter("@g_price_S",_g_price_S),
            new SqlParameter("@g_price_M",_g_price_M),
            new SqlParameter("@g_parent",_g_parent),
            new SqlParameter("@g_isactive",_g_isactive),
            new SqlParameter("@g_isdel",_g_isdel),
            new SqlParameter("@g_wdate",_g_wdate),
            new SqlParameter("@g_hits",_g_hits),
                new SqlParameter("@id", _id) };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(strSql.ToString(), paras);

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

            cno = string.Empty; ;
            orderNo = string.Empty;
            g_name = string.Empty;
            g_sort = 0;
            g_des = string.Empty;
            g_price_S = 0;
            g_price_M = 0;
            g_cent = 0;
            g_parent = 0;
            g_isactive = 0;
            g_isdel = 0;
            g_wdate = System.DateTime.Now;
            g_hits = 0;
            cityID = 0;
            regtime = System.DateTime.Now;
            cityID = 0;
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(cno, g_name,g_sort,g_des,g_price_S,g_price_M,g_cent,g_parent,g_isactive,g_isdel,g_hits, cityID);
            }
            else
            {
                this.MyUpdateMethod(id, cno, g_name,g_sort,g_des,g_price_S,g_price_M,g_cent,g_parent,g_isactive,g_isdel,g_wdate,g_hits);
            }
        }

        /// <summary>
        /// 更新g_isactive字段为0
        /// </summary>
        /// <param name="_c_id"></param>
        public void UpdateIsactive(int _id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_Goods set g_isactive=0 where id=@id");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@id", _id) };
            new comfun().ExecuteNonQuery(strSql.ToString(), paras);
        }


        /// <summary>
        /// 删除处理
        /// </summary>
        /// <param name="_c_id"></param>
        public void UpdateIsdel(int _id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update zagt_Goods set g_isdel=1 where id=@id");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@id", _id) };
            new comfun().ExecuteNonQuery(strSql.ToString(), paras);
        }


        public DataTable GetDataTable()
        {
            DataTable dtGoods = comfun.GetDataTableBySQL("select * from zagt_Goods where g_isactive=1 and g_isdel=0");
            return dtGoods;
        }
        #endregion

        /// <summary>
        /// 统计产品数量
        /// </summary>
        /// <param name="_mid"></param>
        /// <returns></returns>
        public static int GetMsgCount(string _g_name)
        {
            DataTable dt = comfun.GetDataTableBySQL("select count(id) from zagt_Goods where g_name='" + _g_name + "'");
            return Convert.ToInt32(dt.Rows[0][0]);
        }

    }
}