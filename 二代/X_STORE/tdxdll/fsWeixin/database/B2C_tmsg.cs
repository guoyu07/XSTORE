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
    public class B2C_tmsg
    {
        public int id = 0;
        /// '''''   关于类别的一些参数
        public string cno = "";
        public string cname = "";
        public string cpath = "";
        public string cdes = "";
        public int shopID = 0;
        public string t_title = "";
        public string t_author = "";
        public string t_source = "";
        public string t_gif = "";
        public string t_msg = "";
        public int t_isUrl = 0;
        public string t_url = "";             //如果为一个URL链接，则其连接地址为t_url
        public string t_filename = "";        //生成静态页面时，则使用此文件名
        public int t_sort = 99;
        public int t_iFlag = 0;
        public int t_cFlag = 0;
        public int t_hits = 0;
        public DateTime t_wdate = System.DateTime.Now;
        public DateTime regdate = System.DateTime.Now;
        public int t_isActive = 1;
        public int t_isDel = 0;
        public int t_isHead = 0;
        public int t_isCHead = 0;
        public string t_key = "";
        public string t_des = "";
        //public int cityID = Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());

        public string iFlag = "";
        public string cFlag = "";
        public string isActive = "启";
        public string isDel = "未";
        public string isHead = "否";
        public string isCHead = "否";


        #region " No Parameter "
        public B2C_tmsg()
        {
        }
        #endregion

        #region " With Parameter "
        public B2C_tmsg(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        private void LoadData()
        {
            DataTable dt = comfun.GetDataTableBySQL("SELECT *,(select c_name from b2c_tclass where c_no=cno) as cname,"+ // and cityid=" + cityID.ToString() +
                "(select c_url from b2c_tclass where c_no=cno) as cpath," + // and cityid=" + cityID.ToString() + "
                "(select c_des from b2c_tclass where c_no=cno) as cdes" +// and cityid=" + cityID.ToString() + "
                " FROM b2c_Tmsg WHERE id = " + id + "");   //
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("b2c_TmsgID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    cname = Convert.IsDBNull(dt.Rows[0]["cname"]) ? "" : Convert.ToString(dt.Rows[0]["cname"]);
                    cpath = Convert.IsDBNull(dt.Rows[0]["cpath"]) ? "" : Convert.ToString(dt.Rows[0]["cpath"]);
                    cdes = Convert.IsDBNull(dt.Rows[0]["cdes"]) ? "" : Convert.ToString(dt.Rows[0]["cdes"]);
                    shopID = Convert.IsDBNull(dt.Rows[0]["shopID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["shopID"]);
                    t_title = Convert.IsDBNull(dt.Rows[0]["T_title"]) ? "" : Convert.ToString(dt.Rows[0]["T_title"]);
                    t_author = Convert.IsDBNull(dt.Rows[0]["T_author"]) ? "" : Convert.ToString(dt.Rows[0]["T_author"]);
                    t_source = Convert.IsDBNull(dt.Rows[0]["T_source"]) ? "" : Convert.ToString(dt.Rows[0]["T_source"]);
                    t_gif = Convert.IsDBNull(dt.Rows[0]["T_gif"]) ? "" : Convert.ToString(dt.Rows[0]["T_gif"]);
                    t_msg = Convert.IsDBNull(dt.Rows[0]["T_msg"]) ? "" : Convert.ToString(dt.Rows[0]["T_msg"]);
                    t_isUrl = Convert.IsDBNull(dt.Rows[0]["t_isurl"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_isurl"]);
                    t_url = Convert.IsDBNull(dt.Rows[0]["t_url"]) ? "" : Convert.ToString(dt.Rows[0]["t_url"]);
                    t_filename = Convert.IsDBNull(dt.Rows[0]["t_filename"]) ? "" : Convert.ToString(dt.Rows[0]["t_filename"]);
                    t_sort = Convert.IsDBNull(dt.Rows[0]["t_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["t_sort"]);
                    t_iFlag = Convert.IsDBNull(dt.Rows[0]["T_iFlag"]) ? 0 : Convert.ToInt32(dt.Rows[0]["T_iFlag"]);
                    t_cFlag = Convert.IsDBNull(dt.Rows[0]["T_cFlag"]) ? 0 : Convert.ToInt32(dt.Rows[0]["T_cFlag"]);
                    t_hits = Convert.IsDBNull(dt.Rows[0]["T_hits"]) ? 0 : Convert.ToInt32(dt.Rows[0]["T_hits"]);
                    t_wdate = Convert.IsDBNull(dt.Rows[0]["T_wdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["T_wdate"]);
                    regdate = Convert.IsDBNull(dt.Rows[0]["regdate"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regdate"]);
                    t_isActive = Convert.IsDBNull(dt.Rows[0]["T_isActive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["T_isActive"]);
                    t_isDel = Convert.IsDBNull(dt.Rows[0]["T_isDel"]) ? 0 : Convert.ToInt32(dt.Rows[0]["T_isDel"]);
                    t_isHead = Convert.IsDBNull(dt.Rows[0]["t_ishead"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_ishead"]);
                    t_isCHead = Convert.IsDBNull(dt.Rows[0]["t_ischead"]) ? 0 : Convert.ToInt32(dt.Rows[0]["t_ischead"]);
                    t_key = Convert.IsDBNull(dt.Rows[0]["t_key"]) ? "" : Convert.ToString(dt.Rows[0]["t_key"]);
                    t_des = Convert.IsDBNull(dt.Rows[0]["t_des"]) ? "" : Convert.ToString(dt.Rows[0]["t_des"]);
                    t_sort = Convert.IsDBNull(dt.Rows[0]["t_sort"]) ? 99 : Convert.ToInt32(dt.Rows[0]["t_sort"]);
                    //cityID = Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());

                    ///'''''''''''''''
                    switch (t_iFlag)
                    {
                        case 1:
                            iFlag = "isNew.gif";
                            break;
                        case 2:
                            iFlag = "isHot.gif";
                            break;
                        case 3:
                            iFlag = "isSpecial.gif";
                            break;
                        default:
                            iFlag = "";
                            break;
                    }
                    switch (t_cFlag)
                    {
                        case 1:
                            cFlag = "red";
                            break;
                        case 2:
                            cFlag = "green";
                            break;
                        case 3:
                            cFlag = "blue";
                            break;
                        default:
                            cFlag = "";
                            break;
                    }
                    if (t_isActive == 1)
                    {
                        isActive = "启";
                    }
                    else
                    {
                        isActive = "停";
                    }
                    if (t_isDel == 1)
                    {
                        isDel = "已删";
                    }
                    else
                    {
                        isDel = "未";
                    }
                    if (t_isHead == 0)
                    {
                        isHead = "是";
                    }
                    else
                    {
                        isHead = "否";
                    }
                    if (t_isCHead == 0)
                    {
                        isCHead = "是";
                    }
                    else
                    {
                        isCHead = "否";
                    }
                }
            }
            else
            {
                throw new NotSupportedException("b2c_TmsgID：" + id + "不存在");
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        private void MyInsertMethod(string _cno, int _shopID, string _t_title, string _t_author, string _t_source, string _t_gif, string _t_msg, int _t_isurl, string _t_url, string _t_filename, int _t_sort, int _t_iflag, int _t_cflag, int _t_hits, DateTime _t_wdate, DateTime _regdate, int _t_isactive, int _t_isdel, int _t_ishead, int _t_ischead, string _t_key, string _t_des) //, int _cityID
        {

            string queryString = " INSERT INTO b2c_Tmsg (cno,shopID,t_title,t_author,t_source,t_gif,t_msg,t_isurl,t_url,t_filename,t_sort,t_iflag,t_cflag,t_hits,t_wdate,regdate,t_isactive,t_isdel,t_ishead,t_ischead,t_key,t_des)" + //,cityID
                " VALUES (@cno,@shopID,@t_title,@t_author,@t_source,@t_gif,@t_msg,@t_isurl,@t_url,@t_filename,@t_sort,@t_iflag,@t_cflag,@t_hits,@t_wdate,@regdate,@t_isactive,@t_isdel,@t_ishead,@t_ischead,@t_key,@t_des)"; //,@cityID
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@cno", _cno), 
                new SqlParameter("@shopID", _shopID),
                //new SqlParameter("@cityID", _cityID),
                new SqlParameter("@T_title", _t_title),
                new SqlParameter("@T_author", _t_author),
                new SqlParameter("@T_source", _t_source),
                new SqlParameter("@t_key", _t_key),
                new SqlParameter("@T_des", _t_des),
                new SqlParameter("@T_gif", _t_gif),
                new SqlParameter("@T_sort", _t_sort),
                new SqlParameter("@T_msg", _t_msg),
                new SqlParameter("@T_iFlag", _t_iflag),
                new SqlParameter("@T_cFlag", _t_cflag),
                new SqlParameter("@T_hits", _t_hits),
                new SqlParameter("@T_wdate", _t_wdate),
                new SqlParameter("@regdate", _regdate),
                new SqlParameter("@T_isActive", _t_isactive),
                new SqlParameter("@T_isDel", _t_isdel),
                new SqlParameter("@T_isHead", _t_ishead),
                new SqlParameter("@T_isCHead", _t_ischead),
                new SqlParameter("@t_isUrl", _t_isurl),
                new SqlParameter("@t_url", _t_url),
                new SqlParameter("@t_filename", _t_filename)};

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        private void MyUpdateMethod(int _id, string _cno, int _shopID, string _t_title, string _t_author, string _t_source, string _t_gif, string _t_msg, int _t_isurl, string _t_url, string _t_filename, int _t_sort, int _t_iflag, int _t_cflag, int _t_hits, DateTime _t_wdate, DateTime _regdate, int _t_isactive, int _t_isdel, int _t_ishead, int _t_ischead, string _t_key, string _t_des) //, int _cityID
        {
            string queryString = "UPDATE b2c_Tmsg SET cno=@cno,shopID=@shopID,t_title=@t_title,t_author=@t_author,t_source=@t_source,t_gif=@t_gif,t_msg=@t_msg,t_isurl=@t_isurl,t_url=@t_url,t_filename=@t_filename,t_sort=@t_sort,t_iflag=@t_iflag,t_cflag=@t_cflag,t_hits=@t_hits,t_wdate=@t_wdate,regdate=@regdate,t_isactive=@t_isactive,t_isdel=@t_isdel,t_ishead=@t_ishead,t_ischead=@t_ischead,t_key=@t_key,t_des=@t_des WHERE id =" + id; //,cityID=@cityID
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@cno", _cno), 
                new SqlParameter("@shopID", _shopID),
                //new SqlParameter("@cityID", _cityID),
                new SqlParameter("@T_title", _t_title),
                new SqlParameter("@T_author", _t_author),
                new SqlParameter("@T_source", _t_source),
                new SqlParameter("@t_key", _t_key),
                new SqlParameter("@T_des", _t_des),
                new SqlParameter("@T_gif", _t_gif),
                new SqlParameter("@T_sort", _t_sort),
                new SqlParameter("@T_msg", _t_msg),
                new SqlParameter("@T_iFlag", _t_iflag),
                new SqlParameter("@T_cFlag", _t_cflag),
                new SqlParameter("@T_hits", _t_hits),
                new SqlParameter("@T_wdate", _t_wdate),
                new SqlParameter("@regdate", _regdate),
                new SqlParameter("@T_isActive", _t_isactive),
                new SqlParameter("@T_isDel", _t_isdel),
                new SqlParameter("@T_isHead", _t_ishead),
                new SqlParameter("@T_isCHead", _t_ischead),
                new SqlParameter("@t_isUrl", _t_isurl),
                new SqlParameter("@t_url", _t_url),
                new SqlParameter("@t_filename", _t_filename)};


            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

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

            cno = "";
            shopID = 0;
            t_title = "";
            t_author = "";
            t_source = "";
            t_gif = "";
            t_msg = "";
            t_isUrl = 0;
            t_url = "";
            t_filename = "";
            t_sort = 99;
            t_iFlag = 0;
            t_cFlag = 0;
            t_hits = 0;
            t_wdate = System.DateTime.Now;
            regdate = System.DateTime.Now;
            t_isActive = 1;
            t_isDel = 0;
            t_isHead = 0;
            t_isCHead = 0;
            t_key = "";
            t_des = "";
            //cityID = Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString());
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(cno, shopID, t_title, t_author, t_source, t_gif, t_msg, t_isUrl, t_url, t_filename, t_sort, t_iFlag, t_cFlag, t_hits, t_wdate, regdate, t_isActive, t_isDel, t_isHead, t_isCHead, t_key, t_des); //, cityID
            }
            else
            {
                this.MyUpdateMethod(id, cno, shopID, t_title, t_author, t_source, t_gif, t_msg, t_isUrl, t_url, t_filename, t_sort, t_iFlag, t_cFlag, t_hits, t_wdate, regdate, t_isActive, t_isDel, t_isHead, t_isCHead, t_key, t_des); //, cityID
            }
        }

        public static int Delete(int _id)
        {
            //删除图片
            B2C_tmsg tt = new B2C_tmsg(_id);
            if (!string.IsNullOrEmpty(tt.t_gif))
            {
                if (System.IO.File.Exists(consts.rootPath + "/" + tt.t_gif))
                {
                    System.IO.File.Delete(consts.rootPath + "/" + tt.t_gif);
                }
            }
            try
            {
                return comfun.DelByInt("b2c_Tmsg", "id", _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("b2c_TmsgID：" + _id + "删除失败");
            }
        }

        #endregion

        #region " 设置新、特、状态等 "
        public static int setiFlag(string _iflag, int _t_iflag)
        {
            try
            {
                return comfun.UpdateBySQL("update b2c_Tmsg set T_iFlag=" + _t_iflag + " where id in ('" + _iflag + "')");
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static int setcFlag(string _cflag, int _t_cflag)
        {
            try
            {
                return comfun.UpdateBySQL("update b2c_Tmsg set T_cFlag=" + _t_cflag + " where id in('" + _cflag + "')");
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static int setIsActive(string _id)
        {
            try
            {
                return comfun.UpdateBySQL("update b2c_Tmsg set T_isActive=-1*(T_isActive-1) where id in('" + _id + "')");
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static int setIsDel(int _id)
        {
            try
            {
                return comfun.UpdateBySQL("update b2c_Tmsg set T_isDel=-1*(T_isDel-1) where id=" + _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static int setIsHead(int _id)
        {
            try
            {
                return comfun.UpdateBySQL("update b2c_Tmsg set T_IsHead=-1*(T_IsHead-1) where id=" + _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        public static int setIsCHead(int _id)
        {
            try
            {
                return comfun.UpdateBySQL("update b2c_Tmsg set T_IsCHead=-1*(T_IsCHead-1) where id=" + _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region " 更新相关数字等 "
        public void updateHits()
        {
            try
            {
                comfun.UpdateBySQL("update b2c_Tmsg set T_hits=T_hits+1 where id=" + id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        #endregion

        #region "shared function"
        public static DataTable msglist(string keyword, string cno, int iflag, int cflag, int isActive, string sortid, bool sorttype)
        {
            string sql = "select id from b2c_Tmsg where T_title like '%" + keyword +
                "%'"; //and cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString()
            if (!string.IsNullOrEmpty(cno))
            {
                sql = sql + " and cno like '" + cno + "%'";
            }
            if (iflag != 0)
            {
                sql = sql + " and T_iFlag = " + iflag;
            }
            if (cflag != 0)
            {
                sql = sql + " and T_cFlag = " + cflag;
            }
            if (isActive == 1)
            {
                sql = sql + " and T_isActive=1 ";
            }
            sql = sql + " order by " + sortid;
            if (!sorttype)
            {
                sql = sql + " desc";
            }
            if (sortid != "id")
            {
                sql = sql + ", id desc";
            }

            DataTable proTable = comfun.GetDataTableBySQL(sql);

            return proTable;
        }
        public static DataTable msglist(int _page, string _dzd, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from B2C_tmsg where 1=1 and " + _sql;// +" and cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString();
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
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from b2c_Tmsg where " + _sql + " order by id desc"); // and cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + "
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
        public static DataTable topMsglist(int tops, int lens, string cno, int iflag, bool iPic)
        {
            DataTable dt = null;
            string sql = "select top " + tops + "  id,left(t_title," + lens + ") as t_title,t_iflag,T_cFlag,t_wdate,t_gif from b2c_Tmsg";
                //" where cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString();
            if (!string.IsNullOrEmpty(cno))
            {
                sql = sql + " and cno like '" + cno + "%'";
            }
            if (iflag != 0)
            {
                sql = sql + " and T_iFlag = " + iflag;
            }
            if (iPic == true)
            {
                sql = sql + " and (not t_gif='')";
            }
            sql = sql + " order by t_sort,id desc";

            dt = comfun.GetDataTableBySQL(sql);
            return dt;
        }

        #endregion
        public static void getOneClassTree(int classid, System.Web.UI.HtmlControls.HtmlSelect cid)
        {
            string texts = "";
            string values = "";

            B2C_tclass cate = new B2C_tclass(classid);
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
                DataTable classidArry1 = comfun.GetDataTableBySQL("select * from B2C_tclass where c_parent=" + classid + " order by c_id");
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getOneClassTree(Convert.ToInt32(dr["c_id"]), cid);
                }
            }
        }
        public static string retNewsHtml(string _cno, int _topnum, int _len, int _shopID)
        {
            try
            {
                string str = "";
                DataTable dt = comfun.GetDataTableBySQL("select top " + _topnum + " id,t_url,t_isurl,t_wdate,t_filename,left(t_title," + _len +
                    ")as ttitle,(select c_name from B2C_tclass where B2C_tclass.c_no=B2C_tmsg.cno)as cname from B2C_tmsg" + // and cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + "
                    " where shopID=" + _shopID + " and cno like '" + _cno +
                    "%' and t_isactive=1 and t_isdel=0 order by t_sort"); // and cityid=" + System.Web.HttpContext.Current.Session["wID"].ToString() + "
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["t_isurl"]) == 0)
                        {
                            if (dr["t_filename"].ToString() == "")
                            {
                                str += @"<li><a href=""/news-" + dr["id"] + ".html\"><b>" + dr["cname"] + "</b> " + dr["ttitle"] + "…</a><span>" + Convert.ToDateTime(dr["t_wdate"].ToString()).ToShortDateString() + "</span></li>";
                            }
                            else
                            {
                                str += @"<li><a href=""/" + dr["t_filename"] + "\"><b>" + dr["cname"] + "</b> " + dr["ttitle"] + "…</a><span>" + Convert.ToDateTime(dr["t_wdate"].ToString()).ToShortDateString() + "</span></li>";
                            }
                        }
                        else
                        {
                            str += @"<li><a href=http://" + dr["t_url"] + " target=\"_blank\"><b>" + dr["cname"] + "</b> " + dr["ttitle"] + "…</a><span>" + Convert.ToDateTime(dr["t_wdate"].ToString()).ToShortDateString() + "</span></li>";
                        }
                    }

                }
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string createMsg(DataTable _dt)
        {
            string result = "";
            result = result + "<ul>";
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                //<img src="images/xxx.jpg" width="25" height="22" alt="">《销售家》让你从无到有，助力菜鸟腾飞，迈出销售第一步！<br />
                result = result + "<img src='images/xxx.jpg' width='25' height='22' alt=''><a href='news_" + _dt.Rows[i]["id"] + ".html'>" + _dt.Rows[i]["t_title"] + "<br />";
            }
            return result;
        }
        public static string createNew(DataRow _dr)
        {
            string result = "";
            result = result + "<table width='98%' height='66' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td align='center'><strong>";
            result = result + _dr["t_title"];
            result = result + "</strong></td></tr></tbody></table>";
            result = result + "<table width='98%' height='12' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td style='line-height:45px;' align='center'>";
            result = result + "文:" + _dr["t_author"] + "  来源:" + _dr["t_source"] + "  时间:" + _dr["regdate"];
            result = result + "</td></tr></tbody>";
            result = result + "<table width='98%' height='35' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td align='left'><p>";
            result = result + _dr["t_msg"];
            result = result + "</p></td></tr></tbody></table>";
            return result;
        }
        public static string getFileName(DataRow _dr)
        {
            string result = "";
            result += "news_" + _dr["id"] + ".html";
            return result;
        }
        public static DataTable GetList(string _cno, string cityid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select * from b2c_tmsg where cno='" + _cno + "'"); 
                //and cityid="+cityid
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
