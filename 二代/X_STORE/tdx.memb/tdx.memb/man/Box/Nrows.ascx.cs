using Creatrue.kernel;
using DTcms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Telerik.Web.UI;

namespace tdx.memb.box
{
    public partial class Nrows : System.Web.UI.UserControl
    {
        public int hotel_kw_id { get; set; }
        #region 暂时用不到
        //protected void rcb_sp_TextChanged(object sender, EventArgs e)
        //{
        //    if (rcb_sp.SelectedValue != null && hotel_kw_id != null)
        //    {
        //        int sp_id = Convert.ToInt32(rcb_sp.SelectedValue);
        //        int kw_id = Convert.ToInt32(hotel_kw_id);
        //        string sql = "select 库存数 from 视图在库表 where 库位id='" + kw_id + "'and 商品id='" + sp_id + "'";
        //        DataTable dt_kcs = comfun.GetDataTableBySQL(sql);
        //        lblsp_id.Text = sp_id.ToString();
        //        if (dt_kcs.Rows.Count == 0)
        //        {

        //            lblkc_num.Text = null;
        //        }
        //        else
        //        {
        //            lblkc_num.Text = dt_kcs.Rows[0]["库存数"].ToString();
        //        }
        //    }
        //}

        #endregion
        public void loadInit(Newlistmem equ)
        {
            comboboxBind();
            SetDefaultValue(equ);
        }
        public int itemindex { get; set; }
        public void comboboxBind()
        {
           // int rk_againid = ((HiddenField)this.Parent.Page.FindControl("rk_again")).Value.ObjToInt(0);
            int nu = ((DropDownList)this.Parent.Page.FindControl("ddl_warehouse")).SelectedValue.ObjToInt(0);
            
            if (nu > 0)
            {
                hotel_kw_id = nu;//获取父级页面的数据
            }
            else
            {
                hotel_kw_id = 0;
            }
            string sql = @"select 商品id,品名 from WP_酒店商品 a left join WP_仓库表 b on a.仓库id=b.id left join WP_商品表 c on a.商品id=c.id where b.IsShow=1 and a.IsShow=1 and 仓库id=" + hotel_kw_id;
           DataTable dt = comfun.GetDataTableBySQL(sql);
            if(dt.Rows.Count>0)
            {
                this.rcb_sp.DataSource = dt;
                this.rcb_sp.DataBind();
                
            }
            //if (rk_againid > 0)
            //{ //表示重新入库
            //    rcb_sp.SelectedValue = rk_againid.ObjToStr();
            //}
        }
        public void SetDefaultValue(Newlistmem equ)
        {
            if (equ.id_txtbox == null || string.IsNullOrEmpty(equ.id_txtbox))
            {
                return;
            }
           // rcb_sp.Items.FindItemByValue(equ.id_txtbox).Selected = true;//商品绑定
            rcb_sp.Text = equ.goods_cbox;
            lblkc_num.Text = equ.kc_txtbox;//库存
            spnum.Text = equ.rk_txtbox.ToString();//入库
            sp_price.Text = equ.price_txtbox;//单价
            totalprice.Text = equ.totalprice_txtbox;//总价
            txtremark.Value = equ.remark_txtbox;//备注
            count_textbox.Text = equ.count_txtbox;//行数
            editrow_textbox.Text= equ.editrow_txtbox;//编辑时使用id
        }

        public List<Newlistmem> Rowlist()
        {
            var equ_list = new List<Newlistmem>();
            //var count=count_textbox.Text.
            int count= Convert.ToInt32(count_textbox.Text);
            if(count!=0)
            {
                count = 1;
            }
            for(int i=0;i<count;i++)
            {
                var equ = getlistmem();
                if( string.IsNullOrEmpty(equ.goods_cbox))
                {
                    continue;
                }
                else
                {
                    equ_list.Add(getlistmem());
                }
            }
            return equ_list;
        }
        public Newlistmem getlistmem()
        {
            Newlistmem equ = new Newlistmem();
            equ.id_txtbox = string.IsNullOrEmpty(rcb_sp.SelectedValue) ? "0" : rcb_sp.SelectedItem.Value;//商品id
            equ.goods_cbox = string.IsNullOrEmpty(rcb_sp.SelectedValue) ? "" : rcb_sp.SelectedItem.Text;//商品
            equ.kc_txtbox = lblkc_num.Text.Trim();
            equ.rk_txtbox = spnum.Text.Trim();
            equ.price_txtbox = sp_price.Text.Trim();
            equ.totalprice_txtbox = totalprice.Text.Trim();
           equ.remark_txtbox = txtremark.Value.Trim();
            equ.editrow_txtbox = editrow_textbox.Text.Trim();
            return equ;
        }

