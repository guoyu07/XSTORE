 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using DTcms.Common;
using tdx.database;
 

namespace tdx.memb.man.Tuan.YingxiaoManage
{
    public partial class TM_Jian_List : DTcms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dzd = "  *,isnull((select sum(orderJmoney) from TM_jian_log where jid=tm_jian.id),0) as totalmoney,(select c_name from WP_category where c_id=TM_Jian.c_id ) as c_name";
                string sql = "(1=1)";
                string tname = " TM_Jian ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from TM_Jian").Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);


            }
        }
        private string prolist(string _dzd, string _tname, string _sql, int _page)
        { 
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f3f3f3"">";
            str += @"           <td align=center   class=""tablehead"">选择</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">类别</td>";
            str += @"          <td align=center >标题</td>"; 
            str += @"          <td height=""25"" align=center class=""tablehead"">满足条件</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">减免金额</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">开始时间</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">结束时间</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">录入时间</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">已兑金额</td>";
            str += @"          <td align=center  class=""tablehead"">修改</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = TM_jian.GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                string ss = Convert.ToDecimal(dr["j_Dmoney"].ToString()).ToString("f2");
                string result = String.Format("{0:N2}", Convert.ToDecimal("0.333333").ToString("f2"));
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input Class=""checkall"" style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + dr["c_name"] + "</td>"; 
                str += @"          <td align=center >" + dr["j_title"]  + "</td>";
                str += @"          <td align=center >" + Convert.ToDecimal(dr["j_Tmoney"].ToString()).ToString("f2") + "</td>";//
                str += @"          <td align=center >" + Convert.ToDecimal(dr["j_Dmoney"].ToString()).ToString("f2") + "</td>";
                str += @"          <td align=center >" + dr["j_Bdate"] + "</td>";
                str += @"          <td align=center >" + dr["j_Edate"] + "</td>"; 
                str += @"          <td align=center >" + dr["regtime"] + "</td>";
                //str += @"          <td align=center ><a href='TM_jian_log.aspx?id=" + dr["id"].ToString().Trim() + "'>" + dr["totalmoney"] + "</a></td>"; 
                str += @"          <td align=center ><a href='TM_Jian_UseList.aspx?jid=" + dr["id"] + "'>" + Utils.ObjToDecimal(dr["totalmoney"],0).ToString("f2") + "</a></td>"; 
                str += @"          <td align=center> <a href='TM_Jian_Add.aspx?id=" + dr["id"] + "'>修改</a></td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        } 

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            string keyword = ss_keyword.Value;
            string cno = "";  
            string sql = "1=1";
            if(cno!="")
                sql += " and  j_title like '%" + keyword + "%'";


            string dzd = "  *,(select sum(orderJmoney) from TM_jian_log where jid=tm_jian.id) as totalmoney "; 
            string tname = " TM_Jian  ";
           

            lb_prolist.Text = prolist(dzd, tname, sql, Convert.ToInt32(Request["page"]));//
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from TM_Jian where " + sql).Rows[0][0]);
            lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(Convert.ToInt32(Request["page"]), totalcount);
        }

        #region "按钮功能"
        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    int id = Convert.ToInt32(_id);
                    try
                    { 
                        TM_jian.delete(id.ToString());  

                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='TM_Jian_List.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('彻底删除失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要彻底删除的行！');history.go(-1);</script>");
            }
        }
         
        #endregion
    }
}