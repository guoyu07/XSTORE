﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using Creatrue.Common;

namespace tdx.memb.man.Goods
{
    public partial class B2C_Goods_Add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>在这里，编辑您的产品信息。";
            if (!IsPostBack)
            {
                add_leib.Text = "<a href=\"B2C_category_Add.aspx\" class=\"linkAddType\">";
                add_leib.Text += "<asp:Image ID=\"Image2\" runat=\"server\" ImageUrl=\"/man/images4/wh.png\" />没有您想要的？点此添加</a>";
                try
                {
                    if (Request["nav"] != null && Request["nav"].ToString().Equals("true"))
                    {
                        add_leib.Text = "";
                        ltHead.Text = commonTool.DaohangImage("daohang_9.jpg");
                        ltFoot.Text = commonTool.DaohangButton("../Texts/B2C_tpage_Add.aspx?nav=true", "../Texts/B2C_tmsg_Add.aspx?nav=true", "../Texts/B2C_tmsg_Add.aspx?nav=true");//B2C_tclass_Add.aspx?parent=0&level=1&nav=true
                    }//                                                      and cityID=" + Session["wID"].ToString().Trim() + "         where cityID=" + Session["wID"].ToString().Trim() + "   where cityID=" + Session["wid"].ToString().Trim() + "     where  cityID=" + Session["wID"].ToString().Trim() + "
                    DataSet ds = comfun.GetDataSetBySQL("select * from B2C_category where c_parent=0 order by c_id; select cno from B2C_Goods group by cno;select g_unit from b2c_goods group by g_unit   ; select * from B2C_brand where c_parent=0 order by c_no ");
                    /////////添加品牌的加载
                  
                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        B2C_brand.getOneClassTree(Convert.ToInt32(dr["c_id"]), sbid);
                      
                    }
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        B2C_Goods.getCategoryClassTree(Convert.ToInt32(dr["c_id"]), cid);
                    }
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        unit2.Items.Add(new ListItem(dr["g_unit"].ToString(), dr["g_unit"].ToString()));
                    }
                    if (Request["id"] != null)
                    {
                        int id = Convert.ToInt32(Request["id"]);
                        B2C_Goods tt = new B2C_Goods(id);
                        title.Value = tt.g_title;
                        name.Value = tt.g_name;
                        Image1.ImageUrl = tt.g_gif;
                        price_B.Value = Convert.IsDBNull(tt.g_price_B) ? "0.00" : Convert.ToString(tt.g_price_B);
                        price_M.Value = Convert.IsDBNull(tt.g_price_M) ? "0.00" : Convert.ToString(tt.g_price_M);
                        price_S.Value = Convert.IsDBNull(tt.g_price_S) ? "0.00" : Convert.ToString(tt.g_price_S);
                        cent.Value = Convert.IsDBNull(tt.g_cent) ? "0.00" : Convert.ToString(tt.g_cent);
                        lowN.Value = Convert.IsDBNull(tt.g_lowN) ? "0.00" : Convert.ToString(tt.g_lowN);
                        no.Value = tt.g_no;
                        txm.Value = tt.g_txm;
                        unit.Value = tt.g_unit;
                        Image1.ImageUrl = tt.g_gif;
                        _url.Value = tt.g_URL;
                        sort.Value = Convert.IsDBNull(tt.g_sort) ? "99" : Convert.ToString(tt.g_sort);
                        rd_buytype.Value = tt.g_buytype.ToString();
                        rd_xn.Value = tt.g_xuni.ToString();
                        des.Value = tt.g_des;
                        filename.Value = tt.g_filename;
                        _key.Value = tt.g_key;
                        _description.Value = tt.g_description;
                        cid.Items.FindByValue(tt.cno).Selected = true;
                        /////增加默认选项
                        if (!string.IsNullOrEmpty(tt.bno))
                        {
                            sbid.Items.FindByValue(tt.bno).Selected = true;
                        }
                        bid.Value = tt.bno;

                        try
                        {
                            B2C_Goods_M bgm = new B2C_Goods_M(id);
                            _msg.Value = bgm.g_msg;
                        }
                        catch (Exception exe)
                        {
                            comfun.ChuliException(exe, "man/Goods/B2C_Goods_Add.cs", Session["wID"].ToString());
                        }
                    }
                    else
                    {
                        foreach (ListItem item in cid.Items)
                        {
                            if (item.Value != "")
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                        foreach (ListItem item in sbid.Items)
                        {
                            if (item.Value != "")
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                        sort.Value = "99";
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/goods/B2C_Goods_Add.cs", Session["wID"].ToString());
                }
            }
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _cid = comFunction.NoHTML(cid.Value);
                string _bid = comFunction.NoHTML(sbid.Value);
                string _g_title = comFunction.NoHTML(title.Value);
                string _g_name = comFunction.NoHTML(name.Value);

                double _g_price_B = 0.00;
                double _g_price_M = 0.00;
                double _g_price_S = 0.00;
                double _g_cent = 0.00;
                double _g_lowN = 0.00;

                double.TryParse(price_B.Value, out _g_price_B);
                double.TryParse(price_M.Value, out _g_price_M);
                double.TryParse(price_S.Value, out _g_price_S);
                double.TryParse(cent.Value, out _g_cent);
                double.TryParse(lowN.Value, out _g_lowN);

                string _g_no = comFunction.NoHTML(no.Value);
                string _g_txm = comFunction.NoHTML(txm.Value);
                string _g_unit = comFunction.NoHTML(unit.Value);
                string _g_gif = gif.Value;
                string _g_URL = comFunction.NoHTML(_url.Value);
                int _g_sort = 99;
                int.TryParse(sort.Value, out _g_sort);
                int _g_buytype = Convert.ToInt32(rd_buytype.Value);
                int _g_xuni = Convert.ToInt32(rd_xn.Value);
                string _g_des = comFunction.NoHTML(des.Value);
                string _g_filename = comFunction.NoHTML(filename.Value);
                string _g_key = _key.Value;
                string _g_description = comFunction.NoHTML(_description.Value);
                string _g_msg = comFunction.NoSt(_msg.Value);
                string _g_down = "";
                if (_cid == ""&&_bid=="")
                {
                    lt_result.Text = "请选择类别或品牌！";
                    return;
                }
                if (_g_name == "")
                {
                    lt_result.Text = "产品名称不能为空！";
                    return;
                }
                if (_g_name.Length > 200)
                {
                    lt_result.Text = "产品名称字符数不能超过200！";
                    return;
                }
                if (_g_unit.Length > 200)
                {
                    lt_result.Text = "单位字符数不能超过200！";
                    return;
                }
                if (_g_des.Length > 300)
                {
                    lt_result.Text = "单位字符数不能超过200！";
                    return;
                }

                //添加图片
                if (_g_gif != "")
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
                        if (up.UploadPicAsMul3(gif) != 0)
                        {
                            _g_gif = up.getTargetFilename();
                        }
                        else
                        {
                            lt_result.Text = "尺寸太大或者没有选择上传文件！";
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                        return;
                    }
                }

                if (Request["id"] != null)
                {
                    try
                    {

                        int _id = Convert.ToInt32(Request["id"]);
                        B2C_Goods tt = new B2C_Goods(_id);
                        tt.id = _id;
                        tt.cno = _cid;
                        tt.bno = _bid;
                        tt.g_cent = _g_cent;
                        tt.g_des = _g_des;
                        tt.g_description = _g_description;
                        tt.g_filename = _g_filename;
                        tt.g_key = _g_key;
                        tt.g_name = _g_name;
                        tt.g_no = _g_no;
                        tt.g_price_B = _g_price_B;
                        tt.g_price_M = _g_price_M;
                        tt.g_price_S = _g_price_S;
                        tt.g_lowN = _g_lowN;
                        tt.g_sort = _g_sort;
                        tt.g_buytype = _g_buytype;
                        tt.g_xuni = _g_xuni;
                        tt.g_title = _g_title;
                        tt.g_txm = _g_txm;
                        tt.g_unit = _g_unit;
                        tt.g_URL = _g_URL;
                        tt.regtime = DateTime.Now;
                        tt.g_sym = comSUOYIN.GetSUOYIN(_g_name) + "|" + comSUOYIN.GetQuanpin(_g_name);
                        if (_g_gif != "")
                        {
                            tt.g_gif = _g_gif;
                        }
                        if (_g_down != "")
                        {
                            tt.g_gif2 = _g_down;
                        }
                        tt.Update();
                        try
                        {
                            B2C_Goods_M bgm = new B2C_Goods_M(_id);
                            bgm.g_msg = _g_msg;
                            bgm.Update();
                        }
                        catch
                        {
                            B2C_Goods_M bgm = new B2C_Goods_M();
                            bgm.gid = _id;
                            bgm.g_msg = _g_msg;
                            bgm.Update();
                            // throw new Exception(ex1.Message);
                        }
                        lt_result.Text = "修改成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Goods_List.aspx';},300);</script>";


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
                        B2C_Goods tt = new B2C_Goods();
                        tt.Addnew();
                        tt.cno = _cid;
                        tt.bno = _bid;
                        tt.g_cent = _g_cent;
                        tt.g_des = _g_des;
                        tt.g_description = _g_description;
                        tt.g_filename = _g_filename;
                        tt.g_key = _g_key;
                        tt.g_name = _g_name;
                        tt.g_no = _g_no;
                        tt.g_price_B = _g_price_B;
                        tt.g_price_M = _g_price_M;
                        tt.g_price_S = _g_price_S;
                        tt.g_lowN = _g_lowN;
                        tt.g_sort = _g_sort;
                        tt.g_buytype = _g_buytype;
                        tt.g_xuni = _g_xuni;
                        tt.g_title = _g_title;
                        tt.g_txm = _g_txm;
                        tt.g_unit = _g_unit;
                        tt.g_URL = _g_URL;
                        if (_g_gif != "")
                        {
                            tt.g_gif = _g_gif;
                        }
                        if (_g_down != "")
                        {
                            tt.g_gif2 = _g_down;
                        }
                        tt.Update();
                        DataTable dd = comfun.GetDataTableBySQL("select id from B2C_Goods where g_name='" + _g_name + "'");
                        try
                        {
                            B2C_Goods_M bgm = new B2C_Goods_M();
                            bgm.AddNew();
                            bgm.gid = Convert.ToInt32(dd.Rows[0]["id"]);
                            bgm.g_msg = _g_msg;
                            bgm.Update();
                        }
                        catch (Exception ex1) { throw new Exception(ex1.Message); }
                        lt_result.Text = "添加成功！";
                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            return;
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Goods_List.aspx';},300);</script>";


                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/goods/B2C_Goods_Add.cs", Session["wID"].ToString());
            }
        }

    }
}