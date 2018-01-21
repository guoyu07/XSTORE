using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;

namespace tdx.memb.man.Tuan.VipManage
{
    public partial class VipList : DTcms.Web.UI.ManagePage
    {
        DTcms.BLL.WP_会员表 hybll = new DTcms.BLL.WP_会员表();
 

        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
               vipinfoList();
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
            //size为10，第一页的数据
            DTcms.BLL.WP_会员表 badv = new DTcms.BLL.WP_会员表();
            DataTable dt=badv.GetVipInfo("ordercount>0 and " + _where, 1);
            string str = "";
            if (dt.Rows.Count > 0)
            { 
                Rp_VipInfo.DataSource = dt.DefaultView;
                Rp_VipInfo.DataBind(); 
            }
            return str;
        }
        #endregion

        #region 2.0 用户数据显示 + void userinfoList()
        /// <summary>
        /// 用户列表数据显示
        /// </summary>
        public void vipinfoList()
        {

            #region 分页2015.6.25
            try
            {
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                lb_catelist.Text = ClassList(" 1=1 ", _page - 1);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from VipInfo where  ordercount>0 ").Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 10, Request.Form, Request.QueryString);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('网络错误，请稍后重试！')</script>");
            } 
            #endregion

            #region MyRegion
            //DataTable dt = hybll.GetAllList().Tables[0];
            //if (dt.Rows.Count > 0)
            //{

            //    Rp_VipInfo.DataSource = dt.DefaultView;
            //    Rp_VipInfo.DataBind();

            //    ////初始化分页数据源实例
            //    //PagedDataSource pds = new PagedDataSource();
            //    ////设置总行数
            //    //AspNetPager1.RecordCount = dt.Rows.Count;
            //    ////设置分页的数据源
            //    //pds.DataSource = dt.DefaultView;
            //    ////设置当前页
            //    //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            //    ////设置每页显示页数
            //    //pds.PageSize = AspNetPager1.PageSize;
            //    ////启用分页
            //    //pds.AllowPaging = true;
            //    ////设置GridView的数据源为分页数据源
            //    //Rp_VipInfo.DataSource = pds;
            //    ////绑定GridView
            //    //Rp_VipInfo.DataBind();

            //    //this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, this.AspNetPager1.PageSize });

            //} 
            #endregion
        }

        #endregion

        #region 3.0 搜索+ void LBtn_sousuo_Click(object sender, EventArgs e)
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            if (txt_Telephone.Text.Trim() != "" && txt_Name.Text.Trim() != "")
            {
                string sql = " ordercount>0 and  wx昵称 like '%" + txt_Name.Text + "%' and  手机号 like '%" + txt_Telephone.Text + "%' ";
                DataTable dt = hybll.GetListNew(sql).Tables[0];
                    Rp_VipInfo.DataSource = dt.DefaultView;
                    Rp_VipInfo.DataBind();
            }
            else if (txt_Name.Text.Trim() != "")
            {
                string sql = " ordercount>0 and  wx昵称 like '%" + txt_Name.Text + "%' ";
                DataTable dt = hybll.GetListNew(sql).Tables[0];
                    Rp_VipInfo.DataSource = dt.DefaultView;
                    Rp_VipInfo.DataBind();
            }
            else if (txt_Telephone.Text.Trim() != "")
            {
                string sql = " ordercount>0 and   手机号 like '%" + txt_Telephone.Text + "%' ";
                DataTable dt = hybll.GetListNew(sql).Tables[0];
                    Rp_VipInfo.DataSource = dt.DefaultView;
                    Rp_VipInfo.DataBind();
            }
            else
            {
               vipinfoList();
            }
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

            for (int i = 0; i < Rp_VipInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_VipInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_VipInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bool res = hybll.Delete(id);
                    if (res)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            vipinfoList();
        }
        #endregion

 

        #region 6.0 生成Excel表格 + void btn_baobiao_Click(object sender, EventArgs e)

        /// <summary>
        /// 生成Excel表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_baobiao_Click(object sender, EventArgs e)
        {
            DataTable dt = hybll.GetAllList().Tables[0];
            if (dt.Rows.Count > 0)
            {
                DTcms.Common.Excel.DataTable4Excel(dt, "会员信息表");
            }
        }

        #endregion
    }
}