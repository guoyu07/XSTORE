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
    public partial class Merchant : System.Web.UI.Page
    {
        public string img = "";
        public string imgli = "";
        public string infomation = "";
        public int id = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] == null)
            {
                if (Session["wxid"] == null)
                {
                    id = 1;
                    Session["wxid"] = id; 
                }
                else
                {
                    id = Convert.ToInt32(Session["wxid"].ToString());
                    Session["wxid"] = id;

                }
               
            }
            else
            {
                if (Session["wxid"] == null)
                {
                    id = Convert.ToInt32(Request["id"].ToString());
                    Session["wxid"] = id;
                }
                else
                {
                    id = Convert.ToInt32(Session["wxid"].ToString());
                    Session["wxid"] = id;
                }
               
            }


            infomation = info(5, 4);


            #region 图片代码
            string sql = "select * from b2c_honor where cno='004001' order by id desc";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                imgli = "<li class=\"on\"></li>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    img += "<li><a href=\"javascript:;\"><img src='" + dt.Rows[i]["P_url"] + "' /></a></li>";
                    if (i > 0)
                    {
                        imgli += "<li></li>";
                    }
                }

            }
            #endregion


        }

        string info(int leibietop, int infotop)
        {
            string r = "";
            string sql = "select top " + leibietop + "* from TM_商品类别表";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    r += "<div class=\"titleline\"><div class=\"wrap\"><div class=\"title\"><a href=\"ListView.aspx?lbh=" + dt.Rows[i]["类别编号"].ToString() + "&wxid="+id+"\">" + dt.Rows[i]["类别名"].ToString() + "</a></div>";
                    r += " </div></div><div class=\"hei_15\"></div><div class=\"wrap\"><ul class=\"main_pro clear\">";
                    string sqlinfo = "select top " + infotop + "* from TM_商品表 a  where   类别号='" + dt.Rows[i]["类别编号"].ToString() + "' and isshow=1 and 是否上架=1 and 下架时间>convert(varchar(50),'" + DateTime.Now + "',120)  order by  a.id desc";
                    DataTable dtinfo = comfun.GetDataTableBySQL(sqlinfo);
                    if (dtinfo.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtinfo.Rows.Count; j++)
                        {
                            if (dtinfo.Rows[j]["类型"].ToString().Equals("2"))
                            {
                                r += "<li><div class=\"box\"><div class=\"pic_39\"><img src=\"images/pic_39.png\"/></div><div class=\"pic\"><a href=\"index.aspx?attach=::" + dtinfo.Rows[j]["编号"].ToString() + "\" >";
                            }
                            else
                            {
                                r += "<li><div class=\"box\"><div class=\"pic\"><a href=\"index.aspx?attach=::" + dtinfo.Rows[j]["编号"].ToString() + "\" >";
                            }
                            string sqlpic = "select top 1* from TM_商品图片表 where 商品编号='" + dtinfo.Rows[j]["编号"].ToString() + "'";
                            DataTable dtpic = comfun.GetDataTableBySQL(sqlpic);
                            if (dtpic.Rows.Count > 0)
                            {
                                r += " <img src='" + dtpic.Rows[0]["图片路径"].ToString() + "' />";
                            }
                            r += "   </a></div>";
                            r += "<div class=\"pro_name\"><a href=\"index.aspx?attach=::" + dtinfo.Rows[j]["编号"].ToString() + ":" + "\" >" + dtinfo.Rows[j]["品名"].ToString() + "</a></div>";
                            r += "<div class=\"price_old clear\"><em class=\"fl\">¥ " + dtinfo.Rows[j]["本站价"].ToString() + "</em><span class=\"fr\">";
                            string sqlbuy = "select * from TM_订单表 a,TM_订单子表 b where a.订单编号 =b.订单编号 and a.订单编号 in (select 订单编号 from TM_订单支付表)  and 商品编号 ='" + dtinfo.Rows[j]["编号"].ToString() + "'";
                            DataTable dtbuy = comfun.GetDataTableBySQL(sqlbuy);
                            if (dtbuy.Rows.Count > 0)
                            {
                                r += "" + dtbuy.Rows.Count + "人已购买</span></div>";
                            }
                            else
                            {
                                r += "0人已购买</span></div>";
                            }
                            r += "<div class=\"price\"><span>¥ " + dtinfo.Rows[j]["三团价"].ToString() + "</span></div>";
                            r += "	</div></li>";
                        }
                    }
                    r += "</ul></div>";
                }

            }
            return r;
        }


    }
}