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
using tdx.Weixin;
using System.IO;

namespace tdx.memb.man.formcontrols
{
    public partial class userValuesList : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tianjia.Text = "<input value='返回上一层' class=\"btnAdd\" type='button' onclick=\"location.href='objControlsList.aspx';\"/>";
            if (!IsPostBack)
            {
                try
                {
                    if (!IsPostBack & Request["id"] != null)
                    {
                        control_obj co = new control_obj(Convert.ToInt32(Request["id"].ToString()));
                        if (co.id == 0)
                        {
                            lt_result.Text = "请选择正确的项目";
                            Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                            return;
                        }
                        else
                        {
                            xmmingcheng.Text = co.name;

                        }
                        ShowInfo("");

                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/formcontrols/userValuesList.cs", Session["wID"].ToString());
                }
            }
        }
        /// <summary>
        /// 输出结果 如果第二个参数不为空则是下载模式模式
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="isExcel"></param>
        /// <returns></returns>
        protected string ShowInfo(string sql, int isExcel = 0)
        {
            try
            {
                int _wid = Convert.ToInt32(Request["id"].ToString());
                string _sql = "*";
                string _where = string.Format(" wid={0}", _wid);
                string titleTableSql = " select  * from control_key where wid  = " + Request["id"].ToString() + " and type_id<>7 order by sort asc";
                string nriongSql = "";
                if (!string.IsNullOrEmpty(sql))
                {
                    //不为空说明是搜索来的
                    string allSql2 = "select ono from control_user where  key_id in(select id from control_key where  wid=" + Request["id"].ToString() + " ) " + (string.IsNullOrEmpty(sql) ? "" : sql) + " order by regtime desc , id asc";
                    DataTable onos = comfun.GetDataTableBySQL(allSql2);
                    if (onos.Rows.Count > 0)
                    {
                        nriongSql = "and ono in (";
                        for (int i = 0; i < onos.Rows.Count; i++)
                        {
                            if (i > 0)
                            {
                                nriongSql += ",'" + onos.Rows[i]["ono"].ToString() + "'";
                            }
                            else
                            {
                                nriongSql += "'" + onos.Rows[i]["ono"].ToString() + "'";
                            }
                        }
                        nriongSql += ")";
                    }
                }
                string allSql = "select * from control_user where  key_id in(select id from control_key where  wid=" + Request["id"].ToString() + " ) " + (string.IsNullOrEmpty(nriongSql) ? "" : nriongSql) + " order by regtime desc , id asc";
                //分组
                string groupBy = "with a as( select count(id) gs, ono  from control_user   where  key_id in(select id from control_key where  wid=" + Request["id"].ToString() + " ) group by ono  ) select *,(select top 1 regtime from control_user as b where b.ono=a.ono) as regtime from a order by regtime desc";
                //string groupBy = "select count(id) gs, ono from control_user where  key_id in(select id from control_key where  wid=" + Request["id"].ToString() + " ) order by regtime desc  group by ono";
                DataTable titles = comfun.GetDataTableBySQL(titleTableSql);
                DataTable alldt = comfun.GetDataTableBySQL(allSql);
                DataTable groupNeirong = comfun.GetDataTableBySQL(groupBy);
                StringBuilder excel = new StringBuilder();  //为excel准备

                if (alldt.Rows.Count > 0 && ((!string.IsNullOrEmpty(sql) && !string.IsNullOrEmpty(nriongSql)) || (string.IsNullOrEmpty(sql) && string.IsNullOrEmpty(nriongSql))))
                {

                    //查询对应所有的
                    // 当前所有关键字
                    DataTable dtkeys = control_key.GetList(_sql, _where);
                    //当前所有字段对应的值
                    DataTable dtvalues = comfun.GetDataTableBySQL(string.Format("select * from control_value where  key_id in(select id from control_key where  wid={0} ) order by  sort asc ", Request["id"].ToString()));
                    Dictionary<int, string> dictNames = new Dictionary<int, string>();
                    if (dtkeys.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtkeys.Rows)
                        {
                            dictNames.Add(Convert.ToInt32(dr["id"].ToString()), dr["name"].ToString());
                        }
                    }
                    else
                    {
                        lt_result.Text = "控件字典没有数据";
                        return "";
                    }
                    Dictionary<int, string> dictValues = new Dictionary<int, string>();
                    if (dtvalues.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtvalues.Rows)
                        {
                            dictValues.Add(Convert.ToInt32(dr["id"].ToString()), dr["value"].ToString());
                        }

                    }
                    //else
                    //{
                    //    // Response.Write("<script language='javascript'>alert('控件字典没有数据！');</script>");
                    //    return "";
                    //}

                    control_obj co = new control_obj(Convert.ToInt32(Request["id"].ToString()));
                    if (co.id == 0)
                    {
                        lt_result.Text = "请选择正确的项目";
                        Response.Write("<script language='location.href='objControlsList.aspx';</script>");
                        return "";
                    }
                    else
                    {
                        excel.Append(co.name + "\n");

                    }
                    string result1 = "";
                    //开始输出列表内容
                    result1 += "\r\n";
                    result1 += " \r\n <table >";
                    result1 += " \r\n <tbody>";
                    result1 += "\r\n <tr>";
                    //result1 += "\r\n <td height='40' align=\"center\">选择</td> ";
                    if (titles.Rows.Count > 0)
                    {
                        for (int i = 0; i < titles.Rows.Count; i++)
                        {
                            result1 += " \r\n <th >" + titles.Rows[i]["name"].ToString() + "</th> ";
                            ///////////这是保存文件的类
                            excel.Append(titles.Rows[i]["name"].ToString() + ",");
                        }
                    }
                    int countTitle = titles.Rows.Count + 2;  //列总数
                    result1 += " \r\n <th >IP</th> ";
                    excel.Append("IP,");
                    result1 += " \r\n <th >微信ID</th> ";
                    excel.Append("微信ID,");
                    result1 += " \r\n <th >时间</th> ";
                    excel.Append("时间\n");
                    result1 += " \r\n </tr>";
                    if (alldt.Rows.Count > 0)
                    {
                        Dictionary<int, string> infoDict = new Dictionary<int, string>();
                        Dictionary<int, string> infoNeirong = new Dictionary<int, string>();
                        //添加表头的对应信息
                        for (int i = 0; i < titles.Rows.Count; i++)
                        {
                            infoDict.Add(Convert.ToInt32(titles.Rows[i]["id"].ToString()), "");
                        }
                        infoNeirong.Add(1, "ip");
                        infoNeirong.Add(2, "微信ID");
                        infoNeirong.Add(3, "时间");
                        for (int j = 0; j < groupNeirong.Rows.Count; j++)  //循环分组之后的具体内容
                        {
                            //内部过滤
                            DataView dt = new DataView(alldt);
                            dt.RowFilter = "ono ='" + groupNeirong.Rows[j]["ono"].ToString() + "'";  //筛选对应分组的 一组内容
                            int geshu = Convert.ToInt32(groupNeirong.Rows[j]["gs"].ToString());//取到内容的个数
                            DataTable nrTable = dt.ToTable();
                            if (nrTable.Rows.Count == 0)
                            {
                                continue;
                            }
                            for (int k = 0; k < geshu; k++)
                            {
                                string valuesTb = "";  //对应内容
                                //根据个数向字典添加信息
                                //先判断是选项值还是内容
                                if (Convert.ToInt32(nrTable.Rows[k]["value_id"].ToString()) == 0)
                                {
                                    //选项为0则是文本
                                    //判断文本是否为空
                                    if (!Convert.IsDBNull(nrTable.Rows[k]["value_txt"].ToString()))
                                    {
                                        //如果不为空内容

                                        valuesTb = nrTable.Rows[k]["value_txt"].ToString();
                                    }
                                }
                                else
                                {
                                    //选项值对应的内容
                                    if (dictValues.ContainsKey(Convert.ToInt32(nrTable.Rows[k]["value_id"].ToString())))
                                    {
                                        valuesTb = dictValues[Convert.ToInt32(nrTable.Rows[k]["value_id"].ToString())];
                                    }

                                }
                                if (infoDict.ContainsKey(Convert.ToInt32(nrTable.Rows[k]["key_id"].ToString())))
                                {
                                    infoDict[Convert.ToInt32(nrTable.Rows[k]["key_id"].ToString())] = valuesTb;
                                }
                                if (k == 0)
                                {
                                    infoNeirong[1] = nrTable.Rows[k]["ip"].ToString();
                                    infoNeirong[2] = nrTable.Rows[k]["wwv"].ToString();
                                    infoNeirong[3] = Convert.ToDateTime(nrTable.Rows[k]["regtime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                }

                            }
                            //循环结束之后 输出
                            result1 += " \r\n <tr>";

                            foreach (string vl in infoDict.Values)  //输出表表单项
                            {
                                result1 += " \r\n  <td >" + vl + "</td> ";
                                excel.Append(vl + ",");

                            }
                            weixin wx = new weixin();
                            string _appID = "";//开发者ID
                            string _appPSW = "";
                            string _toUser = "";
                            string _nicheng = "";
                            //string _sqlNicheng = "select wx_DID,wx_Dpsw from wx_mp where wid="+Session["wID"]+"";
                            DataTable _dt = wx_mp.GetWxList(Convert.ToInt32(Session["wID"]));
                            int count_title = 0;
                            foreach (int vsl in infoNeirong.Keys)  //输出表表单项
                            {
                                //if (_dt.Rows.Count > 0)
                                //{
                                //    _appID = _dt.Rows[0]["wx_DID"].ToString();
                                //    _appPSW = _dt.Rows[0]["wx_Dpsw"].ToString();
                                //    _toUser = infoNeirong[2];
                                //    _nicheng =
                                //   wx.GetNichen(_toUser, _appID, _appPSW);
                                //}
                                count_title++;
                                if (count_title == 3)
                                {
                                    excel.Append(infoNeirong[vsl] + "\n");
                                }
                                else
                                {
                                    excel.Append(infoNeirong[vsl] + ",");
                                }
                                result1 += " \r\n  <td >" + (string.IsNullOrEmpty(_nicheng) ? "" : _nicheng + "<br/>") + infoNeirong[vsl] + "</td> ";
                            }
                            result1 += " \r\n </tr>";
                            //一组内容循环结束
                            infoNeirong.Clear();//清空
                            infoDict.Clear();
                            //添加表头的对应信息
                            for (int i = 0; i < titles.Rows.Count; i++)
                            {
                                infoDict.Add(Convert.ToInt32(titles.Rows[i]["id"].ToString()), "");
                            }
                            infoNeirong.Add(1, "ip");
                            infoNeirong.Add(2, "微信ID");
                            infoNeirong.Add(3, "时间");
                        }

                    }
                    result1 += " \r\n </tbody>";
                    result1 += " \r\n </table>";


                    if (isExcel == 1)
                    {
                        return excel.ToString();
                    }
                    else
                    {
                        zdList.Text = result1;
                        return "";
                    }
                }
                else
                {
                    if (isExcel == 1)
                    {
                        return excel.ToString();
                    }
                    else
                    {
                        zdList.Text = "";
                        return "";
                    }

                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/formcontrols/userValuesList.cs", Session["wID"].ToString());
            }
            return "";
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
                if (sousuo_txt.Value == "" || sousuo_txt.Value.Trim() == "")
                {
                    files = ShowInfo("", 1);
                }
                else
                {
                    string _where = "";
                    if (Request["select_sousuo"].ToString().Equals("全部"))
                        _where += " and ( value_txt like '%" + sousuo_txt.Value + "%' or wwv like '%" + sousuo_txt.Value + "%') ";//输入姓名查询
                    if (Request["select_sousuo"].ToString().Equals("微信ID"))
                        _where += " and  wwv like '%" + sousuo_txt.Value + "%' ";//输入原始号查询
                    files = ShowInfo(_where, 1);
                    //   dt = B2C_mem.GetList(_sql, _where);

                }
                if (!string.IsNullOrEmpty(files))
                {
                    //不为空则是链接
                    string lj = "bdjg_" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "_").Replace("-", "_").Replace("/", "_") + ".csv";
                    string glj = Request.MapPath("/upload/") + lj;
                    string url = "down.aspx?filename=" + lj;
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



                        xiazai.Text = "<input value='下载excel' class=\"btnGray\" type='button' onclick=\"location.href='http://www.china-mail.com.cn/upload/' +'" + lj + "';\"/>";

                        //xiazai.Text = "<a href='" + url + "'  class=\"btnGreen\" >下载excel</a>";
                    }
                    catch (System.Exception ex)
                    {
                        lt_result.Text = "导出错误";

                        //xiazai.Text = "<a href='####'  class=\"btnGreen\">导出错误</a>";
                    }
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/formcontrols/userValuesList.cs", Session["wID"].ToString());
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {

            try
            {
                if (sousuo_txt.Value == "" || sousuo_txt.Value.Trim() == "")
                {
                    ShowInfo("");
                }
                else
                {
                    string _where = "";
                    if (Request["select_sousuo"].ToString().Equals("全部"))
                        _where += " and ( value_txt like '%" + sousuo_txt.Value + "%' or wwv like '%" + sousuo_txt.Value + "%') ";//输入姓名查询
                    if (Request["select_sousuo"].ToString().Equals("微信ID"))
                        _where += " and  wwv like '%" + sousuo_txt.Value + "%' ";//输入原始号查询
                    ShowInfo(_where);
                    //   dt = B2C_mem.GetList(_sql, _where);
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/formcontrols/userValuesList.cs", Session["wID"].ToString());
            }
        }
    }
}