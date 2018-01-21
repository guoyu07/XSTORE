using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.formcontrols
{
    public partial class controlsList : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack & Request["id"] != null)
            {
                try
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
                        lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，您可以重新配置您的" + co.name + "表单";
                        //   xmmiaoshu.Text = co.des;
                    }

                    tianjia.Text = "<input value='添加字段' class=\"btnAdd\" type='button' onclick=\"location.href='controlEdit.aspx?objid=" + Request["id"].ToString() + "';\"/>";


                    int _wid = Convert.ToInt32(Request["id"].ToString());
                    string _sql = "*";
                    string _where = string.Format(" wid={0}", _wid);
                    DataTable dt = control_key.GetList(_sql, _where);
                    DataTable dtDict = control_dict.GetList("id,name", "1=1");
                    Dictionary<int, string> dictNames = new Dictionary<int, string>();
                    if (dtDict.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtDict.Rows)
                        {
                            dictNames.Add(Convert.ToInt32(dr["id"].ToString()), dr["name"].ToString());
                        }
                    }
                    else
                    {
                        lt_result.Text = "控件字典没有数据";
                        //  Response.Write("<script language='javascript'>alert('控件字典没有数据！');</script>");
                    }
                    string result1 = "";
                    if (dt.Rows.Count > 0)
                    {
                        result1 += "\r\n";
                        result1 += " \r\n <table >";
                        result1 += " \r\n <tbody>";
                        result1 += "\r\n <tr>";
                        result1 += "\r\n <th > <input name=\"delAll\" id=\"delAll\" onclick=\"this.value=checkAll(form1.delbox,this);\" type=\"checkbox\"><label for=\"delAll\">全选</th> ";
                        result1 += "\r\n <th >名称</th> ";
                        result1 += "\r\n <th >类型</th> ";
                        result1 += "\r\n <th >排序</th> ";
                        result1 += " \r\n <th>操作</th> ";
                        result1 += " \r\n </tr>";
                        //   B2C_AccOperate b2c_acc = new B2C_AccOperate();
                        foreach (DataRow dr in dt.Rows)
                        {
                            int _id = Convert.ToInt32(dr["id"].ToString());
                            result1 += " \r\n <tr>";
                            result1 += " \r\n <td > <input name=\"delbox\" value=\"" + dr["id"].ToString() + "\" type=\"checkbox\"></td> ";
                            result1 += " \r\n <td ><a  href=\"" + "cedit.aspx?id=" + dr["id"].ToString() + "&objid=" + Request["id"].ToString() + "\">" + dr["name"].ToString() + "</a></td> ";
                            result1 += " \r\n  <td >" + dictNames[Convert.ToInt32(dr["type_id"].ToString())] + "</td> ";
                            result1 += " \r\n  <td >" + dr["sort"].ToString() + "</td> ";
                            int nowenben = Convert.ToInt32(dr["type_id"].ToString()) > 3 ? 1 : 0;
                            if (nowenben == 1)
                            {
                                result1 += " \r\n<td ><a   href=\"" + "controlitem.aspx?id=" + dr["id"].ToString() + "&objid=" + Request["id"].ToString() + "\"><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                            }
                            else
                            {
                                result1 += " \r\n<td >无子项</td>";
                            }

                            result1 += " \r\n </tr>";
                        }
                        result1 += " \r\n </tbody>";
                        result1 += " \r\n </table>";
                        zdList.Text = result1;
                    }
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/formcontrols/controlsList.cs", Session["wID"].ToString());
                }
            }
        }
        protected void del(object sender, EventArgs e)
        {
            try
            {
                if (Request["delbox"] != null)
                {
                    string ids = Request["delbox"].ToString();
                    string sql = string.Format("delete from control_key where id in ({0}); delete from control_value where key_id in({0});", ids);

                    if (comfun.DelbySQL(sql) > 0)
                    {
                        lt_result.Text = "删除成功";
                        Response.Write("<script language='javascript'>location.href='controlsList.aspx?id=" + Request["id"].ToString() + "';</script>");

                    }
                    else
                    {
                        lt_result.Text = "删除失败";
                        Response.Write("<script language='javascript'>location.href='controlsList.aspx?id=" + Request["id"].ToString() + "';</script>");

                    }
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/formcontrols/controlsList.cs", Session["wID"].ToString());
            }
        }
    }
}