using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common;
using Creatrue.kernel;
using tdx.database;
using tdx.database.database;

namespace tdx.memb.man.UserCenter
{
    public partial class B2C_tixian_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dzd = "  a.* ,b.M_name,b.M_bank,b.M_card,b.m_truename";
                string sql = "(1=1)";
                string tname = " B2C_tixian a left join B2C_mem b on a.mid=b.id  ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_tixian").Rows[0][0]);
                lt_pagearrow.Text = commonTool.F_pagearrow(_page, totalcount);


            }
        }
        private string prolist(string _dzd, string _tname, string _sql, int _page)
        {
            string active = "";

            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f3f3f3"">";
            str += @"           <td align=center   class=""tablehead"">选择</td>";
            str += @"          <td align=center >会员名称</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">银行卡号</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">提现金额</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">申请时间</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">状态</td>";
            //str += @"          <td align=center  class=""tablehead"">修改</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = B2C_tixian.GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input Class=""checkall"" style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + dr["M_name"] + "<br />" + dr["M_truename"].ToString().Trim() + "</td>";
                str += @"          <td align=center >" + dr["M_bank"] + "<br />" + dr["M_card"] + "</td>";
                str += @"          <td align=center >" + dr["tx_money"] + "</td>";
                str += @"          <td align=center >" + dr["regtime"] + "</td>";
                switch (Convert.ToInt32(dr["isActive"]))
                {
                    case -1:
                        active = "驳回";
                        break;
                    case 0:
                        active = "申请";
                        break;
                    case 1:
                        active = "批准";
                        break;
                    case 2:
                        active = "已汇款";
                        break;
                    default:
                        break;
                }
                str += @"          <td align=center>" + active + "</td>";
                //str += @"          <td align=center> <a href='B2C_tixian_Add.aspx?id=" + dr["id"] + "'>修改</a></td>";
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
            string keyword = ss_keyword.Text;
            string cno = "";
            if (ss_cid.Value == "0")
            {
                cno = "M_name";
            }
            else if (ss_cid.Value == "1")
            {
                cno = "M_truename";
            }
            string _cityID = ss_cityID.Value.Trim();

            string sql = "1=1";
            if (cno != "")
                sql += " and mid in (select id from b2c_mem where " + cno + " like '%" + keyword + "%')";
            if (_cityID != "")
                sql += " and isActive = " + _cityID;

            string dzd = "  * ,(select m_name from b2c_mem where b2c_tixian.mid=b2c_mem.id) as M_name";
            dzd += ",(select m_truename from b2c_mem where b2c_tixian.mid=b2c_mem.id) as M_truename";
            dzd += ",(select m_bank from b2c_mem where b2c_tixian.mid=b2c_mem.id) as m_bank";
            dzd += ",(select m_card from b2c_mem where b2c_tixian.mid=b2c_mem.id) as m_card";
            string tname = " B2C_tixian  ";


            lb_prolist.Text = prolist(dzd, tname, sql, Convert.ToInt32(Request["page"]));//
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_tixian where " + sql).Rows[0][0]);
            lt_pagearrow.Text = commonTool.F_pagearrow(Convert.ToInt32(Request["page"]), totalcount);
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
                        //这里要退回款项
                        appsConfig apps = new appsConfig();
                        apps.init();
                        B2C_Account ba = new B2C_Account();
                        string[] _delids = delid.Split(',');
                        foreach (string _txid in _delids)
                        {
                            if (!string.IsNullOrEmpty(_txid))
                            {
                                B2C_tixian bt = new B2C_tixian(Convert.ToInt32(_txid));
                                int _mid = bt.mid;

                                if (bt.isActive >= 0) //如果已经被拒绝，不需要退现；否则都要退现。
                                {

                                    double _tixianMoney = Convert.ToDouble(bt.tx_money) / (1 - apps._tixianZhekou);

                                    ba.AddNew();
                                    ba.mid = _mid;
                                    ba.ptid = 2;
                                    ba.cno = "005";
                                    ba.ac_money = -1 * _tixianMoney;
                                    ba.ac_des = "提现退回";
                                    ba.Update();
                                }
                            }
                        }


                        B2C_tixian.delete(id.ToString());

                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='B2C_tixian_List.aspx';</script>");
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
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbtnstar_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                string _sql = "update b2c_tixian set isactive=1 where id in (" + delid + ")";
                try
                {
                    comfun.UpdateBySQL(_sql);
                    Response.Write("<script language='javascript'>alert('审核通过成功！');location.href='B2C_tixian_List.aspx';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script language='javascript'>alert('审核通过失败！');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }
        //审核不通过
        protected void lkbtnstar2_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                string _sql = "update b2c_tixian set isactive=-1 where id in (" + delid + ")";
                try
                {
                    comfun.UpdateBySQL(_sql);
                    //这里要退回款项
                    appsConfig apps = new appsConfig();
                    apps.init();
                    B2C_Account ba = new B2C_Account();
                    string[] _delids = delid.Split(',');
                    foreach (string _txid in _delids)
                    {
                        if (!string.IsNullOrEmpty(_txid))
                        {
                            B2C_tixian bt = new B2C_tixian(Convert.ToInt32(_txid));
                            int _mid = bt.mid;

                            double _tixianMoney = Convert.ToDouble(bt.tx_money) / (1 - apps._tixianZhekou);

                            ba.AddNew();
                            ba.mid = _mid;
                            ba.ptid = 2;
                            ba.cno = "005";
                            ba.ac_money = 1 * _tixianMoney;
                            ba.ac_des = "提现退回";
                            ba.Update();
                        }
                    }

                    Response.Write("<script language='javascript'>alert('审核不通过！');location.href='B2C_tixian_List.aspx';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script language='javascript'>alert('审核不通过失败！');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }
        //已付款
        protected void lkbtnstar3_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                string _sql = "update b2c_tixian set isactive=2 where id in (" + delid + ")";
                try
                {
                    comfun.UpdateBySQL(_sql);
                    Response.Write("<script language='javascript'>alert('付款成功！');location.href='B2C_tixian_List.aspx';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script language='javascript'>alert('付款失败！');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }
        #endregion
    }
}