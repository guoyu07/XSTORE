using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XStore.Common;
using XStore.Entity;
using XStore.Entity.Model;

namespace XStore.WebSite.WebSite.Goods
{
    public partial class GoodsList : BasePage
    {
        #region 房间
        private Cabinet _cabinet;
        protected Cabinet cabinet
        {
            get
            {
                if (_cabinet == null)
                {
                    var boxMac = Request.QueryString[Constant.IMEI].ObjToStr();

                    _cabinet = context.Query<Cabinet>().FirstOrDefault(o => o.mac.Equals(boxMac));
                }
                return _cabinet;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间";
            if (!IsPostBack)
            {
                if (cabinet ==null)
                {
                    MessageBox.Show(this, "system_alert", "箱子未绑定房间");
                    return;
                }
                if (cabinet.online.HasValue&&cabinet.online.Value)//离线
                {
                    Response.Redirect(string.Format(Constant.LoginDic + "NoPower.aspx?boxmac = {0}", cabinet.mac), false);
                    return;
                }
                else
                {
                    PageInit();
                }
            }
        }
        protected void PageInit()
        {
            try
            {
                if (string.IsNullOrEmpty(cabinet.products))
                {
                    MessageBox.Show(this, "system_alert", "酒店房间未设置默认商品");
                    return;
                }
                var proidList = cabinet.products.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var layout = context.Query<CabinetLayout>().FirstOrDefault(o => o.hotel_id == cabinet.hotel);
                if (layout == null)
                {
                    MessageBox.Show(this, "system_alert", "酒店未设置默认商品");
                    return;
                }
                var layoutProList = layout.products.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (proidList.Count() != layoutProList.Count())
                {
                    MessageBox.Show(this, "system_alert", "房间设置商品不全");
                    return;
                }
                List<ProductQuery> list = new List<ProductQuery>();
                List<Product> productList = context.Query<Product>().Where(o => o.state == 1).ToList();

                for (int i = 0; i < proidList.Count(); i++)
                {
                    var proid = proidList[i].ObjToInt(0);
                    var sell_out = false;
                    //如果实际商品是0，则用默认商品补全
                    if (proid == 0)
                    {
                        proid = layoutProList[i].ObjToInt(0);
                        sell_out = true;
                    }
                    var pro = productList.FirstOrDefault(o => o.id == proid);
                    if (pro == null)
                    {
                        MessageBox.Show(this, "system_alert", "配置的商品不存在");
                        return;
                    }
                    var proQuery = TinyMapper.Map<ProductQuery>(pro);
                    proQuery.sell_out = sell_out;
                    list.Add(proQuery);
                }

                goods_list.DataSource = list;
                goods_list.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
       
        protected string link_detail(bool sell_out,int position,int product_id)
        {
           
            if (sell_out)
            {
                return "#";
            }
            else
            {
                return string.Format("Detail.aspx?product_id={0}&boxmac={1}&position={2}", product_id, cabinet.mac,position);
            }

        }
    }
}