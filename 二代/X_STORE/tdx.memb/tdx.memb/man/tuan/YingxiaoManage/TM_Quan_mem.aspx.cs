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

namespace tdx.memb.man.tuan.YingxiaoManage
{
    public partial class TM_Quan_mem : DTcms.Web.UI.ManagePage
    {
        private int qid = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["qid"] != null)
                {
                    qid = Convert.ToInt32(Request["qid"]);
                }

                string dzd = "  *,(select q_title from  TM_Quan where  TM_Quan.id=qid) as q_title,(select q_money from  TM_Quan where  TM_Quan.id=qid) as q_money";
                dzd += ",(select wx昵称 from WP_会员表 where WP_会员表.openid = TM_Quan_mem.openid) as wx昵称";
                string sql = " qid=" + qid + " ";
                string tname = "  TM_Quan_mem ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from  TM_Quan_mem where " + sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);


            }
        }
        private string prolist(string _dzd, string _tname, string _sql, int _page)
        {
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f3f3f3"">";
            str += @"           <td align=center   class=""tablehead"">选择</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">人员名称</td>";
            str += @"          <td align=center >优惠券名称</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">券金额</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">数量</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">发放时间</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = database.TM_Quan_mem.GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows){
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input Class=""checkall"" style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + dr["wx昵称"].ToString() + "</td>";
                str += @"          <td align=center >" + dr["q_title"] + "</td>";

                str += @"          <td align=center >" + Convert.ToDecimal(dr["q_money"]).ToString("f2") + "</td>";
                str += @"          <td align=center >" + dr["qnum"] + "</td>";
                str += @"          <td align=center >" + dr["regtime"] + "</td>";

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
            if (t == 0)
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
            //string keyword = ss_keyword.Value;
            //string cno = "";
            //string sql = "1=1";
            //if (cno != "")
            //    sql += " and  q_title like '%" + keyword + "%'";


            //string dzd = "  *,(select sum(qnum) from TM_Quan_mem where qid=TM_Quan.id) as totalnum";
            //dzd += ",(select count(id) from tm_quan_mem_log where qmid in (select id from tm_quan_mem where qid=tm_quan.id)) as totalnum2";
            //string tname = " TM_Quan  ";


            //lb_prolist.Text = prolist(dzd, tname, sql, Convert.ToInt32(Request["page"]));//
            ////生成分页按钮
            //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from TM_Quan where " + sql).Rows[0][0]);
            //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(Convert.ToInt32(Request["page"]), totalcount);
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
                        
                        delete(id.ToString());

                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='TM_Quan_mem.aspx?qid=" + Convert.ToInt32(Request["qid"]) + "';</script>");
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



        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from  TM_Quan_mem where id in (" + _ids + ")";
            try
            {
                comfun.UpdateBySQL(sql);
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }
        #endregion
    }
}