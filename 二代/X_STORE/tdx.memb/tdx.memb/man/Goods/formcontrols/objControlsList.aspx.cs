using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using tdx.database.database;

namespace tdx.memb.man.formcontrols
{
    public partial class objControlsList : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    int _wid = Convert.ToInt32(Session["wid"]);
                    bool isJd = true;  //是否截断默认截断
                    if (_wid == 56)
                    {
                        isJd = false;
                        shouhou.Text = "<a  class=\"btnGreen\" href=\"ShouHouDate.aspx\">设置售后限制次数</a>";
                        baoshijiemail.Text = "<a  class=\"btnGreen\" href=\"baoshijiemail.aspx\">设置表单接收邮箱</a>";
                        BsjActivity.Text = "<a  class=\"btnGreen\" href=\"BsjActivity.aspx\">设置活动时间</a>";
                        baoshijiebianji.Text = "<span style='color:red;'>亲爱的,保时捷用户您有任何需求更改请直接联系技术负责人。</span>";
                    }
                    string _sql = "*";
                    string _where = string.Format(" wid={0}", _wid);
                    DataTable dt = control_obj.GetList(_sql, _where);
                    string result1 = "";
                    if (dt.Rows.Count > 0)
                    {
                        result1 += "\r\n";
                        result1 += " \r\n <table>";
                        result1 += " \r\n <tbody>";
                        result1 += "\r\n <tr>";
                        result1 += "\r\n <th ><input name=\"delAll\" id=\"delAll\" onclick=\"this.value=checkAll(form1.delbox,this);\" type=\"checkbox\"><label for=\"delAll\">全选</label>  </th> ";
                        result1 += "\r\n <th >名称</th> ";
                        if (_wid != 56)
                        {
                            result1 += "\r\n <th >入口地址</th> ";
                        }
                        result1 += " \r\n <th >操作</th> ";
                        result1 += " \r\n </tr>";
                        //   B2C_AccOperate b2c_acc = new B2C_AccOperate();
                        int i = 1;
                        ////////////////////////////////////////
                        DataTable dtwid = wx_mp.GetWxList(_wid);
                        string tongyongURl = "";
                        string gnt = "appv";
                        if (dtwid.Rows.Count > 0)
                        {
                            //B2C_worker bw = new B2C_worker(_wid);
                            wx_config bw = new wx_config();
                            if (!string.IsNullOrEmpty(bw.wx_GNTheme))
                            {
                                gnt = bw.wx_GNTheme;
                                tongyongURl = "{0}入口地址为：http://www.china-mail.com.cn/appv/" + "ShowControl.aspx?id={1}&WWX=" + dtwid.Rows[0]["wx_ID"].ToString();
                            }
                        }

                        //string objename = co.name;

                        /////////////////////////////////////////
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (isJd)
                            {
                                if (i <= 5)
                                {
                                    i++;
                                   // continue;
                                }



                            }

                            int _id = Convert.ToInt32(dr["id"].ToString());
                            result1 += " \r\n <tr>";
                            result1 += " \r\n <td > <input name=\"delbox\" value=\"" + dr["id"].ToString() + "\" type=\"checkbox\"></td> ";
                            result1 += " \r\n <td >" + dr["name"].ToString() + "</td> ";
                            if (_wid != 56)
                            {


                                result1 += "\r\n<td>" + string.Format(tongyongURl, dr["name"].ToString(), dr["id"].ToString()) + "</td>";
                            }
                            string neirongbsj = ((_wid == 56) ? "" : " <a  class=\"btnGreen\" href=\"" + "controlsList.aspx?id=" + dr["id"].ToString() + "\">查看表单</a>");
                            result1 += " \r\n<td ><a   href=\"" + "objedit.aspx?id=" + dr["id"].ToString() + "\"><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a>  " + neirongbsj + "</td>";
                            result1 += " \r\n </tr>";
                        }
                        result1 += " \r\n </tbody>";
                        result1 += " \r\n </table>";
                        bdList.Text = result1;
                    }
                    
                    lt_pode.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='objedit.aspx'\" value=\"添加表单项目\" />";
                }

                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/formcontrols/objControlsList.cs", Session["wID"].ToString());
                }
            }
        }
        protected void del(object sender, EventArgs e)
        {
            try
            {
                int _wid = Convert.ToInt32(Session["wid"]);
                if (_wid == 56)
                {
                    lt_result.Text = "亲爱的,保时捷用户您有任何需求更改请直接联系技术负责人！";
                    Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");
                    return;
                }
                if (Request["delbox"] != null)
                {
                    string ids = Request["delbox"].ToString();
                    string sql = string.Format("delete from control_obj where id in ({0});", ids);

                    if (comfun.DelbySQL(sql) > 0)
                    {
                        lt_result.Text = "删除成功";
                        Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");

                    }
                    else
                    {
                        lt_result.Text = "删除失败";
                        Response.Write("<script language='javascript'>location.href='objControlsList.aspx';</script>");

                    }
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/formcontrols/objControlsList.cs", Session["wID"].ToString());
            }
        }
    }
}