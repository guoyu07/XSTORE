using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;
using System.Data;

namespace tdx.memb.man.Texts
{
    public partial class B2C_Photo_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //userAuthentication(11);
            if (!IsPostBack)
            {
                //绑定地区
                DataTable classidArry1 = comfun.GetDataTableBySQL("select c_id from B2C_Pclass where c_parent=0 order by c_id");
                foreach (DataRow dr in classidArry1.Rows)
                {
                    B2C_Pclass.getOneClassTree(Convert.ToInt32(dr["c_id"]), ss_cid);
                }

                string dzd = " *,(select c_name from B2C_Pclass where B2C_Pclass.c_no=b2c_Photo.cno) as cname";
                string sql = "(1=1) ";
                lb_prolist.Text = prolist(dzd, sql, 1);
                //生成分页按钮
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Photo").Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

                lb_proadd.Text = "<a href='B2C_Photo_Add.aspx'>添加新图片</a>";
            }
        }
        private string prolist(string _dzd, string _sql, int _pageIndex)
        {
            string acitve = "";
            string del = "";

            string str = "";
            str += @"<table >";
            str += @"        <tr bgcolor=""#427faf"">";
            str += @"           <th align=center >删除</th>";
            str += @"          <th height=""25"" align=center >类别</th>";
            str += @"          <th align=center >预览</th>";
            str += @"          <th align=center >名称</th>";
            str += @"          <th align=center >类型</th>";
            str += @"          <th align=center >大小</th>";
            str += @"		   <th align=center >时间</th>";
            str += @"		   <th align=center >排序</th>";
            str += @"		   <th align=center >启停/删除</th>";
            str += @"          <th align=center  >修改</th>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }

            DataTable dt = B2C_Photo.GetList(currentpage, _dzd, _sql);

            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#def0ff> ";
                str += @"           <td align=center> <input  style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center height=24>" + dr["cname"] + "</td>";
                str += @"          <td align=center><img src='" + dr["p_url"] + "' border='0' width='30' /></td>";
                str += @"          <td align=center>" + dr["p_name"] + "</td>";
                str += @"          <td align=center>" + dr["p_ftype"] + "</td>";
                str += @"          <td align=center>" + dr["p_fweight"] + "</td>";
                str += @"          <td align=center>" + dr["p_wdate"] + "</td>";
                str += @"          <td align=center>" + dr["p_sort"] + "</td>";
                acitve = Convert.ToInt32(dr["p_isactive"]) == 1 ? "启" : "停";
                del = Convert.ToInt32(dr["p_isdel"]) == 0 ? "未" : "删";
                str += @"          <td align=center>" + acitve + "/" + del + "</td>";
                str += @"          <td align=center><a href=""B2C_Photo_Add.aspx?id=" + dr["id"] + "\">修改</a></td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }
        #region  功能按钮
        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void delBtn_Click(object sender, EventArgs e)
        {
            //userAuthentication(12);
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                try
                {
                    B2C_Photo.delete(delid);
                    Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='B2C_Photo_List.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('彻底删除失败！" + ex.Message.Replace("'", "") + "');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要彻底删除的行！');history.go(-1);</script>");
            }
        }
        /// <summary>
        /// 设置是否启用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //userAuthentication(12);
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                try
                {
                    B2C_Photo.setIsActive(delid);
                    Response.Write("<script language='javascript'>alert('启停设置成功！');location.href='B2C_Photo_List.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('启停设置失败！" + ex.Message.Replace("'", "") + "');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }
        /// <summary>
        /// 设置是否删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button6_Click(object sender, EventArgs e)
        {
            //userAuthentication(12);
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                try
                {
                    B2C_Photo.setIsDel(delid);
                    Response.Write("<script language='javascript'>alert('回收站设置成功！');location.href='B2C_Photo_List.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('回收站设置失败！" + ex.Message.Replace("'", "") + "');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }
        #endregion

        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            string keyword = ss_keyword.Value;
            string cno = ss_cid.Value;
            DateTime Bdate = consts.cons_Bdate;// 
            if (ss_Bdate.Value.Trim() != "")
                Bdate = Convert.ToDateTime(ss_Bdate.Value);
            DateTime Edate = System.DateTime.Now;//
            if (ss_Edate.Value.Trim() != "")
                Edate = Convert.ToDateTime(ss_Edate.Value);
            int isActive = 0;
            if (ss_isActive.Checked == true)
            {
                isActive = 1;
            }
            else
            {
                isActive = 0;
            }
            int isDel = 0;
            if (ss_isDel.Checked == true)
            {
                isDel = 1;
            }
            else
            {
                isDel = 0;
            }
            string sql = "1=1 and (p_name like '%" + keyword + "%' or p_no like '%" + keyword + "%')";
            if (cno != null)
            {
                sql = sql + " and cno like '%" + cno + "%'";
            }
            if (isActive == 1)
            {
                sql = sql + " and p_isActive=1";
            }
            if (isDel == 1)
            {
                sql = sql + " and p_isdel = 1 ";
            }

            if (Bdate != null)
                sql = sql + " and p_wdate >= cast('" + Bdate + "' as datetime)";
            if (Edate != null)
                sql = sql + " and p_wdate <=cast('" + Edate + "' as datetime)";


            string dzd = " *,(select c_name from B2C_Pclass where B2C_Pclass.c_no=B2C_Photo.cno)as cname ";
            lb_prolist.Text = prolist(dzd, sql, Convert.ToInt32(Request["page"]));//, 
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Photo where " + sql).Rows[0][0]);
            lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(Convert.ToInt32(Request["page"]), totalcount);
            //  lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(Convert.ToInt32(Request["page"]), totalcount,20);
        }
    }
}