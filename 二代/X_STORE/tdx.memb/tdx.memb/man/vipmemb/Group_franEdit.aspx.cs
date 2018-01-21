using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.Common;

namespace tdx.memb.man.vipmemb
{
    public partial class Group_franEdit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null && Session["wid"] != null)
                {
                    //编辑
                    B2C_group_fran _bgf = new B2C_group_fran(Convert.ToInt32(Request["id"]));
                    name.Value = _bgf.name;
                    if (_bgf.name.Equals("默认"))
                    {
                        //name.Style.Add("readonly","readonly");
                        name.Attributes.Add("readonly", "readonly");
                    }
                }
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(name.Value.Trim()))
            {
                if (Request["id"] != null && Session["wid"] != null)
                {
                    try
                    {
                        //编辑
                        B2C_group_fran _bgf = new B2C_group_fran(Convert.ToInt32(Request["id"]));
                        _bgf.name = name.Value;
                        _bgf.Update();
                        commonTool.Show_Have_Url(lt_result, "修改成功！", "Group_fran.aspx", 0);
                    }
                    catch
                    {
                        commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);
                    }
                }
                else if (Session["wid"] != null)
                {
                    //添加
                    try
                    {
                        B2C_group_fran _bgf = new B2C_group_fran();
                        _bgf.name = name.Value;
                        _bgf.wid = Convert.ToInt32(Session["wid"]);//对应的公众号ID
                        _bgf.Update();
                        commonTool.Show_Have_Url(lt_result, "添加成功！", "Group_fran.aspx", 0);
                    }
                    catch
                    {
                        commonTool.Show_Have_Url(lt_result, "添加失败！", "", 1);
                    }
                }
            }
            else
            {
                lt_result.Text = "分组名不能为空！";
                return;
            }
        }
    }
}