using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using Creatrue.Common;

namespace tdx.memb.man.Goods
{
    public partial class B2C_Shop_Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 配置您的微商城信息，如：首页展示模块，支付信息等。";
                    int _wid = Convert.ToInt32(Session["wID"].ToString());
                    string _sql = "select * from B2C_shop_config where wid=" + _wid;
                    DataTable _dt = comfun.GetDataTableBySQL(_sql);

                    if (_dt != null && _dt.Rows.Count > 0)//存在信息则显示出来
                    {
                        int _id = Convert.ToInt32(_dt.Rows[0]["id"].ToString());
                        B2C_shop_config _shop = new B2C_shop_config(_id);
                        show_category.Checked = _shop.sc_isCategory == 1 ? true : false;
                        show_brand.Checked = _shop.Sc_isBrand == 1 ? true : false;
                        show_hot.Checked = _shop.Sc_isHot == 1 ? true : false;
                        show_new.Checked = _shop.Sc_isNew == 1 ? true : false;
                        show_special.Checked = _shop.Sc_isSpecial == 1 ? true : false;
                        show_msg.Checked = _shop.Sc_isMsg == 1 ? true : false;

                        _appId.Value = _shop.Sc_wx_appId;
                        _appSecret.Value = _shop.Sc_wx_appSecret;
                        _appSignKey.Value = _shop.Sc_wx_appSignKey;
                        _partnerId.Value = _shop.Sc_wx_partnerId;
                        _partnerKey.Value = _shop.Sc_wx_partnerKey;

                        _securityKey.Value = _shop.Sc_yl_securityKey;
                        _merId.Value = _shop.Sc_yl_merId;
                        _merAbbr.Value = _shop.Sc_yl_merAbbr;
                        _acqCode.Value = _shop.Sc_yl_acqCode;

                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/B2C_Shop_Config", Session["wID"].ToString());
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            int _id = 0;
            try
            {
                int _wid = Convert.ToInt32(Session["wID"].ToString());
                string _sql = "select top 1 * from B2C_shop_config where wid=" + _wid;//查询微商城配置信息
                DataTable _dt = comfun.GetDataTableBySQL(_sql);
                B2C_shop_config _shop;

                if (_dt == null || _dt.Rows.Count == 0)
                {
                    _shop = new B2C_shop_config();
                    _shop.AddNew();
                }
                else
                    _shop = new B2C_shop_config(Convert.ToInt32(_dt.Rows[0]["id"]));

                _id = _shop.id;
                _shop.wid = Convert.ToInt32(Session["wID"].ToString());
                _shop.sc_isCategory = show_category.Checked ? 1 : 0;
                _shop.Sc_isBrand = show_brand.Checked ? 1 : 0;
                _shop.Sc_isHot = show_hot.Checked ? 1 : 0;
                _shop.Sc_isNew = show_new.Checked ? 1 : 0;
                _shop.Sc_isSpecial = show_special.Checked ? 1 : 0;
                _shop.Sc_isMsg = show_msg.Checked ? 1 : 0;

                _shop.Sc_wx_appId = _appId.Value;
                _shop.Sc_wx_appSecret = _appSecret.Value;
                _shop.Sc_wx_appSignKey = _appSignKey.Value;
                _shop.Sc_wx_partnerId = _partnerId.Value;
                _shop.Sc_wx_partnerKey = _partnerKey.Value;

                _shop.Sc_yl_securityKey = _securityKey.Value;
                _shop.Sc_yl_merId = _merId.Value;
                _shop.Sc_yl_merAbbr = _merAbbr.Value;
                _shop.Sc_yl_acqCode = _acqCode.Value;

                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_wx_appId.Length, 50, "appId的长度不能超过50！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_wx_appSecret.Length, 50, "appSecret的长度不能超过50！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_wx_appSignKey.Length, 50, "appSignKey的长度不能超过50！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_wx_partnerId.Length, 50, "partnerId的长度不能超过50！", ""))
                    return;

                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_wx_partnerKey.Length, 50, "partnerKey的长度不能超过50！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_yl_securityKey.Length, 50, "securityKey的长度不能超过50！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_yl_merId.Length, 50, "merId的长度不能超过50！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_yl_merAbbr.Length, 50, "merAbbr的长度不能超过50！", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, _shop.Sc_yl_acqCode.Length, 50, "acqCode的长度不能超过50！", ""))
                    return;

                _shop.Update();
                if (_id != 0)//修改
                    commonTool.Show_Have_Url(lt_result, "修改成功！", "B2C_Shop_Config.aspx", 0);
                else//添加
                    commonTool.Show_Have_Url(lt_result, "添加成功！", "B2C_Shop_Config.aspx", 0);
            }
            catch (Exception ex)
            {
                if (_id != 0)
                    commonTool.Show_Have_Url(lt_result, "修改失败！", "", 1);
                else
                    commonTool.Show_Have_Url(lt_result, "添加失败！", "", 1);
                comfun.ChuliException(ex, "man/Goods/B2C_Shop_Config", Session["wID"].ToString());
            }


        }
    }
}