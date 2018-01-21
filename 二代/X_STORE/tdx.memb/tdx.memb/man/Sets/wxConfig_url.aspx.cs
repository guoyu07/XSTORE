using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;

namespace tdx.memb.man.Sets
{
    public partial class wxConfig_url : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lb_catelist.Text = ClassList();
            }
        }

        #region 读取数据
        protected string ClassList()
        {
            #region 获取大类数据
            string str = "";

            //str += @"        <tr>";
            //str += @"          <td align=left height='25'>微网站</td>";
            //str += @"          <td align=center>http://www.tdx.cn/" + B2C_worker.currentGNTheme() + "/?wwx=" + B2C_worker.currentWWX() + "</td>";
            //str += @"        </tr>";
            //str += @"        <tr>";
            //str += @"          <td align=left height='25'>微商城</td>";
            //str += @"          <td align=center>http://www.tdx.cn/appx/Goodslist.aspx?wwx=" + B2C_worker.currentWWX() + "</td>";
            //str += @"        </tr>";
            //str += @"        <tr>";
            //str += @"          <td align=left height='25'>微团购</td>";
            //str += @"          <td align=center>http://www.tdx.cn/appx/teamlist.aspx?wwx=" + B2C_worker.currentWWX() + "</td>";
            //str += @"        </tr>";
            //str += @"        <tr>";
            //str += @"          <td align=left height='25'>微秒杀</td>";
            //str += @"          <td align=center>http://www.tdx.cn/appx/mslist.aspx?wwx=" + B2C_worker.currentWWX() + "</td>";
            //str += @"        </tr>";
            #endregion

            return str;
        }
        #endregion


    }
}