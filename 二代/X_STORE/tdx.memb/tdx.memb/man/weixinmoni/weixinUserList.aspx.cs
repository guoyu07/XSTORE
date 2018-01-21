using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;
using System.Text;

namespace tdx.memb.man.weixinmoni
{
    public partial class weixinUserList : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["wid"] != null)
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小贴士：</span> 认证服务号，可以将您的粉丝下载到本系统中维护。";
                    getData();
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "memb/weixinmoni/weixinUserList.cs", Session["wID"].ToString());
            }


        }
        protected void getData()
        {
            int pagesize = 20;
            int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
            string _sqlex = "";
            if (comFunction.NoHTML(sousuo_txt.Value) == "" || comFunction.NoHTML(sousuo_txt.Value.Trim()) == "")
            {
                _sqlex = "";
            }
            else
            {
                _sqlex = "and  nick_name like '%" + comFunction.NoHTML(sousuo_txt.Value.Trim().Replace("'", "")) + "%' ";

            }
            string _infoSql = "select *,(row_number() over(order by cityID)) as rown from wx_userInfo where cityID=" + Session["wid"].ToString() + _sqlex;

            string _sql = "with c as (" + _infoSql + ") select top " + pagesize + " * from c where rown>" + (_page - 1) * pagesize + " order by rown;";
            DataTable dt = new DataTable();
            dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                ylList.Text = pageList(dt);
                int totalCount = Convert.ToInt32(comfun.GetDataTableBySQL("select * from wx_userInfo where cityID=" + Session["wid"].ToString() + _sqlex).Rows.Count);
                // lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalCount);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalCount, 20, Request.Form, Request.QueryString);
            }
        }
        /// <summary>
        /// 下载的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_downexcel(object sender, EventArgs e)
        {
            try
            {
                string files = "";
                string _infoSql = "select * from wx_userInfo where cityID=" + Session["wid"].ToString();

                DataTable dt = new DataTable();
                dt = comfun.GetDataTableBySQL(_infoSql);
                if (dt.Rows.Count > 0)
                {
                    files = pageList(dt, 1);
                }

                if (!string.IsNullOrEmpty(files))
                {
                    //不为空则是链接
                    string lj = "hylb_" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "_").Replace("-", "_").Replace("/", "_") + ".csv";
                    string glj = Request.MapPath("/upload/") + lj;
                    string url = "../../down.aspx?filename=" + lj;
                    try
                    {

                        if (System.IO.File.Exists(glj))
                        {
                            System.IO.File.Delete(glj);

                        }
                        Byte[] bys = System.Text.Encoding.GetEncoding("GB2312").GetBytes(files);
                        System.IO.Stream stm = System.IO.File.Create(glj);
                        stm.Write(bys, 0, bys.Length);
                        stm.Close();
                        stm = null;
                        xiazai.Text = "<a href='" + url + "'  class=\"btnGreen\" >下载excel</a>";
                    }
                    catch (System.Exception ex)
                    {
                        xiazai.Text = "<a href='####'  class=\"btnGreen\">导出错误</a>";
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "memb/weixinmoni/weixinUserList.cs", Session["wID"].ToString());
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {

            try
            {
                getData();
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "memb/weixinmoni/weixinUserList.cs", Session["wID"].ToString());
            }

        }
        private string pageList(DataTable _dt, int isExcel = 0)
        {
            string result1 = "";
            StringBuilder sbex = new StringBuilder();
            if (_dt.Rows.Count > 0)
            {
                sbex.Append("关注用户列表\n");
                result1 += "\r\n";
                result1 += " \r\n <table>";
                result1 += " \r\n <tbody>";
                result1 += "\r\n <tr>";
                sbex.Append("昵称,");
                sbex.Append("备注,");
                sbex.Append("分组名称,");
                sbex.Append("微信号\n");
                result1 += "\r\n <th >昵称</th> ";
                result1 += "\r\n <th >备注</th> ";
                result1 += "\r\n <td >分组名称</th> ";
                result1 += "\r\n <th >微信号</th> ";
                result1 += "\r\n <th >修改</th> ";
                result1 += " \r\n </tr>";
                foreach (DataRow dr in _dt.Rows)
                {
                    if (dr["nick_name"].ToString().IndexOf(',') > 0 || dr["nick_name"].ToString().IndexOf('，') > 0 || string.IsNullOrEmpty(dr["nick_name"].ToString()))
                    {
                        continue;
                    }
                    result1 += "\r\n <tr>";
                    sbex.Append(dr["nick_name"] + ",");
                    sbex.Append(dr["remark_name"] + ",");
                    sbex.Append(dr["group_name"] + ",");
                    sbex.Append(dr["weixinID"] + "\n");
                    result1 += "\r\n <td >" + dr["nick_name"] + "</td> ";
                    result1 += "\r\n <td >" + dr["remark_name"] + "</td> ";
                    result1 += "\r\n <td >" + dr["group_name"] + "</td> ";
                    result1 += " \r\n <td >" + dr["weixinID"] + "</td> ";
                    result1 += " \r\n<td ><a href=\"" + "weixinUserEdit.aspx?id=" + dr["fake_id"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/memb/images4/Icon_xiugai.png\"></a></td>";
                    result1 += " \r\n </tr>";
                }
                result1 += " \r\n </table>";
                result1 += " \r\n </tbody>";
            }
            if (isExcel == 1)
            {
                return sbex.ToString();
            }
            else
            {
                return result1;
            }

        }

        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int pagesize = 20;

                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                string _sqlLog = "select * ,(row_number() over(order by cityID)) as rown from wx_userInfo where cityID=" + Session["wid"].ToString();
                _sqlLog = "with c as (" + _sqlLog + ") select top " + pagesize + " * from c where rown>" + (_page - 1) * pagesize + " order by rown;";

                _sqlLog += string.Format("select * from wx_userInfo where cityID={0};", Session["wid"].ToString());
                DataSet ds = comfun.GetDataSetBySQL(_sqlLog);
                DataTable _dt1 = ds.Tables[0];
                DataTable _dt2 = ds.Tables[1];

                ylList.Text = pageList(_dt1);
                int totalcount = _dt2.Rows.Count;
                //   lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "memb/weixinmoni/weixinUserList.cs", Session["wID"].ToString());
            }

        }
    }
}