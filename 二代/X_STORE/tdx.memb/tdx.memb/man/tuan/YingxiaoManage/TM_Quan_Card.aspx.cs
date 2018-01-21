using Creatrue.kernel;
using DTcms.BLL;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.tuan.YingxiaoManage
{
    public partial class TM_Quan_Card : DTcms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string dzd = "  *,(select q_title from  TM_Quan where id=TM_QuanCard.q_id) as q_title";
                string sql = "  q_id = " + Utils.ObjToInt(Request["id"], 0) + "";
                string tname = " TM_QuanCard ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from TM_QuanCard where q_id = " + Utils.ObjToInt(Request["id"], 0) + "").Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);


            }
        }
        private string prolist(string _dzd, string _tname, string _sql, int _page)
        {
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f3f3f3"">";
            str += @"           <td align=center   class=""tablehead"">选择</td>";
            str += @"          <td align=center >标题</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">卡券编号</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">是否兑换</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = DTcms.DAL.TM_QuanCard.GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input Class=""checkall"" style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + dr["q_title"] + "</td>";
                str += @"          <td align=center >" + dr["q_no"] + "</td>";
                str += @"          <td align=center >" + GetIsActivie(dr["is_active"]) + "</td>";

                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }

        public string GetIsActivie(object is_activeOld)
        {
            string isActivie = Utils.ObjToInt(is_activeOld, 0) == 0 ? "否" : "是";
            return isActivie;
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
                        new DTcms.BLL.TM_QuanCard().Delete(id);


                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('彻底删除失败！');history.go(-1);</script>");
                    }
                }
                Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='TM_Quan_Card.aspx?id=" + Utils.ObjToInt(Request["id"], 0) + "';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要彻底删除的行！');history.go(-1);</script>");
            }
        }



        protected void lbtn_Export_Click(object sender, EventArgs e)
        {
            string sql = "  select (select q_title from TM_Quan where id=TM_QuanCard.q_id) as 标题,q_no as 卡券编号,case is_active when 1 then '是' else '否'  end as 是否兑换  from TM_QuanCard where q_id = " + Utils.ObjToInt(Request["id"], 0) + "";


            DataTable dorder = comfun.GetDataTableBySQL(sql);
            DTcms.Common.Excel.DataTable4Excel(dorder, "卡券信息");
        }


        #endregion




    }
}