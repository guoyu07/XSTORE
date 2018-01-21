using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.tuan.YingxiaoManage
{
    public partial class TM_Quan_Use_List : DTcms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime now = DateTime.Now;
                DateTime d1 = new DateTime(now.Year, now.Month, 1);

                txtetime.Text = now.ToString("yyyy-MM-dd");
                txtbtime.Text = d1.ToString("yyyy-MM-dd");
                bindlist();
            }
        }

        public void bindlist()
        {
            string dzd = "  a.*,d.wx昵称,c.q_title,c.q_money ";

            string sql = " 1=1  ";
            if (!string.IsNullOrEmpty(txtbtime.Text) && !string.IsNullOrEmpty(txtetime.Text))
            {
                DateTime btime =Utils.ObjectToDateTime(txtbtime.Text + " 00:00:00.000");
                DateTime etime =Utils.ObjectToDateTime(txtetime.Text + " 23:59:59.000");
                sql += " and a.regtime between '" + btime + "' and '" + etime + "'";
            }
            string tname = "  TM_quan_mem_log a left join  [TM_Quan_mem] b on a.qmid=b.id left join  [TM_Quan] c on b.qid=c.id left join WP_会员表 d on b.openid=d.openid  ";
            lb_prolist.Text = prolist(dzd, tname, sql, 1);
            //生成分页
            int _page = 0;
            if (Request["page"] != null)
            {
                _page = 1;
            }
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from  TM_quan_mem_log a where " + sql).Rows[0][0]);
            lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

        }

        private string prolist(string _dzd, string _tname, string _sql, int _page)
        {
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f3f3f3"">";
            str += @"           <td align=center   class=""tablehead"">选择</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">人员名称</td>";
            str += @"          <td align=center >订单号</td>";
            str += @"          <td align=center >订单金额</td>";
            str += @"          <td align=center >订单状态</td>";
            str += @"          <td align=center >优惠券名称</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">优惠券金额</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">使用时间</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input Class=""checkall"" style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + dr["wx昵称"].ToString() + "</td>";
                str += @"          <td align=center >" + dr["orderNo"] + "</td>";
                str += @"          <td align=center >" + dr["orderMoney"] + "</td>";
                str += @"          <td align=center >" + getstates(dr["orderNo"]) + "</td>";
                str += @"          <td align=center >" + dr["q_title"] + "</td>";

                str += @"          <td align=center >" + Utils.ObjToDecimal(dr["q_money"], 0).ToString("f2") + "</td>";
                str += @"          <td align=center >" + dr["regtime"] + "</td>";

                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }

        public string getstates(object orderNo)
        {
            string states = "";
            string top = "WP_";
            if (Utils.ObjectToStr(orderNo).Length>1)
            {
                if (Utils.ObjectToStr(orderNo).Substring(0,1)=="T")
                {
                    top = "TM_";
                }
            }
            DataTable dts = comfun.GetDataTableBySQL("select state from "+top+"订单表 where 订单编号='"+orderNo+"' ");
            if (dts.Rows.Count>0)
            {
                states = Utils.ObjectToStr(dts.Rows[0][0]);
            }
            return states;
        }

        public static DataTable GetList(int _page, string _dzd, string _tname, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;
            if (_page <= 0)
            {
                _page = 0 + 1;
            }
            string sql = "select count(*) from TM_Quan_mem_log a where 1=1 and " + _sql;
            totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
            totalpage = totalcount / pagesize;
            if (totalcount % pagesize != 0)
            {
                totalpage = totalpage + 1;
            }
            else if (totalpage == 0)
            {
                totalpage = 1;
            }

            beginItem = pagesize * (_page - 1);
            endItem = pagesize * _page - 1;
            if (endItem > (totalcount - 1))
            {
                endItem = totalcount - 1;
            }

            if (beginItem < 0)
            {
                beginItem = 0;
            }
            try
            {
                DataTable dt = comfun.GetDataTableBySQL("select " + _dzd + " from " + _tname + " where " + _sql + " order by id desc");
                DataTable dt2 = dt.Clone();
                if (dt.Rows.Count > 0)
                {
                    for (int i = beginItem; i <= endItem; i++)
                    {
                        dt2.ImportRow(dt.Rows[i]);
                    }
                }
                return dt2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            bindlist();
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

                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='TM_Quan_UseList.aspx?qid=" + Convert.ToInt32(Request["qid"]) + "';</script>");
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

            string sql = "delete from  TM_quan_mem_log where id in (" + _ids + ")";
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

        protected void lbtn_Export_Click(object sender, EventArgs e)
        {
            string sql = " 1=1  ";
            if (!string.IsNullOrEmpty(txtbtime.Text) && !string.IsNullOrEmpty(txtetime.Text))
            {
                DateTime btime = Utils.ObjectToDateTime(txtbtime.Text + " 00:00:00.000");
                DateTime etime = Utils.ObjectToDateTime(txtetime.Text + " 23:59:59.000");
                sql += " and a.regtime between '" + btime + "' and '" + etime + "'";
            }
            string _sql = " select d.wx昵称 as 人员名称,a.orderNo as 订单号, a.orderMoney as 订单金额, c.q_title as 优惠券名称,c.q_money as 优惠券金额,a.regtime as 使用时间 from  TM_quan_mem_log a left join  [TM_Quan_mem] b on a.qmid=b.id left join  [TM_Quan] c on b.qid=c.id left join WP_会员表 d on b.openid=d.openid where " + sql + " ";
    

            DataTable dorder = comfun.GetDataTableBySQL(_sql);
            dorder.Columns.Add("订单状态", typeof(string));
            for (int i = 0; i < dorder.Rows.Count; i++)
            {
                dorder.Rows[i]["订单状态"] = getstates(dorder.Rows[i]["订单号"]);
            }
            DTcms.Common.Excel.DataTable4Excel(dorder, "优惠券使用详情");
        }

    }
}