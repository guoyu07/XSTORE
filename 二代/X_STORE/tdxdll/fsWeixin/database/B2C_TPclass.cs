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
    public class B2C_TPclass
    {
        public int c_id =0;           //编号
        public string c_no = "";      //类别号
        public string c_name = "";    //名称
        public string c_gif = "";     //代表图片
        public string c_url = "";     //链接地址
        public int c_sort = 0;        //排序
        public string c_des = "";     //描述
        public int c_isactive = 1;    //是否启用:1为是,0为否
        public int c_isdel = 0;         //是否删除:0为否,1为是
        public DateTime regtime = DateTime.Now;  //录入时间
        public int c_parent = 0;      //父类编号
        public int c_level = 1;       //层级
        public int c_child = 0;       //子类数目
        public int cityid = Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());        //城市编号
   
        public  B2C_TPclass(){}
        public B2C_TPclass(int _cid)
        {
            c_id = _cid;
            this.load();
        }
        public B2C_TPclass(string _cno) {
            c_no = _cno;
            this.load();
        }
        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select * from B2C_TPclass where c_id=" + c_id + "";
            if (c_id == 0)
            {
                if (!string.IsNullOrEmpty(c_no))
                {
                    sql = "select * from B2C_TPclass where c_no='" + c_no + "' and cityid=" + cityid.ToString();
                }
                else
                {
                    throw new NotSupportedException("B2C_TPclassCID：" + c_id + "不存在");
                }
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_TPclassCID：" + c_id + "不唯一");
                }
                else
                {
                    c_id = Convert.IsDBNull(dt.Rows[0]["c_id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["c_id"]);
                    c_no = Convert.IsDBNull(dt.Rows[0]["c_no"]) ? "" : Convert.ToString(dt.Rows[0]["c_no"]);
                    c_name = Convert.IsDBNull(dt.Rows[0]["c_name"]) ? "" : Convert.ToString(dt.Rows[0]["c_name"]);
                    c_gif = Convert.IsDBNull(dt.Rows[0]["c_gif"]) ? "" : Convert.ToString(dt.Rows[0]["c_gif"]);
                    c_url = Convert.IsDBNull(dt.Rows[0]["c_url"]) ? "" : Convert.ToString(dt.Rows[0]["c_url"]);
                    c_sort = Convert.IsDBNull(dt.Rows[0]["c_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["c_sort"]);
                    c_des = Convert.IsDBNull(dt.Rows[0]["c_des"]) ? "" : Convert.ToString(dt.Rows[0]["c_des"]);
                    c_isactive = Convert.IsDBNull(dt.Rows[0]["c_isactive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["c_isactive"]);
                    c_isdel = Convert.IsDBNull(dt.Rows[0]["c_isdel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_isdel"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);
                    c_parent = Convert.IsDBNull(dt.Rows[0]["c_parent"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_parent"]);
                    c_level = Convert.IsDBNull(dt.Rows[0]["c_level"]) ? 1 : Convert.ToInt32(dt.Rows[0]["c_level"]);
                    c_child = Convert.IsDBNull(dt.Rows[0]["c_child"]) ? 0 : Convert.ToInt32(dt.Rows[0]["c_child"]);
                    //cityid = Convert.IsDBNull(dt.Rows[0]["cityid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["cityid"]);
                }
            }
            else
            {
                throw new NotSupportedException("B2C_TPclass：" + c_id + ":" + c_no + "不存在");
            }

        }
        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _cno,string _cname,string _cgif,string _curl,int _csort,string _cdes,int _cisactive,int _cisdel,DateTime _regtime,int _cparent,int _clevel,int _cchild,int _ccityid)
        {
            if (!string.IsNullOrEmpty(_cname))
            {
                c_name = _cname;
            }
            else
            {
                throw new NotSupportedException("请输入类别名称");
            }
            if (_cparent != 0)
            {
                c_parent = _cparent;
                B2C_TPclass btc = new B2C_TPclass(c_parent);
                c_level = btc.c_level + 1;
                c_no = "";
                DataTable dt = comfun.GetDataTableBySQL("select top 1 * from B2C_TPclass where c_parent=" + c_parent + " and cityID=" + cityid.ToString().Trim()+" order by c_id desc");
                if (dt.Rows.Count > 0)
                {
                    string c_no_tmp = dt.Rows[0]["c_no"].ToString();
                    c_no_tmp = c_no_tmp.Substring(c_no_tmp.Length - 3);
                    int c_no_tmp_int = Convert.IsDBNull(c_no_tmp) ? 0 : Convert.ToInt32(c_no_tmp);
                    c_no_tmp_int = c_no_tmp_int + 1;
                    c_no_tmp = c_no_tmp_int.ToString();
                    while (c_no_tmp.Length < 3)
                    {
                        c_no_tmp = "0" + c_no_tmp;
                    }
                    c_no = btc.c_no + c_no_tmp;
                }
                else
                {
                    c_no = btc.c_no + "001";
                }
            }
            else
            {
                c_parent = 0;
                c_level = 1;
                DataTable dt = comfun.GetDataTableBySQL("select top 1 * from B2C_TPclass where c_parent=0 and cityID=" + cityid.ToString().Trim() + "  order by c_id desc");
                if (dt.Rows.Count > 0)
                {
                    string c_no_tmp = dt.Rows[0]["c_no"].ToString();
                    int c_no_tmp_int = Convert.IsDBNull(c_no_tmp) ? 0 : Convert.ToInt32(c_no_tmp); ;
                    c_no_tmp_int = c_no_tmp_int + 1;
                    c_no_tmp = c_no_tmp_int.ToString();
                    while (c_no_tmp.Length < 3)
                    {
                        c_no_tmp = "0" + c_no_tmp;
                    }
                    c_no = c_no_tmp;
                }
                else
                {
                    c_no = "001";
                }
            }
            try
            {
                string queryString = "update  B2C_TPclass set c_child=c_child+1 where c_id=" + c_parent;
                comfun.UpdateBySQL(queryString);
                string sql = "insert into B2C_TPclass (c_no,c_name,c_gif,c_url,c_sort,c_des,c_isactive,c_isdel,regtime,c_parent,c_level,c_child,cityid) values (@c_no,@c_name,@c_gif,@c_url,@c_sort,@c_des,@c_isactive,@c_isdel,@regtime,@c_parent,@c_level,@c_child,@cityid)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@c_no", c_no), 
                    new SqlParameter("@c_name", c_name), 
                    new SqlParameter("@c_gif", _cgif),
                    new SqlParameter("@c_url", _curl),
                    new SqlParameter("@c_sort", _csort),
                    new SqlParameter("@c_des", _cdes),
                    new SqlParameter("@c_isactive", _cisactive),
                    new SqlParameter("@c_isdel", _cisdel),
                    new SqlParameter("@regtime", _regtime),
                    new SqlParameter("@c_parent", c_parent),
                    new SqlParameter("@c_level", c_level),
                    new SqlParameter("@c_child", _cchild),
                    new SqlParameter("@cityid", _ccityid)};

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
        private void myUpdate(int _cid, string _cno, string _cname, string _cgif, string _curl, string _cdes,int _cparent,int _clevel,int _csort)
        {
            if (!string.IsNullOrEmpty(_cname))
            {
                c_name = _cname;
            }
            else
            {
                throw new NotSupportedException("请输入类别名称");
            }
            c_sort = _csort;
            c_gif = _cgif;
            c_des = _cdes;
            c_url = _curl;
            int c_parent_old = c_parent;
            string c_no_old = c_no;
            int c_level_old = c_level;
            if (_cparent != c_parent_old)
            {
                _cparent = c_parent;
                B2C_TPclass btc = new B2C_TPclass(_cparent);
                c_level = btc.c_level + 1;
                c_no = "";
                DataTable dt = comfun.GetDataTableBySQL("select * from B2C_TPclass where c_parent=" + c_parent + " and cityID=" + cityid.ToString().Trim() + " order by c_id desc");
                if (dt.Rows.Count > 0)
                {
                    string c_no_tmp = dt.Rows[0]["c_no"].ToString();
                    c_no_tmp = c_no_tmp.Substring(c_no_tmp.Length - 3);
                    int c_no_tmp_int = Convert.ToInt32(c_no_tmp);
                    c_no_tmp_int = c_no_tmp_int + 1;
                    c_no_tmp = c_no_tmp_int.ToString();
                    while (c_no_tmp.Length < 3)
                    {
                        c_no_tmp = "0" + c_no_tmp;

                    }
                    c_no = btc.c_no + c_no_tmp;
                }
                else
                {
                    c_no = btc.c_no + "001";
                }
            }
            try
            {
                string sql = "update B2C_TPclass set c_no=@c_no,c_name=@c_name,c_gif=@c_gif,c_url=@c_url,c_des=@c_des,c_sort=@c_sort,c_level=@c_level where c_id=" + _cid;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@c_no", c_no), 
                    new SqlParameter("@c_name", c_name), 
                    new SqlParameter("@c_gif", c_gif),
                    new SqlParameter("@c_url", c_url),
                    new SqlParameter("@c_des", c_des),
                    new SqlParameter("@c_sort", c_sort),
                    new SqlParameter("@c_level", c_level)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
                if (_cparent != c_parent_old)
                {
                    //父类发生编号,需要修改一系列参数
                    //改变原父类的c_child参数
                    //string querystring2 = "update B2C_TPclass set c_child=c_child-1 where c_id=" + c_parent_old;
                    //comfun.UpdateBySQL(querystring2);
                    ////改变现在类的c_child 参数
                    //string querystring3 = "update B2C_TPclass set c_child=c_child+1 where c_id=" + _cparent;
                    //comfun.UpdateBySQL(querystring3);
                    //改变下属的c_level,c_no参数
                    string querystring4 = "update B2C_TPclass set c_child=c_child-1 where c_id=" + c_parent_old +"; update B2C_TPclass set c_child=c_child+1 where c_id=" + _cparent + "; update B2C_TPclass set c_level=" + c_level + 1 + ",c_no ='" + c_no + "'+right(c_no,len(c_no)-" + c_no_old.Length + ")" + " where c_no like '" + c_no_old + "%' and cityid=" + cityid.ToString();
                    comfun.UpdateBySQL(querystring4);
                }
                
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
            string c_no = "";
            int c_parent = 0;
            int c_no_len = 0;
            int c_level = 0;
            string c_gif = "";
            int res = 0;
            if (_cid == 0)
            {
                throw new NotSupportedException("没有取得类别ID号");
            }
            else
            {
                B2C_TPclass btc = new B2C_TPclass(_cid);
                c_no = btc.c_no;
                c_parent = btc.c_parent;
                c_no_len = btc.c_no.Length;
                c_level = btc.c_level;
                c_gif = btc.c_gif;
                string sql = "delete from B2C_TPclass where c_id=" + _cid + "; update B2C_TPclass set c_child=c_child -1 where c_id=" + c_parent + "; update B2C_TPclass set c_no=+right(c_no,len(c_no)-" + c_no_len + "),c_level=c_level-" + c_level + " where c_no like '" + c_no + "%' and cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + "; update B2C_TPclass set c_parent=" + c_parent + "  where c_parent=" + _cid + "";
                if (!string.IsNullOrEmpty(c_gif.Trim()))
                {
                    try
                    {
                        if (System.IO.File.Exists(consts.rootPath + "/" + c_gif))
                        {
                            System.IO.File.Delete(consts.rootPath + "/" + c_gif);
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
            //try
            //{
            //   res= comfun.DelbySQL("delete from B2C_TPclass where c_id in ('" + _cid + "')");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return res;
        }
        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            if (c_id == 0)
            {
                this.myInsert(c_no, c_name, c_gif, c_url, c_sort, c_des, c_isactive, c_isdel, regtime, c_parent, c_level, c_child, cityid);
            }
            else
            {
                this.myUpdate(c_id, c_no, c_name, c_gif, c_url, c_des, c_parent, c_level,c_sort);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            c_id = 0;
            c_no = "";
            c_name = "";
            c_gif = "";
            c_url = "";
            c_sort = 99;
            c_des = "";
            c_isactive = 1;
            c_isdel = 0;
            regtime = DateTime.Now;
            c_parent = 0;
            c_level = 1;
            c_child = 0;
            cityid = Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());    
        }
        #region 设置按钮功能
        /// <summary>
        /// 设置是否启用
        /// </summary>
        /// <param name="_cid"></param>
        public static int setC_isactive(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_TPclass set c_isactive= -1 * (C_isActive - 1) where c_id in ('" + _cid + "')");
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
        public static int setC_isdel(string _cid)
        {
            int res = 0;
            try
            {
                res = comfun.UpdateBySQL("update B2C_TPclass set c_isdel= -1 * (c_isdel - 1) where c_id in ('" + _cid + "')");
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
        public static DataTable GetList(string _dzd,string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_TPclass where cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + " and " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        /// <summary>
        /// 树形结构
        /// </summary>
        public static void getOneClassTree(int classid, System.Web.UI.HtmlControls.HtmlSelect cid)
        {
            string texts = "";
            string values = "";

            B2C_TPclass cate = new B2C_TPclass(classid);
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
                DataTable classidArry1 = comfun.GetDataTableBySQL("select * from B2C_TPclass where c_parent=" + classid + " order by c_id");
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getOneClassTree(Convert.ToInt32(dr["c_id"]), cid);
                }
            }
        }

        #region "路径回溯"
        public static string getURLPath(string _cno, int _limit, string _Seed)
        {
            string result = "";
            int _length = _cno.Length / 3;
            for (int i = _length; i > _limit; i--)
            {
                string cno = _cno.Substring(0, 3 * i);
                string sql = "select c_name,c_url \n";
                sql +=",(select top 1 (case when g_isurl=1 and not (g_url is null) then g_url \n";
                sql +="when not(gfile is null) and rtrim(ltrim(gfile))<>'' then gfile   \n";
                sql +="else 'page_'+ cast(id as varchar)+'.html' \n";
			    sql +="end) from b2c_tpage where cno=c_no and cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + " order by g_sort,id desc) as g_filename    \n";
                sql += "from b2c_tpclass where c_no='" + cno + "' and cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + " \n";
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if(dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    string myFile = dr["c_url"].ToString().Trim();// dr["g_filename"].ToString().Trim();
                    if (myFile.Trim() == "")
                        myFile = dr["g_filename"].ToString().Trim();
                    if (myFile.Trim() == "")
                        myFile = "####";
                    string result2 = "<a href='" + myFile + "'>" + dr["c_name"].ToString().Trim() + "</a>";
                    if (result != "")
                        result = result2 + " > " + result;
                    else
                        result = result2;   
                    dr = null;
                }
                dt.Dispose();
                dt = null;
            }
            return result;
        }
        #endregion
    }
}
