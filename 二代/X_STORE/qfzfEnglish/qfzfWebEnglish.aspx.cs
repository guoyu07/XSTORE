using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qfzfEnglish
{
    public partial class qfzfWebEnglish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 1.0 首页生成
        /// <summary>
        /// 首页生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_index_Click(object sender, EventArgs e)
        {
            string strHtml = GetHtml("/en/index_mo.html");

            strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

            strHtml = strHtml.Replace(" <$首页联系我们$>", GetIndexContact());//生成首页联系我们

            strHtml = strHtml.Replace("<$产品类别$>", GetProduct());//首页产品类别

            strHtml = strHtml.Replace("<$主打产品$>", GetProductlist());//首页产品

            strHtml = strHtml.Replace("<$首页轮播图$>", GetLunBoTu());//首页轮播图

            strHtml = strHtml.Replace("<$首页新闻列表$>", GetNews());//首页新闻列表


            #region 生成头部 title  版权部分
            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

            DTcms.Model.siteconfig model = bll.loadConfig();

            strHtml = strHtml.Replace("<$标题$>", model.webtitle);

            strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

            strHtml = strHtml.Replace("<$简介$>", model.webdescription);

            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
            #endregion

            writeFile("/en/", "index.html", strHtml);
        }

        //首页新闻列表
        private string GetNews()
        {
            StringBuilder str = new StringBuilder();

            string sql = " select top(9)* from  dbo.B2C_tmsg  where  cno in(select c_no from dbo.B2C_tclass where c_no='002') order by id desc";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string filenamelist = "News_" + dt.Rows[i]["cno"] + "_d_" + dt.Rows[i]["id"] + ".html";//新闻链接      
                    str.Append("<li><a href=\"" + filenamelist + "\">" + dt.Rows[i]["t_title"] + "</a></li>");

                }
            }

            return str.ToString();
        }
        //首页轮播图
        private string GetLunBoTu()
        {
            //StringBuilder str = new StringBuilder();

            //string sql = "select * from dbo.B2C_Honor  where  cno in(select c_no from dbo.B2C_Hclass where c_no='002') ";

            //DataTable dt = comfun.GetDataTableBySQL(sql);

            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        str.Append("<a href=\"#\"><img src=\"" + dt.Rows[i]["P_url"] + "\" /></a>");

            //    }
            //}

            StringBuilder str = new StringBuilder();

            string sqls = "select c_no from dbo.B2C_Hclass where c_no='002'";

            DataTable dts = comfun.GetDataTableBySQL(sqls);

            if (dts.Rows.Count > 0)
            {
                string sql = "select * from dbo.B2C_Honor  where  cno like '" + dts.Rows[0]["c_no"] + "%' and len(cno)=6  and cno<>'002002' ";

                DataTable dt = comfun.GetDataTableBySQL(sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str.Append("<a href=\"#\"><img src=\"" + dt.Rows[i]["P_url"] + "\" /></a>");

                    }
                }
            }



            return str.ToString();
        }

        //首页产品
        private string GetProductlist()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select top(3)* from  dbo.B2C_Goods where   cno like '002%' and   len(cno)=9   ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string filenamelist = "Pro_" + dt.Rows[i]["cno"] + "_d_" + dt.Rows[i]["id"] + ".html";//三级链接                    
                    str.Append("<li><div class=\"pic\"><a href=\"" + filenamelist + "\"><img src=\"" + dt.Rows[i]["g_gif"] + "\" /></a></div>");
                    str.Append("<div class=\"txt\"><a href=\"" + filenamelist + "\">" + dt.Rows[i]["g_name"] + "</a></div></li>");
                }
            }


            return str.ToString();
        }

        //首页产品类别
        private string GetProduct()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select top(3)* from dbo.B2C_category where c_no like '002%' and   len(c_no)=6 and c_no<>002  ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string filename = "ProList_" + dt.Rows[i]["c_no"] + "_l_" + i + ".html";//二级链接

                    str.Append("<li class=\"clear\">");

                    str.Append("<div class=\"fl pic\"><a href=\"" + filename + "\"><img src=" + dt.Rows[i]["c_gif"] + " /></a></div>");

                    str.Append("<div class=\"fr cont\"><a class=\"title\" href=\"" + filename + "\">" + dt.Rows[i]["c_name"] + "</a>");

                    str.Append("<div class=\"more_con\">产品特点：" + dt.Rows[i]["c_des"] + "</div></div></li>");
                }
            }

            return str.ToString();
        }

        //生成首页联系我们
        private string GetIndexContact()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_tpage  where cno in(select c_no from dbo.B2C_TPclass where c_no='002') and gtitle='shouyelainxi'";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                str.Append(dt.Rows[0]["gcontent"]);
            }


            return str.ToString();
        }

        //首页导航
        private string GetNav()
        {
            StringBuilder str = new StringBuilder();

            str.Append("<li><a href=\"aboutus.html\">About</a></li>");
            str.Append("<li><a href=\"NewsList_002_l_1.html\">News</a></li>");
            str.Append("<li><a href=\"product.html\" class=\"more\">Product</a>");

            /// 头部导航下拉效果 2015.7.6
            string sql = "select * from dbo.B2C_category where c_no like '002%' and   len(c_no)=6 and c_no<>002  ";//查二级名称

            DataTable dt = comfun.GetDataTableBySQL(sql);

            string strs = String.Empty;

            string strsan = String.Empty;


            strs = "<ul class=\"erjiclass hdw\">";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string filename = "ProList_" + dt.Rows[i]["c_no"] + "_l_" + i + ".html";//二级链接

                    strs += "<li><a href='" + filename + "' class=\"more\">" + dt.Rows[i]["c_name"] + "</a>";//添加二级名称


                    string strsql = "select * from dbo.B2C_category where c_no like '" + dt.Rows[i]["c_no"] + "%' and   len(c_no)=9      and  c_no  <>  " + dt.Rows[i]["c_no"];//查三级名称

                    DataTable dtstr = comfun.GetDataTableBySQL(strsql);

                    strsan = "<ul class='sanjiclass hdwq clear' >";

                    if (dtstr.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtstr.Rows.Count; j++)
                        {
                            string filenamelist = "ProList_" + dtstr.Rows[j]["c_no"] + "_l_" + 1 + ".html";//三级链接

                            strsan += "<li><a href='" + filenamelist + "'>" + dtstr.Rows[j]["c_name"] + "</a></li>";//添加三级名称  和 链接地址
                        }
                    }

                    strsan += "</ul>";

                    strs += strsan;

                    strs += "</li>";
                }
            }
            strs += "</ul>";
            str.Append(strs);
            str.Append("</li>");

            /// 头部导航下拉效果 2015.7.6
            str.Append("<li><a href=\"#\">质量追溯</a></li>");
            str.Append("<li><a href=\"zizhizhengshu.html\">资质证书</a></li>");
            return str.ToString();
        }
        #endregion

        #region 2.0 内页生成
        /// <summary>
        /// 内页生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_neiye_Click(object sender, EventArgs e)
        {
            #region 生成Contact
            CreateContact();
            #endregion

            #region 生成 网站地图
            CreateMap();
            #endregion

            #region 生成 关于我们
            CreateAboutUs();
            #endregion

            #region 生成 产品中心列表
            CreateProduct();
            #endregion

            #region 生成 资质证书 2015.7.21 添加
            CreateZiZhiZhengShu();
            #endregion
        }

        #region 生成 资质证书 2015.7.21 添加
        private void CreateZiZhiZhengShu()
        {
            string strHtml = GetHtml("/en/style_mo.html");

            strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

            strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

            strHtml = strHtml.Replace("<$内页内容$>", ZiZhiZhengShu());//内页内容-资质证书

            strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"zizhizhengshu.html\">资质证书</a>");//内页内容-您的位置

            strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品


            #region 生成头部 title  版权部分
            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

            DTcms.Model.siteconfig model = bll.loadConfig();

            strHtml = strHtml.Replace("<$标题$>", model.webtitle);

            strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

            strHtml = strHtml.Replace("<$简介$>", model.webdescription);

            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
            #endregion

            writeFile("/en/", "zizhizhengshu.html", strHtml);
        }
        //内页内容-资质证书
        private string ZiZhiZhengShu()
        {

            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_Honor  where  cno in(select c_no from dbo.B2C_Hclass where c_no='002002') ";

            DataTable dt = comfun.GetDataTableBySQL(sql);
             str.Append( " <div class='pros'>");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     
                    str.Append("<div class='pro_list'><div class='proimg'><a rel=\"example_group\" href=\"" + dt.Rows[i]["P_url"] + "\">");
                    str.Append("<img src=\"" + dt.Rows[i]["P_url"] + "\" /></a></div>");
                    str.Append("<div class='prodes'>" + dt.Rows[i]["P_name"] + " </div></div>");

                }
            }
           
           

               
              str.Append("</div>");
          

            

            return str.ToString();

            
        }
        #endregion

        #region 生成 产品中心列表
        private void CreateProduct()
        {


            string strHtml = GetHtml("/en/style_mo.html");

            strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

            strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

            strHtml = strHtml.Replace("<$内页内容$>", GetNYProductlist());//内页内容-关于我们

            strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"product.html\">Product</a>");//内页内容-您的位置

            strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品

            #region 生成头部 title  版权部分
            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

            DTcms.Model.siteconfig model = bll.loadConfig();

            strHtml = strHtml.Replace("<$标题$>", model.webtitle);

            strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

            strHtml = strHtml.Replace("<$简介$>", model.webdescription);

            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
            #endregion

            writeFile("/en/", "product.html", strHtml);


        }

        private string GetNYProductlist()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select  * from dbo.B2C_category where c_no like '002%' and   len(c_no)=6 and c_no<>002  ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string filename = "ProList_" + dt.Rows[i]["c_no"] + "_l_" + i + ".html";//二级链接

                    str.Append(" <div class='pros'>");

                    //2015.6.17

                    str.Append("<div class='pro_list'><div class='proimg'><a href='" + filename + "'>");
                    str.Append("<img src='" + dt.Rows[i]["c_gif"] + "' alt=\"" + dt.Rows[i]["c_name"] + "\"  border='0' /></a></div>");
                    str.Append("<div class='prodes'> <a href='" + filename + "'>" + dt.Rows[i]["c_name"] + "</a></div></div>");

                    str.Append("</div>");


                }
            }

            return str.ToString();
        }
        #endregion


        //内页产品
        private string GetNYProduct()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select  * from dbo.B2C_category where c_no like '002%' and   len(c_no)=6 and c_no<>002  ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string filename = "ProList_" + dt.Rows[i]["c_no"] + "_l_" + i + ".html";//二级链接
                    string filename = "#";//二级链接

                    str.Append("<li><a href=\"" + filename + "\">" + dt.Rows[i]["c_name"] + "</a>");


                    ///查询三级列表  2015.7.6 新增
                    string strsql = "select * from dbo.B2C_category where c_no like '" + dt.Rows[i]["c_no"] + "%' and   len(c_no)=9  and  c_no  <>  " + dt.Rows[i]["c_no"];//查三级名称

                    DataTable dtstr = comfun.GetDataTableBySQL(strsql);

                    string strsan = "<ul style='display:none;'>";

                    if (dtstr.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtstr.Rows.Count; j++)
                        {
                            string filenamelist = "ProList_" + dtstr.Rows[j]["c_no"] + "_l_" + 1 + ".html";///三级链接

                            strsan += "<li><a href='" + filenamelist + "'>" + dtstr.Rows[j]["c_name"] + "</a></li>";//添加三级名称  和 链接地址
                        }
                    }
                    strsan += "</ul>";

                    ///查询三级列表  2015.7.6 新增
                    ///
                    str.Append(strsan);
                    str.Append("</li>");

                }
            }

            return str.ToString();
        }

        //内页内容-网站地图
        private string GetMap()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_tpage  where cno in(select c_no from dbo.B2C_TPclass where c_no='002') and gtitle='map'";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                str.Append(dt.Rows[0]["gcontent"]);
            }


            return str.ToString();
        }

        //内页内容-联系我们
        private string GetContact()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_tpage  where cno in(select c_no from dbo.B2C_TPclass where c_no='002') and gtitle='contact'";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                str.Append(dt.Rows[0]["gcontent"]);
            }


            return str.ToString();
        }

        //内页内容-关于我们
        private string Getaboutus()
        {
            StringBuilder str = new StringBuilder();

            string sql = "select * from dbo.B2C_tpage  where cno in(select c_no from dbo.B2C_TPclass where c_no='002') and gtitle='About us'";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                str.Append(dt.Rows[0]["gcontent"]);
            }


            return str.ToString();
        }

        #region 生成 关于我们
        public void CreateAboutUs()
        {
            string strHtml = GetHtml("/en/style_mo.html");

            strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

            strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

            strHtml = strHtml.Replace("<$内页内容$>", Getaboutus());//内页内容-关于我们

            strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"aboutus.html\">AboutUs</a>");//内页内容-您的位置

            strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品

            #region 生成头部 title  版权部分
            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

            DTcms.Model.siteconfig model = bll.loadConfig();

            strHtml = strHtml.Replace("<$标题$>", model.webtitle);

            strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

            strHtml = strHtml.Replace("<$简介$>", model.webdescription);

            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
            #endregion

            writeFile("/en/", "aboutus.html", strHtml);
        }


        #endregion

        #region 生成Map
        public void CreateMap()
        {
            string strHtml = GetHtml("/en/style_mo.html");

            strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

            strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

            strHtml = strHtml.Replace("<$内页内容$>", GetMap());//内页内容-网站地图

            strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"map.html\">Map</a>");//内页内容-您的位置

            strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品

            #region 生成头部 title  版权部分
            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

            DTcms.Model.siteconfig model = bll.loadConfig();

            strHtml = strHtml.Replace("<$标题$>", model.webtitle);

            strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

            strHtml = strHtml.Replace("<$简介$>", model.webdescription);

            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
            #endregion

            writeFile("/en/", "map.html", strHtml);
        }
        #endregion

        #region 生成Contact
        public void CreateContact()
        {

            string strHtml = GetHtml("/en/style_mo.html");

            strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

            strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

            strHtml = strHtml.Replace("<$内页内容$>", GetContact());//内页内容-联系我们

            strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"contact.html\">ContactUs</a>");//内页内容-您的位置

            strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品


            #region 生成头部 title  版权部分
            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

            DTcms.Model.siteconfig model = bll.loadConfig();

            strHtml = strHtml.Replace("<$标题$>", model.webtitle);

            strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

            strHtml = strHtml.Replace("<$简介$>", model.webdescription);

            strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
            #endregion

            writeFile("/en/", "contact.html", strHtml);
        }
        #endregion

        #endregion

        #region 3.0 新闻生成
        /// <summary>
        /// 新闻生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_news_Click(object sender, EventArgs e)
        {
            ////生成新闻内容
            string str = "select * from B2c_Tmsg  where cno='002' order by t_wdate desc";

            DataTable dtN = comfun.GetDataTableBySQL(str);

            for (int i = 0; i < dtN.Rows.Count; i++)
            {
                string strHtml = GetHtml("/en/style_mo.html");

                strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

                strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

                strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"NewsList_002_l_1.html\">News</a>");//内页内容-您的位置

                strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品

                string ss = "<center class='title'>" + dtN.Rows[i]["t_title"].ToString() + "</center>" + dtN.Rows[i]["t_msg"].ToString();

                strHtml = strHtml.Replace("<$内页内容$>", ss);//内页内容-联系我们

                string FileName = GetFileName(2, Convert.ToInt32(dtN.Rows[i]["id"]));

                #region 生成头部 title  版权部分
                DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

                DTcms.Model.siteconfig model = bll.loadConfig();

                strHtml = strHtml.Replace("<$标题$>", model.webtitle);

                strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

                strHtml = strHtml.Replace("<$简介$>", model.webdescription);

                strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
                #endregion
                writeFile("/en/", FileName, strHtml);


            }


            string sql = "select * from b2c_tclass  where c_no='002'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    int line = 12; //更改分页条数 
                    int size;
                    string sql1 = "select * from b2c_tmsg where cno='002'";
                    DataTable dt1 = comfun.GetDataTableBySQL(sql1);
                    if (dt1.Rows.Count > line)
                    {
                        size = ((dt1.Rows.Count % line) != 0 ? dt1.Rows.Count / line + 1 : dt1.Rows.Count);
                    }
                    else
                    {
                        size = 1;
                    }
                    for (int j = 0; j < size; j++)
                    {

                        ////////////////////////生成新闻列表
                        string strHtml0 = GetHtml("/en/style_mo.html");

                        strHtml0 = strHtml0.Replace("<$网页nav$>", GetNav());//首页导航

                        strHtml0 = strHtml0.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

                        strHtml0 = strHtml0.Replace("<$您的位置$>", "<a href=\"NewsList_002_l_1.html\">News</a>");//内页内容-您的位置

                        strHtml0 = strHtml0.Replace("<$内页产品$>", GetNYProduct());//内页产品

                        strHtml0 = strHtml0.Replace("<$内页内容$>", getnewslist(size, (j + 1) * line, j, line));//内页内容-联系我们

                        string FileName = "NewsList_" + dt.Rows[i]["c_no"] + "_l_" + (j + 1) + ".html";

                        #region 生成头部 title  版权部分
                        DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

                        DTcms.Model.siteconfig model = bll.loadConfig();

                        strHtml0 = strHtml0.Replace("<$标题$>", model.webtitle);

                        strHtml0 = strHtml0.Replace("<$关键字$>", model.webkeyword);

                        strHtml0 = strHtml0.Replace("<$简介$>", model.webdescription);

                        strHtml0 = strHtml0.Replace("<$版权$>", model.webcopyright);
                        #endregion
                        writeFile("/en/", FileName, strHtml0);//

                    }
                }
            }
        }


        #region 获取新闻列表+getnewslist(int size, int count, int pagenum, int line)

        string getnewslist(int size, int count, int pagenum, int line)
        {
            string strHtml = String.Empty;
            string sql = "";
            if (pagenum > 0)
            {
                sql = "select top " + line + "* from b2c_tmsg  where id not in (select top (" + line + "*" + pagenum + ") id from b2c_tmsg where    cno='002' order by t_sort asc,t_wdate desc) and cno='002' order by t_sort asc,t_wdate desc";
            }
            else
            {
                sql = "select top " + line + "* from b2c_tmsg where cno='002' order by t_sort asc,t_wdate desc";
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0 && dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string FileName = GetFileName(2, Convert.ToInt32(dt.Rows[i]["id"]));
                    DateTime time = (DateTime)dt.Rows[i]["t_wdate"];
                    strHtml += " <div class='TXT_list'> <div class='TXT_list_title'>+ <a href='" + FileName + "'>" + dt.Rows[i]["t_title"] + "</a></div>   <div class='TXT_list_date'>" + time.ToString("yyyy/MM/dd") + "</div></div> ";
                }
            }
            strHtml = pagechange(count, size, pagenum, strHtml, dt.Rows[0]["cno"].ToString(), line, "NewsList_");


            return strHtml;
        }
        #endregion
        #endregion

        #region 4.0 产品生成
        /// <summary>
        /// 生成产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_product_Click(object sender, EventArgs e)
        {


            DTcms.BLL.siteconfig bll = new DTcms.BLL.siteconfig();

            DTcms.Model.siteconfig model = bll.loadConfig();



            string sqlpro = "select * from dbo.B2C_category where c_no like '002%' and   len(c_no)=6  and c_no <> 002";//查二级名称

            DataTable dtpro = comfun.GetDataTableBySQL(sqlpro);
            if (dtpro.Rows.Count > 0)
            {

                for (int i = 0; i < dtpro.Rows.Count; i++)
                {
                    string strHtml = GetHtml("/en/style_mo.html");

                    strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

                    strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们
                    //2015.7.6
                    strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"product.html\">Product</a><em>></em><a href=\"" + "ProList_" + dtpro.Rows[i]["c_no"] + "_l_" + i + ".html" + "\">" + dtpro.Rows[i]["c_name"] + "</a>");//内页内容-您的位置

                    strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品





                    //内部列表
                    string strsql0 = "select * from dbo.B2C_category where c_no like '" + dtpro.Rows[i]["c_no"] + "%' and   len(c_no)=9  and  c_no  <>  " + dtpro.Rows[i]["c_no"];//查三级名称

                    DataTable dtstr0 = comfun.GetDataTableBySQL(strsql0);

                    if (dtstr0.Rows.Count > 0)
                    {
                        string str0 = String.Empty;

                        str0 += " <div class='pros'>";

                        for (int j = 0; j < dtstr0.Rows.Count; j++)
                        {
                            //2015.6.17
                            string filenamelist0 = "ProList_" + dtstr0.Rows[j]["c_no"] + "_l_" + 1 + ".html";

                            str0 += "<div class='pro_list'><div class='proimg'><a href='" + filenamelist0 + "'>";
                            str0 += "<img src='" + dtstr0.Rows[j]["c_gif"] + "' alt=\"" + dtstr0.Rows[j]["c_name"] + "\"  border='0' /></a></div>";
                            str0 += "<div class='prodes'> <a href='" + filenamelist0 + "'>" + dtstr0.Rows[j]["c_name"] + "</a></div></div>";


                        }

                        str0 += "</div>";

                        strHtml = strHtml.Replace("<$内页内容$>", str0);//内页内容-联系我们

                        string filename = "ProList_" + dtpro.Rows[i]["c_no"] + "_l_" + i + ".html";

                        #region 生成头部 title  版权部分

                        strHtml = strHtml.Replace("<$标题$>", model.webtitle);

                        strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

                        strHtml = strHtml.Replace("<$简介$>", model.webdescription);

                        strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
                        #endregion

                        writeFile("/en/", filename, strHtml);

                    }
                    else
                    {
                        strHtml = strHtml.Replace("<$内页内容$>", "资料整理中......");//内页内容-联系我们

                        string filename = "ProList_" + dtpro.Rows[i]["c_no"] + "_l_" + i + ".html";
                        #region 生成头部 title  版权部分


                        strHtml = strHtml.Replace("<$标题$>", model.webtitle);

                        strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

                        strHtml = strHtml.Replace("<$简介$>", model.webdescription);

                        strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
                        #endregion
                        writeFile("/en/", filename, strHtml);
                    }



                    string sql00 = "select * from dbo.B2C_category where c_no like '" + dtpro.Rows[i]["c_no"] + "%' and   len(c_no)=9  and  c_no  <>  " + dtpro.Rows[i]["c_no"];//查三级名称

                    DataTable dt00 = comfun.GetDataTableBySQL(sql00);
                    if (dt00.Rows.Count > 0)
                    {
                        for (int x = 0; x < dt00.Rows.Count; x++)
                        {

                            int line = 12; //更改分页条数 团队
                            int size;
                            string strsql = "select * from b2c_goods where cno=" + dt00.Rows[x]["c_no"];

                            DataTable dt1 = comfun.GetDataTableBySQL(strsql);

                            if (dt1.Rows.Count > line)
                            {
                                size = ((dt1.Rows.Count % line) != 0 ? dt1.Rows.Count / line + 1 : dt1.Rows.Count / line);
                            }
                            else
                            {
                                size = 1;
                            }
                            for (int j = 0; j < size; j++)
                            {

                                strHtml = GetHtml("/en/style_mo.html");

                                strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

                                strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

                                strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"product.html\">Product</a><em>></em><a href=\"" + "ProList_" + dtpro.Rows[i]["c_no"] + "_l_" + i + ".html" + "\">" + dtpro.Rows[i]["c_name"] + "</a><em>></em><a href=\"#\">" + dt00.Rows[x]["c_name"] + "</a>");//内页内容-您的位置

                                strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品

                                strHtml = strHtml.Replace("<$内页内容$>", getproductlist(size, (j + 1) * line, j, line, " and cno=" + dt00.Rows[x]["c_no"] + ""));//内页内容-联系我们


                                string filenamelist = "ProList_" + dt00.Rows[x]["c_no"] + "_l_" + (j + 1) + ".html";
                                #region 生成头部 title  版权部分


                                strHtml = strHtml.Replace("<$标题$>", model.webtitle);

                                strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

                                strHtml = strHtml.Replace("<$简介$>", model.webdescription);

                                strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
                                #endregion
                                writeFile("/en/", filenamelist, strHtml);

                            }
                        }
                    }





                    /////三级列表
                    string strsql01 = "select * from dbo.B2C_category where c_no like '" + dtpro.Rows[i]["c_no"] + "%' and   len(c_no)=9  and  c_no  <>  " + dtpro.Rows[i]["c_no"];//查三级名称

                    DataTable dtstr = comfun.GetDataTableBySQL(strsql01);

                    if (dtstr.Rows.Count > 0)
                    {


                        //生成内页中资料
                        for (int x = 0; x < dtstr.Rows.Count; x++)
                        {

                            //查询相应的信息
                            string sqlgood = "select * from b2c_goods where cno=" + dtstr.Rows[x]["c_no"];

                            DataTable dtgood = comfun.GetDataTableBySQL(sqlgood);


                            if (dtgood.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtgood.Rows.Count; j++)
                                {
                                    string sqlgoodm = "select * from dbo.B2C_Goods_M  where gid=" + dtgood.Rows[j]["id"];

                                    DataTable dtgoodm = comfun.GetDataTableBySQL(sqlgoodm);

                                    if (dtgoodm.Rows.Count > 0)
                                    {

                                        string ss = "<span class=\"titleclass\">" + dtgood.Rows[j]["g_name"].ToString() + "</span>" + dtgoodm.Rows[0]["g_msg"].ToString().ToString();

                                        strHtml = GetHtml("/en/style_mo.html");

                                        strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

                                        strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

                                        strHtml = strHtml.Replace("<$您的位置$>", "<a href=\"product.html\">Product</a><em>></em><a href=\"" + "ProList_" + dtpro.Rows[i]["c_no"] + "_l_" + i + ".html" + "\">" + dtpro.Rows[i]["c_name"] + "</a><em>></em><a href=\"#\">" + dtstr.Rows[x]["c_name"].ToString() + "</a>");//内页内容-您的位置

                                        strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品

                                        //2015.6.17
                                        if (ss != null)
                                        {

                                            strHtml = strHtml.Replace("<$内页内容$>", ss);//内页内容-联系我们

                                        }
                                        else
                                        {

                                            strHtml = strHtml.Replace("<$内页内容$>", "资料整理中......");//内页内容-联系我们

                                        }
                                    }
                                    else
                                    {
                                        strHtml = GetHtml("/en/style_mo.html");

                                        strHtml = strHtml.Replace("<$网页nav$>", GetNav());//首页导航

                                        strHtml = strHtml.Replace("<$首页联系我们$>", GetIndexContact());//生成首页联系我们

                                        strHtml = strHtml.Replace("<$您的位置$>", " <a href=\"" + "ProList_" + dtpro.Rows[i]["c_no"] + "_l_" + i + ".html" + "\">" + dtpro.Rows[i]["c_name"] + "</a><em>></em><a href=\"#\">" + dtgood.Rows[j]["g_name"].ToString() + "</a>");//内页内容-您的位置

                                        strHtml = strHtml.Replace("<$内页产品$>", GetNYProduct());//内页产品

                                        strHtml = strHtml.Replace("<$内页内容$>", "资料整理中......");//内页内容-联系我们
                                    }

                                    string filenamelist = GetFileName(1, Convert.ToInt32(dtgood.Rows[j]["id"].ToString()));
                                    #region 生成头部 title  版权部分


                                    strHtml = strHtml.Replace("<$标题$>", model.webtitle);

                                    strHtml = strHtml.Replace("<$关键字$>", model.webkeyword);

                                    strHtml = strHtml.Replace("<$简介$>", model.webdescription);

                                    strHtml = strHtml.Replace("<$版权$>", model.webcopyright);
                                    #endregion
                                    writeFile("/en/", filenamelist, strHtml);


                                }
                            }
                        }
                    }
                }
            }



        }

        #region 2.1 生成产品  +string GetProducts()
        /// <summary>
        /// 2.1 生成产品
        /// </summary>
        /// <returns></returns>
        private string GetProducts()
        {

            StringBuilder strpro = new StringBuilder();

            string sqlpro = "select * from dbo.B2C_category where c_no like '002001%' and   len(c_no)=9  and c_no <> 002001";//查二级名称

            DataTable dtpro = comfun.GetDataTableBySQL(sqlpro);

            string strs = String.Empty;

            string strsan = String.Empty;


            if (dtpro.Rows.Count > 0)
            {
                for (int i = 0; i < dtpro.Rows.Count; i++)
                {
                    if (dtpro.Rows[i]["c_no"].ToString() != "002001005")
                    {
                        // string filename = "ProList_" + dtpro.Rows[i]["c_no"] + "_l_" + i + ".html";
                        string filename = "#";

                        strs += "<li><a href='" + filename + "'>" + dtpro.Rows[i]["c_name"] + "</a>";//添加二级名称
                    }
                    else
                    {
                        string filename = "ProList_" + dtpro.Rows[i]["c_no"] + "_l_" + i + ".html";
                        strs += "<li><a href='" + filename + "'>" + dtpro.Rows[i]["c_name"] + "</a>";//添加二级名称
                    }
                    string strsql = "select * from dbo.B2C_category where c_no like '" + dtpro.Rows[i]["c_no"] + "%' and   len(c_no)=12  and  c_no  <>  " + dtpro.Rows[i]["c_no"];//查三级名称

                    DataTable dtstr = comfun.GetDataTableBySQL(strsql);
                    if (dtpro.Rows[i]["c_no"].ToString() != "002001005")
                    {
                        strsan = "<ul>";

                        if (dtstr.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtstr.Rows.Count; j++)
                            {
                                string filenamelist = "ProList_" + dtstr.Rows[j]["c_no"] + "_l_" + 1 + ".html";

                                strsan += "<li><a href='" + filenamelist + "'>" + dtstr.Rows[j]["c_name"] + "</a></li>";//添加三级名称  和 链接地址
                            }
                        }
                        strsan += "</ul>";

                        strs += strsan;
                    }

                }
            }


            strpro.Append(strs);



            return strpro.ToString();
        }
        #endregion

        #region 产品列表 +getproductlist(int size, int count, int pagenum, int line, string _sqlwhere)
        string getproductlist(int size, int count, int pagenum, int line, string _sqlwhere)
        {
            string strHtml = String.Empty;
            string sql = "";
            if (pagenum > 0)
            {
                sql = "select top " + line + "* from b2c_goods where  id not in (select top (" + line + "*" + pagenum + ") id from b2c_goods where 1=1  " + _sqlwhere + "  order by g_sort asc,g_wdate desc) " + _sqlwhere + " order by g_sort asc,g_wdate desc";
            }
            else
            {
                sql = "select top " + line + "* from b2c_goods where 1=1 " + _sqlwhere + "  order by g_sort asc,g_wdate desc";
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0 && dt != null)
            {

                strHtml = "  <div class='pros  clear'> ";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string FileName = GetFileName(1, Convert.ToInt32(dt.Rows[i]["id"]));

                    strHtml += "<div class='pro_list'><div class='proimg'><a href='" + FileName + "'>";
                    strHtml += "<img src='" + dt.Rows[i]["g_gif"] + "' alt=\"" + dt.Rows[i]["g_name"] + "\"  border='0' /></a></div>";
                    strHtml += "<div class='prodes'> <a href='" + FileName + "'>" + dt.Rows[i]["g_name"] + "</a></div></div>";

                }
                strHtml += " </div>";


                strHtml = pagechange(count, size, pagenum, strHtml, dt.Rows[0]["cno"].ToString(), line, "ProList_");
            }
            else //2015.6.17
            {
                strHtml = "  <div class='pros  clear'> ";
                strHtml += "资料整理中......";
                strHtml += " </div>";
            }

            return strHtml;
        }
        #endregion

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

            strHtml += " <div class=\"pageControlCon clear2\">";
            strHtml += "  <ul class=\"clear2 fl\">";
            int s, z;
            s = (count / line) - 1 > 0 ? count / line : 1;
            strHtml += "   <li class=\"" + ((count / line) - 1 > 0 ? "next" : "disabled") + "\"><a href=\"" + ((s == 1) ? "###" : "" + type + "" + cno + "_l_" + (s - 1) + ".html") + "\">Prev</a></li>";

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

            strHtml += " <li class=\"" + ((s == 1) && (s + 1 + 1 < size) ? "next" : (size == (pa + 1) ? "disabled" : "next")) + "\"><a href=" + ((size == (pa + 1)) ? "###" : "" + type + "" + cno + "_l_" + ((pa + 1 + 1) > size ? size : (pa + 1 + 1)) + ".html") + ">Next</a></li>";
            strHtml += " </ul>";
            strHtml += "   <div class=\"total\">";
            strHtml += "  <input type='hidden' id='typecno' value='" + type + "" + cno + "_l_" + "'/><input type='hidden' id='btnsize' value='" + size + "'/> <input type='text' style='width:30px;'  id='pagego' value=''/><a href='javascript:;' onclick='pagego()'>GO</a> ";
            strHtml += "   </div>";
            strHtml += "   <div class=\"total\">";
            strHtml += "  <span id=\"Size\" class=\"pages pages1\">Total " + size + "  </span>";
            strHtml += "   </div>";
            strHtml += "</div></div>";
            return strHtml;
        }
        #endregion
         
    }
}