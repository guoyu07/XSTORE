using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Box
{
    public partial class BoxEdit : System.Web.UI.Page
    {
        string box = DTRequest.GetQueryString("boxid");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (box != "0")//修改
                {

                    bindlist();
                    list();
                }
                else
                {
                    list();
                    area();
                }
            }

        }

        //绑定三个combox控件的输入
        protected void list()
        {
            //string mac_sql = @"select 箱子mac as mac from WP_箱子表";
            //DataTable dt=comfun.GetDataTableBySQL(mac_sql);
            //rcb_mac.DataSource = dt;
            //rcb_mac.DataBind();
            //string kw_sql = @"select 库位id,酒店全称,仓库,库位,Logo,创建时间 from 视图库位表 where 酒店IsShow=1 and 仓库IsShow=1 and 库位IsShow=1 ";
            //DataTable dt = comfun.GetDataTableBySQL(kw_sql);
            //rcb_kw.DataSource = dt;
            //rcb_kw.DataBind();

            string goods_sql = @" select id,图片路径,编号new,编号,品名,类别,单位,规格,重量,市场价,本站价,库存数量,限购数量,分销率,折扣率,是否卖家承担运费,上架时间,下架时间,IsShow,是否上架 from 视图商品信息表 where 1=1 and IsShow=1 ";
            DataTable dt2 = comfun.GetDataTableBySQL(goods_sql);
            rcb_mr.DataSource = dt2;
            rcb_mr.DataBind();
            rcb_sj.DataSource = dt2;
            rcb_sj.DataBind();
        }

        //查询所有的数据
        protected void bindlist()
        {

            DataTable dt = edit();
            assignment(dt);

        }

        #region 生成 商品编号 随机数
        public char[] random = {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };

        public string GeteRandomNumber(int Length)
        {
            StringBuilder randomstr = new StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                randomstr.Append(random[rd.Next(62)]);
            }
            return randomstr.ToString();
        }

        #endregion

        /// <summary>
        /// 修改
        /// </summary>
        protected DataTable edit()
        {
            // string goods_sql = " select  酒店id,酒店全称,仓库id,仓库,库位id,库位 from 视图库位表 where mac=" +mac;
            //            string goods_sql = "select id,箱子mac as mac,位置 from WP_箱子表 where 箱子mac="+mac;
            string box_id = DTRequest.GetQueryString("boxid");
            string wz = DTRequest.GetQueryString("wz");
            string goods_sql = @"select 地区id, 名称,酒店全称,酒店id,仓库id,仓库,库位id,箱子id,库位,mac,位置 from 视图库位表 where 箱子id=" + box_id + " and 位置=" + wz;
            DataTable dt = comfun.GetDataTableBySQL(goods_sql);
            if (dt.Rows.Count > 0)
            {

                dt.Columns.Add("默认商品", typeof(string));
                dt.Columns.Add("实际商品", typeof(string));
                DataTable dt1;
                DataTable dt2;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string sql1 = @"select A.编号new,A.类别号,A.品名,A.规格,A.单位,A.重量,A.序号,B.id as 箱子id,B.箱子号 as 箱子,B.箱子mac as mac,B.位置 as 位置 from WP_商品表 as A left join WP_箱子表 as B on A.Id=B.默认商品id where B.库位id= " + kuwei_id;
                    //string sql2 = @"select 编号new,类别号,品名,规格,单位,重量,序号 from WP_商品表 as A left join WP_箱子表 as B on A.Id=B.实际商品id where B.库位id= " + kuwei_id;
                    // string sql1 = @"select A.编号new,A.类别号,A.品名,A.规格,A.单位,A.重量,A.序号,B.箱子mac as mac,B.位置 as 位置 from WP_商品表 as A left join WP_箱子表 as B on A.Id=B.默认商品id where B.箱子mac=" + mac;
                    // string sql2 = @"select 编号new,类别号,品名,规格,单位,重量,序号 from WP_商品表 as A left join WP_箱子表 as B on A.Id=B.实际商品id where B.箱子mac="+mac;
                    string sql1 = @"select 品名 as 默认商品 from WP_箱子表 A left join WP_商品表 B on A.默认商品id=B.id where 1=1 and a.id=" + box_id + " and A.位置=" + wz;
                    string sql2 = @"select 品名 as 实际商品 from WP_箱子表 A left join WP_商品表 B on A.实际商品id=B.id where 1=1 and a.id=" + box_id + " and A.位置=" + wz;
                    dt1 = comfun.GetDataTableBySQL(sql1);
                    dt2 = comfun.GetDataTableBySQL(sql2);
                    dt.Rows[i]["默认商品"] = dt1.Rows[i]["默认商品"];
                    dt.Rows[i]["实际商品"] = dt2.Rows[i]["实际商品"];
                }
            }

            return dt;
        }

        //给控件初始赋值
        protected void assignment(DataTable dt)
        {
            //地区
            ddl_shen.DataSource = dt;
            ddl_shen.DataValueField = "地区id";
            ddl_shen.DataTextField = "名称";
            ddl_shen.DataBind();
            //酒店
            ddl_hotel.DataSource = dt;
            ddl_hotel.DataValueField = "酒店id";
            ddl_hotel.DataTextField = "酒店全称";
            ddl_hotel.DataBind();
            //仓库
            ddl_warehouse.DataSource = dt;
            ddl_warehouse.DataValueField = "仓库id";
            ddl_warehouse.DataTextField = "仓库";
            ddl_warehouse.DataBind();
            //库位
            ddl_kw.DataSource = dt;
            ddl_kw.DataValueField = "库位id";
            ddl_kw.DataTextField = "库位";
            ddl_kw.DataBind();
            // rcb_kw.Text = dt.Rows[0]["库位"].ObjToStr();
            mac_input.Text = dt.Rows[0]["MAC"].ObjToStr();//MAC
            ddl_wz.SelectedIndex = dt.Rows[0]["位置"].ObjToInt(0);
            rcb_mr.Text = dt.Rows[0]["默认商品"].ObjToStr();
            rcb_sj.Text = dt.Rows[0]["实际商品"].ObjToStr();
            hidd_boxid.Value = dt.Rows[0]["箱子id"].ObjToStr();
        }

        /// <summary>
        /// 提交保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string shen_id = ddl_shen.SelectedValue;//省
            string jd_id = ddl_hotel.SelectedValue;//酒店
            string ck_id = ddl_warehouse.SelectedValue;//仓库
            string kw_id = ddl_kw.SelectedValue;//库位
            string txt_mac = mac_input.Text;//箱子mac
            string wz = ddl_wz.SelectedValue;//位置
            int mr_goods = rcb_mr.SelectedValue.ObjToInt(0);//默认商品
            int sj_goods = rcb_sj.SelectedValue.ObjToInt(0);//实际商品

            if (shen_id == "0")
            {
                MessageBox.Show(this, "省不能为空");
                return;
            }
            if (jd_id == "0")
            {
                MessageBox.Show(this, "仓库不能为空");
                return;
            }
            if (ck_id == "0")
            {
                MessageBox.Show(this, "不能为空");
                return;
            }
            if (kw_id == "0")
            {
                MessageBox.Show(this, "库位不能为空");
                return;
            }
            if (txt_mac == "0")
            {
                MessageBox.Show(this, "MAC不能为空");
                return;
            }
            if (wz == "0")
            {
                MessageBox.Show(this, "位置不能为空");
                return;
            }
            if (mr_goods < 0)
            {
                MessageBox.Show(this, "默认商品不能为空");
                return;
            }
            if (sj_goods < 0)
            {
                MessageBox.Show(this, "实际商品不能为空");
                return;
            }

            string box = DTRequest.GetQueryString("boxid");
            int flag = 0;
            int flag2 = 0;
            if (box != "0")//   !=0 修改
            {//更新
                DataTable dts = edit();
                string up_sql = @"update WP_箱子表 set 库位id=" + kw_id + ",默认商品id=" + mr_goods + ",实际商品id=" + sj_goods + " where 库位id=" + kw_id+" and 位置="+wz;
                string up_sql2 = @"update WP_库位表 set 箱子MAC=" + mac_input.Text + " where id=" + kw_id;
                flag = comfun.UpdateBySQL(up_sql);
                 flag2 = comfun.UpdateBySQL(up_sql2);
            }
            else
            {//新增
                int lx = sel_box(kw_id, wz);
                if (lx == 1)
                {
                    MessageBox.Show(this, "已经有了,请换个位置");
                    return;
                }
                string in_sql = @"insert into WP_箱子表(默认商品id,实际商品id,库位id,位置) values(" + mr_goods + "," + sj_goods + "," + kw_id + "," + wz + ")";
                string in_sql2 = @"update WP_库位表 set 箱子MAC=" + mac_input.Text + " where id= " + kw_id;
                flag = comfun.InsertBySQL(in_sql);
                flag2 = comfun.InsertBySQL(in_sql2);
               // flag2 = 1;
            }
            if (flag > 0&& flag2>0)//判断操作是否成功
            {
                MessageBox.ShowAndRedirect(this, "操作成功", "BoxGoods.aspx");
            }
            else
            {
                MessageBox.Show(this, "操作失败");
                return;
            }
        }

        //查询库位里面是否有箱子了
        protected int sel_box(string kw_box_id, string wz)
        {
            string sql = @"select id from WP_箱子表 where 库位id=" + kw_box_id + " and 位置 =" + wz;
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {

                return 1; //这个位置已经有了
            }
            return 0;//这个位置还没有
        }


        //初始绑定地区
        private void area()
        {
            string sql = "select id,名称 from WP_地区表 where 名称 like '%省%' or 父级id is null"; //or 名称='全国'";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            ddl_shen.DataTextField = "名称";
            ddl_shen.DataValueField = "id";
            ddl_shen.DataSource = dt;
            ddl_shen.DataBind();
            ddl_shen.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        //省联动
        protected void ddl_shen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //shi();
            ddl_hotel.Items.Clear();
            ddl_warehouse.Items.Clear();
            ddl_kw.Items.Clear();
            //ddl_shi.Items.Insert(0, new ListItem("--请选择--", "0"));
            jd();//绑定酒店
            ddl_hotel.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        private void jd()
        {
            //select id,酒店简称 from WP_酒店表  where 区域id='2'
            //string shiid = ddl_shi.SelectedItem.Value;
            ddl_warehouse.Items.Clear();
            ddl_kw.Items.Clear();
            string shenid = ddl_shen.SelectedValue;
            string jd = "select id,酒店简称 from WP_酒店表  where 区域id= " + shenid + "  and IsShow=1 ";
            DataTable dt = comfun.GetDataTableBySQL(jd);
            ddl_hotel.DataTextField = "酒店简称";
            ddl_hotel.DataValueField = "id";
            ddl_hotel.DataSource = dt;
            ddl_hotel.DataBind();
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        //酒店联动
        protected void ddl_hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            warehouse();
            ddl_warehouse.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        //绑定仓库
        private void warehouse()
        {
            ddl_kw.Items.Clear();
            string jdid = ddl_hotel.SelectedValue;
            string warehouse = "select id,仓库名 from WP_仓库表 where 酒店id=" + jdid + " and IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(warehouse);
            ddl_warehouse.DataTextField = "仓库名";
            ddl_warehouse.DataValueField = "id";
            ddl_warehouse.DataSource = dt;
            ddl_warehouse.DataBind();
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        //仓库联动
        protected void ddl_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ckid = ddl_warehouse.SelectedValue;//仓库id
            string ck = @" select id,库位名 from WP_库位表 where 仓库id=" + ckid + " and IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(ck);//查出当前仓库的库位
            ddl_kw.DataSource = dt;//给库位赋值
            ddl_kw.DataTextField = "库位名";
            ddl_kw.DataValueField = "id";
            ddl_kw.DataBind();
            ddl_kw.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        protected void ddl_kw_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kwid = ddl_kw.SelectedValue;
            string mac_sql = @" select b.id,a.箱子MAC from WP_库位表 a left join WP_箱子表 b on a.id=b.库位id where b.库位id="+kwid;
            DataTable dt = comfun.GetDataTableBySQL(mac_sql);
            hiddid.Value = dt.Rows[0]["id"].ObjToStr();
            mac_input.Text=dt.Rows[0]["箱子mac"].ObjToStr();

        }



    }
}