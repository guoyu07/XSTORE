using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;

namespace Tuan
{
    public partial class MyDingInfo : System.Web.UI.Page
    {

        public string name = "";
        public string address = "";
        public string tel = "";
        public string ddbh = "";
        public string totalprice = "";
        public string xdsj = "";
        public string bz = "无";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request["ddbh"] != null)
            {
                ddbh = Request["ddbh"].ToString();
                string sqladdress = "select * from WP_地址表 a,WP_订单地址表 b where a.地址ID=b.id and a.订单编号='" + Request["ddbh"].ToString() + "'";
                DataTable dtaddress = comfun.GetDataTableBySQL(sqladdress);
                if (dtaddress.Rows.Count > 0)
                {
                    name = dtaddress.Rows[0]["收货人"].ToString();
                    tel = dtaddress.Rows[0]["手机号"].ToString();
                    address = dtaddress.Rows[0]["省"].ToString() + dtaddress.Rows[0]["市"].ToString() + dtaddress.Rows[0]["区"].ToString() + dtaddress.Rows[0]["详细地址"].ToString();

                }
                else
                {
                    name = "自提";
                    string sqlziti = "select * from TM_商品表 a,dt_manager b where 用户ID=b.id and  编号 in (select 商品编号 from TM_订单表 a ,TM_订单子表 b where a.订单编号=b.订单编号 and a.订单编号='" + Request["ddbh"].ToString() + "')";
                    DataTable dtziti = comfun.GetDataTableBySQL(sqlziti);
                    if (dtziti.Rows.Count > 0)
                    {
                        address = dtziti.Rows[0]["address"].ToString();
                    }

                }
                string sqlspinfo = "select * from  TM_订单表 a ,TM_订单子表 b,TM_商品表 c,dt_manager d,wx_mp e where b.商品编号=c.编号 and c.用户id=d.id and d.wxid=e.id and  a.订单编号=b.订单编号 and a.订单编号='" + Request["ddbh"].ToString() + "'";
                DataTable dtspinfo = comfun.GetDataTableBySQL(sqlspinfo);
                if (dtspinfo.Rows.Count > 0)
                {
                    string str = "";
                    for (int i = 0; i < dtspinfo.Rows.Count; i++)
                    {
                        string img = "";
                        string sqlimg = "select top 1* from TM_商品图片表 where 商品编号='" + dtspinfo.Rows[i]["编号"].ToString() + "'";
                        DataTable dtimg = comfun.GetDataTableBySQL(sqlimg);
                        if (dtimg.Rows.Count > 0)
                        {
                            img = dtimg.Rows[0]["图片路径"].ToString();
                        }
                        else
                        {
                            img = "images/03.jpg";
                        }

                        totalprice = dtspinfo.Rows[i]["总金额"].ToString();
                        xdsj = dtspinfo.Rows[i]["下单时间"].ToString();
                        str += "<div class=\"content clear\">";
                        str += "<div class=\"fl pic\"><a href=\"index.aspx?attach=::" + dtspinfo.Rows[i]["编号"].ToString() + ":" + dtspinfo.Rows[i]["wxid"].ToString() + "\"><img src=" + img + " /></a></div>";
                        str += " <div class=\"txt fl\">";
                        str += "<a href=\"index.aspx?attach=::" + dtspinfo.Rows[i]["编号"].ToString() + ":" + dtspinfo.Rows[i]["wxid"].ToString() + "\">" + (dtspinfo.Rows[i]["品名"].ToString().Length > 20 ? dtspinfo.Rows[i]["品名"].ToString().Substring(0, 19) + "......" : dtspinfo.Rows[i]["品名"].ToString()) + "</a>";
                        str += "</div><div class=\"old_pic fr\"><p>¥" + dtspinfo.Rows[i]["价格"].ToString() + "</p><p class=\"num\"><em>X</em> " + dtspinfo.Rows[i]["数量"].ToString() + "</p></div></div>";


                    }
                    DingInfo.Text = str;
                }



            }
            else
            {

            }
        }
    }
}