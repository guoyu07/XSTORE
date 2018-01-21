using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common;
using System.Data.SqlClient;

namespace tdx.memb.man.vipmemb
{
    public partial class Edit_PassWord : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request["id"] != null)
                {
                    string _sql = "select * from B2C_mem where id=" + Request["id"].ToString();
                    DataTable _dt = comfun.GetDataTableBySQL(_sql);
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        lt_biaoti.Text = " 会员--" + _dt.Rows[0]["M_name"].ToString();
                    }
                }
            }
        }
        //public int U_id = 0;
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_psw_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                int U_id = Convert.ToInt32(Request["id"].ToString());
                if (M_psw.Value == "")
                {
                    lt_result.Text = "请输入新密码！";
                    return;
                }
                else if (confirm_M_psw.Value == "")
                {
                    lt_result.Text = "请确认新密码！";
                    return;
                }
                else if (M_psw.Value != confirm_M_psw.Value)
                {
                    lt_result.Text = "两次输入密码不一致！";
                    return;
                }
                else
                {
                    UpdatePassWord(U_id);
                    commonTool.Show_Have_Url(lt_result, "修改成功！", "B2C_memList.aspx", 0);
                }
            }
            else
            {
                lt_result.Text = "找不到对应的会员！";
            }
        }

        public void UpdatePassWord(int _id)
        {
            string sql = "update B2C_mem set M_psw=@M_psw where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@M_psw",comEncrypt.GetMD5(M_psw.Value)), 
                    new SqlParameter("@id", _id)
            };
            comfun con = new comfun();
            con.ExecuteNonQuery(sql, paras);
        }
    }
}