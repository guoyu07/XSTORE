using Chloe.MySql;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XStore.WebSite.DBFactory;

namespace XStore.WebSite
{
    public class BasePage:System.Web.UI.Page
    {
        
        public static string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public MySqlContext context ;
        public ILog Log;
        public BasePage() {
            context = new MySqlContext(new MySqlConnectionFactory(connString));
            Log = log4net.LogManager.GetLogger("Weixin.Logging");//获取一个日志记录器
            Log.Info(DateTime.Now.ToString() + ": login success");//写入一条新log

        }
    }
}