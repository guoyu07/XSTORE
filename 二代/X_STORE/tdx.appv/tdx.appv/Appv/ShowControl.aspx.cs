using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.appv
{
    public partial class ShowControl : weixinAuth
    {
        DataTable keyDt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request["id"] != null)
            {


                string themeModel = Session["theme"].ToString();
                string[] _theme = themeModel.Split('|');
                string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                string[] _tdxWeixinArry = _tdxWeixin.Split('|');
                //  YueDu.InnerHtml = "我已阅读了" + _tdxWeixinArry[1] + "<a href=\"#\">隐私政策</a>";
                lt_title.Text = _tdxWeixinArry[1];
                lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\">";
                lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssIndex/" + _theme[0] + "/comm.css\" /> ";
                lt_theme.Text += "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Appv/images/cssDetail/" + _theme[2] + "/detail.css\" /> ";
                //lt_nichen.Text = _tdxWeixinArry[1];
                int mid = 0;
                if (Session["uid"] != null)
                {
                    int.TryParse(Session["uid"].ToString(), out mid);
                }
                control_obj co = new control_obj(Convert.ToInt32(Request["id"].ToString()));

                miaoshu.Text = co.des;
                wid.Value = Request["id"].ToString();
                uid.Value = mid.ToString();
                //处理根据当前的WID输出对应的控件内容
                InitControl(Request["id"].ToString());

            }
        }
        protected void SaveButton(object sender, EventArgs e)
        {
            DataTable drK = control_key.GetList("*", "wid=" + wid.Value.ToString());
            string sqls = "";
            string _sql = string.Format("select * from control_user where  key_id in (select id from control_key where  wid={0})", Request["id"].ToString());

            DataTable _tab = comfun.GetDataTableBySQL(_sql);
            string _ono = "";
            string _wwv = "";
            Random ra = new Random();
            if (Request["WWV"] != null)
                _wwv = Request["WWV"].ToString();
            else if (Session["WWV"] != null)
                _wwv = Session["WWV"].ToString();
            _ono = DateTime.Now.ToString("ssffffff") + ra.Next(10000, 100000).ToString();

            foreach (DataRow dr in drK.Rows)
            {
                int te = Convert.ToInt32(dr["type_id"].ToString());
                switch (te)
                {
                    case 1: //文本框
                        sqls += ChuliWenBen(dr["id"].ToString(), Request["input_" + dr["id"].ToString()], _ono, _wwv);
                        break;
                    case 3://日期
                        sqls += ChuliWenBen(dr["id"].ToString(), Request["input_" + dr["id"].ToString()], _ono, _wwv);
                        break;
                    case 4:   //单选框
                        sqls += ChuliXuanXiang(dr["id"].ToString(), Request["input_" + dr["id"].ToString()], _ono, _wwv);
                        break;
                    case 5:   //多选框
                        sqls += ChuliXuanXiang(dr["id"].ToString(), Request["input_" + dr["id"].ToString()], _ono, _wwv);
                        break;
                    case 6:   //下拉菜单
                        sqls += ChuliXuanXiang(dr["id"].ToString(), Request["input_" + dr["id"].ToString()], _ono, _wwv);
                        break;
                    case 7:   //默认文本
                        sqls += ChuliXuanXiang(dr["id"].ToString(), Request["input_" + dr["id"].ToString()], _ono, _wwv);
                        break;
                    default:
                        sqls += ChuliWenBen(dr["id"].ToString(), Request["input_" + dr["id"].ToString()], _ono, _wwv);
                        break;

                }
            }
            int cou = comfun.InsertBySQL(sqls);
            if (cou > 0)
            {
                Response.Write("<script language='javascript'>alert('恭喜你，提交成功！');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('对不起，提交失败！');</script>");
            }

        }
        /// <summary>
        /// 处理文本的返回值
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private string ChuliWenBen(string keyId, string value, string ono, string _wwv)
        {
            string ip = Request.ServerVariables["Remote_addr"].ToString();
            return string.Format("insert into control_user (key_id,value_txt,mid,ip,ono,wwv) values({0},'{1}',{2},'{3}','{4}','{5}'); \n\r", keyId, value, uid.Value, ip, ono, _wwv);
        }
        /// <summary>
        /// 处理选项的返回值
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private string ChuliXuanXiang(string keyId, string value, string _ono, string _wwv)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            string ip = Request.ServerVariables["Remote_addr"].ToString();
            string[] vas = value.Split(new char[] { ',' });
            string relt = "";
            for (int i = 0; i < vas.Length; i++)
            {
                if (!string.IsNullOrEmpty(vas[i]))
                {
                    relt += string.Format("insert into control_user (key_id,value_id,mid,ip,ono,wwv) values({0},'{1}',{2},'{3}','{4}','{5}'); \n\r", keyId, vas[i], uid.Value, ip, _ono, _wwv);
                }

            }
            return relt;
        }
        /// <summary>
        /// 根据当前WID 输出对应的表单内容
        /// </summary>
        /// <param name="wid"></param>
        private void InitControl(string wid)
        {
            string _sql = string.Format("wid={0} order by sort", wid);
            keyDt = control_key.GetList("*", _sql);
            string result = "<p class=\"title\">";
            //result += wid.Equals("10") ? " 服务地点   上海闵行保时捷中心(中春路7358号)" : "试驾地点   上海闵行保时捷中心(中春路7358号)  ";
            result += "</p>";
            foreach (DataRow dr in keyDt.Rows)
            {
                int te = Convert.ToInt32(dr["type_id"].ToString());
                switch (te)
                {
                    case 1: //文本框
                        result += "<p class=\'pbq\'><div class=\'divbq\'>" + Wenben(dr["id"].ToString(), dr["name"].ToString()) + "</div></p>";
                        break;
                    case 3://日期
                        result += "<p class=\'pbq\'><div class=\'divbq\'>" + RiQi(dr["id"].ToString(), dr["name"].ToString()) + "</div></p>";
                        break;
                    case 4:   //单选框
                        result += "<p class=\'pbq\'><div class=\'divbq\'>" + DanXuanKuang(dr["id"].ToString(), dr["name"].ToString()) + "</div></p>";
                        break;
                    case 5:   //多选框
                        result += "<p class=\'pbq\'><div class=\'divbq\'>" + DuoXuanKuan(dr["id"].ToString(), dr["name"].ToString()) + "</div></p>";
                        break;
                    case 6:   //下拉菜单
                        if (!dr["name"].ToString().Equals("性别"))
                        {
                            result += "<p class=\'pbq\'><div class=\'divbq\'>" + Xialakuang(dr["id"].ToString(), dr["name"].ToString()) + "</div></p>";
                        }
                        break;
                    case 7:   //默认文本
                        result += "<p class=\'pbq\'><div class=\'divbq\'>" + Morenwenben(dr["id"].ToString(), dr["name"].ToString()) + "</div></p>";
                        break;
                    default:
                        result += "<p class=\'pbq\'><div class=\'divbq\'>" + WenBenYu(dr["id"].ToString(), dr["name"].ToString()) + "</div></p>";
                        break;

                }
                //循环输出标签内容
            }

            //result += "<div><input type='submit' onserverclick='SaveButton' runat='Server' id='btn_save' class='btn3_mouseup' value='提交' /></div>";
            //result += " </fieldset>";
            resultStr.Text = result;
        }
        /// <summary>
        /// 多选框
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string DuoXuanKuan(string keyId, string name)
        {
            string resu = "";
            //根据当前ID获取对应的选项
            DataTable valueDt = control_value.GetList("*", string.Format("key_id={0} order by sort ", keyId));
            if (valueDt.Rows.Count > 0)
            {
                resu += "<div class='zuce-biaodan'><div class=\'divmingzi\'><label>" + name + ":</label></div>";
                foreach (DataRow dr in valueDt.Rows)
                {
                    string xuanzhong = Convert.ToInt32(dr["is_select"].ToString()) == 0 ? "" : " checked=\"checked\" ";
                    resu += string.Format("<input type=\"checkbox\" id='{2}' class='radiostyle' name=\"input_{1}\" {3} value=\"{2}\">&nbsp;<label for='{2}'>{0}</label>", dr["value"].ToString(), keyId, dr["id"].ToString(), xuanzhong);
                    //遍历对应的选项//
                }
                resu += " </div> ";
                return resu;
            }
            else
            {
                return resu;
            }

        }

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        private string Xialakuang(string keyId, string name)
        {
            string resu = "";
            //根据当前ID获取对应的选项
            DataTable valueDt = control_value.GetList("*", string.Format("key_id={0} order by sort ", keyId));
            if (valueDt.Rows.Count > 0)
            {
                resu += name.Equals("性别") ? "" : "<div class='zuce-biaodan'><div class=\'divmingzi\'><label>" + (name.Equals("时间") ? "" : name + ":") + "</label></div>";
                resu += "<select id='" + keyId + "' name='input_" + keyId + "'>";
                foreach (DataRow dr in valueDt.Rows)
                {
                    string xuanzhong = Convert.ToInt32(dr["is_select"].ToString()) == 0 ? "" : " selected=\"selected\" ";
                    resu += "<option value='" + dr["id"].ToString() + "' " + xuanzhong + ">" + dr["value"].ToString() + "";
                    //resu += string.Format("<input type=\"checkbox\" id='{2}' class='radiostyle' name=\"input_{1}\" {3} value=\"{2}\">&nbsp;<label for='{2}'>{0}</label>", dr["value"].ToString(), keyId, dr["id"].ToString(), xuanzhong);
                    //遍历对应的选项//
                    resu += "</option>";
                }
                resu += " </select>";
                resu += name.Equals("性别") ? "" : "<div></div></div>";
                return resu;
            }
            else
            {
                return resu;
            }

        }

        /// <summary>
        /// 默认文本
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string Morenwenben(string keyId, string name)
        {
            string resu = "";
            //根据当前ID获取对应的选项
            DataTable valueDt = control_value.GetList("*", string.Format("key_id={0} order by sort ", keyId));
            if (valueDt.Rows.Count > 0)
            {
                resu += "<div class='zuce-biaodan'><div class=\'divmingzi\'><label>" + (name.Equals("时间") ? "" : name + ":") + "</label></div>";
                resu += valueDt.Rows[0]["value"].ToString();
                resu += "<div></div></div>";
                return resu;
            }
            else
            {
                return resu;
            }
        }
        /// <summary>
        /// 单选框的内容
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private string DanXuanKuang(string keyId, string name)
        {
            //string result = "<div class='zuce-biaodan'><label for='" + keyId + "'>" + name + ":</label>： &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type='text' name='input_" + keyId + "' id='" + keyId + "' /><div></div></div>";
            string resu = "";
            //根据当前ID获取对应的选项
            DataTable valueDt = control_value.GetList("*", string.Format("key_id={0} order by sort ", keyId));
            if (valueDt.Rows.Count > 0)
            {
                resu += "<div class='zuce-biaodan'><div class=\'divmingzi\'><label>" + name + ":</label></div>";
                foreach (DataRow dr in valueDt.Rows)
                {
                    string xuanzhong = Convert.ToInt32(dr["is_select"].ToString()) == 0 ? "" : " checked=\"checked\" ";
                    resu += string.Format("<input type=\"radio\" id='{2}' class='radiostyle' name=\"input_{1}\" {3} value=\"{2}\">&nbsp;<label for='{2}'>{0}</label>", dr["value"].ToString(), keyId, dr["id"].ToString(), xuanzhong);
                    //遍历对应的选项//
                }
                resu += " <div></div></div> ";
                return resu;
            }
            else
            {
                return resu;
            }


            // throw new NotImplementedException();
        }
        /// <summary>
        /// 文本域
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string WenBenYu(string keyId, string name)
        {
            string result = "<div><div class=\'divmingzi\'><label for='" + keyId + "'>" + name + ":</label></div><div class='zuce-biaodan'><textarea name='input_" + keyId + "' cols='35' rows='4' class='input-xlarge' id='" + keyId + "'></textarea></div></div>";
            //string resu = string.Format("<div class=\"controlName\"><span>{0}:</span> <textarea class='px2' rows=\"6\" cols=\"20\" name=\"intput_{1}\">{0}</textarea>&nbsp;</div>", name, keyId);
            return result;
        }
        /// <summary>
        /// 日期标签输出
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string RiQi(string keyId, string name)
        {
            string result = "";
            result += "<div class='zuce-biaodan'><div class=\'divmingzi\'><label for='" + keyId + "'>" + name + ":</label></div><input type='text' onfocus=\"HS_setDate(this)\" name='input_" + keyId + "' id='" + keyId + "' />";
            //DataTable _temp;
            //DataView _dv1 = keyDt.AsDataView();
            //_dv1.RowFilter = " type_id=3 and wid=" + Request["id"];
            //_temp = _dv1.ToTable();
            //if (_temp.Rows.Count > 0)
            //{
            //    if (_temp.Rows[0]["id"].Equals(keyId))
            //    {
            // result += Shijian();
            //    }
            //}
            result += "<div></div></div>";
            //string result = "<div class='zuce-biaodan'><div class=\'divmingzi\'><label for='" + keyId + "'>" + name + ":</label></div><input type='text' visible='false'  onfocus='HS_setDate(this);' readonly='readonly' name='input_" + keyId + "' id='" + keyId + "' /><div></div></div>";
            //string resu = string.Format("<div class=\"controlName\"><span>{0}:</span><input type=\"text\" name=\"input_{1}\" value=\"{2}\"  onfocus=\"HS_setDate(this);\" readonly=\"readonly\" class=\"px\">&nbsp;</div>", name, keyId, DateTime.Now.ToString("yyyy-MM-dd"));
            return result;
        }
        /// <summary>
        /// 文本框标签输出
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string Wenben(string keyId, string name)
        {
            string result = "<div class='zuce-biaodan'><div class=\'divmingzi\'><label for='" + keyId + "'>" + name + ":</label></div><input type='text' name='input_" + keyId + "' id='" + keyId + "' />";
            if (name.Equals("顾客姓名"))
            {
                DataTable _item = keyDt;
                DataView _dv = _item.AsDataView();
                _dv.RowFilter = "name='性别' and wid=" + Request["id"];
                _item = _dv.ToTable();
                if (_item.Rows.Count > 0)
                {
                    result += Xialakuang(_item.Rows[0]["id"].ToString(), "性别");
                }
            }
            result += "<div></div></div>";
            //string resu = string.Format("<div class=\"controlName\"><span>{0}:</span><input type=\"text\" id=\"{1}\" name=\"input_{1}\" value=\"{0}\" class=\"px\">&nbsp;</div>", name, keyId);
            return result;
        }
        private string Shijian()
        {
            string result = "";
            result += @"<table id='res_date' class='calheader' cellspacing='0' cellpadding='2' title='日历' border='0' style='width:90%;height:220px;font-size:12px;font-family:Times New Roman;color:Black;border-width:1px;border-style:solid;border-color:Gainsboro;background-color:White;border-collapse:collapse;'>
                                    <tr>
                                        <td colspan='7' style='background-color:Silver;height:14pt;'>
                                            <table class='calheader' cellspacing='0' border='0' style='color:Black;font-family:Times New Roman;font-size:14pt;font-weight:bold;width:100%;border-collapse:collapse;'>
                                                <tr>
                                                    <td style='color:White;font-size:12px;width:15%;'>
                                                        <a href='javascript:__doPostBack('res_date','V5114')' style='color:White'
                                                        title='转到上一个月'>
                                                            <</a>
                                                    </td>
                                                    <td align='center' style='width:70%;'>
                                                        2014年2月
                                                    </td>
                                                    <td align='right' style='color:White;font-size:12px;width:15%;'>
                                                        <a href='javascript:__doPostBack('res_date','V5173')' style='color:White'
                                                        title='转到下一个月'>
                                                            >
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align='center' abbr='星期日' scope='col' style='color:#333333;background-color:infobackground;font-size:12px;font-weight:bold;height:12px;'>
                                            日
                                        </th>
                                        <th align='center' abbr='星期一' scope='col' style='color:#333333;background-color:infobackground;font-size:12px;font-weight:bold;height:12px;'>
                                            一
                                        </th>
                                        <th align='center' abbr='星期二' scope='col' style='color:#333333;background-color:infobackground;font-size:12px;font-weight:bold;height:12px;'>
                                            二
                                        </th>
                                        <th align='center' abbr='星期三' scope='col' style='color:#333333;background-color:infobackground;font-size:12px;font-weight:bold;height:12px;'>
                                            三
                                        </th>
                                        <th align='center' abbr='星期四' scope='col' style='color:#333333;background-color:infobackground;font-size:12px;font-weight:bold;height:12px;'>
                                            四
                                        </th>
                                        <th align='center' abbr='星期五' scope='col' style='color:#333333;background-color:infobackground;font-size:12px;font-weight:bold;height:12px;'>
                                            五
                                        </th>
                                        <th align='center' abbr='星期六' scope='col' style='color:#333333;background-color:infobackground;font-size:12px;font-weight:bold;height:12px;'>
                                            六
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            1
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align='center' style='width:14%;'>
                                            2
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            3
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            4
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            5
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            6
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            7
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            8
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align='center' style='width:14%;'>
                                            9
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            10
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            11
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            12
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            13
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            14
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            15
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align='center' style='width:14%;'>
                                            16
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            17
                                        </td>
                                        <td align='center' style='background-color:buttonhighlight;border-color:#E0E0E0;border-width:1px;border-style:Solid;width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5162')' style='color:Black'
                                            title='2月18日'>
                                                18
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5163')' style='color:Black'
                                            title='2月19日'>
                                                19
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5164')' style='color:Black'
                                            title='2月20日'>
                                                20
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5165')' style='color:Black'
                                            title='2月21日'>
                                                21
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5166')' style='color:Black'
                                            title='2月22日'>
                                                22
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5167')' style='color:Black'
                                            title='2月23日'>
                                                23
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5168')' style='color:Black'
                                            title='2月24日'>
                                                24
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5169')' style='color:Black'
                                            title='2月25日'>
                                                25
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5170')' style='color:Black'
                                            title='2月26日'>
                                                26
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5171')' style='color:Black'
                                            title='2月27日'>
                                                27
                                            </a>
                                        </td>
                                        <td align='center' style='width:14%;'>
                                            <a href='javascript:__doPostBack('res_date','5172')' style='color:Black'
                                            title='2月28日'>
                                                28
                                            </a>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                        <td align='center' style='color:#999999;width:14%;'>
                                        </td>
                                    </tr>
                                </table>";
            return result;
        }
    }
}