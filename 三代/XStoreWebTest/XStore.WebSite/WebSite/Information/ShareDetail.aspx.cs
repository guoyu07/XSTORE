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
    public partial class ShareDetail : CenterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "幸事多私享空间-流水明细";
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        protected void PageInit() {
            var requestUrl = string.Format(Constant.YunApi + "test/share/list?username={0}", userInfo.username);
            var response = JsonConvert.DeserializeObject<ListResponse>(Utils.HttpGet(requestUrl));
            if (response.operationStatus.Equals("SUCCESS"))
            {
               
                detail_rp.DataSource = response.operationMessage.Select(o => new
                {
                    cause = o.cause,
                    date = o.date,
                    income = (o.type ==1)?"-"+o.income.CentToRMB(0).ToString("F2"):"+"+o.income.CentToRMB(0).ToString("F2"),
                    type=o.type

                }).ToList();
                detail_rp.DataBind();
                return;
            }
            else
            {
                MessageBox.Show(this, "system_alert","明细获取失败");
                return;
            }
        }
    }
}