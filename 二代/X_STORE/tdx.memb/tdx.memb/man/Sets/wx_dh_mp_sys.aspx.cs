using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.Sets
{
    public partial class wx_dh_mp_sys : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request["nav"] != null && Request["nav"].ToString().Equals("true"))
                {
                    ///如果存在则去最新一个记录
                    DataTable _dt = comfun.GetDataTableBySQL(string.Format("select top 1 * from wx_mp where wid={0} order by id desc", Session["wid"]));
                    if (_dt.Rows.Count > 0)
                    {
                        wx_mp wxmp = new wx_mp(Convert.ToInt32(_dt.Rows[0]["id"].ToString()));
                        txtName.Value = wxmp.wx_name;
                        txtNichen.Value = wxmp.wx_nichen;
                        txtGUID.Value = wxmp.wx_ID;
                        txtDID.Value = wxmp.wx_DID;
                        txtDpsw.Value = wxmp.wx_Dpsw;
                        if (wxmp.wx_cid == 1)
                            RD_Cid2.Checked = true;
                        else
                            RD_Cid1.Checked = true;
                    }
                    ltHead.Text = commonTool.DaohangImage("1.jpg");
                    //ltFoot.Text = commonTool.DaohangButton("../main.aspx", "../Texts/B2C_tpage_Add.aspx?nav=true", "../Texts/B2C_tpage_Add.aspx?nav=true");
                    ltFoot.Text = commonTool.DaohangButton("../index.aspx", "####", "####");

                    int _id = Convert.ToInt32(Session["wID"].ToString());

                    //B2C_worker bw = new B2C_worker(_id);
                    //txtNichen.Value = bw.wx_nichen;
                    //txtCompany.Value = bw.M_company;
                    //txtTel.Value = bw.M_tel;
                    //txtMobile.Value = bw.M_mobile;
                    //txtMail.Value = bw.M_email;
                    //txtUrl.Value = bw.M_url;
                    //txtQq.Value = bw.M_QQ;


                    //if (bw.hy_no != null && bw.hy_no != "")
                    //{
                    //    ListItem lt;
                    //    lt = new ListItem();
                    //    lt.Value = "请选择类别";
                    //    lt.Text = "请选择类别";
                    //    hy.Items.Add(lt);
                    //    getClassByID(bw.hy_no);
                    //}
                    //else
                    //{
                    //    ListItem lt;
                    //    lt = new ListItem();
                    //    lt.Value = "请选择类别";
                    //    lt.Text = "请选择类别";
                    //    lt.Selected = true;
                    //    hy.Items.Add(lt);
                    //    getClass();
                    //}
                    //if (bw.area_no != "")
                    //{
                    //    string[] _area = bw.area_no.Split('|');
                    //    if (_area.Length >= 3)
                    //    {
                    //        string str = "<script language='javascript'>";
                    //        str += "$(\"#Select1\").val(\"" + _area[0] + "\");";
                    //        str += "$(\"#Select2\").prepend(\"<option value='" + _area[1] + "' selected>" + _area[1] + "</option>\");";
                    //        str += "$(\"#Select3\").prepend(\"<option value='" + _area[2] + "'>" + _area[2] + "</option>\");";
                    //        str += "</script>";
                    //        sc.Text = str;

                    //    }
                    //}
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('非法进入！');location.href='../index.aspx';</script>");
                }
            }

        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {

            string _id = Session["wID"].ToString();
            string _wz_nichen = txtNichen.Value;
            string _M_company = txtCompany.Value;
            string _M_tel = txtTel.Value;
            string _M_mobile = txtMobile.Value;
            string _M_email = txtMail.Value;
            string _M_url = txtUrl.Value;
            string _M_QQ = txtQq.Value;

            if (_wz_nichen.Trim() == "")
            {
                lt_result.Text = "请输入网站名称";
                return;
            }

            try
            {
                //B2C_worker goods = new B2C_worker(Convert.ToInt32(_id));
                //hf.Value = Request["hy"].ToString();
                //if (hf.Value != "请选择类别")
                //{
                //    //DataTable _tab = comfun.GetDataTableBySQL(string.Format("select * from weixin_class where name='{0}'", Request["hy"].ToString()));
                //    goods.hy_no = hf.Value;
                //}

                //if (Request["Select1"].ToString() != "--请选择省份--")
                //{
                //    goods.area_no = Request["Select1"].ToString() + "|" + Request["Select2"].ToString() + "|" + Request["Select3"].ToString();

                //}

                //goods.wx_nichen = _wz_nichen;
                //goods.M_company = _M_company;
                //goods.M_tel = _M_tel;
                //goods.M_mobile = _M_mobile;
                //goods.M_email = _M_email;
                //goods.M_url = _M_url;
                //goods.M_QQ = _M_QQ;
                //goods.Update();
                //lt_result.Text = "设置成功！";



                ////lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wxConfig.aspx';},300);</script>";
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
            }

            int _wid = Session["wID"] != null ? Convert.ToInt32(Session["wID"].ToString()) : 0;
            string _wx_name = txtName.Value;
            string _wx_nichen = txtNichen.Value;
            string _wx_ID = txtGUID.Value;
            string _wx_DID = txtDID.Value;
            string _wx_Dpsw = txtDpsw.Value;
            string _wx_2wm = txtGif.Value;
            int _wx_FirstIsGif = 0;  //默认文字模式
            string _wx_des = ""; //默认没有描述
            int _wx_cid = 1;
            if (RD_Cid1.Checked == true)
                _wx_cid = 0;

            if (_wx_2wm != "")
            {
                comUpload up = new comUpload();
                up.clearFileType();
                up.addFileType("jpg");
                up.addFileType("jpeg");
                up.addFileType("gif");
                up.addFileType("png");
                up.addFileType("bmp");

                try
                {
                    if (up.UploadPic(txtGif) != 0)
                    {
                        _wx_2wm = up.getTargetFilename();
                    }
                }
                finally { up = null; }
            }
            if (_wx_name.Trim() == "")
            {
                lt_result.Text = "请输入微信号.";
                return;
            }
            if (_wx_ID.Trim() == "")
            {
                lt_result.Text = "请输入您的微信原始号";
                return;
            }
            if (_wx_nichen.Trim() == "")
            {
                lt_result.Text = "请输入您的微信昵称";
                return;
            }

            DataTable _dt = comfun.GetDataTableBySQL(string.Format("select top 1 * from wx_mp where wid={0} order by id desc", Session["wid"]));
            if (_dt.Rows.Count > 0)
            {  //修改模式
                try
                {
                    //判断原始号不能重复
                    DataTable dt = comfun.GetDataTableBySQL("select id from wx_mp where wx_id='" + _wx_ID + "' and id<>" + _dt.Rows[0]["id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        lt_result.Text = "该原始号已经存在！";
                        dt.Dispose();
                        return;
                    }

                    wx_mp goods = new wx_mp(Convert.ToInt32(_dt.Rows[0]["id"].ToString()));
                    if (goods.wid != _wid)
                    {
                        lt_result.Text = "这不是您的微信公众号,请不要操作！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_mp_list.aspx';},300);</script>";
                        return;
                    }
                    else
                    {
                        goods.wx_name = _wx_name;
                        goods.wx_nichen = _wx_nichen;
                        goods.wx_ID = _wx_ID;
                        goods.wx_DID = _wx_DID;
                        goods.wx_Dpsw = _wx_Dpsw;
                        if (_wx_2wm != "")
                        {
                            goods.wx_2wm = _wx_2wm;
                        }
                        goods.wx_cid = _wx_cid;
                        goods.Update();
                        lt_result.Text = "修改成功！";
                    }
                }
                catch (Exception ex)
                {
                    lt_result.Text = ex.Message;
                    return;
                }
            }
            else
            {


                //添加模式

                //判断原始号不能重复
                DataTable dt = comfun.GetDataTableBySQL("select id from wx_mp where wx_id='" + _wx_ID + "'");
                if (dt.Rows.Count > 0)
                {
                    lt_result.Text = "该原始号已经存在！";
                    dt.Dispose();
                    return;
                }
                try
                {
                    wx_mp goods = new wx_mp();
                    goods.wid = _wid;
                    goods.wx_name = _wx_name;
                    goods.wx_nichen = _wx_nichen;
                    goods.wx_ID = _wx_ID;
                    goods.wx_DID = _wx_DID;
                    goods.wx_Dpsw = _wx_Dpsw;
                    goods.wx_FirstIsGif = Convert.ToInt32(_wx_FirstIsGif);
                    goods.wx_2wm = _wx_2wm;
                    goods.wx_cid = _wx_cid;
                    goods.wx_des = _wx_des;
                    goods.Update();
                    lt_result.Text = "添加成功！";
                    //lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_mp_list.aspx';},300);</script>";
                }
                catch (Exception ex)
                {
                    lt_result.Text = ex.Message;
                    return;
                }
            }
            ltFoot.Text = commonTool.DaohangButton("../index.aspx", "../Texts/B2C_tpage_Add.aspx?nav=true", "../Texts/B2C_tpage_Add.aspx?nav=true");
        }

        static string Sql = "*";
        static string Where = "1=1";
        DataTable dt = B2C_WeiXin_Class.GetList(Sql, Where);

        private void getClassByID(string number, int id = 0)
        {
            DataView dv = dt.AsDataView();
            //"len(number)=" + index + " and 
            dv.RowFilter = " fat_Id = " + id;
            DataTable dt1 = dv.ToTable();
            if (dt1.Rows.Count > 0)
            {
                ListItem lt;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    lt = new ListItem();
                    lt.Text = huagang(dt1.Rows[i]["number"].ToString().Length) + dt1.Rows[i]["name"].ToString();
                    lt.Value = dt1.Rows[i]["number"].ToString();
                    if (dt1.Rows[i]["number"].ToString().Equals(number))
                    {
                        lt.Selected = true;
                        hf.Value = lt.Value;
                    }
                    hy.Items.Add(lt);
                    if (Convert.ToInt32(dt1.Rows[i]["child_number"]) > 0)
                    {
                        getClassByID(number, Convert.ToInt32(dt1.Rows[i]["id"]));
                    }
                }
            }
        }

        private string huagang(int lengths)
        {
            string _xian = "";
            if (lengths > 3)
            {
                for (int i = 0; i < lengths / 3; i++)
                {
                    _xian += "-";
                }
            }
            return _xian;
        }

        /// <summary>
        /// 初始化一个下拉菜单
        /// </summary>
        /// <param name="id"></param>
        private void getClass(int id = 0)
        {
            DataView dv = dt.AsDataView();
            dv.RowFilter = " fat_Id = " + id;
            DataTable dt1 = dv.ToTable();
            if (dt1.Rows.Count > 0)
            {
                ListItem lt;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    lt = new ListItem();
                    lt.Text = huagang(dt1.Rows[i]["number"].ToString().Length) + dt1.Rows[i]["name"].ToString();
                    lt.Value = dt1.Rows[i]["number"].ToString();
                    hy.Items.Add(lt);
                    if (Convert.ToInt32(dt1.Rows[i]["child_number"]) > 0)
                    {
                        getClass(Convert.ToInt32(dt1.Rows[i]["id"]));
                    }
                }
            }
        }

    }
}