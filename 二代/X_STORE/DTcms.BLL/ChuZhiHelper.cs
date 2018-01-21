using Chanjet.TP.OpenAPI;
using DTcms.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
//using tdx.database.Common_Pay.WeiXinPay;

namespace DTcms.BLL
{
    public class ChuZhiHelper
    {
        OpenAPI TPlusAPI = null;

        public decimal GetChuZhi(string code, string cardcode, string mobilephone)
        {
            if (!isLogined())
            {
                GetToken();
            }
            try
            {
                string param = "{\r\n         dto:{\r\n                   Code:\""+code+"\",\r\n                   CardCode:\""+cardcode+"\",\r\n                   Mobilephone:\""+mobilephone+"\"\r\n         }\r\n}";
                Log.WriteLog("", "", param);
                string result = this.TPlusAPI.Call<string>("member/Query", param);
                Log.WriteLog("", "", "call:member/Query");
                Log.WriteLog("", "", "success:" + result);

                if (result == null || result == "[]" || result == "")
                {
                    return Convert.ToDecimal(0);
                }
                else
                {
                    JArray ja = (JArray)JsonConvert.DeserializeObject(result);
                    Log.WriteLog("", "", "结果:" + ja[0]["BalanceStorage"]);
                    Log.WriteLog("", "", "结果:" +Convert.ToDecimal(ja[0]["BalanceStorage"].ToString()));
                    return Convert.ToDecimal(Convert.ToDecimal(ja[0]["BalanceStorage"].ToString()).ToString("f2"));
                }
            }
            catch (RestException ex)
            {
                Log.WriteLog("", "", "call:member/Query");
                Log.WriteLog("", "", "error:" + ex.Message + "\r\n" + ex.ResponseBody);
                Log.WriteLog("", "", "结果失败");
                return Convert.ToDecimal(0);
            }
        }

        public void UpdatetChuZhi(string order_no, string cardcode,string money)
        {
            if (!isLogined())
            {
                GetToken();
            }
            try
            {
                string param = "{\r\n   dto:{\r\n  VoucherDate: \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\r\n  ExternalCode:\"" + order_no + "\",\r\n   StorageAmount:-" + money + ",\r\n  StorageDetails: [{ \r\n  Member:{CardCode: \"" + cardcode + "\"},\r\n    ThisStorageAmount:-" + money + " \r\n  }],\r\n  StorageMutiSettleDetails: [{ \r\n SettleStyle:{Name:\"会员储值卡\"},\r\n   BankAccount:{Name:\"现金\"},\r\n   StorageAmount:-" + money + "\r\n  }]\r\n  }, param: {\r\n IsAudit:\"true\"\r\n } \r\n  }\r\n ";

                Log.WriteLog("", "", param);
                string result = this.TPlusAPI.Call<string>("memberStorage/Create", param);
                Log.WriteLog("", "", "call:memberStorage/Create");
                Log.WriteLog("", "", "success");

            }
            catch (RestException ex)
            {
                Log.WriteLog("", "", "memberStorage/Create");
                Log.WriteLog("", "", "error:" + ex.Message + "\r\n" + ex.ResponseBody);
                Log.WriteLog("", "", "结果失败");

            }
        }


        bool isLogined()
        {
            if (TPlusAPI != null && !string.IsNullOrEmpty(TPlusAPI.Credentials.Access_Token))
                return true;
            return false;
        }

        private void GetToken()
        {
            //106.14.77.233:8080
            this.TPlusAPI = new OpenAPI("http://127.0.0.1:8080/TPlus/api/v1/", new Credentials()
            {
                AppKey = "6ed52e40-a6cf-4927-91c7-7700339ae0c1",
                AppSecret = "lziluc",
                UserName = "18851500729",
                Password = "wuhan1991",
                LoginDate = DateTime.Now.ToString("yyyy-MM-dd"),
                AccountNumber = "1"
            });

            try
            {
                dynamic r = r = TPlusAPI.GetToken();
                Log.WriteLog("", "", "Call:GetToken \r\n result:success");
            }
            catch (RestException ex)
            {
                Log.WriteLog("", "", "Call:GetToken \r\n error:" + ex.Message);
                if (ex.Code == "EXSM0004")
                {
                    this.btnReLogin_Click();
                }
            }
        }

        private void btnReLogin_Click()
        {
            try
            {
                dynamic r = this.TPlusAPI.ReLogin();

            }
            catch (RestException ex)
            {
            }
        }


    }
}
