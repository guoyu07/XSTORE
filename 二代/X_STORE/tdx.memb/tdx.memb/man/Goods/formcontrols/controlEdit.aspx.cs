using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.formcontrols
{
    public partial class controlEdit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request["objid"] != null)
            {

                try
                {
                    //添加
                    //pay.Checked = true;

                    wid.Value = Request["objid"].ToString();
                    isE.Value = "0";
                    SetRank(0);
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "memb/formcontrols/controlEdit.cs", Session["wID"].ToString());
                }

            }
        }
        internal void SetRank(int id)
        {
            DataTable dt = control_dict.GetList("*", "1=1");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem lt;
                lt = new ListItem();
                lt.Value = dt.Rows[i]["id"].ToString();
                lt.Text = dt.Rows[i]["name"].ToString();
                select_type.Items.Add(lt);
            }
            if (select_type.Items.Count > 0)
            {
                select_type.SelectedIndex = 0;
            }

        }
    }
}