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
using System.Text;
using System.Collections;


namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class GoodsList : System.Web.UI.Page
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
            Session.Contents.Remove("goods_combo_id");//清空session
            if (!IsPostBack)
            {
                goodstype();
                string spbh = string.IsNullOrEmpty(Request["spbh"]) ? "0" : Request["spbh"];
                string types = string.IsNullOrEmpty(Request["types"]) ? "0" : Request["types"];//0-全部商品；1-出售中的商品；2-库存不足；3-仓库中的商品

                switch (Convert.ToInt32(types))
                {
                    case 0:
                        where1 = " and 1=1 ";
                        where2 = " and 1=1 ";
                        hidd_hide.Value = "1";
                        break;
                    case 1:
                        where1 = " and 是否上架=1 ";
                        where2 = " and 是否上架=1 ";
                        break;
                    case 2:
                        where1 = " and 库存数量<=1 ";
                        where2 = " and 库存数量=0 ";
                        break;
                    case 3:
                        where1 = " and 库存数量>=1 ";
                        where2 = " and 是否上架=0 ";
                        break;
                }
                ClassList(where1);
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
            string sql = @"select id as 商品id,图片路径,编号new,编码,编号,品名,类别,单位,规格,重量,市场价,本站价,库存数量,限购数量,是否卖家承担运费,上架时间,下架时间,IsShow,是否上架 from 视图商品信息表 where 1=1 and IsShow=1 and 是否单样=1 " + where_sql + " order by 录入时间 desc ";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            dt.Columns.Add("已售数量", typeof(string));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql2 = @"select sum(数量) as 已售数量 from 订单列表 where 支付状态=3 and 商品id="+dt.Rows[i]["商品id"];
                    DataTable dt2 = comfun.GetDataTableBySQL(sql2);
                    if(dt2.Rows.Count>0){
                        dt.Rows[i]["已售数量"] = dt2.Rows[0]["已售数量"];

                    }  else
                        {
                            dt.Rows[i]["已售数量"] = "0";
                        }
                    }
            }
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = 10;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPager1.RecordCount = dt.Rows.Count;//记录总数
            this.sptList1.DataSource = pdsList;
            this.sptList1.DataBind();
            return dt;
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

                        comfun.UpdateBySQL("Update WP_酒店商品 set IsShow =0 where 商品id="+id);
                 int flag=comfun.UpdateBySQL(" Update WP_商品表 set IsShow=0 where id=" + id + " ");

                   // int flag=comfun.DelbySQL("DELETE FROM WP_箱子表 WHERE 默认商品id = "+id);
                    if (flag > 0)
                    {
                        MessageBox.ShowAndRedirect(this, "删除成功！","GoodsList.aspx");
                    }
                    else {
                        MessageBox.Show(this,"删除失败");
                        return;
                    }

                    }
                }
            }
            //goodsinfoList();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
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

                //Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                //Response.End();


            }

            return s;

        }
        #endregion

        #region 搜索  2015.7.12
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
           
        }
        #endregion

        protected string sousuo() {
            string query = "";
            string shop_name = txt_pinming.Text;
            string sxj_lb = sxj.SelectedValue;
            string bianma = txt_bianma.Text;
            if (shop_name != "")
            {
                query += " and (品名 like '%" + shop_name + "%' or 编号new like '%" + shop_name + "%') and 是否单样=1 ";
            }
            if(bianma!=""){
                query += @" and 编码='"+bianma+"'";   
            }
            string type_id = this.drp_photo.SelectedValue;

            if (type_id != "0")
            {
                query += " and 类别号=" + type_id + " ";
            }
            if (sxj_lb == "1")
            {
                query += " and 是否上架=1 ";
            }
            if(sxj_lb=="2"){
                query += " and 是否上架=0 ";
            }
            ClassList(query);
            return query;
            
        }

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
        //        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
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
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
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
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsList.aspx'", true);
        }
        /// <summary>
        /// 添加组合套餐
        /// </summary>
        string id = "";
        string goods_combo_id = "";
        CheckBox cb;
        protected void btn_combined_package_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("goods_combo_id");//清空session
            string str = hiddf.Value.ObjToStr();         //获取隐藏域中的值(商品id)
            Session["goods_combo_id"] = str;            //赋值到session
            string[] ssp=str.Split(',');                
            if (ssp.Length<3)
            {
                MessageBox.Show(this,"请选择商品后再组合为套餐!");
                return;
            }
            JavaScriptLocationHref("GoodsEdit.aspx?id=-1");
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
        // 导出数据
        protected void lbtn_Export_Click(object sender, EventArgs e)
        {
                string where_sql= sousuo();
                string sql = @"select 编号new as 条形码,编号,编码,品名,类别,单位,规格,重量,市场价,本站价,库存数量,限购数量,上架时间,下架时间  from 视图商品信息表 where 1=1 and IsShow=1 and 是否单样=1 " + where_sql + " order by 录入时间 desc ";
                DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "商品信息" + DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else
                Response.Write("<script>alert('导出失败，没有数据')</script>");

        }

        //分页数值改变
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
           
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            sousuo();

        

        }

        //单击跳转页面
        protected void open_combo(object sender, EventArgs e)
        {
            Server.Transfer("GoodsCombo.aspx?spbh=0"); 
        }

        //绑定选中事件
        protected void chkId_DataBinding(object sender, EventArgs e)
        {
            string ss = hiddf.Value;//取出所有的
            string[] st=ss.Split(',');
            for (int j = 0; j < st.Length-1; j++)
            {
                for (int i = 0; i < sptList1.Items.Count; i++)
                {
                    id = ((HiddenField)sptList1.Items[i].FindControl("hidId")).Value;//商品id
                    cb = (CheckBox)sptList1.Items[i].FindControl("chkId");//选中的id
                    if (st[j]==id)
                    {
                        cb.Checked=true;
                    }

                }
            }

        }

        protected void chkId_CheckedChanged(object sender, EventArgs e)
        {
            string hv = hiddf.Value;//先拿出所有的
            List<string> list = new List<string>(hv.Split(','));
            CheckBox obj = sender as CheckBox;
           id = ((HiddenField)obj.Parent.FindControl("hidId")).Value;

            if (obj.Checked)//如果选中，就是原来没有选中，需要增加
            {
                list.Add(id);
            }
            else {
                list.Remove(id);
            }
            //list.RemoveAt(0);
            string ss="";
            list.Remove("");
            foreach (var item in list)
	        {
		            ss+=item+",";
	        }
            hiddf.Value = ss;
        }
      
     
    }
}




