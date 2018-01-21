 
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
    public partial class TM_Quan_List : DTcms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dzd = "  *,(select sum(qnum) from  TM_Quan_mem where qid= TM_Quan.id) as totalnum";
                dzd += ",(select count(id) from  tm_quan_mem_log where qmid in (select id from  tm_quan_mem where qid= tm_quan.id)) as totalnum2";
                string sql = "(1=1)";
                string tname = "  TM_Quan ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from  TM_Quan").Rows[0][0]);
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
            str += @"          <td height=""25"" align=center class=""tablehead"">券获取条件</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">券使用条件</td>";

            str += @"          <td height=""25"" align=center class=""tablehead"">券金额</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">数量</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">开始时间</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">结束时间</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">录入时间</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">已发放</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">已兑换</td>";
            str += @"          <td align=center colspan=""3"" class=""tablehead"">操作</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = TM_Quan.GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input Class=""checkall"" style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + GetTypes(dr["types"]) + "</td>";
                str += @"          <td align=center >" + dr["q_title"]  + "</td>";
                str += @"          <td align=center >" + Convert.ToDecimal(dr["q_Getmoney"]).ToString("f2") + "</td>";
                str += @"          <td align=center >" + Convert.ToDecimal(dr["q_Tmoney"]).ToString("f2") + "</td>";

                str += @"          <td align=center >" + Convert.ToDecimal(dr["q_money"]).ToString("f2") + "</td>";
                str += @"          <td align=center >" + dr["q_num"] + "</td>";
                str += @"          <td align=center >" + dr["q_Bdate"] + "</td>";
                str += @"          <td align=center >" + dr["q_Edate"] + "</td>"; 
                str += @"          <td align=center >" + dr["regtime"] + "</td>";
                str += @"          <td align=center ><a href='TM_Quan_mem.aspx?qid=" + dr["id"] + "'>" + dr["totalnum"] + "</a></td>";
                str += @"          <td align=center ><a href='TM_Quan_UseList.aspx?qid=" + dr["id"] + "'>" + dr["totalnum2"] + "</a></td>"; 

                str += @"          <td align=center> <a href='TM_Quan_Add.aspx?id=" + dr["id"] + "'>修改</a></td>";
                str += @"          <td align=center> <a href='TM_Quan_Card_Add.aspx?id=" + dr["id"] + "'>生成卡券</a></td>";
                str += @"          <td align=center> <a href='TM_Quan_Card.aspx?id=" + dr["id"] + "'>查看卡券</a></td>";

                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }

        public String GetTypes(object a)
        {
            string x = "";
            int t = Utils.ObjToInt(a, 0);
            if (t==0)
            {
                x = "优惠券";
            }
            else
            {
                x = "红包";
            }
            return x;


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
                sql += " and  q_title like '%" + keyword + "%'";


            string dzd = "  *,(select sum(qnum) from  TM_Quan_mem where qid= TM_Quan.id) as totalnum";
            dzd += ",(select count(id) from  tm_quan_mem_log where qmid in (select id from  tm_quan_mem where qid= tm_quan.id)) as totalnum2";
            string tname = "  TM_Quan  ";
           

            lb_prolist.Text = prolist(dzd, tname, sql, Convert.ToInt32(Request["page"]));//
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from  TM_Quan where " + sql).Rows[0][0]);
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
                        TM_Quan.delete(id.ToString());  

                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='TM_Quan_List.aspx';</script>");
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