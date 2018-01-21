using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.DBUtility;
using tdx.database;

namespace tdx.memb.man.UserCenter
{
    public partial class B2C_mem_Add_Service_Center : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();

            if (!IsPostBack)
            {
                int id = 0;

                DataSet ds = DbHelperSQL.Query("select * from B2C_mem where ParentID=0  order by id; ");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    getOneClassTree(Convert.ToInt32(dr["id"]), txt_ParentID);
                }

                if (Request["id"] != null)
                {
                    id = Convert.ToInt32(Request["id"]);
                    B2C_mem mem = new B2C_mem(id);
                    //txt_M_no.Text = mem.M_no;
                    drop_M_vip.Value = mem.M_vip.ToString();

                    //txt_M_psw.Text = mem.M_psw;
                    //txt_M_psw2.Text = mem.M_psw2;
                    txt_M_truename.Text = mem.M_truename;
                    txt_M_IDCard.Text = mem.M_IDCard;
                    //txt_M_bank.Text = mem.M_bank;
                    //txt_M_card.Text = mem.M_card;
                    txt_M_mobile.Text = mem.M_mobile;

                    if (mem.M_sex == "男")
                    {
                        radsexman.Checked = true;
                    }
                    else if (mem.M_sex == "女")
                    {
                        radsexwoman.Checked = true;
                    }
                    else if (mem.M_sex == "保密")
                    {
                        radsexbaomi.Checked = true;
                    }
                    txtx_M_QQ.Text = mem.M_QQ;
                    txt_M_email.Text = mem.M_email;
                    txt_M_photo.Text = mem.M_photo;
                    txt_M_addr.Text = mem.M_addr;
                    txt_M_zip.Text = mem.M_zip;
                    //  txt_M_BirthDay.Text = mem.M_BirthDay.ToString();
                    txt_M_tags.Text = mem.M_tags;

                    txt_ParentID.Value = mem.id.ToString();
                    //txt_jieshaoID.Text = mem.jieshaoMobile.ToString();
                    //ss_cityID.Value = mem.cityID.ToString().Trim();
                    //txt_M_star.Text = mem.M_star.ToString();

                    //一些是不能修改的
                    drop_M_vip.Disabled = true;
                    //txt_ParentID.Enabled = false;
                    //txt_jieshaoID.Enabled = false;
                    //ss_cityID.Disabled = true;
                }
                else
                {
                    string _mno = Request["mno"] != null ? Request["mno"].ToString().Trim() : "";
                    string _parentID = Request["parentID"] != null ? Request["parentID"].ToString().Trim() : "0";
                    string _parentMobile = comfun.GetStrByInt("M_mobile", "b2c_mem", "id", Convert.ToInt32(_parentID));
                    txt_M_no.Value = _mno;
                    txt_ParentID.Value = id.ToString();
                }
            }
        }

        private void bind()
        {
            //string sql2 = "select id ,real_name from dt_manager where role_id=5 order by id";
            //DataTable dt2 = comfun.GetDataTableBySQL(sql2);
            //ss_cityID.DataSource = dt2.DefaultView;
            //ss_cityID.DataTextField = "real_name";
            //ss_cityID.DataValueField = "id";
            //ss_cityID.DataBind();

            string sql2 = "select Mvip_id ,mvip_name from B2C_memvip order by Mvip_id";
            DataTable dt2 = comfun.GetDataTableBySQL(sql2);
            drop_M_vip.DataSource = dt2.DefaultView;
            drop_M_vip.DataTextField = "Mvip_name";
            drop_M_vip.DataValueField = "Mvip_id";
            drop_M_vip.DataBind();
            //drop_M_vip.Items.Insert(0, new ListItem("全部", "0"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string sex = "";
            if (radsexman.Checked == true)
            {
                sex = "男";
            }
            else if (radsexwoman.Checked == true)
            {
                sex = "女";
            }
            else if (radsexbaomi.Checked == true)
            {
                sex = "保密";
            }
            //if (txt_jieshaoID.Text.Trim() == "")
            //{
            //    Response.Write("<script language='javascript'>alert('请选择介绍人！');</script>");
            //    return;
            //}
            //if (txt_ParentID.Text.Trim() == "")
            //{
            //    Response.Write("<script language='javascript'>alert('请选择上一节点！');</script>");
            //    return;
            //}
            //if (ss_cityID.Items[ss_cityID.SelectedIndex].Value.Trim() == "0")
            //{
            //    Response.Write("<script language='javascript'>alert('请选择物流中心！');</script>");
            //    return;
            //}


            if (Request["id"] != null)
            {

                try
                {
                    int id = Convert.ToInt32(Request["id"]);

                    DataTable dt = comfun.GetDataTableBySQL("select M_name from B2C_mem where (M_name='" + txt_M_mobile.Text.Trim() + "' or M_idCard='" + txt_M_IDCard.Text.Trim() + "') and id<>" + id.ToString().Trim());
                    //   DataTable dt = comfun.GetDataTableBySQL("select M_name from B2C_mem");
                    if (dt.Rows.Count <= 0)
                    {
                        B2C_mem mem = new B2C_mem(id);
                        //mem.M_no = txt_M_no.Text;
                        //mem.M_vip = drop_M_vip.SelectedIndex;
                        mem.M_name = txt_M_mobile.Text.Trim();
                        if (txt_M_psw.Text.Trim() != "")
                            mem.M_psw = txt_M_psw.Text;
                        if (txt_M_psw2.Text.Trim() != "")
                            mem.M_psw2 = txt_M_psw2.Text;
                        mem.M_truename = txt_M_truename.Text;
                        mem.M_IDCard = txt_M_IDCard.Text;
                        mem.M_sex = sex;
                        mem.M_mobile = txt_M_mobile.Text; ;
                        //mem.M_bank = txt_M_bank.Text;
                        //mem.M_card = txt_M_card.Text;
                        mem.M_QQ = txtx_M_QQ.Text;
                        mem.M_email = txt_M_email.Text; ;
                        mem.M_photo = txt_M_photo.Text;
                        mem.M_addr = txt_M_addr.Text;
                        mem.M_zip = txt_M_zip.Text;
                        //mem.M_BirthDay=
                        mem.M_tags = txt_M_tags.Text;
                        mem.M_isactive = Convert.ToInt32(Request["M_isactive"]);
                        // mem.ParentID = Convert.ToInt32(comfun.GetStrbySQL("id","B2C_mem"," m_mobile='" + txt_ParentID.Text.Trim() + "'"));
                        // mem.jieshaoID = Convert.ToInt32(comfun.GetStrbySQL("id", "B2C_mem", " m_mobile='" + txt_jieshaoID.Text.Trim() + "'"));
                        //mem.cityID = Convert.ToInt32(ss_cityID.Value.Trim());
                        //mem.M_leve = 0;
                        //mem.M_star = 0; 
                        mem.Update();

                        if (Convert.ToInt32(Request["M_isactive"]) == 0)
                        {
                            Response.Write(
                                "<script language='javascript'>alert('修改成功！');location.href='B2C_mem_List_Service_Center.aspx';</script>");
                            Response.End();
                        }
                        else
                        {
                            Response.Write(
    "<script language='javascript'>alert('修改成功！');location.href='B2C_mem_List_Service_Center_isactive.aspx';</script>");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('存在相同的手机号或身份证号！');history.go(-1);</script>");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    DataTable dt = comfun.GetDataTableBySQL("select M_name from B2C_mem where M_name='" + txt_M_mobile.Text.Trim() + "' or M_idCard='" + txt_M_IDCard.Text.Trim() + "'");
                    //   DataTable dt = comfun.GetDataTableBySQL("select M_name from B2C_mem");
                    if (dt.Rows.Count <= 0)
                    {
                        B2C_mem mem = new B2C_mem();
                        mem.AddNew();
                        //mem.M_no = txt_M_no.Text;
                        mem.M_vip = Convert.ToInt32(Request["drop_M_vip"].ToString().Trim());
                        mem.M_name = txt_M_mobile.Text;
                        mem.M_psw = txt_M_psw.Text;
                        mem.M_psw2 = txt_M_psw2.Text;
                        mem.M_truename = txt_M_truename.Text;
                        mem.M_IDCard = txt_M_IDCard.Text;
                        mem.M_sex = sex;
                        mem.M_mobile = txt_M_mobile.Text;
                        //mem.M_bank = txt_M_bank.Text;
                        //mem.M_card = txt_M_card.Text;
                        mem.M_QQ = txtx_M_QQ.Text;
                        mem.M_email = txt_M_email.Text;
                        mem.M_photo = txt_M_photo.Text;
                        mem.M_addr = txt_M_addr.Text;
                        mem.M_zip = txt_M_zip.Text;

                        mem.M_tags = txt_M_tags.Text;
                        mem.M_isactive = Convert.ToInt32(Request["M_isactive"]);

                        string _parentID = txt_ParentID.Value;
                            //comfun.GetStrbySQL("id", "B2C_mem", " m_mobile='" + txt_ParentID.Text.Trim() + "'");
                        if (_parentID == "")
                            _parentID = "0";
                        mem.ParentID = Convert.ToInt32(_parentID);

                        string 
                        //    _jieshaoID = comfun.GetStrbySQL("id", "B2C_mem", " m_mobile='" + txt_jieshaoID.Text.Trim() + "'");
                        //if (_jieshaoID == "")
                            _jieshaoID = "0";
                        mem.jieshaoID = Convert.ToInt32(_jieshaoID);

                        //mem.cityID = Convert.ToInt32(Request["ss_cityID"].ToString().Trim());
                        //mem.M_leve = 0;
                        mem.M_star = 0;

                        mem.Update();

                        if (Convert.ToInt32(Request["M_isactive"])==0)
                        {
                            Response.Write("<script language='javascript'>alert('添加成功！');location.href='B2C_mem_List_Service_Center.aspx';</script>");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('添加成功！');location.href='B2C_mem_List_Service_Center_isactive.aspx';</script>");
                            Response.End();
                        }

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('存在相同的手机号或身份证号！');history.go(-1);</script>");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        ////检查上一节点人
        //protected void btnSubmit0_Click(object sender, EventArgs e)
        //{
        //    string _mobile = txt_ParentID.Text.Trim();
        //    if (comfun.GetStrbySQL("id", "b2c_mem", "m_mobile='" + _mobile + "'").Trim() != "")
        //        Response.Write("<script language='javascript'>alert('上一节点可以使用！');</script>");
        //    else
        //        Response.Write("<script language='javascript'>alert('找不到上一节点！');</script>");
        //    return;
        //}

        ////检查介绍人
        //protected void btnSubmit1_Click(object sender, EventArgs e)
        //{
        //    string _mobile = txt_jieshaoID.Text.Trim();
        //    if (comfun.GetStrbySQL("id", "b2c_mem", "m_mobile='" + _mobile + "'").Trim() != "")
        //        Response.Write("<script language='javascript'>alert('介绍人可以使用！');</script>");
        //    else
        //        Response.Write("<script language='javascript'>alert('找不到介绍人！');</script>");
        //    return;
        //}

        public void getOneClassTree(int classid, System.Web.UI.HtmlControls.HtmlSelect cid)
        {
            string texts = "";
            string values = "";
            int depth = 0;
            B2C_mem cate = new B2C_mem(classid);
            DataTable dt_Have = DbHelperSQL.Query("select * from B2C_mem where ParentID=" + classid + " order by id").Tables[0];
            if (cate.ParentID > 0)
            {
                depth = 1;
            }
            while (depth > 0)
            {
                texts += "　";
                depth = depth - 1;
            }
            values = cate.id.ToString();

            if (dt_Have.Rows.Count == 0)
            {
                texts += " - " + cate.M_name;
                cid.Items.Add(new ListItem(texts, values));
            }
            else
            {
                texts += " + " + cate.M_name;
                cid.Items.Add(new ListItem(texts, values));
                DataTable classidArry1 = DbHelperSQL.Query("select * from B2C_mem where ParentID=" + classid + " order by id").Tables[0];
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getOneClassTree(Convert.ToInt32(dr["id"]), cid);
                }
            }
        }



    }
}