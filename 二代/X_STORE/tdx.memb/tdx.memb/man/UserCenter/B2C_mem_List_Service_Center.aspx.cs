using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common;
using Creatrue.kernel;
using tdx.database;
using tdx.database.database;

namespace tdx.memb.man.UserCenter
{
    public partial class B2C_mem_List_Service_Center : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dzd = " *,(select Mvip_name from B2C_memvip where B2C_memvip.Mvip_id=B2C_mem.M_vip)as mname,(select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=1 order by id desc) as amt,(select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=2 order by id desc) as amt2 ";
                dzd += ",isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=3 order by id desc),0) as M_dongjie";
                dzd += ",(select m_truename from b2c_mem as m1 where m1.id = b2c_mem.parentID) as parentName";
                dzd += ",(select m_truename from b2c_mem as m2 where m2.id = b2c_mem.jieshaoID) as jieshaoName";
                dzd += ",(select real_name from dt_manager where dt_manager.id=b2c_mem.cityID) as cityName";
                string sql = "(1=1) and M_isactive=0 and m_isdel=0";
                string tname = " B2C_mem ";
                lb_prolist.Text = prolist(dzd, tname, sql, 1);
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_mem where " + sql).Rows[0][0]);
                lt_pagearrow.Text = commonTool.F_pagearrow(_page, totalcount);

