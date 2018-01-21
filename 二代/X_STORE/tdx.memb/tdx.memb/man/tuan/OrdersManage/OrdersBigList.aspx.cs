using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.Common;
using System.Data;
using DTcms.DBUtility;
using Creatrue.Common.Msgbox;
using tdx.database;
using DTcms.Model;

namespace tdx.memb.man.Tuan.OrdersManage
{
    public partial class OrdersBigList : System.Web.UI.Page
    {
        DTcms.BLL.TM_订单表 flbll = new DTcms.BLL.TM_订单表();
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
            string sql = "select  *  from (   select wd.订单编号,wd.总金额,wd.下单时间,wd.is_del,wd.openid, d.id as id, 商品编号, wd.state, 价格,数量,  推荐人openID,推荐人订单号  ";
            sql += " , dddz.省,dddz.市,dddz.区,dddz.商圈,dddz.详细地址,dddz.手机号,dddz.收货人,dddz.备注, 支付方式,支付金额, 支付时间   ";
            sql += " from  dbo.TM_订单表  as wd left join  dbo.TM_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            sql += "  dbo.TM_订单支付表 as dd on d.订单编号=dd.订单编号 left join  ";
            sql += "   dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join  ";
            sql += "  dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  ";
            sql += "   where 商品编号 in(select 编号 from dbo.TM_商品表  )) as aa  where aa.订单编号='" + order + "' ";

            DataTable dt = comfun.GetDataTableBySQL(sql);


            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();
            lt_pagearrow.Text = "";

        }

