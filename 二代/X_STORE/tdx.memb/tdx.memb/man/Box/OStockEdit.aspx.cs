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
using Telerik.Charting;
namespace tdx.memb.box
{
    public partial class OStockEdit : System.Web.UI.Page
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
            string instrockid =string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"];
            Instocknum.Text = instrockid.ObjToStr();
            instockdatetime.Text = DateTime.Now.ObjToStr();
            //品名
            instockuser();
            gongyinshang();
            area();
            jd();
            warehouse();
            kw();
            string sql = @" select a.出库类型,a.位置,e.id as 区域id,d.id as 酒店id,c.id as 仓库id,b.id as 库位id 
from WP_出库表 a left join WP_库位表 b on a.库位id=b.id left join WP_仓库表 c on b.仓库id=c.id left join WP_酒店表 d on c.酒店id=d.id left join WP_地区表 e on d.区域id=e.id where 单据编号='" + instrockid + "'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                //ddl_shen.Items.FindByValue("区域id").Selected = true;
                //ddl_hotel.Items.FindByValue("酒店id").Selected = true;
                //ddl_warehouse.Items.FindByValue("仓库id").Selected = true;
                //ddl_kw.Items.FindByValue("库位id").Selected = true;
                ddl_shen.SelectedValue = dt.Rows[0]["区域id"].ObjToStr();
                ddl_hotel.SelectedValue = dt.Rows[0]["酒店id"].ObjToStr();
                ddl_warehouse.SelectedValue = dt.Rows[0]["仓库id"].ObjToStr();
                ddl_kw.SelectedValue = dt.Rows[0]["库位id"].ObjToStr();
                rklx_ddl.SelectedValue = dt.Rows[0]["出库类型"].ObjToStr();
                
            }
            ddl_shen.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            rukuleixing();
            // string userid = new DTcms.BLL.manager_role().GetTitle(admin_info.role_id).ObjToStr();
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
            string sql = "select id as 商品id1,品名 as 品名1 from WP_商品表 where IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(sql);
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
            string sql = "select 编号 as id,公司名称 from Wp_客户资料 where 是否供应商 = 1";
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
            dt1.Rows.Add(1, "正常出库");
            dt1.Rows.Add(2, "其他出库");
            dt1.Rows.Add(3, "转出库");
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
            string sql = "select id,名称 from WP_地区表 where  父级id is null "; 
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_shen.DataTextField = "名称";
            ddl_shen.DataValueField = "id";
            ddl_shen.DataSource = dt;
            ddl_shen.DataBind();
        }
        //jd
        private void jd()
        {
           // string shenid = ddl_shen.SelectedValue;
            string jd = "select id,酒店全称 from WP_酒店表 where IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(jd);
            ddl_hotel.DataTextField = "酒店全称";
            ddl_hotel.DataValueField = "id";
            ddl_hotel.DataSource = dt;
            ddl_hotel.DataBind();
        }
        //ck
        private void warehouse()
        {
            //string jdid = ddl_hotel.SelectedValue;
            string warehouse = "select id,仓库名 from WP_仓库表 where IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(warehouse);
            ddl_warehouse.DataTextField = "仓库名";
            ddl_warehouse.DataValueField = "id";
            ddl_warehouse.DataSource = dt;
            ddl_warehouse.DataBind();
        }
        //kw
        private void kw()
        {
           // string warehouseid = ddl_warehouse.SelectedValue;
            string kw = "select id,库位名 from WP_库位表 where 箱子MAC is null and IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(kw);
            ddl_kw.DataTextField = "库位名";
            ddl_kw.DataValueField = "id";
            ddl_kw.DataSource = dt;
            ddl_kw.DataBind();
        }
        //protected void wz_bound()
        //{
        //    ddl_wz.Items.Insert(0, new ListItem("--1--", "1"));
        //    ddl_wz.Items.Insert(0, new ListItem("--2--", "2"));
        //    ddl_wz.Items.Insert(0, new ListItem("--3--", "3"));
        //    ddl_wz.Items.Insert(0, new ListItem("--4--", "4"));
        //    ddl_wz.Items.Insert(0, new ListItem("--5--", "5"));
        //    ddl_wz.Items.Insert(0, new ListItem("--6--", "6"));
        //    ddl_wz.Items.Insert(0, new ListItem("--7--", "7"));
        //    ddl_wz.Items.Insert(0, new ListItem("--8--", "8"));
        //    ddl_wz.Items.Insert(0, new ListItem("--9--", "9"));
        //    ddl_wz.Items.Insert(0, new ListItem("--10--", "10"));
        //    ddl_wz.Items.Insert(0, new ListItem("--11--", "11"));
        //    ddl_wz.Items.Insert(0, new ListItem("--12--", "12"));
        //}
        //省
        protected void ddl_shen_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ddl_hotel.Items.Clear();
            ddl_warehouse.Items.Clear();
            ddl_kw.Items.Clear();
           // ddl_wz.Items.Clear();
            jd();
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
          //  ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        //酒店
        protected void ddl_hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_warehouse.Items.Clear();
            ddl_kw.Items.Clear();
          //  ddl_wz.Items.Clear();
            warehouse();
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            //ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        //仓库
        protected void ddl_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_kw.Items.Clear();
            //ddl_wz.Items.Clear();
            kw();
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
            //ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        //库位
        protected void ddl_kw_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   ddl_wz.Items.Clear();
            //wz_bound();
            //ddl_wz.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        //箱子
        protected void ddl_wz_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
        #region 入库列表databound事件
        protected void product_rep_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {

            var item = e.Item.FindControl("rows") as OutRows;
            var equ_list = string.IsNullOrEmpty(json_memory.Value) ? new List<Newlistmem>() : JsonConvert.DeserializeObject<List<Newlistmem>>(json_memory.Value);
            if (equ_list.Count() < item.itemindex + 1)
                item.loadInit(new Newlistmem());
            else
                item.loadInit(equ_list[item.itemindex]);
        }
        #endregion
        #region
        protected void product_rep_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            //插入数据
            string instrockid = string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"];

            if (eidtlbl.Text != null&& eidtlbl.Text != string.Empty )
                {
                    this.product_rep.DataSource = new int[int.Parse(counter.Value)];
                }
                else
                {
                    string sql = @"select  WP_酒店表.酒店全称,WP_地区表.名称,WP_出库表.id,单据编号,WP_出库表.商品id,WP_出库表.位置,WP_商品表.品名,数量,出价,总出价额,备注,WP_出库表.库位id,位置,操作id,dt_manager.[user_name],出库类型,WP_库位表.库位名,WP_库位表.箱子号,WP_库位表.仓库id,WP_仓库表.酒店id,WP_酒店表.区域id 
                      from WP_出库表 left join WP_库位表 on WP_库位表.id=WP_出库表.库位id left join WP_仓库表 on WP_仓库表.id=WP_库位表.仓库id left join WP_酒店表 on WP_酒店表.id=WP_仓库表.酒店id left join WP_地区表 on WP_地区表.id=WP_酒店表.区域id left join dt_manager on dt_manager.id=WP_出库表.操作id left join WP_商品表 on WP_商品表.id=商品id  
                        where 单据编号='"+instrockid+"'";//'"+instrockid+"'";
                    DataTable dt = comfun.GetDataTableBySQL(sql);
                    var itemList = new List<Newlistmem>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Newlistmem equ = new Newlistmem();
                        //  Product product=new Product();
                        equ.id_txtbox = dt.Rows[i]["商品id"].ObjToStr();
                        string sql_kc = "select 库存数 from 视图在库表 where 商品id='" + dt.Rows[i]["商品id"].ObjToStr() + "' and 库位id='" + dt.Rows[i]["库位id"].ObjToStr() + "'";
                        DataTable kc_dt = comfun.GetDataTableBySQL(sql_kc);
                        equ.goods_cbox = dt.Rows[i]["品名"].ObjToStr();
                        if (kc_dt.Rows.Count > 0)
                        {
                            equ.kc_txtbox = kc_dt.Rows[0]["库存数"].ObjToStr();
                        }
                        else {
                            equ.kc_txtbox = "0";
                        }
                        
                        equ.rk_txtbox = dt.Rows[i]["数量"].ObjToStr();
                        equ.price_txtbox = dt.Rows[i]["出价"].ObjToStr();
                        equ.totalprice_txtbox = dt.Rows[i]["总出价额"].ObjToStr();
                        equ.remark_txtbox = dt.Rows[i]["备注"].ObjToStr();
                        equ.count_txtbox = "";// dt.Rows[i]["商品id"].ObjToStr();
                        equ.editrow_txtbox = dt.Rows[i]["id"].ObjToStr();
                        itemList.Add(equ);
                    }
                    ddl_shen.SelectedValue = dt.Rows[0]["名称"].ObjToStr();
                ddl_hotel.SelectedValue=dt.Rows[0]["酒店全称"].ObjToStr();
                    json_memory.Value = JsonConvert.SerializeObject(itemList);
                    counter.Value = dt.Rows.Count.ObjToStr();
                    eidtlbl.Text = dt.Rows.Count.ObjToStr();
                    this.product_rep.DataSource = new int[int.Parse(counter.Value)];
                }      


        }
        #endregion

        protected void plus_ServerClick(object sender, EventArgs e)
        {
            counter.Value = (int.Parse(counter.Value) + 1).ObjToStr();
            var equ_list = product_rep.Items.Select(o => (o.FindControl("rows") as OutRows)).Select(o => o.getlistmem()).ToList();

            json_memory.Value = JsonConvert.SerializeObject(equ_list);
            //int count = Convert.ToInt32(counter.Value);
            product_rep.Rebind();

        }



        protected void Btnrk_Click(object sender, EventArgs e)
        {
            int gys = Convert.ToInt32(gongyinshang_ddl.SelectedValue);
            int czy = Convert.ToInt32(instockuser_ddl.SelectedValue);
            int rklx = Convert.ToInt32(rklx_ddl.SelectedValue);
            int kwid = Convert.ToInt32(ddl_kw.SelectedValue);
            //var data_list = JsonConvert.DeserializeObject<List<Newlistmem>>(json_memory.Value);
            var equ_list = product_rep.Items.Select(o => (o.FindControl("rows") as OutRows)).Select(o => o.getlistmem()).ToList();
            int flag = 0;
            int ff = 0;
            if (gys != 0 && czy != 0 && kwid != 0)
            {
                foreach (Newlistmem item in equ_list)
                {
                    ff = ff + 1;
                    string id = item.id_txtbox;
                    string sel_sql = @"select id from WP_入库表 where 单据编号='" + Instocknum.Text + "'";
                    DataTable dt = comfun.GetDataTableBySQL(sel_sql);//查这个编号有多少条记录
                        if(dt.Rows.Count<=equ_list.Count){
                            if (ff <= dt.Rows.Count)
                            {//循环的次数小于已有记录数的时候，只修改
                                if (id != "" && id != null && kwid != 0)
                               {
                                    string sql = "update WP_出库表 set 商品id='" + item.id_txtbox + "',数量='" + item.rk_txtbox + "',出价='" + item.price_txtbox + "',总出价额='" + item.totalprice_txtbox + "',库位id='" + kwid + "',操作id='" + czy + "',出库类型='" + rklx + "',备注='" + item.remark_txtbox + "' where id='" + item.editrow_txtbox + "'";
                                    flag = new comfun().Update(sql);
                               }
                            }else{//超过原有的时候增加 
                                string sql = @" insert into WP_出库表(操作日期,单据编号,商品id,数量,出价,总出价额,库位id,操作id,出库类型,备注)values('" + DateTime.Now.ToUniversalTime().ToString() + "','" + Instocknum.Text + "','" + item.id_txtbox + "','" + item.rk_txtbox + "','" + item.price_txtbox + "','" + item.totalprice_txtbox + "','" + kwid + "','" + czy + "','" + rklx + "','" + item.remark_txtbox + "')";
                                flag=new comfun().Insert(sql);
                            }
                              if (flag == 0)
                                    {
                                        break;
                                    }
                        }
                           }
                }else {
                    MessageBox.Show(this, "请确认数据填写完整！");
                    return;
                }
                if (flag != 0)
                {
                    MessageBox.ShowAndRedirect(this, "修改成功！", "OutStockList.aspx");
                }
                else {
                    MessageBox.Show(this, "修改失败！");
                }
                
            }


       

    }
}