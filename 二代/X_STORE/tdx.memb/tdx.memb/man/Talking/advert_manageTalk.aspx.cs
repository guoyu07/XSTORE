﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.Common;
using tdx.database;

namespace tdx.memb.man.Talking
{
    public partial class advert_manageTalk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                advertinfoList();
            }
        }

        private void advertinfoList()
        {
            DataTable dt = comfun.GetDataTableBySQL("select * from advert where types =3 ");

            this.rptList1.DataSource = dt.DefaultView;
            this.rptList1.DataBind();


        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < this.rptList1.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList1.Items[i].FindControl("hideID")).Value);
                CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    int count = comfun.DelbySQL("delete from advert where id=" + id);

                    if (count > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "alert('删除成功')", true);
                    }
                }
            }
            advertinfoList();

        }



    }
}