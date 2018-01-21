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

namespace tdx.memb.man.Tuan.GoodsManage
{
    public partial class GoodsList : System.Web.UI.Page
    {

        DTcms.BLL.TM_商品表 spbll = new DTcms.BLL.TM_商品表();
        //protected internal DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        public static int td;
        public static string where1 = "  and 1=1  ";
        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string spbh = string.IsNullOrEmpty(Request["spbh"]) ? "0" : Request["spbh"];
                string types = string.IsNullOrEmpty(Request["types"]) ? "0" : Request["types"];//0-全部商品；1-出售中的商品；2-库存不足；3-仓库中的商品

                switch (Convert.ToInt32(types))
                {
                    case 0:
                        where1 = " and 1=1 ";
                        break;
                    case 1:
                        where1 = " and aa.是否上架=1 ";
                        break;
                    case 2:
                        where1 = " and aa.库存数量=0 ";
                        break;
                    case 3:
                        where1 = " and aa.是否上架=0 ";
                        break;
                }

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
            string sql = "select  *  from ( select  isnull((select  salenum from  [SaleCount] where   SaleCount.商品id=sp.id and  typename='TM'),0) as salenum, ";
            sql += "sp.id as 商品id,用户ID,编号,编号new,类别号,ca.c_name,品名,isTuan,规格,单位,重量,市场价,本站价,序号,分销率,三团价,九团价,上架时间,下架时间,录入时间,库存数量,限购数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮,";
            sql += "sp.regtime,(select top 1 图片路径 from TM_商品图片表 where sp.编号=商品编号 order by 序号 asc) as 图片路径  ";
            sql += "from   dbo.TM_商品表 as sp    ";
            sql += "  left join WP_category ca on sp.类别号=ca.c_no   )  as aa  where aa.IsShow=1 and aa.编号 ='" + spbh + "' '" + where1 + "' order by 序号 asc,regtime desc ";

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

            string sql = "  select top 10 *  from ( select  isnull((select  salenum from  [SaleCount] where   SaleCount.商品id=sp.id and  typename='TM'),0) as salenum,   ";
            sql += "  sp.id as 商品id,用户ID,编号,编号new,类别号,ca.c_name,isTuan,品名,规格,单位,重量,市场价,本站价,序号,分销率,三团价,九团价,上架时间,下架时间,录入时间,库存数量,限购数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮,    ";
            sql += "  sp.regtime,(select top 1 图片路径 from TM_商品图片表 where sp.编号=商品编号 order by 序号 asc) as 图片路径    ";
            sql += "   from  dbo.TM_商品表 as sp     ";
            //sql += "   on sp.编号=spxq.商品编号  ) as aa  where aa.yhid not in (select top (10*" + page + ") aa.yhid  from ( select yh.id as yhid,user_name,openid,telephone,    ";
            sql += "    left join WP_category ca on sp.类别号=ca.c_no      ) as aa  where aa.商品id not in (select top (10*" + (page - 1) + ")      ";
            sql += "  sp.id as 商品id      ";
            sql += "   from  dbo.TM_商品表 as sp     ";
            sql += "    left join WP_category ca on sp.类别号=ca.c_no    where  IsShow=1 and " + _where + " ";
            sql += " " + where1 + " order by 序号 asc, sp.regtime desc) and aa.IsShow=1 and  " + _where + " ";
            sql += " " + where1 + " order by 序号 asc, regtime desc  ";

            /*
             
               
             select  *   from   [SaleCount]
             
             */


            //StringBuilder sb = new StringBuilder();

            //sb.Append("\r\n select  *   from  (select ROW_NUMBER() over (order by  yhid ) as rownum,  *  from  GoodsInfo where 1=1)t ");
            //sb.Append("\r\n where rownum between " + (10 * (page) + 1) + " and  " + (10 * (page+1)) + "");

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

                //Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                //Response.End();

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
            //string sql = "select * from ( select yh.id as yhid,user_name,openid,telephone,  ";
            //sql += "sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,分销率,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,";
            //sql += "spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍,";
            //sql += "sptp.id as 商品图片id ,sptp.商品编号  as tp商品编号,标题,图片路径  ";
            //sql += "from dbo.dt_manager as yh left join dbo.TM_商品表 as sp on yh.id=sp.用户id   left join dbo.TM_商品详情表  as spxq  ";
            //sql += "on sp.编号=spxq.商品编号 left join dbo.TM_商品图片表  as sptp on  spxq.商品编号=sptp.商品编号)  as aa  "+where;

