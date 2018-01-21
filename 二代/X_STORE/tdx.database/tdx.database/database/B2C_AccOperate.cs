using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Creatrue.kernel;

namespace tdx.database
{
    /// <summary>
    /// 日志操作类
    /// </summary>
    public class B2C_AccOperate
    {
        public int id = 0;
        public int wid = 0;
        public int ptid = 1;
        public double ac_money = 0;
        public double ac_Amt = 0;

        public string cno = "";
        public string orderNo = "";

        public DateTime ac_update = DateTime.Now;
        public DateTime ac_regdate = DateTime.Now;

        public string ac_des = "";
        public int uid = 0;

        public B2C_AccOperate() { }
        public B2C_AccOperate(int _id)
        {
            id = _id;
            this.load();
        }


        private void load()
        {
            string sql = "select * from C2C_Account where id=" + id + "";
            if (id == 0)
            {

                throw new NotSupportedException("该记录不存在");
                //return;
            }
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("记录：" + id + "不唯一");
                }
                else
                {

                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    wid = Convert.IsDBNull(dt.Rows[0]["wid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["wid"]);
                    ptid = Convert.IsDBNull(dt.Rows[0]["ptid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ptid"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    orderNo = Convert.IsDBNull(dt.Rows[0]["orderNo"]) ? "" : Convert.ToString(dt.Rows[0]["orderNo"]);
                    ac_money = Convert.IsDBNull(dt.Rows[0]["M_question"]) ? 0 : Convert.ToDouble(dt.Rows[0]["ac_money"]);
                    ac_Amt = Convert.IsDBNull(dt.Rows[0]["M_answer"]) ? 0 : Convert.ToDouble(dt.Rows[0]["ac_Amt"]);
                    ac_update = Convert.IsDBNull(dt.Rows[0]["ac_update"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["ac_update"]);
                    ac_regdate = Convert.IsDBNull(dt.Rows[0]["ac_regdate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["ac_regdate"]);
                    uid = Convert.IsDBNull(dt.Rows[0]["uid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["uid"]);
                    ac_des = Convert.IsDBNull(dt.Rows[0]["ac_des"]) ? "" : Convert.ToString(dt.Rows[0]["ac_des"]);

                }
            }
            else
            {
                throw new NotSupportedException("B2C_mem_id：" + id + "不存在");
            }
        }

        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        public static void myInsert(int _wid, int _ptid, string _cno, double _ac_money, double _ac_Amt, string _ac_des, int _uid)
        {
            try
            {
                string sql = string.Format("insert into C2C_Account (wid,ptid,cno,orderNo,ac_money,ac_Amt,ac_update,ac_regdate,ac_des,uid) values (@wid,@ptid,@cno,'{1}',@ac_money,@ac_Amt,@ac_update,@ac_regdate,@ac_des,@uid)", "", "");
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@ptid", _ptid),
                    new SqlParameter("@cno", _cno),
                    new SqlParameter("@ac_money", _ac_money), 
                    new SqlParameter("@ac_Amt", _ac_Amt),
                    new SqlParameter("@ac_update",  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@ac_regdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@ac_des", _ac_des),
                    new SqlParameter("@uid", _uid)
                };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }


        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from C2C_Account where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        /// <summary>
        /// 获取积分
        /// </summary>
        /// <param name="_wid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetJiFen(int _wid, int _id)
        {
            string str = "";
            string _sql = " top 1 ac_Amt ";
            string _where = string.Format(" wid={0} and uid={1} and ptid=1 order by id desc", _wid, _id);
            DataTable dt = GetList(_sql, _where);
            if (dt.Rows.Count > 0)
            {
                str = " \r\n  <td align=\"center\" height=\"24\">" + Convert.ToDouble(dt.Rows[0]["ac_Amt"].ToString()).ToString("F2") + "</td> ";
            }
            else
            {
                str = " \r\n  <td align=\"center\" height=\"24\">0.00</td> ";
            }
            return str;
        }

        public static double JiFenHave(int _wid, int _id)
        {
            double jifen = 0;
            string _sql = " top 1 ac_Amt ";
            string _where = string.Format(" wid={0} and uid={1} and ptid=1 order by id desc", _wid, _id);
            DataTable dt = GetList(_sql, _where);
            if (dt.Rows.Count > 0)
            {
                jifen = Convert.ToDouble(dt.Rows[0]["ac_Amt"].ToString());
            }
            return jifen;
        }

        public static string JIFen(int _wid, int _id)
        {
            string str = "0.00";
            string _sql = " top 1 ac_Amt ";
            string _where = string.Format(" wid={0} and uid={1} and ptid=1 order by id desc", _wid, _id);
            DataTable dt = GetList(_sql, _where);
            if (dt.Rows.Count > 0)
            {
                str = Convert.ToDouble(dt.Rows[0]["ac_Amt"].ToString()).ToString("F2");
            }
            return str;
        }

        public static string Money(int _wid, int _id)
        {
            string str = "0.00";
            string _sql = " top 1 ac_Amt ";
            string _where = string.Format(" wid={0} and uid={1} and ptid=2 order by id desc", _wid, _id);
            DataTable dt = GetList(_sql, _where);
            if (dt.Rows.Count > 0)
            {
                str = Convert.ToDouble(dt.Rows[0]["ac_Amt"].ToString()).ToString("F2");
            }
            return str;
        }

        public static double MoneyHave(int _wid, int _id)
        {
            double _money = 0;
            string _sql = " top 1 ac_Amt ";
            string _where = string.Format(" wid={0} and uid={1} and ptid=2 order by id desc", _wid, _id);
            DataTable dt = GetList(_sql, _where);
            if (dt.Rows.Count > 0)
            {
                _money = Convert.ToDouble(dt.Rows[0]["ac_Amt"].ToString());
            }
            return _money;
        }

        /// <summary>
        /// 获取余额
        /// </summary>
        /// <param name="_wid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMoney(int _wid, int _id)
        {
            string str = "";
            string _sql = " top 1 ac_Amt ";
            string _where = string.Format(" wid={0} and uid={1} and ptid=2 order by id desc", _wid, _id);
            DataTable dt = GetList(_sql, _where);
            if (dt.Rows.Count > 0)
            {
                str = " \r\n  <td align=\"center\" height=\"24\">" + Convert.ToDouble(dt.Rows[0]["ac_Amt"].ToString()).ToString("F2") + "</td> ";
            }
            else
            {
                str = " \r\n  <td align=\"center\" height=\"24\">0.00</td> ";
            }
            return str;
        }
        /// <summary>
        /// 获取剩余余额
        /// </summary>
        /// <param name="_wid"></param>
        /// <param name="_id"></param>
        /// <returns></returns>
        public string GetMoney_object(int _wid, int _id)
        {
            string str = "";
            string _sql = " top 1 ac_Amt ";
            string _where = string.Format(" wid={0} and uid={1} and ptid=2 order by id desc", _wid, _id);
            DataTable dt = GetList(_sql, _where);
            if (dt.Rows.Count > 0)
            {
                str = Convert.ToDouble(dt.Rows[0]["ac_Amt"].ToString()).ToString("F2");
            }
            else
            {
                str = "0.00";
            }
            return str;
        }

        /// <summary>
        /// 充值金额
        /// </summary>
        /// <param name="_wid">关联公众号的id</param>
        /// <param name="_id">关联会员id</param>
        /// <param name="_enterMoney">充值的金额</param>
        /// <returns></returns>
        public static bool AddMoney(int _wid, int _id, double _enterMoney)
        {
            try
            {
                bool _jifen = B2C_AccountConfig.IsOpen(_wid, 1);//标识积分规则是否启用
                bool _qianbao = B2C_AccountConfig.IsOpen(_wid, 2);//标识金额规则是否启用

                bool _return = false;//标识返回值
                string _sql = "*";
                int rank_id = 0;
                string _where = string.Format(" uid={0}", _id);
                DataTable dt = B2C_user_rank.GetList(_sql, _where);

                rank_id = Convert.ToInt32(dt.Rows[0]["rankid"].ToString());
                string _time = DateTime.Now.ToString();

                DataTable _dtRank = B2C_rankinfo.GetList(" score", string.Format("id={0}", rank_id));
                int _score = Convert.ToInt32(_dtRank.Rows[0]["score"]);//当前会员对应的积分

                string _card = "select top 1 * from B2C_vipcard where wid=" + _wid.ToString();
                DataTable dt_card = comfun.GetDataTableBySQL(_card);
                int card_id = Convert.ToInt32(dt_card.Rows[0]["id"].ToString());

                _where = string.Format("score<={0} and cardid={1} order by score desc", _score, card_id);
                _dtRank = B2C_rankinfo.GetList(" id", _where);//小于等于该会员等级积分的id，即该会员可享用这些id对应的规则

                double _ac_Amt = 0;//记录余额
                string _yueSql = "top 1 *";
                string _yueWhere = string.Format(" ptid=2 and uid={0} order by id desc", _id);//查询对应会员的金额
                DataTable yue_dt = GetList(_yueSql, _yueWhere);
                if (yue_dt.Rows.Count > 0)
                    _ac_Amt = Convert.ToDouble(yue_dt.Rows[0]["ac_Amt"].ToString());//账户当前的金额
                double _ac_Amt_JiFen = 0;
                _yueWhere = string.Format(" ptid=1 and uid={0} order by id desc", _id);//查询对应会员的积分数
                yue_dt = GetList(_yueSql, _yueWhere);
                if (yue_dt.Rows.Count > 0)
                    _ac_Amt_JiFen = Convert.ToDouble(yue_dt.Rows[0]["ac_Amt"].ToString());//账户当前的积分数

                int i = 0;
                int _insertFlag = 0;//标识是否插入过充值金额
                while (i < _dtRank.Rows.Count)//遍历符合条件的等级id
                {
                    string _qianbao_where = string.Format(" wid={0} and payorcost=1 and rankid={1} and star_time<='{2}' and end_time>='{3}' order by create_time desc", _wid, Convert.ToInt32(_dtRank.Rows[i]["id"]), _time, _time);
                    dt = B2C_wallet.GetList(_sql, _qianbao_where);
                    if (dt.Rows.Count > 0)
                    {
                        DataTable fandianDT = new DataTable();
                        DataTable zhengDT = new DataTable();
                        DataView vdfan = new DataView(dt);
                        DataView vdzheng = new DataView(dt);
                        vdfan.RowFilter = " is_fandian=1";
                        vdfan.Sort = "amount desc";
                        fandianDT = vdfan.ToTable();
                        vdzheng.RowFilter = " is_fandian=0";
                        vdzheng.Sort = "amount desc";
                        zhengDT = vdzheng.ToTable();
                        int flag = 0;//标识是否使用过规则

                        double moneylevel = 0;
                        double giveAmount = 0;
                        double giveJifen = 0;
                        double jiFenLevel = 0;
                        int addFlag = 0;
                        int addJiFenFlag = 0;

                        if (fandianDT.Rows.Count > 0)//有返点
                        {
                            foreach (DataRow dr in fandianDT.Rows)
                            {
                                if (_enterMoney >= Convert.ToDouble(dr["amount"].ToString()))
                                {
                                    moneylevel = Convert.ToDouble(dr["amount"].ToString());
                                    giveAmount = Convert.ToDouble(dr["give_amount"].ToString());
                                    break;
                                }
                            }
                            if (moneylevel != 0 && _qianbao == true)
                            {
                                if (_insertFlag == 0)
                                {
                                    string des1 = string.Format("充值{0}元", _enterMoney);
                                    _ac_Amt += _enterMoney;
                                    myInsert(_wid, 2, "", _enterMoney, _ac_Amt, des1, _id);
                                    _insertFlag = 1;
                                }
                                string des2 = string.Format("充值{0}元返{1}%:{2}", _enterMoney, giveAmount, _enterMoney * (giveAmount / 100));
                                _ac_Amt += _enterMoney * (giveAmount / 100);
                                myInsert(_wid, 2, "", _enterMoney * (giveAmount / 100), _ac_Amt, des2, _id);
                                flag = 1;
                                _return = true;
                                break;
                            }
                        }
                        if (zhengDT.Rows.Count > 0)//无返点的
                        {
                            if (flag == 0)
                            {
                                string des1 = "";
                                string des2 = "";
                                int flagJifen = 0;
                                int flagMoney = 0;
                                foreach (DataRow dr in zhengDT.Rows)
                                {
                                    if (_enterMoney >= Convert.ToDouble(dr["amount"].ToString()))
                                    {
                                        if (dr["category"].ToString() == "1")
                                        {
                                            if (flagJifen == 1)
                                                continue;
                                            giveJifen = Convert.ToDouble(dr["give_amount"].ToString());
                                            addJiFenFlag = Convert.ToInt32(dr["is_add"].ToString());
                                            jiFenLevel = Convert.ToDouble(dr["amount"].ToString());
                                            flagJifen = 1;
                                        }
                                        else
                                        {
                                            if (flagMoney == 1)
                                                continue;
                                            giveAmount = Convert.ToDouble(dr["give_amount"].ToString());
                                            addFlag = Convert.ToInt32(dr["is_add"].ToString());
                                            moneylevel = Convert.ToDouble(dr["amount"].ToString());
                                            flagMoney = 1;
                                        }
                                    }
                                }
                                if (_insertFlag == 0)
                                {
                                    des2 = string.Format("充值{0}元", _enterMoney);
                                    _ac_Amt += _enterMoney;
                                    myInsert(_wid, 2, "", _enterMoney, _ac_Amt, des2, _id);
                                    _insertFlag = 1;

                                    int repJifen = 0;//标识是否执行过积分赠送
                                    int repMoney = 0;//标识是否执行过金额赠送

                                    if (jiFenLevel != 0 && _jifen)
                                    {
                                        repJifen = 1;
                                        if (addJiFenFlag == 0)
                                        {
                                            des1 = string.Format(" 充值金额满{0}元送{1}积分", jiFenLevel, giveJifen);
                                            _ac_Amt_JiFen += giveJifen;
                                            myInsert(_wid, 1, "赠送", giveJifen, _ac_Amt_JiFen, des1, _id);
                                        }
                                        else
                                        {
                                            des1 = string.Format("累加充{0}元送{1}积分", _enterMoney, ((int)(_enterMoney / jiFenLevel)) * giveJifen);
                                            _ac_Amt_JiFen += ((int)(_enterMoney / jiFenLevel)) * giveJifen;
                                            myInsert(_wid, 1, "赠送", ((int)(_enterMoney / jiFenLevel)) * giveJifen, _ac_Amt_JiFen, des1, _id);

                                        }
                                        B2C_rankinfo.Upgrade(_id, _wid);//积分增加，判断等级是否变化
                                    }
                                    if (moneylevel != 0 && _qianbao)
                                    {
                                        repMoney = 1;
                                        if (addFlag == 0)
                                        {
                                            des1 = string.Format(" 充值金额满{0}元送{1}元", moneylevel, giveAmount);
                                            _ac_Amt += giveAmount;
                                            myInsert(_wid, 2, "赠送", giveAmount, _ac_Amt, des1, _id);
                                        }
                                        else
                                        {
                                            des1 = string.Format("累加充{0}元送{1}元", _enterMoney, ((int)(_enterMoney / moneylevel)) * giveAmount);
                                            _ac_Amt += ((int)(_enterMoney / moneylevel)) * giveAmount;
                                            myInsert(_wid, 2, "赠送", ((int)(_enterMoney / moneylevel)) * giveAmount, _ac_Amt, des1, _id);
                                        }
                                    }
                                    if (repJifen == 1 || repMoney == 1)
                                    {
                                        _return = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    i++;
                }
                if (_insertFlag == 0)
                {
                    string des2 = string.Format("充值{0}元", _enterMoney);
                    _ac_Amt += _enterMoney;
                    myInsert(_wid, 2, "", _enterMoney, _ac_Amt, des2, _id);
                    _return = true;
                }
                return _return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // <summary>
        /// 增加积分
        /// </summary>
        /// <param name="_wid"></param>
        /// <param name="_id"></param>
        /// <param name="_enterJiFen"></param>
        /// <param name="_acc_amount"></param>
        /// <returns></returns>
        public bool AddJiFen(int _wid, int _id, double _enterJiFen, double _acc_amount)
        {
            try
            {
                string ac_des = string.Format("增加积分{0}", _enterJiFen);
                myInsert(_wid, 1, "", _enterJiFen, _acc_amount, ac_des, _id);
                B2C_rankinfo.Upgrade(_id, _wid);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 减少积分
        /// </summary>
        /// <param name="_wid"></param>
        /// <param name="_id"></param>
        /// <param name="_enterJiFen"></param>
        /// <param name="_acc_amount"></param>
        /// <returns></returns>
        public bool ReduJiFen(int _wid, int _id, double _enterJiFen, double _acc_amount)
        {
            try
            {
                string ac_des = string.Format("减少积分{0}", _enterJiFen);
                myInsert(_wid, 1, "", _enterJiFen * (-1), _acc_amount, ac_des, _id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 消费金额
        /// </summary>
        /// <param name="_wid"></param>
        /// <param name="_id"></param>
        /// <param name="_enterMoney"></param>
        /// <returns></returns>
        public static bool ReduceMoney(int _wid, int _id, double _enterMoney)
        {
            try
            {

                bool _jifen = B2C_AccountConfig.IsOpen(_wid, 1);//标识对应公众号的积分规则是否开启
                bool _qianbao = B2C_AccountConfig.IsOpen(_wid, 2);//标识对应公众号的金额规则是否开启


                bool _return = false;//标识返回值

                string _sql = "*";
                int rank_id = 0;//当前会员的等级id
                string _where = string.Format(" uid={0}", _id);
                DataTable dt = B2C_user_rank.GetList(_sql, _where);
                rank_id = Convert.ToInt32(dt.Rows[0]["rankid"].ToString());//当前会员的等级id

                string _time = DateTime.Now.ToString();

                DataTable _dtRank = B2C_rankinfo.GetList(" score", string.Format("id={0}", rank_id));
                int _score = Convert.ToInt32(_dtRank.Rows[0]["score"]);//当前会员对应的积分

                string _card = "select top 1 * from B2C_vipcard where wid=" + _wid.ToString();
                DataTable dt_card = comfun.GetDataTableBySQL(_card);
                int card_id =Convert.ToInt32(dt_card.Rows[0]["id"].ToString());

                _where = string.Format("score<={0} and cardid={1} order by score desc", _score, card_id);
                _dtRank = B2C_rankinfo.GetList(" id", _where);//小于等于该会员等级积分的id，即该会员可享用这些id对应的规则

                double _ac_Amt = 0;//记录余额
                string _yueSql = "top 1 *";
                string _yueWhere = string.Format(" ptid=2 and uid={0} order by id desc", _id);//查询对应会员的金额
                DataTable yue_dt = GetList(_yueSql, _yueWhere);
                if (yue_dt.Rows.Count > 0)
                    _ac_Amt = Convert.ToDouble(yue_dt.Rows[0]["ac_Amt"].ToString());//账户当前的金额
                double _ac_Amt_JiFen = 0;
                _yueWhere = string.Format(" ptid=1 and uid={0} order by id desc", _id);//查询对应会员的积分数
                yue_dt = GetList(_yueSql, _yueWhere);
                if (yue_dt.Rows.Count > 0)
                    _ac_Amt_JiFen = Convert.ToDouble(yue_dt.Rows[0]["ac_Amt"].ToString());//账户当前的积分数

                int i = 0;
                int _insertFlag = 0;//标识是否插入消费数据
                while (i < _dtRank.Rows.Count)//依次遍历符合条件的等级id对应的规则
                {

                    string _qianbao_where = string.Format(" wid={0} and payorcost=-1 and star_time<='{1}' and end_time>='{2}' and rankid={3} order by create_time desc", _wid, _time, _time, Convert.ToInt32(_dtRank.Rows[i]["id"].ToString()));
                    dt = B2C_wallet.GetList(_sql, _qianbao_where);
                    if (dt.Rows.Count > 0)
                    {
                        DataTable fandianDT = new DataTable();//返点规则表
                        DataTable zhengDT = new DataTable();//不返点
                        DataView vdfan = new DataView(dt);
                        DataView vdzheng = new DataView(dt);
                        vdfan.RowFilter = " is_fandian=1";
                        vdfan.Sort = "amount desc";
                        fandianDT = vdfan.ToTable();//筛选出返点
                        vdzheng.RowFilter = " is_fandian=0";
                        vdzheng.Sort = "amount desc";
                        zhengDT = vdzheng.ToTable();//筛选出不返点
                        int flag = 0;//标识是否使用过规则

                        double moneylevel = 0;
                        double giveAmount = 0;
                        double giveJifen = 0;
                        double jiFenLevel = 0;
                        int addFlag = 0;
                        int addJiFenFlag = 0;

                        if (fandianDT.Rows.Count > 0)//存在返点
                        {
                            foreach (DataRow dr in fandianDT.Rows)
                            {
                                if (_enterMoney >= Convert.ToDouble(dr["amount"].ToString()))
                                {
                                    moneylevel = Convert.ToDouble(dr["amount"].ToString());
                                    giveAmount = Convert.ToDouble(dr["give_amount"].ToString());
                                    break;
                                }
                            }

                            if (moneylevel != 0 && _qianbao)
                            {
                                if (_insertFlag == 0)
                                {
                                    string des1 = string.Format("消费{0}元", _enterMoney);
                                    _ac_Amt -= _enterMoney;
                                    myInsert(_wid, 2, "", _enterMoney * (-1), _ac_Amt, des1, _id);

                                    string des2 = string.Format("消费{0}元返{1}%:{2}", _enterMoney, giveAmount, _enterMoney * (giveAmount / 100));
                                    _ac_Amt += _enterMoney * (giveAmount / 100);
                                    myInsert(_wid, 2, "", _enterMoney * (giveAmount / 100), _ac_Amt, des2, _id);
                                    flag = 1;

                                    _insertFlag = 1;
                                    _return = true;
                                    break;//执行过，跳出while
                                }
                            }

                        }
                        if (zhengDT.Rows.Count > 0)//存在不返点的规则
                        {
                            if (flag == 0)
                            {
                                string des1 = "";
                                string des2 = "";
                                int flagJifen = 0;
                                int flagMoney = 0;
                                foreach (DataRow dr in zhengDT.Rows)
                                {
                                    if (_enterMoney >= Convert.ToDouble(dr["amount"].ToString()))
                                    {
                                        if (dr["category"].ToString() == "1")
                                        {
                                            if (flagJifen == 1)
                                                continue;
                                            giveJifen = Convert.ToDouble(dr["give_amount"].ToString());
                                            addJiFenFlag = Convert.ToInt32(dr["is_add"].ToString());
                                            jiFenLevel = Convert.ToDouble(dr["amount"].ToString());
                                            flagJifen = 1;
                                        }
                                        else
                                        {
                                            if (flagMoney == 1)
                                                continue;
                                            giveAmount = Convert.ToDouble(dr["give_amount"].ToString());
                                            addFlag = Convert.ToInt32(dr["is_add"].ToString());
                                            moneylevel = Convert.ToDouble(dr["amount"].ToString());
                                            flagMoney = 1;
                                        }
                                    }
                                }
                                if (_insertFlag == 0)
                                {
                                    des2 = string.Format("消费{0}元", _enterMoney);
                                    _ac_Amt -= _enterMoney;
                                    myInsert(_wid, 2, "", _enterMoney * (-1), _ac_Amt, des2, _id);

                                    _return = true;
                                    _insertFlag = 1;

                                    int repJifen = 0;//标识是否执行过积分赠送
                                    int repMoney = 0;//标识是否执行过金额赠送

                                    if (jiFenLevel != 0 && _jifen)//送积分
                                    {
                                        repJifen = 1;
                                        if (addJiFenFlag == 0)
                                        {
                                            des1 = string.Format(" 消费金额满{0}元送{1}积分", jiFenLevel, giveJifen);
                                            _ac_Amt_JiFen += giveJifen;
                                            myInsert(_wid, 1, "赠送", giveJifen, _ac_Amt_JiFen, des1, _id);
                                        }
                                        else
                                        {
                                            des1 = string.Format("累加消费{0}元送{1}积分", _enterMoney, ((int)(_enterMoney / jiFenLevel)) * giveJifen);
                                            _ac_Amt_JiFen += ((int)(_enterMoney / jiFenLevel)) * giveJifen;
                                            myInsert(_wid, 1, "赠送", ((int)(_enterMoney / jiFenLevel)) * giveJifen, _ac_Amt_JiFen, des1, _id);
                                        }
                                        B2C_rankinfo.Upgrade(_id, _wid);
                                    }

                                    if (moneylevel != 0 && _qianbao)//送金额
                                    {
                                        repMoney = 1;
                                        if (addFlag == 0)
                                        {
                                            des1 = string.Format(" 消费金额满{0}元送{1}元", moneylevel, giveAmount);
                                            _ac_Amt += giveAmount;
                                            myInsert(_wid, 2, "赠送", giveAmount, _ac_Amt, des1, _id);
                                        }
                                        else
                                        {
                                            des1 = string.Format("累加消费{0}元送{1}元", _enterMoney, ((int)(_enterMoney / moneylevel)) * giveAmount);
                                            _ac_Amt += ((int)(_enterMoney / moneylevel)) * giveAmount;
                                            myInsert(_wid, 2, "赠送", ((int)(_enterMoney / moneylevel)) * giveAmount, _ac_Amt, des1, _id);
                                        }
                                    }

                                    if (repJifen == 1 || repMoney == 1)//跳出while
                                    {
                                        _return = true;
                                        break;
                                    }
                                }

                            }
                        }
                    }                   
                    i++;
                }
                if (_insertFlag == 0)//如果未执行插入消费数据
                {
                    string des2 = string.Format("消费{0}元", _enterMoney);
                    _ac_Amt -= _enterMoney;
                    myInsert(_wid, 2, "", _enterMoney*(-1), _ac_Amt, des2, _id);
                    _return = true;
                }

                return _return;
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "memb/vipmemb/MoneyChange.cs","72");
                return false;
            }
        }

    }
}