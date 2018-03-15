using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XStore.Common;
using XStore.Entity;
using XStore.Entity.Model;

namespace XStore.WebSite.WebSite.Information
{
    public partial class Wallet : CenterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间-零钱";
            PageInit();
        }
        protected void PageInit() {

            var requestUrl = string.Format(Constant.YunApi + "test/share/income?username={0}", userInfo.username);
            var response = JsonConvert.DeserializeObject<BuyResponse>(Utils.HttpGet(requestUrl));
            if (response.operationStatus.Equals("SUCCESS"))
            {
                mymoney.InnerHtml = response.operationMessage.ObjToInt(0).CentToRMB(0).ToString("F2");
                return;
            }
            else
            {
                MessageBox.Show(this, "system_alert", response.operationMessage);
                return;
            }
        }

        protected void extract_ServerClick(object sender, EventArgs e)
        {
            var requestUrl = string.Format(Constant.YunApi + "test/share/extract?username={0}", userInfo.username);
            var response = JsonConvert.DeserializeObject<BuyResponse>(Utils.HttpGet(requestUrl));
            if (response.operationStatus.Equals("SUCCESS"))
            {
                if (response.operationMessage.ObjToInt(0)==0)
                {
                    MessageBox.Show(this, "system_alert", "提现金额不足");
                    return;
                }
                else
                {
                    MessageBox.Show(this, "system_alert", "提现成功");
                    return;
                }
               
            }
            else
            {
                MessageBox.Show(this, "system_alert", response.operationMessage);
                return;
            }
        }
    }
}