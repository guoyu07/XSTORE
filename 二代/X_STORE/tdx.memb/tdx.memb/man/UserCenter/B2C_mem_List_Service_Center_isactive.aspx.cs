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

namespace tdx.memb.man.UserCenter
{
    public partial class B2C_mem_List_Service_Center_isactive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dzd = " *,(select Mvip_name from B2C_memvip where B2C_memvip.Mvip_id=B2C_mem.M_vip)as mname,(select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=1 order by id desc) as amt,(select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=2 order by id desc) as amt2 ";
                dzd += ",isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=3 order by id desc),0) as M_dongjie";
                dzd += ",(select m_truename from b2c_mem as m1 where m1.id = b2c_mem.parentID) as parentName";
                dzd += ",(select m_truename from b2c_mem as m2 where m2.id = b2c_mem.jieshaoID) as jieshaoName";
                dzd += ",(select real_name from dt_manager where dt_manager.id=b2c_mem.cityID) as cityName";
                dzd += ",(select count(id) from b2c_mem as m3 where m3.jieshaoID = b2c_mem.id) as childs";
                dzd += ",(select count(id) from b2c_mem as m4 where m4.m_no like b2c_mem.m_no +'%' and m4.m_level>b2c_mem.m_level) as allChilds";
                dzd += ",(select max(m_level) from b2c_mem as m5 where m5.m_no like b2c_mem.m_no +'%') as maxLevel";
                dzd += ",(select top 1 m_truename from b2c_mem as m6 where m6.m_no like b2c_mem.m_no +'%' order by m_level desc,id desc ) as endName";
                dzd += ",(select  sum(mvip_price) from b2c_mem as m7,B2C_memvip where m7.m_vip =b2c_memvip.Mvip_id and m7.jieshaoID = b2c_mem.id and m7.m_isactive=1) as ticheng";
                dzd += ",(select  sum(tx_money) from b2c_tixian  where mid=b2c_mem.id and isactive=1) as tixian";
                string sql = "(1=1) and M_isactive=1 and M_isdel=0 ";
                string tname = " B2C_mem ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_mem where " + sql).Rows[0][0]);
                lt_pagearrow.Text = commonTool.F_pagearrow(_page, totalcount);

                //绑定初始化
                bind();
            }
        }
        private void bind()
        {
            string sql2 = "select id ,real_name from dt_manager where role_id=5 order by id";
            DataTable dt2 = comfun.GetDataTableBySQL(sql2);
            ss_cityID.DataSource = dt2.DefaultView;
            ss_cityID.DataTextField = "real_name";
            ss_cityID.DataValueField = "id";
            ss_cityID.DataBind();
            ss_cityID.Items.Insert(0, new ListItem("全部", "0"));
        }
        private string prolist(string _dzd, string _tname, string _sql, int _page)
        {
            string active = "";
            string del = "";
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f3f3f3"">";
            str += @"           <td align=center   class=""tablehead"">选择</td>";
            str += @"          <td align=center >会员编号 <br /> 会员等级</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">登陆名<br />真实姓名<br />性别</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">星级<br />层级</td>";
            //str += @"          <td height=""25"" align=center class=""tablehead"">开户行</td>";
            str += @"          <td align=center class=""tablehead"">上级 </td>";
            //str += @"          <td height=""25"" align=center class=""tablehead"">销售员</td>";
            str += @"          <td align=center class=""tablehead"">钱包</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">奖金</td>";
            str += @"          <td align=center class=""tablehead"">状态</td>";
            str += @"          <td align=center class=""tablehead"">注册日期<br />登录次数</td>";
            str += @"          <td align=center  class=""tablehead"">修改</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = B2C_mem.GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input  style=""clear:both; width:20px;"" Class=""checkall""  type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + dr["M_no"] + "<br />" + dr["mname"] + "</td>";
                str += @"          <td align=center height=24>" + dr["M_name"] + "<br />" + dr["M_truename"] + "<br />" + dr["M_sex"] + "</td>";
                str += @"          <td align=center>" + dr["M_star"] + "<br />" + dr["M_level"] + "</td>";
                //str += @"          <td align=center height=24>" + dr["M_bank"] + "<br />" + dr["M_card"] + "</td>";
                str += @"          <td align=center>" + dr["parentName"] + "</td>";
                //str += @"          <td align=left width='120'>销售员: " + dr["allChilds"] + "<br />网&nbsp;&nbsp;  点: " + dr["maxLevel"] + "<br />业&nbsp;&nbsp;  绩: " + dr["childs"] + "</td>";
                str += @"          <td align=left width='120'>升: " + dr["amt"] + "<br />现: " + dr["amt2"] + "<br />冻: " + dr["M_dongjie"] + "</td>";
                ////<a href='B2C_Accout_List_New.aspx?mid=" + dr["id"].ToString() + "'></a>
                str += @"          <td align=left width='120'>总业绩: " + dr["ticheng"] + "<br />提&nbsp;&nbsp; 现: " + dr["tixian"] + "<br />余&nbsp;&nbsp; 额: " + dr["amt2"] + "</td>";
                active = Convert.ToInt32(dr["M_isactive"]) == 1 ? "生效" : "未生效";
                del = Convert.ToInt32(dr["M_isdel"]) == 0 ? "未删除" : "已删除";
                str += @"          <td align=center>" + active + "<br />" + del + "</td>";
                str += @"          <td align=center>" + dr["M_regtime"] + "<br />" + dr["M_hits"] + "</td>";
                str += @"          <td align=center> <a href='B2C_mem_Add_Service_Center.aspx?id=" + dr["id"] + "&M_isactive=1'>修改</a>";
                //str += @"  <br /> <a href='B2C_Account_New_Add.aspx?mid=" + dr["id"] + "'>财务</a>";
                str += @"</td>";
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
                cno = "M_mobile";
            }
            else if (ss_cid.Value == "1")
            {
                cno = "M_truename";
            }
            string _cityID = ss_cityID.Value.Trim();
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

            string sql = "1=1 ";
            if (keyword != "")
                sql += " and " + cno + " like '%" + keyword + "%'";
            if (_cityID != "" && _cityID != "0")
                sql += " and cityID = " + _cityID;
            string dzd = " *,(select Mvip_name from B2C_memvip where B2C_memvip.Mvip_id=B2C_mem.M_vip)as mname";
            dzd += ",(select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=1 order by id desc) as amt,(select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=2 order by id desc) as amt2 ";
            dzd += ",isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=3 order by id desc),0) as M_dongjie";
            dzd += ",(select m_truename from b2c_mem as m1 where m1.id = b2c_mem.parentID) as parentName";
            dzd += ",(select m_truename from b2c_mem as m2 where m2.id = b2c_mem.jieshaoID) as jieshaoName";
            dzd += ",(select real_name from dt_manager where dt_manager.id=b2c_mem.cityID) as cityName";
            dzd += ",(select count(id) from b2c_mem as m3 where m3.jieshaoID = b2c_mem.id) as childs";
            dzd += ",(select count(id) from b2c_mem as m4 where m4.m_no like b2c_mem.m_no +'%' and m4.m_level>b2c_mem.m_level) as allChilds";
            dzd += ",(select max(m_level) from b2c_mem as m5 where m5.m_no like b2c_mem.m_no +'%') as maxLevel";
            dzd += ",(select top 1 m_truename from b2c_mem as m6 where m6.m_no like b2c_mem.m_no +'%' order by m_level desc,id desc ) as endName";
            dzd += ",(select  sum(mvip_price) from b2c_mem as m7,B2C_memvip where m7.m_vip =b2c_memvip.Mvip_id and m7.jieshaoID = b2c_mem.id and m7.m_isactive=1) as ticheng";
            dzd += ",(select  sum(tx_money) from b2c_tixian  where mid=b2c_mem.id and isactive=1) as tixian";
            string tname = " B2C_mem ";
            if (isActive == 1)
            {
                sql = sql + " and M_isactive=1";
            }
            if (isDel == 1)
            {
                sql = sql + " and M_isdel = 1 ";
            }

            lb_prolist.Text = prolist(dzd, tname, sql, Convert.ToInt32(Request["page"]));//
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_mem where " + sql).Rows[0][0]);
            lt_pagearrow.Text = commonTool.F_pagearrow(Convert.ToInt32(Request["page"]), totalcount);
        }

        #region  功能按钮
        /// <summary>
        /// 假删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    string id = _id;
                    try
                    {
                        B2C_mem.setDel(id);
                        Response.Write("<script language='javascript'>alert('设置删除成功！');location.href='B2C_mem_List_Service_Center_isactive.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('设置删除失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }

        /// <summary>
        /// 启动 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbtnstar_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    string id = _id;
                    try
                    {
                        B2C_mem.setActive(id);
                        Response.Write("<script language='javascript'>alert('设置启停成功！');location.href='B2C_mem_List_Service_Center_isactive.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('设置启停失败！');history.go(-1);</script>");
                    }
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