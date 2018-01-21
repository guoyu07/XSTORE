using Creatrue.kernel;
using DTcms.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx_NewWeb.Shop.pages
{
    public partial class managerSetPsd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private DataRow _changeuserinfo;

        protected DataRow ChangeUserInfo
        {
            get
            {
                if (_changeuserinfo == null)
                {
                    if (Request.QueryString["userId"] != null && !string.IsNullOrEmpty(Request.QueryString["userId"].ObjToStr()))
                    {
                        Log.WriteLog("类：managerSetPsd", "方法：ChangeUserInfo", "UserId:" + Request.QueryString["userId"]);
                        var user_sql = string.Format("SELECT * FROM [WP_用户表] WHERE id ={0}", Request.QueryString["userId"].ObjToStr());
                        DataTable user_dt = comfun.GetDataTableBySQL(user_sql);
                        if (user_dt.Rows.Count > 0)
                        {
                            _changeuserinfo = user_dt.Rows[0];
                        }
                        else
                        {
                            RedirectError("用户不存在");
                        }
                    }
                   

                }
                return _changeuserinfo;
            }


        }

        protected void PageInit()
        {
            user_id_input.Value = ChangeUserInfo["id"].ObjToStr();
            name_input.Value = ChangeUserInfo["真实姓名"].ObjToStr();
            phone_input.Value = ChangeUserInfo["手机号"].ObjToStr();
            account_input.Value = ChangeUserInfo["用户名"].ObjToStr();
        }
    }
}