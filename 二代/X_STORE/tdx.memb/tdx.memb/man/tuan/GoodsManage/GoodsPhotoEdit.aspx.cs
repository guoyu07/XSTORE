using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using tdx.database;
using DTcms.Model;

namespace tdx.memb.man.Tuan.GoodsManage
{
    public partial class GoodsPhotoEdit : System.Web.UI.Page
    {
        DTcms.BLL.TM_商品图片表 sptpbll = new DTcms.BLL.TM_商品图片表();

        DTcms.Model.TM_商品图片表 sptpmodel = new DTcms.Model.TM_商品图片表();
        protected internal siteconfig siteConfig;


        public string src = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                photo(id);
                goodsphoto();
            }
        }


        private void goodsphoto()
        {


            DTcms.BLL.manager dtbll = new DTcms.BLL.manager();
            try
            {
                int dtid = int.Parse(string.IsNullOrEmpty(Session["dtid"].ToString()) ? "-1" : Session["dtid"].ToString());

                if (dtid > 0)
                {
                    DataTable dtdt = dtbll.GetList(0," id=" + dtid,"id").Tables[0];
                    if (dtdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtdt.Rows.Count; i++)
                        {
                            //if (dtdt.Rows[i]["user_name"].ToString() != "admin")
                            //{
                                //string sql = " select * from dbo.TM_商品表 where 用户ID=" + dtdt.Rows[0]["id"];
                            string sql = " select * from dbo.TM_商品表 where 用户ID !=0";
                                DataTable dt = DbHelperSQL.Query(sql).Tables[0];

                                if (dt.Rows.Count > 0)
                                {

                                    drp_photo.DataSource = dt.DefaultView;
                                    drp_photo.DataTextField = "品名";
                                    drp_photo.DataValueField = "编号";

                                    drp_photo.DataBind();

                                }
                            //}

                        }
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();
            }


        }


        private void photo(int id)
        {
            DataTable dt = sptpbll.GetList(" id=" + id).Tables[0];
            if (dt.Rows.Count > 0)
            {

                txt_biaoti.Text = dt.Rows[0]["标题"].ToString();
                src = txt_img.Text = dt.Rows[0]["图片路径"].ToString();

                goodsphoto();
                drp_photo.SelectedValue = dt.Rows[0]["商品编号"].ToString();
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
            else
            {
                Session["_t_source_url"] = "";
            }



            sptpmodel.标题 = txt_biaoti.Text;
            sptpmodel.图片路径 = string.IsNullOrEmpty(Session["_t_source_url"].ToString()) ? txt_img.Text : Session["_t_source_url"].ToString();

            sptpmodel.商品编号 = drp_photo.SelectedValue;

            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            if (id > 0)
            {
                sptpmodel.id = id;

                bool b = sptpbll.Update(sptpmodel);

                if (b)
                {
                    MessageBox.ShowAndRedirect(this, "修改成功！", "GoodsPhotoList.aspx");

                }
                else
                {
                    MessageBox.Show(this, "修改失败！");
                }
            }
            else
            {
                int i = sptpbll.Add(sptpmodel);

                if (i > 0)
                {
                    MessageBox.ShowAndRedirect(this, "添加成功！", "GoodsPhotoList.aspx");

                }
                else
                {
                    MessageBox.Show(this, "添加失败！");
                }
            }
        }
    }
}