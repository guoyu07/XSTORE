using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using Creatrue.Common;
using System.Data;
using DTcms.DBUtility;

namespace tdx.memb.man.Sets
{
    public partial class wxConfig_mb : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>请选择您的微官网模板。模板将影响到您的网站显示外观。";
                if (Request["nav"] != null && Request["nav"].ToString() == "true")
                {
                    daohang_Image.Text = commonTool.DaohangImage("daohang_4.jpg");
                    string beforeUrl = "../Sets/B2C_menu2_Add.aspx?nav=true";
                    string nextUrl = "../Ads/B2C_ADS_Add2.aspx?cno=009&nav=true";
                    daohang_Button.Text = commonTool.DaohangButton(beforeUrl, nextUrl, nextUrl);
                }
                int _id = Convert.ToInt32(Session["wID"].ToString());
                string _sql = "select  * from wx_theme";
                _sql += "\r\n union ";
                _sql += "\r\n select 0,'不启用快捷方式','',1,4,1";
                DataTable dt = comfun.GetDataTableBySQL(_sql);
                //B2C_worker bw = new B2C_worker(_id);
                //int _wx_theme1 = bw.wx_theme;
                //int _wx_theme2 = bw.wx_theme2;
                //int _wx_theme3 = bw.wx_theme3;
                //int _wx_theme4 = bw.wx_theme4;

                //lt_shouye.Text = GetMode(1, _wx_theme1, dt);
                //lt_liebiao.Text = GetMode(2, _wx_theme2, dt);
                //lt_xiangqing.Text = GetMode(3, _wx_theme3, dt);
                //lt_kuaijie.Text = GetMode(4, _wx_theme4, dt);


