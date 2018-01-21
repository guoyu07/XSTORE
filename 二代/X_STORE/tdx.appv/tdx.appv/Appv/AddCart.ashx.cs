using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using tdx.database;
using System.Web.SessionState;

namespace tdx.appv
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AddCart : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            double _nowNum = 0;
            //添加进购物车
            if (context.Request["guid"] != null)
            {
                string _guid = context.Request["guid"].ToString().Trim();
                string _sl = context.Request["qnt"].ToString().Trim();
                string _gname = ""; 
                string _dj = "";
                string _gtotal = "";
                string _cent = "";
                string _allcent = "";
                string _ggif = "";
                string _gdes = "";
                B2C_Goods myg = new B2C_Goods(Convert.ToInt32(_guid));
                _gname = myg.g_name;
                if(_sl.Length == 0 )
                    _sl = "1";
                _dj = myg.g_price_S.ToString();

                //如果为vip会员，则价格变化了.
                if (context.Session["mID"] != null)
                {
                    B2C_mem bm = new B2C_mem(Convert.ToInt32(context.Session["mID"]));
                    if (bm.M_vip > 1)
                    {
                        _dj = myg.g_price_B.ToString(); 
                    }
                }

                _gtotal = (Convert.ToDouble(_dj) * Convert.ToDouble(_sl)).ToString().Trim();
                _cent = myg.g_cent.ToString();
                _allcent = (Convert.ToDouble(_cent) * Convert.ToDouble(_sl)).ToString().Trim();
                _ggif = myg.g_gif;
                _gdes = "";


                _nowNum = Convert.ToDouble(_sl);

                if (context.Session[orderAuth.getOrderCookieKey()] != null) //购物车不为空,添加货物
                {
                    DataTable orderTable = (DataTable)context.Session[orderAuth.getOrderCookieKey()];

                    Boolean bl = false;
                    foreach (DataRow dr in orderTable.Rows)
                    {
                        if (dr["guid"].ToString().Trim() == _guid) //存在相同货物
                        {
                            dr["g_num"] = (Convert.ToDouble(dr["g_num"]) + Convert.ToDouble(_sl)).ToString().Trim();
                            dr["g_amt"] = (Convert.ToDouble(dr["g_amt"]) + Convert.ToDouble(_gtotal)).ToString().Trim();
                            dr["g_allcent"] = (Convert.ToDouble(dr["g_allcent"]) + Convert.ToDouble(_allcent)).ToString().Trim();

                            //此处进行最低起订数量判断
                            if ((Convert.ToDouble(dr["g_num"]) + Convert.ToDouble(_sl)) < myg.g_lowN)
                            {
                                dr["g_num"] = myg.g_lowN;
                                dr["g_amt"] = Convert.ToDouble(_dj) * myg.g_lowN;
                                dr["g_allcent"] = Convert.ToDouble(_cent) * myg.g_lowN;
                            }

                            context.Session[orderAuth.getOrderCookieKey()] = orderTable;

                            _nowNum = Convert.ToDouble(dr["g_num"]);

                            bl = true;
                            break;
                        }
                    }
                    if (bl == false)
                    { //购物车不存在该商品，则新加商品
                        if(Convert.ToDouble(_sl)<myg.g_lowN)
                        {
                            _sl = myg.g_lowN.ToString();
                        } 
                        _gtotal = (Convert.ToDecimal(_sl) * Convert.ToDecimal(_dj)).ToString();
                        _allcent = (Convert.ToDecimal(_sl) * Convert.ToDecimal(_cent)).ToString();

                        DataRow row = orderTable.NewRow();
                        row[0] = _guid;
                        row[1] = _gname;
                        row[2] = _sl;
                        row[3] = _dj;
                        row[4] = _gtotal;
                        row[5] = _cent;
                        row[6] = _allcent;
                        row[7] = _ggif;
                        row[8] = _gdes;
                        orderTable.Rows.Add(row);
                        context.Session[orderAuth.getOrderCookieKey()] = orderTable;
                    }
                }
                else//购物车为空,初始化购物车
                {
                    if (Convert.ToDouble(_sl) < myg.g_lowN)
                    {
                        _sl = myg.g_lowN.ToString();
                    } 
                    _gtotal = (Convert.ToDecimal(_sl) * Convert.ToDecimal(_dj)).ToString();
                    _allcent = (Convert.ToDecimal(_sl) * Convert.ToDecimal(_cent)).ToString();

                    DataTable orderTable = new DataTable();
                    orderTable.Columns.Add("guid");
                    orderTable.Columns.Add("g_name");
                    orderTable.Columns.Add("g_num");
                    orderTable.Columns.Add("g_price");
                    orderTable.Columns.Add("g_amt");
                    orderTable.Columns.Add("g_cent");
                    orderTable.Columns.Add("g_allcent");
                    orderTable.Columns.Add("g_gif");
                    orderTable.Columns.Add("g_des");

                    DataRow row = orderTable.NewRow();
                    row[0] = _guid;
                    row[1] = _gname;
                    row[2] = _sl;
                    row[3] = _dj;
                    row[4] = _gtotal;
                    row[5] = _cent;
                    row[6] = _allcent;
                    row[7] = _ggif;
                    row[8] = _gdes;
                    orderTable.Rows.Add(row);
                    context.Session[orderAuth.getOrderCookieKey()] = orderTable;
                }
            }
            //处理完返回结果
            DataTable orderTable2 = (DataTable)context.Session[orderAuth.getOrderCookieKey()];
            double _totalsj = 0;
            double _totalmoney = 0;
            foreach (DataRow dr in orderTable2.Rows)
            {
                _totalsj += Convert.ToDouble(dr["g_num"]);
                _totalmoney += Convert.ToDouble(dr["g_amt"]);
            }
            orderTable2.Dispose();
            orderTable2 = null;

            context.Response.Write("<a href='cart.aspx?WWX=" + (context.Request["WWX"] != null ? context.Request["WWX"].ToString().Trim() : "") + "' rel=\"external\">本品已订" + _nowNum + "件。共" + _totalsj + "件," + _totalmoney + "元</a>");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
