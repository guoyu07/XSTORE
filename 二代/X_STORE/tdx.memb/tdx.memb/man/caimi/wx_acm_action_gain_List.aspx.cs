﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.caimi
{
    public partial class wx_acm_action_gain_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理和编辑猜谜活动的获奖信息。";
                    string _id = Request["id"] != null ? Request["id"].ToString() : "";

                    string dzd = " *,(select ac_name from wx_acm_action where id=acid) acname,(select g_name from wx_acm_action_gains where id=gid) as gname ";
                    string sql = "(1=1) and acid=" + _id;
                    lb_prolist.Text = prolist(dzd, sql);
                    //生成分页按钮
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_acm_gain where  " + sql).Rows[0][0]);
                    int _ipage = Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1;
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_ipage, totalcount, 20, Request.Form, Request.QueryString);



                    //lb_proadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='wx_acm_action_gain_Add.aspx' \" value=\"添加新猜谜活动\"/>";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/wx_acm_action_gain_List.cs", Session["wID"].ToString());
                }
            }
        }
        private string prolist(string _dzd, string _sql)
        {
            string str = "";
            str += @"<table >";
            str += @"        <tr>";
            str += "          <th ><input type=checkbox  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"          <th>活动名称</th>";
            str += @"          <th>奖品</th>";
            str += @"          <th>获奖时间</th>";
            str += @"          <th>身份证</th>";
            str += @"          <th>电话</th>";
            str += @"          <th>姓名</th>";
            str += @"          <th>领奖时间</th>";
            str += @"          <th>员工</th>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            //str += currentpage.ToString();
            DataTable dt = wx_acm_gain.GetList(currentpage, _dzd, _sql);

            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr> ";
                str += @"          <td  > <input type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td >" + dr["acname"] + "</td>";
                str += @"          <td >" + dr["gname"] + "</td>";
                str += @"          <td >" + dr["ga_wdate"] + "</td>";
                str += @"          <td >" + dr["ga_idc"] + "</td>";
                str += @"          <td >" + dr["ga_tel"] + "</td>";
                str += @"          <td >" + dr["ga_gdate"] + "</td>";
                str += @"          <td >" + dr["wuser"] + "</td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }
        #region  功能按钮

        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string delid = "0";
                if (Request["delbox"] != null)
                {
                    delid = Request["delbox"].ToString();
                    wx_acm_gain.delete(delid);

                    lt_result.Text = "彻底删除成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_action_gain_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的项！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/wx_acm_action_gain_List.cs", Session["wID"].ToString());
            }
        }

        #endregion

    }
}