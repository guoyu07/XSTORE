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

namespace tdx.memb.man.Shop.OrdersManage
{
    public partial class OrdersList : System.Web.UI.Page
    {
        DTcms.BLL.WP_订单表 flbll = new DTcms.BLL.WP_订单表();
        protected internal siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ///2015.7.12 添加
                string opid = string.IsNullOrEmpty(Request["openid"]) ? "0" : Request["openid"];
                string order = string.IsNullOrEmpty(Request["order"]) ? "0" : Request["order"];

                if (opid == "0" && order == "0")
                {
                    goodsinfoList();
                }
                else if (order != "0")
                {
                    getlistorder(order);

                }
                else if (opid != "0")
                {
                    getlist(opid);
                }

            }
        }
        /// <summary>
        /// 某个人的订单  2015.7.12
        /// </summary>
        /// <param name="opid"></param>
        private void getlistorder(string order)
        {
            string sql = "select  *  from (   select wd.订单编号,wd.总金额,wd.下单时间,wd.openid,wd.is_del, d.id as id, 商品编号, wd.state, 价格,数量,  推荐人openID,推荐人订单号  ";
            sql += " , dddz.省,dddz.市,dddz.区,dddz.商圈,dddz.详细地址,dddz.手机号,dddz.收货人,dddz.备注, 支付方式,支付金额, 支付时间   ";
            sql += " from  dbo.WP_订单表  as wd left join  dbo.WP_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            sql += "  dbo.WP_订单支付表 as dd on d.订单编号=dd.订单编号 left join  ";
            sql += "   dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join  ";
            sql += "  dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  ";
            sql += "   where 商品编号 in(select 编号 from dbo.WP_商品表  )) as aa  where aa.订单编号='" + order + "' ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                Rp_UserInfo.DataSource = dt.DefaultView;
                Rp_UserInfo.DataBind();
                lt_pagearrow.Text = "";
            }
        }

        /// <summary>
        /// 某个人的订单  2015.7.12
        /// </summary>
        /// <param name="opid"></param>
        private void getlist(string opid)
        {
            string sql = "select  *  from (   select wd.订单编号,wd.总金额,wd.下单时间,wd.state,wd.is_del,wd.openid, d.id as id, 商品编号,  价格,数量,  推荐人openID,推荐人订单号  ";
            sql += " , dddz.省,dddz.市,dddz.区,dddz.商圈,dddz.详细地址,dddz.手机号,dddz.收货人,dddz.备注, 支付方式,支付金额, 支付时间   ";
            sql += " from  dbo.WP_订单表  as wd left join  dbo.WP_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            sql += "  dbo.WP_订单支付表 as dd on d.订单编号=dd.订单编号 left join  ";
            sql += "   dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join  ";
            sql += "  dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  ";
            sql += "   where 商品编号 in(select 编号 from dbo.WP_商品表  )) as aa  where aa.openID='" + opid + "' ";

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

            string sql = "  select top 10*  from (  select wd.订单编号,wd.总金额,wd.state,wd.is_del,wd.下单时间,wd.openid, d.id as id, 商品编号,  价格,数量,  推荐人openID,推荐人订单号     ";
            sql += "    , 省,市,区,商圈,详细地址,手机号,收货人, 支付方式,支付金额, 支付时间,wd.备注   ";
            sql += " from  dbo.WP_订单表  as wd left join  dbo.WP_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            sql += "   dbo.WP_订单支付表 as dd on d.订单编号=dd.订单编号 left join    ";
            sql += "   dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join   ";
            sql += " dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  ";
            sql += "  where 商品编号 in(select 编号 from dbo.WP_商品表 " + _where + " )) as aa where id not in (select top (10*" + page + ") id  from (   select wd.订单编号,wd.总金额,wd.下单时间,wd.is_del,wd.openid, d.id as id, 商品编号,  价格,数量,  推荐人openID,推荐人订单号      ";
            sql += "  , 省,市,区,商圈,详细地址,手机号,收货人, 支付方式,支付金额, 支付时间,wd.备注    ";
            sql += " from  dbo.WP_订单表  as wd left join  dbo.WP_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            sql += "   dbo.WP_订单支付表 as dd on d.订单编号=dd.订单编号 left join    ";
            sql += "   dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join   ";
            sql += " dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id";
            sql += "   where 商品编号 in(select 编号 from dbo.WP_商品表 " + _where + "  )) as aa  order by id desc)  order by id desc";



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
                goods("");
            }
            catch (Exception)
            {
                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();

            }
        }

        private void goods(string where)
        {


            //string sql = "select count(*) from (  select d.id as id, 商品编号,d.订单编号,d.openID  ,价格,数量,金额,下单时间,推荐人openID,推荐人订单号  ";
            //sql += ", 省,市,区,商圈,详细地址,手机号,收货人,备注, 支付方式,支付金额, 支付时间  ";
            //sql += "from dbo.WP_订单表 as d left join ";
            //sql += "dbo.WP_订单地址表 as dd on d.订单编号=dd.订单编号 left join ";
            //sql += "dbo.WP_订单支付表 as dz   on dd.订单编号=dz.订单编号 ";
            //sql += "where 商品编号 in(select 编号 from dbo.WP_商品表 " + where + " )) as aa  ";

            string sql = "select  count(*)  from (  select wd.订单编号,wd.总金额,wd.下单时间,wd.is_del,wd.state,wd.openid, d.id as id, 商品编号,  价格,数量,  推荐人openID,推荐人订单号    ";
            sql += " , dddz.省,dddz.市,dddz.区,dddz.商圈,dddz.详细地址,dddz.手机号,dddz.收货人,wd.备注, 支付方式,支付金额, 支付时间   ";
            sql += " from  dbo.WP_订单表  as wd left join  dbo.WP_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            sql += " dbo.WP_订单支付表 as dd on d.订单编号=dd.订单编号 left join  ";
            sql += "  dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join  ";
            sql += " dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  ";
            sql += " where 商品编号 in(select 编号 from dbo.WP_商品表 " + where + "  )) as aa   ";




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
                    int count = comfun.DelbySQL("delete from wp_订单子表 where id=" + id);

                    // bool res = flbll.Delete(id);
                    if (count > 0)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='OrdersList.aspx'", true);
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

        //                    string sql = "select * from (  select d.id as id, 商品编号,d.订单编号,d.openID  ,价格,数量,金额,下单时间,推荐人openID,推荐人订单号  ";
        //                    sql += ", 省,市,区,商圈,详细地址,手机号,收货人,d.备注, 支付方式,支付金额, 支付时间  ";
        //                    sql += "from dbo.WP_订单表 as d left join ";
        //                    sql += "dbo.WP_订单地址表 as dd on d.订单编号=dd.订单编号 left join ";
        //                    sql += "dbo.WP_订单支付表 as dz   on dd.订单编号=dz.订单编号 ";
        //                    sql += "where 商品编号 in(select 编号 from dbo.WP_商品表  where 用户ID=" + dtdt.Rows[i]["id"].ToString() + ")) as aa ";

        //                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        DTcms.Common.Excel.DataTable4Excel(dt, "订单Excel表");
        //                    }

        //                }
        //                else
        //                {
        //                    string sql = "select * from (  select d.id as id, 商品编号,d.订单编号,d.openID  ,价格,数量,金额,下单时间,推荐人openID,推荐人订单号  ";
        //                    sql += ", 省,市,区,商圈,详细地址,手机号,收货人,d.备注, 支付方式,支付金额, 支付时间  ";
        //                    sql += "from dbo.WP_订单表 as d left join ";
        //                    sql += "dbo.WP_订单地址表 as dd on d.订单编号=dd.订单编号 left join ";
        //                    sql += "dbo.WP_订单支付表 as dz   on dd.订单编号=dz.订单编号 ";
        //                    sql += "where 商品编号 in(select 编号 from dbo.WP_商品表 )) as aa ";


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
            string query = "";
            if (Jxl.Value.Trim() != "" && Jx2.Value.Trim() != "")
            {
                //sousuo(" where    aa.下单时间   between  '" + Jxl.Value + "' and  '" + Jx2.Value + "'");
                query += " and  CONVERT(varchar(100), aa.下单时间, 23)   between  '" + Jxl.Value + "' and  '" + Jx2.Value + "'";
            }
            if (txt_bianhao.Text.Trim() != "")
            {
                //sousuo(" where  aa.订单编号 like '%" + txt_bianhao.Text + "%' ");
                query += " and aa.订单编号 like '%" + txt_bianhao.Text + "%' ";
            }
            if (txt_ren.Text.Trim() != "")
            {
                //sousuo(" where  aa.收货人 like '%" + txt_ren.Text + "%'   ");
                query += " and aa.收货人 like '%" + txt_ren.Text + "%'  ";
            }
            if (txt_Telephone.Text.Trim() != "")
            {
                //sousuo(" where    aa.手机号 like '%" + txt_Telephone.Text + "%' ");
                query += " and aa.手机号 like '%" + txt_Telephone.Text + "%' ";
            }
            sousuo(query);
        }

        public void sousuo(string where)
        {
            //string sql = "select * from (  select d.id as id, 商品编号,d.订单编号,d.openID  ,价格,数量,金额,下单时间,推荐人openID,推荐人订单号  ";
            //sql += ", 省,市,区,商圈,详细地址,手机号,收货人,备注, 支付方式,支付金额, 支付时间  ";
            //sql += "from dbo.WP_订单表 as d left join ";
            //sql += "dbo.WP_订单地址表 as dd on d.订单编号=dd.订单编号 left join ";
            //sql += "dbo.WP_订单支付表 as dz   on dd.订单编号=dz.订单编号 ";
            //sql += "where 商品编号 in(select 编号 from dbo.WP_商品表 )) as aa " + where;

            string sql = "select  *  from (  select wd.订单编号,wd.总金额,wd.下单时间,wd.is_del,wd.state,wd.openid, d.id as id, 商品编号,  价格,数量,  推荐人openID,推荐人订单号    ";
            sql += " , dddz.省,dddz.市,dddz.区,dddz.商圈,dddz.详细地址,dddz.手机号 as phone,dddz.收货人,wd.备注, 支付方式,支付金额,支付时间,A.手机号  ";
            sql += " from  dbo.WP_订单表  as wd left join  dbo.WP_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            sql += " dbo.WP_订单支付表 as dd on d.订单编号=dd.订单编号 left join  ";
            sql += "  dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join  ";
            sql += " dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  left join ";
            sql += " dbo.WP_会员表 as A on A.openid=wd.openid ";
            sql += " where 商品编号 in(select 编号 from dbo.WP_商品表 )) as aa  where 1=1 " + where + " order by 下单时间 desc";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();
            lt_pagearrow.Text = "";
            //}
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
        /// 获得用户名
        /// </summary>
        /// <returns></returns>
        public string getuser(string openid)
        {
            string sql = "select * from  dbo.WP_会员表 where openid='" + openid + "' ";

            DataTable dt = comfun.GetDataTableBySQL(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["手机号"].ToString();
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

        public string getispay(string openid, string order_no)
        {
            List<DTcms.Model.WP_订单支付表> listpay = new DTcms.BLL.WP_订单支付表().GetModelList(" 订单编号='" + order_no + "' and openid='" + openid + "'");
            string ispay = "未支付";
            if (listpay != null && listpay.Count > 0)
            {
                ispay = "已支付";
            }
            return ispay;
        }

        public string getstate(string is_del,string state)
        {
            if (is_del == "1")
            {
                return "用户已删除";
            }
            return state;
        }
    }
}

