using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.HotelWarehouse
{
    public partial class RegionEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            if (id != -1)
            {//修改
                bind(id);
            }
        }
        protected void bind(int id) {
            string sql = @"select id,名称,区号 from WP_地区表 where 是否删除=0 and id="+id;
            DataTable dt = new comfun().GetDataTable(sql);
            if(dt.Rows.Count>0){
                txt_region.Text = dt.Rows[0]["名称"].ObjToStr();
                txt_AreaCode.Text = dt.Rows[0]["区号"].ObjToStr();
            }
        }
        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string region_name = txt_region.Text.ObjToStr();//地区名
            string areacode = txt_AreaCode.Text.ObjToStr();//区号
            if(region_name==""){
                MessageBox.Show(this, "请填写地区名!");
                return;
            } 
           
            if(qh.InnerText!=""){
                MessageBox.Show(this,"请修改区号!");
                return;
            }

            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            int flag=0;
            if (id != -1)
            {//修改
                string up_sql = @"update WP_地区表 set 名称='"+region_name+"',区号='"+areacode+"' where id="+id;
                flag=new comfun().Update(up_sql);
            }
            else {
                string time = System.DateTime.Now.ToString();
                string ins_sql = @"insert into WP_地区表 (名称,区号,创建时间,是否删除)values('" + region_name + "','" + areacode + "','" + time + "','0')";
                flag=new comfun().Insert(ins_sql);
            }
            if(flag!=0){
                MessageBox.ShowAndRedirect(this,"操作成功!","Region.aspx");
               return;
            }
            MessageBox.Show(this,"操作失败!");
        }
    

    }
}