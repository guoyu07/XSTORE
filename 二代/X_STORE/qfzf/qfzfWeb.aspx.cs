using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Utilities;
namespace qfzfUI
{
    public partial class qfzfWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_index_Click(object sender, EventArgs e)
        {
            string strHtml = GetHtml("/index_mo.html");

            strHtml = strHtml.Replace("<$首页banner$>", GenerateBanner(" cno like '001001%'"));//首页导航

            strHtml = strHtml.Replace("<$旅游商业规划$>", Get_GuiHua());//旅游商业策划

            strHtml = strHtml.Replace("<$旅游商业策划$>", Get_Cehua());//旅游商业策划

            strHtml = strHtml.Replace("<$旅游商业场景$>", Get_ChangJing());//旅游商业场景

            strHtml = strHtml.Replace("<$旅游商业体验$>", Get_TiYan());//旅游商业体验

            strHtml = strHtml.Replace("<$旅游商业研发$>", Get_YanFa());//旅游商业研发

            strHtml = strHtml.Replace("<$旅游商业管理$>", Get_GuanLi());//旅游商业管理

            strHtml = strHtml.Replace("<$项目案例$>", Get_AnLi());//项目案例

            strHtml = strHtml.Replace("<$首页公司简介$>", GetIndexAboutUs());//公司简介

            strHtml = strHtml.Replace("<$首页公司荣誉$>", GetIndexHonor());//公司荣誉

            strHtml = strHtml.Replace("<$首页联络我们$>", GetIndexContact());//联络我们

            strHtml = strHtml.Replace("<$底部联络我们$>", GetBottomContact());//联络我们

            #region 生成头部 title  版权部分

            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

            DTcms.Model.siteconfig model = bll.loadConfig();

            strHtml = strHtml.Replace("<$底部备案信息$>", model.webcrod);
            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
            #endregion
            writeFile("/", "index.html", strHtml);
        }

