using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.vipmemb
{
    public partial class B2C_memList : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 查询您所有的会员信息。";
                    int _wid = Convert.ToInt32(Session["wid"]);
                    string _sql = "*";
                    //string _where = string.Format(" cityID={0}", _wid);
                    DataTable dt = B2C_mem.GetList(1, _sql, "B2C_mem", "");
                    string result1 = "";
                    if (dt.Rows.Count > 0)
                    {
                        result1 += "\r\n";
                        result1 += " \r\n <table>";
                        result1 += "\r\n <tr>";
                        result1 += "\r\n<th ><input type=checkbox  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
                        result1 += "\r\n <th >用户名</th> ";
                        result1 += "\r\n <th >会员等级</th> ";
                        result1 += "\r\n <th >手机</th> ";
                        result1 += "\r\n <th >余额</th> ";
                        result1 += "\r\n <th >积分</th> ";
                        result1 += "\r\n <th>修改密码</th> ";
                        result1 += "\r\n <th>金额调节</th> ";
                        result1 += "\r\n <th>积分调节</th> ";
                        result1 += "\r\n <th>积分日志</th> ";
                        result1 += "\r\n <th>钱包日志</th> ";
                        result1 += "\r\n <th>日志记录</th> ";
                        result1 += " \r\n <th>修改</th> ";
                        result1 += " \r\n </tr>";
                        B2C_AccOperate b2c_acc = new B2C_AccOperate();
                        foreach (DataRow dr in dt.Rows)
                        {
                            int _id = Convert.ToInt32(dr["id"].ToString());
                            result1 += " \r\n <tr>";
                            result1 += " \r\n <td > <input name=\"delbox\" value=\"" + dr["id"].ToString() + "\" type=\"checkbox\"></td> ";
                            result1 += " \r\n <td >" + dr["M_name"].ToString() + "</td> ";
                            result1 += " \r\n <td>" + B2C_rankinfo.RankinfoName(_id).ToString() + "</td> ";
                            result1 += " \r\n  <td>" + dr["M_mobile"].ToString() + "</td> ";
                            result1 += b2c_acc.GetMoney(_wid, _id);
                            result1 += b2c_acc.GetJiFen(_wid, _id);
                            result1 += " \r\n<td><a href=\"" + "Edit_PassWord.aspx?id=" + dr["id"].ToString() + "\">修改密码</a></td>";
                            result1 += " \r\n<td ><a href=\"" + "MoneyChange.aspx?id=" + dr["id"].ToString() + "\">金额调整</a></td>";
                            result1 += " \r\n<td><a href=\"" + "JiFen_Change.aspx?id=" + dr["id"].ToString() + "\">积分调整</a></td>";
                            result1 += " \r\n<td><a href=\"" + "JiFen_log.aspx?id=" + dr["id"].ToString() + "\">查看积分日志</a></td>";
                            result1 += " \r\n<td><a href=\"" + "Money_log.aspx?id=" + dr["id"].ToString() + "\">查看钱包日志</a></td>";
                            result1 += " \r\n<td><a href=\"" + "Check_C2C_Log.aspx?id=" + dr["id"].ToString() + "\">查看日志</a></td>";
                            result1 += " \r\n<td><a href=\"" + "B2C_memEdit.aspx?id=" + dr["id"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                            result1 += " \r\n </tr>";
                        }
                        result1 += " \r\n </table>";
                        ylList.Text = result1;
                    }

                    InitVipCard();
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/B2C_memList.cs", Session["wID"].ToString());
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void delBtn_Click(object sender, EventArgs e)
        {
            if (Request["delbox"] != null)
            {
                if (Request["delbox"].ToString() != "")
                {
                    try
                    {
                        string _delStr = Request["delbox"].ToString();
                        string[] sets = _delStr.Split(',');

                        foreach (string _id in sets)
                        {
                            string _sql = "select * from B2C_mem where id=" + _id;
                            DataTable dt = comfun.GetDataTableBySQL(_sql);
                            string _name = dt.Rows[0]["M_name"].ToString();
                            string _del = "delete from B2C_mem where id=" + _id;
                            if (B2C_AccOperate.JiFenHave(Convert.ToInt32(Session["wID"].ToString()), Convert.ToInt32(_id)) > 0 || B2C_AccOperate.JiFenHave(Convert.ToInt32(Session["wID"].ToString()), Convert.ToInt32(_id)) > 0)
                            {
                                lt_result.Text += "会员" + _name + "无法删除,必须积分和金额都为0时，才可以删除！<br/>";
                            }
                            else
                            {
                                comfun.DelbySQL(_del);
                            }
                        }
                        lt_result.Text += "   操作结束<br/>";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_memList.aspx';},1000);</script>";

                    }
                    catch (Exception ex)
                    {
                        commonTool.Show_Have_Url(lt_result, "彻底删除失败！", "", 1);
                    }
                }

            }
            else
            {
                lt_result.Text = "请选择您要删除的项！";
            }
        }

        /// <summary>
        /// 初始化会员卡信息
        /// </summary>
        private void InitVipCard()
        {
            string wid = Session["wid"].ToString();
            B2C_vipcard _bv = new B2C_vipcard(wid);
            if (_bv.id == 0)
            {
                //么有会员卡信息,添加一条默认会员卡信息
                _bv.is_open = 1;
                _bv.name = "会员卡";
                _bv.pre_name = "0000";
                _bv.acc_card = 1;
                _bv.card_start = 1;
                _bv.wid = Convert.ToInt32(wid);
                _bv.create_time = DateTime.Now;
                B2C_AccountConfig _ba;
                _ba = new B2C_AccountConfig();
                _ba.wid = Convert.ToInt32(wid);
                _ba.category = 1;
                _ba.opened = 1;//添加积分配置，默认开启
                _ba.Update();
                _ba = new B2C_AccountConfig();
                _ba.wid = Convert.ToInt32(wid);
                _ba.category = 2;
                _ba.opened = 1;//添加钱包配置，默认开启
                _ba.Update();
                _bv.Update();
            }
            string _where = "cardid=" + _bv.id;
            DataTable dt = B2C_rankinfo.GetList("*", _where);
            if (dt.Rows.Count <= 0)
            {
                B2C_rankinfo _br = new B2C_rankinfo();
                _br.name = "普通会员卡";
                _br.score = 0;
                _br.overdays = 0;
                _br.des = "";
                _br.cardid = _bv.id;
                _br.create_time = DateTime.Now;
                _br.Update();
            }
        }
    }
}