        protected void rcb_sp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcb_sp.SelectedValue != null )//&& hotel_kw_id != null)
            {
                int sp_id = Convert.ToInt32(rcb_sp.SelectedValue);
              //  int kw_id = Convert.ToInt32(hotel_kw_id);
                string sql = "select 商品id,库存数 from 视图在库表 where 商品id='" + sp_id + "'";// 库位id='" + kw_id + "'and 
                DataTable dt_kcs = comfun.GetDataTableBySQL(sql);
                lblsp_id.Text = sp_id.ToString();
                if (dt_kcs.Rows.Count == 0)
                {

                    lblkc_num.Text = null;
                    lblsp_id.Text=null;
                }
                else
                {
                    lblkc_num.Text = dt_kcs.Rows[0]["库存数"].ToString();
                    lblsp_id.Text = sp_id.ToString();
                }
            }
        }
        protected void del_Click(object sender, EventArgs e)
        {
           // var p_listview = (RadListView)this.Page.Parent.FindControl("test");
           // p_listview.Items[itemindex].Remove();
           // p_listview.Items.RemoveAt(itemindex);
          //this.Page.Parent.Controls.Remove(this);
            if (editrow_textbox.Text != "")
            {
                MessageBox.Show("请填写公司名称!");
                int id = Convert.ToInt32(editrow_textbox.Text.ToString());
                string sql = "DELETE FROM [dbo].[WP_入库表] where id='"+id+"'";
                comfun.DelbySQL(sql);
            }
            else
            {
                this.Parent.Controls.Remove(this);
                this.itemindex = this.itemindex - 1;
            }
            MessageBox.Show("删除成功！");
          
        }
        #region 自动计算
        //string  zhengshu="^/d+(/./d)?$";
      //  string xs = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
        string xs = "^/d+(/./d)?$";
        string zzs = "^/d+$";

    
       

        protected void spnum_TextChanged(object sender, EventArgs e)
        {

            string spsl = spnum.Text.ObjToStr();
            string spdj = sp_price.Text.ObjToStr();
            string spzj = totalprice.Text.ObjToStr();
            if (spsl != "" && spsl != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spsl, zzs))
            {//数量不为空
                if (spdj != "" && spdj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spdj, xs))//||&&spzj==""spzj==string.Empty
                {//数量 单价不为空
                    spzj = (Convert.ToDecimal(spsl) * Convert.ToDecimal(spdj)).ObjToStr();
                    totalprice.Text = spzj;
                }
                else if ((spzj != "" && spzj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spzj, xs)) && (spdj == "" || spdj == string.Empty))
                {//数量 总价 不为空
                    spdj = (Convert.ToDecimal(spzj) / Convert.ToDecimal(spsl)).ObjToStr();
                    sp_price.Text = spdj;
                }
                else
                {
                    // System.Windows.Forms.MessageBox.Show("请输入正确数据");
                }
            }
            else if (spdj != "" && spdj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spdj, xs))
            {//单价不为空
                if ((spsl != "" && spsl != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spsl, zzs)) && (spzj == "" || spzj == string.Empty))
                {//单价 数量不为空
                    spzj = (Convert.ToDecimal(spsl) * Convert.ToDecimal(spdj)).ObjToStr();
                    totalprice.Text = spzj;
                }
                else if ((spzj != "" && spzj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spzj, xs)) && (spsl == "" || spsl == string.Empty))
                {//单价 总价不为空
                    spsl = (Convert.ToDecimal(spzj) / Convert.ToDecimal(spdj)).ObjToStr();
                    spnum.Text = spsl;
                }
                else
                {
                    // System.Windows.Forms.MessageBox.Show("请输入正确数据");
                }
            }
            else if (spzj != "" && spzj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spzj, xs))
            {//总价不为空
                if ((spsl != "" && spsl != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spsl, zzs)) && (spdj == "" || spdj == string.Empty))
                {//总价 数量不为空
                    spdj = (Convert.ToDecimal(spzj) / Convert.ToDecimal(spsl)).ObjToStr();
                    sp_price.Text = spdj;
                }
                else if ((spzj != "" && spzj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spzj, xs)) && (spsl == "" || spsl == string.Empty))
                {//总价 单价不为空
                    spsl = (Convert.ToDecimal(spzj) / Convert.ToDecimal(spdj)).ObjToStr();
                    spnum.Text = spsl;
                }
                else
                {
                    // System.Windows.Forms.MessageBox.Show("请输入正确数据");
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("请输入正确数量");
            }
        }
        #endregion

    }
}