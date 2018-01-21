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
    public partial class OStockAdd : System.Web.UI.Page
    {
        // protected DTcms.Model.manager admin_info;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        #region 初始化信息
        protected void bind()
        {
            counter.Value = "1";
            string test = "OutS" + DateTime.Now.ToString("yyyyMMdd") + DbHelperSQL.Query(@"select right('00000'+cast(a.num+1 as  varchar(50)),5) from (select count(1) as num from [dbo].[WP_出库表] where CONVERT(varchar(100),操作日期,23)=CONVERT(varchar(100),GETDATE(),23)) a").Tables[0].Rows[0][0].ToString();
            Instocknum.Text = test;
            instockdatetime.Text = DateTime.Now.ToString();
            //品名

            instockuser();
            area();
            ddl_shen.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));
            rukuleixing();
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
        protected void rukuleixing()
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("name", typeof(string));
            dt1.Rows.Add(1, "正常出库");
            dt1.Rows.Add(2, "其他出库");
            dt1.Rows.Add(3, "转出库");
            cklx_ddl.DataSource = dt1;
            cklx_ddl.DataTextField = "name";
            cklx_ddl.DataValueField = "id";
            cklx_ddl.DataBind();
        }

        #endregion
        #region 联动信息
        //shen
        private void area()
        {
            string sql = "select id,名称 from WP_地区表 where  父级id is null"; //or 名称='全国'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_shen.DataTextField = "名称";
            ddl_shen.DataValueField = "id";
            ddl_shen.DataSource = dt;
            ddl_shen.DataBind();
        }
        //jd
        private void jd()
        {
            //select id,酒店简称 from WP_酒店表  where 区域id='2'
            string shiid = ddl_shen.SelectedItem.Value;
            string jd = "select id,酒店简称 from WP_酒店表  where 区域id='" + shiid + "' and IsShow=1";
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
            string warehouse = "select id,仓库名 from WP_仓库表 where 酒店id='" + jdid + "' and IsShow=1";
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
            string kw = "select id,库位名 from WP_库位表 where 仓库id='" + warehouseid + "' and 箱子MAC is null and IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(kw);
            ddl_kw.DataTextField = "库位名";
            ddl_kw.DataValueField = "id";
            ddl_kw.DataSource = dt;
            ddl_kw.DataBind();
        }
        //protected void newrows_Click(object sender, EventArgs e)
        //{
        //}

        private void db(string where_sql)
        {
            string sql = @"select a.id as 库位id,a.库位名 as 库位,c.酒店全称 as 酒店全称,b.仓库名 as 仓库 
  from WP_库位表 a left join WP_仓库表 b on a.仓库id=b.id left join WP_酒店表 c on b.酒店id=c.id 
  where a.IsShow=1 and b.IsShow=1 and c.IsShow=1 " + where_sql;
            DataTable dt = comfun.GetDataTableBySQL(sql);
            
        }
        protected void ddl_shen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_hotel.Items.Clear();
            ddl_warehouse.Items.Clear();
            ddl_kw.Items.Clear();
            ddl_wz.Items.Clear();
            jd();
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));
            string where_sql = "";
            if (ddl_shen.SelectedValue != "0")
            {
                where_sql = @" and c.区域id=" + ddl_shen.SelectedValue;
            }

            db(where_sql);
        }

        protected void ddl_hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_warehouse.Items.Clear();
            ddl_kw.Items.Clear();
            ddl_wz.Items.Clear();
            warehouse();
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));
            string where_sql = "";
            if (ddl_hotel.SelectedItem.Value.ToString() != "0")
            {
                where_sql = @" and c.区域id=" + ddl_shen.SelectedValue + " and c.id=" + ddl_hotel.SelectedValue;
            }
            else
            {
                where_sql = @" and c.区域id=" + ddl_shen.SelectedValue;
            }
            db(where_sql);
        }

        protected void ddl_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddl_kw.Items.Clear();
            ddl_wz.Items.Clear();
            kw();
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));

            string where_sql = "";
            if (ddl_warehouse.SelectedValue != "0")
            {
                where_sql = @" and c.区域id=" + ddl_shen.SelectedValue + " and c.id=" + ddl_hotel.SelectedValue + " and b.id=" + ddl_warehouse.SelectedValue;
            }
          
            db(where_sql);
           
        }
        protected void ddl_kw_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_wz.Items.Clear();
            wz_bound();
            ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));
            string where_sql = "";
            if (ddl_kw.SelectedValue != "0")
            {
                where_sql = @" and c.区域id=" + ddl_shen.SelectedValue + " and c.id=" + ddl_hotel.SelectedValue + " and b.id=" + ddl_warehouse.SelectedValue + " and a.id=" + ddl_kw.SelectedValue;
            }
         
            db(where_sql);
            //new OutRows().comboboxBind(ddl_kw.SelectedValue.ObjToInt(0));
            product_rep.Rebind();
        }
        protected void ddl_wz_SelectedIndexChanged(object sender, EventArgs e)
        {
            string where_sql = "";
            if (ddl_wz.SelectedValue != "0")
            {
                where_sql = @" and c.区域id=" + ddl_shen.SelectedValue + " and c.id=" + ddl_hotel.SelectedValue + " and b.id=" + ddl_warehouse.SelectedValue + " and a.id=" + ddl_kw.SelectedValue + " and a.位置=" + ddl_wz.SelectedValue;
            }
        
            db(where_sql);
        }

        protected void wz_bound() {
            ddl_wz.Items.Insert(0, new ListItem("--1--", "1"));
            ddl_wz.Items.Insert(0, new ListItem("--2--", "2"));
            ddl_wz.Items.Insert(0, new ListItem("--3--", "3"));
            ddl_wz.Items.Insert(0, new ListItem("--4--", "4"));
            ddl_wz.Items.Insert(0, new ListItem("--5--", "5"));
            ddl_wz.Items.Insert(0, new ListItem("--6--", "6"));
            ddl_wz.Items.Insert(0, new ListItem("--7--", "7"));
            ddl_wz.Items.Insert(0, new ListItem("--8--", "8"));
            ddl_wz.Items.Insert(0, new ListItem("--9--", "9"));
            ddl_wz.Items.Insert(0, new ListItem("--10--", "10"));
            ddl_wz.Items.Insert(0, new ListItem("--11--", "11"));
            ddl_wz.Items.Insert(0, new ListItem("--12--", "12"));
        }

        #endregion
        #region 入库列表databound事件
        protected void product_rep_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            var item = e.Item.FindControl("rows") as OutRows;
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
            var equ_list = product_rep.Items.Select(o => (o.FindControl("rows") as OutRows)).Select(o => o.getlistmem()).ToList();

            json_memory.Value = JsonConvert.SerializeObject(equ_list);
            //int count = Convert.ToInt32(counter.Value);
            product_rep.Rebind();
          
        }



        protected void Btnrk_Click(object sender, EventArgs e)
        {
            string outs = "OutS" + DateTime.Now.ToString("yyyyMMdd") + DbHelperSQL.Query(@"select right('00000'+cast(a.num+1 as  varchar(50)),5) from (select count(1) as num from [dbo].[WP_出库表] where CONVERT(varchar(100),操作日期,23)=CONVERT(varchar(100),GETDATE(),23)) a").Tables[0].Rows[0][0].ToString();
           // int gys=Convert.ToInt32( gongyinshang_ddl.SelectedValue);
            int czy=Convert.ToInt32( instockuser_ddl.SelectedValue);
            int cklx=Convert.ToInt32(cklx_ddl.SelectedValue);
            int kwid=Convert.ToInt32(ddl_kw.SelectedValue);
            int wz = Convert.ToInt32(ddl_wz.SelectedValue);
            //var data_list = JsonConvert.DeserializeObject<List<Newlistmem>>(json_memory.Value);
            var equ_list = product_rep.Items.Select(o => (o.FindControl("rows") as OutRows)).Select(o => o.getlistmem()).ToList();
            int flag = 0;
            foreach (Newlistmem item in equ_list)
            {
                string id = item.id_txtbox;
                if(id!=""&&id!=null){
                    string sql = "insert into [dbo].[WP_出库表] ([单据编号],[商品id],[数量],[出价],[总出价额],[操作日期],[备注],[库位id],[位置],[操作id],[出库类型])values('"+outs+"','"+item.id_txtbox+"','"+item.rk_txtbox+"','"+item.price_txtbox+"','"+item.totalprice_txtbox+"',GETDATE(),'"+item.remark_txtbox+"','"+kwid+"',"+wz+",'"+czy+"','"+cklx+"')";
                    flag=new comfun().Insert(sql);
                    string ins_sql = @"insert into WP_配货信息表 (出库编号,操作员id,状态)values('" + outs + "','" + czy + "',4)";
                    new comfun().Insert(ins_sql);
                    if(flag==0){
                        break;
                    }
                }
            }
            if (flag != 0)
            {
                MessageBox.ShowAndRedirect(this, "修改成功！", "OutStockList.aspx");
            }
            else {
                MessageBox.Show(this, "添加失败");
                return;
            }
            

        }

     

     

    }
}