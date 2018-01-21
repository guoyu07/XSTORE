using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Box
{
    /// <summary>
    /// lx  依据类型
    /// 1 换货申请
    /// 2 箱子换房申请
    /// </summary>


    public partial class ApplicationManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string lx = Request["lx"].ObjToStr();
                if (lx == "1")
                {
                    changeGoods();
                }
                else {
                    changeBox();
                }

            }
        }
        protected void changeGoods() {
            string id = Request["id"].ObjToStr();
            string sql = @"select 原商品id,新商品id from WP_换货表 where  id="+id;
            DataTable dt = new comfun().GetDataTable(sql);
            dt.Columns.Add("原来的", typeof(string));
            dt.Columns.Add("新的", typeof(string));
            if (dt.Rows.Count > 0)
            {
                    DataTable dtb = new comfun().GetDataTable(@"select 品名 from WP_商品表 where id=" + dt.Rows[0]["原商品id"]);
                    if (dtb.Rows.Count > 0)
                    {
                        dt.Rows[0]["原来的"] = dtb.Rows[0]["品名"];
                    }
                    DataTable dtc = new comfun().GetDataTable(@"select 品名 from WP_商品表 where id=" + dt.Rows[0]["新商品id"]);
                    if (dtb.Rows.Count > 0)
                    {
                        dt.Rows[0]["新的"] = dtc.Rows[0]["品名"];
                    }
            }
            Rp_changeGoods.DataSource = dt;
            Rp_changeGoods.DataBind();
        }

        protected void changeBox()
        {
            string id = Request["id"].ObjToStr();
            string sql = @"select 原库位id,新库位id from WP_换箱表 where  id=" + id;
            DataTable dt = new comfun().GetDataTable(sql);
            dt.Columns.Add("原来的", typeof(string));
            dt.Columns.Add("新的", typeof(string));
            if (dt.Rows.Count > 0)
            {
                DataTable dtb = new comfun().GetDataTable(@"select 库位名 from WP_库位表 where id=" + dt.Rows[0]["原库位id"]);
                if (dtb.Rows.Count > 0)
                {
                    dt.Rows[0]["原来的"] = dtb.Rows[0]["库位名"];
                }
                DataTable dtc = new comfun().GetDataTable(@"select 库位名 from WP_库位表 where id=" + dt.Rows[0]["新库位id"]);
                if (dtb.Rows.Count > 0)
                {
                    dt.Rows[0]["新的"] = dtc.Rows[0]["库位名"];
                }
            }
            Rp_changeGoods.DataSource = dt;
            Rp_changeGoods.DataBind();
        }

        //同意
        protected void BtnYes_Click(object sender, EventArgs e)
        {
            string id = Request["id"].ObjToStr();//申请表id
            string lx = Request["lx"].ObjToStr();
            int flag =0;
            int flag2 = 0;
            if (lx == "1")
            {//换货
                flag = new comfun().Update(@"update WP_换货表 set 状态=2 where id=" + id);
                DataTable dt = new comfun().GetDataTable(@"select 箱子id,新商品id from WP_换货表 where id=" + id);
                flag2 = new comfun().Update(@"update WP_箱子表 set 实际商品id="+dt.Rows[0]["新商品id"]+" where id=" + dt.Rows[0]["箱子id"]);
            }
            else {//换箱
                flag = new comfun().Update(@"update WP_换箱表 set 状态=2 where id=" + id);
                DataTable dt = new comfun().GetDataTable(@"select mac,原库位id,新库位id from WP_换箱表 where id=" + id);
                flag2 = new comfun().Update(@"update WP_库位表 set 箱子MAC='" + dt.Rows[0]["mac"] + "' where id=" + dt.Rows[0]["新库位id"]);
                if(flag2==0){
                    return;
                }
                flag2 = new comfun().Update(@"update WP_库位表 set 箱子MAC='NULL' where id=" + dt.Rows[0]["原库位id"]);
                if (flag2 == 0)
                {
                    return;
                }
                flag2 = new comfun().Update(@"update WP_箱子表 set 库位id="+dt.Rows[0]["新库位id"]+" where 库位id="+dt.Rows[0]["原库位id"]);
            }
            
            if (flag != 0&& flag2!=0)
            {
                string js = @"<Script language='JavaScript'>
                    alert('操作成功!');</Script>";
                HttpContext.Current.Response.Write(js);
                string js2 = @"<Script language='JavaScript'>window.close();</Script>";
                HttpContext.Current.Response.Write(js2);
            }
            else {
                MessageBox.Show(this, "操作失败!");
            }
        }
        //拒绝
        protected void BtnNo_Click(object sender, EventArgs e)
        {
            string id = Request["id"].ObjToStr();
            string lx = Request["lx"].ObjToStr();
            int flag = 0;
            if (lx == "1")
            {//换货
                flag = new comfun().Update(@"update WP_换货表 set 状态=3 where id=" + id);
            }
            else {
                flag = new comfun().Update(@"update WP_换箱表 set 状态=3 where id=" + id);
            }
            if (flag != 0)
            {
                string js = @"<Script language='JavaScript'>
                    alert('操作成功!');</Script>";
                HttpContext.Current.Response.Write(js);
                string js2 = @"<Script language='JavaScript'>window.close();</Script>";
                HttpContext.Current.Response.Write(js2);
            }
            else
            {
                string js = @"<Script language='JavaScript'>
                    alert('操作失败!');</Script>";
                HttpContext.Current.Response.Write(js);
            }

        }

    }
}