﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.Goods
{
    public partial class B2C_category_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 编辑您的产品类别。";

                    string _sql = "select top(3) * from B2C_tpage order by id"; // where cityID=" + Session["wID"].ToString().Trim() + "
                    DataTable _tpage = comfun.GetDataTableBySQL(_sql);
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_category tt = new B2C_category(id);
                        txtmc.Value = tt.c_name;
                        Image1.ImageUrl = tt.c_gif;
                        txturl.Value = tt.c_url;
                        txtpx.Value = Convert.IsDBNull(tt.c_sort) ? "" : Convert.ToString(tt.c_sort);
                        txtms.Value = tt.c_des;
                        class_parent.Value = Convert.IsDBNull(tt.c_parent) ? "" : Convert.ToString(tt.c_parent);
                        class_level.Value = Convert.IsDBNull(tt.c_level) ? "" : Convert.ToString(tt.c_level);
                        try
                        {
                            B2C_category parent_cate = new B2C_category(Convert.ToInt32(tt.c_parent));
                            parent_cate = null;
                        }
                        catch (Exception ex)
                        {
                            ;// lt_result.Text = ex.Message;  
                        }
                    }
                    else
                    {
                        if (Request["nav"] != null && Request["nav"].ToString().Equals("true"))
                        {
                            ltHead.Text = commonTool.DaohangImage("4.jpg");
                            ltFoot.Text = commonTool.DaohangButton("../Texts/B2C_tpage_Add2.aspx?id=" + _tpage.Rows[1]["id"] + "&nav=true", "../Goods/B2C_Goods_Add.aspx?nav=true", "../Goods/B2C_Goods_Add.aspx?nav=true");
                        }
                        if (Request["parent"] != null)
                        {
                            class_parent.Value = Request["parent"];
                        }
                        if (Request["level"] != null)
                        {
                            class_level.Value = Request["level"];
                        }
                        try
                        {
                            if (Request["parent"] != null)
                            {
                                int parentID = Convert.ToInt32(Request["parent"]);
                                B2C_category parent_cate = new B2C_category(parentID);
                                parent_cate = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            // lt_result.Text = ex.Message;  
                        }
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/B2C_category_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _mc = comFunction.NoHTML(txtmc.Value);
                string _gif = txtgif.Value;
                string _url = comFunction.NoHTML(txturl.Value);
                int _px = 99;
                int.TryParse(txtpx.Value, out _px);
                string _ms = comFunction.NoHTML(txtms.Value);
                int classparent = Convert.IsDBNull(class_parent.Value) ? 0 : Convert.ToInt32(class_parent.Value);
                int classlevel = Convert.IsDBNull(class_level.Value) ? 1 : Convert.ToInt32(class_level.Value);

                if (_mc == "")
                {
                    lt_result.Text = "类别名称不能为空！";
                    return;
                }
                if (_mc.Length > 200)
                {
                    lt_result.Text = "类别名称字符数不能超过200！";
                    return;
                }
                if (_ms.Length > 300)
                {
                    lt_result.Text = "描述字符数不能超过200！";
                    return;
                }

                //添加图片
                if (_gif != "")
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
                        if (up.UploadPicAsMul(txtgif) != 0)
                        {
                            _gif = up.getTargetFilename();
                        }
                        else
                            _gif = "";
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
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_category tt = new B2C_category(id);
                        tt.c_id = id;

                        tt.c_name = _mc;
                        tt.c_url = _url;
                        if (_gif != "")
                        {
                            tt.c_gif = _gif;
                        }
                        tt.c_sort = _px;
                        tt.c_des = _ms;
                        tt.Update();
                        lt_result.Text = "修改成功.";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_category_List.aspx';},300);</script>";

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
                        B2C_category tt = new B2C_category();
                        tt.Addnew();
                        tt.c_parent = classparent;
                        tt.c_level = classlevel;
                        tt.c_name = _mc;
                        tt.c_url = _url;
                        if (_gif != "")
                        {
                            tt.c_gif = _gif;
                        }
                        tt.c_sort = _px;
                        tt.c_des = _ms;
                        tt.Update();
                        lt_result.Text = "添加成功.";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_category_List.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_category_Add.cs", Session["wID"].ToString());
            }
        }
    }
}