using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using System.Text.RegularExpressions;
using Creatrue.Common;

namespace tdx.memb.man.vipmemb
{
    public partial class JiFen_Change : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    string _sql = "select * from B2C_mem where id=" + Request["id"].ToString();
                    DataTable _dt = comfun.GetDataTableBySQL(_sql);
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        lt_biaoti.Text = " 会员--" + _dt.Rows[0]["M_name"].ToString();
                    }
                }
            }
        }
        public static bool IsNumber(String strNumber)
        {

            Regex objNotNumberPattern = new Regex("[^0-9.-]");

            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");

            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");

            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";

            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";

            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&

             !objTwoDotPattern.IsMatch(strNumber) &&

             !objTwoMinusPattern.IsMatch(strNumber) &&

             objNumberPattern.IsMatch(strNumber);
        }
        /// <summary>
        /// 增加积分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                int _wid = Convert.ToInt32(Session["wid"]);
                int _id = Convert.ToInt32(Request["id"].ToString());
                if (JiFen_Count.Value == "")
                {
                    lt_result.Text = "请输入交易金额!";
                    return;
                }
                else if (!IsNumber(JiFen_Count.Value) || (IsNumber(JiFen_Count.Value) && Convert.ToDouble(JiFen_Count.Value) <= 0))
                {
                    lt_result.Text = "增加积分必须为大于0的数字!";
                    return;
                }
                else   //添加积分
                {
                    try
                    {
                        Convert.ToInt32(JiFen_Count.Value);
                    }
                    catch
                    {
                        lt_result.Text = "增加积分必须为整数!";
                        return;
                    }
                    try
                    {
                        double _ac_Amt = 0;//记录余额
                        string _yueSql = "top 1 *";
                        string _yueWhere = string.Format(" ptid=1 and uid={0} order by id desc", _id);//查询对应会员的积分数
                        DataTable yue_dt = B2C_AccOperate.GetList(_yueSql, _yueWhere);
                        if (yue_dt.Rows.Count > 0)
                            _ac_Amt = Convert.ToDouble(yue_dt.Rows[0]["ac_Amt"].ToString());//账户当前的积分数
                        double enterJiFen = Convert.ToDouble(JiFen_Count.Value);
                        _ac_Amt += enterJiFen;
                        B2C_AccOperate b2c_Opp = new B2C_AccOperate();
                        b2c_Opp.AddJiFen(_wid, _id, enterJiFen, _ac_Amt);
                        commonTool.Show_Have_Url(lt_result, "成功增加积分!", "B2C_memList.aspx", 0);
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            else
            {
                lt_result.Text = "无法获取到会员信息!";
            }
        }

        /// <summary>
        /// 减少积分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Reduce_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                int _wid = Convert.ToInt32(Session["wid"]);
                int _id = Convert.ToInt32(Request["id"].ToString());
                if (JiFen_Count.Value == "")
                {
                    lt_result.Text = "请输入交易金额!";
                    return;
                }
                else if (!IsNumber(JiFen_Count.Value) || (IsNumber(JiFen_Count.Value) && Convert.ToDouble(JiFen_Count.Value) <= 0))
                {
                    lt_result.Text = "消费积分必须为大于0的数字!";
                    return;
                }
                else   //减少积分
                {
                    try
                    {
                        Convert.ToInt32(JiFen_Count.Value);
                    }
                    catch
                    {
                        lt_result.Text = "减少积分必须为整数!";
                        return;
                    }
                    try
                    {
                        double _ac_Amt = 0;//记录余额
                        string _yueSql = "top 1 *";
                        string _yueWhere = string.Format(" ptid=1 and uid={0} order by id desc", _id);//查询对应会员的积分数
                        DataTable yue_dt = B2C_AccOperate.GetList(_yueSql, _yueWhere);
                        if (yue_dt.Rows.Count > 0)
                            _ac_Amt = Convert.ToDouble(yue_dt.Rows[0]["ac_Amt"].ToString());//账户当前的积分数
                        double enterJiFen = Convert.ToDouble(JiFen_Count.Value);
                        if (enterJiFen <= _ac_Amt)
                        {
                            _ac_Amt -= enterJiFen;
                            B2C_AccOperate b2c_Opp = new B2C_AccOperate();
                            b2c_Opp.ReduJiFen(_wid, _id, enterJiFen, _ac_Amt);
                            commonTool.Show_Have_Url(lt_result, "成功扣除积分!", "B2C_memList.aspx", 0);

                        }
                        else
                        {
                            lt_result.Text = "积分不足!";
                        }
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                    }
                }
            }
            else
            {
                lt_result.Text = "无法获取到会员信息!";
            }
        }
    }
}