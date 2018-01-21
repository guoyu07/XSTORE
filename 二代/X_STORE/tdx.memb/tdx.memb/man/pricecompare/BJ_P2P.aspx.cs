using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using tdx.database;
using Creatrue.kernel;

namespace tdx.memb.man.pricecompare
{
    public partial class BJ_P2P : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null && Session["wid"] != null)
                {
                    DataTable dt = comfun.GetDataTableBySQL("select * from B2C_Goods where id =" + Request["id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        shangpinming.Value = dt.Rows[0]["g_name"].ToString();
                        jiage.Value = Convert.ToDouble(dt.Rows[0]["g_price_M"].ToString()).ToString("F2");
                        weixinjiage.Value = Convert.ToDouble(dt.Rows[0]["g_price_S"].ToString()).ToString("F2");
                        //先检测所有的商户是都对当前商品进行了绑定
                        DataTable dt_obj = BJ_obj.GetList("*", "wid=" + Session["wid"].ToString());
                        if (dt_obj.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt_obj.Rows)
                            {
                                //便利检测是都产品都含有关联记录
                                DataTable dt_d = BJ_value.GetList("*", "obj_id=" + dr["id"].ToString() + "and pro_id=" + Request["id"].ToString());
                                if (dt_d.Rows.Count == 0)
                                {
                                    BJ_value bjv = new BJ_value();
                                    bjv.obj_id = Convert.ToInt32(dr["id"].ToString());
                                    bjv.pro_id = Convert.ToInt32(Request["id"].ToString());
                                    bjv.Update();
                                }

                            }
                            Chuli(Request["id"].ToString(), Session["wid"].ToString());
                        }
                        else
                        {
                            shangjia.Text = "没有添加其他商铺";
                        }
                    }
                    else
                    {
                        return;
                    }



                }
                else
                {
                    return;
                }
            }
        }

        private void Chuli(string id, string wid)
        {
            DataTable dtObj = BJ_obj.GetList("*", "wid=" + wid);
            Dictionary<string, string> objDict = new Dictionary<string, string>();
            //循环存放字典
            foreach (DataRow dro in dtObj.Rows)
            {
                objDict.Add(dro["id"].ToString(), dro["name"].ToString());
            }
            string result1 = "";
            DataTable dtVa = BJ_value.GetList("*", "pro_id=" + id);
            result1 += "\r\n";
            result1 += " \r\n <table class=\"borderTable\" align=\"center\" border=\"0\"  cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            result1 += " \r\n <tbody>";
            result1 += "\r\n <tr>";
            result1 += "\r\n <td align=\"center\">商城名称</td> ";
            result1 += "\r\n <td align=\"center\">价格</td> ";
            result1 += " \r\n </tr>";
            if (dtVa.Rows.Count > 0)
            {
                foreach (DataRow dr in dtVa.Rows)
                {
                    dangqianid.Value += string.IsNullOrEmpty(dangqianid.Value) ? dr["id"].ToString() : "," + dr["id"].ToString();
                    int _id = Convert.ToInt32(dr["id"].ToString());
                    result1 += " \r\n <tr>";
                    //result1 += " \r\n <td align=\"left\" height=\"100\"> <input name=\"delbox\" value=\"" + dr["id"].ToString() + "\" type=\"checkbox\"></td> ";
                    result1 += " \r\n <td align=\"center\" height=\"30\">" + objDict[dr["obj_id"].ToString()] + "</td> ";
                    result1 += " \r\n  <td align=\"center\" height=\"30\"><input name=\"neirongprice\" value=\"" + Convert.ToDouble(dr["price"].ToString()).ToString("F2") + "\" type=\"text\"><input name=\"shangjiaid\" value=\"" + dr["id"].ToString() + "\" type=\"checkbox\" style=\"display:none\"></td> ";
                    result1 += " \r\n </tr>";
                }
                shangjia.Text = result1;
            }


        }
        protected void baocunbianji(object sender, EventArgs e)
        {
            if (Request["neirongprice"] != null & !string.IsNullOrEmpty(dangqianid.Value))
            {
                string[] neirongs = Request["neirongprice"].ToString().Split(new char[] { ',' });
                string[] ids = dangqianid.Value.Split(new char[] { ',' });
                if (neirongs.Length == ids.Length)
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        BJ_value bv = new BJ_value(Convert.ToInt32(ids[i]));
                        double.TryParse(neirongs[i], out bv.price);
                        bv.Update();
                    }
                    Response.Write("<script language='javascript'>alert('更新成功！');location.href='BJ_P2P.aspx?id=" + Request["id"].ToString() + "';</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('更新失败！');location.href='BJ_P2P.aspx?id=" + Request["id"].ToString() + "';</script>");
                }
            }
        }
    }
}