using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.DBUtility;
using DTcms.Model;
using tdx.database;

namespace tdx.memb.man.tuan.GoodsManage
{
    public partial class GoodsSales : System.Web.UI.Page
    {

        DTcms.BLL.TM_商品表 spbll = new DTcms.BLL.TM_商品表();
        protected internal siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        public static int td;
        public static string where1 = "  and 1=1  ";
        //and 下单时间 between '2015-12-19 15:09:08.000' and  '2015-12-19 15:09:08.000'
        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string spbh = string.IsNullOrEmpty(Request["spbh"]) ? "0" : Request["spbh"];

                if (spbh == "0")
                {
                    goodsinfoList();
                }
                else
                {
                    getlist(spbh);
                }
            }

        }

        /// <summary>
        /// 某个人的订单  2015.7.12
        /// </summary>
        /// <param name="opid"></param>
        private void getlist(string spbh)
        {
            string sql = "select  *  from ( select isnull(x.销量,0) as 销量,  ";
            sql += "sp.id as 商品id,用户ID,编号,编号New,限购数量,分销率,isTuan,类别号,ca.c_name,品名,规格,单位,重量,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮";
            sql += " from  dbo.TM_商品表 as sp  ";
            sql += " left join WP_category ca on sp.类别号=ca.c_no  left join (select b.商品id,sum(b.数量) as 销量 from [dbo].[TM_订单表] a left join [TM_订单子表] b on a.订单编号=b.订单编号 where a.state in ('未支付','已支付','已发货','已完成') " + where1 + " group by b.商品id) x on x.商品id=sp.id  ) ";
            sql += " as aa  where aa.IsShow=1 and aa.编号 ='" + spbh + "' order by  销量 desc";

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

            string sql = "  select top 10*  from ( select isnull(x.销量,0) as 销量,   ";
            sql += "  sp.id as 商品id,用户ID,编号,编号new,限购数量,isTuan,分销率,类别号,ca.c_name,品名,规格,单位,重量,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮    ";
            sql += "   from  dbo.TM_商品表 as sp   ";
            sql += "    left join WP_category ca on sp.类别号=ca.c_no  left join (select b.商品id,sum(b.数量) as 销量 from [dbo].[TM_订单表] a left join [TM_订单子表] b on a.订单编号=b.订单编号 where  a.state in ('未支付','已支付','已发货','已完成') " + where1 + " group by b.商品id) x on x.商品id=sp.id  ) as aa  where aa.IsShow=1 and aa.商品id not in (select top (10*" + page + ") aa.商品id  from ( select isnull(x.销量,0) as 销量,    ";
            sql += "  sp.id as 商品id,用户ID,编号,编号new,限购数量,isTuan,分销率,类别号,ca.c_name,品名,规格,单位,重量,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架     ";
            sql += "   from  dbo.TM_商品表 as sp       ";
            sql += "   left join WP_category ca on sp.类别号=ca.c_no  left join (select b.商品id,sum(b.数量) as 销量 from [dbo].[TM_订单表] a left join [TM_订单子表] b on a.订单编号=b.订单编号 where  a.state in ('未支付','已支付','已发货','已完成') " + where1 + " group by b.商品id) x on x.商品id=sp.id )  as aa  where  aa.IsShow=1 and  " + _where + "";
            sql += "  order by 销量 desc) and  " + _where + " ";
            sql += "  order by 销量 desc  ";



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
                goods(" 1=1 ");
                goodstype();
            }
            catch (Exception)
            {

                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();

            }
        }


        private void goodstype()
        {
            string sql = " select c_id,c_no as 类别编号,c_name as 类别名 from dbo.WP_category order by c_id asc";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["类别名"] = "所有分类";
            row["类别编号"] = "-1";
            dt.Rows.InsertAt(row, 0);
            if (dt.Rows.Count > 0)
            {

                drp_photo.DataSource = dt.DefaultView;
                drp_photo.DataTextField = "类别名";
                drp_photo.DataValueField = "类别编号";

                drp_photo.DataBind();

            }

        }

        private void goods(string where)
        {
            string sql = "select count(*) from ( select isnull(x.销量,0) as 销量,  ";
            sql += "sp.id as 商品id,用户ID,编号,编号new,限购数量,分销率,类别号,isTuan,ca.c_name,品名,规格,单位,重量,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮 ";
            sql += " from  dbo.TM_商品表 as sp  ";
            sql +=
                " left join WP_category ca on sp.类别号=ca.c_no  left join (select b.商品id,sum(b.数量) as 销量 from [dbo].[TM_订单表] a left join [TM_订单子表] b on a.订单编号=b.订单编号 where a.state in ('未支付','已支付','已发货','已完成') " +
                where1 + " ";
            sql += "group by b.商品id) x on x.商品id=sp.id )  as aa  where aa.IsShow=1 and " + where + "  ";

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
                    DTcms.BLL.TM_商品图片表 sptpbll = new DTcms.BLL.TM_商品图片表();

                    DTcms.BLL.TM_商品详情表 spxqbll = new DTcms.BLL.TM_商品详情表();

                    DTcms.BLL.TM_商品表 spbll = new DTcms.BLL.TM_商品表();

                    DataTable dt = spbll.GetList(" id=" + id).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        ///删除图片
                        DataTable dttp = sptpbll.GetList(" 商品编号='" + dt.Rows[0]["编号"].ToString() + "' ").Tables[0];
                        if (dttp.Rows.Count > 0)
                        {
                            for (int j = 0; j < dttp.Rows.Count; j++)
                            {
                                bool r = sptpbll.Delete(int.Parse(dttp.Rows[j]["id"].ToString()));
                            }
                        }

                        ///删除详情
                        DataTable dtxq = spxqbll.GetList(" 商品编号='" + dt.Rows[0]["编号"].ToString() + "' ").Tables[0];

                        if (dtxq.Rows.Count > 0)
                        {
                            bool re = spxqbll.Delete(int.Parse(dtxq.Rows[0]["id"].ToString()));
                        }
                    }
                    ///删除商品
                    bool res = spbll.Delete(id);
                    if (res)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
        }
        #endregion


        #region 6.0 生成Excel表格 + void btn_baobiao_Click(object sender, EventArgs e)

        ///// <summary>
        ///// 生成Excel表格
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btn_baobiao_Click(object sender, EventArgs e)
        //{
        //    //string sql = "select * from ( select yh.id as yhid,用户名,密码,openID,手机号,微信昵称,微信头像, ";
        //    //sql += "sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,";
        //    //sql += "spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍,";
        //    //sql += "sptp.id as 商品图片id ,sptp.商品编号  as tp商品编号,标题,图片路径  ";
        //    //sql += "from dbo.TM_用户表 as yh inner join dbo.TM_商品表 as sp on yh.id=sp.用户id   left join dbo.TM_商品详情表  as spxq  ";
        //    //sql += " on sp.编号=spxq.商品编号 left join dbo.TM_商品图片表  as sptp on  spxq.商品编号=sptp.商品编号)  as aa  ";

        //    //DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        //    DataTable dt = spbll.GetAllList().Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        DTcms.Common.Excel.DataTable4Excel(dt, "商品信息表");
        //    }
        //} 
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
        /// <summary>
        /// 搜索  2015.7.12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            string query = "";
            if (Jxl.Value.Trim() != "" && Jx2.Value.Trim() != "")
            {
                query = " and 1=1 ";

                where1 = " and 下单时间 between " + Jxl.Value.Trim().ToString() + " and  " + Jx2.Value.Trim().ToString() +
                         " ";

            }


            if (query == "")
            {
                goodsinfoList();
            }
            else
            {
                sousuo(query);
            }

        }

        private void sousuo(string where)
        {
            string sql = "select *  from ( select isnull(x.销量,0) as 销量,  ";
            sql += "sp.id as 商品id,用户ID,编号,编号new,限购数量,isTuan,分销率,类别号,ca.c_name,品名,规格,单位,重量,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮";
            sql += " from  dbo.TM_商品表 as sp  ";
            sql += " left join WP_category ca on sp.类别号=ca.c_no  left join (select b.商品id,sum(b.数量) as 销量 from [dbo].[TM_订单表] a left join [TM_订单子表] b on a.订单编号=b.订单编号 where  a.state in ('未支付','已支付','已发货','已完成') " + where1 + " group by b.商品id) x on x.商品id=sp.id )  as aa  where aa.IsShow=1 and 1=1  " + where + " order by 销量 desc ";



            DataTable dt = comfun.GetDataTableBySQL(sql);


            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();
            lt_pagearrow.Text = "";



        }
        #endregion

        protected void drp_photo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type_id = this.drp_photo.Text;

            if (type_id == "-1")
            {
                sousuo(" and 1=1 ");
            }
            else
            {
                string c_nos = DbHelperSQL.Query("exec [proceGetChildCno] '" + type_id + "'").Tables[0].Rows[0][0].ToString();

                sousuo(" and aa.类别号 in (" + c_nos + ") ");
            }
        }

        //导出数据
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string query = "";
            string where2 = " ";
            if (Jxl.Value.Trim() != "" && Jx2.Value.Trim() != "")
            {
                query = " and 1=1 ";

                where2 = " and 下单时间 between " + Jxl.Value.Trim().ToString() + " and  " + Jx2.Value.Trim().ToString() +
                         " ";
            }
            else
            {
                query = " and 1=1 ";
                where2 = " and 1=1 ";

            }
            string sql = "select 编号new as 商品编号,品名,c_name as 类别,单位,规格,重量,市场价 as 价格,本站价 as 团购价,库存数量,限购数量,上架时间,下架时间,分销率,销量   from ( select isnull(x.销量,0) as 销量,  ";
            sql += "sp.id as 商品id,用户ID,编号,编号new,限购数量,isTuan,分销率,类别号,ca.c_name,品名,规格,单位,重量,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮";
            sql += " from  dbo.TM_商品表 as sp   ";
            sql += " left join WP_category ca on sp.类别号=ca.c_no  left join (select b.商品id,sum(b.数量) as 销量 from [dbo].[TM_订单表] a left join [TM_订单子表] b on a.订单编号=b.订单编号 where  a.state in ('未支付','已支付','已发货','已完成') " + where2 + " group by b.商品id) x on x.商品id=sp.id )  as aa  where  1=1 and aa.IsShow=1   order by 销量 desc ";

            DataTable dtdata = comfun.GetDataTableBySQL(sql);

            if (dtdata.Rows.Count > 0)
            {
                DTcms.Common.Excel.DataTable4Excel(dtdata, "销量排行Excel表");
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }






    }
}