﻿using Creatrue.Common.Msgbox;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;

namespace tdx.memb.man.Tuan.BrowseManage
{
    public partial class BrowseList : DTcms.Web.UI.ManagePage
    {
        DTcms.BLL.WP_浏览记录表 flbll = new DTcms.BLL.WP_浏览记录表();

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

            string sql = " select top 10*  from dbo.WP_浏览记录表 where id not in (select top (10*" + page + ") id  from dbo.WP_浏览记录表 where  订单编号 in (  ";
            sql += " select 订单编号 from dbo.TM_订单子表  where 商品编号 in(  ";
            sql += " select 编号 from dbo.TM_商品表  " + _where + "  ))) and  订单编号 in (    ";
            sql += " select 订单编号 from dbo.TM_订单子表  where 商品编号 in(  ";
            sql += "  select 编号 from dbo.TM_商品表  " + _where + " ))";

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

                int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ToString()) ? "-1" : Session["dtid"].ToString());

                if (dtid > 0)
                {
                    DataTable dtdt = dtbll.GetList(" id=" + dtid).Tables[0];
                    if (dtdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtdt.Rows.Count; i++)
                        {
                            if (dtdt.Rows[i]["user_name"].ToString() != "admin")
                            {
                                goods("where 用户ID=" + dtdt.Rows[i]["id"].ToString());
                            }
                            else
                            {
                                goods("");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('网络链接超时，请重新登录！')</script>");

            }
        }

        private void goods(string where)
        {


            string sql = "select count(*) from dbo.WP_浏览记录表  where  订单编号 in (  ";
            sql += "select 订单编号 from dbo.TM_订单子表  where 商品编号 in(";
            sql += "select 编号 from dbo.TM_商品表  " + where + "))";




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
                Response.Write("<script>alert('网络错误，请稍后重试！')</script>");
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

                    bool res = flbll.Delete(id);
                    if (res)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            goodsinfoList();
        }
        #endregion

        //#region 5.0分页
        /////// <summary>
        /////// 分页控件
        /////// </summary>
        /////// <param name="sender"></param>
        /////// <param name="e"></param>
        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{
        //    goodsinfoList();
        //}
        //#endregion

        #region 6.0 生成Excel表格 + void btn_baobiao_Click(object sender, EventArgs e)

        /// <summary>
        /// 生成Excel表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_baobiao_Click(object sender, EventArgs e)
        {

            DTcms.BLL.manager dtbll = new DTcms.BLL.manager();

            int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ToString()) ? "-1" : Session["dtid"].ToString());

            if (dtid > 0)
            {
                DataTable dtdt = dtbll.GetList(" id=" + dtid).Tables[0];
                if (dtdt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtdt.Rows.Count; i++)
                    {
                        if (dtdt.Rows[i]["user_name"].ToString() != "admin")
                        {
                            string sql = "select * from dbo.WP_浏览记录表  where  订单编号 in (  ";
                            sql += "select 订单编号 from dbo.TM_订单子表  where 商品编号 in(";
                            sql += "select 编号 from dbo.TM_商品表  where 用户ID=" + dtdt.Rows[i]["id"].ToString() + "))";


                            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                DTcms.Common.Excel.DataTable4Excel(dt, "浏览Excel表");
                            }

                        }
                        else
                        {
                            string sql = "select * from dbo.WP_浏览记录表  where  订单编号 in ( ";
                            sql += "select 订单编号 from dbo.TM_订子单表  where 商品编号 in(";
                            sql += "select 编号 from dbo.TM_商品表   ))";


                            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                DTcms.Common.Excel.DataTable4Excel(dt, "浏览Excel表");
                            }
                        }

                    }
                }
            }


        }
    }
}

        #endregion 