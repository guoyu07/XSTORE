using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.memb.box;
using DTcms.Model;
using Newtonsoft.Json;
using Creatrue.Common.Msgbox;

namespace tdx.memb.man.Box
{
    public partial class boxManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bind();
            }
        
        }
        protected void bind() {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            string goods_sql = @"select 库位,地区id, 名称,酒店全称,酒店id,仓库id,仓库,库位id,箱子id,库位,mac,位置,默认商品id,实际商品id from 视图库位表 where 库位id=" + id + " and 酒店IsShow=1 and 仓库IsShow=1 and 库位IsShow=1";
            DataTable dtx = new comfun().GetDataTable(goods_sql);
           
            if (dtx.Rows.Count < 12)
            {
                counter.Value = "12";
            }
            else {
                counter.Value = dtx.Rows.Count.ObjToStr();
            }
        }

        //查这个房间的箱子并绑定数据
        protected void product_rep_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            if (eidtlbl.Text != null && eidtlbl.Text != string.Empty)
            {
                this.product_rep.DataSource = new int[int.Parse(counter.Value)];
            }
            else
            {
                string goods_sql = @"select 库位,地区id, 名称,酒店全称,酒店id,仓库id,仓库,库位id,箱子id,库位,mac,位置,默认商品id,实际商品id from 视图库位表 where 库位id=" + id + " and 酒店IsShow=1 and 仓库IsShow=1 and 库位IsShow=1 and 箱子IsShow=1 and 数量=1";
                DataTable dtx = new comfun().GetDataTable(goods_sql);
                var itemList = new List<boxManage_model>();
                if(dtx.Rows.Count>0){
                   
                    for (int i = 0; i < dtx.Rows.Count;i++ )
                    {
                      
                        boxManage_model bmm = new boxManage_model();
                        bmm.hotel_name = dtx.Rows[i]["酒店全称"].ObjToStr();
                        bmm.ck = dtx.Rows[i]["仓库"].ObjToStr();
                        bmm.kw = dtx.Rows[i]["库位"].ObjToStr();
                        bmm.mac = dtx.Rows[i]["mac"].ObjToStr();
                        bmm.wz = (i+1).ObjToStr();
                        bmm.kwid = id.ObjToStr();//库位id
                        if (dtx.Rows[i]["默认商品id"].ObjToStr()!="")
                        {
                        DataTable dta=comfun.GetDataTableBySQL("select 品名 from WP_商品表 where id="+dtx.Rows[i]["默认商品id"].ObjToStr());
                            if(dta.Rows.Count>0){
                                bmm.mr_goods = dta.Rows[0]["品名"].ObjToStr();
                            }
                        }
                        if (dtx.Rows[i]["实际商品id"].ObjToStr()!="")
                        {
                          DataTable dtb = comfun.GetDataTableBySQL("select 品名 from WP_商品表 where id=" + dtx.Rows[i]["实际商品id"].ObjToStr());
                        if (dtb.Rows.Count > 0)
                        {
                            bmm.sj_goods = dtb.Rows[0]["品名"].ObjToStr();
                        }
                        }
                        itemList.Add(bmm);
                    }
                }
                json_memory.Value = JsonConvert.SerializeObject(itemList);
                //counter.Value = dtx.Rows.Count.ObjToStr();
                eidtlbl.Text = dtx.Rows.Count.ToString();
                this.product_rep.DataSource = new int[int.Parse(counter.Value)];
            }

        }
        
        //绑定
        protected void product_rep_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {

            var item = e.Item.FindControl("boxme") as boxMAe;
            var equ_list = string.IsNullOrEmpty(json_memory.Value) ? new List<boxManage_model>() : JsonConvert.DeserializeObject<List<boxManage_model>>(json_memory.Value);
            if (equ_list.Count() < item.itemindex + 1)
                item.loadInit(new boxManage_model());
            else
                item.loadInit(equ_list[item.itemindex]);
        }
        //增加项
        protected void plus_ServerClick(object sender, EventArgs e)
        {
            counter.Value = (int.Parse(counter.Value) + 1).ToString();
            var equ_list = product_rep.Items.Select(o => (o.FindControl("boxme") as boxMAe)).Select(o => o.getlistmem()).ToList();

            json_memory.Value = JsonConvert.SerializeObject(equ_list);
            product_rep.Rebind();

        }
        protected void Btnrk_Click(object sender, EventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);//库位id

            string sel_boxid = @" select id from WP_箱子表 where 库位id="+id+" and IsShow=1";
            DataTable dt=comfun.GetDataTableBySQL(sel_boxid);
            var equ_list = product_rep.Items.Select(o => (o.FindControl("boxme") as boxMAe)).Select(o => o.getlistmem()).ToList();
            int flag = 0;
             int i=1;
             //箱子中为空
            
                foreach (boxManage_model item in equ_list)
                {
                    string box_goods = @" select id from WP_箱子表 where 库位id=" + id + " and IsShow=1 and 位置=" +i;//看库位的有没有某个位置
                    DataTable dta = comfun.GetDataTableBySQL(box_goods);
                    
                    if (dta.Rows.Count > 0)
                    {//有设置位置
                        string sql = "update WP_箱子表 set 默认商品id='" + item.mr_goods + "',实际商品id='" + item.sj_goods + "' ,IsShow=1 where 库位id='" + id + "' and 位置='" + i+"' ";
                        flag = new comfun().Update(sql);
                    }
                    else//没有设置位置
                    {
                        string sql = @" insert into WP_箱子表(位置,默认商品id,实际商品id,库位id,数量)values('" +i + "','" + item.mr_goods + " ','" + item.mr_goods + " ','" + id + "',1)";
                        flag = new comfun().Insert(sql);
                    }
                    if (flag == 0)
                    {
                        break;
                    }
                    i = i + 1;
                }
            
            
                MessageBox.ShowAndRedirect(this, "操作成功！", "../../man/HotelWarehouse/HotelWarehousekw.aspx");
            
           

        }
    

    }
}