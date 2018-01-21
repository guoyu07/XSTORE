using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace tdx.memb.man.Box
{
    public partial class ExChangeGoods : System.Web.UI.Page
    {
        /// <summary>
        ///  1  申请中
        ///  2 同意换货
        ///  3 不同意换货
        /// </summary>
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bind("");   
            }
        }
        protected void bind(string where_sql) {
            string sql = @"select a.id,箱子id,c.库位名,原商品id,新商品id,a.状态,申请时间,操作时间,a.openid,b.用户名 
 from WP_换货表 a left join WP_用户表 b on a.openid=b.openid  left join WP_库位表 c on a.箱子id=c.id 
 where 1=1 "+where_sql+" order by 申请时间 desc";
            DataTable dt = new comfun().GetDataTable(sql);
            dt.Columns.Add("原商品品名",typeof(string));
            dt.Columns.Add("新商品品名", typeof(string));
            if(dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dtb = new comfun().GetDataTable(@"select 品名 from WP_商品表 where id="+dt.Rows[i]["原商品id"]);
                    if(dtb.Rows.Count>0){
                        dt.Rows[i]["原商品品名"]=dtb.Rows[0]["品名"];
                    }
                    DataTable dtc = new comfun().GetDataTable(@"select 品名 from WP_商品表 where id=" + dt.Rows[i]["新商品id"]);
                    if (dtb.Rows.Count > 0)
                    {
                        dt.Rows[i]["新商品品名"] = dtc.Rows[0]["品名"];
                    }

                }
            }
            PagedDataSource pdsList = new PagedDataSource();
            pdsList.DataSource = dt.DefaultView;
            pdsList.AllowPaging = true;//数据源允许分页
            pdsList.PageSize = this.AspNetPagerIn.PageSize;//取控件的分页大小
            pdsList.CurrentPageIndex = this.AspNetPagerIn.CurrentPageIndex - 1;//显示当前页
            //设置控件
            this.AspNetPagerIn.RecordCount = dt.Rows.Count;//记录总数
            this.AspNetPagerIn.PageSize = 10;
            Rp_changeGoods.DataSource = pdsList;
            Rp_changeGoods.DataBind();

        }


        //搜索
        protected void LBtn_sousuo_Click(object sender, EventArgs e)
        {
            sousuo();
        }
        protected void sousuo() { 
           string kwname=kw_name.Text.ObjToStr();
            string ztlx = zt_lx.SelectedValue;
            string start_time = Jxl.Value.ObjToStr();
            string end_time = Jx2.Value.ObjToStr();
            string where_sql = "";
            if(kwname!=""){
                where_sql += " and c.库位名 like '%"+kwname+"%'";
            }
            if (ztlx != "0")
            {
                where_sql += " and a.状态=" + ztlx ;
            }
            if (start_time != "")
            {
                where_sql += " and 申请时间> '" + start_time + "'";
            }
            if (end_time != "")
            {
                where_sql += " and 申请时间<'" + end_time + "'";
            }
            bind(where_sql);
        }

        protected string Getzt(string zt) {
            string zz = "show";
            switch(zt)
            {
                case "1":
                    break;
                case "2":
                    zz = "none";
                    break;
                case "3":
                    zz = "none";
                    break;
            }
            return zz;
        }
        protected string Getzt2(string zt)
        {
            string zz = "show";
            switch (zt)
            {
                case "1":
                    zz = "none";
                    break;
                case "2":
                    break;
                case "3":
                    zz = "none";
                    break;
            }
            return zz;
        }
        protected string Getzt3(string zt)
        {
            string zz = "show";
            switch (zt)
            {
                case "1":
                    zz = "none";
                    break;
                case "2":
                    zz = "none";
                    break;
                case "3":
                    break;
            }
            return zz;
        }
        protected string GetztName(string zt)
        {
            string zz = "";
            switch (zt)
            {
                case "1":
                    zz = "申请审核中";
                    break;
                case "2":
                    zz = "申请通过";
                    break;
                case "3":
                    zz = "申请未通过";
                    break;
            }
            return zz;
        }
        //分页值改变
        protected void AspNetPagerIn_PageChanged(object sender, PageChangingEventArgs e)
        {
            AspNetPagerIn.CurrentPageIndex = e.NewPageIndex;
            sousuo();
        }
    }
}