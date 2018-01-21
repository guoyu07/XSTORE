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
    public class B2C_Goods
    {
        #region 属性
        public int id = 0;          //编号
        public string cno = "";     //类别编号
        public string bno = "";     //品牌编号
        public string g_no = "";    //货号
        public string g_txm = "";   //条形码
        public string g_name = "";  //名称
        public string g_unit = "";  //单位
        public string g_gif = "";   //代表图片
        public int g_isURL = 0;     //是否跳转
        public string g_URL = "";   //如果跳转，则连接地址
        public int g_sort = 99;     //排序
        public string g_des = "";   //描述
        public double g_price_B = 0.00; //采购价
        public double g_price_S = 0.00; //销售价
        public double g_price_M = 0.00; //市场价
        public double g_cent = 0.00;    //积分
        public double g_lowN = 0.00;//起订数量
        public int g_flag = 0;          //标志
        public string g_filename = "";  //文件名
        public string g_title = "";     //标题
        public string g_key = "";       //优化keywoed
        public string g_description = "";   //优化之description
        public int g_isactive = 1;            //启用否
        public int g_isdel = 0;               //是否删除
        public string g_sym = "";               //索引码
        public DateTime g_wdate = DateTime.Now; //上架时间
        public DateTime regtime = DateTime.Now; //录入时间
       
        public string g_gif2 = "";//下载文件
        public int g_buytype = 0;//购买途径
        public int g_xuni = 0;//是否虚拟物品
        public decimal g_buys = 0;//购买次数
        public int g_hits = 0;//浏览次数

        public string cname = "";//类别名称
        #endregion

        #region 构造函数
        public B2C_Goods() { }
        public B2C_Goods(int _id)
        {
            id = _id;
            this.load();
        }
        public B2C_Goods(string _g_name)
        {
            g_name = _g_name;
            this.load();
        }
        #endregion

        #region SELECT
        public void load()
        {
            string sql = "select *,(select c_name from b2c_category where c_no=cno ) as cname from B2C_Goods where id=" + id + "";
            if (id == 0)
            {
                if (!string.IsNullOrEmpty(g_name))
                {
                    sql = "select *,(select c_name from b2c_category where c_no=cno ) as cname from B2C_Goods where g_name='" + g_name + "'";
                }
                else
                {
                    throw new NotSupportedException("B2C_Goods ID：" + id + "不存在");
                }
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_Goods ID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    bno = Convert.IsDBNull(dt.Rows[0]["bno"]) ? "" : Convert.ToString(dt.Rows[0]["bno"]);
                    g_no = Convert.IsDBNull(dt.Rows[0]["g_no"]) ? "" : Convert.ToString(dt.Rows[0]["g_no"]);
                    g_txm = Convert.IsDBNull(dt.Rows[0]["g_txm"]) ? "" : Convert.ToString(dt.Rows[0]["g_txm"]);
                    g_name = Convert.IsDBNull(dt.Rows[0]["g_name"]) ? "" : Convert.ToString(dt.Rows[0]["g_name"]);
                    g_unit = Convert.IsDBNull(dt.Rows[0]["g_unit"]) ? "" : Convert.ToString(dt.Rows[0]["g_unit"]);
                    g_gif = Convert.IsDBNull(dt.Rows[0]["g_gif"]) ? "" : Convert.ToString(dt.Rows[0]["g_gif"]);
                    g_isURL = Convert.IsDBNull(dt.Rows[0]["g_isURL"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_isURL"]);
                    g_URL = Convert.IsDBNull(dt.Rows[0]["g_URL"]) ? "" : Convert.ToString(dt.Rows[0]["g_URL"]);
                    g_sort = Convert.IsDBNull(dt.Rows[0]["g_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["g_sort"]);
                    g_des = Convert.IsDBNull(dt.Rows[0]["g_des"]) ? "" : Convert.ToString(dt.Rows[0]["g_des"]);
                    g_price_B = Convert.IsDBNull(dt.Rows[0]["g_price_B"]) ? 0.00 : Convert.ToDouble(dt.Rows[0]["g_price_B"]);
                    g_price_S = Convert.IsDBNull(dt.Rows[0]["g_price_S"]) ? 0.00 : Convert.ToDouble(dt.Rows[0]["g_price_S"]);
                    g_price_M = Convert.IsDBNull(dt.Rows[0]["g_price_M"]) ? 0.00 : Convert.ToDouble(dt.Rows[0]["g_price_M"]);
                    g_cent = Convert.IsDBNull(dt.Rows[0]["g_cent"]) ? 0.00 : Convert.ToDouble(dt.Rows[0]["g_cent"]);
                    g_lowN = Convert.IsDBNull(dt.Rows[0]["g_lowN"]) ? 0.00 : Convert.ToDouble(dt.Rows[0]["g_lowN"]);
                    g_flag = Convert.IsDBNull(dt.Rows[0]["g_flag"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_flag"]);
                    g_filename = Convert.IsDBNull(dt.Rows[0]["g_filename"]) ? "" : Convert.ToString(dt.Rows[0]["g_filename"]);
                    g_title = Convert.IsDBNull(dt.Rows[0]["g_title"]) ? "" : Convert.ToString(dt.Rows[0]["g_filename"]);
                    g_key = Convert.IsDBNull(dt.Rows[0]["g_key"]) ? "" : Convert.ToString(dt.Rows[0]["g_key"]);
                    g_description = Convert.IsDBNull(dt.Rows[0]["g_description"]) ? "" : Convert.ToString(dt.Rows[0]["g_description"]);
                    g_isactive = Convert.IsDBNull(dt.Rows[0]["g_isactive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["g_isactive"]);
                    g_isdel = Convert.IsDBNull(dt.Rows[0]["g_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_isdel"]);
                    g_key = Convert.IsDBNull(dt.Rows[0]["g_key"]) ? "" : Convert.ToString(dt.Rows[0]["g_key"]);
                    g_sym = Convert.IsDBNull(dt.Rows[0]["g_sym"]) ? "" : Convert.ToString(dt.Rows[0]["g_sym"]);
                    g_wdate = Convert.IsDBNull(dt.Rows[0]["g_wdate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["g_wdate"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                    
                    g_gif2 = Convert.IsDBNull(dt.Rows[0]["g_gif2"]) ? "" : Convert.ToString(dt.Rows[0]["g_gif2"]);
                    g_buytype = Convert.IsDBNull(dt.Rows[0]["g_buytype"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_buytype"]);
                    g_xuni = Convert.IsDBNull(dt.Rows[0]["g_xuni"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_xuni"]);
                    //g_buys = Convert.IsDBNull(dt.Rows[0]["buynum"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["buynum"]);
                    g_hits = Convert.IsDBNull(dt.Rows[0]["g_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["g_hits"]);

                    cname = Convert.IsDBNull(dt.Rows[0]["cname"]) ? "" : Convert.ToString(dt.Rows[0]["cname"]);

                }
            }
            else
            {
                throw new NotSupportedException("B2C_Goods：" + id + ":" + cno + "不存在");
            }
        }
        #endregion

        #region INSERT
        private void myInsert(string _cno, string _bno, string _g_no, string _g_txm, string _g_name, string _g_unit, string _g_gif, int _g_isURL, string _g_URL, int _g_sort, string _g_des, double _g_price_B, double _g_price_S, double _g_price_M, double _g_cent,double _g_lowN, int _g_flag, string _g_filename, string _g_title, string _g_key, string _g_description, int _g_isactive, int _g_isdel,string _g_sym, DateTime _g_wdate, DateTime _regtime,string _g_gif2,int _g_buytype,int _g_xuni)
        {
            if (!string.IsNullOrEmpty(_g_name))
            {
                g_name = _g_name;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }
            try
            {
                string sql = "insert into B2C_Goods (cno,bno,g_no,g_txm,g_name,g_unit,g_gif,g_isURL,g_URL,g_sort,g_des,g_price_B,g_price_S,g_price_M,g_cent,g_lowN,g_flag,g_filename,g_title,g_key,g_description,g_isactive,g_isdel,g_sym,g_wdate,regtime,g_gif2,g_buytype,g_xuni) values (@cno,@bno,@g_no,@g_txm,@g_name,@g_unit,@g_gif,@g_isURL,@g_URL,@g_sort,@g_des,@g_price_B,@g_price_S,@g_price_M,@g_cent,@g_lowN,@g_flag,@g_filename,@g_title,@g_key,@g_description,@g_isactive,@g_isdel,@g_sym,@g_wdate,@regtime,@g_gif2,@g_buytype,@g_xuni)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", _cno), 
                    new SqlParameter("@bno", _bno), 
                    new SqlParameter("@g_no", _g_no),
                    new SqlParameter("@g_txm", _g_txm),
                    new SqlParameter("@g_name", _g_name),
                    new SqlParameter("@g_unit", _g_unit),
                    new SqlParameter("@g_gif", _g_gif),
                    new SqlParameter("@g_isURL", _g_isURL),
                    new SqlParameter("@g_URL", _g_URL),
                    new SqlParameter("@g_sort", _g_sort),
                    new SqlParameter("@g_des", _g_des),
                    new SqlParameter("@g_price_B", _g_price_B),
                    new SqlParameter("@g_price_S", _g_price_S),
                    new SqlParameter("@g_price_M", _g_price_M),
                    new SqlParameter("@g_cent", _g_cent),
                    new SqlParameter("@g_lowN", _g_lowN),
                    new SqlParameter("@g_flag", _g_flag),
                    new SqlParameter("@g_filename", _g_filename),
                    new SqlParameter("@g_title", _g_title),
                    new SqlParameter("@g_key", _g_key),
                    new SqlParameter("@g_description", _g_description),
                    new SqlParameter("@g_isactive", _g_isactive),
                    new SqlParameter("@g_isdel", _g_isdel),
                    new SqlParameter("@g_sym", _g_sym),
                    new SqlParameter("@g_wdate", _g_wdate),
                    new SqlParameter("@regtime", _regtime),

                    new SqlParameter("@g_gif2", _g_gif2),
                    new SqlParameter("@g_buytype", _g_buytype),
                    new SqlParameter("@g_xuni", _g_xuni)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region UPDATE
        private void myUpdate(int _id, string _cno, string _bno, string _g_no, string _g_txm, string _g_name, string _g_unit, string _g_gif, int _g_isURL, string _g_URL, int _g_sort, string _g_des, double _g_price_B, double _g_price_S, double _g_price_M, double _g_cent, double _g_lowN, string _g_filename, string _g_title, string _g_key, string _g_description, string _g_sym, DateTime _g_wdate, string _g_gif2, int _g_buytype, int _g_xuni)
        {
            if (!string.IsNullOrEmpty(_g_name))
            {
                g_name = _g_name;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }
            cno = _cno;
            bno = _bno;
            g_no = _g_no;
            g_txm = _g_txm;
            g_name = _g_name;
            g_unit = _g_unit;
            g_gif = _g_gif;
            g_isURL = _g_isURL;
            g_URL = _g_URL;
            g_sort = _g_sort;
            g_des = _g_des;
            g_price_B = _g_price_B;
            g_price_S = _g_price_S;
            g_price_M = _g_price_M;
            g_cent = _g_cent;
            g_lowN = _g_lowN;
            g_filename = _g_filename;
            g_sym = _g_sym;
            g_title = _g_title;
            g_key = _g_key;
            g_description = _g_description;
            g_wdate = _g_wdate;
            g_gif2 = _g_gif2;
            g_buytype = _g_buytype;
            g_xuni = _g_xuni;
            try
            {
                string sql = "update B2C_Goods set cno=@cno,bno=@bno,g_no=@g_no,g_txm=@g_txm,g_name=@g_name,g_unit=@g_unit,g_gif=@g_gif,g_isURL=@g_isURL,g_URL=@g_URL,g_sort=@g_sort,g_des=@g_des,g_price_B=@g_price_B,g_price_S=@g_price_S,g_price_M=@g_price_M,g_cent=@g_cent,g_lowN=@g_lowN,g_filename=@g_filename,g_title=@g_title,g_key=@g_key,g_sym=@g_sym,g_description=@g_description,g_wdate=@g_wdate,g_gif2=@g_gif2,g_buytype=@g_buytype,g_xuni=@g_xuni where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@cno", cno), 
                    new SqlParameter("@bno", bno), 
                    new SqlParameter("@g_no", g_no),
                    new SqlParameter("@g_txm", g_txm),
                    new SqlParameter("@g_name", g_name),
                    new SqlParameter("@g_unit", g_unit),
                    new SqlParameter("@g_gif", g_gif),
                    new SqlParameter("@g_isURL", g_isURL),
                    new SqlParameter("@g_URL", g_URL),
                    new SqlParameter("@g_sort", g_sort),
                    new SqlParameter("@g_des", g_des),
                    new SqlParameter("@g_price_B", g_price_B),
                    new SqlParameter("@g_price_S", g_price_S),
                    new SqlParameter("@g_price_M", g_price_M),
                    new SqlParameter("@g_cent", g_cent),
                    new SqlParameter("@g_lowN", g_lowN),
                    new SqlParameter("@g_filename", g_filename),
                    new SqlParameter("@g_title", g_title),
                    new SqlParameter("@g_key", g_key),
                    new SqlParameter("@g_sym", g_sym),
                    new SqlParameter("@g_description", g_description),
                    new SqlParameter("@g_wdate", g_wdate),
                    new SqlParameter("@g_gif2", _g_gif2),
                    new SqlParameter("@g_buytype", _g_buytype),
                    new SqlParameter("@g_xuni", _g_xuni)
                };
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region DELETE
        public static int myDel(int _id)
        {
            int res = 0;
            string _g_gif = "";
            if (_id == 0)
            {
                throw new NotSupportedException("没有取得类别ID号");
            }
            else
            {
                B2C_Goods bg = new B2C_Goods(_id);
                _g_gif = bg.g_gif;
                string sql = "delete from B2C_Goods where id=" + _id + "";
                if (!string.IsNullOrEmpty(_g_gif.Trim()))
                {
                    try
                    {
                        if (System.IO.File.Exists(consts.rootPath + "/" + _g_gif))
                        {
                            System.IO.File.Delete(consts.rootPath + "/" + _g_gif);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
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
        }
        #endregion

        public void Addnew()
        {
            id = 0;
            cno = "";
            bno = "";
            g_des = "";
            g_description = "";
            g_filename = "";
            g_flag = 0;
            g_key = "";
            g_name = "";
            g_no = "";
            g_price_B = 0.00;
            g_price_M = 0.00;
            g_price_S = 0.00;
            g_cent = 0.00;
            g_lowN = 0.00;
            g_sort = 99;
            g_title = "";
            g_txm = "";
            g_unit = "";
            g_URL = "";
            regtime = DateTime.Now;
            g_isactive = 1;
            g_isdel = 0;
            g_isURL = 0;
            g_sym = "";
            g_gif = "";
            g_wdate = DateTime.Now;
           

            g_gif2 = "";
            g_buytype = 0;
            g_xuni = 0;

            g_buys = 0;
            g_hits = 0;
        }

        #region 根据ID判断是添加还是修改
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(cno, bno, g_no, g_txm, g_name, g_unit, g_gif, g_isURL, g_URL, g_sort, g_des, g_price_B, g_price_S, g_price_M, g_cent,g_lowN, g_flag, g_filename, g_title, g_key, g_description, g_isactive, g_isdel,g_sym, g_wdate, regtime,g_gif2,g_buytype,g_xuni);
            }
            else
            {
                this.myUpdate(id, cno, bno, g_no, g_txm, g_name, g_unit, g_gif, g_isURL, g_URL, g_sort, g_des, g_price_B, g_price_S, g_price_M, g_cent, g_lowN, g_filename, g_title, g_key, g_description, g_sym, g_wdate, g_gif2, g_buytype, g_xuni);
            }
        }
        #endregion

        #region 设置按钮功能
        // 设置是否启用
        public static int setIsactive(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Goods set g_isactive= -1 * (g_isactive - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        /// 设置是否删除
        public static int setIsdel(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Goods set g_isdel= -1 * (g_isdel - 1) where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// 设置是否删除
        public static int setBuyType(int _buyType,string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Goods set g_buytype=" + _buyType.ToString() + " where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public static int setHits(string _id)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_Goods set g_hits=g_hits+1 where id in ('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        } 
        #endregion

        #region 条件查询
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Goods where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        #region 类别树形结构
        public static void getCategoryClassTree(int classid, System.Web.UI.HtmlControls.HtmlSelect cid)
        {
            string texts = "";
            string values = "";

            B2C_category cate = new B2C_category(classid);
            int depth = cate.c_level;
            while (depth > 0)
            {
                texts += "　";
                depth = depth - 1;
            }
            values = cate.c_no;
            if (cate.c_child < 1)
            {
                texts += " - " + cate.c_name;
                cid.Items.Add(new ListItem(texts, values));
            }
            else
            {
                texts += " + " + cate.c_name;
                cid.Items.Add(new ListItem(texts, values));
                DataTable classidArry1 = comfun.GetDataTableBySQL("select * from B2C_category where c_parent=" + classid + " order by c_id");
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getCategoryClassTree(Convert.ToInt32(dr["c_id"]), cid);
                }
            }
        }
        #endregion

        #region 品牌树形结构
        public static void getBrandClassTree(int classid, System.Web.UI.HtmlControls.HtmlSelect bid)
        {
            string texts = "";
            string values = "";

            B2C_brand cate = new B2C_brand(classid);
            int depth = cate.c_level;
            while (depth > 0)
            {
                texts += "　";
                depth = depth - 1;
            }
            values = cate.c_no;
            if (cate.c_child < 1)
            {
                texts += " - " + cate.c_name;
                bid.Items.Add(new ListItem(texts, values));
            }
            else
            {
                texts += " + " + cate.c_name;
                bid.Items.Add(new ListItem(texts, values));
                DataTable classidArry1 = comfun.GetDataTableBySQL("select * from B2C_brand where c_parent=" + classid + " order by c_id");
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getBrandClassTree(Convert.ToInt32(dr["c_id"]), bid);
                }
            }
        }
        #endregion

        //public static DataTable msglist(int _page, string _dzd, string _sql)
        //{
        //    int totalcount = 0;
        //    int totalpage = 0;
        //    int pagesize = consts.pagesize_Txt;
        //    int beginItem = 0;
        //    int endItem = 0;

        //    string sql = "select count(*) from B2C_Goods where 1=1 and " + _sql + "";
        //    totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
        //    totalpage = totalcount / pagesize;
        //    if (totalpage < totalcount / pagesize)
        //    {
        //        totalpage = totalpage + 1;
        //    }

        //    beginItem = pagesize * (_page - 1);
        //    endItem = pagesize * _page - 1;
        //    if (endItem > (totalcount - 1))
        //    {
        //        endItem = totalcount - 1;
        //    }

        //    if (beginItem < 0)
        //    {
        //        beginItem = 0;
        //    }

        //    try
        //    {
        //        DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Goods where " + _sql + " order by id desc");
        //        DataTable dt2 = proTable.Clone();
        //        for (int i = beginItem; i <= endItem; i++)
        //        {
        //            dt2.ImportRow(proTable.Rows[i]);
        //        }
        //        return dt2;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
