using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Shop.FreightManage
{
    public partial class FerightMainEdit2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                if (id > 0)
                {
                    BindList(id);
                }
            }
        }

        protected void BindList(int id)
        {
            DataTable dt = comfun.GetDataTableBySQL("select * from [WP_FreightMainD] where mainid='"+id+"' and areas!='默认'");
            DataTable dt2 = comfun.GetDataTableBySQL("select * from [WP_FreightMainD] where mainid='" + id + "' and areas='默认'");          
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0]["计价方式"].ToString() == "0")
                {
                    string msg = "$(function(){ $(\"#cgTitle1\").html(\"件内\");$(\"#cgTitle2\").html(\"件\"); $(\"#changeTitle1\").html(\"首件(件)\"); $(\"#changeTitle2\").html(\"续件(件)\");})";
                    Page.ClientScript.RegisterStartupScript(GetType(), "msg", msg, true);
                    rdoj.Checked = true;
                }
                else
                {
                    string msg = "$(function(){ $(\"#cgTitle1\").html(\"kg内\");$(\"#cgTitle2\").html(\"kg\");$(\"#changeTitle1\").html(\"首重(kg)\");$(\"#changeTitle2\").html(\"续重(kg)\");})";
                    Page.ClientScript.RegisterStartupScript(GetType(), "msg", msg, true);
                    rdoW.Checked = true;
                }
                string[] Arry = dt2.Rows[0]["运送方式"].ToString().Split(',');
                txt_bianhao.Text = dt2.Rows[0]["name"].ToString();
                txt默认kg.Value = dt2.Rows[0]["shouzhong"].ToString();
                txt默认元.Value = dt2.Rows[0]["shoujia"].ToString();
                txt增加kg.Value = dt2.Rows[0]["xuzhong"].ToString();
                txt增加元.Value = dt2.Rows[0]["xujia"].ToString();
                hidid.Value = dt2.Rows[0]["id"].ToString();
                if (Arry[0] == "平邮")
                {
                    ck平邮.Checked = true;
                }

                if (Arry[1] == "快递")
                {
                    ck快递.Checked = true;
                }
                if (Arry[2] == "EMS")
                {
                    ckEMS.Checked = true;
                }   
            }
            string strTr = "";
            if (dt.Rows.Count > 0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string[] Arry = dt.Rows[i]["运送方式"].ToString().Split(',');
                    strTr += " <tr><td id=\"td_" + i + "\"><a href=\"javascript:;\" onclick=\"add(this)\">编辑</a><input type=\"text\" value=\"" + dt.Rows[i]["areas"] + "\" /><input type=\"hidden\" value=\""+dt.Rows[i]["id"]+"\"/> </td><td><input type=\"text\" value=\"" + dt.Rows[i]["shouzhong"] + "\" /></td><td><input type=\"text\" value=\"" + dt.Rows[i]["shoujia"] + "\" /></td><td><input type=\"text\" value=\"" + dt.Rows[i]["xuzhong"] + "\" /></td><td><input type=\"text\" value=\"" + dt.Rows[i]["xujia"] + "\" /></td><td>";                   
                    if (Arry[0] == "平邮")
                    {
                        strTr += "<input type=\"checkbox\" id=\"ck平邮" + i + "\" checked=\"checked\" value=\"平邮\"/>平邮";
                    }
                    else
                    {
                        strTr += "<input type=\"checkbox\" id=\"ck平邮" + i + "\"  value=\"平邮\"/>平邮";
                    }
                    if (Arry[1] == "快递")
                    {
                        strTr += "<input type=\"checkbox\" id=\"ck快递" + i + "\" checked=\"checked\"  value=\"快递\"/>快递";
                    }
                    else
                    {
                        strTr += "<input type=\"checkbox\" id=\"ck快递" + i + "\" value=\"快递\"/>快递";
                    }
                    if (Arry[2] == "EMS")
                    {
                        strTr += "<input type=\"checkbox\" id=\"ckEMS" + i + "\" checked=\"checked\"  value=\"EMS\"/>EMS";
                    }
                    else
                    {
                        strTr += "<input type=\"checkbox\" id=\"ckEMS" + i + "\" value=\"EMS\"/>EMS";
                    }                                       
                    strTr+="</td><td><a href=\"javascript:;\" onclick=\"del(this)\">删除</a></td></tr>";
                }
                ltrTr.Text = strTr;
            }
        }

    }
}