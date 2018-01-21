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
using System.Data.SqlClient;
using Wuqi.Webdiyer;
using tdx.database.Common_Pay.WeiXinPay;
using DTcms.Model;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;


namespace tdx.memb.box
{
    public partial class InStockAdd : System.Web.UI.Page
    {
        // protected DTcms.Model.manager admin_info;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    bind();
            }
        }
        #region
        protected void bind()
        {
            counter.Value = "1";
            string test = "InS" + DateTime.Now.ToString("yyyyMMdd") + DbHelperSQL.Query(@"select right('00000'+cast(a.num+1 as  varchar(50)),5) from (select count(1) as num from [dbo].[WP_入库表] where CONVERT(varchar(100),操作日期,23)=CONVERT(varchar(100),GETDATE(),23)) a").Tables[0].Rows[0][0].ToString();
            Instocknum.Text = test;
            instockdatetime.Text = DateTime.Now.ToString();
            //品名

            instockuser();
            gongyinshang();
            area();
            ddl_shen.Items.Insert(0, new ListItem("--请选择--", "0"));
            //ddl_shi.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            rukuleixing();
            // string userid = new DTcms.BLL.manager_role().GetTitle(admin_info.role_id).ToString();
            //  InStockUser.Text = userid;
            product_rep.Rebind();

        }
        #region 商品选择
        protected void sp_choose()
        {
            spchoose1();
        }
        protected void spchoose1()
        {
            string sql = "select id as 商品id1,品名 as 品名1 from WP_商品表";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            //rcb_sp1.DataSource = dt;
            //rcb_sp1.DataBind();
        }
        #endregion
        protected void instockuser()
        {
            string sql = "select id,[user_name] from dt_manager";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            instockuser_ddl.DataTextField = "user_name";
            instockuser_ddl.DataValueField = "id";
            instockuser_ddl.DataSource = dt;
            instockuser_ddl.DataBind();
        }
        protected void gongyinshang()
        {
            string sql = "select 编号 as id,公司名称 from Wp_客户资料 where 是否供应商 = 1 and IsShow=1";
            DataTable dt1 = comfun.GetDataTableBySQL(sql); //new DataTable();
            gongyinshang_ddl.DataSource = dt1;
            gongyinshang_ddl.DataTextField = "公司名称";
            gongyinshang_ddl.DataValueField = "id";
            gongyinshang_ddl.DataBind();
        }
        protected void rukuleixing()
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("name", typeof(string));
            dt1.Rows.Add(1, "正常入库");
            dt1.Rows.Add(2, "其它入库");
            dt1.Rows.Add(3, "转入库");
            dt1.Rows.Add(4, "退货入库");
            rklx_ddl.DataSource = dt1;
            rklx_ddl.DataTextField = "name";
            rklx_ddl.DataValueField = "id";
            rklx_ddl.DataBind();
        }

        #endregion
        #region 联动信息
        //shen
        private void area()
        {
            string sql = "select id,名称 from WP_地区表 where 父级id is null"; //or 名称='全国'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_shen.DataTextField = "名称";
            ddl_shen.DataValueField = "id";
            ddl_shen.DataSource = dt;
            ddl_shen.DataBind();
        }
        //shi
        //private void shi()
        //{
        //    string shenid = ddl_shen.SelectedItem.Value;
        //    string shi = "select id,名称 from WP_地区表 where 父级id='" + shenid + "'";
        //    DataTable dt = comfun.GetDataTableBySQL(shi);
        //    ddl_shi.DataTextField = "名称";
        //    ddl_shi.DataValueField = "id";
        //    ddl_shi.DataSource = dt;
        //    ddl_shi.DataBind();
        //}
        //jd
        private void jd()
        {
            //select id,酒店简称 from WP_酒店表  where 区域id='2'
            //string shiid = ddl_shi.SelectedItem.Value;
            string shenid = ddl_shen.SelectedItem.Value;
            string jd = "select id,酒店简称 from WP_酒店表  where 区域id='" + shenid + "'and isshow=1";
            DataTable dt = comfun.GetDataTableBySQL(jd);
            ddl_hotel.DataTextField = "酒店简称";
            ddl_hotel.DataValueField = "id";
            ddl_hotel.DataSource = dt;
            ddl_hotel.DataBind();

        }
        //ck
        private void warehouse()
        {
            string jdid = ddl_hotel.SelectedItem.Value;
            string warehouse = "select id,仓库名 from WP_仓库表 where 酒店id='" + jdid + "'and isshow=1";
            DataTable dt = comfun.GetDataTableBySQL(warehouse);
            ddl_warehouse.DataTextField = "仓库名";
            ddl_warehouse.DataValueField = "id";
            ddl_warehouse.DataSource = dt;
            ddl_warehouse.DataBind();
        }
        //kw
        private void kw()
        {
            string warehouseid = ddl_warehouse.SelectedItem.Value;
            string kw = "select id,库位名 from WP_库位表 where 仓库id='" + warehouseid + "' and 箱子MAC is null and isshow=1 and 库位名 like '%总台%'";
            DataTable dt = comfun.GetDataTableBySQL(kw);
            ddl_kw.DataTextField = "库位名";
            ddl_kw.DataValueField = "id";
            ddl_kw.DataSource = dt;
            ddl_kw.DataBind();
        }
        //protected void newrows_Click(object sender, EventArgs e)
        //{
        //}

        protected void ddl_shen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //shi();
            jd();
           // ddl_hotel.Items.Clear();
            ddl_warehouse.Items.Clear();
            ddl_kw.Items.Clear();
           // ddl_shi.Items.Insert(0, new ListItem("--请选择--", "0"));
           ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        //protected void ddl_shi_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    jd();
        //    ddl_warehouse.Items.Clear();
        //    ddl_kw.Items.Clear();
        //    ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
        //    ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
        //    ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
        //}

        protected void ddl_hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            warehouse();
            ddl_kw.Items.Clear();
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            // ddl_warehouse.Items.Insert(0, "--请选择--");
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        protected void ddl_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            kw();
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            product_rep.Rebind();
        }

        protected void ddl_kw_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region 入库列表databound事件
        protected void product_rep_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            var item = e.Item.FindControl("rows") as Nrows;
            //var equ_list = new List<Newlistmem>();
            var equ_list = string.IsNullOrEmpty(json_memory.Value) ? new List<Newlistmem>() :JsonConvert.DeserializeObject<List<Newlistmem>>(json_memory.Value);
            //var count = int.Parse(counter.Value);
            if (equ_list.Count() <item.itemindex+1)
                item.loadInit(new Newlistmem());
            else
                item.loadInit(equ_list[item.itemindex]);
        }
        #endregion
        #region
        protected void product_rep_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            this.product_rep.DataSource = new int[int.Parse(counter.Value)];
        }
        #endregion

        protected void plus_ServerClick(object sender, EventArgs e)
        {
            counter.Value = (int.Parse(counter.Value) + 1).ToString();
            var equ_list = product_rep.Items.Select(o => (o.FindControl("rows") as Nrows)).Select(o => o.getlistmem()).ToList();

            json_memory.Value = JsonConvert.SerializeObject(equ_list);
            //int count = Convert.ToInt32(counter.Value);
            product_rep.Rebind();
          
        }


        //保存
        protected void Btnrk_Click(object sender, EventArgs e)
        {
            string ins = "Ins" + DateTime.Now.ToString("yyyyMMdd") + DbHelperSQL.Query(@"select right('00000'+cast(a.num+1 as  varchar(50)),5) from (select count(1) as num from WP_入库表 where CONVERT(varchar(100),操作日期,23)=CONVERT(varchar(100),GETDATE(),23)) a").Tables[0].Rows[0][0].ToString();
            int gys=Convert.ToInt32( gongyinshang_ddl.SelectedValue);
            int czy=Convert.ToInt32( instockuser_ddl.SelectedValue);
            int rklx=Convert.ToInt32(rklx_ddl.SelectedValue);
            int kwid=Convert.ToInt32(ddl_kw.SelectedValue);
            var equ_list = product_rep.Items.Select(o => (o.FindControl("rows") as Nrows)).Select(o => o.getlistmem()).ToList();
            int flag = 0;
            if (gys != 0 && czy != 0&& kwid != 0) //&& rklx != 0 
            {
                foreach (Newlistmem item in equ_list)
                {
                    string id = item.id_txtbox;
                    if (id != "" && id != null)
                    {
                        string sql = "insert into [dbo].[WP_入库表] ([单据编号],[供应商id],[商品id],[数量],[进价],[总进价额],[操作日期],[备注],[库位id],[位置],[操作id],[入库类型]) values('" + ins + "','" + gys + "','" + item.id_txtbox + "','" + item.rk_txtbox + "','" + item.price_txtbox + "','" + item.totalprice_txtbox + "',GETDATE(),'" + item.remark_txtbox + "','" + kwid + "',1,'" + czy + "','" + rklx + "')";
                        flag=new comfun().Insert(sql);
                        DataTable dta = new comfun().GetDataTable(@"select [dbo].[商品库存数](" + item.rk_txtbox + "," + item.rk_txtbox + ") as 商品库存数");//得到当前库存
                        if(dta.Rows.Count>0){
                            new comfun().Update(@" update WP_商品表 set 库存数量=" + dta.Rows[0]["商品库存数"] + " where id=" + item.id_txtbox);//更新商品表库存
                        }

                       if(flag==0){
                           break;
                       }
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("请确认数据填写完整");
            }
            if (flag != 0)
            {
                MessageBox.ShowAndRedirect(this, "添加成功!", "InStockList.aspx");
                return;
            }
            else {
                MessageBox.Show(this,"添加失败");
                return;
            }
        }


        //protected void tkrk(string bhid) { //退款商品入库
        //    counter.Value = "1";
        //    area();//地区
        //    instockuser();//操作人
        //    gongyinshang();//供应商
        //    jd();//酒店
        //    warehouse();//仓库
        //    kw();//库位
        //    rukuleixing();//入库类型
        //    string sql = @" select 商品id,仓库id from WP_订单子表 where 订单编号='" + bhid + "'";
        //    DataTable dt = comfun.GetDataTableBySQL(sql);
        //    dt.Columns.Add("区域id",typeof(string));
        //    dt.Columns.Add("酒店id", typeof(string));
        //    dt.Columns.Add("库位id", typeof(string));
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
                
        //            string sel_sql = @" select 地区id,酒店id,库位id from 视图地区酒店仓库表 where 仓库id="+dt.Rows[0]["仓库id"];
        //            DataTable dta = comfun.GetDataTableBySQL(sel_sql);
        //            if(dta.Rows.Count>0){
        //                dt.Rows[i]["区域id"] = dta.Rows[0]["地区id"];
        //                dt.Rows[i]["酒店id"] = dta.Rows[0]["酒店id"];
        //                dt.Rows[i]["库位id"] = dta.Rows[0]["库位id"];
        //            }
        //        }
        //        ddl_shen.SelectedValue = dt.Rows[0]["区域id"].ObjToStr();
        //        ddl_hotel.SelectedValue = dt.Rows[0]["酒店id"].ObjToStr();
        //        ddl_warehouse.SelectedValue = dt.Rows[0]["仓库id"].ObjToStr();
        //        ddl_kw.SelectedValue = dt.Rows[0]["库位id"].ObjToStr();
        //        rklx_ddl.SelectedValue = "4";
        //        product_rep.Rebind();
        //        rk_again.Value = dt.Rows[0]["商品id"].ObjToStr(); ;//不为空的时候重新入库
        //    }
        //}
        

    }
}