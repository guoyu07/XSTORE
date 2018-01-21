 
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
 

namespace tdx.memb.man.Tuan.Tixian
{
    public partial class B2C_tixian_List : DTcms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dzd = "  a.* ,b.wx昵称,b.wx头像,b.手机号";
                string sql = "(1=1)";
                string tname = " B2C_tixian a left join wp_会员表 b on a.mid=b.id  ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_tixian").Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);


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
                str += @"          <td align=center >" + dr["wx昵称"] + "<br />" + dr["手机号"].ToString().Trim() + "</td>"; 
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
            string keyword = ss_keyword.Value;
            string cno = "";
            if (ss_cid.Value == "0")
            {
                cno = "手机号";
            }
            else if (ss_cid.Value == "1")
            {
                cno = "wx昵称";
            }
            string _cityID = ss_cityID.Value.Trim();

            string sql = "1=1";
            if(cno!="")
                sql += " and mid in (select id from wp_会员表 where " + cno + " like '%" + keyword + "%')";
            if (_cityID != "")
                sql += " and isActive = " + _cityID;

            string dzd = "  * ,(select wx昵称 from wp_会员表 where b2c_tixian.mid=wp_会员表.id) as wx昵称";
            dzd += ",(select wx头像 from wp_会员表 where b2c_tixian.mid=wp_会员表.id) as wx头像";
            dzd += ",(select 手机号 from wp_会员表 where b2c_tixian.mid=wp_会员表.id) as 手机号"; 
            string tname = " B2C_tixian  ";
           

            lb_prolist.Text = prolist(dzd, tname, sql, Convert.ToInt32(Request["page"]));//
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_tixian where " + sql).Rows[0][0]);
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

                    //这里要扣除款项 
                    //B2C_Account ba = new B2C_Account();
                    //string[] _delids = delid.Split(',');
                    //foreach (string _txid in _delids)
                    //{
                    //    if (!string.IsNullOrEmpty(_txid))
                    //    {
                    //        B2C_tixian bt = new B2C_tixian(Convert.ToInt32(_txid));
                    //        int _mid = bt.mid;

                    //        double _tixianMoney = Convert.ToDouble(bt.tx_money);

                    //        ba.AddNew();
                    //        ba.mid = _mid;
                    //        ba.ptid = 2;
                    //        ba.cno = "005";
                    //        ba.ac_money = _tixianMoney;
                    //        ba.ac_des = "提现";
                    //        ba.Update();
                    //    }
                    //}

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