                //绑定初始化
                bind();
            }
        }

        private void bind()
        {
            string sql2 = "select id ,real_name from dt_manager where role_id=5 order by id";
            DataTable dt2 = comfun.GetDataTableBySQL(sql2);
            ss_cityID.DataSource = dt2.DefaultView;
            ss_cityID.DataTextField = "real_name";
            ss_cityID.DataValueField = "id";
            ss_cityID.DataBind();
            ss_cityID.Items.Insert(0, new ListItem("全部", "0"));
        }

        private string prolist(string _dzd, string _tname, string _sql, int _page)
        {
            string active = "";
            string del = "";
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f3f3f3"">";
            str += @"           <td align=center   class=""tablehead"">选择</td>";
            str += @"          <td align=center >会员编号</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">会员等级</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">登陆名<br />真实姓名</td>";
            str += @"          <td height=""25"" align=center class=""tablehead"">性别</td>";
            //str += @"          <td height=""25"" align=center class=""tablehead"">开户行</td>";
            str += @"          <td align=center class=""tablehead"">状态</td>";
            str += @"          <td align=center class=""tablehead"">注册日期<br />登录次数</td>";
            str += @"          <td align=center class=""tablehead"">上级</td>";
            //str += @"          <td align=center class=""tablehead"">介绍人</td>";
            //str += @"          <td height=""25"" align=center class=""tablehead"">星级</td>";
            //str += @"          <td height=""25"" align=center class=""tablehead"">物流中心</td>";
            str += @"          <td align=center  class=""tablehead"">修改</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = B2C_mem.GetList(currentpage, _dzd, _tname, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input  style=""clear:both; width:20px;"" Class=""checkall""  type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center >" + dr["M_no"] + "</td>";
                str += @"          <td align=center height=24>" + dr["mname"] + "</td>";
                str += @"          <td align=center height=24>" + dr["M_name"] + "<br />" + dr["M_truename"] + "</td>";
                str += @"          <td align=center>" + dr["M_sex"] + "</td>";
                //str += @"          <td align=center height=24>" + dr["M_bank"] + "<br />" + dr["M_card"] + "</td>";
                active = Convert.ToInt32(dr["M_isactive"]) == 1 ? "生效" : "未生效";
                del = Convert.ToInt32(dr["M_isdel"]) == 0 ? "未删除" : "已删除";
                str += @"          <td align=center>" + active + "/" + del + "</td>";
                str += @"          <td align=center>" + dr["M_regtime"] + "<br />" + dr["M_hits"] + "</td>";
                str += @"          <td align=center>" + dr["parentName"] + "</td>";
                //str += @"          <td align=center>" + dr["jieshaoName"] + "</td>";
                //str += @"          <td align=center>" + dr["M_star"] + "</td>";
                //str += @"          <td align=center>" + dr["cityName"] + "</td>";
                str += @"          <td align=center> <a href='B2C_mem_Add_Service_Center.aspx?id=" + dr["id"] + "&M_isactive=0 '>修改</a></td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }
        #region  功能按钮
        /// <summary>
        /// 假删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    string id = _id;
                    try
                    {
                        B2C_mem.setDel(id);
                        Response.Write("<script language='javascript'>alert('设置删除成功！');location.href='B2C_mem_List_Service_center.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('设置删除失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }

        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbtnstar_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    string id = _id;
                    try
                    {
                        B2C_mem.setActive2(id);
                        ////给钱
                        //B2C_mem bc = new B2C_mem(Convert.ToInt32(id));
                        //B2C_Account ba = new B2C_Account();
                        //appsConfig apps = new appsConfig();
                        //apps.init();

                        //ba.AddNew();
                        //ba.mid = bc.jieshaoID;
                        //ba.ptid = 3;
                        //ba.cno = "008";
                        //ba.ac_money = apps.GetGPrice(bc.M_vip) * apps._zhekou;
                        ////计算销售提成

                        //ba.ac_des = bc.M_truename + "的销售提成";
                        //ba.Update();

                        //B2C_Account2 ba2 = new B2C_Account2();
                        //ba2.AddNew();
                        //ba2.mid = bc.cityID;
                        //ba2.ptid = 3;
                        //ba2.cno = "009";
                        //ba2.ac_money = apps.GetGPrice(bc.M_vip) * apps._wuliuZhekou;

                        //ba2.ac_des = bc.M_truename + "的物流提成";

                        //ba2.Update();

                        ////计算点位奖
                        //handle_xiaoshouButie(bc.ParentID);

                        ////计算同层管理奖
                        //handle_tongcengguanli(bc.ParentID, 0);

                        Response.Write("<script language='javascript'>alert('审核通过成功！');location.href='B2C_mem_List_Service_center.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('审核通过失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }

        //审核不通过
        protected void lkbtnstar2_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                string _sql = "update b2c_mem set m_isactive=-1 where id in(" + delid + ")";
                try
                {
                    comfun.UpdateBySQL(_sql);
                    Response.Write("<script language='javascript'>alert('审核不通过成功！');location.href='B2C_mem_List_Service_center.aspx';</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('审核不通过失败！');history.go(-1);</script>");
                }

            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要设置的行！');history.go(-1);</script>");
            }
        }

        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    int id = Convert.ToInt32(_id);
                    try
                    {
                        B2C_mem.myDel(id);
                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='B2C_mem_List_Service_Center.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('彻底删除失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要彻底删除的行！');history.go(-1);</script>");
            }
        }

        #endregion

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            string keyword = ss_keyword.Text.Trim();
            string cno = "";
            if (ss_cid.Value == "0")
            {
                cno = "M_mobile";
            }
            else if (ss_cid.Value == "1")
            {
                cno = "M_truename";
            }
            string _cityID = ss_cityID.Value.Trim();

            string sql = "1=1 and m_isactive=-2  and m_isdel=0";
            if (keyword != "")
                sql += " and " + cno + " like '%" + keyword + "%'";
            if (_cityID != "" && _cityID != "0")
                sql += " and cityID = " + _cityID;

            string dzd = " *,(select Mvip_name from B2C_memvip where B2C_memvip.Mvip_id=B2C_mem.M_vip)as mname";
            dzd += ",(select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=1 order by id desc) as amt,(select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=2 order by id desc) as amt2 ";
            dzd += ",isnull((select top 1 ac_amt from b2c_account where mid=b2c_mem.id and ptid=3 order by id desc),0) as M_dongjie";
            dzd += ",(select m_truename from b2c_mem as m1 where m1.id = b2c_mem.parentID) as parentName";
            dzd += ",(select m_truename from b2c_mem as m2 where m2.id = b2c_mem.jieshaoID) as jieshaoName";
            dzd += ",(select real_name from dt_manager where dt_manager.id=b2c_mem.cityID) as cityName";
            string tname = " B2C_mem ";

            lb_prolist.Text = prolist(dzd, tname, sql, Convert.ToInt32(Request["page"]));//

            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_mem where " + sql).Rows[0][0]);
            lt_pagearrow.Text = commonTool.F_pagearrow(Convert.ToInt32(Request["page"]), totalcount);
        }

        #region "处理销售补贴"
        //protected void handle_xiaoshouButie(int _mid)
        //{
        //    B2C_mem bc = new B2C_mem(_mid);
        //    appsConfig apps = new appsConfig();
        //    apps.init();

        //    //计算是否达到最高佣金
        //    DataTable dt = comfun.GetDataTableBySQL("select isnull(sum(ac_money),0) from b2c_account where cno='011' and mid=" + _mid.ToString());


        //    if (dt.Rows.Count > 0)
        //    {
        //        double _xiane = apps._xiaoshouButie_xiane;
        //        if (bc.M_vip > 1) _xiane = apps._xiaoshouButie_xiane2;
        //        if (double.Parse(dt.Rows[0][0].ToString()) < _xiane)
        //        {
        //            //可以执行
        //            B2C_Account ba2 = new B2C_Account();
        //            ba2.AddNew();
        //            ba2.mid = _mid;
        //            ba2.ptid = 3;
        //            ba2.cno = "011";
        //            ba2.ac_money = apps.GetGPrice(bc.M_vip) * apps._xiaoshouButie;
        //            ba2.ac_des = bc.M_truename + "的销售补贴";

        //            ba2.Update();
        //        }
        //    }
        //    else //可以执行
        //    {
        //        B2C_Account ba2 = new B2C_Account();
        //        ba2.AddNew();
        //        ba2.mid = _mid;
        //        ba2.ptid = 3;
        //        ba2.cno = "011";
        //        ba2.ac_money = apps.GetGPrice(bc.M_vip) * apps._xiaoshouButie;
        //        ba2.ac_des = bc.M_truename + "的销售补贴";

        //        ba2.Update();
        //    }

        //    if (bc.ParentID > 0)
        //    {
        //        handle_xiaoshouButie(bc.ParentID);
        //    }
        //}

        //protected void handle_tongcengguanli(int _mid, int _star)
        //{
        //    string _sql = "";
        //    B2C_mem bc = new B2C_mem(_mid);
        //    appsConfig apps = new appsConfig();
        //    apps.init();

        //    //通过会员编号来解决
        //    if (_star < 1) //第一层的人
        //    {
        //        _sql = "select * from b2c_mem where parentID=" + _mid.ToString() + " and m_isactive=1 and m_isdel=0 order by id desc";
        //        _sql += ";select * from b2c_account where mid=" + _mid.ToString() + " and cno='012' and orderNo='" + _star.ToString() + "'";//同层管理奖
        //        DataSet ds = comfun.GetDataSetBySQL(_sql);

        //        double _total = 0; //总获得同层管理奖
        //        foreach (DataRow dr in ds.Tables[1].Rows)
        //        {
        //            _total += Convert.ToDouble(dr["ac_money"].ToString().Trim());
        //        }
        //        int _GoldCount = 0;//总获得奖金会员数量
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            if (Convert.ToInt32(dr["m_vip"].ToString()) == 2)
        //                _GoldCount++;
        //        }

        //        if (ds.Tables[0].Rows.Count > 2) //三个
        //        {
        //            if (ds.Tables[1].Rows.Count > 1 || _total >= apps._xiaoshouLevel_max)
        //            {
        //                ;//已经有两笔了或已经达到1500，则忽略，不再享受。
        //            }
        //            else
        //            {
        //                B2C_Account ba2 = new B2C_Account();
        //                ba2.AddNew();
        //                ba2.mid = _mid;
        //                ba2.ptid = 3;
        //                ba2.cno = "012";
        //                ba2.orderNo = _star.ToString();
        //                ba2.ac_des = bc.M_truename + "的第一层同层管理奖";

        //                //2016-03-04修改
        //                //如果老三是银，则只能获得500；
        //                //如果老三是金，则要观察前面的：前面的是俩金或俩银，都是500；前面是一金一银，则是1000
        //                if (Convert.ToInt32(ds.Tables[0].Rows[0]["m_vip"].ToString()) == 1)
        //                {
        //                    ba2.ac_money = apps._xiaoshouLevel;
        //                }
        //                else
        //                {
        //                    if (Convert.ToInt32(ds.Tables[0].Rows[1]["m_vip"].ToString()) == Convert.ToInt32(ds.Tables[0].Rows[2]["m_vip"].ToString())) //俩金或俩银
        //                    {
        //                        ba2.ac_money = apps._xiaoshouLevel;
        //                    }
        //                    else
        //                    {
        //                        ba2.ac_money = apps._xiaoshouLevel2;
        //                    }
        //                }
        //                //以下老的方法不再使用，使用上面新的方法
        //                //if (_total >= apps._xiaoshouLevel2) //只有一笔，并且是1000,则只能获得500
        //                //{
        //                //    ba2.ac_money = apps._xiaoshouLevel;
        //                //}
        //                //else //只有一笔，并且是500，则需要判断是否有2金，有两金是1000，否则是500
        //                //{
        //                //    if (_GoldCount > 1)
        //                //        ba2.ac_money = apps._xiaoshouLevel2;
        //                //    else
        //                //        ba2.ac_money = apps._xiaoshouLevel;
        //                //}
        //                ba2.Update();
        //            }
        //        }
        //        else if (ds.Tables[0].Rows.Count > 1) //两个
        //        {
        //            if (ds.Tables[1].Rows.Count <= 0)//也有2个，并且还没有收到奖金,则
        //            {
        //                B2C_Account ba2 = new B2C_Account();
        //                ba2.AddNew();
        //                ba2.mid = _mid;
        //                ba2.ptid = 3;
        //                ba2.cno = "012";
        //                ba2.orderNo = _star.ToString();
        //                ba2.ac_des = bc.M_truename + "的第一层同层管理奖";

        //                if (_GoldCount > 1)
        //                    ba2.ac_money = apps._xiaoshouLevel2;
        //                else
        //                    ba2.ac_money = apps._xiaoshouLevel;

        //                ba2.Update();
        //            }
        //        }
        //    }
        //    else //超过第一层的人的奖金计算:计算本层级三条线的数量。以及获得本层级的同层管理奖的数量
        //    {
        //        _sql = "select * from b2c_mem where m_no like '" + bc.M_no + "1%' and m_level = " + (bc.M_leve + _star + 1) + "  and m_isactive=1 and m_isdel=0 order by id";
        //        _sql += ";\r\n " + "select * from b2c_mem where m_no like '" + bc.M_no + "2%' and m_level = " + (bc.M_leve + _star + 1) + " and m_isactive=1 and m_isdel=0  order by id";
        //        _sql += ";\r\n " + "select * from b2c_mem where m_no like '" + bc.M_no + "3%' and m_level = " + (bc.M_leve + _star + 1) + " and m_isactive=1 and m_isdel=0  order by id";
        //        _sql += ";select * from b2c_account where mid=" + _mid.ToString() + " and cno='012' and orderNo='" + _star.ToString() + "'";//同层管理奖
        //        DataSet ds = comfun.GetDataSetBySQL(_sql);

        //        double _total = 0; //总获得同层管理奖
        //        foreach (DataRow dr in ds.Tables[3].Rows)
        //        {
        //            _total += Convert.ToDouble(dr["ac_money"].ToString().Trim());
        //        }
        //        if (_total >= apps._xiaoshouLevel_max || ds.Tables[3].Rows.Count > 1)//本层级的同层管理奖已经达到最大，则没有任何操作。
        //        { }
        //        else
        //        {
        //            #region "计算每条线金会员的数量”
        //            int _GoldNum1 = 0, _honorNum1 = ds.Tables[0].Rows.Count;
        //            int _GoldNum2 = 0, _honorNum2 = ds.Tables[1].Rows.Count;
        //            int _GoldNum3 = 0, _honorNum3 = ds.Tables[2].Rows.Count;
        //            int _GoldNum = 0;
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                if (Convert.ToInt32(dr["m_vip"].ToString()) == 2)
        //                {
        //                    _GoldNum1 = 1;
        //                    break;
        //                }
        //            }
        //            foreach (DataRow dr in ds.Tables[1].Rows)
        //            {
        //                if (Convert.ToInt32(dr["m_vip"].ToString()) == 2)
        //                {
        //                    _GoldNum2 = 1;
        //                    break;
        //                }
        //            }
        //            foreach (DataRow dr in ds.Tables[2].Rows)
        //            {
        //                if (Convert.ToInt32(dr["m_vip"].ToString()) == 2)
        //                {
        //                    _GoldNum3 = 1;
        //                    break;
        //                }
        //            }
        //            _GoldNum = _GoldNum1 + _GoldNum2 + _GoldNum3;
        //            #endregion

        //            int _Num_xian = 0;//有几条线
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if (ds.Tables[i].Rows.Count > 0)
        //                    _Num_xian++;
        //            }
        //            switch (_Num_xian)
        //            {
        //                case 0://没有任何线
        //                    return; // 直接跳出程序.也不会上推了，反正都没有。
        //                case 1: //只有一条腿，不给奖
        //                    break;
        //                case 2:
        //                    #region "2条线"
        //                    if (ds.Tables[3].Rows.Count > 0)
        //                    {
        //                        break; //已经获得过奖,跳出
        //                    }
        //                    else //还没有获得奖
        //                    {
        //                        //那条线只有1个，看其实金还是银。
        //                        //如果两条线都大约1 ，则无效（老用户）
        //                        int _honor = 0;
        //                        if (_honorNum1 > 1) _honor++;
        //                        if (_honorNum2 > 1) _honor++;
        //                        if (_honorNum3 > 1) _honor++;
        //                        if (_honor > 1) break; //排除掉老用户

        //                        //接下来，看那条线只有1个用户，其用户是金or银
        //                        B2C_Account ba2 = new B2C_Account();
        //                        ba2.AddNew();
        //                        ba2.mid = _mid;
        //                        ba2.ptid = 3;
        //                        ba2.cno = "012";
        //                        ba2.orderNo = _star.ToString();
        //                        ba2.ac_des = bc.M_truename + "的第" + (_star + 1).ToString() + "层同层管理奖";

        //                        //if (_GoldNum > 1)
        //                        //{
        //                        //    ba2.ac_money = apps._xiaoshouLevel2;
        //                        //}
        //                        //else
        //                        //{
        //                        //    ba2.ac_money = apps._xiaoshouLevel;
        //                        //}
        //                        if (_honorNum1 == 1)
        //                        {
        //                            if (_GoldNum1 > 0)
        //                            {
        //                                ba2.ac_money = apps._xiaoshouLevel2;
        //                            }
        //                            else
        //                            {
        //                                ba2.ac_money = apps._xiaoshouLevel;
        //                            }
        //                        }
        //                        else if (_honorNum2 == 1)
        //                        {
        //                            if (_GoldNum2 > 0)
        //                            {
        //                                ba2.ac_money = apps._xiaoshouLevel2;
        //                            }
        //                            else
        //                            {
        //                                ba2.ac_money = apps._xiaoshouLevel;
        //                            }
        //                        }
        //                        else if (_honorNum3 == 1)
        //                        {
        //                            if (_GoldNum3 > 0)
        //                            {
        //                                ba2.ac_money = apps._xiaoshouLevel2;
        //                            }
        //                            else
        //                            {
        //                                ba2.ac_money = apps._xiaoshouLevel;
        //                            }
        //                        }
        //                        //else
        //                        //    ba2.ac_money = apps._xiaoshouLevel;
        //                        //没有一个线只有一个用户，表示所有的 线都大于1个用户；表示已经获得过奖。
        //                        ba2.Update();
        //                    }
        //                    #endregion
        //                    break;
        //                case 3:
        //                    #region "3条线"
        //                    //那条线只有1个，看其实金还是银。
        //                    //如果三条线都大约1 ，则无效（老用户）
        //                    int _honor2 = 0;
        //                    if (_honorNum1 > 1) _honor2++;
        //                    if (_honorNum2 > 1) _honor2++;
        //                    if (_honorNum3 > 1) _honor2++;
        //                    if (_honor2 > 2) break; //排除掉老用户
        //                    if (ds.Tables[3].Rows.Count > 1) //已经拿过两次的也排除掉
        //                        break;
        //                    else
        //                    {
        //                        B2C_Account ba2 = new B2C_Account();
        //                        ba2.AddNew();
        //                        ba2.mid = _mid;
        //                        ba2.ptid = 3;
        //                        ba2.cno = "012";
        //                        ba2.orderNo = _star.ToString();
        //                        ba2.ac_des = bc.M_truename + "的第" + (_star + 1).ToString() + "层同层管理奖";

        //                        //如果c路是银的话，直接给500，如果c路是金的话，还要看前面的情况
        //                        int _flag = -1;
        //                        if (_honorNum1 == 1)
        //                        {
        //                            if (_GoldNum1 > 0)
        //                            {
        //                                _flag = 1;
        //                            }
        //                            else
        //                                _flag = 0;
        //                        }
        //                        else if (_honorNum2 == 1)
        //                        {
        //                            if (_GoldNum2 > 0)
        //                            {
        //                                _flag = 1;
        //                            }
        //                            else
        //                                _flag = 0;
        //                        }
        //                        else if (_honorNum3 == 1)
        //                        {
        //                            if (_GoldNum3 > 0)
        //                            {
        //                                _flag = 1;
        //                            }
        //                            else
        //                                _flag = 0;
        //                        }
        //                        if (_flag == 0)
        //                        {
        //                            ba2.ac_money = apps._xiaoshouLevel;
        //                        }
        //                        else if (_flag == 1)
        //                        {
        //                            double _xiaoshouLevel_haved = 0;
        //                            if (ds.Tables[3].Rows.Count > 0)
        //                                _xiaoshouLevel_haved = Convert.ToDouble(ds.Tables[3].Rows[0]["ac_money"].ToString().Trim());
        //                            ba2.ac_money = apps._xiaoshouLevel_max - _xiaoshouLevel_haved;
        //                        }
        //                        if (ba2.ac_money > 1000)
        //                            ba2.ac_money = 1000;

        //                        ba2.Update();
        //                        break;
        //                    }
        //                    #endregion

        //            }

        //        }


        //    }

        //    //继续往上推，只到父亲为0
        //    if (bc.ParentID > 0)
        //    {
        //        handle_tongcengguanli(bc.ParentID, _star + 1);
        //    }
        //}

        #endregion
    }
}