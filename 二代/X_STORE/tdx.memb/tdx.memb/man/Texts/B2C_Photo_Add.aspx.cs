using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Texts
{
    public partial class B2C_Photo_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //userAuthentication(12);
            if (!IsPostBack)
            {
                DataSet ds = comfun.GetDataSetBySQL("select * from B2C_Pclass where c_parent=0 order by c_id");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    B2C_Pclass.getOneClassTree(Convert.ToInt32(dr["c_id"]), cid);
                }
                ds.Dispose();
                ds = null;

                //t_author.Value = Convert.ToString(Session["admin_user"]);//作者，即当前登录用户
                if (Request["id"] != null)
                {
                    int id = Convert.ToInt32(Request["id"]);
                    B2C_Photo goods = new B2C_Photo(id);
                    t_title.Value = goods.P_no;
                    t_author.Value = goods.P_name;
                    t_source_url.Value = goods.P_url;
                    t_wdes.Value = goods.P_des;
                    t_w_sort.Value = goods.P_sort.ToString();
                    t_wdate.Value = goods.P_wdate.ToString();
                    wtab.Value = goods.P_tab;
                    wrow.Value = goods.P_row;
                }
                else
                {
                    t_w_sort.Value = "99";
                    t_wdate.Value = System.DateTime.Now.ToShortDateString();
                    if (null != Request["ptab"])
                        wtab.Value = Request["ptab"].ToString();
                    if (null != Request["prow"])
                        wrow.Value = Request["prow"].ToString();
                }
            }
        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {

            string _cno = cid.Value;
            string _t_title = comFunction.NoHTML(t_title.Value); //文档号
            string _t_author = comFunction.NoHTML(t_author.Value); //文档名称
            string _t_source_url = comFunction.NoHTML(t_source_url.Value); //文档路径
            string _t_wdes = comFunction.NoSt(t_wdes.Value);//简介
            int _t_wsort = Convert.ToInt32(t_w_sort.Value);
            string _t_wdate = t_wdate.Value; //建档时间
            string _wtab = wtab.Value;//关联表格
            string _wrow = wrow.Value;//关联字段
            //判断是否上传...
            string _t_source_file = t_source_file.Value.Trim();
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
                System.IO.FileInfo f = new System.IO.FileInfo(Server.MapPath("/") + _t_source_url);
                _t_ftype = f.Name.Substring(f.Name.LastIndexOf(".") + 1, f.Name.Length - f.Name.LastIndexOf(".") - 1).ToLower();
                _t_fweight = (f.Length / 1000) + "K";
            }


            if (Request["id"] != null)
            {
                try
                {
                    B2C_Photo goods = new B2C_Photo(Convert.ToInt32(Request["id"]));
                    goods.cno = _cno;
                    goods.P_no = _t_title;
                    goods.P_name = _t_author;
                    goods.P_url = _t_source_url;
                    goods.P_ftype = _t_ftype;
                    goods.P_fweight = _t_fweight;
                    goods.P_des = _t_wdes;
                    goods.P_sort = _t_wsort;
                    goods.P_tab = _wtab;
                    goods.P_row = _wrow;
                    goods.P_wdate = Convert.ToDateTime(_t_wdate);

                    goods.Update();
                    Response.Write("<script language='javascript'>alert('修改成功！');location.href='B2C_Photo_List.aspx';</script>");
                }
                catch
                {
                    Response.Write("<script language='javascript'>alert('修改失败！');history.go(-1);</script>");
                }
            }
            else
            {
                try
                {
                    DataTable dt = comfun.GetDataTableBySQL("select id from b2c_photo where P_no='" + _t_title.Trim() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        Response.Write("<script language='javascript'>alert('系统中存在相同的图片号,请重新选择！');history.go(-1);</script>");
                        Response.End();
                        return;
                    }

                    B2C_Photo goods = new B2C_Photo();
                    goods.AddNew();
                    goods.cno = _cno;
                    goods.P_no = _t_title;
                    goods.P_name = _t_author;
                    goods.P_url = _t_source_url;
                    goods.P_ftype = _t_ftype;
                    goods.P_fweight = _t_fweight;
                    goods.P_des = _t_wdes;
                    goods.P_sort = _t_wsort;
                    goods.P_tab = _wtab;
                    goods.P_row = _wrow;
                    goods.P_wdate = Convert.ToDateTime(_t_wdate);

                    goods.Update();
                    Response.Write("<script language='javascript'>alert('添加成功！');location.href='B2C_Photo_List.aspx';</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('添加失败！');history.go(-1);</script>");
                }
            }
        }
    }
}