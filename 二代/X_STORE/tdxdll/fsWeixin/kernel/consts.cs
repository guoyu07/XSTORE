using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//======================================================
//
//     成熟版网站系统，包括类别管理、品牌管理、产品管理、公告管理
//     新闻管理、页面管理、会员管理、网站配置等。 
//=======================================================

namespace tdx.kernel
{ 
    public static class consts
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Connstr"].ConnectionString;

        //public static string constr = "Data Source=192.168.0.254,1500;Initial Catalog=weixin;Persist Security Info=True;User ID=sa;Password=123456;Connect Timeout=9999";
        public static string baseUrl = "http://" + System.Web.HttpContext.Current.Request.Url.Host.ToString(); //System.Configuration.ConfigurationManager.ConnectionStrings["ConnUrl"].ConnectionString != "" ? System.Configuration.ConfigurationManager.ConnectionStrings["ConnUrl"].ConnectionString : System.Web.HttpContext.Current.Request.Url.Host.ToString();
        
        public static string rootPath = "/";
        public static string loginSkip = "";

        public static string uploadPath = "/upload";
        public static int pic_minSize = 320;
        public static int pic_middelSize = 400;
        public static int pic_maxSize = 800;
        //0为以width为准,1为以height为准
        public static int pic_w_or_h = 0;
        //加水印的图片地址,相对地址，使用时需要server.mappath
        public static string pic_water = "/upload/water/water1.png";
        //加特殊水印的图片地址，相对地址,使用时需要server.mappath
        public static string pic_water_hot = "/upload/water/water1.png";

        public static int pagesize_Pic = 20;

        public static int pagesize_Txt = 20;

        /* 一系列系统运行标准参数 */
        public static double minPrice = 0.3;
        public static double minPrice_local = 1.0;
        public static double zhekou = 0.7;
        public static double zhekou_local = 0.5;
        public static double regPrice = 10;
        public static double regPrice2 = 10;
        public static double yaoPrice = 2;
        public static int yqDay = 3; //任务结束后3天点击有效
        public static int jgMi = 1440; //2011-09-15修正为24小时;2011-09-15修正为12小时;任务点击同IP间隔30分钟
        public static DateTime cons_Bdate = Convert.ToDateTime("2013-01-01");
        
        public static int getConfig(string keyname)
        {
            return Convert.ToInt32(comEncrypt.jiemi(System.Web.Configuration.WebConfigurationManager.AppSettings[keyname]));
        }
         
     }
}