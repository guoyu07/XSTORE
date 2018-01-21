using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ahomet.Web.Controls
{
    public class WebSource
    {
        /// <summary>
        /// 注册地址
        /// </summary>
        /// <returns></returns>
        public static string GetRegisterUrl()
        {
            return "Ahomet.Web.Controls.";
        }
        /// <summary>
        /// 获取扩展名
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetExt(string input)
        {
            return input.Substring(input.LastIndexOf(".") + 1);
        }
        /// <summary>
        /// 增加 /控件/ 资源
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <param name="page"></param>
        public static void AddControls(string name, string key, Page page)
        {
            string ext = GetExt(name);
            string dir = GetRegisterUrl();
            switch (ext)
            {
                case "css":
                    string css = "<link type=\"text/css\" href=\"" + page.ClientScript.GetWebResourceUrl(typeof(WebSource), dir + "css." + name) + "\" rel=\"stylesheet\" />\r";
                    Literal li = new Literal();
                    li.ID = key;
                    li.Text = css;
                    page.Header.Controls.Add(li);
                    break;
                case "js":
                    string script = "<script src=\"" + page.ClientScript.GetWebResourceUrl(typeof(WebSource), dir + "js." + name) + "\" type=\"text/javascript\"></script>\r";
                    page.ClientScript.RegisterStartupScript(page.GetType(), key, script, false);
                    break;
                case "gif":
                case "png":
                case "jpg":

                    break;
            }
        }
        /// <summary>
        /// 增加 /控件脚本 /资源
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        public static void AddControlsScriptResource(string name, Page page)
        {
            string ext = GetExt(name);
            string dir = GetRegisterUrl();
            switch (ext)
            {
                case "js":
                    page.ClientScript.RegisterClientScriptResource(typeof(WebSource), dir + "js." + name);
                    break;
            }
        }
        /// <summary>
        /// 获取 /控件目录 /下资源URL地址
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string GetControlsResourceUrl(string name, Page page)
        {
            string ext = GetExt(name);
            string dir = GetRegisterUrl();
            switch (ext)
            {
                case "gif":
                case "png":
                case "jpg":
                    ext = "images";
                    break;
            }
            return page.ClientScript.GetWebResourceUrl(typeof(WebSource), dir + ext + "." + name);
        }
    }
}
