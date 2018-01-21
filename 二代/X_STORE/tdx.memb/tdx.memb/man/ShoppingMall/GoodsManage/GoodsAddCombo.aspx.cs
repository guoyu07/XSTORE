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

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class GoodsAddCombo : System.Web.UI.Page
    {
        DTcms.BLL.WP_商品表 spbll = new DTcms.BLL.WP_商品表();

        DTcms.BLL.WP_商品详情表 spxqbll = new DTcms.BLL.WP_商品详情表();

        DTcms.Model.WP_商品表 spmodel = new DTcms.Model.WP_商品表();

        public static int spxqid;

        public static int sptpid;
        protected string strTr = "";
        public string goods_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txt_pinming.Text= combo().TrimEnd('+');
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

                int id = int.Parse(string.IsNullOrEmpty(Request["goods_combo_id"]) ? "-1" : Request["goods_combo_id"]);
                //Dropleibie();
                showgoods(id);
                if (id != -1)
                {
                    AddorEdit.Value = "0";
                    BindList(id);
                    
                }
            }
        }
        /// <summary>
        /// 获取商品名称
        /// </summary>
        DTcms.BLL.WP_商品表 BLL_商品名=new DTcms.BLL.WP_商品表();
        string name = "";
        string[] goods_id_combo;

        //判断有哪些个商品
        protected string[] combo_length() {
            string goods_combo_id = "";
            if (Session["goods_combo_id"] != null)
            {
                goods_combo_id = (string)Session["goods_combo_id"];
            }
            goods_id_combo = goods_combo_id.Split(',');
            return goods_id_combo;
        } 

        protected string combo()
        {
            //string goods_combo_id = DTRequest.GetString("goods_combo_id");
           // string[] goods_id_combo= goods_combo_id.Split(',');
            string goods_combo_id="";
            if (Session["goods_combo_id"] != null) { 
                    goods_combo_id= (string)Session["goods_combo_id"];
            }
            goods_id_combo = goods_combo_id.Split(',');
            int r = -1;
            for (int i = 0; i < goods_id_combo.Length-1;i++ )
            {
                if (int.TryParse(goods_id_combo[i], out r))
                {
                    spmodel = BLL_商品名.GetModel(Int32.Parse(goods_id_combo[i]));        
                }
                name+=spmodel.品名;
            }

            return name;
        }



        //DTcms.BLL.WP_category BLL_商品 = new DTcms.BLL.WP_category();
        //private void Dropleibie()
        //{
        //    DataSet ds = DbHelperSQL.Query("select * from WP_category where c_parent=0  order by c_id; ");
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        BLL_商品.getOneClassTree(Convert.ToInt32(dr["c_id"]), txt_leibiehao);
        //    }


        //    DataTable dt = DbHelperSQL.Query("select * from WP_FreightMain  order by id; ").Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "请选择";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    if (dt.Rows.Count > 0)
        //    {

        //        yunfeimoban.DataSource = dt.DefaultView;
        //        yunfeimoban.DataTextField = "name";
        //        yunfeimoban.DataValueField = "id";

        //        yunfeimoban.DataBind();

        //    }
        //}
 


        /// <summary>
        /// 规格列表 
        /// </summary>
        protected void BindList(int id)
        {
            DataTable dt = DbHelperSQL.Query("select * from [WP_商品表] where IsShow=1 and id='" + id + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {

                DataTable dtlist = DbHelperSQL.Query("select * from [WP_商品表] where IsShow=1 and 编号='" + dt.Rows[0]["编号"] + "'").Tables[0];
                for (int i = 0; i < dtlist.Rows.Count; i++)
                {
                    strTr += "<tr><td><input type=\"text\" id=\"txt商品编号" + i + "\"  runat=\"server\" value=\"" + dtlist.Rows[i]["编号new"] + "\" /><input type=\"hidden\" id=\"txtid" + i + "\"  runat=\"server\" value=\"" + dtlist.Rows[i]["id"] + "\" /></td><td><input type=\"text\"  id=\"txt规格" + i + "\"  runat=\"server\" value=\"" + dtlist.Rows[i]["规格"] + "\" /></td><td><input type=\"text\"  id=\"txt重量" + i + "\"  runat=\"server\" value=\"" + dtlist.Rows[i]["重量"] + "\" /></td><td><input type=\"text\" id=\"txt市场价" + i + "\"  runat=\"server\" value=\"" + dtlist.Rows[i]["市场价"] + "\" /></td><td><input type=\"text\" id=\"txt本站价" + i + "\"  runat=\"server\" value=\"" + dtlist.Rows[i]["本站价"] + "\" /></td><td><input type=\"text\" id=\"txt库存" + i + "\"  runat=\"server\" value=\"" + dtlist.Rows[i]["库存数量"] + "\" /></td><td><a href=\"javascript:;\" onclick=\"del(this)\">删除</a></td></tr>";
                }
               // ltrTr.Text = strTr;


                //DataTable dtlist = DbHelperSQL.Query("select * from [WP_商品表] where 编号='"+dt.Rows[0]["编号"]+"'").Tables[0];
                //rptList.DataSource = dtlist;
                //rptList.DataBind();
            }
            string msg = "$(\"#tr规格\").css(\"display\",\"none\")";
            Page.ClientScript.RegisterStartupScript(GetType(), "msg", msg, true);
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

        public void showgoods(int id)
        {
            //商品显示
            DataTable dt = spbll.GetList(" IsShow=1 and id=" + id).Tables[0];

            if (dt.Rows.Count > 0)
            {
                txt_bianhao.Text = dt.Rows[0]["编号"].ObjToStr();
                txt编号new.Value = dt.Rows[0]["编号new"].ObjToStr();
                txt规格.Value = dt.Rows[0]["规格"].ObjToStr();
                txt本站价.Value = dt.Rows[0]["本站价"].ObjToStr();
                txt市场价.Value = dt.Rows[0]["市场价"].ObjToStr();
                txt_danwei.Text = dt.Rows[0]["单位"].ObjToStr();
                txt_bianma.Text = dt.Rows[0]["编码"].ObjToStr();
                //txt_序号1.Text = dt.Rows[0]["序号"] != null ? dt.Rows[0]["序号"].ObjToStr() : "99";
                txt重量.Value = dt.Rows[0]["重量"].ObjToStr();
                //txt_分销率.Text = dt.Rows[0]["分销率"].ObjToStr();
                //txt_限购数量.Text = dt.Rows[0]["限购数量"].ObjToStr();
                // txt_guige.Text = dt.Rows[0]["规格"].ObjToStr();
                // txt_jiutuanjia.Text = dt.Rows[0]["九团价"].ObjToStr();
                //txt_kucunshuliang.Text = dt.Rows[0]["库存数量"].ObjToStr();
                txt_leibiehao.Value = dt.Rows[0]["类别号"].ObjToStr();
                //yunfeimoban.Value = dt.Rows[0]["运费模板"].ObjToStr();
                txt_pinming.Text = dt.Rows[0]["品名"].ObjToStr();
                //txt_santuanjia.Text = dt.Rows[0]["三团价"].ObjToStr();
                // txt_shichangjia.Text = dt.Rows[0]["市场价"].ObjToStr();
                txt_shifoushangjia.SelectedValue = dt.Rows[0]["是否上架"].ObjToStr();
                txt_spleibie.SelectedValue = dt.Rows[0]["类型"].ObjToStr();
                Jxl.Value = dt.Rows[0]["上架时间"].ObjToStr();
                Jx2.Value = dt.Rows[0]["下架时间"].ObjToStr();
                isshow.Value = dt.Rows[0]["IsShow"].ObjToStr();
                this.txt库存.Value = dt.Rows[0]["库存数量"].ObjToStr();

                if (dt.Rows[0]["限购数量"] != null)
                    txt_限购数量.Text = dt.Rows[0]["限购数量"].ObjToStr();

               // txt_zhekou.Text = dt.Rows[0]["折扣率"].ObjToStr();
                //txt_yunfei.SelectedValue = dt.Rows[0]["是否卖家承担运费"].ObjToStr();
                //txt_baoyou.Text = Convert.ToDecimal(dt.Rows[0]["满多少包邮"]).ObjToStr("f2");

                //商品详情显示
                DataTable spxqdt = spxqbll.GetList(" 商品编号='" + dt.Rows[0]["编号"].ObjToStr() + "' order by id desc ").Tables[0];

                if (spxqdt.Rows.Count > 0)
                {
                    spxqid = int.Parse(spxqdt.Rows[0]["id"].ObjToStr());
                    UEContent.Value = spxqdt.Rows[0]["描述"].ObjToStr();
                    txt_tedian.Value = spxqdt.Rows[0]["特点"].ObjToStr();
                    txt_zhuyishixiang.Value = spxqdt.Rows[0]["注意事项"].ObjToStr();
                    txt_pinpaijieshao.Value = spxqdt.Rows[0]["品牌介绍"].ObjToStr();
                    txt_zizhizhengming.Value = spxqdt.Rows[0]["资质证明"].ObjToStr();
                }
                string _SqlShow = "select * from [WP_商品图片表] where 商品编号='" + dt.Rows[0]["编号"].ObjToStr() + "' order by 序号 asc ";
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

        public bool shuzi(string s)
        {
            string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txt_bianhao.Text.Trim() == "")
            {
                MessageBox.Show(this, "编号不能为空！"); return;
            }
            if (txt规格.Value.Trim() == "")
            {
                MessageBox.Show(this, "规格不能为空！"); return;
            }
            if (!shuzi(txt本站价.Value.ObjToStr().Replace(".", "0")))
            {
                MessageBox.Show(this, "输入有误！"); return;
            }
            //if (!shuzi(txt市场价.Value.ObjToStr().Replace(".", "0")))
            //{
            //    MessageBox.Show(this, "输入有误！"); return;
            //}
            //if (txt_shuliang.Text.Trim() == "") {
            //    MessageBox.Show(this, "数量不能为空！"); return;
            //}
            if (txt_danwei.Text.Trim() == "")
            {
                MessageBox.Show(this, "单位不能为空！"); return;
            }
            if (txt_bianma.Text.Trim() == "")
            {
                MessageBox.Show(this, "编码不能为空！"); return;
            }
            int xh = 99;
          //  if (txt_序号1.Text.Trim() != "")
          //  {
         //       int.TryParse(txt_序号1.Text.Trim(), out xh);
          //  }
            if (txt编号new.Value.Trim() == "")
            {
                MessageBox.Show(this, "条形码不能为空！"); return;
            }
            if (txt规格.Value.Trim() == "")
            {
                MessageBox.Show(this, "规格不能为空！"); return;
            }
            if (txt重量.Value.Trim() == "")
            {
                MessageBox.Show(this, "重量不能为空！"); return;
            }
            if (txt本站价.Value.Trim() == "")
            {
                MessageBox.Show(this, "本站价不能为空！"); return;
            }
            if (txt市场价.Value.Trim() == "")
            {
                MessageBox.Show(this, "市场价不能为空！"); return;
            }
            if (txt库存.Value.Trim() == "")
            {
                MessageBox.Show(this, "库存数量不能为空！"); return;
            }

            if (txt_leibiehao.Value == "")
            {
                MessageBox.Show(this, "类别号不能为空！"); return;
            }
            if (txt_pinming.Text.Trim() == "")
            {
                MessageBox.Show(this, "品名不能为空！"); return;
            }
            
            if (string.IsNullOrEmpty(this.txt库存.Value))
            {
                MessageBox.Show(this, "请填写库存数量！"); return;
            }
            ///商品
            spmodel.编号 = txt_bianhao.Text;

            string[] albumArr1 = DTRequest.GetFormString("hid_photo_name").Split(',');
            if (albumArr1 != null && albumArr1.Length > 0 && albumArr1[0] != "")
            {
                new DTcms.DAL.ComPicDAL().DoPic(spmodel.编号);
            }
            else
            {
                MessageBox.Show(this, "请先上传图片！"); return;
            }

            spmodel.规格 = txt规格.Value;
            spmodel.本站价 = Utils.ObjToDecimal(txt本站价.Value, 0);
            spmodel.市场价 = Utils.ObjToDecimal(txt市场价.Value, 0);
            spmodel.单位 = txt_danwei.Text;
            spmodel.编码 = txt_bianma.Text;
            spmodel.序号 = xh;
            spmodel.重量 = Utils.ObjToDecimal(txt重量.Value, 0);
            spmodel.类别号 = txt_leibiehao.Value;
           // spmodel.运费模板 = int.Parse(yunfeimoban.Value);
            Random rd = new Random();
            int rdValue = rd.Next(1000, 9999);
            spmodel.编号new = txt编号new.Value;
            spmodel.品名 = txt_pinming.Text;
            spmodel.是否上架 = int.Parse(txt_shifoushangjia.SelectedValue);
            spmodel.录入时间 = DateTime.Now;
            spmodel.类型 = int.Parse(txt_spleibie.SelectedValue);
            spmodel.库存数量 = DTcms.Common.Utils.StrToInt(this.txt库存.Value, 0);
            spmodel.限购数量 = DTcms.Common.Utils.StrToInt(this.txt_限购数量.Text, 0);

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
            else
            {
                time1 = DateTime.Now.AddYears(2);
            }
            spmodel.上架时间 = time;
            spmodel.下架时间 = time1;

            spmodel.IsShow = int.Parse(string.IsNullOrEmpty(isshow.Value) ? "1" : isshow.Value);

            spmodel.用户ID = 1;
           // decimal fenxiaolv = DTcms.Common.Utils.StrToDecimal(this.txt_分销率.Text, 0);
            //spmodel.分销率 = fenxiaolv;
            spmodel.限购数量 = DTcms.Common.Utils.StrToInt(this.txt_限购数量.Text, 0);
            //spmodel.折扣率 = DTcms.Common.Utils.StrToDecimal(this.txt_zhekou.Text, 0);
         //   spmodel.是否卖家承担运费 = int.Parse(txt_yunfei.SelectedValue);

            string miaosh = string.Empty;
            //商品详情
            if (UEContent.Value != "")
            {
                miaosh = UEContent.Value;
          
            }
            comfun.InsertBySQL("insert into wp_商品详情表 (描述,商品编号) values ('" + miaosh + "','" + spmodel.编号 + "')");
            string pinming = txt_pinming.Text.ObjToStr().Replace("'", "''");

            var insert_sql = @"insert into [WP_商品表] (用户ID,规格,类别号,品名,单位,上架时间,下架时间,限购数量,是否上架,regtime,序号,编号,是否单样,编号new,编码) values('1','" + txt规格 .Value+ "','" + txt_leibiehao.Value + "','" + pinming + "','"
                                                                                + txt_danwei.Text + "','" + time + "','" + time1 + "','" + txt_限购数量.Text + "','" + txt_shifoushangjia.SelectedValue + "','" +
                                                                                DateTime.Now.ObjToStr() + "','" + xh + "','" + txt_bianhao.Text + "',0,"+txt编号new.Value+",'"+txt_bianma.Text+"')Select @@Identity";
            int flag2 = comfun.InsertBySQL(insert_sql);
            if(flag2>0){
                MessageBox.ShowAndRedirect(this,"添加成功","GoodsList.aspx");
            }
            string[] number=combo_length();
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
                    BindList(bid);
                }
            }
        }

    }
}