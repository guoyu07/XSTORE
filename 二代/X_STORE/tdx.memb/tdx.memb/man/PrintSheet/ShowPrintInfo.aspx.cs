using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
namespace tdx.memb.man.PrintSheet
{
    public partial class ShowPrintInfo : System.Web.UI.Page
    {
        private string orderNO;
        private string orderType;
        private string printType;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sss = Request.Cookies["OrderInfo"].Value;
            this.ReportViewer.Report = null;
            orderNO = Request.QueryString["orderNO"] == null ? "-1" : Request.QueryString["orderNO"].ToString();
            orderType = Request.QueryString["orderType"] == null ? "-1" : Request.QueryString["orderType"].ToString();
            printType = Request.QueryString["printType"] == null ? "" : Request.QueryString["printType"].ToString();
            if (string.IsNullOrEmpty(printType))
                LoadInfo();
            else
                LoadInfoNew();
        }
        private void LoadInfo()
        {
            PrintOrder pEnterPinfo = new PrintOrder(orderNO, orderType);
            pEnterPinfo.ShowPrintStatusDialog = false;
            this.ReportViewer.Report = pEnterPinfo; 
        }

        public Dictionary<string, string> getJson(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            Dictionary<string, string> jsonObject = (Dictionary<string, string>)ser.ReadObject(ms);
            return jsonObject;
        }
        private void LoadInfoNew()
        {

            //string OrderInfo = Request.Params["OrderInfo"];
            //string OrderInfo=Request.Cookies["OrderInfo"].Value;
            string OrderInfo=Request.QueryString["OrderInfo"];
            //{"OrderInfo":[{"orderNO":"S2016042200001","orderType":"WP" },{"orderNO":"S2016042200001","orderType":"WP" },{"orderNO":"S2016042200001","orderType":"WP" }]}
          
            Dictionary<string, string> orderinfo = new Dictionary<string, string>();
            //orderinfo.Add("S2016042200001", "WP");
            //orderinfo.Add("S2016042200002", "WP");
            //orderinfo.Add("S2016042200003", "WP");
            //orderinfo.Add("S2016042200004", "WP");
            //orderinfo.Add("S20160422000034", "WP");
            //orderinfo.Add("S2016042200005", "WP");
            //orderinfo.Add("S20160422000061", "WP");
            //string ss = Newtonsoft.Json.JsonConvert.SerializeObject(orderinfo);
            /*
             
             {"S2016042200001":"WP","S2016042200002":"WP","S2016042200003":"WP","S2016042200004":"WP","S20160422000034":"WP","S2016042200005":"WP","S20160422000061":"WP"}
             //{'S2016042200001':'WP',S2016042300001':'WP'}
             */
            //orderinfo.Clear();
            //orderinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string,string>>(ss);
            orderinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(OrderInfo);
            MultyReport pEnterPinfo = new MultyReport(orderinfo);
            this.ReportViewer.Report = pEnterPinfo;
        }
    }
}