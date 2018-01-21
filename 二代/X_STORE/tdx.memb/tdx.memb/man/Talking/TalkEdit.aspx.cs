using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Msgbox;
using DTcms.DBUtility;
using tdx.database;

namespace tdx.memb.man.Talking
{
    public partial class TalkEdit : System.Web.UI.Page
    {
        private string openid = "of8T9tqpdohEMcKV4jQ5i53ZDG0w";

        DTcms.BLL.TK_发帖表 spbll = new DTcms.BLL.TK_发帖表();

        DTcms.Model.TK_发帖表 spmodel = new DTcms.Model.TK_发帖表();

        public static int spxqid;

        public static int sptpid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_bianhao.Text = GeteRandomNumber(15);
                int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                showgoods(id);


                Dropleibie();
            }
        }

        DTcms.BLL.TK_发帖类别表 BLL_商品 = new DTcms.BLL.TK_发帖类别表();
        private void Dropleibie()
        {
            DataSet ds = DbHelperSQL.Query("select * from TK_发帖类别表 where c_parent=0  order by id; ");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BLL_商品.getOneClassTree(Convert.ToInt32(dr["id"]), txt_leibiehao);
            }
        }


        public void showgoods(int id)
        {
            //商品显示
            DataTable dt = spbll.GetList(" id=" + id).Tables[0];

            if (dt.Rows.Count > 0)
            {
                Dropleibie();
                txt_bianhao.Text = dt.Rows[0]["编号"].ToString();
                txt_leibiehao.Value = dt.Rows[0]["类别号"].ToString();
                txt_pinming.Text = dt.Rows[0]["名称"].ToString();
                txt_shifoushangjia.SelectedValue = dt.Rows[0]["是否置顶"].ToString();
                UEContent.Value = dt.Rows[0]["内容"].ToString();

                string _SqlShow = "select * from [TK_发帖图片表] where 编号='" + dt.Rows[0]["编号"].ToString() + "' ";
                DataTable dt_show = DbHelperSQL.Query(_SqlShow).Tables[0];
                if (dt_show.Rows.Count > 0)
                {
                    //绑定展示图
                    rptManagementAttachList.DataSource = dt_show;
                    rptManagementAttachList.DataBind();
                }
            }

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
            if (txt_leibiehao.Value == "")
            {
                MessageBox.Show(this, "类别号不能为空！"); return;
            }
            if (txt_pinming.Text.Trim() == "")
            {
                MessageBox.Show(this, "名称不能为空！"); return;
            }

            spmodel.编号 = txt_bianhao.Text;
            spmodel.类别号 = txt_leibiehao.Value;
            spmodel.名称 = txt_pinming.Text;
            spmodel.是否置顶 = int.Parse(txt_shifoushangjia.SelectedValue);
            spmodel.内容 = UEContent.Value;
            spmodel.openid = openid;

            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            new DTcms.DAL.ComPicDAL().DoPic2(spmodel.编号);

            if (id > 0)
            {
                spmodel.id = id;


                bool sp = spbll.Update(spmodel);

                if (sp)
                {
                    MessageBox.ShowAndRedirect(this, "修改成功！", "TalkList.aspx");
                }
                else
                {
                    MessageBox.Show(this, "修改失败！");
                }

            }
            else
            {
                int sp = spbll.Add(spmodel);

                if (sp > 0)
                {
                    MessageBox.ShowAndRedirect(this, "添加成功！", "TalkList.aspx");
                }
                else
                {
                    MessageBox.Show(this, "添加失败！");
                }

            }


        }

    }
}