using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.HotelWarehouse
{
    public partial class HotelContainer : System.Web.UI.Page
    {
        /// <summary>
        /// WP_箱子表中 status表示状态
        /// 1 在线
        /// 2 离线
        /// 3 故障
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bind();    
            }
        }

        protected void bind() {
            string sql = @" SELECT ('q_'+Convert(nvarchar(250),id)) as id, 名称 as name ,NULL as parentId FROM WP_地区表 
  UNION ALL
  SELECT  ('j_'+Convert(nvarchar(250),Id)) as id, 酒店全称 as name ,('q_'+Convert(nvarchar(250),区域id )) as parentId FROM WP_酒店表 
  where IsShow=1
  UNION ALL
  SELECT ('c_'+Convert(nvarchar(250),id)) as id, 仓库名 as name ,('j_'+Convert(nvarchar(250),酒店id)) as parentId FROM WP_仓库表 
  where IsShow=1";
            DataTable dt = new comfun().GetDataTable(sql);//
            if(dt.Rows.Count>0){
                string sql2 = @"SELECT Convert(nvarchar(250),NULL) as id,mac as name,Convert(nvarchar(250),NULL)  as parentId from 视图仓库箱子表 where 箱子IsShow=1 and 仓库IsShow=1 and 库位IsShow=1 and mac is not null group by mac";
               DataTable dta = new comfun().GetDataTable(sql2);//
                if(dta.Rows.Count>0){
                    for (int i = 0; i < dta.Rows.Count; i++)
                    {
                        DataTable dtb = new comfun().GetDataTable(@"select top 1 箱子id,仓库id from 视图仓库箱子表 where 箱子IsShow=1 and 仓库IsShow=1 and 库位IsShow=1 and mac='"+dta.Rows[i]["name"].ObjToStr()+" '");//
                        dta.Rows[i]["id"] = dtb.Rows[0]["箱子id"];
                        dta.Rows[i]["parentId"] = "C_" + dtb.Rows[0]["仓库id"].ObjToStr();
                        dt.Rows.Add(dta.Rows[i].ItemArray);
                    }
                    
                }
                }
            DataTable dtc=dtAdd(dt);
            rtv_status.DataSource = dtc;
            rtv_status.DataTextField = "name";
            rtv_status.DataFieldID = "id";
            rtv_status.DataValueField = "id";
            rtv_status.DataFieldParentID = "parentId";
            rtv_status.DataBind();
        }

        protected DataTable dtAdd(DataTable dt) {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i]["id"].ObjToStr().IndexOf("q")!=-1){//不等于-1的时候省份为条件,   取区域id
                    string[] str=dt.Rows[i]["id"].ObjToStr().Split('_');
                    DataTable dtc = dt_mac_sql(" and d.id=" + str[1]);
                    DataTable dtd = dt_sql("and 状态=1 and c.id=" + str[1]);//在线
                    DataTable dte = dt_sql("and 状态=2 and c.id=" + str[1]);//离线
                    DataTable dtf = dt_sql("and 状态=3 and c.id=" + str[1]);//故障
                    dt.Rows[i]["name"] = dt.Rows[i]["name"] + "   总数:" + dtc.Rows.Count+"   在线:"+dtd.Rows.Count+"   离线:"+dte.Rows.Count+"   故障:"+dtf.Rows.Count;
                }
                if (dt.Rows[i]["id"].ObjToStr().IndexOf("j") != -1)
                {//不等于-1的时候酒店集团为条件,   取酒店id
                    string[] str = dt.Rows[i]["id"].ObjToStr().Split('_');
                    DataTable dtb = dt_mac_sql("and a.酒店id=" + str[1]);
                    DataTable dtc = dt_sql("and 状态=1 and a.酒店id=" + str[1]);//在线
                    DataTable dtd = dt_sql("and 状态=2 and a.酒店id=" + str[1]);//离线
                    DataTable dte = dt_sql("and 状态=3 and a.酒店id=" + str[1]);//故障
                    dt.Rows[i]["name"] = dt.Rows[i]["name"] + "   总数:" + dtb.Rows.Count+"   在线:"+dtc.Rows.Count+"   离线:"+dtd.Rows.Count+"   故障:"+dte.Rows.Count;
                    
                }
                if (dt.Rows[i]["id"].ObjToStr().IndexOf("c") != -1)
                {//不等于-1的时候酒店为条件,   取仓库id
                    string[] str = dt.Rows[i]["id"].ObjToStr().Split('_');
                    DataTable dtb = dt_mac_sql("and b.id=" + str[1]);
                    DataTable dtc =dt_sql("and 状态=1 and b.id=" + str[1]);
                    DataTable dtd = dt_sql("and 状态=2 and b.id=" + str[1]);
                    DataTable dte = dt_sql("and 状态=3 and b.id=" + str[1]);
                    dt.Rows[i]["name"] = dt.Rows[i]["name"] + "   总数:" + dtb.Rows.Count + "   在线:" + dtc.Rows.Count + "   离线:" + dtd.Rows.Count + "   故障:" + dte.Rows.Count;
                    
                }
              if (dt.Rows[i]["id"].ObjToStr().IndexOf("_") == -1)
              {//不等于-1的时候箱子为条件,   取箱子id
                  string str = dt.Rows[i]["id"].ObjToStr();
                  DataTable dtb = dt_mac_sql("and 箱子id=" + str);
                  if(dtb.Rows.Count>0){
                      string mac_sql = @"select case 状态 when '1' then '在线' when '2' then '离线' when '3' then '故障' end as 状态 
                                                from 视图仓库箱子表 
                    where 箱子IsShow=1 and 仓库IsShow=1 and 库位IsShow=1 and mac is not null and mac='" + dtb.Rows[0]["mac"] + "'";
                      DataTable dtc = new comfun().GetDataTable(mac_sql);
                      dt.Rows[i]["name"] = dt.Rows[i]["name"] +"   状态:" + dtc.Rows[0]["状态"];
                  }
                  
              }

            }

            return dt;
        }

        protected DataTable dt_mac_sql(string where_sql) {
            string sql = @"select mac 
                                            from 视图仓库箱子表 a left join WP_仓库表 b on a.仓库id=b.id left join WP_酒店表 c on b.酒店id=c.id left join WP_地区表 d on c.区域id=d.id  
                                            where 箱子IsShow=1 and 仓库IsShow=1 and 库位IsShow=1 and mac is not null "+where_sql +" group by mac";
          return  new comfun().GetDataTable(sql);//总数
        }
        protected DataTable dt_sql(string where_sql) {
            string str = @"  select count(状态) 
                                    from 视图仓库箱子表 a left join WP_仓库表 b on a.仓库id=b.id left join WP_酒店表 c on b.酒店id=c.id left join WP_地区表 d on c.区域id=d.id  
                                    where 箱子IsShow=1 and 仓库IsShow=1 and 库位IsShow=1 and mac is not null "+where_sql + " group by mac";
            return new comfun().GetDataTable(str);//在线
        }
    }
}