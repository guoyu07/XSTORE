using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XStore.Common;
using XStore.Common.Helper;
using XStore.Entity;
using XStore.Entity.Model;

namespace XStore.WebSite.WebSite.Operation
{
    public partial class RoomFixed : MacPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间-常规补货";
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            if (userInfo == null)
            {
                MessageBox.Show(this, "system_alert", "用户不存在");
                return;
            }
            if (cabinet == null)
            {
                MessageBox.Show(this, "system_alert", "房间不存在");
                return;
            }

            if (string.IsNullOrEmpty(cabinet.products))
            {
                MessageBox.Show(this, "system_alert", "酒店房间未设置默认商品");
                return;
            }
            #region 绑定房间商品
            var proidList = new List<int>();
            //根据storebatch获取对应的商品id
            var storeBatchList = cabinet.products.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(o => o.ObjToInt(0));
            foreach (var storeBatch in storeBatchList)
            {
                proidList.Add(context.Query<StoreBatch>()
                    .Where(o => o.id == storeBatch)
                    .LeftJoin<ProductBatch>((a, b) => a.batch_id == b.id).Select((a, b) => b.product_id)
                    .FirstOrDefault());
            }
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
            box_rp.DataSource = list;
            box_rp.DataBind();
            #endregion

            #region 打开需要补货的格子
            try
            {
                if (string.IsNullOrEmpty(cabinet.products))
                {
                    MessageBox.Show(this,"system_alert","房间未设置商品");
                    return;
                }
                var requestUrl = string.Format(Constant.YunApi + "test/back/start?mac={0}&username={1}", cabinet.mac, userInfo.username);
                var response = JsonConvert.DeserializeObject<BuyResponse>(Utils.HttpGet(requestUrl));
                if (!response.operationStatus.Equals("SUCCESS"))
                {
                    MessageBox.Show(this, "system_alert", "补货单生成失败");
                    return;
                }
                var backNo = response.operationMessage.ObjToStr();
                var storeIdList = cabinet.products.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(o=>o.ObjToInt(0)).ToList();
                var position =string.Empty;
                for (int i = 0; i < storeIdList.Count; i++)
                {
                    if (storeIdList[i] == 0)
                    {
                        position += storeIdList[i] + ",";
                    }
                }
                if (!string.IsNullOrEmpty(position))
                {
                    position = position.TrimEnd(',');
                    var rbh = new RemoteBoxHelper();
                    rbh.OpenRemoteBox(cabinet.mac, backNo, position, 0x02);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"system_alert","数据异常");
                return;
            }
            #endregion
        }
        #region 补货完成
        protected void finish_button_Click(object sender, EventArgs e)
        {
           //TODO
        }
        #endregion
    }
}