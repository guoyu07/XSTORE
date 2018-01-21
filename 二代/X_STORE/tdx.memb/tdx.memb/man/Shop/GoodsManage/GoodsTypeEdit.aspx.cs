using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.BLL;
using DTcms.Model;
using Creatrue.Common.Msgbox;
using System.Data;
using Creatrue.kernel;
using tdx.database;



namespace tdx.memb.man.Shop.GoodsManage
{
    public partial class GoodsTypeEdit : System.Web.UI.Page
    {
        DTcms.BLL.WP_商品类别表 splbbll = new DTcms.BLL.WP_商品类别表();

        DTcms.Model.WP_商品类别表 splmodel = new DTcms.Model.WP_商品类别表();

        public static int id;
        public string src = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "0" : Request["id"]);

                Show(id);
            }
        }

        private void Show(int id)
        {
            if (id > 0)
            {
                DataTable dt = splbbll.GetList(" id=" + id).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_leibiebianhao.Text = dt.Rows[0]["类别编号"].ToString();
                    txt_leibieming.Text = dt.Rows[0]["类别名"].ToString();
                    src = txt_img.Text = dt.Rows[0]["图片"].ToString();
                }
            }
            else
            {


                txt_leibiebianhao.Text = DateTime.Now.ToString("yyyyMMddHHmmss");


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            if (txt_leibieming.Text.Trim() == "")
            {
                MessageBox.Show(this, "类别号不能为空！");
            }
            if (this.t_source_file.Value.Trim() == ""&&this.txt_img.Text.Trim()=="")
            {
                MessageBox.Show(this, "请选择图片！");
                return;
            }

            string _t_source_url = ""; //文档路径
            //判断是否上传...
            string _t_source_file = comFunction.NoHTML(t_source_file.Value.Trim());
            if (_t_source_file != "")
            {
                comUpload up = new comUpload();
                up.clearFileType();//支持pdf、doc、xls、docx、xlsx、jpg、gif

                up.addFileType("jpg");
                up.addFileType("gif");
                up.addFileType("jpeg");
                up.addFileType("png");
                up.addFileType("bmp");


                try
                {
                    if (up.UploadPic(t_source_file) != 0)
                    {
                        _t_source_file = up.getTargetFilename();
                        _t_source_url = _t_source_file;
                    }

                }
                finally { up = null; }
            }

            string _t_ftype = "";
            string _t_fweight = "";
            if (_t_source_url.Trim() != "")
            {
                Session["_t_source_url"] = _t_source_url;
                System.IO.FileInfo f = new System.IO.FileInfo(Server.MapPath("/") + _t_source_url);
                _t_ftype = f.Name.Substring(f.Name.LastIndexOf(".") + 1, f.Name.Length - f.Name.LastIndexOf(".") - 1).ToLower();
                _t_fweight = (f.Length / 1000) + "K";
            }
            else
            {
                Session["_t_source_url"] = "";
            }

            splmodel.类别名 = txt_leibieming.Text.Trim();
            splmodel.类别编号 = txt_leibiebianhao.Text.Trim();
            splmodel.图片 = string.IsNullOrEmpty(Session["_t_source_url"].ToString()) ? txt_img.Text : Session["_t_source_url"].ToString();


            if (id > 0)
            {
                splmodel.id = id;

                if (splbbll.Update(splmodel))
                {
                    MessageBox.ShowAndRedirect(this, "修改成功！", "GoodsTypeList.aspx");
                }
            }
            else
            {

                if (splbbll.Add(splmodel) > 0)
                {
                    MessageBox.ShowAndRedirect(this, "添加成功！", "GoodsTypeList.aspx");
                }
            }
        }
    }
}