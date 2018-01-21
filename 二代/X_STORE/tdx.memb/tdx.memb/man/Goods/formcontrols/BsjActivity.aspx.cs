using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.formcontrols
{
    public partial class BsjActivity : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["wID"].ToString() == "56")
                {
                    string _sql = " select * from control_value where key_id=103";
                    DataTable _tab = comfun.GetDataTableBySQL(_sql);
                    if (_tab.Rows.Count > 0)
                    {
                        InitList(_tab);
                    }
                }
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            int flag = 0;
            if (Session["wID"].ToString() == "56")
            {
                foreach (ListItem item in M_activity.Items)
                {
                    if (item.Selected == true)
                    {
                        int _id = Convert.ToInt32(item.Value);
                        string _sql = "select * from B2C_Bsj_Act where activity_id=" + _id.ToString();
                        DataTable _tab = comfun.GetDataTableBySQL(_sql);
                        if (_tab.Rows.Count > 0)
                        {
                            B2C_Bsj_Act activity = new B2C_Bsj_Act(Convert.ToInt32(_tab.Rows[0]["id"].ToString()));
                            activity.begin_time = kaishi.Value;
                            activity.end_time = jieshu.Value;
                            if (kaishi.Value.Trim() != "" && jieshu.Value.Trim() != "")
                            {
                                if (Convert.ToDateTime(kaishi.Value) <= Convert.ToDateTime(jieshu.Value))
                                {
                                    activity.Update();
                                    flag++;
                                }
                                else
                                {
                                    Response.Write("<script language='javascript'>alert('开始时间不能大于结束时间!')</script>");
                                    return;
                                }
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>alert('必须选择活动的开始时间和结束时间!')</script>");
                                return;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(kaishi.Value.Trim()) || string.IsNullOrEmpty(jieshu.Value.Trim()))
                            {
                                Response.Write("<script language='javascript'>alert('必须选择活动的开始时间和结束时间!')</script>");
                                return;
                            }
                            if (Convert.ToDateTime(kaishi.Value) > Convert.ToDateTime(jieshu.Value))
                            {
                                Response.Write("<script language='javascript'>alert('开始时间不能大于结束时间!')</script>");
                                return;
                            }
                            _sql = "insert into B2C_Bsj_Act(activity_id,begin_time,end_time) values(" + _id + ",'" + kaishi.Value + "','" + jieshu.Value + "')";
                            int num = comfun.InsertBySQL(_sql);
                            if (num > 0)
                                Response.Write("<script language='javascript'>alert('保存成功!');location.href='BsjActivity.aspx';</script>");
                            else
                                Response.Write("<script language='javascript'>alert('保存失败!')</script>");
                        }
                        break;
                    }
                }
                if (flag != 0)
                {
                    Response.Write("<script language='javascript'>alert('修改成功!');location.href='BsjActivity.aspx';</script>");
                }
                else
                    Response.Write("<script language='javascript'>alert('修改失败!')</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('不具备编辑权限!')</script>");
            }
        }

        private void InitList(DataTable _tab)
        {

            for (int i = 0; i < _tab.Rows.Count; i++)
            {
                ListItem list = new ListItem();
                list.Value = _tab.Rows[i]["id"].ToString();
                list.Text = _tab.Rows[i]["value"].ToString();
                M_activity.Items.Add(list);
                if (i == 0)
                {

                    list.Selected = true;
                    string _sql = "select * from B2C_Bsj_Act where activity_id=" + list.Value;
                    DataTable dt = comfun.GetDataTableBySQL(_sql);
                    if (dt.Rows.Count > 0)
                    {
                        kaishi.Value = dt.Rows[0]["begin_time"].ToString();
                        jieshu.Value = dt.Rows[0]["end_time"].ToString();
                    }
                }

            }
        }

        protected void Select_Change(object sender, EventArgs e)
        {
            foreach (ListItem item in M_activity.Items)
            {
                if (item.Selected == true)
                {
                    int _id = Convert.ToInt32(item.Value);
                    string _sql = "select * from B2C_Bsj_Act where activity_id=" + _id.ToString();
                    DataTable _tab = comfun.GetDataTableBySQL(_sql);
                    if (_tab.Rows.Count > 0)
                    {

                        kaishi.Value = _tab.Rows[0]["begin_time"].ToString();
                        jieshu.Value = _tab.Rows[0]["end_time"].ToString();
                    }
                    else
                    {
                        kaishi.Value = "";
                        jieshu.Value = "";
                    }
                    break;
                }
            }
        }



    }
}