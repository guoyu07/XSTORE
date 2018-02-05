using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common;
using XStore.Common.Helper;
using XStore.Entity;
using XStore.Entity.Model;

namespace XStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenBox();

        }
        private static void SetMacList() {
            var requestUrl = string.Format("{0}test/cabinets?page=0&size=1000 ", Constant.YunApi);
            var response = JsonConvert.DeserializeObject<JObject>(Utils.HttpGet(requestUrl));
            if (response["operationStatus"].ObjToStr().Equals("SUCCESS"))
            {
                var arrList = JsonConvert.DeserializeObject<JArray>(response["operationMessage"].ObjToStr());
                List<OnlineBox> macList = new List<OnlineBox>();

                foreach (var arr in arrList)
                {
                    var sub = JsonConvert.DeserializeObject<JArray>(arr.ToString());
                    var mac = new OnlineBox();
                    mac.mac = sub[0].ObjToStr();
                    mac.online = sub[1].ObjToInt(0) == 0 ? false : true;
                    mac.lineTime = DateTime.Now;
                    macList.Add(mac);
                }
                CacheHelper.SetCache("Boxes", macList);
            }

        }
        private static void OpenBox() {
            var rbh = new RemoteBoxHelper();
            rbh.OpenRemoteBox("861853033030503", "00000010", "1");
        }
    }
}
