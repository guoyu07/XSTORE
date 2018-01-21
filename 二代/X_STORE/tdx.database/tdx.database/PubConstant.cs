using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxes.DBUtility
{
    public class PubConstant
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                if (ConfigurationManager.AppSettings["ConnectionString"] == null)//客户端连接下面
                {
                    // _connectionString = "Data Source=120.26.129.244;Initial Catalog=smartHotel;Persist Security Info=True;User ID=sa;Password=AIling13382207296";
                    //_connectionString = "Data Source=139.196.15.45;Initial Catalog=smartHotel;Persist Security Info=True;User ID=sa;Password=!@#123qaz";
                    // _connectionString = "Data Source=.;Initial Catalog=smartHotel;Persist Security Info=True;User ID=sa;Password=!@#123qaz";
                    // _connectionString = "Data Source=.;Initial Catalog=ZHJJ;Persist Security Info=True;User ID=sa;Password=221867cf";
                    //_connectionString = "Data Source=120.26.129.244;Initial Catalog=muxian;Persist Security Info=True;User ID=sa;Password=!sa10hokkai";
                    _connectionString = "Data Source=139.199.160.173;Initial Catalog=tshop;Persist Security Info=True;User ID=xxx;Password=123456";
                    // _connectionString = "Data Source=.;Initial Catalog=muxian;Persist Security Info=True;User ID=sa;Password=tx!@#123tx";
                    // _connectionString = "Data Source=.;Initial Catalog=muxian;Persist Security Info=True;User ID=sa;Password=221867cf";


                }
                return _connectionString;
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];

            return connectionString;
        }
    }
}
