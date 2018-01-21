using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Tuan.VipManage
{
    public partial class VipEdit : DTcms.Web.UI.ManagePage
    {
        DTcms.BLL.WP_会员表 hybll = new DTcms.BLL.WP_会员表();

        DTcms.Model.WP_会员表 hymodel = new DTcms.Model.WP_会员表();

       
        public static int ids;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                if (id > 0)
                {
                    ids = id;
                    showuser(id);
                }
            }
        }
        public void showuser(int id)
        {

            DataTable dt = hybll.GetList(" id=" + id).Tables[0];
            if (dt.Rows.Count > 0)
            {
               
                txt_nicheng.Text = dt.Rows[0]["wx昵称"].ToString();
                txt_openid.Text = dt.Rows[0]["openid"].ToString();
                txt_Telephone.Text = dt.Rows[0]["手机号"].ToString();
                txt_Headimg.Text = dt.Rows[0]["wx头像"].ToString();
               
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {


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

           
            hymodel.手机号 = txt_Telephone.Text;
            hymodel.wx昵称 = txt_nicheng.Text;
            hymodel.wx头像 = Session["_t_source_url"].ToString();
            
            hymodel.openid = txt_openid.Text;
            hymodel.id = ids;

            bool b = hybll.Update(hymodel);

            if (b)
            {
                MessageBox.ShowAndRedirect(this, "修改成功！", "VipList.aspx");

            }
        }
    }
}