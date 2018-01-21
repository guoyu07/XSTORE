using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.Common;
using System.Data;
using tdx.database.database;

namespace tdx.memb.man.Sets
{
    public partial class wxConfig : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["nav"] != null && Request["nav"].ToString().Equals("true"))
                {
                    ltHead.Text = commonTool.DaohangImage("1.jpg");
                    ltFoot.Text = commonTool.DaohangButton("javascript:void(0)", "../Texts/B2C_tpage_Add.aspx?nav=true", "../Texts/B2C_tpage_Add.aspx?nav=true");
                }

                int _id = Convert.ToInt32(Session["wID"].ToString());
                #region MyRegion
                //string _sql = string.Format("select * from B2C_HY where hy_no=(select hy_no from B2C_worker where id={0})", _id);
                //DataTable _tab = comfun.GetDataTableBySQL(_sql);
                //DataTable _tab_hy = comfun.GetDataTableBySQL("select * from B2C_HY");
                //if (_tab != null && _tab.Rows.Count>0)
                //{
                //    if (_tab_hy != null)
                //    {
                //        for (int i = 0; i < _tab_hy.Rows.Count; i++)
                //        {
                //            hy.Items.Add(_tab_hy.Rows[i]["hy_name"].ToString());
                //        }
                //    }
                //    hy.Value = _tab.Rows[0]["hy_name"].ToString();
                //}
                //else
                //{
                //    if (_tab_hy != null)
                //    {
                //        for (int i = 0; i < _tab_hy.Rows.Count; i++)
                //        {
                //            hy.Items.Add(_tab_hy.Rows[i]["hy_name"].ToString());
                //        }
                //        hy.Value = "0";
                //    }
                //} 
                #endregion
                wx_config bw = new wx_config();
                txtNichen.Value = bw.wx_nichen;
                txtCompany.Value = bw.M_company;
                txtTel.Value = bw.M_tel;
                txtMobile.Value = bw.M_mobile;
                wx_name.Value = bw.wx_name;
                txtMail.Value = bw.M_email;
                txtQq.Value = bw.M_QQ;
                txtMap.Value = bw.M_map;

                //if (bw.hy_no != null && bw.hy_no != "")
                //{
                //    ListItem lt;
                //    lt = new ListItem();
                //    lt.Value = "请选择类别";
                //    lt.Text = "请选择类别";
                //    hy.Items.Add(lt);
                //    getClassByID(bw.hy_no);
                //}
                //else
                //{
                //    ListItem lt;
                //    lt = new ListItem();
                //    lt.Value = "请选择类别";
                //    lt.Text = "请选择类别";
                //    lt.Selected = true;
                //    hy.Items.Add(lt);
                //    getClass();
                //}

                //if (bw.area_no != "")
                //{
                //    string[] _area = bw.area_no.Split('|');
                //    if (_area.Length >= 3)
                //    {
                //        string str = "<script language='javascript'>";
                //        str += "$(\"#Select1\").val(\"" + _area[0] + "\");";
                //        str += "$(\"#Select2\").prepend(\"<option value='" + _area[1] + "' selected>" + _area[1] + "</option>\");";
                //        str += "$(\"#Select3\").prepend(\"<option value='" + _area[2] + "'>" + _area[2] + "</option>\");";
                //        str += "</script>";
                //        sc.Text = str;

                //    }
                //}
            }
        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            string _id = Session["wID"].ToString();
            string _wx_nichen = txtNichen.Value;
            string _M_company = txtCompany.Value;
            string _M_tel = txtTel.Value;
            string _M_mobile = txtMobile.Value;
            string _M_email = txtMail.Value;
            string _M_QQ = txtQq.Value;
            string _M_WX = wx_name.Value;
            string _M_map = txtMap.Value;
            if (_wx_nichen.Trim() == "")
            {
                lt_result.Text = "请输入网站名称";
                return;
            }

            try
            {
                //B2C_worker goods = new B2C_worker(Convert.ToInt32(_id));
                //hf.Value = Request["hy"].ToString();
                //if (hf.Value != "请选择类别")
                //    goods.hy_no = hf.Value;

                //if (Request["Select1"].ToString() != "--请选择省份--")
                //{
                //    goods.area_no = Request["Select1"].ToString() + "|" + Request["Select2"].ToString() + "|" + Request["Select3"].ToString();

                //}
                //goods.wx_nichen = _wx_nichen;
                //goods.M_company = _M_company;
                //goods.M_tel = _M_tel;
                //goods.M_mobile = _M_mobile;
                //goods.M_email = _M_email;
                //goods.M_QQ = _M_QQ;
                //goods.M_map = _M_map;
                //goods.wx_name = _M_WX;
                //goods.Update();
                //lt_result.Text = "设置成功！";
                //if (Request["nav"] != null && Request["nav"].ToString() == "true")
                //    return;
                //else
                //    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wxConfig.aspx';},300);</script>";
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
            }

        }

        static string Sql = "*";
        static string Where = "1=1";
        DataTable dt = B2C_WeiXin_Class.GetList(Sql, Where);

        private void getClassByID(string number, int id = 0)
        {
            DataView dv = dt.AsDataView();
            //"len(number)=" + index + " and 
            dv.RowFilter = " fat_Id = " + id;
            DataTable dt1 = dv.ToTable();
            if (dt1.Rows.Count > 0)
            {
                ListItem lt;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    lt = new ListItem();
                    lt.Text = huagang(dt1.Rows[i]["number"].ToString().Length) + dt1.Rows[i]["name"].ToString();
                    lt.Value = dt1.Rows[i]["number"].ToString();
                    if (dt1.Rows[i]["number"].ToString().Equals(number))
                    {
                        lt.Selected = true;
                        hf.Value = lt.Value;
                    }
                    hy.Items.Add(lt);
                    if (Convert.ToInt32(dt1.Rows[i]["child_number"]) > 0)
                    {
                        getClassByID(number, Convert.ToInt32(dt1.Rows[i]["id"]));
                    }
                }
            }
        }

        private string huagang(int lengths)
        {
            string _xian = "";
            if (lengths > 3)
            {
                for (int i = 0; i < lengths / 3; i++)
                {
                    _xian += "-";
                }
            }
            return _xian;
        }

        /// <summary>
        /// 初始化一个下拉菜单
        /// </summary>
        /// <param name="id"></param>
        private void getClass(int id = 0)
        {
            DataView dv = dt.AsDataView();
            dv.RowFilter = " fat_Id = " + id;
            DataTable dt1 = dv.ToTable();
            if (dt1.Rows.Count > 0)
            {
                ListItem lt;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    lt = new ListItem();
                    lt.Text = huagang(dt1.Rows[i]["number"].ToString().Length) + dt1.Rows[i]["name"].ToString();
                    lt.Value = dt1.Rows[i]["number"].ToString();
                    hy.Items.Add(lt);
                    if (Convert.ToInt32(dt1.Rows[i]["child_number"]) > 0)
                    {
                        getClass(Convert.ToInt32(dt1.Rows[i]["id"]));
                    }
                }
            }
        }
    }
}