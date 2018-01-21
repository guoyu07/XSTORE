
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;

namespace tdx.memb.man.Tuan.YingxiaoManage
{
    public partial class TM_Jian_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                int id = 0;
                Dropleibie();
                if (Request["id"] != null)
                { 
                    id = Convert.ToInt32(Request["id"]);
                    TM_jian tixian = new TM_jian(id);
                    txt_leibiehao.Value = tixian.c_id.ToString() ;
                    txt_title.Text  = tixian.j_title;
                    txt_Tmoney.Text = tixian.j_Tmoney.ToString();
                    txt_Jmoney.Text = tixian.j_Dmoney.ToString();
                    Jxl.Value = tixian.j_Bdate.ToString();
                    Jx2.Value = tixian.j_Edate.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string _title = txt_title.Text.Trim();
            string _Tmoney = txt_Tmoney.Text.Trim();
            string _Dmoney = txt_Jmoney.Text.Trim();
            string _Bdate = Jxl.Value;
            string _Edate = Jx2.Value;
            int c_id = -1;
            int.TryParse(txt_leibiehao.Value.ToString(),out c_id);
            if (c_id <0)
            {
                Response.Write("<script language='javascript'>alert('请选择商品类别！');history.go(-1);</script>");
                Response.End();
                return;
            }
            if (_title == "")
            {
                Response.Write("<script language='javascript'>alert('请输入标题！');history.go(-1);</script>");
                Response.End();
                return;
            }
            if (Convert.ToDecimal(_Tmoney) <= 0)
            {
                Response.Write("<script language='javascript'>alert('满足条件不能为负数或0！');history.go(-1);</script>");
                Response.End();
                return;
            }
            else if (Convert.ToDecimal(_Tmoney) < Convert.ToDecimal(_Dmoney))
            {
                Response.Write("<script language='javascript'>alert('满足条件不能小于减免金额！');history.go(-1);</script>");
                Response.End();
                return;
            }
            if (Convert.ToDecimal(_Dmoney) <= 0)
            {
                Response.Write("<script language='javascript'>alert('满足条件不能为负数或0！');history.go(-1);</script>");
                Response.End();
                return;
            }  

            if (Request["id"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Request["id"]);

                    TM_jian tixian = new TM_jian(id);
                    tixian.j_title = _title;
                    tixian.c_id = c_id;
                    tixian.j_Tmoney = Convert.ToDecimal(_Tmoney);
                    tixian.j_Dmoney = Convert.ToDecimal(_Dmoney);
                    tixian.j_Bdate = Convert.ToDateTime(_Bdate);
                    tixian.j_Edate = Convert.ToDateTime(_Edate);
                    tixian.Update();
                    Response.Write("<script language='javascript'>alert('修改成功！');location.href='TM_Jian_List.aspx';</script>");
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

                   TM_jian tixian = new TM_jian();  
                    tixian.AddNew();
                    tixian.c_id = c_id;
                    tixian.j_title = _title;
                    tixian.j_Tmoney = Convert.ToDecimal(_Tmoney);
                    tixian.j_Dmoney = Convert.ToDecimal(_Dmoney);
                    tixian.j_Bdate = Convert.ToDateTime(_Bdate);
                    tixian.j_Edate = Convert.ToDateTime(_Edate);
                    tixian.Update(); 


                    Response.Write("<script language='javascript'>alert('添加成功！');location.href='TM_Jian_List.aspx';</script>");
                    Response.End();
                     
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        
        DTcms.BLL.WP_category BLL_商品 = new DTcms.BLL.WP_category();
        private void Dropleibie()
        {
            txt_leibiehao.Items.Clear();
            DataSet ds = DbHelperSQL.Query("select * from WP_category where c_parent=0  order by c_id; ");
            txt_leibiehao.Items.Add(new ListItem("请选择商品类别", ""));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txt_leibiehao.Items.Add(new ListItem(dr["c_name"].ToString(), dr["c_id"].ToString()));
                //BLL_商品.getOneClassTree(Convert.ToInt32(dr["c_id"]), txt_leibiehao);
            }//该方式有目录树


        }
    }
}
