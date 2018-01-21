using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Model;
using DTcms.BLL;
using System.Data;
using Creatrue.Common.Msgbox;
using Creatrue.kernel;

namespace tdx.memb.man.Tuan.UserManage
{
    public partial class UserList : DTcms.Web.UI.ManagePage
    {
        DTcms.BLL.manager yhbll = new DTcms.BLL.manager();
         
        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userinfoList();
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
            DataTable dt = comfun.GetDataTableBySQL("select top 10*  from dt_manager where id not in (select top (10*" + page + ") id  from dt_manager) and   id<>1  and " + _where + "");

            
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
        public void userinfoList()
        {
            DataTable dt = yhbll.GetAllList().Tables[0];
            if (dt.Rows.Count > 0)
            {
                 
                #region 分页2015.6.25
                try
                {
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);

                    lb_catelist.Text = ClassList(" 1=1 ", _page - 1);
                     
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from dt_manager where  id<>1 ").Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 10, Request.Form, Request.QueryString);


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('网络错误，请稍后重试！"+ex.Message+"')</script>");
                }
                #endregion
                 
            }
        }

        #endregion

        #region 3.0 搜索+ void LBtn_sousuo_Click(object sender, EventArgs e)
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void LBtn_sousuo_Click(object sender, EventArgs e)
        //{
        //    if (txt_Telephone.Text.Trim() != "" && txt_Name.Text.Trim() != "")
        //    {
        //        string sql = " 用户名 like '%" + txt_Name.Text + "%' and  手机号 like '%" + txt_Telephone.Text+"%' ";
        //        DataTable dt = yhbll.GetList(sql).Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            Rp_UserInfo.DataSource = dt.DefaultView;
        //            Rp_UserInfo.DataBind();
        //        }
                
        //    }
        //    else if (txt_Name.Text.Trim() != "")
        //    {
        //        string sql = " 用户名 like '%" + txt_Name.Text + "%' ";
        //        DataTable dt = yhbll.GetList(sql).Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            Rp_UserInfo.DataSource = dt.DefaultView;
        //            Rp_UserInfo.DataBind();
        //        }
        //    }
        //    else if (txt_Telephone.Text.Trim() != "")
        //    {
        //        string sql = "  手机号 like '%" + txt_Telephone.Text + "%' ";
        //        DataTable dt = yhbll.GetList(sql).Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            Rp_UserInfo.DataSource = dt.DefaultView;
        //            Rp_UserInfo.DataBind();
        //        }
        //    }
        //    else 
        //    {
        //        userinfoList();
        //    }


        //}
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
                    bool res = yhbll.Delete(id);
                    if (res)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            userinfoList();
        }
        #endregion
         
        #region 6.0 生成Excel表格 + void btn_baobiao_Click(object sender, EventArgs e)

        /// <summary>
        /// 生成Excel表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btn_baobiao_Click(object sender, EventArgs e)
        //{
        //   DataTable  dt= yhbll.GetAllList().Tables[0];
        //   if (dt.Rows.Count>0)
        //   { 
        //       DTcms.Common.Excel.DataTable4Excel(dt, "用户信息表");
        //   }
        //}
        
        #endregion 
    }
}