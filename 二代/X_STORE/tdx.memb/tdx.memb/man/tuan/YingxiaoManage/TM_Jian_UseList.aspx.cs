using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;

namespace tdx.memb.man.tuan.YingxiaoManage
{
    public partial class TM_Jian_UseList : DTcms.Web.UI.ManagePage
    {
        private int jid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["jid"] != null)
                {
                    jid = Convert.ToInt32(Request["jid"]);
                }

                string dzd = "  *,(select j_title from  [TM_Jian] b where b.id= [TM_Jian_log].jid) as j_title,(select wx昵称 from  WP_会员表 c where c.openid= [TM_Jian_log].openid) as wx昵称 ";
                string sql = " jid=" + jid + " ";
                string tname = "   [TM_Jian_log] ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(1) from  [TM_Jian_log] where " + sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);


            }
        }
        private string prolist(string _dzd, string _tname, string _sql, int _page)
        {
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f3f3f3"">";
            str += @"           <td align=center   class=""tablehead"">选择</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">优惠券名称</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">使用人员</td>";
            str += @"          <td align=center >订单号</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">订单金额</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">减免金额</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">使用日期</td>";
            //str += @"          <td align=center  class=""tablehead"">修改</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = TM_jian_log.GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input Class=""checkall"" style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + dr["j_title"] + "</td>";str += @"          <td align=center >" + dr["wx昵称"] + "</td>";
                str += @"          <td align=center >" + dr["orderNo"] + "</td>";
                str += @"          <td align=center >" + Convert.ToDecimal(dr["orderMoney"].ToString()).ToString("f2") + "</td>";//
                str += @"          <td align=center >" + Convert.ToDecimal(dr["orderJMoney"].ToString()).ToString("f2") + "</td>";
                str += @"          <td align=center >" + dr["regtime"].ToString() + "</td>";
                //str += @"          <td align=center> <a href='TM_Jian_Add.aspx?id=" + dr["id"] + "'>修改</a></td>";
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
            string sql = " jid=" + jid + " ";
            if (keyword != "")
                sql += " and  orderNo like '%" + keyword + "%'";

            string dzd = "  *,(select j_title from  [TM_Jian] b where b.id= [TM_Jian_log].jid) as j_title,(select wx昵称 from  WP_会员表 c where c.openid= [TM_Jian_log].openid) as wx昵称 ";
            string tname = "  [TM_Jian_log]   ";


            lb_prolist.Text = prolist(dzd, tname, sql, Convert.ToInt32(Request["page"]));//
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(1) from  [TM_Jian_log]  where " + sql).Rows[0][0]);
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

                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='TM_Jian_UseList.aspx?jid="+jid+"';</script>");
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