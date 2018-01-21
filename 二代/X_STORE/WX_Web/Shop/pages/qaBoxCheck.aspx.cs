using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using DTcms.Common.Helper;

namespace Wx_NewWeb.Shop.pages
{
    public partial class qaBoxCheck : BasePage
    {

        public string localboxmac = string.Empty;
        public string version = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                localboxmac = Request.QueryString["boxmac"].ObjToStr();
                ViewState["boxmac"] = localboxmac;
               
                PageInit();
            }
        }
     
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
        protected void PageInit()
        {
            var list = new List<numClass>();
            list.Add(new numClass() { num = 1 });
            list.Add(new numClass() { num = 2 });
            list.Add(new numClass() { num = 3 });
            list.Add(new numClass() { num = 4 });
            list.Add(new numClass() { num = 5 });
            list.Add(new numClass() { num = 6 });
            list.Add(new numClass() { num = 7 });
            list.Add(new numClass() { num = 8 });
            list.Add(new numClass() { num = 9 });
            list.Add(new numClass() { num = 10 });
            list.Add(new numClass() { num = 11 });
            list.Add(new numClass() { num = 12 });
            box_rp.DataSource = list;
            box_rp.DataBind();

            //var selectSql = string.Format(@"select isnull(版本号,'') as 版本号 from WP_库位表 where 箱子MAC = '{0}'", localboxmac);
            var selectSql = string.Format(@"SELECT isnull(Version,'') as 版本号 FROM [tshop].[dbo].[WP_BarCode] where BarCode ='{0}'", localboxmac);
            var dt = SqlDataHelper.GetDataTable(selectSql);
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["版本号"].ToString()))
                {
                    version = ((int)(HexStringToByteArray(dt.Rows[0]["版本号"].ToString()).First() & 0xFF)).ToString();
                }
            }
        }
        public class numClass
        {
            public int num{get;set;}
        }
        protected void position_click(object sender, EventArgs e)
        {
            var num = (sender as HtmlAnchor).Attributes["num"].ObjToInt(0) - 1;
            var list = new List<string>();
            list.Add(num.ObjToStr());
            OpenBox(list);
        }
        private void OpenBox(List<string> list)
        {

            var rbh = new RemoteBoxHelper();
            localboxmac = ViewState["boxmac"].ObjToStr();
            var postion_list = list.Aggregate<string>((x, y) => x + "," + y).ToString();
            try
            {
                rbh.OpenRemoteBox("" + localboxmac + "","","" + postion_list + "");
                
                var insert_sql = string.Format(@"INSERT INTO [dbo].[WP_ 开箱记录表]
           ([箱子MAC]
           ,[openid]
           ,[操作人id]
           ,[联系电话]
           ,[操作时间]
           ,[操作日志]
           ,[操作结果])
     VALUES
           ('{0}'
           ,'{1}'
           ,{2}
           ,'{3}'
           ,getdate()
           ,'{4}'
           ,'{5}')", localboxmac, OpenId, UserId, UserInfo["手机号"].ObjToStr(), postion_list + ":执行开箱操作", "开箱成功");
                Log.WriteLog("页面：qaBoxCheck", "方法：qaBoxCheck", "insert_sql：" + insert_sql);
                var b = SqlDataHelper.ExecuteCommand(insert_sql);
                if (b == 0)
                {
                     Response.Write("<script>alert('日志记录失败！')</script>");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("页面：qaBoxCheck", "方法：qaBoxCheck", "异常信息：" + ex.Message);
                RedirectError("");
            }

        }

        protected void openAll_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            list.Add("0"); list.Add("1"); list.Add("2"); list.Add("3"); list.Add("4"); list.Add("5"); list.Add("6");
            list.Add("7"); list.Add("8"); list.Add("9"); list.Add("10"); list.Add("11"); 
            OpenBox(list);
            PageInit();
        }
    }
}