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

namespace tdx.memb.man.Texts
{
    public partial class wx_keys_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小贴士：</span> 在这里，可以设置网友在您的公众号里发送关键词时，对应的自动回复内容。从而实现自动客服功能";
            int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);

            if (_wid == 0)
            {
                Response.Write("<script language='javascript'>alert('请先选择具体要操作的公众号！');location.href='/sets/wx_mp_list.aspx';</script>");
                return;
            }
            else
            {
                try
                {
                    wx_mp wxmp = new wx_mp(_wid);
                    lt_mp.Text = wxmp.wx_nichen;
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('请先选择具体要操作的公众号！" + ex.Message.Replace("'", "") + "');location.href='/sets/wx_mp_list.aspx';</script>");
                    return;
                }
            }

            string _sql = "(1=1)"; //  where wid=" + Session["wID"].ToString().Trim() + "and cityID=" + _wid + " and cityid in (select id from wx_mp)
            lb_catelist.Text = pagelist(_sql);
            //生成分页按钮
            int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_keys where 1=1 and " + _sql).Rows[0][0]);
            //  lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);
            lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);

            lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\" href='wx_keys_Add.aspx?wid=" + _wid.ToString().Trim() + "' value=\"添加新关键词\" onclick=\"location.href='wx_keys_Add.aspx?wid=" + _wid.ToString().Trim() + "';\" />";

        }
        private string pagelist(string _sql)
        {
            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            string _dzd = " *,(select f_name from wx_keys_f where id=fid) as fname ";
            DataTable catetable = wx_keys.GetList(currentpage, _dzd, _sql);
            string str = "";
            str += @"<table >";
            str += @"        <tr>";
            str += "           <th align=center height=\"25\"><input type=checkbox  name=\"delAll\" id=\"delAll\" runat=\"server\" style=\" clear:both; width:20px;\"  onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += "          <th >排序</th>";
            str += "          <th >关键词</th>";
            str += "          <th >答案</th>";
            str += "          <th >功能</th>";
            str += "          <th  >修改</th>";
            str += "        </tr>";
            str += "        ";
            foreach (DataRow dr in catetable.Rows)
            {
                str += @"        <tr> ";
                str += "        <td> <input type=checkbox style=\"clear:both; width:20px;\" name=\"delbox\" value=\"" + dr["id"] + "\"" + (Convert.ToInt32(dr["k_isSys"]) > 0 ? "disabled" : "") + "   > </td> ";
                str += "        <td>" + dr["k_sort"] + "</td>";
                str += "        <td>" + dr["k_words"] + "</a></td>";
                str += "        <td>" + (string.IsNullOrEmpty(dr["k_url"].ToString()) ? dr["k_answer"] : dr["k_url"]) + "</td>";
                str += "        <td>" + dr["fname"] + "</td>";
                string guid = Convert.IsDBNull(dr["guid"]) ? "" : Convert.ToString(dr["guid"]);
                if (string.IsNullOrEmpty(guid))
                {
                    str += "        <td >" + (Convert.ToInt32(dr["k_isSys"]) < 2 ? "<a href=\"wx_keys_Add.aspx?id=" + dr["id"] + "&wid=" + Request["wid"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a>" : "") + "</td>";
                }
                else
                {
                    str += "        <td>" + (Convert.ToInt32(dr["k_isSys"]) < 2 ? "<a href=\"wx_keys_Edit.aspx?guid=" + guid + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a>" : "") + "</td>";
                }

                str += "    </tr>";
            }

            str += "";
            str += "</table>";

            return str;
        }

        protected void delBtn_Click(System.Object sender, System.EventArgs e)
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
                        wx_keys.myDel(cid);
                        lt_result.Text = "删除成功！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_keys_List.aspx?wid=" + Request["wid"].ToString() + "';},300);</script>";
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

        protected void ss_btn_ServerClick(System.Object sender, System.EventArgs e)
        {
            int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);
            string _sql = "(1=1)"; // where wid=" + Session["wID"].ToString().Trim() + " and cityID=" + _wid + " and cityid in (select id from wx_mp)

            //收集参数
            string keyword = ss_keyword.Value.Trim();
            keyword = keyword.Replace("'", "");
            string sql = " k_words like '%" + keyword + "%' and " + _sql;

            lb_catelist.Text = pagelist(sql);

            //生成分页按钮
            int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_keys where " + sql).Rows[0][0]);
            //   lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);
            lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
        }


    }
}