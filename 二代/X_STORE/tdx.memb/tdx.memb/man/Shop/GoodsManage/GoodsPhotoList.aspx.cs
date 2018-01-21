using Creatrue.Common.Msgbox;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.Common;
using tdx.database;
using DTcms.Model;


namespace tdx.memb.man.Shop.GoodsManage
{
    public partial class GoodsPhotoList : System.Web.UI.Page
    {
        DTcms.BLL.WP_商品图片表 spbll = new DTcms.BLL.WP_商品图片表();

        public static int td;

        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                goodsinfoList();
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

            string sql = "  select top 10*  from  dbo.WP_商品图片表 where id not in (select top (10*" + page + ") id  from  dbo.WP_商品图片表  where 商品编号 in(select 编号 from dbo.WP_商品表 " + _where + " ) order by id desc) and     ";
            sql += "  商品编号 in(select 编号 from dbo.WP_商品表  " + _where + ") order by id desc   ";


            DataTable dt = comfun.GetDataTableBySQL(sql);


            string str = "";
            if (dt.Rows.Count > 0)
            {
                Rp_UserInfo.DataSource = dt.DefaultView;
                Rp_UserInfo.DataBind();

            }
            else
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
                int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ToString()) ? "-1" : Session["dtid"].ToString());

                if (dtid > 0)
                {
                    DataTable dtdt = dtbll.GetList(0," id=" + dtid,"id").Tables[0];
                    if (dtdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtdt.Rows.Count; i++)
                        {
                            if (dtdt.Rows[i]["user_name"].ToString() != "admin")
                            {
                                td = 0;
                                if (Request["spbh"] != null)
                                {
                                    //goods("where 用户ID=" + dtdt.Rows[i]["id"].ToString()+" and 商品编号='"+Request["spbh"].ToString()+"'");
                                    //goodsphoto("where 用户ID=" + dtdt.Rows[i]["id"].ToString() + " and 编号='" + Request["spbh"].ToString() + "'");

                                    goods("where  商品编号='" + Request["spbh"].ToString() + "'");
                                    goodsphoto("where  编号='" + Request["spbh"].ToString() + "'");
                                }
                                else
                                {
                                    //goods("where 用户ID=" + dtdt.Rows[i]["id"].ToString());
                                    //goodsphoto("where 用户ID=" + dtdt.Rows[i]["id"].ToString());
                                    goods("");
                                    goodsphoto("");
                                }

                            }
                            else
                            {
                                td = 1;
                                if (Request["spbh"] != null)
                                {
                                    goods(" where   商品编号='" + Request["spbh"].ToString() + "'");
                                    goodsphoto("where 编号='" + Request["spbh"].ToString() + "' ");
                                }
                                else
                                {
                                    goods("");
                                    goodsphoto("");
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
                //Response.Write("<script>alert('网络链接超时，请重新登录！')</script>");
                //Response.Write("<script>parent.location.href='http://sgapp.creatrue.net/man/login.aspx'</Script>");
            }
        }

        private void goodsphoto(string p)
        {
            string sql = " select * from dbo.WP_商品表 " + p;


            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {

                drp_photo.DataSource = dt.DefaultView;
                drp_photo.DataTextField = "品名";
                drp_photo.DataValueField = "编号";

                drp_photo.DataBind();

            }
        }

        private void goods(string where)
        {

            string sql = " select * from  dbo.WP_商品图片表 where 商品编号 in(select 编号 from dbo.WP_商品表 " + where + ") order by id desc";



            #region 分页2015.6.25
            try
            {
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);

                lb_catelist.Text = ClassList(where, _page - 1);


                //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows.Count);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 10, Request.Form, Request.QueryString);


            }
            catch (Exception ex)
            {
                // Response.Write("<script>parent.location.href='http://china-mail.com.cn/39tuan/man/login.aspx'</Script>");
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

                    bool res = spbll.Delete(id);
                    if (res)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsPhotoList.aspx'", true);
        }
        #endregion



        protected void drp_photo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTcms.BLL.manager dtbll = new DTcms.BLL.manager();


            int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ToString()) ? "-1" : Session["dtid"].ToString());

            if (dtid > 0)
            {
                DataTable dtdt = dtbll.GetList(0," id=" + dtid,"id").Tables[0];
                if (dtdt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtdt.Rows.Count; i++)
                    {
                        if (dtdt.Rows[i]["user_name"].ToString() != "admin")
                        {
                            //string where="where 用户ID=" + dtdt.Rows[i]["id"].ToString();
                            //    string s="  and 商品编号= '" + drp_photo.SelectedValue + "' ";
                            //    string _where = "  where 商品编号= '" + drp_photo.SelectedValue + "' ";
                            //    goodss(where,s);

                            goodss("  where 用户ID!=0", "  and 商品编号= '" + drp_photo.SelectedValue + "' ");
                            //try
                            //{
                            //    string sql = " select * from  dbo.WP_商品图片表 where 商品编号 in(select 编号 from dbo.WP_商品表  where 编号=" + drp_photo.SelectedValue + ") order by id desc";
                            //    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);

                            //    lb_catelist.Text = ClassList(_where, _page - 1);


                            //    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
                            //    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 10, Request.Form, Request.QueryString);


                            //}
                            //catch (Exception ex)
                            //{
                            //    // Response.Write("<script>parent.location.href='http://china-mail.com.cn/39tuan/man/login.aspx'</Script>");
                            //}
                        }
                        else
                        {
                            goodss("  where 用户ID!=0", "  and 商品编号= '" + drp_photo.SelectedValue + "' ");

                        }
                    }
                }
            }
        }

        private void goodss(string where, string s)
        {
            string sql = " select * from  dbo.WP_商品图片表 where 商品编号 in(select 编号 from dbo.WP_商品表 " + where + ") " + s + " order by id desc";


            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();

            lt_pagearrow.Text = "";
        }
    }
}

