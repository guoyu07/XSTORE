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
    public partial class MoneyChange : workAuth
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
        /// 充值金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                int _wid = Convert.ToInt32(Session["wid"]);
                int _id = Convert.ToInt32(Request["id"].ToString());
                if (Money_Count.Value == "")
                {
                    lt_result.Text = "请输入交易金额!";
                    return;
                }
                else if (!IsNumber(Money_Count.Value) || (IsNumber(Money_Count.Value) && Convert.ToDouble(Money_Count.Value) <= 0))
                {
                    lt_result.Text = "充值金额必须为大于0的数字!";
                    return;
                }
                else   //充值金额
                {
                    try
                    {
                        double enterMoney = Convert.ToDouble(Money_Count.Value);
                        if (B2C_AccOperate.AddMoney(_wid, _id, enterMoney))
                        {
                            commonTool.Show_Have_Url(lt_result, "操作成功！", "B2C_memList.aspx", 0);
                        }
                        else
                        {
                            commonTool.Show_Have_Url(lt_result, "操作发生异常,增加金额失败！", "B2C_memList.aspx", 0);
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

        /// <summary>
        /// 消费金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Reduce_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                int _wid = Convert.ToInt32(Session["wid"]);
                int _id = Convert.ToInt32(Request["id"].ToString());
                if (Money_Count.Value == "")
                {
                    lt_result.Text = "请输入交易金额!";
                    return;
                }
                else if (!IsNumber(Money_Count.Value) || (IsNumber(Money_Count.Value) && Convert.ToDouble(Money_Count.Value) <= 0))
                {
                    lt_result.Text = "消费金额必须为大于0的数字!";
                    return;
                }
                else   //消费金额
                {
                    try
                    {
                        double reduceMoney = Convert.ToDouble(Money_Count.Value);
                        if (B2C_AccOperate.ReduceMoney(_wid, _id, reduceMoney))
                            commonTool.Show_Have_Url(lt_result, "操作成功！", "B2C_memList.aspx", 0);
                        else
                            commonTool.Show_Have_Url(lt_result, "操作失败,余额不足或操作发生异常！", "B2C_memList.aspx", 0);

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