using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.Weixin;

namespace jnsywx.appv
{
    public partial class tpage : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');

                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');

                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = " <meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\" />";
                lt_description.Text = " <meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_theme.Text = " <link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssIndex/" + _theme[0] + "/comm.css\" />";
                lt_theme.Text += " <link rel=\"stylesheet\" type=\"text/css\" href=\"/images/cssDetail/" + _theme[2] + "/detail.css\" />";
                //lt_theme2.Text = _tdxWeixinArry[2];

                int id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                if (id == 0)
                {
                    Response.Write("<p>您找的单页面不存在</p>");
                    return;
                }
                else
                {

                    string sql = "select * from b2c_tpage where id='" + id + "'";
                    DataSet ds = comfun.GetDataSetBySQL(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lt_title.Text = ds.Tables[0].Rows[0]["gtitle"].ToString();

                        lt_proTitle.Text = ds.Tables[0].Rows[0]["gtitle"].ToString();//bt.cname;
                        lt_proAuthor.Text = "";
                        lt_proDate.Text = ds.Tables[0].Rows[0]["regtime"].ToString() != null ? ("发布:" + ds.Tables[0].Rows[0]["regtime"].ToString()) : "";

                        lt_newsContent.Text = ds.Tables[0].Rows[0]["gcontent"].ToString();
                    }
                }

                try
                {
                    //B2C_worker bw = new B2C_worker(Convert.ToInt32(_tdxWeixinArry[0]));
                    string sql0 = "select * from  dt_manager where id= 1";
                    DataSet ds0 = comfun.GetDataSetBySQL(sql0);

                    lt_tel.Text = "<a href='tel:" + ds0.Tables[0].Rows[0]["telephone"] + "'><img src=\"/images/icon_tel.png\">拨打电话</a>";
                }
                catch (Exception ex) { }
            }


        }
    }
}