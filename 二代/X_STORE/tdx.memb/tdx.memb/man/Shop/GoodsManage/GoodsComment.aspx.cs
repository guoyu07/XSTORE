using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Shop.GoodsManage
{
    public partial class GoodsComment : System.Web.UI.Page
    {
        string spid = "0";
        string types = "WP";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 spid= string.IsNullOrEmpty(Request["spid"]) ? "0" : Request["spid"];
                 types= string.IsNullOrEmpty(Request["types"]) ? "0" : Request["types"];

                DataTable dt = comfun.GetDataTableBySQL(" select a.*,b.类别号,b.编号new ,b.品名,b.规格,c.wx昵称 as 评论人,c.wx头像 from WP_商品评论表 a left join WP_商品表 b on a.商品id=b.id left join WP_会员表 c on a.openid=c.openid where a.商品id=" + spid + " and types='" + types + "' order by a.createtime desc ");
                Rp_UserInfo.DataSource = dt.DefaultView;
                Rp_UserInfo.DataBind();

            }
        }


        #region 4.0 删除 +void btnDelete_Click(object sender, EventArgs e)
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool a = false;
            for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    int res = comfun.DelbySQL(" delete from WP_商品评论表 where id=" + id + " ");
                    if (res > 0)
                    {
                        a = true;
                    }
                }
            }
            if (a == true)
            {
                MessageBox.Show(this, "删除成功！");
            }
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsComment.aspx?spid="+spid+" &types='"+types+"'' ", true);
        }
        #endregion


    }
}