        /// <summary>
        /// 某个人的订单  2015.7.12
        /// </summary>
        /// <param name="opid"></param>
        private void getlist(string opid)
        {
            string sql = "select  *  from (   select wd.订单编号,wd.总金额,wd.下单时间,wd.is_del,wd.state,wd.openid, d.id as id, 商品编号,  价格,数量,  推荐人openID,推荐人订单号  ";
            sql += " , dddz.省,dddz.市,dddz.区,dddz.商圈,dddz.详细地址,dddz.手机号,dddz.收货人,dddz.备注, 支付方式,支付金额, 支付时间   ";
            sql += " from  dbo.TM_订单表  as wd left join  dbo.TM_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            sql += "  dbo.TM_订单支付表 as dd on d.订单编号=dd.订单编号 left join  ";
            sql += "   dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join  ";
            sql += "  dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  ";
            sql += "   where 商品编号 in(select 编号 from dbo.TM_商品表  )) as aa  where aa.openID='" + opid + "' ";

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

            string sql = "  select top 10*  from (  select wd.id,wd.订单编号,wd.总金额,wd.state,wd.is_del,wd.下单时间,wd.openid ";
            sql += "    , 省,市,区,商圈,详细地址,手机号,收货人, 支付方式,支付金额, 支付时间,wd.备注   ";
            sql += " from  dbo.TM_订单表  as wd  left join    ";
            sql += "   dbo.TM_订单支付表 as dd on wd.订单编号=dd.订单编号 left join    ";
            sql += "   dbo.WP_地址表 as dz   on wd.订单编号=dz.订单编号 left join   ";
            sql += " dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  ";
            sql += "  where 1=1 " + _where + ") as aa where id not in (select top (10*" + page + ") id  from (   select wd.id,wd.订单编号,wd.总金额,wd.下单时间,wd.is_del,wd.openid  ";
            sql += "  , 省,市,区,商圈,详细地址,手机号,收货人, 支付方式,支付金额, 支付时间,wd.备注    ";
            sql += " from  dbo.TM_订单表  as wd  left join    ";
            sql += "   dbo.TM_订单支付表 as dd on wd.订单编号=dd.订单编号 left join    ";
            sql += "   dbo.WP_地址表 as dz   on wd.订单编号=dz.订单编号 left join   ";
            sql += " dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id";
            sql += "   where 1=1 " + _where + ") as aa  order by id desc)  order by id desc";



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
            //string sql = "select  count(*)  from (  select wd.订单编号,wd.总金额,wd.下单时间,wd.state,wd.openid, d.id as id, 商品编号,  价格,数量,  推荐人openID,推荐人订单号    ";
            //sql += " , dddz.省,dddz.市,dddz.区,dddz.商圈,dddz.详细地址,dddz.手机号,dddz.收货人,wd.备注, 支付方式,支付金额, 支付时间   ";
            //sql += " from  dbo.TM_订单表  as wd left join  dbo.TM_订单子表 as d on wd.订单编号=d.订单编号 left join    ";
            //sql += " dbo.TM_订单支付表 as dd on d.订单编号=dd.订单编号 left join  ";
            //sql += "  dbo.WP_地址表 as dz   on d.订单编号=dz.订单编号 left join  ";
            //sql += " dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  ";
            //sql += " where 商品编号 in(select 编号 from dbo.TM_商品表 " + where + "  )) as aa   ";

            string sql = "select count(*) from TM_订单表";
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
                string no = ((HiddenField)Rp_UserInfo.Items[i].FindControl("hidno")).Value;
                if (cb.Checked)
                {
                    int count1 = comfun.DelbySQL("delete from TM_订单表 where id=" + id);
                    int count2 = comfun.DelbySQL("delete from TM_订单子表 where 订单编号='" + no + "'");

                }
            }
            goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='OrdersBigList.aspx'", true);
        }
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
                query += " and  CONVERT(varchar(100), aa.下单时间, 23)   between  '" + Jxl.Value + "' and  '" + Jx2.Value + "'";
            }
            if (txt_bianhao.Text.Trim() != "")
            {
                query += " and aa.订单编号 like '%" + txt_bianhao.Text + "%' ";
            }
            if (txt_ren.Text.Trim() != "")
            {
                query += " and aa.收货人 like '%" + txt_ren.Text + "%'  ";
            }
            if (txt_Telephone.Text.Trim() != "")
            {
                query += " and aa.手机号 like '%" + txt_Telephone.Text + "%' ";
            }
            sousuo(query);
        }

        public void sousuo(string where)
        {


            string sql = "select  *  from (  select wd.id,wd.订单编号,wd.总金额,wd.下单时间,wd.is_del,wd.state,wd.openid    ";
            sql += " , dddz.省,dddz.市,dddz.区,dddz.商圈,dddz.详细地址,dddz.手机号 as phone,dddz.收货人,wd.备注, 支付方式,支付金额,支付时间,A.手机号  ";
            sql += " from  dbo.TM_订单表  as wd  left join    ";
            sql += " dbo.TM_订单支付表 as dd on wd.订单编号=dd.订单编号 left join  ";
            sql += "  dbo.WP_地址表 as dz   on wd.订单编号=dz.订单编号 left join  ";
            sql += " dbo.WP_订单地址表 as dddz  on  dddz.id=dz.地址id  left join ";
            sql += " dbo.WP_会员表 as A on A.openid=wd.openid ";
            sql += " where 1=1) as aa  where 1=1 " + where + " order by 下单时间 desc";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();
            lt_pagearrow.Text = "";

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


        //改变订单状态
        protected void lbtchange_state_Click(object sender, EventArgs e)
        {
            string state = this.ddlstate.Text;
            if (state == "0")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('请选择状态')", true);
                return;
            }
            else
            {
                bool flag = false;
                for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
                {
                    int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                    CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                    string no = ((HiddenField)Rp_UserInfo.Items[i].FindControl("hidno")).Value;
                    if (cb.Checked)
                    {
                        flag = true;
                        comfun.UpdateBySQL("update TM_订单表 set state='" + state + "' where id=" + id + " and 订单编号='" + no + "'");
                    }

                }
                if (!flag)
                {
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('没有选中任何订单')", true);
                    return;
                }
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='OrdersBigList.aspx'", true);
            }
        }

        public string getstate(string is_del, string state)
        {
            if (is_del == "1")
            {
                return "用户已删除";
            }
            return state;
        }

    }
}