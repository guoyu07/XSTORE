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
    public partial class wx_acm_action_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，编辑您的猜谜活动。";
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
                        wx_acm_action goods = new wx_acm_action(id);
                        foreach (ListItem li in lid.Items)
                        {
                            if (goods.lid.IndexOf("," + li.Value + ",") != -1)    //如果li.Value值等于某值,就钩选
                            {
                                li.Selected = true;
                            }
                        }
                        hid.Items.FindByValue(goods.hid.ToString()).Selected = true;
                        whid.Items.FindByValue(goods.whid.ToString()).Selected = true;

                        ac_name.Value = goods.ac_name;
                        ac_bdate.Value = goods.bdate.ToString();
                        ac_edate.Value = goods.edate.ToString();
                        ac_freq.Value = goods.freq.ToString();
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/wx_acm_action_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            try
            {

                string _ac_name = comFunction.NoHTML(ac_name.Value);
                string _ac_freq = comFunction.NoHTML(ac_freq.Value);
                string _ac_bdate = ac_bdate.Value;
                string _ac_edate = ac_edate.Value;
                string _lid = ",";
                foreach (ListItem item in lid.Items)
                {
                    if (item.Selected == true)
                        _lid += item.Value + ",";
                }
                string _hid = hid.Value;
                string _whid = whid.Value;

                if (_ac_name.Trim() == "")
                {
                    lt_result.Text = "请输入活动标题！";
                    return;
                }
                if (_ac_name.Length > 255)
                {
                    lt_result.Text = "活动标题的字符数不能超过255！";
                    return;
                }


                if (Request["id"] != null)
                {
                    try
                    {
                        wx_acm_action goods = new wx_acm_action(Convert.ToInt32(Request["id"]));
                        goods.lid = _lid;
                        goods.hid = Convert.ToInt32(_hid);
                        goods.whid = Convert.ToInt32(_whid);

                        goods.ac_name = _ac_name;
                        goods.freq = Convert.ToInt32(_ac_freq);
                        goods.bdate = Convert.ToDateTime(_ac_bdate);
                        goods.edate = Convert.ToDateTime(_ac_edate);

                        goods.Update();
                        lt_result.Text = "修改成功！";

                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_action_List.aspx';},300);</script>";
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
                        wx_acm_action goods = new wx_acm_action();
                        goods.AddNew();
                        goods.lid = _lid;
                        goods.hid = Convert.ToInt32(_hid);
                        goods.whid = Convert.ToInt32(_whid);

                        goods.ac_name = _ac_name;
                        goods.freq = Convert.ToInt32(_ac_freq);
                        goods.bdate = Convert.ToDateTime(_ac_bdate);
                        goods.edate = Convert.ToDateTime(_ac_edate);


                        goods.Update();
                        lt_result.Text = "添加成功！";

                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_action_List.aspx';},300);</script>";

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/wx_acm_action_Add.cs", Session["wID"].ToString());
            }
        }
    }
}