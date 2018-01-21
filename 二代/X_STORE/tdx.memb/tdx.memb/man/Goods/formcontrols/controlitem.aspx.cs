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
    public partial class controlitem : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null && Request["objid"] != null)
                    {
                        DataTable dt = control_key.GetList("*", "id=" + Request["id"].ToString());
                        if (dt.Rows.Count > 0)
                        {
                            int _objID = Convert.ToInt32(dt.Rows[0]["wid"].ToString());
                            control_obj co = new control_obj(_objID);
                            if (co.id == 0)
                            {
                                Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                                return;
                            }
                            else
                            {
                                qianzhui.Text = co.name + "表单配置-字段：";
                            }

                            ////////////////////////
                            if (dt.Rows[0]["type_id"].ToString() == "4" || dt.Rows[0]["type_id"].ToString() == "5" || dt.Rows[0]["type_id"].ToString() == "6" || dt.Rows[0]["type_id"].ToString() == "7")
                            {
                                int typeid = Convert.ToInt32(dt.Rows[0]["type_id"].ToString());
                                //shifouduoxuan1.Attributes.CssStyle.Remove("display");
                                //shifouduoxuan2.Attributes.CssStyle.Remove("display");
                                //shifouduoxuan1.Attributes.CssStyle.Add("display", "block");
                                //shifouduoxuan2.Attributes.CssStyle.Add("display", "block");
                                if (typeid == 7)
                                {
                                    tianjiaxiangmu.Text = "<input value='返回上一层' class=\"btnAdd\" type='button' onclick=\"location.href='controlsList.aspx?id=" + Request["objid"].ToString() + "';\"/>";


                                    //tianjiaxiangmu.Text = "<a  class=\"btnGreen\" href=\"controlsList.aspx?id=" + Request["objid"].ToString() + "\">返回上一层</a>";
                                }
                                else
                                {
                                    tianjiaxiangmu.Text = "<input value='添加新字段内容' class=\"btnAdd\" type='button' onclick=\"location.href='itemedit.aspx?id=" + Request["id"].ToString() + "&objid=" + Request["objid"].ToString() + "';\"/><input value='返回上一层' class=\"btnAdd\" type='button' onclick=\"location.href='controlsList.aspx?id=" + Request["objid"].ToString() + "';\"/>";
                                }

                            }
                            DataTable dtDict = control_dict.GetList("id,name", "id=" + dt.Rows[0]["type_id"].ToString());
                            if (dtDict.Rows.Count > 0)
                            {
                                leixing.Text = dtDict.Rows[0]["name"].ToString();
                            }
                            ziduanmingzi.Text = dt.Rows[0]["name"].ToString();
                            name.Text = dt.Rows[0]["name"].ToString();
                            sort.Text = dt.Rows[0]["sort"].ToString();
                            // xiugaianniu.Text = "<a class=\"btnGreen\" href=\"" + "cedit.aspx?id=" + dt.Rows[0]["id"].ToString() + "\">修改表单信息</a>";
                            chulixiangmu(Request["id"].ToString());
                        }



                    }
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "memb/formcontrols/controlitem.cs", Session["wID"].ToString());
                }
            }
        }
        /// <summary>
        /// 处理项目的内容
        /// </summary>
        /// <param name="p"></param>
        private void chulixiangmu(string p)
        {

            try
            {
                DataTable dt = control_value.GetList("*", "key_id=" + p);
                string result1 = "";
                if (dt.Rows.Count > 0)
                {
                    result1 += "\r\n";
                    result1 += " \r\n <table >";
                    result1 += " \r\n <tbody>";
                    result1 += "\r\n <tr>";
                    result1 += "\r\n <th  width=\"10%\" align=\"left\"><input name=\"delAll\"  onclick=\"this.value=checkAll(form1.delbox,this);\" type=\"checkbox\"><label for=\"delAll\">全部</th> ";
                    result1 += "\r\n <th >内容</th> ";
                    result1 += "\r\n <th >排序</th> ";
                    result1 += " \r\n <th >是否默认项</th> ";
                    result1 += " \r\n <th >修改</th> ";
                    result1 += " \r\n </tr>";
                    //   B2C_AccOperate b2c_acc = new B2C_AccOperate();
                    foreach (DataRow dr in dt.Rows)
                    {
                        int _id = Convert.ToInt32(dr["id"].ToString());
                        result1 += " \r\n <tr>";
                        result1 += " \r\n <td > <input name=\"delbox\" value=\"" + dr["id"].ToString() + "\" type=\"checkbox\"></td> ";
                        result1 += " \r\n <td >" + dr["value"].ToString() + "</td> ";
                        result1 += " \r\n  <td >" + dr["sort"].ToString() + "</td> ";
                        string neirong = dr["is_select"].ToString() == "1" ? "是" : "否";
                        result1 += " \r\n  <td >" + neirong + "</td> ";
                        result1 += " \r\n<td ><a  href=\"" + "itemedit.aspx?iid=" + dr["id"].ToString() + "&id=" + Request["id"].ToString() + "&objid=" + Request["objid"].ToString() + "\"><img width=\"20\" height=\"20\"  src=\"/memb/images4/Icon_xiugai.png\"></a></td>";
                        result1 += " \r\n </tr>";
                    }
                    result1 += " \r\n </tbody>";
                    result1 += " \r\n </table>";
                    xiangmu.Text = result1;
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "memb/formcontrols/controlitem.cs", Session["wID"].ToString());
            }
        }
        protected void del(object sender, EventArgs e)
        {
            try
            {
                if (Request["delbox"] != null)
                {
                    string ids = Request["delbox"].ToString();
                    string sql = string.Format(" delete from control_value where id in({0});", ids);

                    if (comfun.DelbySQL(sql) > 0)
                    {
                        lt_result.Text = "删除成功";
                        Response.Write("<script language='javascript'>location.href='controlitem.aspx?id=" + Request["id"].ToString() + "&objid=" + Request["objid"].ToString() + "';</script>");

                    }
                    else
                    {
                        lt_result.Text = "删除失败";
                        Response.Write("<script language='javascript'>location.href='controlitem.aspx?id=" + Request["id"].ToString() + "&objid=" + Request["objid"].ToString() + "';</script>");

                    }
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "memb/formcontrols/controlitem.cs", Session["wID"].ToString());
            }
        }
    }
}