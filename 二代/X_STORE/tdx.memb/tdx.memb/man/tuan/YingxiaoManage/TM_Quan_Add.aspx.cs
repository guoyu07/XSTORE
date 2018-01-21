 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.DBUtility;
using tdx.database;

namespace tdx.memb.man.Tuan.YingxiaoManage
{
    public partial class TM_Quan_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                goodstype();
                int id = 0;
                if (Request["id"] != null)
                {id = Convert.ToInt32(Request["id"]);
                    TM_Quan tixian = new TM_Quan(id);
                    txt_title.Text  = tixian.q_title;
                    txt_qTmoney.Text = tixian.q_Tmoney.ToString();
                    txt_q_Getmoney.Text = tixian.q_Getmoney.ToString();
                    txt_Tmoney.Text = tixian.q_money.ToString();
                    txt_Jmoney.Text = tixian.q_num.ToString();
                    Jxl.Value = tixian.q_Bdate.ToString();
                    Jx2.Value = tixian.q_Edate.ToString();
                    drp_types.SelectedValue = tixian.types.ToString();
                }
            }
        }

        private void goodstype()
        {

            DataTable dt=new DataTable() ;
            dt.Columns.Add("types", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Rows.Add(0, "优惠券");
            dt.Rows.Add(1, "红包");
            DataRow row = dt.NewRow();
            row["name"] = "所有分类";
            row["types"] = "-1";
            dt.Rows.InsertAt(row, 0);
            if (dt.Rows.Count > 0)
            {

                drp_types.DataSource = dt.DefaultView;
                drp_types.DataTextField = "name";
                drp_types.DataValueField = "types";
                drp_types.DataBind();
            }

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string _title = txt_title.Text.Trim();
            string _qTmoney = txt_qTmoney.Text.Trim();
            string _qGetmoney = txt_q_Getmoney.Text.Trim();
            string _Tmoney = txt_Tmoney.Text.Trim();
            string _Dmoney = txt_Jmoney.Text.Trim();
            string _Bdate = Jxl.Value;
            string _Edate;
            if (!string.IsNullOrEmpty(Jx2.Value))
            {
                _Edate = Jx2.Value;
            }
            else
            {
                _Edate = Utils.ObjectToDateTime(Jxl.Value).AddYears(2).ToString();
            }

            int types = Utils.ObjToInt(drp_types.SelectedValue, 0);

            if (_title == "")
            {
                Response.Write("<script language='javascript'>alert('请输入标题！');history.go(-1);</script>");
                Response.End();
                return;
            }
            if (Convert.ToDecimal(_Tmoney) <= 0)
            {
                Response.Write("<script language='javascript'>alert('金额不能为负数或0！');history.go(-1);</script>");
                Response.End();
                return;
            } 
            if (Convert.ToDecimal(_Dmoney) <= 0)
            {
                Response.Write("<script language='javascript'>alert('数量不能为负数或0！');history.go(-1);</script>");
                Response.End();
                return;
            }  

            if (Request["id"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Request["id"]);
                    TM_Quan tixian = new TM_Quan(id);
                    tixian.q_title = _title;
                    tixian.q_Tmoney = Convert.ToDecimal(_qTmoney);
                    tixian.q_Getmoney = Convert.ToDecimal(_qGetmoney);
                    tixian.q_money = Convert.ToDecimal(_Tmoney);
                    tixian.q_num = Convert.ToInt32(_Dmoney);
                    tixian.q_Bdate = Convert.ToDateTime(_Bdate);
                    tixian.q_Edate = Convert.ToDateTime(_Edate);
                    tixian.types = types;
                    tixian.Update();
                    Response.Write("<script language='javascript'>alert('修改成功！');location.href='TM_Quan_List.aspx';</script>");
                    Response.End();
                    //  }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else //新加
            {
                try
                { 

                   TM_Quan tixian = new TM_Quan();  
                    tixian.AddNew();
                    tixian.q_title = _title;
                    tixian.q_Tmoney = Convert.ToDecimal(_qTmoney);
                    tixian.q_Getmoney = Convert.ToDecimal(_qGetmoney);
                    tixian.q_money = Convert.ToDecimal(_Tmoney);
                    tixian.q_num = Convert.ToInt32(_Dmoney);
                    tixian.q_Bdate = Convert.ToDateTime(_Bdate);
                    tixian.q_Edate = Convert.ToDateTime(_Edate);
                    tixian.types = types;tixian.Update(); 


                    Response.Write("<script language='javascript'>alert('添加成功！');location.href='TM_Quan_List.aspx';</script>");
                    Response.End();
                     
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
