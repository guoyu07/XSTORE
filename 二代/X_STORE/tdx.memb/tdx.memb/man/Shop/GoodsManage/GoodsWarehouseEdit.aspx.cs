using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common.Msgbox;
using System.Text;

namespace tdx.memb.man.Shop.GoodsManage
{
    public partial class GoodsWarehouseEdit : System.Web.UI.Page
    {
        string kuwei_id = "";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               DataTable ft= comfun.GetDataTableBySQL("select id,酒店全称 from WP_酒店表");
                if(ft.Rows.Count>0){
                    for (int i = 0; i < ft.Rows.Count;i++ )
                    {
                        grogshop_name.Items.Add(new ListItem(ft.Rows[i]["酒店全称"].ObjToStr(), ft.Rows[i]["id"].ObjToStr()));
                    }
                }
                

                kuwei_id = Request.QueryString["kuwei_id"];
                if (kuwei_id != "0")//修改
                {
                    bindlist();
                    ddl_store_val();
                }
                else {
                    ddl_store_val();
                }
            }

        }
       


        protected void bindlist()//查询所有的数据
        {

            DataTable dt= edit();
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
        protected DataTable edit() {
            string kuwei_id = Request.QueryString["kuwei_id"];
            string goods_sql = " select  酒店id,酒店全称,仓库id,仓库,库位id,库位 from 视图库位表 where 库位id=" + kuwei_id;
            DataTable dt = comfun.GetDataTableBySQL(goods_sql);
            if (dt.Rows.Count > 0)
            {
            
            dt.Columns.Add("默认商品", typeof(string));
            dt.Columns.Add("实际商品", typeof(string));
            dt.Columns.Add("箱子id", typeof(string));
            dt.Columns.Add("箱子", typeof(string));
            dt.Columns.Add("mac", typeof(string));
            dt.Columns.Add("位置", typeof(string));
            DataTable dt1;
            DataTable dt2;

           
                for(int i=0;i<dt.Rows.Count;i++){
                    string sql1 = @"select A.编号new,A.类别号,A.品名,A.规格,A.单位,A.重量,A.序号,B.id as 箱子id,B.箱子号 as 箱子,B.箱子mac as mac,B.位置 as 位置 from WP_商品表 as A left join WP_箱子表 as B on A.Id=B.默认商品id where B.库位id= " + kuwei_id;
                    string sql2 = @"select 编号new,类别号,品名,规格,单位,重量,序号 from WP_商品表 as A left join WP_箱子表 as B on A.Id=B.实际商品id where B.库位id= " + kuwei_id;

                     dt1 = comfun.GetDataTableBySQL(sql1);
                     dt2 = comfun.GetDataTableBySQL(sql2);
                     dt.Rows[i]["默认商品"]=dt1.Rows[i]["品名"];
                     dt.Rows[i]["默认商品"]=dt2.Rows[i]["品名"];
                     dt.Rows[i]["箱子id"] = dt1.Rows[i]["箱子id"];
                     dt.Rows[i]["箱子"] = dt1.Rows[i]["箱子"];
                     dt.Rows[i]["mac"] = dt1.Rows[i]["mac"];
                     dt.Rows[i]["位置"] = dt1.Rows[i]["位置"];
                }
              }
            
            return dt;
        }

        protected void assignment(DataTable dt) {//给控件赋值
            //grogshop.Text = dt.Rows[0]["酒店"].ObjToStr();//grogshop
            warehouse.Text = dt.Rows[0]["仓库"].ObjToStr();//仓库
            storagelocation.Text = dt.Rows[0]["库位"].ObjToStr();//库位
            box.Text = dt.Rows[0]["箱子"].ObjToStr();//箱子
            MACaspx.Text = dt.Rows[0]["MAC"].ObjToStr();//MAC
            location.Text = dt.Rows[0]["位置"].ObjToStr();//位置
            //ddlA_default_goods.Text = dt.Rows[0]["默认商品"].ObjToStr();//默认商品
            //ddlA_practical_goods.Text = dt.Rows[0]["实际商品"].ObjToStr();//实际商品
        }

        /// <summary>
        /// 提交保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string grogshop_click = grogshop_name.SelectedValue;
            string warehouse_click = warehouse.Text;
            string storagelocation_click = storagelocation.Text;
            string box_click = box.Text;
            string MAC_click = MACaspx.Text;
            string location_click = location.Text;
            //string ddlA_default_goods_click = ddlA_default_goods.Text;
            //string default_goods_click = default_goods.Text;
            if (grogshop_click == "0")
            {
                MessageBox.Show(this, "酒店不能为空！");
                return;
            }
            if (warehouse_click == "")
            {
                MessageBox.Show(this, "仓库不能为空！"); 
                return;
            }
            if (storagelocation_click == "")
            {
                MessageBox.Show(this, "库位不能为空！"); 
                return;
            }
            if (box_click == "")
            {
                MessageBox.Show(this,"箱子不能为空！"); 
                return;
            }
            if (MAC_click == "")
            {
                MessageBox.Show(this, "MAC不能为空！"); 
                return;
            }
            if (location_click == "")
            {
                MessageBox.Show(this, "位置不能为空！"); 
                return;
            }

            int flag = 0;
            int flag1=0;
            int flag2 = 0;
            if (kuwei_id !="" )//判断是更新还是插入
            {//更新
                DataTable dts= edit();
                flag = comfun.UpdateBySQL(@"update WP_仓库表 set 仓库名='" + warehouse_click + "' where 酒店id=" + dts.Rows[0]["酒店id"].ObjToInt(0)+"\n"+
                                                                "update WP_库位表 set 库位名='" + storagelocation_click + "' where 仓库id=" + dts.Rows[0]["仓库id"].ObjToInt(0));
             
            }
            else {//插入
                flag= comfun.InsertBySQL(@"insert into WP_仓库表 (仓库名,酒店id) values('" + warehouse_click + "',"+grogshop_name.SelectedValue.ObjToInt(0)+")");
                flag1=comfun.InsertBySQL("insert into WP_库位表 (库位名,仓库id) values('" + storagelocation_click + "','"+flag+"')");
                string max_id = Convert.ToString(comfun.GetDataSetBySQL("select max(id) as id from WP_库位表").Tables[0].Rows[0]["id"]);
                flag2 = comfun.InsertBySQL("insert into WP_箱子表(箱子号,默认商品id,实际商品id,库位id,箱子mac,位置) values('" + box_click + "'," + ddlA_defaule_goods_name.SelectedValue.ObjToInt(0) + "," + ddlA_practical_goods_name.SelectedValue.ObjToInt(0) + "," + max_id + "," + MAC_click + "," + box_click + ")");
             

            }
            if (flag > 0 )//判断操作是否成功
            {
                MessageBox.ShowAndRedirect(this, "操作成功", "GoodsWarehouseManage.aspx");
                return;
            }
            else
            {
                MessageBox.Show(this, "操作失败");
                
                return;
            }
        }

        /// <summary>
        ///动态绑定下拉框 
        /// </summary>
        protected void ddl_store_val()
        {
            string sql = @" select 类别名,id from WP_商品类别表 order by 类别编号";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddlA_default_goods.Items.Add(new ListItem(dt.Rows[i]["类别名"].ObjToStr(), dt.Rows[i]["类别名"].ObjToStr())); //绑定下拉框控件
                    ddlA_practical_goods.Items.Add(new ListItem(dt.Rows[i]["类别名"].ObjToStr(), dt.Rows[i]["类别名"].ObjToStr())); //绑定下拉框控件

                }
            }


        }
        //下拉框联动
        protected void ddlA_default_goods_SelectedIndexChanged(object sender, EventArgs e)
        {
            string defaule_goods_name = ddlA_default_goods.Text;//默认类别
            string sql =@" select A.品名,A.id from WP_商品表 as A left join WP_商品类别表 as B on A.类别号=B.类别编号 where 类别名='"+defaule_goods_name+"' order by A.品名";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddlA_defaule_goods_name.Items.Add(new ListItem(dt.Rows[i]["品名"].ObjToStr(), dt.Rows[i]["id"].ObjToStr())); //绑定下拉框控件
                }
            }
        }

        protected void ddlA_practical_goods_SelectedIndexChanged(object sender, EventArgs e)
        {
            string practical_goods_name = ddlA_practical_goods.Text;//实际商品名
            string sql = @" select A.品名,A.id from WP_商品表 as A left join WP_商品类别表 as B on A.类别号=B.类别编号 where 类别名='" + practical_goods_name + "' order by A.品名";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddlA_practical_goods_name.Items.Add(new ListItem(dt.Rows[i]["品名"].ObjToStr(), dt.Rows[i]["id"].ObjToStr())); //绑定下拉框控件
                }
            }
        }


    }
}