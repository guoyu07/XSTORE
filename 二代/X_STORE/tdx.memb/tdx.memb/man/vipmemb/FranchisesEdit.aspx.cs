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
    public partial class FranchisesEdit : workAuth
    {

        DataTable _rank;
        string _check = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int _wid = 29;
                try
                {
                    if (Request["id"] != null && Session["wid"] != null)
                    {
                        //编辑
                        Senk();
                        SenkVIPDefault();
                        B2C_Franchises _bf = new B2C_Franchises(Convert.ToInt32(Request["id"]));
                        name.Value = _bf.name;
                        des.Value = _bf.des;
                        //isLong.Value = _bf.is_long.ToString();
                        group_id.Value = _bf.group_id.ToString();
                    }
                    else
                    {
                        //添加
                        //初始化
                        Senk();
                        SenkVIP();
                        //_where = " group_id in(select id from B2C_group_fran where wid=" + 29 + ")";
                        //DataTable _tequan = B2C_Franchises.GetList(_sql, _where);
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/FranchisesEdit.cs", Session["wID"].ToString());
                }
            }
            else
            {
                if (Request["fanwei"] != null)
                    SenkVIP(Request["fanwei"].ToString());
                else
                    SenkVIP(1);

            }
        }
        //加载默认值的初始化
        private void SenkVIPDefault()
        {
            if (Session["wid"] != null)
            {
                int wid = Convert.ToInt32(Session["wid"]);
                string result1 = "";
                result1 += "\r\n";
                string _sql = "*";
                string _where = "wid=" + wid;
                DataTable _vip = B2C_vipcard.GetList(_sql, _where);
                //_where = "id=" + Request["id"].ToString();
                //DataTable _fr = B2C_Franchises.GetList(_sql, _where);
                _where = " franid = " + Request["id"].ToString();
                DataTable _br = B2C_rankvsfran.GetList(_sql, _where);
                if (_vip.Rows.Count > 0)
                {
                    _where = " cardid=" + _vip.Rows[0]["id"].ToString();
                    _rank = B2C_rankinfo.GetList(_sql, _where);
                    List<int> item = new List<int>();
                    foreach (DataRow dr in _br.Rows)
                    {
                        if (string.IsNullOrEmpty(_csh.Value))
                        {
                            _csh.Value = _csh.Value + dr["rankid"].ToString();
                        }
                        else
                        {
                            _csh.Value = _csh.Value + "," + dr["rankid"].ToString();
                        }
                        item.Add(Convert.ToInt32(dr["rankid"].ToString()));
                    }
                    int i = 0;
                    string[] checkStr = _check.Split(',');
                    foreach (DataRow dr in _rank.Rows)
                    {
                        if (item.IndexOf(Convert.ToInt32(dr["id"])) >= 0)
                        {
                            result1 += "\r\n <input style='height: 25px;' name='fanwei' onchange='getFanWei();' id='rank_" + dr["id"].ToString() + "' value='" + dr["id"].ToString() + "' runat='server' maxlength='50' checked='checked'  type='checkbox' />";
                            result1 += "\r\n <label for='rank_" + dr["id"].ToString() + "'>" + dr["name"].ToString() + "</label><br />";
                        }
                        else
                        {
                            result1 += "\r\n <input style='height: 25px;' name='fanwei' onchange='getFanWei();' id='rank_" + dr["id"].ToString() + "' value='" + dr["id"].ToString() + "' runat='server' maxlength='50' type='checkbox' />";
                            result1 += "\r\n <label for='rank_" + dr["id"].ToString() + "'>" + dr["name"].ToString() + "</label><br />";
                        }
                    }
                }
                result1 += "\r\n";
                ylList.Text = result1;
            }
        }
        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void Senk()
        {
            if (Session["wid"] != null)
            {
                int wid = Convert.ToInt32(Session["wid"]);
                //初始化下拉框
                ListItem lt;
                lt = new ListItem();
                //lt.Value = "1";
                //lt.Text = "长期有效";
                //isLong.Value = "1";
                //is_long.Items.Add(lt);
                string _sql = "*";
                string _where = "wid=" + wid;
                DataTable _fenzu = B2C_group_fran.GetList(_sql, _where);
                int index = 0;
                foreach (DataRow dr in _fenzu.Rows)
                {
                    if (index == 0)
                    {
                        lt = new ListItem();
                        lt.Value = dr["id"].ToString();
                        lt.Text = dr["name"].ToString();
                        lt.Selected = true;
                        hf.Value = dr["id"].ToString();
                        group_id.Items.Add(lt);
                        index++;
                    }
                    else
                    {
                        lt = new ListItem();
                        lt.Value = dr["id"].ToString();
                        lt.Text = dr["name"].ToString();
                        group_id.Items.Add(lt);
                    }
                }
            }
        }
        private void SenkVIP(int flag = 0)
        {
            if (Session["wid"] != null)
            {
                int wid = Convert.ToInt32(Session["wid"]);
                string result1 = "";
                result1 += "\r\n";
                string _sql = "*";
                string _where = "wid=" + wid;
                DataTable _vip = B2C_vipcard.GetList(_sql, _where);
                if (_vip.Rows.Count > 0)
                {
                    _where = " cardid=" + _vip.Rows[0]["id"].ToString();
                    _rank = B2C_rankinfo.GetList(_sql, _where);
                    int count = 0;

                    foreach (DataRow dr in _rank.Rows)
                    {
                        ++count;
                        if (count == 1 && flag == 0)
                            result1 += "\r\n <input style='height: 25px;' name='fanwei' onchange='getFanWei();' id='rank_" + dr["id"].ToString() + "' value='" + dr["id"].ToString() + "' runat='server' maxlength='50' checked  type='checkbox' />";
                        else
                            result1 += "\r\n <input style='height: 25px;' name='fanwei' onchange='getFanWei();' id='rank_" + dr["id"].ToString() + "' value='" + dr["id"].ToString() + "' runat='server' maxlength='50'  type='checkbox' />";

                        result1 += "\r\n <label for='rank_" + dr["id"].ToString() + "'>" + dr["name"].ToString() + "</label><br />";
                    }
                }
                result1 += "\r\n";
                ylList.Text = result1;
            }
        }

        private void SenkVIP(string _Chk)
        {
            if (Session["wid"] != null)
            {
                int wid = Convert.ToInt32(Session["wid"]);
                string result1 = "";
                result1 += "\r\n";
                string _sql = "*";
                string _where = "wid=" + wid;
                DataTable _vip = B2C_vipcard.GetList(_sql, _where);
                if (_vip.Rows.Count > 0)
                {
                    _where = " cardid=" + _vip.Rows[0]["id"].ToString();
                    _rank = B2C_rankinfo.GetList(_sql, _where);
                    int count = 0;
                    string[] _checkStr = _Chk.Split(',');
                    foreach (DataRow dr in _rank.Rows)
                    {

                        if (_checkStr.Length > 0)
                        {
                            if (count < _checkStr.Length && _checkStr[count] == dr["id"].ToString())
                                result1 += "\r\n <input style='height: 25px;' name='fanwei' onchange='getFanWei();' id='rank_" + dr["id"].ToString() + "' value='" + dr["id"].ToString() + "' runat='server' maxlength='50' checked  type='checkbox' />";
                            else
                                result1 += "\r\n <input style='height: 25px;' name='fanwei' onchange='getFanWei();' id='rank_" + dr["id"].ToString() + "' value='" + dr["id"].ToString() + "' runat='server' maxlength='50'  type='checkbox' />";
                        }
                        else
                            result1 += "\r\n <input style='height: 25px;' name='fanwei' onchange='getFanWei();' id='rank_" + dr["id"].ToString() + "' value='" + dr["id"].ToString() + "' runat='server' maxlength='50'  type='checkbox' />";

                        result1 += "\r\n <label for='rank_" + dr["id"].ToString() + "'>" + dr["name"].ToString() + "</label><br />";
                        count++;
                    }
                }
                result1 += "\r\n";
                ylList.Text = result1;
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(comFunction.NoHTML(name.Value.Trim())))
                {
                    if (Request["id"] != null && Session["wid"] != null)
                    {
                        int wid = Convert.ToInt32(Session["wid"]);
                        try
                        {
                            //编辑
                            B2C_Franchises _bf = new B2C_Franchises(Convert.ToInt32(Request["id"]));
                            _bf.name = comFunction.NoHTML(name.Value);
                            _bf.group_id = Convert.ToInt32(hf.Value);
                            _bf.des = comFunction.NoHTML(des.Value);
                            if (_bf.name == "")
                            {
                                lt_result.Text = "特权名称不能为空！";
                                return;
                            }
                            if (_bf.name.Length > 50)
                            {
                                lt_result.Text = "特权名称最多不超过50个字符！";
                                return;
                            }
                            if (_bf.des.Length > 255)
                            {
                                lt_result.Text = "描述最多不超过255个字符！";
                                return;
                            }
                            if (Request["fanwei"] == null || Request["fanwei"].ToString() == "")
                            {
                                lt_result.Text = "请选择特权范围！";
                                return;
                            }
                            _check = Request["fanwei"].ToString();
                            _bf.Update();
                            //修改自己

                            //修改关联表
                            string _rankID = Request["id"].ToString();
                            string xuanzhong = rank.Value;
                            string moren = _csh.Value;
                            string[] str;
                            string[] _moren;
                            if (!string.IsNullOrEmpty(xuanzhong))
                            {
                                str = xuanzhong.Split(new char[] { ',' });
                            }
                            else
                            {
                                str = new string[] { };
                            }
                            if (!string.IsNullOrEmpty(moren))
                            {
                                _moren = moren.Split(new char[] { ',' });
                            }
                            else
                            {
                                _moren = new string[] { };
                            }
                            List<string> _listAdd = new List<string>();
                            List<string> _listRemove = new List<string>();
                            for (int i = 0; i < str.Length; i++)
                            {
                                _listAdd.Add(str[i]);
                            }
                            for (int i = 0; i < _moren.Length; i++)
                            {
                                _listRemove.Add(_moren[i]);
                            }
                            List<string> _itemAdd = _listAdd;
                            List<string> _itemRemove = _listRemove;
                            //System.Math.Abs
                            for (int i = 0; i < _listAdd.Count; i++)
                            {
                                for (int j = 0; j < _listRemove.Count; j++)
                                {
                                    if (System.Math.Abs(Convert.ToInt32(_listAdd[i])) == System.Math.Abs(Convert.ToInt32(_listRemove[j])))
                                    {
                                        _itemAdd.Remove(_listAdd[i]);
                                        _itemRemove.Remove(_listRemove[j]);
                                    }
                                }
                            }
                            //删除对应的不需要的记录
                            for (int i = 0; i < _itemRemove.Count; i++)
                            {
                                string delete = " franid=" + _rankID + " and rankid=" + _listRemove[i].Trim();
                                int result = B2C_rankvsfran.delete(delete);
                                if (result == 0)
                                {
                                    commonTool.Show_Have_Url(lt_result, "清除不需要记录失败！", "", 1);
                                    //throw new Exception("删除记录失败");
                                }
                            }
                            B2C_rankvsfran _br;
                            //添加新的记录
                            for (int i = 0; i < _itemAdd.Count; i++)
                            {
                                _br = new B2C_rankvsfran();
                                _br.create_time = DateTime.Now;
                                _br.franid = Convert.ToInt32(_rankID);
                                _br.rankid = Convert.ToInt32(_itemAdd[i].Trim());
                                _br.Update();
                            }
                            commonTool.Show_Have_Url(lt_result, "修改成功！", "Franchises.aspx", 0);
                        }
                        catch (Exception ex1)
                        {
                            commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);
                        }
                    }
                    else if (Session["wid"] != null)
                    {
                        //添加
                        try
                        {
                            int wid = Convert.ToInt32(Session["wid"]);
                            //添加特权
                            B2C_Franchises _bf = new B2C_Franchises();
                            _bf.name = comFunction.NoHTML(name.Value);
                            _bf.group_id = Convert.ToInt32(hf.Value);
                            _bf.des = comFunction.NoHTML(des.Value);
                            if (_bf.name == "")
                            {
                                lt_result.Text = "特权名称不能为空！";
                                return;
                            }
                            if (_bf.name.Length > 50)
                            {
                                lt_result.Text = "特权名称最多不超过50个字符！";
                                return;
                            }
                            if (_bf.des.Length > 255)
                            {
                                lt_result.Text = "描述最多不超过255个字符！";
                                return;
                            }
                            if (Request["fanwei"] == null || Request["fanwei"].ToString() == "")
                            {
                                lt_result.Text = "请选择特权范围！";
                                return;
                            }
                            _check = Request["fanwei"].ToString();
                            _bf.create_time = DateTime.Now;
                            _bf.Update();
                            //添加特权结束

                            //找到刚添加的特权
                            string _sql = "top(1)  *";
                            string _where = "group_id in( select id from  B2C_group_fran where wid=" + wid + " ) order by id desc";
                            _rank = B2C_Franchises.GetList(_sql, _where);
                            string _rankID = _rank.Rows[0]["id"].ToString();


                            string xuanzhong = rank.Value;
                            string moren = _csh.Value;
                            string[] str = xuanzhong.Split(new char[] { ',' });
                            string[] _moren;
                            if (!string.IsNullOrEmpty(moren))
                            {
                                _moren = moren.Split(new char[] { ',' });
                            }
                            else
                            {
                                _moren = new string[] { };
                            }
                            List<string> _listAdd = new List<string>();
                            List<string> _listRemove = new List<string>();
                            for (int i = 0; i < str.Length; i++)
                            {
                                _listAdd.Add(str[i]);
                            }
                            for (int i = 0; i < _moren.Length; i++)
                            {
                                _listRemove.Add(_moren[i]);
                            }
                            List<string> _itemAdd = _listAdd;
                            List<string> _itemRemove = _listRemove;
                            //System.Math.Abs
                            for (int i = 0; i < _listAdd.Count; i++)
                            {
                                for (int j = 0; j < _listRemove.Count; j++)
                                {
                                    if (System.Math.Abs(Convert.ToInt32(_listAdd[i])) == System.Math.Abs(Convert.ToInt32(_listRemove[i])))
                                    {
                                        _itemAdd.Remove(_listAdd[i]);
                                        _itemRemove.Remove(_listRemove[j]);
                                    }
                                }
                            }
                            for (int i = 0; i < _listRemove.Count; i++)
                            {
                                string delete = " franid=" + _rankID + " and rankid=" + _listRemove[i].Trim();
                                int result = B2C_rankvsfran.delete(delete);
                                if (result == 0)
                                {
                                    commonTool.Show_Have_Url(lt_result, "清除不需要记录失败！", "", 1);

                                }
                            }
                            B2C_rankvsfran _br;
                            for (int i = 0; i < _itemAdd.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(_itemAdd[i]))
                                {
                                    _br = new B2C_rankvsfran();
                                    _br.create_time = DateTime.Now;
                                    _br.franid = Convert.ToInt32(_rankID);
                                    _br.rankid = Convert.ToInt32(_itemAdd[i].Trim());
                                    _br.Update();
                                }
                            }
                            commonTool.Show_Have_Url(lt_result, "添加成功！", "Franchises.aspx", 0);
                        }
                        catch (Exception ex)
                        {
                            commonTool.Show_Have_Url(lt_result, "添加失败！", "", 1);
                        }
                    }
                }
                else
                {
                    commonTool.Show_Have_Url(lt_result, "特权名不能为空！", "", 1);

                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/FranchisesEdit.cs", Session["wID"].ToString());
            }
        }
    }
}