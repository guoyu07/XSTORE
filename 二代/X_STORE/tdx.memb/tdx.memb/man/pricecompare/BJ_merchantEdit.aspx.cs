using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.Common;

namespace tdx.memb.man.pricecompare
{
    public partial class BJ_merchantEdit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null && Session["wid"] != null)
                {
                    //编辑
                    BJ_obj _bo = new BJ_obj(Convert.ToInt32(Request["id"]));
                    name.Value = _bo.name;
                }
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            BJ_obj _bo;
            if (Request["id"] != null)
                _bo = new BJ_obj(Convert.ToInt32(Request["id"]));
            else
                _bo = new BJ_obj();
            _bo.name = name.Value;
            _bo.wid = Convert.ToInt32(Session["wid"]);

            if (!commonTool.RemindMessageEmpty(lt_result, _bo.name, "商城名称不能为空！", ""))
                return;
            if (!commonTool.RemindMessageLengh(lt_result, _bo.name.Length, 50, "商城名称长度不能超过50", ""))
                return;
            if (Request["id"] != null)
            {
                try
                {
                    //编辑

                    _bo.name = name.Value;
                    _bo.Update();
                    commonTool.Show_Have_Url(lt_result, "修改成功！", "BJ_merchant.aspx", 0);
                }
                catch (Exception ex)
                {
                    commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);
                }
            }
            else if (Session["wid"] != null)
            {
                try
                {
                    _bo.Update();
                    commonTool.Show_Have_Url(lt_result, "添加成功！", "BJ_merchant.aspx", 0);
                }
                catch (Exception ex)
                {
                    commonTool.Show_Have_Url(lt_result, "添加失败！", "", 1);
                }
            }

        }
    }
}