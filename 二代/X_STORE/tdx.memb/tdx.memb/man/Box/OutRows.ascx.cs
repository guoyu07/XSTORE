using Creatrue.kernel;
using DTcms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Telerik.Web.UI;
using DTcms.Common;
using System.Text.RegularExpressions;

namespace tdx.memb.box
{
    public partial class OutRows : System.Web.UI.UserControl
    {
        public int hotel_kw_id { get; set; }
       

        public void loadInit(Newlistmem equ)
        {
            comboboxBind();
            SetDefaultValue(equ);
        }
        public int itemindex { get; set; }

        public void comboboxBind()
        {
            int nu = ((DropDownList)this.Parent.Page.FindControl("ddl_kw")).SelectedValue.ObjToInt(0);
            if (nu > 0)
            {
                hotel_kw_id = nu;//获取父级页面的数据
            }
            else {
                hotel_kw_id =0;
            }
            string sql_sp = "select 商品id,品名 from 视图在库表 where 库位id='"+hotel_kw_id+"'";
           //string sql = "select id,品名 from WP_商品表";
           DataTable dt = comfun.GetDataTableBySQL(sql_sp);
           rcb_sp.DataSource = dt;
           rcb_sp.DataBind();
            
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
            txt_UnitPrice.Text = equ.price_txtbox;//单价
            lb_rental.Text = equ.totalprice_txtbox;//总价
            txtremark.Value = equ.remark_txtbox;//备注
            count_textbox.Text = equ.count_txtbox;//行数
            editrow_textbox.Text = equ.editrow_txtbox;//编辑时使用id
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
            equ.kc_txtbox = lblkc_num.Text.Trim();//库存
            equ.rk_txtbox = spnum.Text.Trim();//数量
            equ.price_txtbox = txt_UnitPrice.Text.Trim();//单价
            equ.totalprice_txtbox = lb_rental.Text.Trim();//总额
            equ.remark_txtbox = txtremark.Value.Trim();//备注
            equ.editrow_txtbox = editrow_textbox.Text.Trim();
            return equ;
        }
        //商品选中值改变
        protected void rcb_sp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string ss = rcb_sp.SelectedItem.ToString();
            int kw_id = Convert.ToInt32(((DropDownList)this.Parent.Page.FindControl("ddl_kw")).SelectedValue);
            int sp_id = Convert.ToInt32(rcb_sp.SelectedValue);
            if (sp_id != 0 && kw_id != 0)//)
            {
                string sql = "select 商品id,库存数 from 视图在库表 where 商品id='" + sp_id + "'";// 库位id='" + kw_id + "'and 
                DataTable dt_kcs = comfun.GetDataTableBySQL(sql);
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
        //是否正整数
        protected bool IsPositiveInteger(string ss)
        {
            Regex regex = new Regex(@"[1-9]\d*");
            return regex.IsMatch(ss);
        }
        protected void del_Click(object sender, EventArgs e)
        {
           // var p_listview = (RadListView)this.Page.Parent.FindControl("test");
           // p_listview.Items[itemindex].Remove();
           // p_listview.Items.RemoveAt(itemindex);
          //this.Page.Parent.Controls.Remove(this);
            if (editrow_textbox.Text != "")
            {
                MessageBox.Show("成功从数据库中删除！");
                int id = Convert.ToInt32(editrow_textbox.Text.ToString());
                string sql = "DELETE FROM [dbo].[WP_出库表] where id='" + id + "'";
                comfun.DelbySQL(sql);
            }
            else
            {
                MessageBox.Show("删除成功！");
                this.Parent.Controls.Remove(this);
                this.itemindex = this.itemindex - 1;
            }
        }

        #region 自动计算
        //string  zhengshu="^/d+(/./d)?$";
        //  string xs = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
        //string xs = "^/d+(/./d)?$";
        //string zzs = "^/d+$";
        protected void spnum_TextChanged(object sender, EventArgs e)
        {

        
                string sp = spnum.Text;
                if (!IsPositiveInteger(spnum.Text))
                {
                    MessageBox.Show("请填写正整数!");
                    return;
                }
                if (spnum.Text.ObjToInt(0) > lblkc_num.Text.ObjToInt(0))
                {
                    MessageBox.Show("出库的数量大于库存数!");
                    return;
                }
                string  kwid = ((DropDownList)this.Parent.Page.FindControl("ddl_kw")).SelectedValue;
                if (kwid != "0")
                {
                    string sql_sql = "  select [dbo].[统计出价额](" + rcb_sp.SelectedValue + "," + kwid + "," + sp + ",GETDATE()) as 总出价额";
                    DataTable dt = comfun.GetDataTableBySQL(sql_sql);
                    if (dt.Rows.Count > 0)
                    {
                        txt_UnitPrice.Text = (Utils.ObjToDecimal(dt.Rows[0]["总出价额"].ObjToStr(), 0) / spnum.Text.ObjToInt(0)).ObjToStr();//计算单价
                        lb_rental.Text = dt.Rows[0]["总出价额"].ObjToStr();
                    }
                }

            //string spsl = spnum.Text.ObjToStr();
            //string spdj = sp_price.Text.ObjToStr();
            //string spzj = totalprice.Text.ObjToStr();
            //if (spsl != "" && spsl != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spsl, zzs))
            //{//数量不为空
            //    if (spdj != "" && spdj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spdj, xs))//||&&spzj==""spzj==string.Empty
            //    {//数量 单价不为空
            //        spzj = (Convert.ToDecimal(spsl) * Convert.ToDecimal(spdj)).ObjToStr();
            //        totalprice.Text = spzj;
            //    }
            //    else if ((spzj != "" && spzj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spzj, xs)) && (spdj == "" || spdj == string.Empty))
            //    {//数量 总价 不为空
            //        spdj = (Convert.ToDecimal(spzj) / Convert.ToDecimal(spsl)).ObjToStr();
            //        sp_price.Text = spdj;
            //    }
            //    else
            //    {
            //        // System.Windows.Forms.MessageBox.Show("请输入正确数据");
            //    }
            //}
            //else if (spdj != "" && spdj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spdj, xs))
            //{//单价不为空
            //    if ((spsl != "" && spsl != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spsl, zzs)) && (spzj == "" || spzj == string.Empty))
            //    {//单价 数量不为空
            //        spzj = (Convert.ToDecimal(spsl) * Convert.ToDecimal(spdj)).ObjToStr();
            //        totalprice.Text = spzj;
            //    }
            //    else if ((spzj != "" && spzj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spzj, xs)) && (spsl == "" || spsl == string.Empty))
            //    {//单价 总价不为空
            //        spsl = (Convert.ToDecimal(spzj) / Convert.ToDecimal(spdj)).ObjToStr();
            //        spnum.Text = spsl;
            //    }
            //    else
            //    {
            //        // System.Windows.Forms.MessageBox.Show("请输入正确数据");
            //    }
            //}
            //else if (spzj != "" && spzj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spzj, xs))
            //{//总价不为空
            //    if ((spsl != "" && spsl != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spsl, zzs)) && (spdj == "" || spdj == string.Empty))
            //    {//总价 数量不为空
            //        spdj = (Convert.ToDecimal(spzj) / Convert.ToDecimal(spsl)).ObjToStr();
            //        sp_price.Text = spdj;
            //    }
            //    else if ((spzj != "" && spzj != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(spzj, xs)) && (spsl == "" || spsl == string.Empty))
            //    {//总价 单价不为空
            //        spsl = (Convert.ToDecimal(spzj) / Convert.ToDecimal(spdj)).ObjToStr();
            //        spnum.Text = spsl;
            //    }
            //    else
            //    {
            //        // System.Windows.Forms.MessageBox.Show("请输入正确数据");
            //    }

            //}
            //else
            //{
            //    System.Windows.Forms.MessageBox.Show("请输入正确数量");
            //}
        }
        #endregion
    }
}