        #region  获取首页Banner
        /// <summary>
        /// 获取首页Banner
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected string GenerateBanner(string sql)
        {
            string _bannerHtml = string.Empty;
            DataTable DT_banner = tdx.database.B2C_Honor.GetList("*", sql);
            try
            {
                if (DT_banner.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_banner.Rows.Count; i++)
                    {
                        _bannerHtml += "<li><a href=\"#\" target=\"_blank\"><img onerror=\"lod(this)\" src=" + DT_banner.Rows[i]["P_url"].ToString() + "></a></li>";
                    }
                    return _bannerHtml;
                }
                else
                {
                    return _bannerHtml;
                }

            }
            catch
            {

            }
            return _bannerHtml;

        }
        #endregion

        #region 生成首页规划
        protected string Get_GuiHua()
        {
            string _guihuaHtml = string.Empty;
            DataTable DT_GuiHua = tdx.database.B2C_Goods.GetList(" top 3* ", " cno='001005' order by g_sort desc ");
            try
            {
                if (DT_GuiHua.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_GuiHua.Rows.Count; i++)
                    {
                        string filename = "Pro_" + DT_GuiHua.Rows[i]["cno"].ToString() + "_d_" + DT_GuiHua.Rows[i]["id"].ToString() + ".html";
                        if (i == 0)
                        {
                            _guihuaHtml += "<li class=\"first\"><div class=\"pic\"><a href=\"" + filename + "\"><img src=" + DT_GuiHua.Rows[0]["g_gif"].ToString() + " /><span>" + DT_GuiHua.Rows[0]["g_name"].ToString() + "</span></a></div>  <div class=\"title\"><a href=" + filename + ">" + GetStrByByteLength(DT_GuiHua.Rows[0]["g_des"].ToString(), 120, true) + "<span>[更多]</span></a></div> </li>";
                        }
                        else
                        {
                            _guihuaHtml += "<li><div class=\"pic\"><a href=\"" + filename + "\"><img src=" + DT_GuiHua.Rows[i]["g_gif"].ToString() + " /><span>" + DT_GuiHua.Rows[i]["g_name"].ToString() + "</span></a></div>  <div class=\"title\"><a href=" + filename + ">" + GetStrByByteLength(DT_GuiHua.Rows[i]["g_des"].ToString(), 120, true) + "<span>[更多]</span></a></div> </li>";
                        }
                    }

                    return _guihuaHtml;
                }
                else
                {
                    return _guihuaHtml;
                }

            }
            catch
            {

            }
            return _guihuaHtml;
        }
        #endregion

        #region 生成首页旅游商业策划
        protected string Get_Cehua()
        {
            string _CehuaHtml = string.Empty;
            DataTable DT__CeHua = tdx.database.B2C_Goods.GetList(" top 3* ", " cno='001006' order by g_sort desc ");
            try
            {
                if (DT__CeHua.Rows.Count > 0)
                {
                    for (int i = 0; i < DT__CeHua.Rows.Count; i++)
                    {
                        string filename = "Pro_" + DT__CeHua.Rows[i]["cno"].ToString() + "_d_" + DT__CeHua.Rows[i]["id"].ToString() + ".html";
                        if (i == 0)
                        {
                            _CehuaHtml += " <div class=\"left\"><div class=\"pic\"><a href=" + filename + ">	<img src=" + DT__CeHua.Rows[0]["g_gif"].ToString() + " />	<div class=\"con_m\">	<h3 class=\"title\">" + DT__CeHua.Rows[0]["g_name"].ToString() + "</h3>	<div class=\"con\">" + GetStrByByteLength(DT__CeHua.Rows[0]["g_des"].ToString(), 200, true) + "</div>	</div> </a> </div> </div><div class=\"right\">";
                        }
                        else
                        {
                            _CehuaHtml += "<div class=\"lcon lcon01\">	<h3 class=\"title\"><a href=" + filename + ">" + DT__CeHua.Rows[i]["g_name"].ToString() + "</a></h3>  <div class=\"con\">" + GetStrByByteLength(DT__CeHua.Rows[i]["g_des"].ToString(), 250, true) + "</div>  <div class=\"more\"><a href=" + filename + ">[查看详情]</a></div> </div>";
                        }
                    }

                    return _CehuaHtml + "</div>";
                }
                else
                {
                    return _CehuaHtml;
                }

            }
            catch
            {

            }
            return _CehuaHtml;
        }
        #endregion

        #region 生成首页旅游商业场景
        protected string Get_ChangJing()
        {
            string _ChangJingHtml = string.Empty;
            DataTable DT__ChangJing = tdx.database.B2C_Goods.GetList(" top 4* ", " cno='001007' order by g_sort desc ");
            try
            {
                if (DT__ChangJing.Rows.Count > 0)
                {
                    for (int i = 0; i < DT__ChangJing.Rows.Count; i++)
                    {
                        string filename = "Pro_" + DT__ChangJing.Rows[i]["cno"].ToString() + "_d_" + DT__ChangJing.Rows[i]["id"].ToString() + ".html";
                        _ChangJingHtml += "<li>	<div class=\"pic pic0" + (i + 1) + "\"><a href=" + filename + "></a></div>  <a href=" + filename + " class=\"title\">" + DT__ChangJing.Rows[i]["g_name"].ToString() + "</a> <div class=\"con\">" + GetStrByByteLength(DT__ChangJing.Rows[i]["g_des"].ToString(), 100, true) + "<a href=" + filename + ">更多</a></div> </li>";
                    }
                    return _ChangJingHtml;
                }
                else
                {
                    return _ChangJingHtml;
                }

            }
            catch
            {

            }
            return _ChangJingHtml;
        }
        #endregion

        #region   生成首页旅游商业体验
        protected string Get_TiYan()
        {
            string _TiYanHtml = string.Empty;
            DataTable DT__TiYan = tdx.database.B2C_Goods.GetList(" top 2* ", " cno='001008' order by g_sort desc ");
            try
            {
                if (DT__TiYan.Rows.Count > 0)
                {
                    for (int i = 0; i < DT__TiYan.Rows.Count; i++)
                    {
                        string filename = "Pro_" + DT__TiYan.Rows[i]["cno"].ToString() + "_d_" + DT__TiYan.Rows[i]["id"].ToString() + ".html";
                        if (i == 0)
                        {
                            _TiYanHtml += " <div class=\"left\"><div class=\"pic\"><a href=" + filename + "><img src=" + DT__TiYan.Rows[i]["g_gif"].ToString() + " />	<div class=\"con_m\">	<h3 class=\"title\">" + DT__TiYan.Rows[i]["g_name"].ToString() + "</h3><div class=\"con\">" + GetStrByByteLength(DT__TiYan.Rows[i]["g_des"].ToString(), 90, true) + "<span>[更多]</span></div></div></a></div></div>";
                        }
                        else
                        {
                            _TiYanHtml += " <div class=\"right\"><div class=\"pic\"><a href=" + filename + "><img src=" + DT__TiYan.Rows[i]["g_gif"].ToString() + " />	<div class=\"con_m\">	<h3 class=\"title\">" + DT__TiYan.Rows[i]["g_name"].ToString() + "</h3><div class=\"con\">" + GetStrByByteLength(DT__TiYan.Rows[i]["g_des"].ToString(),90, true) + "<span>[更多]</span></div></div></a></div></div>";
                        }
                    }
                    return _TiYanHtml;
                }
                else
                {
                    return _TiYanHtml;
                }

            }
            catch
            {

            }
            return _TiYanHtml;
        }
        #endregion


        #region 生成首页旅游商业研发
        protected string Get_YanFa()
        {

            string _YanFaHtml = string.Empty;
            DataTable DT_YanFa = tdx.database.B2C_Goods.GetList(" top 3* ", " cno='001009' order by g_sort desc ");
            try
            {
                if (DT_YanFa.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_YanFa.Rows.Count; i++)
                    {
                        string filename = "Pro_" + DT_YanFa.Rows[i]["cno"].ToString() + "_d_" + DT_YanFa.Rows[i]["id"].ToString() + ".html";
                        if (i == 0)
                        {
                            _YanFaHtml += "<li class=\"first\"><a href=" + filename + " class=\"title icon0" + (i + 1) + "\">" + DT_YanFa.Rows[i]["g_name"].ToString() + "</a> <div class=\"con\">" + GetStrByByteLength(DT_YanFa.Rows[i]["g_des"].ToString(), 120, true) + "</div> <a href=" + filename + " class=\"more\">查看详情</a></li>";
                        }
                        else
                        {
                            _YanFaHtml += "<li><a href=" + filename + " class=\"title icon0" + (i + 1) + "\">" + DT_YanFa.Rows[i]["g_name"].ToString() + "</a> <div class=\"con\">" + GetStrByByteLength(DT_YanFa.Rows[i]["g_des"].ToString(), 120, true) + "</div> <a href=" + filename + " class=\"more\">查看详情</a></li>";
                        }

                    }
                    return _YanFaHtml;
                }
                else
                {
                    return _YanFaHtml;
                }

            }
            catch
            {

            }
            return _YanFaHtml;
        }
        #endregion


        #region 生成首页旅游商业管理
        protected string Get_GuanLi()
        {
            string _GuanLiHtml = string.Empty;
            DataTable DT_GuanLi = tdx.database.B2C_Goods.GetList(" top 4* ", " cno='001010' order by g_sort desc ");

            try
            {
                if (DT_GuanLi.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_GuanLi.Rows.Count; i++)
                    {

                        string filename = "Pro_" + DT_GuanLi.Rows[i]["cno"].ToString() + "_d_" + DT_GuanLi.Rows[i]["id"].ToString() + ".html";
                        _GuanLiHtml += "<li class=\"clear\"><a href=\"" + filename + "\" class=\"title\"><span>" + DT_GuanLi.Rows[i]["g_name"].ToString() + "</span></a> <div class=\"con\">" + GetStrByByteLength(DT_GuanLi.Rows[i]["g_des"].ToString(), 250, true) + "</div><div class=\"pic\"><img src=\"images/gl_right0" + (i + 1) + ".jpg\" /></div></li>";
                    }
                    return _GuanLiHtml;
                }
                else
                {
                    return _GuanLiHtml;
                }

            }
            catch
            {

            }
            return _GuanLiHtml;
        }
        #endregion


        #region 生成首页项目案例
        protected string Get_AnLi()
        {
            string _AnLiHtml = string.Empty;
            DataTable DT_AnLi = tdx.database.B2C_Goods.GetList(" top 4* ", " cno='001011' order by g_sort desc ");
            try
            {
                if (DT_AnLi.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_AnLi.Rows.Count; i++)
                    {
                        string filename = "Pro_" + DT_AnLi.Rows[i]["cno"].ToString() + "_d_" + DT_AnLi.Rows[i]["id"].ToString() + ".html";
                        _AnLiHtml += "<li><div class=\"pic\"><a href=" + filename + "><img src=" + DT_AnLi.Rows[i]["g_gif"].ToString() + " /></a><span class=\"title\"><a href=" + filename + ">" + DT_AnLi.Rows[i]["g_name"].ToString() + "</a></span></div>    </li>";
                    }
                    return _AnLiHtml;
                }
                else
                {
                    return _AnLiHtml;
                }

            }
            catch
            {

            }
            return _AnLiHtml;
        }
        #endregion


        #region 生成首页联系我们
        private string GetIndexContact()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_tpage  where cno in(select c_no from dbo.B2C_TPclass where c_no='002') and gtitle='首页联络我们'";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                str.Append(dt.Rows[0]["gcontent"]);
            }
            return "<a class=\"title\" href=\"about_001_d_12.html\">联络我们</a>  <div class=\"con\">" + str.ToString() + "</div>";
        }
        #endregion

        #region 生成底部联系我们
        private string GetBottomContact()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_tpage  where cno in(select c_no from dbo.B2C_TPclass where c_no='002') and gtitle='首页联络我们'";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                str.Append(dt.Rows[0]["gcontent"]);
            }
            return str.ToString();
        }
        #endregion

        #region  生成首页关于我们
        private string GetIndexAboutUs()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_tpage  where cno in(select c_no from dbo.B2C_TPclass where c_no='002') and gtitle='首页公司简介'";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                str.Append(dt.Rows[0]["gcontent"]);
            }

            return "<a class=\"title\" href=\"about_001_d_10.html\">公司简介</a>  <div class=\"con\">" + str.ToString() + "<a href=\"about_001_d_10.html\">[更多]</a></div> ";
        }
        #endregion


        #region 生成首页公司荣誉
        protected string GetIndexHonor()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_tpage  where cno in(select c_no from dbo.B2C_TPclass where c_no='002') and gtitle='首页公司荣誉'";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                str.Append(dt.Rows[0]["gcontent"]);
            }

            return "<a class=\"title\" href=\"about_001_d_11.html\">公司荣誉</a>  <div class=\"con\">" + str.ToString() + "<a href=\"about_001_d_11.html\">[更多]</a></div>";
        }
        #endregion


        #region 获取模本HTML  +   string GetHtml(string _mo)
        /// <summary>
        /// 获取模本HTML
        /// </summary>
        /// <param name="_mo"></param>
        /// <returns></returns>
        string GetHtml(string _mo)
        {
            string result = "";
            System.IO.StreamReader reader = new System.IO.StreamReader(Server.MapPath(_mo), System.Text.Encoding.GetEncoding("utf-8"));
            result = reader.ReadToEnd().ToString().Trim();
            reader.Close();
            return result;
        }
        #endregion


        #region 写入HTML文件   + void writeFile(String _FilePath, string _FileName, string _FileContent)
        /// <summary>
        /// 写入HTML文件
        /// </summary>
        /// <param name="_FilePath"></param>
        /// <param name="_FileName"></param>
        /// <param name="_FileContent"></param>
        private void writeFile(String _FilePath, string _FileName, string _FileContent)
        {

            try
            {
                if (!System.IO.Directory.Exists(Server.MapPath(_FilePath)))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(_FilePath));//判断路径是否存在，如果不存在就新建
                }
            }
            catch (Exception ex)
            {
                throw new Exception("创建目录失败:" + ex.Message);
            }
            try
            {
                if (!System.IO.File.Exists(Server.MapPath(_FilePath) + _FileName))//
                {
                    System.IO.File.Delete(Server.MapPath(_FilePath) + _FileName);
                }
                Byte[] bContent = System.Text.Encoding.GetEncoding("utf-8").GetBytes(_FileContent);
                string file_path = Server.MapPath(_FilePath) + _FileName;
                System.IO.Stream fs = System.IO.File.Create(Server.MapPath(_FilePath) + _FileName);//创建文件，将内容写入
                fs.Write(bContent, 0, bContent.Length);
                fs.Close();
                fs = null;
            }
            catch (Exception ex1)
            {
                throw new Exception("创建网页文件失败:" + ex1.Message + ":" + Server.MapPath(_FilePath) + _FileName);
            }
        }
        #endregion


        #region 当前位置   +  string GetPosUrl(int d, int id)
        /// <summary>
        ///当前位置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetPosUrl(int d, int id)
        {
            StringBuilder sbhtml = new StringBuilder();
            switch (d)
            {
                case 1:
                    string strSql = "select * from B2C_Tclass where c_no=(select cno from B2c_Tmsg where id=" + id + ")";
                    DataTable dt = comfun.GetDataTableBySQL(strSql);
                    sbhtml.Append("<em>></em><a href=\"\">" + dt.Rows[0]["c_name"] + "</a>");
                    break;
                case 2:
                    string str = "select * from B2C_category where c_no=(select cno from B2c_goods where id=" + id + " and cno<>'')";
                    DataTable dts = comfun.GetDataTableBySQL(str);
                    string st = "select * from B2C_category where c_id=" + dts.Rows[0]["c_parent"] + "";
                    DataTable ds = comfun.GetDataTableBySQL(st);
                    if (ds.Rows.Count > 0)
                    {
                        if (dts.Rows[0]["c_no"].Equals("002003"))
                        {
                            sbhtml.Append("<em>></em><a href=\"\">" + dts.Rows[0]["c_name"] + "</a>");
                        }
                        else
                        {
                            sbhtml.Append("<em>></em><a href=\"\">" + ds.Rows[0]["c_name"] + "</a><em>></em><a href=\"\">" + dts.Rows[0]["c_name"] + "</a>");
                        }
                    }

                    else
                    {
                        sbhtml.Append("<em>></em><a href=\"\">" + dts.Rows[0]["c_name"] + "</a>");
                    }
                    break;
                case 3:
                    string strs = "select * from B2C_TPclass where c_no=(select cno from B2c_Tpage where id=" + id + ")";
                    DataTable dtss = comfun.GetDataTableBySQL(strs);
                    sbhtml.Append("<em>></em><a href=\"\">" + dtss.Rows[0]["c_name"] + "</a>");
                    break;
                case 4:
                    string strss = "select * from B2C_Tclass where c_id=" + id + " ";
                    DataTable dtsss = comfun.GetDataTableBySQL(strss);
                    //string stras = "select * from B2C_Tclass where c_id=" + dtsss.Rows[0]["c_parent"] + " ";
                    //DataTable dtas = comfun.GetDataTableBySQL(stras);
                    sbhtml.Append("<em>></em><a href=\"\">" + dtsss.Rows[0]["c_name"] + "</a>");
                    //<em>></em><a href=\"\">" + dtas.Rows[0]["c_name"] + "</a>
                    break;
            }

            return sbhtml.ToString();
        }
        #endregion


        #region 网站配置   + string GetTitle(int d, int id)
        /// <summary>
        /// 网站配置
        /// </summary>
        /// <param name="d"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetTitle(int d, int id)
        {
            StringBuilder sbhtml = new StringBuilder();
            switch (d)
            {
                case 1:

                    string strSql = "select * from B2C_Tclass where c_no=(select cno from B2c_Tmsg where id=" + id + ")";
                    try
                    {
                        DataTable dt = comfun.GetDataTableBySQL(strSql);
                        string st = "select * from B2C_Tmsg where id=" + id + "";
                        DataTable ds = comfun.GetDataTableBySQL(st);
                        if (ds.Rows.Count > 0)
                        {
                            sbhtml.Append(ds.Rows[0]["T_title"] + "--" + dt.Rows[0]["c_name"] + "--实创科技");

                        }
                        else
                        {
                            sbhtml.Append(dt.Rows[0]["c_name"] + "--实创科技");
                        }
                    }
                    catch { }
                    break;
                case 2:
                    string stas = "select * from B2C_goods where id=" + id + " and cno<>''";
                    DataTable dtd = comfun.GetDataTableBySQL(stas);
                    if (dtd.Rows[0]["g_title"].ToString().Length > 1)
                    {
                        sbhtml.Append(dtd.Rows[0]["g_title"] + "--实创科技");
                    }
                    else
                    {
                        string str = "select * from B2C_category where c_no=(select cno from B2c_goods where id=" + id + " and cno<>'')";
                        DataTable dts = comfun.GetDataTableBySQL(str);
                        string sts = "select * from B2C_goods where id=" + id + " and cno<>''";
                        DataTable dss = comfun.GetDataTableBySQL(sts);
                        if (dss.Rows.Count > 0)
                        {
                            sbhtml.Append(dss.Rows[0]["g_name"] + "--" + dts.Rows[0]["c_name"] + "--实创科技");

                        }
                        else
                        {
                            sbhtml.Append(dts.Rows[0]["c_name"] + "--实创科技");
                        }
                    }
                    break;
                case 3:
                    string stras = "select * from B2c_Tpage where id=" + id + "";
                    DataTable dtras = comfun.GetDataTableBySQL(stras);
                    if (dtras.Rows[0]["g_title"].ToString().Length > 1)
                    {
                        sbhtml.Append(dtras.Rows[0]["g_title"] + "--实创科技");
                    }
                    else
                    {
                        string strs = "select * from B2C_TPclass where c_no=(select cno from B2c_Tpage where id=" + id + ")";
                        DataTable dtss = comfun.GetDataTableBySQL(strs);
                        string stss = "select * from B2C_Tpage where id=" + id + "";
                        DataTable dsss = comfun.GetDataTableBySQL(stss);
                        if (dsss.Rows.Count > 0)
                        {
                            sbhtml.Append(dsss.Rows[0]["gtitle"] + "--" + dtss.Rows[0]["c_name"] + "--实创科技");

                        }
                        else
                        {
                            sbhtml.Append(dtss.Rows[0]["c_name"] + "--实创科技");
                        }

                    }

                    break;
            }



            return sbhtml.ToString();
        }
        string GetKey(int d, int id)
        {
            string strKey = string.Empty;
            DataTable dt = null;
            try
            {
                switch (d)
                {
                    case 1:
                        string strSql = "select * from b2c_goods where id=" + id + " and cno<>''";
                        dt = comfun.GetDataTableBySQL(strSql);
                        strKey = dt.Rows[0]["g_des"].ToString();
                        break;
                    case 2:
                        string strt = "select * from b2c_tmsg where id=" + id + "";
                        dt = comfun.GetDataTableBySQL(strt);
                        strKey = dt.Rows[0]["T_des"].ToString();
                        break;
                    case 3:
                        string strp = "select * from b2c_Tpage where id=" + id + "";
                        dt = comfun.GetDataTableBySQL(strp);
                        strKey = dt.Rows[0]["g_des"].ToString();
                        break;
                }
            }
            catch { }
            return strKey;
        }
        string GetDes(int d, int id)
        {
            string strDes = string.Empty;
            DataTable dt = null;
            try
            {
                switch (d)
                {
                    case 1:
                        string strSql = "select * from b2c_goods where id=" + id + " and cno<>''";
                        dt = comfun.GetDataTableBySQL(strSql);
                        strDes = dt.Rows[0]["g_des"].ToString();
                        break;
                    case 2:
                        string strt = "select * from b2c_tmsg where id=" + id + "";
                        dt = comfun.GetDataTableBySQL(strt);
                        strDes = dt.Rows[0]["T_des"].ToString();
                        break;
                    case 3:
                        string strp = "select * from b2c_Tpage where id=" + id + "";
                        dt = comfun.GetDataTableBySQL(strp);
                        strDes = dt.Rows[0]["g_des"].ToString();
                        break;
                }
            }
            catch { }
            return strDes;
        }
        string[] GetConfig()
        {
            string[] strconfig = new string[3];
            string strSql = "select * from B2c_config where id=1";
            DataTable dt = comfun.GetDataTableBySQL(strSql);
            strconfig[0] = dt.Rows[0]["shop_title"].ToString();
            strconfig[1] = dt.Rows[0]["shop_Keyword"].ToString();
            strconfig[2] = dt.Rows[0]["shop_des"].ToString();
            return strconfig;
        }
        #endregion


        #region 文件名  + string GetFileName(int d, int id)
        /// <summary>
        /// 文件名
        /// </summary>
        /// <param name="d">判断是产品内容表、新闻内容表、单页面内容表</param>
        /// <param name="id">表对应的id</param>
        /// <returns></returns>
        string GetFileName(int d, int id)
        {
            string fileName = string.Empty;
            DataTable dt = null;
            switch (d)
            {
                case 1:
                    string strS = "select * from b2c_goods where id=" + id + " and cno<>''";
                    DataTable dtA = comfun.GetDataTableBySQL(strS);
                    if (dtA.Rows[0]["g_filename"].ToString().Length > 5)
                    {
                        fileName = dtA.Rows[0]["g_filename"].ToString();
                    }
                    else
                    {
                        fileName = "Pro_" + dtA.Rows[0]["cno"] + "_d_" + dtA.Rows[0]["id"] + ".html";
                    }
                    break;
                case 2:
                    string str = "select * from b2c_Tmsg where id=" + id + "";
                    dt = comfun.GetDataTableBySQL(str);
                    if (dt.Rows[0]["t_filename"].ToString().Length > 5)
                    {
                        fileName = dt.Rows[0]["t_filename"].ToString();
                    }
                    else
                    {
                        fileName = "News_" + dt.Rows[0]["cno"] + "_d_" + dt.Rows[0]["id"] + ".html";
                    }
                    break;
                case 3:
                    string strp = "select * from b2c_Tpage where id=" + id + "";
                    dt = comfun.GetDataTableBySQL(strp);
                    if (dt.Rows[0]["gfile"].ToString().Length > 5)
                    {
                        fileName = dt.Rows[0]["gfile"].ToString();
                    }
                    else
                    {
                        fileName = "Pag_" + dt.Rows[0]["cno"] + "_d_" + dt.Rows[0]["id"] + ".html";
                    }
                    break;
                case 4:
                    string strc1 = "select G.* from b2c_Goods G inner join b2c_category C on G.cno=C.C_no and c.c_Id=" + id + "  and G.cno<>''";
                    DataTable dtc1 = comfun.GetDataTableBySQL(strc1);
                    if (dtc1.Rows.Count > 0 && dtc1 != null)
                    {
                        if (dtc1.Rows[0]["g_filename"].ToString().Length > 5)
                        {
                            fileName = dtc1.Rows[0]["g_filename"].ToString();
                        }
                        else
                        {
                            fileName = "Pro_" + dtc1.Rows[0]["cno"] + "_d_" + dtc1.Rows[0]["id"] + ".html";
                        }
                    }
                    /*   else 
                       {
                           Page.Response.Write("<script>alert('您所查看的内容不存在，请添加后重试')</script>");
                       }
                     */
                    break;
            }
            return fileName;
        }
        #endregion


        #region 弹出提示  +void Alert(string alert)
        /// <summary>
        /// 弹出提示
        /// </summary>
        /// <param name="alert"></param>
        private void Alert(string alert)
        {
            //  Response.Write("<script>alert('" + alert + "')</script>");
        }
        #endregion


        #region 分页
        string pagechange(int count, int size, int pa, string strHtml, string cno, int line, string type)
        {

            strHtml += " <div class=\"pageControlCon clear\">";
            strHtml += "  <ul class=\"clear fl\">";
            int s, z;
            s = (count / line) - 1 > 0 ? count / line : 1;
            strHtml += "   <li class=\"" + ((count / line) - 1 > 0 ? "next" : "disabled") + "\"><a href=\"" + ((s == 1) ? "###" : "" + type + "" + cno + "_l_" + (s - 1) + ".html") + "\">上一页</a></li>";

            for (int i = 0; i < size; i++)
            {
                if (pa == i)
                {
                    strHtml += " <li class=\"active\"><a href=\"" + type + "" + cno + "_l_" + (i + 1) + ".html\">" + (i + 1) + "</a></li>";
                }
                else
                {
                    strHtml += " <li class=\"topage\"><a href=\"" + type + "" + cno + "_l_" + (i + 1) + ".html\">" + (i + 1) + "</a></li>";
                }
            }
            strHtml += " <li class=\"" + ((s == 1) && (s + 1 + 1 < size) ? "next" : (size == (pa + 1) ? "disabled" : "next")) + "\"><a href=" + ((size == (pa + 1)) ? "###" : "" + type + "" + cno + "_l_" + ((pa + 1 + 1) > size ? size : (pa + 1 + 1)) + ".html") + ">下一页</a></li>";
            strHtml += " </ul>";
            strHtml += "<div class=\"total\">";
            strHtml += "<span id=\"Size\" class=\"pages pages1\">共 " + size + " 页</span>";
            strHtml += "   </div>";
            strHtml += "</div>";
            return strHtml;
        }
        #endregion


        #region
        /// <summary>
        /// 根据字节最大长度，返回字符串 
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="maxLength">字节长度</param>
        /// <param name="fillDot">是否用...填充超过长度的末尾</param>
        /// <returns></returns>
        public string GetStrByByteLength(string strText, int maxLength, bool fillDot)
        {
            if (!string.IsNullOrEmpty(strText))
            {
                strText = strText.Trim();
                int i = 0;
                foreach (char c in strText)
                {
                    int j = Encoding.Default.GetByteCount(c.ToString());
                    if (j > 1)
                        maxLength -= (j - 1);

                    i++;
                    if (i >= maxLength)
                        break;
                }
                if (i < strText.Length)
                {
                    if (fillDot)
                        strText = strText.Substring(0, i) + "...";
                    else
                        strText = strText.Substring(0, i);
                }
            }
            return strText;
        }
        #endregion


        #region 生成 内页
        protected void btn_neiye_Click(object sender, EventArgs e)
        {
            //生成旅游内页
            GetLvYou_NeiYe();
            //生成关于我们内页
            GetAboutInfo();
        }
        #endregion

        #region
        private void GetLvYou_NeiYe()
        {
            try
            {
                DataTable Dt_category = tdx.database.B2C_category.GetList("*", " 1=1 and len(c_no)=6 ");
                if (Dt_category.Rows.Count > 0)
                {
                    for (int c = 0; c < Dt_category.Rows.Count; c++)
                    {
                        DataTable dt_goods = comfun.GetDataTableBySQL("select * from B2c_Goods g left join   B2C_Goods_m  m on     g.id=m.gid  where cno='" + Dt_category.Rows[c]["c_no"] + "' ");
                        if (dt_goods.Rows.Count > 0)
                        {
                            for (int g = 0; g < dt_goods.Rows.Count; g++)
                            {
                                string strHtml = GetHtml("/style02_mo.html");

                                strHtml = strHtml.Replace("<$底部联络我们$>", GetBottomContact());//联络我们

                                #region 生成头部 title  版权部分

                                DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

                                DTcms.Model.siteconfig model = bll.loadConfig();

                                strHtml = strHtml.Replace("<$底部备案信息$>", model.webcrod);

                                strHtml = strHtml.Replace("<$版权$>", model.webcopyright);

                                string filename = "Pro_" + dt_goods.Rows[g]["cno"].ToString() + "_d_" + dt_goods.Rows[g]["id"].ToString() + ".html";
                                strHtml = strHtml.Replace("<$内页banner$>", GenerateBanner(" cno like '001002%'"));//首页导航
                                strHtml = strHtml.Replace("<$内页一级类别$>", Dt_category.Rows[c]["c_name"].ToString());
                                strHtml = strHtml.Replace("<$内页详情$>", dt_goods.Rows[g]["g_msg"].ToString());
                                //生成二级类别下的列

                                string _NeiYe = "<span class=\"shows\">" + dt_goods.Rows[g]["g_name"].ToString() + "</span><div class=\"slids width1\"><a href=" + filename + " class=\"select\">" + dt_goods.Rows[g]["g_name"].ToString() + "</a>";
                                try
                                {
                                    DataTable DT_OtherGoods = comfun.GetDataTableBySQL("select * from B2c_Goods g left join   B2C_Goods_m  m on     g.id=m.gid  where cno='" + Dt_category.Rows[c]["c_no"] + "' and g.g_name<>'" + dt_goods.Rows[g]["g_name"].ToString() + "' ");
                                    if (DT_OtherGoods.Rows.Count > 0)
                                    {
                                        for (int t = 0; t < DT_OtherGoods.Rows.Count; t++)
                                        {
                                            string other_fileName = "Pro_" + DT_OtherGoods.Rows[t]["cno"].ToString() + "_d_" + DT_OtherGoods.Rows[t]["id"].ToString() + ".html";
                                            _NeiYe += "<a href=" + other_fileName + ">" + DT_OtherGoods.Rows[t]["g_name"].ToString() + "</a>";
                                        }
                                    }
                                    else
                                    {

                                    }

                                }
                                catch
                                {

                                }
                                strHtml = strHtml.Replace("<$内页二级类别$>", _NeiYe + "</div></div>");

                                strHtml = strHtml.Replace("<$旅游导航栏$>", GetNav());

                                writeFile("/", filename, strHtml);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
                                #endregion

        #region 生成关于我们
        private void GetAboutInfo()
        {
            try
            {
                DataTable Dt_page = comfun.GetDataTableBySQL("select * from B2C_tpage  where 1=1 and cno='001'");

                DataTable Dt_page_Name = comfun.GetDataTableBySQL("select * from B2C_TPclass  where 1=1 and c_no='001'");
                if (Dt_page.Rows.Count > 0)
                {
                    for (int c = 0; c < Dt_page.Rows.Count; c++)
                    {
                        string strHtml = GetHtml("/style02_mo.html");
                        string filename = "about_" + Dt_page.Rows[c]["cno"].ToString() + "_d_" + Dt_page.Rows[c]["id"].ToString() + ".html";
                        strHtml = strHtml.Replace("<$内页banner$>", GenerateBanner(" cno like '001002%'"));//首页导航
                        strHtml = strHtml.Replace("<$内页一级类别$>", Dt_page_Name.Rows[0]["c_name"].ToString());
                        strHtml = strHtml.Replace("<$内页详情$>", Dt_page.Rows[c]["gcontent"].ToString());
                        //生成二级类别下的列表
                        string _NeiYe = "<span class=\"shows\">" + Dt_page.Rows[c]["gtitle"].ToString() + "</span><div class=\"slids width1\"><a href=" + filename + " class=\"select\">" + Dt_page.Rows[c]["gtitle"].ToString() + "</a>";

                        DataTable DT_OthePages = comfun.GetDataTableBySQL("select * from B2C_tpage  where 1=1 and cno='001' and id<>" + Dt_page.Rows[c]["id"] + "");
                        for (int t = 0; t < DT_OthePages.Rows.Count; t++)
                        {
                            string other_fileName = "about_" + DT_OthePages.Rows[t]["cno"].ToString() + "_d_" + DT_OthePages.Rows[t]["id"].ToString() + ".html";

                            _NeiYe += "<a href=" + other_fileName + ">" + DT_OthePages.Rows[t]["gtitle"].ToString() + "</a>";
                        }
                        strHtml = strHtml.Replace("<$内页二级类别$>", _NeiYe + "</div></div>");

                        strHtml = strHtml.Replace("<$旅游导航栏$>", GetNav());

                        strHtml = strHtml.Replace("<$底部联络我们$>", GetBottomContact());//联络我们

                        #region 生成头部 title  版权部分

                        DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

                        DTcms.Model.siteconfig model = bll.loadConfig();

                        strHtml = strHtml.Replace("<$底部备案信息$>", model.webcrod);
                        strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
                        #endregion

                        writeFile("/", filename, strHtml);

                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        #region  生成列表页
        protected void btn_product_Click(object sender, EventArgs e)
        {
            //分为旅游模块的列表页面和项目案例列表
            Get_LvYouList();
            Get_CaseList();
            //读取导航栏
        }
        #endregion


        /// <summary>
        /// 读取导航名称
        /// </summary>
        /// <returns></returns>

        #region 生成导航栏
        private string GetNav()
        {
            StringBuilder str = new StringBuilder();

            str.Append("<li class=\"first\"><a href=\"index.html\"  class=\"active\">首页</a></li>");
            str.Append("<li><a href=\"ProList_001005_l_1.html\">旅游商业规划</a></li>");
            str.Append("<li><a href=\"ProList_001006_l_1.html\">旅游商业策划</a></li>");
            str.Append("<li><a href=\"ProList_001007_l_1.html\">旅游商业场景</a></li>");
            str.Append("<li><a href=\"ProList_001008_l_1.html\">旅游商业体验</a></li>");
            str.Append("<li><a href=\"ProList_001009_l_1.html\">旅游商品研发</a></li>");
            str.Append("<li><a href=\"ProList_001010_l_1.html\">旅游商业管理</a></li>");
            str.Append("<li class=\"last\"><a href=\"about_001_d_10.html\">关于我们</a></li>");
            str.Append("<li class=\"last\"><a href=\"ProList_001011_l_1.html\">项目案例</a></li>");
            return str.ToString();
        }
        #endregion

        protected void Get_LvYouList()
        {
            DataTable Dt_category = tdx.database.B2C_category.GetList("*", " 1=1 and len(c_no)=6 and c_no<>001011");
            StringBuilder str_ListHtml = new StringBuilder();
            if (Dt_category.Rows.Count > 0)
            {
                for (int c = 0; c < Dt_category.Rows.Count; c++)
                {
                    int line = 3;//每页数目
                    int pagesize;//页码
                    DataTable dt_goods = comfun.GetDataTableBySQL("select * from B2c_Goods g left join   B2C_Goods_m  m on   g.id=m.gid  where cno='" + Dt_category.Rows[c]["c_no"] + "' ");
                    if (dt_goods.Rows.Count > 0)
                    {
                        if (dt_goods.Rows.Count > line)
                        {
                            pagesize = ((dt_goods.Rows.Count % line) != 0 ? dt_goods.Rows.Count / line + 1 : dt_goods.Rows.Count);
                        }
                        else
                        {
                            pagesize = 1;
                        }
                        for (int j = 0; j < pagesize; j++)
                        {
                            string strHtml = GetHtml("/style01_mo.html");
                            strHtml = strHtml.Replace("<$内页banner$>", GenerateBanner(" cno like '001002%'"));
                            strHtml = strHtml.Replace("<$内页一级类别$>", Dt_category.Rows[c]["c_name"].ToString());
                            strHtml = strHtml.Replace(" <$旅游导航栏$>", GetNav());
                            //生成旅游列表
                            strHtml = strHtml.Replace("<$content$>", getproductlist(pagesize, (j + 1) * line, j, line, " and cno=" + Dt_category.Rows[c]["c_no"] + ""));
                            string filenamelist = "ProList_" + Dt_category.Rows[c]["c_no"] + "_l_" + (j + 1) + ".html";
                            strHtml = strHtml.Replace("<$旅游列表$>", str_ListHtml.ToString());

                            strHtml = strHtml.Replace("<$底部联络我们$>", GetBottomContact());//联络我们

                            #region 生成头部 title  版权部分

                            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

                            DTcms.Model.siteconfig model = bll.loadConfig();
                            strHtml = strHtml.Replace("<$底部备案信息$>", model.webcrod);
                            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
                            writeFile("/", filenamelist, strHtml);
                        }
                    }


                }
            }
        }

        #region  生成案例列表
        protected void Get_CaseList()
        {
            DataTable Dt_category = tdx.database.B2C_category.GetList("*", " 1=1  and c_no=001011");
            StringBuilder str_ListHtml = new StringBuilder();
            if (Dt_category.Rows.Count > 0)
            {
                for (int c = 0; c < Dt_category.Rows.Count; c++)
                {
                    int line = 12;//每页数目
                    int pagesize;//页码
                    DataTable dt_goods = comfun.GetDataTableBySQL("select * from B2c_Goods g left join   B2C_Goods_m  m on   g.id=m.gid  where cno='" + Dt_category.Rows[c]["c_no"] + "' ");
                    if (dt_goods.Rows.Count > 0)
                    {
                        if (dt_goods.Rows.Count > line)
                        {
                            pagesize = ((dt_goods.Rows.Count % line) != 0 ? dt_goods.Rows.Count / line + 1 : dt_goods.Rows.Count);
                        }
                        else
                        {
                            pagesize = 1;
                        }
                        for (int j = 0; j < pagesize; j++)
                        {
                            string strHtml = GetHtml("/style01_mo.html");
                            strHtml = strHtml.Replace("<$内页banner$>", GenerateBanner(" cno like '001002%'"));
                            strHtml = strHtml.Replace("<$内页一级类别$>", Dt_category.Rows[c]["c_name"].ToString());
                            strHtml = strHtml.Replace(" <$旅游导航栏$>", GetNav());
                            //生成旅游列表
                            strHtml = strHtml.Replace("<$content$>", getcaselist(pagesize, (j + 1) * line, j, line, " and cno=" + Dt_category.Rows[c]["c_no"] + ""));
                            string filenamelist = "ProList_" + Dt_category.Rows[c]["c_no"] + "_l_" + (j + 1) + ".html";
                            strHtml = strHtml.Replace("<$旅游列表$>", str_ListHtml.ToString());

                            strHtml = strHtml.Replace("<$底部联络我们$>", GetBottomContact());//联络我们

                            #region 生成头部 title  版权部分

                            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

                            DTcms.Model.siteconfig model = bll.loadConfig();

                            strHtml = strHtml.Replace("<$底部备案信息$>", model.webcrod);
                            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
                            writeFile("/", filenamelist, strHtml);
                        }
                    }


                }
            }
        }
                            #endregion


        #region  生成旅游列表
        string getproductlist(int size, int count, int pagenum, int line, string _sqlwhere)
        {
            StringBuilder strHtml = new StringBuilder();
            string sql = "";
            if (pagenum > 0)
            {
                sql = "select top " + line + "* from b2c_goods where  id not in (select top (" + line + "*" + pagenum + ") id from b2c_goods where 1=1  " + _sqlwhere + "  order by g_sort asc,g_wdate desc) " + _sqlwhere + " order by g_sort asc,g_wdate desc";
            }
            else
            {
                sql = "select top " + line + "* from b2c_goods where 1=1 " + _sqlwhere + "  order by g_sort asc,g_wdate desc";
            }
            DataTable dt_goods = comfun.GetDataTableBySQL(sql);
            if (dt_goods.Rows.Count > 0 && dt_goods != null)
            {
                strHtml.Append("<div class='content  clear'><ul class=\"clear m_pad style_list\">");
                for (int i = 0; i < dt_goods.Rows.Count; i++)
                {
                    string filename = "Pro_" + dt_goods.Rows[i]["cno"].ToString() + "_d_" + dt_goods.Rows[i]["id"].ToString() + ".html";
                    if (i == 0)
                    {
                        strHtml.Append("<li class=\"first\"><div class=\"pic\"><a href=" + filename + "><img src=" + dt_goods.Rows[i]["g_gif"].ToString() + " /><span>" + dt_goods.Rows[i]["g_name"].ToString() + "</span></a></div>  <div class=\"title\"><a href=" + filename + ">" + GetStrByByteLength(dt_goods.Rows[i]["g_des"].ToString(), 120, true) + "</a></div>  </li>");
                    }
                    else
                    {
                        strHtml.Append("<li><div class=\"pic\"><a href=" + filename + "><img src=" + dt_goods.Rows[i]["g_gif"].ToString() + " /><span>" + dt_goods.Rows[i]["g_name"].ToString() + "</span></a></div>  <div class=\"title\"><a href=" + filename + ">" + GetStrByByteLength(dt_goods.Rows[i]["g_des"].ToString(), 120, true) + "</a></div>  </li>");
                    }
                }
                strHtml.Append("</ul></div>");
                //分页效果
                strHtml.Append(pagechange(count, size, pagenum, string.Empty, dt_goods.Rows[0]["cno"].ToString(), line, "ProList_"));
            }
            else //2015.6.17
            {
                strHtml.Append("<div class='pros  clear'> ");
                strHtml.Append("Data collated......");
                strHtml.Append(" </div>");
            }

            return strHtml.ToString();
        }


        #endregion

        #region  生成案例
        string getcaselist(int size, int count, int pagenum, int line, string _sqlwhere)
        {
            StringBuilder strHtml = new StringBuilder();
            string sql = "";
            if (pagenum > 0)
            {
                sql = "select top " + line + "* from b2c_goods where  id not in (select top (" + line + "*" + pagenum + ") id from b2c_goods where 1=1  " + _sqlwhere + "  order by g_sort asc,g_wdate desc) " + _sqlwhere + " order by g_sort asc,g_wdate desc";
            }
            else
            {
                sql = "select top " + line + "* from b2c_goods where 1=1 " + _sqlwhere + "  order by g_sort asc,g_wdate desc";
            }
            DataTable dt_goods = comfun.GetDataTableBySQL(sql);
            if (dt_goods.Rows.Count > 0 && dt_goods != null)
            {
                strHtml.Append("<div class='content  clear m_index08 '><ul class=\"clear m_pad \">");
                for (int i = 0; i < dt_goods.Rows.Count; i++)
                {
                    string filename = "Pro_" + dt_goods.Rows[i]["cno"].ToString() + "_d_" + dt_goods.Rows[i]["id"].ToString() + ".html";
                    strHtml.Append("<li><div class=\"pic\"><a href=" + filename + "><img src=" + dt_goods.Rows[i]["g_gif"].ToString() + " /> </a> <span class=\"title\"><a href=" + filename + ">" + dt_goods.Rows[i]["g_name"].ToString() + "</a></span></div></li>");
                }
                strHtml.Append("</ul></div>");
                //分页效果
                strHtml.Append(pagechange(count, size, pagenum, string.Empty, dt_goods.Rows[0]["cno"].ToString(), line, "ProList_"));
            }
            else //2015.6.17
            {
                strHtml.Append("<div class='pros  clear'> ");
                strHtml.Append("Data collated......");
                strHtml.Append(" </div>");
            }

            return strHtml.ToString();
        }


        #endregion

        #endregion


    }
                            #endregion
        #endregion

}

