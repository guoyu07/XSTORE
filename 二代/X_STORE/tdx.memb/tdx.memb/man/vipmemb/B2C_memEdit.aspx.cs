using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using Creatrue.Common;
using System.Data;

namespace tdx.memb.man.vipmemb
{
    public partial class B2C_memEdit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 编辑您的微信会员信息";
                    if (Request["id"] != null)
                    {
                        int id = 0;
                        if (int.TryParse(Request["id"].ToString(), out id))
                        {
                            B2C_mem b2c = new B2C_mem(id);
                            M_name.Value = b2c.M_name;
                            if (Session["wID"] != null && Session["wID"].ToString() == "56")
                            {
                                //DPID.Style.Remove(HtmlTextWriterStyle.Display);
                                DPID.Attributes.CssStyle.Remove("display");
                                CarNo.Attributes.CssStyle.Remove("display");
                                //M_DPID.Value = b2c.M_DPID;
                                //M_CarNo.Value = b2c.M_CarNo;
                            }

                            M_sex.Value = b2c.M_sex;
                            M_tags.Value = b2c.M_tags;
                            //M_xueli.Value = b2c.M_xueli;
                            M_addr.Value = b2c.M_addr;

                            //M_tel.Value = b2c.M_tel;
                            //M_fax.Value = b2c.M_fax;
                            M_mobile.Value = b2c.M_mobile;
                            M_BirthDay.Value = b2c.M_BirthDay.ToString();
                            M_email.Value = b2c.M_email;
                            M_QQ.Value = b2c.M_QQ;
                            m_ph.Src = b2c.M_photo;
                        }
                    }
                    else
                    {
                        if (Session["wID"] != null && Session["wID"].ToString() == "56")
                        {
                            //DPID.Style.Remove(HtmlTextWriterStyle.Display);
                            DPID.Attributes.CssStyle.Remove("display");

                            CarNo.Attributes.CssStyle.Remove("display");
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/B2C_memEdit.cs", Session["wID"].ToString());
                }
            }
        }

        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            try
            {
                B2C_mem b2c;
                if (Request["id"] != null)
                    b2c = new B2C_mem(Convert.ToInt32(Request["id"]));
                else
                {
                    b2c = new B2C_mem();
                    b2c.AddNew();
                }

                //b2c.cityID = Convert.ToInt32(Session["wid"]);
                b2c.M_name = comFunction.NoHTML(M_name.Value);
                //b2c.M_psw = M_psw.Value;
                b2c.M_sex = M_sex.Value;
                b2c.M_tags = comFunction.NoHTML(M_tags.Value);
                //b2c.M_xueli = M_xueli.Value;
                b2c.M_addr = comFunction.NoHTML(M_addr.Value);
                //wx.qr_code = qr_code.Value;
                //b2c.M_tel = comFunction.NoHTML(M_tel.Value);
                //b2c.M_fax = comFunction.NoHTML(M_fax.Value);
                b2c.M_mobile = comFunction.NoHTML(M_mobile.Value);
                if (Session["wID"] != null && Session["wID"].ToString() == "56")
                {
                    //DPID.Style.Remove(HtmlTextWriterStyle.Display);                            
                    //b2c.M_DPID = comFunction.NoHTML(M_DPID.Value);
                    //b2c.M_CarNo = comFunction.NoHTML(M_CarNo.Value);
                }

                if (M_BirthDay.Value != "")
                {
                    b2c.M_BirthDay = Convert.ToDateTime(M_BirthDay.Value);
                }
                else
                {
                    b2c.M_BirthDay = DateTime.Parse("1900-1-1");
                }
                b2c.M_email = comFunction.NoHTML(M_email.Value);
                b2c.M_QQ = comFunction.NoHTML(M_QQ.Value);
                if (!commonTool.RemindMessageEmpty(lt_result, b2c.M_name, "会员名不能为空！", ""))
                    return;


                if (!commonTool.RemindMessageEmpty(lt_result, b2c.M_mobile, "手机不能为空！", ""))
                    return;

                if (!commonTool.RemindMessageLengh(lt_result, b2c.M_name.Length, 50, "会员名长度不能超过50！", ""))
                    return;
                if (!commonTool.IsMobilePhone(b2c.M_mobile))
                {
                    commonTool.Show_Have_Url(lt_result, "手机号不合法！请输入11位有效手机号", "", 1);
                    return;
                }

                if (!commonTool.RemindMessageEmpty(lt_result, b2c.M_sex, "性别不能为空！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, b2c.M_tags.Length, 255, "标签长度不能超过50！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, b2c.M_addr.Length, 255, "地址长度不能超过50！", ""))
                    return;
                //if (!commonTool.RemindMessageLengh(lt_result, b2c.M_tel.Length, 20, "电话长度不能超过20！", ""))
                //    return;
                //if (!commonTool.RemindMessageLengh(lt_result, b2c.M_fax.Length, 20, "传真长度不能超过20！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, b2c.M_email.Length, 20, "邮箱长度不能超过20！", ""))
                    return;
                if (b2c.M_email != "" && !commonTool.IsEmail(b2c.M_email))
                {
                    lt_result.Text = "邮箱输入不合法，请输入有效的邮箱";
                    return;
                }
                if (!commonTool.RemindMessageLengh(lt_result, b2c.M_QQ.Length, 20, "QQ长度不能超过20！", ""))
                    return;
                //if (!commonTool.RemindMessageLengh(lt_result, b2c.M_DPID.Length, 50, "BPID长度不能超过50！", ""))
                //    return;
                //if (!commonTool.RemindMessageLengh(lt_result, b2c.M_CarNo.Length, 50, "车架号长度不能超过50！", ""))
                //    return;



                ///处理图片开始
                string _photo = M_photo.Value; //会员头像
                if (_photo != "")
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
                        if (up.UploadPicAsMul(M_photo) != 0)
                        {
                            _photo = up.getTargetFilename();
                            b2c.M_photo = _photo;
                        }
                    }
                    finally { up = null; }

                }
                ///处理图片结束

                if (Request["id"] != null)
                {
                    try
                    {
                        string _phone = "select * from B2C_mem where id <>" + Request["id"].ToString() + " and M_mobile=" + b2c.M_mobile;//cityID=" + Session["wID"].ToString() + " and
                        DataTable _dt = comfun.GetDataTableBySQL(_phone);
                        if (_dt != null && _dt.Rows.Count > 0)
                        {
                            lt_result.Text = "已存在相同的手机号,修改失败";
                            return;
                        }
                        b2c.Update();
                        commonTool.Show_Have_Url(lt_result, "修改成功！", "B2C_memList.aspx", 0);

                    }
                    catch (System.Exception ex)
                    {
                        commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);
                    }
                }
                else
                {
                    try
                    {

                        DataTable dt_mem = B2C_mem.GetList("*", ""); //, string.Format(" cityID={0}", b2c.cityID)
                        int flag = 0;
                        foreach (DataRow dr in dt_mem.Rows)
                        {
                            if (dr["M_name"].ToString() == M_name.Value)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            string _phone = "select * from B2C_mem where M_mobile=" + b2c.M_mobile; // cityID=" + Session["wID"].ToString() + " and
                            DataTable _tab = comfun.GetDataTableBySQL(_phone);
                            if (_tab != null && _tab.Rows.Count > 0)
                            {
                                lt_result.Text = "已存在相同的手机号,无法添加！";
                                return;
                            }
                            b2c.Update();
                            string _sql = "top 1 *";
                            string _where = string.Format(" order by id desc"); //cityID={0} , b2c.cityID
                            DataTable _dt = B2C_mem.GetList(_sql, _where);
                            int mem_id = Convert.ToInt32(_dt.Rows[0]["id"]);
                            B2C_rankinfo.OpenCard(mem_id); //, b2c.cityID
                            commonTool.Show_Have_Url(lt_result, "添加成功！", "B2C_memList.aspx", 0);
                        }
                        else
                        {
                            commonTool.Show_Have_Url(lt_result, "用户名重复！", "", 1);
                        }

                    }
                    catch (System.Exception ex)
                    {
                        commonTool.Show_Have_Url(lt_result, "添加失败！", "", 1);
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/B2C_memEdit.cs", Session["wID"].ToString());
            }
        }


    }
}