            string sql = "select count(*) from ( select   ";
            sql += "\r\n sp.id as 商品id,用户ID,编号,编号new,isTuan,类别号,ca.c_name,品名,规格,单位,重量,市场价,本站价,分销率,三团价,九团价,上架时间,下架时间";
            sql += "\r\n ,录入时间,库存数量,限购数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮,";
            sql += "\r\n sp.regtime,(select top 1 图片路径 from TM_商品图片表 where sp.编号=商品编号 order by 序号 asc) as 图片路径  ";
            //sql += "from dbo.dt_manager as yh left join dbo.TM_商品表 as sp on yh.id=sp.用户id   left join dbo.TM_商品详情表  as spxq  ";
            sql += "\r\n from  dbo.TM_商品表 as sp   ";
            sql += "\r\n  left join WP_category ca on sp.类别号=ca.c_no  )  as aa  where aa.IsShow=1 and " + where + "  ";
            sql += " " + where1 + " ";
            #region 分页2015.6.25
            try
            {
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);

                lb_catelist.Text = ClassList(where, _page);

                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 10, Request.Form, Request.QueryString);


            }
            catch (Exception ex)
            {

                //Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                //Response.End();
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

                    //DataTable dt = spbll.GetList(" id=" + id).Tables[0];

                    //if (dt.Rows.Count > 0)
                    //{
                    //    ///删除图片
                    //    DataTable dttp = sptpbll.GetList(" 商品编号='" + dt.Rows[0]["编号"].ToString() + "' ").Tables[0];
                    //    if (dttp.Rows.Count > 0)
                    //    {
                    //        for (int j = 0; j < dttp.Rows.Count; j++)
                    //        {
                    //            bool r = sptpbll.Delete(int.Parse(dttp.Rows[j]["id"].ToString()));
                    //        }
                    //    }

                    //    ///删除详情
                    //    DataTable dtxq = spxqbll.GetList(" 商品编号='" + dt.Rows[0]["编号"].ToString() + "' ").Tables[0];

                    //    if (dtxq.Rows.Count > 0)
                    //    {
                    //        bool re = spxqbll.Delete(int.Parse(dtxq.Rows[0]["id"].ToString()));
                    //    }
                    //}
                    ///删除商品
                    //bool res = spbll.Delete(id);
                     DbHelperSQL.GetSingle(" Update TM_商品表 set IsShow=0 where id=" + id + " ");

                    MessageBox.Show(this, "删除成功！");
                }
            }
            goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
        }
        #endregion

        #region 5.0分页
        ///// <summary>
        ///// 分页控件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{
        //    goodsinfoList();
        //}
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
        //    //sql += "sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,分销率,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,";
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

                //Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                //Response.End();


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
            if (txt_pinming.Text.Trim() != "")
            {
                query += " and (品名 like '%" + txt_pinming.Text.Trim() + "%' or 编号new like '%" + txt_pinming.Text.Trim() + "%')  ";
                //sousuo( "品名 like '%"+ txt_pinming.Text.Trim()+"%'");
            }
            //if (txt_username.Text.Trim() != "")
            //{
            //    query += " and user_name like '%" + txt_username.Text.Trim() + "%'";
            //    sousuo(" user_name like '%" + txt_username.Text.Trim() + "%'");
            //}
            //if (txt_telephone.Text.Trim() != "")
            //{
            //    query += " and telephone like '%" + txt_telephone.Text.Trim() + "%'";
            //    //sousuo("telephone like '%"+txt_telephone.Text.Trim()+"%'");
            //}


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
            string sql = "select *  from ( select  isnull((select  salenum from  [SaleCount] where   SaleCount.商品id=sp.id and  typename='TM' ),0) as salenum, ";
            sql += "sp.id as 商品id,用户ID,编号,编号new,类别号,ca.c_name,品名,isTuan,规格,单位,重量,市场价,本站价,序号,分销率,三团价,九团价,上架时间,下架时间,录入时间,库存数量,限购数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮,";
            sql += "sp.regtime,(select top 1 图片路径 from TM_商品图片表 where sp.编号=商品编号 order by 序号 asc) as 图片路径 ";
            sql += "from   dbo.TM_商品表 as sp    ";
            sql += "  left join WP_category ca on sp.类别号=ca.c_no    )  as aa  where  1=1 and aa.IsShow=1  " + where + "  ";
            sql += "" + where1 + "  order by 序号 asc, regtime desc";


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

        protected void btn_设置分销率_Click(object sender, EventArgs e)
        {
            decimal fenxiao = -1m;
            decimal.TryParse(this.txt_分销率.Text, out fenxiao);
            if (fenxiao > 0)
            {
                for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
                {
                    int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                    CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                    if (cb.Checked)
                    {
                        DTcms.BLL.TM_商品表 bgoods = new DTcms.BLL.TM_商品表();
                        DTcms.Model.TM_商品表 mgoods = bgoods.GetModel(id);
                        if (mgoods != null)
                        {
                            mgoods.分销率 = fenxiao;
                            bgoods.Update(mgoods);
                        }
                    }
                }
                goodsinfoList();
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
            }
            else
            {
                Response.Write("<script>alter('请设置合适的分销率')</script>");
            }
        }
        protected void btn_批量上架_Click(object sender, EventArgs e)
        {
            int right = 0, wrong = 0;
            for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DTcms.BLL.TM_商品表 bgoods = new DTcms.BLL.TM_商品表();
                    DTcms.Model.TM_商品表 mgoods = bgoods.GetModel(id);
                    if (mgoods != null)
                    {
                        mgoods.是否上架 = 1;
                        if (bgoods.Update(mgoods))
                            right++;
                        else
                            wrong++;
                    }
                }
            }
            MessageBox.Show(this, "成功上架" + right + "个商品，失败" + wrong + "个商品");
            goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
        }

        protected void btn_批量下架_Click(object sender, EventArgs e)
        {
            int right = 0, wrong = 0;
            for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DTcms.BLL.TM_商品表 bgoods = new DTcms.BLL.TM_商品表();
                    DTcms.Model.TM_商品表 mgoods = bgoods.GetModel(id);
                    if (mgoods != null)
                    {
                        mgoods.是否上架 = 0;
                        if (bgoods.Update(mgoods))
                            right++;
                        else
                            wrong++;
                    }
                }
            }
            MessageBox.Show(this, "成功上架" + right + "个商品，失败" + wrong + "个商品");
            goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
        }


        //导出数据
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
            string sql = "select  	c_name as 类别,品名,规格,编号new as 条形码,isTuan,单位,重量,市场价,本站价,序号 as 显示顺序,分销率,上架时间,下架时间,库存数量,限购数量,case 是否上架 when 1 then '是' else '否' end as 是否上架,折扣率,case 是否卖家承担运费 when 1 then '是' else '否' end as 是否卖家承担运费,regtime as 更新时间 from ( select   isnull((select  salenum from  [SaleCount] where   SaleCount.商品id=sp.id and  typename='TM'),0) as salenum, ";
            sql += "sp.id as 商品id,用户ID,编号,编号new,类别号,ca.c_name,品名,isTuan,规格,单位,重量,市场价,本站价,序号,分销率,三团价,九团价,上架时间,下架时间,录入时间,库存数量,限购数量,IsShow,是否上架,类型,折扣率,是否卖家承担运费,cast(满多少包邮 as decimal(18,2)) as 满多少包邮,";
            sql += " sp.regtime  ";
            sql += "from  dbo.TM_商品表 as sp    ";
            sql += " left join WP_category ca on sp.类别号=ca.c_no  )  as aa  where  1=1 and aa.IsShow=1 " + where1 + " order by 序号 asc,regtime desc ";

            DataTable dt1 = comfun.GetDataTableBySQL(sql);

            if (dt1.Rows.Count > 0)
            {
                DTcms.Common.Excel.DataTable4Excel(dt1, "团购商品表");
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }

        public string GetTypeTuan(object isTuan)
        {
            string a = "";
            int istuan = Utils.ObjToInt(isTuan, 0);
            if (istuan == 0)
            {
                a = "团购";
            }
            else if (istuan == 1)
            {
                a = "秒杀";
            }
            else if (istuan == 2)
            {
                a = "预售";
            }
            else
            {
                
            }
            return a;}






    }
}



