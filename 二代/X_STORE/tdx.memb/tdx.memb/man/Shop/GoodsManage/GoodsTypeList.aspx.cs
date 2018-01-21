using Creatrue.Common.Msgbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using tdx.database;
using System.Web.UI.WebControls;
using DTcms.Model;


namespace tdx.memb.man.Shop.GoodsManage
{
    public partial class GoodsTypeList : System.Web.UI.Page
    {
        DTcms.BLL.WP_商品类别表 splbbll = new DTcms.BLL.WP_商品类别表();

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                goodstypeshow();
            }
        }

       public void  goodstypeshow()
       {
         DataTable dt=  splbbll.GetList(" 1=1 order by id desc").Tables[0];

         if (dt.Rows.Count>0)
         {
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

            for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DTcms.Model.WP_商品类别表 model = splbbll.GetModel(id);
                    bool res = splbbll.Delete(id);
                    string typeno = model.类别编号;
                    List<DTcms.Model.WP_商品表> goods = new DTcms.BLL.WP_商品表().GetModelList(" 类别号='" + typeno + "'");
                    if (goods != null)
                    {
                        foreach (DTcms.Model.WP_商品表 g in goods)
                        {
                            new DTcms.BLL.WP_商品表().Delete(g.id);
                            List<DTcms.Model.WP_商品图片表> imgs = new DTcms.BLL.WP_商品图片表().GetModelList(" 商品编号='" + g.编号+"'");
                            if (imgs != null)
                            {
                                foreach (DTcms.Model.WP_商品图片表 m in imgs)
                                {
                                    new DTcms.BLL.WP_商品图片表().Delete(m.id);
                                }
                            }
                        }
                    }
                    if (res)
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            goodstypeshow();
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "location.href='GoodsTypeList.aspx'", true);
        }
        #endregion

    }
}