using Newtonsoft.Json;
using System;
using XStore.Entity;

namespace XStore.WebSite
{
    public partial class Index :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        public void PageInit() {

            test.InnerText = JsonConvert.SerializeObject(context.Query<Areas>().ToList());

        }
    }
}