                lt_shouye.Text = GetMode(1, dt);
                lt_liebiao.Text = GetMode(2, dt);
                lt_xiangqing.Text = GetMode(3, dt);
                lt_kuaijie.Text = GetMode(4, dt);


            }
        }

        /// <summary>
        /// 提取模板
        /// </summary>
        private string GetMode(int _cid, DataTable _dt)
        {
            string result = "";
            string result1 = "";
            string result2 = "";
            string result3 = "";

            _dt.Rows.Add();
            DataView dv = new DataView(_dt);
            dv.RowFilter = " cid=" + _cid;

            DataTable newDt = dv.ToTable();
            result += "\r\n<table width=\"92%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
            int count = 0;
            string resultAll = "";

            foreach (DataRow dr in newDt.Rows)
            {
                ++count;
                if (count != 0 && count % 3 == 1)
                {
                    result1 = "\r\n<tr>";
                    result2 = "\r\n<tr>";
                    result3 = "\r\n<tr>";
                }
                result1 += "<td align=\"center\">";
                if (_cid == 1)//首页模板
                    result1 += "\r\n<img src=\"/Appv/images/" + dr["t_theme"] + "/index.jpg\" width=\"200\" height=\"320\" />";
                else if (_cid == 2)//列表模板
                    result1 += "\r\n<img src=\"/Appv/images/" + dr["t_theme"] + "/list.jpg\" width=\"200\" height=\"320\" />";
                else if (_cid == 3)//详情页模板
                    result1 += "\r\n<img src=\"/Appv/images/" + dr["t_theme"] + "/view.jpg\" width=\"200\" height=\"320\" />";
                else //快捷方式
                    result1 += "\r\n<img src=\"/images/wsite/" + dr["t_theme"] + "/kuai.jpg\" width=\"60\" height=\"60\" />";

                result1 += "\r\n</td>";

                result2 += "\r\n<td align=\"center\">";
                result2 += Convert.ToInt32(dr["isActive"].ToString()) == 1 ? "<input type=\"radio\" name=\"chk" + _cid + "\" id=\"_check" + dr["id"].ToString() + "\" value=\"" + dr["id"].ToString() + "\" checked runat=\"server\" />" : "<input type=\"radio\" name=\"chk" + _cid + "\" id=\"_chk" + dr["id"].ToString() + "\" value=\"" + dr["id"].ToString() + "\"  runat=\"server\" />";
                result2 += "\r\n" + dr["t_name"].ToString() + "";
                result2 += "\r\n</td>";

                result3 += "\r\n<td align=\"center\">";
                result3 += "\r\n&nbsp;";
                result3 += "\r\n</td>";

                if (count != 0 && count % 3 == 0)//每三个模板一行
                {
                    result1 += "\r\n</tr>";
                    result2 += "\r\n</tr>";
                    result3 += "\r\n</tr>";
                    resultAll += result1 + result2 + result3;
                }
            }
            if (count != 0 && count % 3 != 0)
            {
                result1 += "\r\n</tr>";
                result2 += "\r\n</tr>";
                result3 += "\r\n</tr>";
                resultAll += result1 + result2 + result3;

            }
            result += resultAll;
            result += "\r\n</table>";

            return result;
        }


        /// <summary>
        /// 提取模板
        /// </summary>
        private string GetMode(int _cid, int _theme, DataTable _dt)
        {
            string result = "";
            string result1 = "";
            string result2 = "";
            string result3 = "";

            _dt.Rows.Add();
            DataView dv = new DataView(_dt);
            dv.RowFilter = " cid=" + _cid;

            DataTable newDt = dv.ToTable();
            result += "\r\n<table width=\"92%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
            int count = 0;
            string resultAll = "";

            foreach (DataRow dr in newDt.Rows)
            {
                ++count;
                if (count != 0 && count % 3 == 1)
                {
                    result1 = "\r\n<tr>";
                    result2 = "\r\n<tr>";
                    result3 = "\r\n<tr>";
                }
                result1 += "<td align=\"center\">";
                if (_cid == 1)//首页模板
                    result1 += "\r\n<img src=\"/Appv/images/" + dr["t_theme"] + "/index.jpg\" width=\"200\" height=\"320\" />";
                else if (_cid == 2)//列表模板
                    result1 += "\r\n<img src=\"/Appv/images/" + dr["t_theme"] + "/list.jpg\" width=\"200\" height=\"320\" />";
                else if (_cid == 3)//详情页模板
                    result1 += "\r\n<img src=\"/Appv/images/" + dr["t_theme"] + "/view.jpg\" width=\"200\" height=\"320\" />";
                else //快捷方式
                    result1 += "\r\n<img src=\"/images/wsite/" + dr["t_theme"] + "/kuai.jpg\" width=\"60\" height=\"60\" />";

                result1 += "\r\n</td>";

                result2 += "\r\n<td align=\"center\">";
                result2 += _theme == Convert.ToInt32(dr["id"].ToString()) ? "<input type=\"radio\" name=\"chk" + _cid + "\" id=\"_check" + dr["id"].ToString() + "\" value=\"" + dr["id"].ToString() + "\" checked runat=\"server\" />" : "<input type=\"radio\" name=\"chk" + _cid + "\" id=\"_chk" + dr["id"].ToString() + "\" value=\"" + dr["id"].ToString() + "\"  runat=\"server\" />";
                result2 += "\r\n" + dr["t_name"].ToString() + "";
                result2 += "\r\n</td>";

                result3 += "\r\n<td align=\"center\">";
                result3 += "\r\n&nbsp;";
                result3 += "\r\n</td>";

                if (count != 0 && count % 3 == 0)//每三个模板一行
                {
                    result1 += "\r\n</tr>";
                    result2 += "\r\n</tr>";
                    result3 += "\r\n</tr>";
                    resultAll += result1 + result2 + result3;
                }
            }
            if (count != 0 && count % 3 != 0)
            {
                result1 += "\r\n</tr>";
                result2 += "\r\n</tr>";
                result3 += "\r\n</tr>";
                resultAll += result1 + result2 + result3;

            }
            result += resultAll;
            result += "\r\n</table>";

            return result;
        }


        /// <summary>
        /// 提交模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            string _id = Session["wID"].ToString();

            int _wx_theme = 1;
            int _wx_theme2 = 1;
            int _wx_theme3 = 1;
            int _wx_theme4 = 1;
            if (Request["chk1"] != null)
                _wx_theme = Convert.ToInt32(Request["chk1"].ToString());
            if (Request["chk2"] != null)
                _wx_theme2 = Convert.ToInt32(Request["chk2"].ToString());
            if (Request["chk3"] != null)
                _wx_theme3 = Convert.ToInt32(Request["chk3"].ToString());
            if (Request["chk4"] != null)
                _wx_theme4 = Convert.ToInt32(Request["chk4"].ToString());

            try
            {
                //B2C_worker goods = new B2C_worker(Convert.ToInt32(_id));
                //goods.wx_theme = _wx_theme;
                //goods.wx_theme2 = _wx_theme2;
                //goods.wx_theme3 = _wx_theme3;
                //goods.wx_theme4 = _wx_theme4;
                //goods.Update();

                string sql1_1 = "update wx_theme set isActive = 0 where cid = 1";
                string sql1 = "update wx_theme set isActive = 1 where id = " + _wx_theme;
                string sql2_1 = "update wx_theme set isActive = 0 where cid = 2";
                string sql2 = "update wx_theme set isActive = 1 where id = " + _wx_theme2;
                string sql3_1 = "update wx_theme set isActive = 0 where cid = 3";
                string sql3 = "update wx_theme set isActive = 1 where id = " + _wx_theme3;
                string sql4 = _wx_theme4 == 0 ? "" : "update wx_theme set isActive = 1 where id = " + _wx_theme4;
                List<string> list = new List<string>();
                list.Add(sql1_1);
                list.Add(sql1);
                list.Add(sql2_1);
                list.Add(sql2);
                list.Add(sql3_1);
                list.Add(sql3);
                if (sql4.Length > 0)
                {
                    string sql4_1 = "update wx_theme set isActive = 0 where cid = 4";
                    list.Add(sql4_1);
                    list.Add(sql4);
                }
                DbHelperSQL.ExecuteSqlTran(list);


                lt_result.Text = "设置成功！";
                if (Request["nav"] != null && Request["nav"].ToString() == "true")
                {
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wxConfig_mb.aspx?nav=true';},300);</script>";
                }

                else
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wxConfig_mb.aspx';},300);</script>";
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
            }

        }



    }
}