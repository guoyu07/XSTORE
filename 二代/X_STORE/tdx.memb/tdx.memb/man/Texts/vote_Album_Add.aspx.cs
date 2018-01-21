using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Texts
{
    public partial class vote_Album_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>在这里，编辑您的投票项信息。";
            if (!IsPostBack)
            {
                loadOptions();//加载投票项目
                try
                {
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        DataTable Album = comfun.GetDataTableBySQL("select * from vote_Album where id=" + id);
                        _name.Value = Album.Rows[0]["Album_name"].ToString();
                        bigpic_id.Value = Album.Rows[0]["bigpic_id"].ToString();
                        Image1.ImageUrl = Album.Rows[0]["Album_pic"].ToString();
                        _desc.Value = Album.Rows[0]["Album_desc"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/vote_Album_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _Album_name = comFunction.NoHTML(_name.Value);
                int _bigpic_id = int.Parse(bigpic_id.Value);
                string _Album_pic = _pic.Value;
                string _Album_desc = comFunction.NoSt(_desc.Value);

                if (_Album_name == "" || _Album_name.Length > 200)
                {
                    lt_result.Text = "投票名不能为空！且长度不可超过200";
                    return;
                }
                if (_bigpic_id == 0)
                {
                    lt_result.Text = "请选择投票项目！";
                    return;
                }
                //添加图片
                if (_Album_pic != "")
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
                        if (up.UploadPicAsMul3(_pic) != 0)
                        {
                            _Album_pic = up.getTargetFilename();
                        }
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
                if (Request["id"] != null)
                {
                    try
                    {
                        int _id = Convert.ToInt32(Request["id"]);
                        DataTable Album = comfun.GetDataTableBySQL("select * from vote_Album where id=" + _id);
                        string updateSql = string.Empty;
                        if (_Album_pic != "")
                        {
                            updateSql = @"update vote_Album set Album_name='" + _Album_name + "',Album_pic='" + _Album_pic + "',Album_desc='" + _Album_desc + "',bigpic_id=" + _bigpic_id + " where id=" + _id;
                        }
                        else
                        {
                            updateSql = @"update vote_Album set Album_name='" + _Album_name + "',Album_desc='" + _Album_desc + "',bigpic_id=" + _bigpic_id + " where id=" + _id;
                        }
                        int iret = comfun.UpdateBySQL(updateSql);
                        if (iret == 1)
                        {
                            lt_result.Text = "修改成功！";
                        }
                        else
                        { lt_result.Text = "修改失败！"; }
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='vote_Album_List.aspx';},300);</script>";

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
                else
                {
                    try
                    {
                        string insertSql = @"insert into vote_Album(Album_name,Album_pic,Album_desc,bigpic_id) values('" + _Album_name + "','" + _Album_pic + "','" + _Album_desc + "'," + _bigpic_id + ")";
                        int iret = comfun.InsertBySQL(insertSql);
                        if (iret == 1)
                        {
                            lt_result.Text = "添加成功！";
                        }
                        else
                        {
                            lt_result.Text = "添加失败！";
                        }
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='vote_Album_List.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/vote_Album_Add.cs", Session["wID"].ToString());
            }
        }

        #region
        private void loadOptions()
        {
            bigpic_id.Items.Clear();
            DataTable dtOption = comfun.GetDataTableBySQL("select * from vote_bigpic where isactive=1");// and cityID=" + Session["wID"]
            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "--请选择投票项目--";
            bigpic_id.Items.Add(item);
            if (dtOption.Rows.Count > 0)
            {
                foreach (DataRow dr in dtOption.Rows)
                {
                    ListItem options = new ListItem();
                    options.Value = dr["id"].ToString();
                    options.Text = dr["name"].ToString();
                    bigpic_id.Items.Add(options);
                }
            }

        }
        #endregion
    }
}