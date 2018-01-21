using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.DBUtility;
using DTcms.Model;
using tdx.database;

namespace tdx.memb.man.Talking
{
    public partial class TalkTalk : System.Web.UI.Page
    {
        protected internal siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        public static int td;

        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = string.IsNullOrEmpty(Request["id"]) ? "0" : Request["id"];

                if (id == "0")
                {
                    goodsinfoList();
                }
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
            string sql = "  select top 10*  from ( select a.*,b.wx昵称,wx头像,b.手机号,c.名称,c.内容,d.类别名,d.类别编号 from [dbo].[TK_评论表] a left join WP_会员表 b on a.openid=b.openid left join TK_发帖表 c on a.发帖表id =c.id left join  TK_发帖类别表 d on c.类别号=d.类别编号    ";
            sql += "    )  as aa  where aa.id  not in (select top (10*" + page + ") id  from ( select a.*,b.wx昵称,wx头像,b.手机号,c.名称,c.内容,d.类别名,d.类别编号 from [dbo].[TK_评论表] a left join WP_会员表 b on a.openid=b.openid left join TK_发帖表 c on a.发帖表id =c.id left join  TK_发帖类别表 d on c.类别号=d.类别编号      ";
            sql += "    )  as aa   where    " + _where + " order by id desc) and  " + _where + "  order by id desc  ";



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

            DTcms.BLL.manager dtbll = new DTcms.BLL.manager();


            try
            {
                goods(" aa.id!=0");
                //goodstype();
            }
            catch (Exception)
            {

                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();

            }
        }


        //private void goodstype()
        //{
        //    string sql = " select id,类别编号,类别名 from TK_发帖类别表 order by id asc";

        //    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["类别名"] = "所有分类";
        //    row["类别编号"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    if (dt.Rows.Count > 0)
        //    {

        //        drp_photo.DataSource = dt.DefaultView;
        //        drp_photo.DataTextField = "类别名";
        //        drp_photo.DataValueField = "类别编号";

        //        drp_photo.DataBind();

        //    }

        //}

        private void goods(string where)
        {

            string sql = "select count(*) from ( select a.*,b.wx昵称,wx头像,b.手机号,c.名称,c.内容,d.类别名,d.类别编号 from [dbo].[TK_评论表] a left join WP_会员表 b on a.openid=b.openid left join TK_发帖表 c on a.发帖表id =c.id left join  TK_发帖类别表 d on c.类别号=d.类别编号 )  ";
            sql += "  as aa  where  " + where + "  ";

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

                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();
            }
            #endregion


        }

        #endregion



        #region 4.0 删除 +void btnDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //DTcms.BLL.WP_商品图片表 sptpbll = new DTcms.BLL.WP_商品图片表();

                    //DTcms.BLL.WP_商品详情表 spxqbll = new DTcms.BLL.WP_商品详情表();

                    DTcms.BLL.TK_评论表 spbll = new DTcms.BLL.TK_评论表();

                    //DataTable dt = spbll.GetList(" id=" + id).Tables[0];

                    //if (dt.Rows.Count > 0)
                    //{
                    //    ///删除图片
                    //    DataTable dttp = sptpbll.GetList(" 商品编号='" + dt.Rows[0]["编号"].ToString() + "' ").Tables[0];
                    //    if (dttp.Rows.Count > 0)
                    //    {
                    //        for (int j = 0; j < dttp.Rows.Count; j++)
                    //        {
                    //            bool r = sptpbll.Delete(int.Parse(dttp.Rows[j]["id"].ToString()));
                    //        }
                    //    }

                    //    ///删除详情
                    //    DataTable dtxq = spxqbll.GetList(" 商品编号='" + dt.Rows[0]["编号"].ToString() + "' ").Tables[0];

                    //    if (dtxq.Rows.Count > 0)
                    //    {
                    //        bool re = spxqbll.Delete(int.Parse(dtxq.Rows[0]["id"].ToString()));
                    //    }
                    //}
                    ///删除商品
                    bool res = spbll.Delete(id);
                    if (res)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='TalkTalk.aspx'", true);
        }
        #endregion


        #region 6.0 生成Excel表格 + void btn_baobiao_Click(object sender, EventArgs e)

        ///// <summary>
        ///// 生成Excel表格
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btn_baobiao_Click(object sender, EventArgs e)
        //{
        //    //string sql = "select * from ( select yh.id as yhid,用户名,密码,openID,手机号,微信昵称,微信头像, ";
        //    //sql += "sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,";
        //    //sql += "spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍,";
        //    //sql += "sptp.id as 商品图片id ,sptp.商品编号  as tp商品编号,标题,图片路径  ";
        //    //sql += "from dbo.WP_用户表 as yh inner join dbo.WP_商品表 as sp on yh.id=sp.用户id   left join dbo.WP_商品详情表  as spxq  ";
        //    //sql += " on sp.编号=spxq.商品编号 left join dbo.WP_商品图片表  as sptp on  spxq.商品编号=sptp.商品编号)  as aa  ";

        //    //DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        //    DataTable dt = spbll.GetAllList().Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        DTcms.Common.Excel.DataTable4Excel(dt, "商品信息表");
        //    }
        //} 
        #endregion

        #region 前台判断是否显示
        /// <summary>
        /// 前台判断是否显示
        /// </summary>
        /// <returns></returns>
        public string isshow()
        {
            DTcms.BLL.manager dtbll = new DTcms.BLL.manager();

            string s = String.Empty;
            try
            {
                int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ToString()) ? "-1" : Session["dtid"].ToString());

                if (dtid > 0)
                {
                    DataTable dtdt = dtbll.GetList(0, " id=" + dtid, "id").Tables[0];
                    if (dtdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtdt.Rows.Count; i++)
                        {
                            if (dtdt.Rows[i]["user_name"].ToString() == "admin")
                            {

                                s = " <th width=\"6%\">当前状态</th>";

                            }

                        }
                    }
                }

            }
            catch (Exception)
            {

                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();


            }

            return s;

        }
        #endregion

        #region 搜索
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            string query = "";
            if (txt_pinming.Text.Trim() != "")
            {
                query += " and 名称 like '%" + txt_pinming.Text.Trim() + "%'";
            }


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
            string sql = "select *  from ( select a.*,b.wx昵称,wx头像,b.手机号,c.名称,c.内容,d.类别名,d.类别编号 from [dbo].[TK_评论表] a left join WP_会员表 b on a.openid=b.openid left join TK_发帖表 c on a.发帖表id =c.id left join  TK_发帖类别表 d on c.类别号=d.类别编号   ";
            sql += " )  as aa  where  1=1 " + where + "  ";


            DataTable dt = comfun.GetDataTableBySQL(sql);


            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();
            lt_pagearrow.Text = "";



        }
        #endregion

        //protected void drp_photo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string type_id = this.drp_photo.Text;

        //    if (type_id == "-1")
        //    {
        //        sousuo(" and aa.id!=0");
        //    }
        //    else
        //    {
        //        sousuo(" and aa.类别号='" + type_id + "'");
        //    }
        //}
    }
}