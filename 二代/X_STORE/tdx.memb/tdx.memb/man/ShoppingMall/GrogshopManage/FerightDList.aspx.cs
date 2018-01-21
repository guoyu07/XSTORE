using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using DTcms.DBUtility;
using DTcms.Common;
using DTcms.Model;
using System.Text;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class FerightDList : System.Web.UI.Page
    {
        DTcms.BLL.WP_商品表 spbll = new DTcms.BLL.WP_商品表();
        protected internal siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        public static int td;

        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                sousuo();
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

            for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    string del = "delete  from  WP_FreightMainD where   id=" + id;
                    comfun.DelbySQL(del);
                    //MessageBox.Show(this, "删除成功！");
                }
            }
            int myid = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='FerightDList.aspx?id=" + myid + "'", true);
        }
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

        #region 搜索  2015.7.12
        private void sousuo()
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n select  id,name,shouzhong,shoujia,xujia,xuzhong,areas,convert(varchar(50),createtime,23) as createtime ");
            sb.Append("\r\n ,(select name from  WP_FreightMain where id=WP_FreightMainD.mainid)  as mainname  from WP_FreightMainD where mainid= " + id);
            DataTable dt = comfun.GetDataTableBySQL(sb.ToString());
            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();
        }
        #endregion
    }
}




