using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;

namespace tdx.memb.man
{
    public partial class daohang : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int _wid = Session["wID"] != null ? Convert.ToInt32(Session["wID"].ToString().Trim()) : 0;
                if (_wid == 0)
                    Response.Redirect("/");

                //try
                //{
                //    B2C_worker bw = new B2C_worker(_wid);
                //    //lt_mem.Text = bw.M_name + ",欢迎回来. 您的等级为： " + bw.Mvipname + ".";
                //}
                //catch (Exception ex) { }

                //string _sql = "select * from wx_actions2 order by id;select * from wx_actions order by id";
                //DataSet ds = comfun.GetDataSetBySQL(_sql);
                //string result = "";
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    result += "\r\n <li> <input type=\"checkbox\" name=\"chk" + dr["id"].ToString() + "\" value=\"" + dr["id"].ToString() + "\" checked />" + dr["ac_name"].ToString() + " </li>";
                //}
                //lt_1.Text = result;
                //result = "";
                //foreach (DataRow dr in ds.Tables[1].Rows)
                //{
                //    result += "\r\n <li> <input type=\"checkbox\" name=\"chk" + dr["id"].ToString() + "\" value=\"" + dr["id"].ToString() + "\" checked />" + dr["ac_name"].ToString() + " </li>";
                //}
                //lt_2.Text = result;  
            }
        }
    }
}