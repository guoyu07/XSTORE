using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Model;
using Creatrue.Common.Msgbox;

namespace tdx.memb.man.Box
{
    public partial class boxMAe : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                area();
            }
        }
        //绑定品名
        protected void area() {
            rcb_mr.Items.Clear();
            rcb_sj.Items.Clear();

            string sel_sql = @"select id,品名 from 视图商品信息表 where IsShow=1 and 是否单样 <> 1";
            DataTable dt=comfun.GetDataTableBySQL(sel_sql);
            rcb_mr.DataSource = dt;
            rcb_mr.DataBind();
            
            rcb_sj.DataSource = dt;
            rcb_sj.DataBind();
        }
        public int itemindex { get; set; }//行数
        protected void del_Click(object sender, EventArgs e)
        {
            if (editrow_textbox.Text != "")
            {
                int flag = new comfun().Update("update WP_箱子表 set IsShow=0 where 位置=" + (this.itemindex + 1).ObjToStr() + " and 库位id=" + editrow_textbox.Text);
                this.Parent.Controls.Remove(this);
                this.itemindex = this.itemindex - 1;
                number.Value = itemindex.ObjToStr();
            }
            else {
                this.Parent.Controls.Remove(this);
                this.itemindex = this.itemindex - 1;
            }
          
        }

        public string getnumber() {
            if(items.Value.ObjToStr()!=""){
                return items.Value.ObjToStr();
            }

            return this.itemindex.ObjToStr();
        }
            public boxManage_model getlistmem()
            {
            boxManage_model equ = new boxManage_model();
            equ.wz = (this.itemindex+1).ObjToStr();
           // items.Value = this.itemindex.ObjToStr();
            equ.hotel_name=hotel_name.Text.Trim().ObjToStr();
            equ.ck = ck.Text.Trim().ObjToStr();
            equ.kw = kw.Text.Trim().ObjToStr();
            equ.mac = mac.Text.Trim().ObjToStr();
            equ.kwid = editrow_textbox.Text.Trim().ObjToStr();
            if (rcb_mr.SelectedValue == "")
            {
                equ.mr_goods = " ";
            }
            else {
                equ.mr_goods = rcb_mr.SelectedValue;
            }
            if (rcb_sj.SelectedValue=="")
            {
                equ.sj_goods = " ";
            }
            else
            {
                equ.sj_goods = rcb_sj.SelectedValue;
            }
            
            return equ;
        }

            public void loadInit(boxManage_model equ)
            {
                area();
                SetDefaultValue(equ);
            }

            public void SetDefaultValue(boxManage_model equ)
            {
                //wz.Text = equ.wz;
                hotel_name.Text = equ.hotel_name;
                ck.Text = equ.ck;
                kw.Text = equ.kw;
                mac.Text = equ.mac;
                rcb_mr.Text = equ.mr_goods;
                rcb_sj.Text = equ.sj_goods;
                editrow_textbox.Text = equ.kwid;
            }
    }
}