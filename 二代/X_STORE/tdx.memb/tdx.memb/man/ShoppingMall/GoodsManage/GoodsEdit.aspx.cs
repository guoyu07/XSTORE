using Creatrue.Common.Msgbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.DBUtility;
using tdx.database;
using Creatrue.kernel;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;
using System.Collections;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public  partial class GoodsEdit : System.Web.UI.Page
    {
        DTcms.BLL.WP_商品表 spbll = new DTcms.BLL.WP_商品表();

        DTcms.BLL.WP_商品详情表 spxqbll = new DTcms.BLL.WP_商品详情表();

        DTcms.Model.WP_商品表 spmodel = new DTcms.Model.WP_商品表();

        //DTcms.Model.WP_商品详情表 spxqmodel = new DTcms.Model.WP_商品详情表();

        public static int spxqid;

        public static int sptpid;
        protected string strTr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_bianhao.Text = GeteRandomNumber(18);
                
                string mon = "";

                if (int.Parse(DateTime.Now.Month.ObjToStr()) > 10)
                {
                    mon = "/" + DateTime.Now.Month.ObjToStr();
                }
                else
                {
                    mon = "/0" + DateTime.Now.Month.ObjToStr();
                }

                Jxl.Value = DateTime.Now.Year.ObjToStr() + mon + "/01";

                int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                Dropleibie();
                showgoods(id);
                if (Session["goods_combo_id"].ObjToStr()!="")//是组合套餐
                {
                    sel_combo_name();
                }
            }
        }


        DTcms.BLL.WP_category BLL_商品 = new DTcms.BLL.WP_category();
        private void Dropleibie()
        {
            DataSet ds = DbHelperSQL.Query("select * from WP_category where c_parent=0  order by c_id; ");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BLL_商品.getOneClassTree(Convert.ToInt32(dr["c_id"]), txt_leibiehao);
            }


        //    DataTable dt = DbHelperSQL.Query("select * from WP_FreightMain  order by id; ").Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "请选择";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    if (dt.Rows.Count > 0)
        //    {

        //        yunfeimoban.DataSource = dt;
        //        yunfeimoban.DataTextField = "name";
        //        yunfeimoban.DataValueField = "id";

        //        yunfeimoban.DataBind();

        //    }
        }
        //如果是组合套餐，查各自的名字并赋值到文本框
        protected void sel_combo_name() {
            string goods_combo_id=Session["goods_combo_id"].ObjToStr();//取出所有选中的单样商品id
           // List<string> list=goods_combo_id.Split(',');

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
            return randomstr.ObjToStr();
        }

        #endregion


        DataTable dtb;
        public int metering=0;//计次
        public void showgoods(int id)
        {
            //商品显示
        //    DataTable dtx = spbll.GetList("  id=" + id).Tables[0];
            DataTable dtx = DbHelperSQL.Query("select * from 视图商品信息表 where id=" + id).Tables[0];
            if (dtx.Rows.Count > 0)
            {
                txt_bianma.Text = dtx.Rows[0]["编码"].ObjToStr();
                txt_bianhao.Text = dtx.Rows[0]["编号"].ObjToStr();
                txt编号new.Value = dtx.Rows[0]["编号new"].ObjToStr();//条形码
                txt规格.Value = dtx.Rows[0]["规格"].ObjToStr();
                txt本站价.Value = dtx.Rows[0]["本站价"].ObjToStr();
                txt市场价.Value = dtx.Rows[0]["市场价"].ObjToStr();
                txt_danwei.Text = dtx.Rows[0]["单位"].ObjToStr();
                //txt_number1.Text = dtx.Rows[0]["序号"] != null ? dtx.Rows[0]["序号"].ObjToStr() : "99";
                txt重量.Value = dtx.Rows[0]["重量"].ObjToStr();
               // txt_分销率.Text = dtx.Rows[0]["分销率"].ObjToStr();
                txt_max_number.Text = dtx.Rows[0]["限购数量"].ObjToStr();
                txt库存.Value = dtx.Rows[0]["库存数量"].ObjToStr();
                txt_leibiehao.Value = dtx.Rows[0]["类别号"].ObjToStr();
                //yunfeimoban.Value = dtx.Rows[0]["运费模板"].ObjToStr();
                txt_pinming.Text = dtx.Rows[0]["品名"].ObjToStr();
                txt_shifoushangjia.SelectedValue = dtx.Rows[0]["是否上架"].ObjToStr();
                txt_spleibie.SelectedValue = dtx.Rows[0]["类型"].ObjToStr();
                Jxl.Value = dtx.Rows[0]["上架时间"].ObjToStr();
                Jx2.Value = dtx.Rows[0]["下架时间"].ObjToStr();
                isshow.Value = dtx.Rows[0]["IsShow"].ObjToStr();

                if (dtx.Rows[0]["限购数量"]!=null)
                    txt_max_number.Text = dtx.Rows[0]["限购数量"].ObjToStr();

                //txt_zhekou.Text = dtx.Rows[0]["折扣率"].ObjToStr();
             //   txt_yunfei.SelectedValue = dtx.Rows[0]["是否卖家承担运费"].ObjToStr();
                spxqid = int.Parse(dtx.Rows[0]["id"].ObjToStr());
                UEContent.Value = dtx.Rows[0]["描述"].ObjToStr();
                txt_tedian.Value = dtx.Rows[0]["特点"].ObjToStr();
                txt_zhuyishixiang.Value = dtx.Rows[0]["注意事项"].ObjToStr();
                txt_pinpaijieshao.Value = dtx.Rows[0]["品牌介绍"].ObjToStr();
                txt_zizhizhengming.Value = dtx.Rows[0]["资质证明"].ObjToStr();
                //}
                string _SqlShow = "select * from [WP_商品图片表] where 商品编号='" + dtx.Rows[0]["编号"].ObjToStr() + "' order by 序号 asc ";
                DataTable dt_show = DbHelperSQL.Query(_SqlShow).Tables[0];
                if (dt_show.Rows.Count > 0)
                {
                    //绑定展示图
                    rptManagementAttachList.DataSource = dt_show;
                    rptManagementAttachList.DataBind();
                }
            }
            else
            {
                this.Jxl.Value = "";
            }

        }
        //是否大于0
        protected bool shuzi2(string s) { 
            string pattern="([1-9]\\d*(\\.\\d*[1-9])?)";
              Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }
        //是否是正整数
        public bool shuzi(string s)
        {
            string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        //点击保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            

            if (txt_bianhao.Text.Trim() == "")
            {
                MessageBox.Show(this, "请正确填写编号！"); return;
            }
            if (txt规格.Value.Trim() == "")
            {
                MessageBox.Show(this, "请正确填写规格！"); return;
            }
          
            if (txt_danwei.Text.Trim() == "")
            {
                MessageBox.Show(this, "请正确填写单位！"); return;
            }
            if (txt_bianma.Text.Trim() == "")
            {
                MessageBox.Show(this, "请正确填写编码！"); return;
            }
            if(txt重量.Value.ObjToInt(0)<0){
                MessageBox.Show(this,"请正确填写重量"); return;
            }
            int xh = 99;
            //if (txt_number1.Text.Trim() != "")
            //{
            //    int.TryParse(txt_number1.Text.Trim(), out xh);
            //}
            if (txt编号new.Value.Trim() == "")
            {
                MessageBox.Show(this, "请正确填写条形码！"); return;
            }
            if (txt本站价.Value.Trim() == "")
            {
                MessageBox.Show(this, "请正确填写本站价！"); return;
            }
            //if (txt库存.Value.Trim() .ObjToInt(0)<0)
            //{
            //    MessageBox.Show(this, "库存数量需要输入大于0的正整数！"); return;
            //}
            if (txt_leibiehao.Value == "")
            {
                MessageBox.Show(this, "类别号不能为空！"); return;
            }
            if (txt_pinming.Text.Trim() == "")
            {
                MessageBox.Show(this, "品名不能为空！"); return;
            }
            if (!shuzi2(txt市场价.Value.ObjToStr()))
            {
                MessageBox.Show(this, "市场价输入有误!"); return;
            }
            if (!shuzi2(txt本站价.Value.ObjToStr()))
            {
                MessageBox.Show(this, "本站价输入有误！"); return;
            }
            if(!shuzi(txt库存.Value.ObjToStr())){
                MessageBox.Show(this, "库存数量输入有误"); return;
            }
            if (!shuzi(txt_max_number.Text.ObjToStr()))
            {
                MessageBox.Show(this, "限购数量输入有误"); return;
            }
            //if (!shuzi2(txt_分销率.Text.ObjToStr()))
            //{
            //    MessageBox.Show(this, "分销率输入有误"); return;
            //}
            //if (!shuzi2(txt_zhekou.Text.ObjToStr()))
            //{
            //    MessageBox.Show(this, "折扣率输入有误"); return;
            //}

            ///商品
            spmodel.编号 = txt_bianhao.Text;
            spmodel.单位 = txt_danwei.Text;
            spmodel.编码 = txt_bianma.Text;
            spmodel.序号 = xh;
            spmodel.类别号 = txt_leibiehao.Value;
            //spmodel.运费模板 = int.Parse(yunfeimoban.Value);
            Random rd = new Random();
            int rdValue = rd.Next(1000, 9999);
            spmodel.编号new = txt编号new.Value;
            spmodel.品名 = txt_pinming.Text;
            spmodel.是否上架 = int.Parse(txt_shifoushangjia.SelectedValue);
            spmodel.录入时间 = DateTime.Now;
            spmodel.类型 = int.Parse(txt_spleibie.SelectedValue);
            spmodel.限购数量 = DTcms.Common.Utils.StrToInt(this.txt_max_number.Text, 0);

            if (Jxl.Value.Trim() == "")
            {
                MessageBox.Show(this, "上架时间不能为空！"); return;
            }

            DateTime time = Convert.ToDateTime(Jxl.Value);
            DateTime time1;
            if (Jx2.Value.Trim() != "")
            {              
                time1 = Convert.ToDateTime(Jx2.Value);
            }
            else{
                 time1 = DateTime.Now.AddYears(2);
            }
            spmodel.上架时间 = time;
            spmodel.下架时间 = time1;
            

            spmodel.IsShow = int.Parse(string.IsNullOrEmpty(isshow.Value) ? "1" : isshow.Value);

            //int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ObjToStr()) ? "-1" : Session["dtid"].ObjToStr());

        
            spmodel.用户ID = 1;

           // decimal fenxiaolv = DTcms.Common.Utils.StrToDecimal(this.txt_分销率.Text, 0); 
            //spmodel.分销率 = fenxiaolv;
            spmodel.限购数量 = DTcms.Common.Utils.StrToInt(this.txt_max_number.Text, 0);
            //spmodel.折扣率 = DTcms.Common.Utils.StrToDecimal(this.txt_zhekou.Text, 0); 
           // spmodel.是否卖家承担运费 = int.Parse(txt_yunfei.SelectedValue);
            //spmodel.满多少包邮 = DTcms.Common.Utils.StrToDecimal(this.txt_baoyou.Text, 0); 

            string miaosh = string.Empty;
            //商品详情
            if (UEContent.Value!="")
            {
                miaosh = UEContent.Value;
                //spxqmodel.描述 = UEContent.Value;
                //spxqmodel.特点 = txt_tedian.Value;
                //spxqmodel.注意事项 = txt_zhuyishixiang.Value;
                //spxqmodel.品牌介绍 = txt_pinpaijieshao.Value;
                //spxqmodel.商品编号 = txt_bianhao.Text;
                //spxqmodel.资质证明 = txt_zizhizhengming.Value;
            }
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);//  -1新增

            string[] albumArr1 = DTRequest.GetFormString("hid_photo_name").Split(',');
            string str = "";
            if (albumArr1 != null && albumArr1.Length > 0 && albumArr1[0] != "")
            {
                string str1 = string.Join(".", albumArr1);
                //  str = str1.Substring(2, 40);
                List<string> list_str = str1.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                str = list_str[1];
                ps.Value = str;
            }
            else
            {
                MessageBox.Show(this, "请先上传图片！"); return;
            }
           
            if (id > 0)//修改
            {
                spmodel.id = id;
                if (true)
                {
                    if (!string.IsNullOrEmpty(miaosh))
                    {
                        if (comfun.GetDataTableBySQL(" select 商品编号 from wp_商品详情表 where 商品编号='" + spmodel.编号 + "' ").Rows.Count<1)
                        {
                            new comfun().Insert("insert into wp_商品详情表 (商品编号) values ('" + spmodel.编号 + "')");
                        }
                        comfun.UpdateBySQL("update wp_商品详情表 set 描述='" + miaosh + "' where 商品编号='" + spmodel.编号 + "'");
                    }
                    new comfun().Update("update WP_商品图片表 set 图片路径 ='"+str+"' where 商品编号='"+spmodel.编号+"'");
                    MessageBox.ShowAndRedirect(this, "修改成功！", "GoodsList.aspx");
                }
            }
            else//新增
            {
                 int sp= new comfun().Insert("insert into wp_商品详情表 (描述,商品编号) values ('" + miaosh + "','" + spmodel.编号 + "')");
                 new comfun().Insert("insert into WP_商品图片表(商品编号,序号,图片路径) values('"+spmodel.编号+"',0,'"+str+"')");
                 //DbHelperSQL.ExecuteSql("insert into WP_商品图片表(商品编号,序号,图片路径) values('" + spmodel.编号 + "',0,'" + str + "')");
            }
            string pinming = txt_pinming.Text.ObjToStr().Replace("'", "''");
            int flag = 0;
            if (id>0)//修改
            {
                //if (RadioButtonList1.SelectedValue == "1")
                //{
                    //for (int i = 0; i < count; i++)
                    //{
                    string str_sql = "update [WP_商品表] set 用户ID=1,类别号='" + txt_leibiehao.Value + "',品名='" + pinming + "',单位='" + txt_danwei.Text + "',编码='"+txt_bianma.Text+"',上架时间='" + time + "',下架时间='" + time1 + "',限购数量=" + txt_max_number.Text + ",是否上架='" + txt_shifoushangjia.SelectedValue + "',regtime='" + DateTime.Now.ObjToStr() + "',序号='" + xh + "',编号new='" + txt编号new.Value + "',库存数量='" + txt库存.Value + "',规格='" + txt规格.Value + "',市场价='" + txt市场价.Value + "',本站价='" + txt本站价.Value + "',重量='" + txt重量.Value + "'  where 编号='" + txt_bianhao.Text + "'";
                     flag = new comfun().Update(str_sql);
       
            }
            else//新增
            {
                string ins_sql = "";
                //判断是不是组合商品
                if (Session["goods_combo_id"] != null)//查看seesion的内容
                {//是组合商品

                   string  insert_sql = @"insert into WP_商品表 (用户ID,编号,类别号,品名,单位,上架时间,下架时间,限购数量,是否上架,regtime,序号,编号new,库存数量,规格,市场价,本站价,重量,是否单样,编码)values
                                                                                ('1','" + txt_bianhao.Text + "','" + txt_leibiehao.Value + "','" + txt_pinming.Text + "','" + txt_danwei.Text + "','" + time + "','" + time1 + "','" + txt_max_number.Text + "','" + txt_shifoushangjia.SelectedValue + "','" + DateTime.Now.ObjToStr() + "'," + xh + ",'"+ txt编号new.Value + "','" + txt库存.Value + "','" + txt规格.Value + "','" + txt市场价.Value + "','" + txt本站价.Value + "','" + txt重量.Value + "',0,'"+txt_bianma.Text+"')SELECT @@IDENTITY  ";
                   new comfun().Insert(insert_sql);
                   DataTable dtl= comfun.GetDataTableBySQL(@" select id from WP_商品表 where 编号='" + txt_bianhao.Text + "' and 编号new='" + txt编号new.Value + "'");
                    int max_id=0;
                    if (dtl.Rows.Count > 0)
                    {
                        max_id = dtl.Rows[0]["id"].ObjToInt(0);
                    }
                    else {
                        MessageBox.Show(this,"操作失败!");
                        return;
                    }
                    string session_id=Session["goods_combo_id"] as string;
                    string[] sessions_id=session_id.Split(',');
                    for (int i = 0; i < sessions_id.Length - 1;i++ )
                    {//循环在商品表组中添加
                        flag=comfun.InsertBySQL("insert into WP_商品表组 (商品组合id,商品id,数量)values(" + max_id + ","+sessions_id[i]+",1)");
                    }
                    
                }
                else//不是组合商品
                {
                    ins_sql = @"insert into WP_商品表 (用户ID,编号,类别号,品名,单位,上架时间,下架时间,限购数量,是否上架,regtime,序号,编号new,库存数量,规格,市场价,本站价,重量,是否单样,编码)values
                                                                                ('1','" + txt_bianhao.Text + "','" + txt_leibiehao.Value + "','" + txt_pinming.Text + "','" + txt_danwei.Text + "','" + time + "','" + time1 + "','" + txt_max_number.Text + "','" + txt_shifoushangjia.SelectedValue + "','" + DateTime.Now.ObjToStr() + "'," + xh + ",'"
                                                                                                                                                                                                                                       + txt编号new.Value + "','" + txt库存.Value + "','" + txt规格.Value + "','" + txt市场价.Value + "','" + txt本站价.Value + "','" + txt重量.Value + "',1,'"+txt_bianma.Text+"')";
                    flag = new comfun().Insert(ins_sql);//执行sql语句
                }
                 
             
                
            }
            if (flag > 0)
            {
                MessageBox.ShowAndRedirect(this, "操作成功!", "GoodsList.aspx");
            }
            else {
                MessageBox.Show(this, "操作失败!");
            }
            Session.Contents.Remove("goods_combo_id");//清空session
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DelLine")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DTcms.BLL.WP_商品表 bll_sp = new DTcms.BLL.WP_商品表();
                if (bll_sp.Delete(id))
                {
                    MessageBox.Show(this, "删除成功！");
                    int bid = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                }               
            }
        }

      
    }
}