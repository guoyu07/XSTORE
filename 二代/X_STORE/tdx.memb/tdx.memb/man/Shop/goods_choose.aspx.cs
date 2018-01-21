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
using DTcms.Common;
using tdx.database;
using DTcms.Model;

namespace tdx.memb.man.Shop
{
    public partial class goods_choose : System.Web.UI.Page
    {
        DTcms.BLL.WP_商品表 spbll = new DTcms.BLL.WP_商品表();
        protected internal siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        public static int td;
        public string url = "";
        public string ctl = "";
        public string choose = "";
        public string btn = "";
        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ctl = DTRequest.GetQueryString("ctl");
            this.btn = DTRequest.GetQueryString("btn");
            string s = DTRequest.GetQueryString("choose");
            this.choose = s == "" ? "multiple" : s;
            string val = DTRequest.GetQueryString("val");
            url = val;

            if (!IsPostBack)
            {
                ///2015.7.12 添加
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
            string sql = "select  *  from ( select yh.id as yhid,user_name,telephone,  ";
            sql += "sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,";
            sql += "spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍  ";
            sql += "from dbo.dt_manager as yh left join dbo.WP_商品表 as sp on yh.id=sp.用户id   left join dbo.WP_商品详情表  as spxq  ";
            sql += "on sp.编号=spxq.商品编号  )  as aa  where aa.编号 ='" + spbh + "'  ";

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

            string sql = "  select top 10*  from ( select yh.id as yhid,user_name,telephone,    ";
            sql += "  sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,    ";
            sql += "  spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍     ";
            sql += "   from dbo.dt_manager as yh inner join dbo.WP_商品表 as sp on yh.id=sp.用户id   left join dbo.WP_商品详情表  as spxq    ";
            //sql += "   on sp.编号=spxq.商品编号  ) as aa  where aa.yhid not in (select top (10*" + page + ") aa.yhid  from ( select yh.id as yhid,user_name,openid,telephone,    ";
            sql += "   on sp.编号=spxq.商品编号  ) as aa  where aa.商品id not in (select top (10*" + page + ") aa.商品id  from ( select yh.id as yhid,user_name,telephone,    ";
            sql += "  sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,     ";
            sql += "  spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍       ";
            sql += "   from dbo.dt_manager as yh left join dbo.WP_商品表 as sp on yh.id=sp.用户id   left join dbo.WP_商品详情表  as spxq     ";
            sql += "   on sp.编号=spxq.商品编号  )  as aa  where    " + _where + " order by 商品id desc) and  " + _where + "  order by 商品id desc  ";



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

            try
            {
                goods(" aa.yhid!=0");
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
            string sql = " select * from dbo.WP_category ";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["c_name"] = "所有分类";
            row["c_no"] = "-1";
            dt.Rows.InsertAt(row, 0);
            if (dt.Rows.Count > 0)
            {

                drp_photo.DataSource = dt.DefaultView;
                drp_photo.DataTextField = "c_name";
                drp_photo.DataValueField = "c_no";

                drp_photo.DataBind();

            }

        }

        private void goods(string where)
        {
          

            string sql = "select count(*) from ( select yh.id as yhid,user_name,telephone,  ";
            sql += "sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,";
            sql += "spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍  ";
            
            sql += "from dbo.dt_manager as yh inner join dbo.WP_商品表 as sp on yh.id=sp.用户id   left join dbo.WP_商品详情表  as spxq  ";
            sql += "on sp.编号=spxq.商品编号  )  as aa  where  " + where + "  ";



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
                // Response.Write("<script>parent.location.href='http://china-mail.com.cn/39tuan/man/login.aspx'</Script>");
            }
            #endregion
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
                query += " and 品名 like '%" + txt_pinming.Text.Trim() + "%'";
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
            string sql = "select *  from ( select yh.id as yhid,user_name,telephone,  ";
            sql += "sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,是否上架,类型,";
            sql += "spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍  ";
            sql += "from dbo.dt_manager as yh left join dbo.WP_商品表 as sp on yh.id=sp.用户id   left join dbo.WP_商品详情表  as spxq  ";
            sql += "on sp.编号=spxq.商品编号  )  as aa  where  1=1 " + where + "  ";


            DataTable dt = comfun.GetDataTableBySQL(sql);


            Rp_UserInfo.DataSource = dt.DefaultView;
            Rp_UserInfo.DataBind();
            lt_pagearrow.Text = "";



        }
        #endregion

        protected void drp_photo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string c_no = this.drp_photo.Text;

            if (c_no == "-1")
            {
                sousuo(" and  aa.yhid!=0");
            }
            else
            {
                string c_nos = DbHelperSQL.Query("exec [proceGetChildCno] '" + c_no + "'").Tables[0].Rows[0][0].ToString();
                sousuo(" and  aa.类别号 in  (" + c_nos + ")");
            }
        }
    }
}