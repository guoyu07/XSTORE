using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class GoodsCombo : System.Web.UI.Page
    {
        public int goods_id;
        DTcms.BLL.WP_商品表 spbll = new DTcms.BLL.WP_商品表();
        //protected internal DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        public static int td;
        public int totalcount = 0;
        public static string where1 = "  and 1=1  ";
        public static string where2 = "  and 1=1  ";
        #region 1.0  页面加载
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
             
                ClassList(where1);
                goodstype();
                //   getstore();

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
        protected DataTable ClassList(string where_sql)
        {
            string sql = @"select id as 商品id,图片路径,编号new,编号,编码,品名,类别,单位,规格,重量,市场价,本站价,库存数量,限购数量,分销率,折扣率,是否卖家承担运费,上架时间,下架时间,IsShow,是否上架,是否单样 from 视图商品信息表 where 1=1 and IsShow=1 and 是否单样=0 " + where_sql + " order by 录入时间 desc ";//为1时单样
            DataTable dt = comfun.GetDataTableBySQL(sql);
            dt.Columns.Add("已售数量", typeof(string));
            string sql2 = @"select salenum,商品id from SaleCount ";
            DataTable dt2 = comfun.GetDataTableBySQL(sql2);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["商品id"] == dt2.Rows[j]["商品id"])
                        {
                            dt.Rows[i]["已售数量"] = dt2.Rows[j]["salenum"];
                        }
                        else
                        {
                            dt.Rows[i]["已售数量"] = 0;
                        }
                    }
                }
            }
            bound(dt);//绑定分页
            return dt;
        }
        #endregion

        //绑定分页控件
        public void bound(DataTable dt)
        {
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.sptList1.DataSource = pdsList;
            this.sptList1.DataBind();
        }



        #region 4.0 删除 +void btnDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < sptList1.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)sptList1.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)sptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DTcms.BLL.WP_商品图片表 sptpbll = new DTcms.BLL.WP_商品图片表();

                    DTcms.BLL.WP_商品详情表 spxqbll = new DTcms.BLL.WP_商品详情表();

                    DTcms.BLL.WP_商品表 spbll = new DTcms.BLL.WP_商品表();

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
                    //删除组合


                    int flag=DbHelperSQL.GetSingle(" Update WP_商品表 set IsShow=0 where id=" + id + " ").ObjToInt(0);
                    //int flag = comfun.DelbySQL("DELETE FROM WP_箱子表 WHERE 默认商品id = " + id);
                    if (flag > 0)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                    else
                    {
                        MessageBox.Show(this, "删除失败");
                    }


                }
            }
            //goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsCombo.aspx'", true);
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
        //    //sql += "sp.id as 商品id,用户ID,编号,类别号,品名,规格,单位,市场价,本站价,分销率,三团价,九团价,上架时间,下架时间,录入时间,库存数量,IsShow,";
        //    //sql += "spxq.id as 商品详情id,spxq.商品编号 as xq商品编号,描述,特点,注意事项,资质证明,品牌介绍,";
        //    //sql += "sptp.id as 商品图片id ,sptp.商品编号  as tp商品编号,标题,图片路径  ";
        //    //sql += "from dbo.WP_用户表 as yh inner join dbo.WP_商品表 as sp on yh.id=sp.用户id   left join dbo.WP_商品详情表  as spxq  ";
        //    //sql += " on sp.编号=spxq.商品编号 left join dbo.WP_商品图片表  as sptp on  spxq.商品编号=sptp.商品编号)  as aa  ";

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
            sousuo();  
        }
        #endregion

        #region 搜索
        protected string sousuo()
        {
            string query = "";
            string shop_name = txt_pinming.Text;
            string sxj_lb = sxj.SelectedValue;
            string bianma = txt_bianma.Text;
            if (shop_name != "")
            {
                query += " and (品名 like '%" + shop_name + "%' or 编号new like '%" + shop_name + "%')";
            }
            if (bianma != "")
            {
                query += " and 编码 like '%"+bianma+"%'";
            }
            string type_id = this.drp_photo.SelectedValue;

            if (type_id == "0")
            {
                query += " and 1=1 ";
            }
            else
            {
                // string c_nos = DbHelperSQL.Query("exec [proceGetChildCno] '" + type_id + "'").Tables[0].Rows[0][0].ToString();
                query += " and 类别号=" + type_id + " ";
            }
            if (sxj_lb == "1")
            {
                query += " and 是否上架=1";
            }
            if (sxj_lb=="2")
            {
                query += " and 是否上架=0";
            }
            DataTable dt = ClassList(query);
            bound(dt);
            return query;
        }
        #endregion
        //商品类别
        private void goodstype()
        {
            string sql = " select c_id,c_no as 类别编号,c_name as 类别名 from dbo.WP_category order by c_id asc";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            //DataRow row = dt.NewRow();
            //row["类别名"] = "所有分类";
            //row["类别编号"] = "-1";
            //dt.Rows.InsertAt(row, 0);
            if (dt.Rows.Count > 0)
            {

                drp_photo.DataSource = dt;
                drp_photo.DataTextField = "类别名";
                drp_photo.DataValueField = "类别编号";

                drp_photo.DataBind();
                drp_photo.Items.Insert(0, new ListItem("请选择", "0"));
            }


        }

        //设置分效率
        //protected void btn_save_distribution_Click(object sender, EventArgs e)
        //{
        //    decimal fenxiao = -1m;
        //    decimal.TryParse(this.txt_distribution.Text, out fenxiao);
        //    if (fenxiao > 0)
        //    {
        //        for (int i = 0; i < sptList1.Items.Count; i++)
        //        {
        //            int id = Convert.ToInt32(((HiddenField)sptList1.Items[i].FindControl("hidId")).Value);
        //            CheckBox cb = (CheckBox)sptList1.Items[i].FindControl("chkId");
        //            if (cb.Checked)
        //            {
        //                DTcms.BLL.WP_商品表 bgoods = new DTcms.BLL.WP_商品表();
        //                DTcms.Model.WP_商品表 mgoods = bgoods.GetModel(id);
        //                if (mgoods != null)
        //                {
        //                    mgoods.折扣率 = fenxiao;
        //                    bgoods.Update(mgoods);
        //                }
        //            }
        //        }
        //        // goodsinfoList();
        //        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsCombo.aspx'", true);
        //    }
        //    else
        //    {
        //        Response.Write("<script>alter('请设置合适的分销率')</script>");
        //    }
        //}
        protected void btn_batch_putaway_Click(object sender, EventArgs e)
        {
            int right = 0, wrong = 0;
            for (int i = 0; i < sptList1.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)sptList1.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)sptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DTcms.BLL.WP_商品表 bgoods = new DTcms.BLL.WP_商品表();
                    DTcms.Model.WP_商品表 mgoods = bgoods.GetModel(id);
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
            //  goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsCombo.aspx'", true);
        }

        protected void btn_batch_soldout__Click(object sender, EventArgs e)
        {
            int right = 0, wrong = 0;
            for (int i = 0; i < sptList1.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)sptList1.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)sptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DTcms.BLL.WP_商品表 bgoods = new DTcms.BLL.WP_商品表();
                    DTcms.Model.WP_商品表 mgoods = bgoods.GetModel(id);
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
            // goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsCombo.aspx'", true);
        }

        #region
        public static void JavaScriptLocationHref(string url)
        {
           
            string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
            
        }
        #endregion

        //导出数据
        protected void LBtn_Export_Click(object sender, EventArgs e)
        {
             string where_sql= sousuo();
             DataTable dt = new comfun().GetDataTable(@"select 编号new as 条形码,编号,编码,品名,类别,单位,规格,重量,市场价,本站价,库存数量,限购数量,上架时间,下架时间,是否上架,(case 是否单样 when '1' then '单样' when '0' then '组合' end) as 是否单样 from 视图商品信息表 where 1=1 and IsShow=1 and 是否单样=0 " + where_sql + " order by 录入时间 desc ");
             if (dt.Rows.Count > 0)
             {
           
             DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "组合商品信息" +DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else{
                Response.Write("<script>alert('导出失败，没有数据')</script>");
          }

        }


        //分页数值改变
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();  
        }

        protected string isCombo(string id)
        {
            string[] str_id = id.Split(',');//数组
            for (int i = 0; i < str_id.Length - 1; i++)
            {
                DataTable dtb = comfun.GetDataSetBySQL("select 商品id from WP_商品表组 where 商品组合id=" + str_id[i]).Tables[0];
                if (dtb.Rows.Count != 0)
                {
                    return "0";//组合
                }
            }
            return "1";//单样
        }

        protected void open_combo(object sender, EventArgs e)
        {
        //    MessageBox.ShowAndRedirect(this, "", "");
        
            Server.Transfer("GoodsList.aspx"); 
           } 
        }

    }
