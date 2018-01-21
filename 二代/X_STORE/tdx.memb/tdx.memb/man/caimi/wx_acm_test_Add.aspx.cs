using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.caimi
{
    public partial class wx_acm_test_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，编辑您的谜语。";
                    string _sql = "select * from wx_acm_level;select * from wx_acm_holiday;select * from wx_acm_with";
                    DataSet ds = comfun.GetDataSetBySQL(_sql);
                    this.lid.DataSource = ds.Tables[0]; //这里我绑到DataTable上了.
                    this.lid.DataTextField = "c_name"; //前台看到的值,也就是CheckBoxList中显示出来的值
                    this.lid.DataValueField = "id"; //这个值直接在页面上是看不到的,但在源代码中可以看到
                    this.lid.DataBind();

                    this.hid.DataSource = ds.Tables[1]; //这里我绑到DataTable上了.
                    this.hid.DataTextField = "c_name"; //前台看到的值,也就是CheckBoxList中显示出来的值
                    this.hid.DataValueField = "id"; //这个值直接在页面上是看不到的,但在源代码中可以看到
                    this.hid.DataBind();

                    this.whid.DataSource = ds.Tables[2]; //这里我绑到DataTable上了.
                    this.whid.DataTextField = "c_name"; //前台看到的值,也就是CheckBoxList中显示出来的值
                    this.whid.DataValueField = "id"; //这个值直接在页面上是看不到的,但在源代码中可以看到
                    this.whid.DataBind();

                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        wx_acm_test goods = new wx_acm_test(id);
                        lid.Items.FindByValue(goods.lid.ToString()).Selected = true;

                        foreach (ListItem li in hid.Items)
                        {
                            if (goods.hid.IndexOf("," + li.Value + ",") != -1)    //如果li.Value值等于某值,就钩选
                            {
                                li.Selected = true;
                            }
                        }
                        foreach (ListItem li in whid.Items)
                        {
                            if (goods.whid.IndexOf("," + li.Value + ",") != -1)    //如果li.Value值等于某值,就钩选
                            {
                                li.Selected = true;
                            }
                        }

                        t_title.Value = goods.t_title;
                        t_answer.Value = goods.t_answer;
                        t_des.Value = goods.t_cont;
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/wx_acm_test_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            try
            {

                string _t_title = comFunction.NoHTML(t_title.Value);
                string _t_cont = comFunction.NoHTML(t_des.Value);
                string _t_answer = comFunction.NoHTML(t_answer.Value);
                string _lid = lid.Value;
                string _hid = ",";
                foreach (ListItem item in hid.Items)
                {
                    if (item.Selected == true)
                        _hid += item.Value + ",";
                }

                string _whid = ",";
                foreach (ListItem item in whid.Items)
                {
                    if (item.Selected == true)
                        _whid += item.Value + ",";
                }

                if (_t_title.Trim() == "")
                {
                    lt_result.Text = "请输入谜面！";
                    return;
                }
                if (_t_title.Length > 255)
                {
                    lt_result.Text = "谜面的字符数不能超过255！";
                    return;
                }
                if (_t_answer.Trim() == "")
                {
                    lt_result.Text = "请输入答案！";
                    return;
                }
                if (_t_answer.Length > 20)
                {
                    lt_result.Text = "答案的字符数不能超过20！";
                    return;
                }


                if (Request["id"] != null)
                {
                    try
                    {
                        wx_acm_test goods = new wx_acm_test(Convert.ToInt32(Request["id"]));
                        goods.lid = Convert.ToInt32(_lid);
                        goods.hid = _hid;
                        goods.whid = _whid;

                        goods.t_title = _t_title;
                        goods.t_answer = _t_answer;
                        goods.t_cont = _t_cont;

                        goods.Update();
                        lt_result.Text = "修改成功！";

                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_test_List.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
                else
                {
                    try
                    {
                        wx_acm_test goods = new wx_acm_test();
                        goods.AddNew();
                        goods.lid = Convert.ToInt32(_lid);
                        goods.hid = _hid;
                        goods.whid = _whid;

                        goods.t_title = _t_title;
                        goods.t_answer = _t_answer;
                        goods.t_cont = _t_cont;


                        goods.Update();
                        lt_result.Text = "添加成功！";

                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_test_List.aspx';},300);</script>";

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/wx_acm_test_Add.cs", Session["wID"].ToString());
            }
        }
    }
}