using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.Common;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.Sets
{
    public partial class welConfig : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["nav"] != null && Request["nav"].ToString().Equals("true"))
                {
                    ltHead.Text = commonTool.DaohangImage("13.jpg");
                    ltFoot.Text = commonTool.DaohangButton("../Sets/B2C_ADS_Add2.aspx?nav=true", "../Texts/wx_keys_Add.aspx?nav=true", "../Texts/wx_keys_Add.aspx?nav=true");
                }
                int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);
                if (_wid == 0)
                {
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        DataTable _dt = comfun.GetDataTableBySQL(string.Format("select top 1 * from wx_mp where wid={0} order by id desc", Session["wid"]));
                        if (_dt.Rows.Count == 0)
                        {
                            string na = "?nav=true";
                            Response.Write("<script language='javascript'>alert('请添加具体要操作的公众号！');location.href='../Sets/wx_mp_add.aspx" + na + "';</script>");
                        }
                        else
                        {
                            int wx_id = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                            Response.Write("<script language='javascript'>location.href='../Sets/welConfig.aspx?wid=" + wx_id + "&nav=true';</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('请先选择具体要操作的公众号！');location.href='../Sets/wx_mp_list.aspx';</script>");
                    }
                    return;
                }
                else
                {
                    string _sql = "select * from B2C_ADS where cityID=" + _wid + " and cno='001'";
                    DataTable dt = comfun.GetDataTableBySQL(_sql);
                    this.Image1.ImageUrl = dt.Rows[0]["a_gif"].ToString();
                }
            }
        }
        protected void btnsave_ServerClick(object sender, EventArgs e)
        {
            if (Request["wid"] != null)
            {
                string str = "";
                try
                {
                    string filePath = GetImage(fileimg.Value);
                    string _wID = Request["wid"].ToString();
                    string _sql = "update B2C_ADS set a_gif='" + filePath + "',a_adGif='" + filePath + "' where cityID=" + _wID + " and cno='001'";
                    //0失败，1成功
                    int i = comfun.UpdateBySQL(_sql);
                    if (Request["nav"] != null && Request["nav"].ToString().Equals("true"))
                    {
                        str += "?nav=true&wid=" + _wID;
                    }
                    else
                    {
                        str += "?wid=" + _wID;
                    }
                    if (i == 0)
                    {
                        Response.Write("<script language='javascript'>alert('修改失败！');location.href='../Sets/welConfig.aspx" + str + "';</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('修改成功！');location.href='../Sets/welConfig.aspx" + str + "';</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('修改失败！');location.href='../Sets/welConfig.aspx" + str + "';</script>");
                }
            }
        }

        private string GetImage(string fileImg)
        {
            if (!string.IsNullOrEmpty(fileImg))
            {
                comUpload up = new comUpload();
                up.clearFileType();
                up.addFileType("jpg");
                up.addFileType("jpeg");
                up.addFileType("gif");
                up.addFileType("png");
                up.addFileType("bmp");
                try
                {
                    if (up.UploadPic(fileimg) != 0)
                    {
                        fileImg = up.getTargetFilename();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return fileImg;
        }
    }
}