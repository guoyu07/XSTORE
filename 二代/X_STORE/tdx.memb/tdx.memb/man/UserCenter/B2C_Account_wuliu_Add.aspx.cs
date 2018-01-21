using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;

namespace tdx.memb.man.UserCenter
{
    public partial class B2C_Account_wuliu_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  userAuthentication(12);
            if (!IsPostBack)
            {
                if (Request["mid"] == null)
                {
                    Response.Write("<script language='javascript'>alert('请选择一个会员再进行操作！');location.href='dt_manager_list.aspx';</script>");
                    Response.End();
                }
                else
                {
                    int Mid = Convert.ToInt32(Request["mid"]);

                    string sql = "select id,M_truename from B2C_mem where id=" + Mid;
                    sql += "\n ;select id,pt_name,pt_isYN from b2c_paytype order by id";
                    sql += "\n;select c_no,c_name from b2c_kemu order by c_id";
                    DataSet ds = comfun.GetDataSetBySQL(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        string str = "";
                        str += "        " + dr["M_truename"].ToString().Trim();
                        lt_memid.Value = dr["id"].ToString();
                        lt_mem.Text = str;

                    }
                    //绑定支付方式
                    t_pt.DataSource = ds.Tables[1].DefaultView;
                    t_pt.DataTextField = "pt_name";
                    t_pt.DataValueField = "id";
                    t_pt.DataBind();
                    //绑定账户类型
                    t_cno.DataSource = ds.Tables[2].DefaultView;
                    t_cno.DataTextField = "c_name";
                    t_cno.DataValueField = "c_no";
                    t_cno.DataBind();

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string _mid = lt_memid.Value.Trim();
            string _amt = t_num.Text.Trim();
            string _des = t_msg.Value.Trim();
            string _ptid = t_pt.Value.Trim();
            string _cno = t_cno.Value.Trim();

            int mid = 0;
            if (_mid != "") mid = Convert.ToInt32(_mid);
            double amt = 0;
            if (_amt != "") amt = Convert.ToDouble(_amt);
            int ptid = 0;
            int yn = 1;
            if (_ptid != "")
            {
                ptid = Convert.ToInt32(_ptid);
                DataTable dt_tmp = comfun.GetDataTableBySQL("select c_math from b2c_kemu where c_no='" + _cno + "'");
                if (dt_tmp.Rows.Count > 0)
                    yn = int.Parse(dt_tmp.Rows[0]["c_math"].ToString());
                // throw new Exception(yn.ToString() + dt_tmp.Rows.Count.ToString());
            }

            B2C_Account ba = new B2C_Account();
            ba.AddNew();
            ba.ac_money = amt * yn;
            ba.ac_des = _des;
            ba.mid = mid;
            ba.ptid = ptid;
            ba.cno = _cno;
            ba.orderNo = "";// gid.ToString();
            //throw new Exception(amt.ToString());
            try
            {
                ba.Update();
                //如果有任务ID，则更新任务情况
                //if (gid != 0)
                //{
                //    //如果gid！=0，还需要更新商品的amt和chg               
                //    //B2C_Goods.updateCHG(gid, amt);
                //    //另外,商品日志表写入记录
                //    //B2C_Goods.insertLogs(gid, 0, "线下充值", "线下充值" + string.Format("{0:F}", amt) + "元");
                //}
                Response.Write("<script language='javascript'>alert('操作成功！');location.href='B2C_Accout_wuliu2_List.aspx?mid=" + mid.ToString() + "';</script>");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }
    }
}