using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.Common;
using DTcms.DBUtility;
using DTcms.Model;
using tdx.database;

namespace tdx.memb.man.Talking
{
    public partial class talk_choose : System.Web.UI.Page
    {
        DTcms.BLL.TK_发帖表 spbll = new DTcms.BLL.TK_发帖表();
        protected internal siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        public static int td;
        public string url = "";
        public string ctl = "";
        public string choose = "";
        public string btn = "";
        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ctl = DTRequest.GetQueryString("ctl");
            this.btn = DTRequest.GetQueryString("btn");
            string s = DTRequest.GetQueryString("choose");
            this.choose = s == "" ? "multiple" : s;
            string val = DTRequest.GetQueryString("val");
            url = val;

            if (!IsPostBack)
            {
                ///2015.7.12 添加
                string spbh = string.IsNullOrEmpty(Request["spbh"]) ? "0" : Request["spbh"];


                if (spbh == "0")
                {
                    goodsinfoList();
                }
                else
                {
                    getlist(spbh);
                }
            }
        }

        /// <summary>
        /// 某个人的订单  2015.7.12
        /// </summary>
        /// <param name="opid"></param>
        private void getlist(string spbh)
        {
            string sql = "select  *  from ( select yh.openid as yhid,wx昵称 as 发布人,手机号,  ";
            sql += "sp.id ,sp.编号,sp.类别号,sp.名称, sp.内容,sp.创建时间,sp.是否置顶,lb.类别名 ";
            sql += "from dbo.WP_会员表 as yh left join dbo.TK_发帖表 as sp on yh.openid=sp.openid left join TK_发帖类别表 lb on sp.类别号=lb.类别编号   ";
            sql += " )  as aa  where  aa.编号 ='" + spbh + "'  ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                Rp_UserInfo.DataSource = dt.DefaultView;
                Rp_UserInfo.DataBind();
                lt_pagearrow.Text = "";
            }

        }

        #endregion

        #region 读取分页数据2015.6.25
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        protected string ClassList(string _where, int page)
        {

            string sql = "  select top 10*  from ( select yh.openid as yhid,wx昵称 as 发布人,手机号,    ";
            sql += "  sp.id ,sp.编号,sp.类别号,sp.名称, sp.内容,sp.创建时间,sp.是否置顶,lb.类别名    ";
            sql += "  from dbo.WP_会员表 as yh left join dbo.TK_发帖表 as sp on yh.openid=sp.openid left join TK_发帖类别表 lb on sp.类别号=lb.类别编号      ";
            sql += "     ";
            sql += "   )  as aa  where aa.id not in (select top (10*" + page + ") aa.id  from ( select yh.openid as yhid,wx昵称 as 发布人,手机号,    ";
            sql += "   sp.id ,sp.编号,sp.类别号,sp.名称, sp.内容,sp.创建时间,sp.是否置顶,lb.类别名      ";
            sql += "   from dbo.WP_会员表 as yh left join dbo.TK_发帖表 as sp on yh.openid=sp.openid left join TK_发帖类别表 lb on sp.类别号=lb.类别编号     ";
            sql += "  )  as aa  where   " + _where + " order by id desc) and  " + _where + "  order by id desc  ";



            DataTable dt = comfun.GetDataTableBySQL(sql);


            string str = "";
            if (dt.Rows.Count > 0)
            {
                Rp_UserInfo.DataSource = dt.DefaultView;
                Rp_UserInfo.DataBind();

            }
            return str;
        }
        #endregion


        #region 2.0 用户数据显示 + void userinfoList()
        /// <summary>
        /// 用户列表数据显示
        /// </summary>
        public void goodsinfoList()
        {

            try
            {
                goods(" aa.id!=0");
                goodstype();
            }
            catch (Exception)
            {

                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();

            }
        }


        private void goodstype()
        {
            string sql = " select * from dbo.TK_发帖类别表 ";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["类别名"] = "所有分类";
            row["类别编号"] = "-1";
            dt.Rows.InsertAt(row, 0);
            if (dt.Rows.Count > 0)
            {

                drp_photo.DataSource = dt.DefaultView;
                drp_photo.DataTextField = "类别名";
                drp_photo.DataValueField = "类别编号";

                drp_photo.DataBind();

            }

        }

        private void goods(string where)
        {


            string sql = "select count(*) from ( select yh.openid as yhid,wx昵称 as 发布人,手机号, ";
            sql += "sp.id ,sp.编号,sp.类别号,sp.名称, sp.内容,sp.创建时间,sp.是否置顶,lb.类别名 ";
            sql += " from dbo.WP_会员表 as yh left join dbo.TK_发帖表 as sp on yh.openid=sp.openid left join TK_发帖类别表 lb on sp.类别号=lb.类别编号   ";
            sql += "  )  as aa   where  " + where + "  ";



            #region 分页2015.6.25
            try
            {
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);

                lb_catelist.Text = ClassList(where, _page - 1);

                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 10, Request.Form, Request.QueryString);


            }
            catch (Exception ex)
            {
                // Response.Write("<script>parent.location.href='http://china-mail.com.cn/39tuan/man/login.aspx'</Script>");
            }
            #endregion
        }

        #endregion





        #region 搜索  2015.7.12
        /// <summary>
        /// 搜索  2015.7.12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            string query = "";
            if (txt_pinming.Text.Trim() != "")
            {
                query += " and 名称 like '%" + txt_pinming.Text.Trim() + "%'";
                //sousuo( "品名 like '%"+ txt_pinming.Text.Trim()+"%'");
            }
            //if (txt_username.Text.Trim() != "")
            //{
            //    query += " and user_name like '%" + txt_username.Text.Trim() + "%'";
            //    sousuo(" user_name like '%" + txt_username.Text.Trim() + "%'");
            //}
            //if (txt_telephone.Text.Trim() != "")
            //{
            //    query += " and telephone like '%" + txt_telephone.Text.Trim() + "%'";
            //    //sousuo("telephone like '%"+txt_telephone.Text.Trim()+"%'");
            //}


            if (query == "")
            {
                goodsinfoList();
            }
            else
            {
                sousuo(query);
            }

        }

        private void sousuo(string where)
        {
            string sql = "select  *  from ( select yh.openid as yhid,wx昵称 as 发布人,手机号,  ";
            sql += "sp.id ,sp.编号,sp.类别号,sp.名称, sp.内容,sp.创建时间,sp.是否置顶,lb.类别名 ";
            sql += "from dbo.WP_会员表 as yh left join dbo.TK_发帖表 as sp on yh.openid=sp.openid left join TK_发帖类别表 lb on sp.类别号=lb.类别编号  ";
            sql += ")  as aa   where  1=1 " + where + "  ";


            DataTable dt = comfun.GetDataTableBySQL(sql);


            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();
            lt_pagearrow.Text = "";



        }
        #endregion

        protected void drp_photo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type_id = this.drp_photo.Text;

            if (type_id == "-1")
            {
                sousuo(" and  aa.id!=0");
            }
            else
            {
                sousuo(" and  aa.类别号='" + type_id + "'");
            }
        }
    }
}