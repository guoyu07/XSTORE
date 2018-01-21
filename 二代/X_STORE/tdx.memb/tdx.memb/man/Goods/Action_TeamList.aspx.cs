using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;
using System.Text.RegularExpressions;

namespace tdx.memb.man.Goods
{
    public partial class Action_TeamList : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理您的微团购项目。";
                    int wid = 0;
                    if (Session["wid"] != null)
                    {
                        int.TryParse(Session["wid"].ToString(), out wid);
                    }


                    string dzd = " * ";
                    string sql = string.Format("(wID={0})", wid);
                    lb_prolist.Text = prolist(dzd, sql, 1);

                    ////生成分页按钮
                    //int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_worker").Rows[0][0]);
                    //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

                    lb_proadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='Edit_Team.aspx?wid=0'\" value=\"添加新团购\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/Action_TeamList.cs", Session["wID"].ToString());
                }

            }

        }
        private string prolist(string _dzd, string _sql, int _pageIndex)
        {
            //  string active = "";
            string str = "";
            str += @"<table  >";
            str += @"  <tbody>";
            str += @"    <tr  >";
            str += "   <th  ><input name=\"delAll\" id=\"delAll\" onclick=\"this.value=checkAll(form1.delbox,this);\" type=\"checkbox\"/>全选</th>";
            str += @"   <th  >团购项目名称</th>";
            str += @"   <th   >成团条件限制1</th>";
            str += @"   <th   >成团条件限制2</th>";
            str += @"          <th   >市场价</th>";
            str += @"          <th  >团购价</th>";
            str += @"          <th  >虚拟购买人数/最少成团人数/最多可购买数量</th>";
            str += @"          <th  >已经购买数量</th>";
            str += @"          <th >开始时间/结束时间</th>";
            str += @"          <th  >修改</th>";
            str += @"        </tr>";
            str += @"        ";
            int currentPage = 1;
            if (Request["page"] != null)
            {
                currentPage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = B2C_Team.GetList(_dzd, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr  > ";
                str += @"     <td  ><input name=""delbox"" type=""checkbox"" value=""" + dr["id"] + "\"></td>";
                str += @"          <td align=""center""  >" + dr["tm_title"] + "</td>";
                str += @"          <td  align=""center"" >" + dr["tm_tiaojian"] + "</td>";
                str += @"          <td align=""center"" >" + dr["tm_tiaojian2"] + "</td>";
                str += @"          <td align=""center"" >" + Convert.ToDouble(dr["tm_price_m"]).ToString("F2") + "</td>";
                str += @"          <td align=""center"">" + Convert.ToDouble(dr["tm_price_t"]).ToString("F2") + "</td>";
                str += @"          <td align=""center"" >" + dr["tm_AMT_xn"] + "/" + dr["tm_AMT_min"] + "/" + dr["tm_AMT_max"] + "</td>";
                str += @"          <td align=""center"" >" + Convert.ToInt32(dr["tm_AMT_have"]) + "</td>";
                str += @"          <td align=""center"" >" + dr["tm_Bdate"] + "/" + dr["tm_Edate"] + "</td>";
                str += "          <td><a href=\"Edit_Team.aspx?id=" + dr["id"] + "\"><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"  </tbody>";
            str += @"      </table>";
            return str;
        }

        protected void delBtn_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (Request["delbox"] != null)
                {
                    string delid = Request["delbox"].ToString();
                    string[] delidArry = Regex.Split(delid, ",");
                    foreach (string s in delidArry)
                    {
                        int cid = Convert.ToInt32(s);
                        try
                        {
                            B2C_Team.myDel(cid);
                            lt_result.Text = "删除成功";
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Action_TeamList.aspx';},300);</script>";
                        }
                        catch (Exception ex)
                        {
                            lt_result.Text = "删除失败！";
                        }
                    }

                }
                else
                {
                    lt_result.Text = "请选择要删除的项！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/Action_TeamList.cs", Session["wID"].ToString());
            }
        }
    }
}