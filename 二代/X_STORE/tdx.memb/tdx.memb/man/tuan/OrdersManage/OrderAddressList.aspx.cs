using Creatrue.Common.Msgbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using Creatrue.kernel;
using tdx.database;
using DTcms.Model;


namespace tdx.memb.man.Tuan.OrdersManage
{
    public partial class OrderAddressList : System.Web.UI.Page
    {
        DTcms.BLL.WP_订单地址表 flbll = new DTcms.BLL.WP_订单地址表();
        protected internal siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {///2015.7.12 添加
                string openid = string.IsNullOrEmpty(Request["openid"]) ? "0" : Request["openid"];



                if (openid == "0")
                {
                    infoList();
                }
                else
                {
                    getlist(openid);
                }
               
            }
        }

        private void getlist(string openid)
        {
            string sql = "select  *  from dbo.WP_订单地址表 where 订单编号='"+openid+"' and is_del=0";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                Rp_UserInfo.DataSource = dt.DefaultView;
                Rp_UserInfo.DataBind();
                lt_pagearrow.Text = "";
            } 
        }
        #region 读取分页数据2015.6.25
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        protected string ClassList(string _where, int page)
        {
            DataTable dt = comfun.GetDataTableBySQL("select top 10*  from dbo.WP_订单地址表  where is_del=0 and  id not in (select top (10*" + page + ") id  from  dbo.WP_订单地址表 where is_del=0 ) ");


            string str = "";

            if (dt.Rows.Count > 0)
            {


                Rp_UserInfo.DataSource = dt.DefaultView;
                Rp_UserInfo.DataBind();
            }
            return str;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private void infoList()
        {
           

                #region 分页2015.6.25
                try
                {
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);

                    lb_catelist.Text = ClassList(" 1=1 ", _page - 1);

                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from dbo.WP_订单地址表 where is_del=0 ").Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 10, Request.Form, Request.QueryString);


                }
                catch (Exception ex)
                {
                    Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                    Response.End();
                }
                #endregion

            
        }

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
            infoList();
        }

        /// <summary>
        /// 获取wx昵称 2015.7.12
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public string getnicheng(string openid)
        {
            string sql = "select * from  dbo.WP_会员表 where openid='" + openid + "' ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["wx昵称"].ToString();
            }
            return "";
        }
        /// <summary>
        /// 获取wx头像 2015.7.12
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public string gettouxiang(string openid)
        {
            string sql = "select * from  dbo.WP_会员表 where openid='" + openid + "' ";


            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["wx头像"].ToString();
            }
            return "";
        }
    }
}