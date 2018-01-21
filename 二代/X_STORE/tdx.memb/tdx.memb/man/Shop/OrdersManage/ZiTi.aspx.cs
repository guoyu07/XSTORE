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

namespace tdx.memb.man.Shop.OrdersManage
{
    public partial class ZiTi : System.Web.UI.Page
    {

        DTcms.BLL.WP_订单表 flbll = new DTcms.BLL.WP_订单表();

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

            string sql = " select top 10* from WP_订单表 a,WP_订单子表 zb,WP_地址表 b ,WP_订单支付表 c ";
            sql += "where a.openid in (select openid from WP_地址表) ";
            sql += "and a.订单编号 = b.订单编号 and a.订单编号 =c.订单编号 ";
            sql += "and 地址ID=0 and zb.商品编号 in(select 编号 from dbo.WP_商品表  " + _where + "    ) ";
            sql += "and a.id not in (select top (10*" + page + ")  a.id  from WP_订单表 a,WP_订单子表 zb,WP_地址表 b ,WP_订单支付表 c ";
            sql += " where a.openid in (select openid from WP_地址表) ";
            sql += " and a.订单编号 = b.订单编号 and a.订单编号 =c.订单编号  and 地址ID=0 ";
            sql += " and zb.商品编号 in(select 编号 from dbo.WP_商品表  " + _where + "    ) order by a.id desc)  order by a.id desc";






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
                    DataTable dtdt = dtbll.GetList(0," id=" + dtid,"id").Tables[0];
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
                //Response.Write("<script>alert('网络链接超时，请重新登录！')</script>");
                //Response.Write("<script>parent.location.href='http://sgapp.creatrue.net/aspx/man/login.aspx'</Script>");

            }
        }

        private void goods(string where)
        {




            string sql = "select  count(*)  from WP_订单表 a,WP_订单子表 zb,WP_地址表 b ,WP_订单支付表 c";
            sql += " where a.openid in (select openid from WP_地址表)";
            sql += " and a.订单编号 = b.订单编号";
            sql += " and a.订单编号 =c.订单编号 ";
            sql += " and 地址ID=0 and zb.商品编号 in(select 编号 from dbo.WP_商品表 " + where + "  ) ";


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
                //   Response.Write(ex);
                Response.Write("<script>parent.location.href='http://sgapp.creatrue.net/aspx/man/login.aspx'</Script>");
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



        #region 6.0 生成Excel表格 + void btn_baobiao_Click(object sender, EventArgs e)

        /// <summary>
        /// 生成Excel表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btn_baobiao_Click(object sender, EventArgs e)
        //{

        //    DTcms.BLL.manager dtbll = new DTcms.BLL.manager();

        //    int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ToString()) ? "-1" : Session["dtid"].ToString());

        //    if (dtid > 0)
        //    {
        //        DataTable dtdt = dtbll.GetList(" id=" + dtid).Tables[0];
        //        if (dtdt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dtdt.Rows.Count; i++)
        //            {
        //                if (dtdt.Rows[i]["user_name"].ToString() != "admin")
        //                {
        //                    string sql = "select * from WP_订单表 a,WP_地址表 b ,WP_订单支付表 c";
        //                    sql += " where a.openid in (select openid from WP_地址表)";
        //                    sql += " and a.订单编号 = b.订单编号";
        //                    sql += " and a.订单编号 =c.订单编号 ";
        //                    sql += " and 地址ID=0 and 商品编号 in(select 编号 from dbo.WP_商品表  where 用户ID=" + dtdt.Rows[i]["id"].ToString() + ")  ";


        //                    //string sql = "select * from (  select d.id as id, 商品编号,d.订单编号,d.openID  ,价格,数量,金额,下单时间,推荐人openID,推荐人订单号  ";
        //                    //sql += ", 省,市,区,商圈,详细地址,手机号,收货人,备注, 支付方式,支付金额, 支付时间  ";
        //                    //sql += "from dbo.WP_订单表 as d left join ";
        //                    //sql += "dbo.WP_订单地址表 as dd on d.订单编号=dd.订单编号 left join ";
        //                    //sql += "dbo.WP_订单支付表 as dz   on dd.订单编号=dz.订单编号 ";
        //                    //sql += "where 商品编号 in(select 编号 from dbo.WP_商品表  where 用户ID=" + dtdt.Rows[i]["id"].ToString() + ")) as aa ";

        //                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        DTcms.Common.Excel.DataTable4Excel(dt, "订单Excel表");
        //                    }

        //                }
        //                else
        //                {
        //                    //string sql = "select * from (  select d.id as id, 商品编号,d.订单编号,d.openID  ,价格,数量,金额,下单时间,推荐人openID,推荐人订单号  ";
        //                    //sql += ", 省,市,区,商圈,详细地址,手机号,收货人,备注, 支付方式,支付金额, 支付时间  ";
        //                    //sql += "from dbo.WP_订单表 as d left join ";
        //                    //sql += "dbo.WP_订单地址表 as dd on d.订单编号=dd.订单编号 left join ";
        //                    //sql += "dbo.WP_订单支付表 as dz   on dd.订单编号=dz.订单编号 ";
        //                    //sql += "where 商品编号 in(select 编号 from dbo.WP_商品表 )) as aa ";

        //                    string sql = "select * from WP_订单表 a,WP_地址表 b ,WP_订单支付表 c";
        //                    sql += " where a.openid in (select openid from WP_地址表)";
        //                    sql += " and a.订单编号 = b.订单编号";
        //                    sql += " and a.订单编号 =c.订单编号 ";
        //                    sql += " and 地址ID=0 and 商品编号 in(select 编号 from dbo.WP_商品表  ) ";
        //                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        DTcms.Common.Excel.DataTable4Excel(dt, "订单Excel表");
        //                    }
        //                }

        //            }
        //        }
        //    }


        //}
        #endregion

        #region 7.0  2015.6.29 搜索
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            if (Jxl.Value.Trim() != "" && Jx2.Value.Trim() != "")
            {
                sousuo(" and    a.下单时间   between  '" + Jxl.Value + "' and  '" + Jx2.Value + "'");
            }
            if (txt_bianhao.Text.Trim() != "")
            {
                sousuo(" and  a.订单编号 like '%" + txt_bianhao.Text + "%' ");
            }


        }

        public void sousuo(string where)
        {
            string sql = "select * from WP_订单表 a,WP_地址表 b ,WP_订单支付表 c";
            sql += " where a.openid in (select openid from WP_地址表)";
            sql += " and a.订单编号 = b.订单编号";
            sql += " and a.订单编号 =c.订单编号 ";
            sql += " and 地址ID=0 and 商品编号 in(select 编号 from dbo.WP_商品表  ) " + where;


            //string sql = "select * from (  select d.id as id, 商品编号,d.订单编号,d.openID  ,价格,数量,金额,下单时间,推荐人openID,推荐人订单号  ";
            //sql += ", 省,市,区,商圈,详细地址,手机号,收货人,备注, 支付方式,支付金额, 支付时间  ";
            //sql += "from dbo.WP_订单表 as d left join ";
            //sql += "dbo.WP_订单地址表 as dd on d.订单编号=dd.订单编号 left join ";
            //sql += "dbo.WP_订单支付表 as dz   on dd.订单编号=dz.订单编号 ";
            //sql += "where 商品编号 in(select 编号 from dbo.WP_商品表 )) as aa " + where;

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Rp_UserInfo.DataSource = dt.DefaultView;
                Rp_UserInfo.DataBind();
                lt_pagearrow.Text = "";
            }
        }

        #endregion
        #region 8.0 前台获取商品名称  2015.6.29
        /// <summary>
        /// 前台获取商品名称
        /// </summary>
        /// <param name="bianhao"></param>
        /// <returns></returns>
        public string getpinming(string bianhao)
        {
            string sql = "select * from dbo.WP_商品表 where 编号='" + bianhao + "'";
            string s = String.Empty;
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                s = dt.Rows[0]["品名"].ToString();
            }
            return s;
        }
        #endregion

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

