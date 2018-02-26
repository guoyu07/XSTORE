using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XStore.Entity;
using static XStore.Entity.Enum;

namespace XStore.WebSite.WebSite._Ascx
{
    public partial class CenterFooter : System.Web.UI.UserControl
    {
        public string CenterPage = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            CenterPage cp = new CenterPage();

            switch ((UserRoleEnum)cp.userRole.role_id)
            {
                case UserRoleEnum.前台:
                    CenterPage = "EmployeeCenter.aspx";
                    break;
                case UserRoleEnum.区域经理:
                case UserRoleEnum.经理:
                    CenterPage = "ManageCenter.aspx";
                    break;
                default:break;
            }

        }
    }
}