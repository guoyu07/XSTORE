using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Data;

namespace tdx.kernel
{
    /// <summary>
    /// 一些通用的函数
    /// </summary>
    /// <remarks></remarks>

    public class comFunction
    {
        /// <summary>
        /// 获得字符串右侧的部分
        /// </summary>
        /// <param name="StrValue">字符串</param>
        /// <param name="CharValue">界定右侧的字符</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetRightByChar(string StrValue, string CharValue)
        {
            string[] MyStr = Regex.Split(StrValue, CharValue);
            return MyStr[MyStr.Length - 1];
        }


        /// <summary>
        /// 获得用户的登录ID地址
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int GetUserLoginID()
        {
            //If HttpContext.Current.Session("UserID") = Nothing Then Throw New NotSupportedException("用户登录信息丢失，请重新登录！")
            //Return HttpContext.Current.Session("UserID")
            return 13;
        }

        /// <summary>
        /// 获得当前页面的Url
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public string GetNowUrl()
        {
            string[] P = System.Web.HttpContext.Current.Request.ServerVariables["PATH_INFO"].Split('/');
            string FileName = P[P.Length - 1];
            if (string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"]))
            {
                return FileName;
            }
            else
            {
                return FileName + "?" + System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"];
            }
        }

        /// <summary>
        /// 获得时间的月份值形式
        /// </summary>
        /// <param name="Dates">日期型</param>
        /// <returns>返回类似：200705格式</returns>
        /// <remarks></remarks>
        public static object GetMonth(System.DateTime Dates)
        {
            return Dates.Year + String.Format(Dates.Month.ToString(), "00");
        }

        /// <summary>
        /// 返回类似“2007-06-15”格式
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetDate(System.DateTime dates)
        {
            return dates.Year + "-" + String.Format(dates.Month.ToString(), "00") + "-" + String.Format(dates.Day.ToString(), "00");
        }
        /// <summary>
        /// 返回现在时间的"2007-06-15"格式
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string getNowAsString()
        {
            return String.Format("{0:yyyy-MM-dd}", System.DateTime.Now);//.Year + "-" + String.Format("0:yyyy-MM-dd",System.DateTime.Now.Month) + "-" + String.Format(System.DateTime.Now.Day.ToString(), "00");
        }

        /// <summary>
        /// 返回小数点后面2位
        /// </summary>
        public string GetStrByDec(decimal D)
        {
            string Str = D.ToString().TrimEnd('0').TrimEnd('.');
            if (Str == "")
            {
                return "0";
            }
            else
            {
                return Str;
            }
        }

        public static string NoHTML(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", @"""", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", @"\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", @"\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", @"\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", @"\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring = System.Web.HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        /// <summary>
        /// 过滤脚本
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoSt(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            return Htmlstring;
        }


        public static string getSubStr(String s, int len)
        {
            s = NoHTML(s);
            if (s.Length < len)
                return s;
            else
                return s.Substring(0, 100) + "...";

        }

        public static string GetArrowHtml(int _ipage, int totalcount, string _type)
        {
            string result = "";
            int _totalpage = totalcount / consts.pagesize_Pic;
            if (totalcount % consts.pagesize_Pic != 0)
            {
                _totalpage = _totalpage + 1;
            }
            int forwardpage = _ipage - 1;
            if (forwardpage < 1)
            {
                forwardpage = 1;
            }
            int backpage = _ipage + 1;
            if (backpage > _totalpage)
            {
                backpage = _totalpage;
            }

            //页数多于1页时才显示分页控制器
            if (_totalpage > 1)
            {

                //存在分页控制器即存在"上一页"按钮
                if (_ipage == 1)
                {
                    result += "<a class=\"prev\">上一页</a>" + "\n";
                }
                else
                {
                    //if (_ipage - 1 == 1)
                    //{
                    result += "<a class=\"prev\" href='?" + _type + "&page=" + forwardpage + "'>上一页</a>" + "\n";
                    //}
                    //else
                    //{
                    //    result += "<a class=\"prev\" href='?" + _type + "&page=" + forwardpage + "'>上一页</a>" + "\n";
                    //}
                }

                //直接输出分页页码,不存在翻页后的...控制
                if (_totalpage < 12)//12
                {
                    for (int _tmppage = 1; _tmppage <= _totalpage; _tmppage++)
                    {
                        string cclassname = "arrow_num";
                        if (_tmppage == _ipage)
                        {
                            cclassname = "pagecurr";
                        }
                        //if (_tmppage == 1)
                        //{
                        result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                        //}
                        //else
                        //{
                        //    result += "<a class=\"" + cclassname + "\" href='" + _type + "_" + _tmppage + ".html'> " + _tmppage + " </a>" + "\n";
                        //}
                    }
                    //多于12页,需要存在...控制
                }
                else
                {
                    //前半部分,1~9,直接显示成页码框
                    if (_ipage < 10)//10
                    {
                        for (int _tmppage = 1; _tmppage <= 5; _tmppage++)
                        {
                            string cclassname = "arrow_num";
                            if (_tmppage == _ipage)
                            {
                                cclassname = "pagecurr";
                            }
                            //if (_tmppage == 1)
                            //{
                            //    result += "<a class=\"" + cclassname + "\" href='" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                            //}
                            //else
                            //{
                            result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                            //}
                        }
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        //<div class="null">...</div>
                        result += "<a href='?" + _type + "&page=" + _totalpage + "'> " + _totalpage + " </a>" + "\n";
                        //当ipage>=10页时,前半部分,1 ... 然后后面的
                    }
                    else
                    {
                        result += "<a href='?" + _type + "'> 1 </a>" + "\n";
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        //后半段也需要...
                        if ((_totalpage - _ipage) > 5)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= (_ipage + 4); _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='" + _type + "_" + _tmppage + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                            result += "<span class=\"pagetext\">...</span>" + "\n";
                            //<div class="null">...</div>
                            result += "<a href='?" + _type + "&page=" + _totalpage + "'> " + _totalpage + " </a>" + "\n";
                            //后半段不需要...,并且从ipage-2开始
                        }
                        else if ((_totalpage - _ipage) > 2)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='?" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                            //后半段不需要...,并且从7-ipage处开始
                        }
                        else
                        {
                            for (int _tmppage = (_totalpage - 6); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                        }
                    }
                }

                //存在分页控制器,即存在"下一页"按钮
                if (_ipage == _totalpage)
                {
                    result += "<a class=\"next\">下一页</a>" + "\n";
                }
                else
                {
                    if (_ipage + 1 == 1)
                    {
                        result += "<a class=\"next\" href='?" + _type + "'>下一页</a>" + "\n";
                    }
                    else
                    {
                        result += "<a class=\"next\" href='?" + _type + "&page=" + (_ipage + 1) + "'>下一页</a>" + "\n";
                    }
                }

            }
            return result;
        }

        public static string GetArrowHtml2(int _ipage, int totalcount, string _type)
        {
            string result = "";
            int _totalpage = totalcount / consts.pagesize_Txt;
            if (totalcount % consts.pagesize_Txt != 0)
            {
                _totalpage = _totalpage + 1;
            }
            int forwardpage = _ipage - 1;
            if (forwardpage < 1)
            {
                forwardpage = 1;
            }
            int backpage = _ipage + 1;
            if (backpage > _totalpage)
            {
                backpage = _totalpage;
            }

            //页数多于1页时才显示分页控制器
            if (_totalpage > 1)
            {

                //存在分页控制器即存在"上一页"按钮
                if (_ipage == 1)
                {
                    result += "<a class=\"prev\">上一页</a>" + "\n";
                }
                else
                {
                    //if (_ipage - 1 == 1)
                    //{
                    result += "<a class=\"prev\" href='?" + _type + "&page=" + forwardpage + "'>上一页</a>" + "\n";
                    //}
                    //else
                    //{
                    //    result += "<a class=\"prev\" href='?" + _type + "&page=" + forwardpage + "'>上一页</a>" + "\n";
                    //}
                }

                //直接输出分页页码,不存在翻页后的...控制
                if (_totalpage < 12)//12
                {
                    for (int _tmppage = 1; _tmppage <= _totalpage; _tmppage++)
                    {
                        string cclassname = "arrow_num";
                        if (_tmppage == _ipage)
                        {
                            cclassname = "pagecurr";
                        }
                        //if (_tmppage == 1)
                        //{
                        result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                        //}
                        //else
                        //{
                        //    result += "<a class=\"" + cclassname + "\" href='" + _type + "_" + _tmppage + ".html'> " + _tmppage + " </a>" + "\n";
                        //}
                    }
                    //多于12页,需要存在...控制
                }
                else
                {
                    //前半部分,1~9,直接显示成页码框
                    if (_ipage < 10)//10
                    {
                        for (int _tmppage = 1; _tmppage <= 5; _tmppage++)
                        {
                            string cclassname = "arrow_num";
                            if (_tmppage == _ipage)
                            {
                                cclassname = "pagecurr";
                            }
                            //if (_tmppage == 1)
                            //{
                            //    result += "<a class=\"" + cclassname + "\" href='" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                            //}
                            //else
                            //{
                            result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                            //}
                        }
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        //<div class="null">...</div>
                        result += "<a href='?" + _type + "&page=" + _totalpage + "'> " + _totalpage + " </a>" + "\n";
                        //当ipage>=10页时,前半部分,1 ... 然后后面的
                    }
                    else
                    {
                        result += "<a href='?" + _type + "'> 1 </a>" + "\n";
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        //后半段也需要...
                        if ((_totalpage - _ipage) > 5)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= (_ipage + 4); _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='" + _type + "_" + _tmppage + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                            result += "<span class=\"pagetext\">...</span>" + "\n";
                            //<div class="null">...</div>
                            result += "<a href='?" + _type + "&page=" + _totalpage + "'> " + _totalpage + " </a>" + "\n";
                            //后半段不需要...,并且从ipage-2开始
                        }
                        else if ((_totalpage - _ipage) > 2)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='?" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                            //后半段不需要...,并且从7-ipage处开始
                        }
                        else
                        {
                            for (int _tmppage = (_totalpage - 6); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                result += "<a class=\"" + cclassname + "\" href='?" + _type + "&page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                        }
                    }
                }

                //存在分页控制器,即存在"下一页"按钮
                if (_ipage == _totalpage)
                {
                    result += "<a class=\"next\">下一页</a>" + "\n";
                }
                else
                {
                    if (_ipage + 1 == 1)
                    {
                        result += "<a class=\"next\" href='?" + _type + "'>下一页</a>" + "\n";
                    }
                    else
                    {
                        result += "<a class=\"next\" href='?" + _type + "&page=" + (_ipage + 1) + "'>下一页</a>" + "\n";
                    }
                }

            }
            return result;
        }

        //2011-09-16日修改作为重点前台界面，包含css样式。【静态页面】
        public static string GetArrowHtml3(int _ipage, int totalcount, string _myFile)
        {
            return GetArrowHtml3(_ipage, totalcount, _myFile, consts.pagesize_Txt);
        }
        public static string GetArrowHtml3(int _ipage, int totalcount, string _myFile, int _pagesize)
        {
            string result = "";
            //添加样式
            result += "\n <style>";
            result += "\n";
            result += "\n.page_fenye{display:inline;margin:0 auto;padding:0;overflow:hidden;}";
            result += "\n.prev,.arrow_num,.next{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 20px;border:1px solid #cccccc;font-weight: bolder;}";
            result += "\n.pagecurr{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 20px;color: #FF6600;border:1px solid #FF6600;font-weight: bolder;}";
            result += "\n";
            result += "\n </style>";
            //文件划分
            int lastIndexPoint = _myFile.LastIndexOf(".");
            string myFile_first = _myFile.Substring(0, lastIndexPoint);
            string myFile_ext = _myFile.Substring(lastIndexPoint, _myFile.Length - lastIndexPoint);

            int _totalpage = totalcount / _pagesize;
            if (totalcount % _pagesize != 0)
            {
                _totalpage = _totalpage + 1;
            }
            int forwardpage = _ipage - 1;
            if (forwardpage < 1)
            {
                forwardpage = 1;
            }
            int backpage = _ipage + 1;
            if (backpage > _totalpage)
            {
                backpage = _totalpage;
            }

            //页数多于1页时才显示分页控制器
            if (_totalpage > 1)
            {
                //存在分页控制器即存在"上一页"按钮
                if (_ipage == 1)
                {
                    result += "<a class=\"prev\">PREV.</a>" + "\n";
                }
                else
                {
                    result += "<a class=\"prev\" href='" + (forwardpage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + forwardpage + myFile_ext)) + "'>PREV.</a>" + "\n";
                }


                if (_totalpage < 12)//12//直接输出分页页码,不存在翻页后的...控制
                {
                    for (int _tmppage = 1; _tmppage <= _totalpage; _tmppage++)
                    {
                        string cclassname = "arrow_num";
                        if (_tmppage == _ipage)
                        {
                            cclassname = "pagecurr";
                        }
                        result += "<a class=\"" + cclassname + "\" href='" + (_tmppage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + _tmppage + myFile_ext)) + "'> " + _tmppage + " </a>" + "\n";
                    }
                }
                else //多于12页,需要存在...控制
                {
                    if (_ipage < 6)//10//前半部分,1~5,直接显示成页码框
                    {
                        for (int _tmppage = 1; _tmppage <= 5; _tmppage++)
                        {
                            string cclassname = "arrow_num";
                            if (_tmppage == _ipage)
                            {
                                cclassname = "pagecurr";
                            }
                            result += "<a class=\"" + cclassname + "\" href='" + (_tmppage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + _tmppage + myFile_ext)) + "'> " + _tmppage + " </a>" + "\n";
                        }
                        result += "<span class=\"pagetext\">...</span>" + "\n";

                        result += "<a class=\"pagetext\" href='" + (_totalpage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + _totalpage + myFile_ext)) + "'> " + _totalpage + " </a>" + "\n";
                    }
                    else
                    {
                        result += "<a href='" + (myFile_first + myFile_ext) + "'> 1 </a>" + "\n";
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        if ((_totalpage - _ipage) > 5)//后半段也需要...
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= (_ipage + 4); _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='" + (_tmppage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + _tmppage + myFile_ext)) + "'> " + _tmppage + " </a>" + "\n";
                            }
                            result += "<span class=\"pagetext\">...</span>" + "\n";
                            result += "<a class=\"pagetext\" href='" + (_totalpage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + _totalpage + myFile_ext)) + "'> " + _totalpage + " </a>" + "\n";
                        }
                        else if ((_totalpage - _ipage) > 2)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='" + (_tmppage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + _tmppage + myFile_ext)) + "'> " + _tmppage + " </a>" + "\n";
                            }
                            //后半段不需要...,并且从7-ipage处开始
                        }
                        else
                        {
                            for (int _tmppage = (_totalpage - 6); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='" + (_tmppage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + _tmppage + myFile_ext)) + "'> " + _tmppage + " </a>" + "\n";
                            }
                        }
                    }
                }

                //存在分页控制器,即存在"下一页"按钮
                if (_ipage == _totalpage)
                {
                    result += "<a class=\"next\"> NEXT </a>" + "\n";
                }
                else
                {
                    result += "<a class=\"next\" href='" + (backpage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + backpage + myFile_ext)) + "'> NEXT </a>" + "\n";
                }

            }
            return result;
        }

        //2011-09-25日修改作为重点前台界面,包含css样式.【动态页面】
        public static string GetArrowHtml4(int _ipage, int totalcount, string _type)
        {
            return GetArrowHtml4(_ipage, totalcount, _type, consts.pagesize_Txt);
        }
        public static string GetArrowHtml4(int _ipage, int totalcount, string _type, int _pagesize)
        {
            string result = "";
            //添加样式
            result += "\n <br /><style>";
            result += "\n";
            result += "\n.page_fenye{display:inline;margin:0 auto;padding:0;overflow:hidden;}";
            result += "\n.prev,.arrow_num,.next{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 20px;border:1px solid #cccccc;font-weight: bolder;}";
            result += "\n.pagecurr{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 20px;color: #FF6600;border:1px solid #FF6600;font-weight: bolder;}";
            result += "\n";
            result += "\n </style> <br />";

            int _totalpage = totalcount / _pagesize;
            if (totalcount % _pagesize != 0)
            {
                _totalpage = _totalpage + 1;
            }
            int forwardpage = _ipage - 1;
            if (forwardpage < 1)
            {
                forwardpage = 1;
            }
            int backpage = _ipage + 1;
            if (backpage > _totalpage)
            {
                backpage = _totalpage;
            }

            //页数多于1页时才显示分页控制器
            if (_totalpage > 1)
            {
                //存在分页控制器即存在"上一页"按钮
                if (_ipage == 1)
                {
                    result += "<a class=\"prev\">上一页</a>" + "\n";
                }
                else
                {
                    result += "<a class=\"prev\" href='?page=" + forwardpage + "&" + _type + "'>上一页</a>" + "\n";
                }


                if (_totalpage < 12)//12//直接输出分页页码,不存在翻页后的...控制
                {
                    for (int _tmppage = 1; _tmppage <= _totalpage; _tmppage++)
                    {
                        string cclassname = "arrow_num";
                        if (_tmppage == _ipage)
                        {
                            cclassname = "pagecurr";
                        }
                        result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "&" + _type + "'> " + _tmppage + " </a>" + "\n";
                    }
                }
                else //多于12页,需要存在...控制
                {
                    if (_ipage < 6)//10//前半部分,1~5,直接显示成页码框
                    {
                        for (int _tmppage = 1; _tmppage <= 5; _tmppage++)
                        {
                            string cclassname = "arrow_num";
                            if (_tmppage == _ipage)
                            {
                                cclassname = "pagecurr";
                            }
                            result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "&" + _type + "'> " + _tmppage + " </a>" + "\n";
                        }
                        result += "<span class=\"pagetext\">...</span>" + "\n";

                        result += "<a class=\"pagetext\" href='?page=" + _totalpage + "&" + _type + "'> " + _totalpage + " </a>" + "\n";
                    }
                    else
                    {
                        result += "<a href='?page=1&" + _type + "'> 1 </a>" + "\n";
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        if ((_totalpage - _ipage) > 5)//后半段也需要...
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= (_ipage + 4); _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "&" + _type + "'> " + _tmppage + " </a>" + "\n";
                            }
                            result += "<span class=\"pagetext\">...</span>" + "\n";
                            result += "<a class=\"pagetext\" href='?page=" + _totalpage + "&" + _type + "'> " + _totalpage + " </a>" + "\n";
                        }
                        else if ((_totalpage - _ipage) > 2)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "&" + _type + "'> " + _tmppage + " </a>" + "\n";
                            }
                            //后半段不需要...,并且从7-ipage处开始
                        }
                        else
                        {
                            for (int _tmppage = (_totalpage - 6); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "&" + _type + "'> " + _tmppage + " </a>" + "\n";
                            }
                        }
                    }
                }

                //存在分页控制器,即存在"下一页"按钮
                if (_ipage == _totalpage)
                {
                    result += "<a class=\"next\"> 下一页 </a>" + "\n";
                }
                else
                {
                    result += "<a class=\"next\" href='?page=" + backpage + "&" + _type + "'> 下一页 </a>" + "\n";
                }

            }
            return result;
        }

        public static string GetArrowHtmlAJAX(int _ipage, int totalcount, string _type)
        {
            string result = "";
            int _totalpage = totalcount / consts.pagesize_Txt;
            if (totalcount % consts.pagesize_Txt != 0)
            {
                _totalpage = _totalpage + 1;
            }
            int forwardpage = _ipage - 1;
            if (forwardpage < 1)
            {
                forwardpage = 1;
            }
            int backpage = _ipage + 1;
            if (backpage > _totalpage)
            {
                backpage = _totalpage;
            }

            //页数多于1页时才显示分页控制器
            if (_totalpage > 1)
            {

                //存在分页控制器即存在"上一页"按钮
                if (_ipage == 1)
                {
                    result += "<a class=\"prev\">上一页</a>" + "\n";
                }
                else
                {
                    //if (_ipage - 1 == 1)
                    //{
                    result += "<a class=\"prev\" href='####' onClick='fenye(\"" + _type + "\",\"" + forwardpage + "\");'>上一页</a>" + "\n";
                    //}
                    //else
                    //{
                    //    result += "<a class=\"prev\" href='?" + _type + "&page=" + forwardpage + "'>上一页</a>" + "\n";
                    //}
                }

                //直接输出分页页码,不存在翻页后的...控制
                if (_totalpage < 12)//12
                {
                    for (int _tmppage = 1; _tmppage <= _totalpage; _tmppage++)
                    {
                        string cclassname = "arrow_num";
                        if (_tmppage == _ipage)
                        {
                            cclassname = "pagecurr";
                        }
                        //if (_tmppage == 1)
                        //{
                        result += "<a class=\"" + cclassname + "\" href='####' onClick='fenye(\"" + _type + "\",\"" + _tmppage + "\");'> " + _tmppage + " </a>" + "\n";
                        //}
                        //else
                        //{
                        //    result += "<a class=\"" + cclassname + "\" href='" + _type + "_" + _tmppage + ".html'> " + _tmppage + " </a>" + "\n";
                        //}
                    }
                    //多于12页,需要存在...控制
                }
                else
                {
                    //前半部分,1~9,直接显示成页码框
                    if (_ipage < 10)//10
                    {
                        for (int _tmppage = 1; _tmppage <= 5; _tmppage++)
                        {
                            string cclassname = "arrow_num";
                            if (_tmppage == _ipage)
                            {
                                cclassname = "pagecurr";
                            }
                            //if (_tmppage == 1)
                            //{
                            //    result += "<a class=\"" + cclassname + "\" href='" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                            //}
                            //else
                            //{
                            result += "<a class=\"" + cclassname + "\" href='####' onClick='fenye(\"" + _type + "\",\"" + _tmppage + "\");'> " + _tmppage + " </a>" + "\n";
                            //}
                        }
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        //<div class="null">...</div>
                        result += "<a href='####' onClick='fenye(\"" + _type + "\",\"" + _totalpage + "\")'> " + _totalpage + " </a>" + "\n";
                        //当ipage>=10页时,前半部分,1 ... 然后后面的
                    }
                    else
                    {
                        result += "<a href='####' onClick='fenye(\"" + _type + "\",\"1\")'> 1 </a>" + "\n";
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        //后半段也需要...
                        if ((_totalpage - _ipage) > 5)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= (_ipage + 4); _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                result += "<a class=\"" + cclassname + "\" href='####' onClick='fenye(\"" + _type + "\",\"" + _tmppage + "\")'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='" + _type + "_" + _tmppage + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                            result += "<span class=\"pagetext\">...</span>" + "\n";
                            //<div class="null">...</div>
                            result += "<a href='####' onClick='fenye(\"" + _type + "\",\"" + _totalpage + "\")'> " + _totalpage + " </a>" + "\n";
                            //后半段不需要...,并且从ipage-2开始
                        }
                        else if ((_totalpage - _ipage) > 2)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='?" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                result += "<a class=\"" + cclassname + "\" href='####' onClick='fenye(\"" + _type + "\",\"" + _tmppage + "\");'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                            //后半段不需要...,并且从7-ipage处开始
                        }
                        else
                        {
                            for (int _tmppage = (_totalpage - 6); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                //if (_tmppage == 1)
                                //{
                                //    result += "<a class=\"" + cclassname + "\" href='" + _type + ".html'> " + _tmppage + " </a>" + "\n";
                                //}
                                //else
                                //{
                                result += "<a class=\"" + cclassname + "\" href='####' onClick='fenye(\"" + _type + "\",\"" + _tmppage + "\");'> " + _tmppage + " </a>" + "\n";
                                //}
                            }
                        }
                    }
                }

                //存在分页控制器,即存在"下一页"按钮
                if (_ipage == _totalpage)
                {
                    result += "<a class=\"next\">下一页</a>" + "\n";
                }
                else
                {
                    if (_ipage + 1 == 1)
                    {
                        result += "<a class=\"next\" href='####' onClick='fenye(\"" + _type + "\",\"1\")'>下一页</a>" + "\n";
                    }
                    else
                    {
                        result += "<a class=\"next\" href='####' onClick='fenye(\"" + _type + "\",\"" + (_ipage + 1) + "\")'>下一页</a>" + "\n";
                    }
                }

            }
            return result;
        }

        public static string GetAddressByIP(string _ips)
        {
            //QQWry qq = new QQWry(HttpContext.Current.Server.MapPath("/master/config/qqwry.dat"));
            QQWry qq = new QQWry("d:/w724/tdx/db/qqwry.dat");
            IPLocation ip = qq.SearchIPLocation(_ips);//这里添写IP地址
            string adress = ip.country + ip.area;
            return adress;
        }

        public static string Guolv(string _source)
        {
            string[] mgc = { "MADA", "mada", "fuck", "FUCK" };
            foreach (string s in mgc)
            {
                string s1 = "";
                for (int i = 0; i < s.Length; i++)
                    s1 += s.Substring(i, 1) + "-";
                _source = _source.Replace(s, s1);
            }
            return _source.Replace(" ", "");
        }

        #region "登录后台首页菜单"
        
        public static string CreateShop()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("<div class=\"lv1\"> \r\n");
            sbResult.Append("  <div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append(" <a class=\"index_menu_title\" href=\"javascript:void(0)\">微商城</a> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<div class=\"index_menu\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv2\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Shop_Config.aspx\" target=\"mainFram\">商城配置</a> \r\n");
            sbResult.Append(" </div> \r\n");


            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Goods_List.aspx\" target=\"mainFram\">产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append(" <div class=\"lv3\"> \r\n");
            sbResult.Append("<a href=\"/memb/Goods/B2C_category_List.aspx\" target=\"mainFram\">产品类别</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  <div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_brand_List.aspx\" target=\"mainFram\">产品品牌</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Goods_List.aspx\" target=\"mainFram\">产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");
            ////////////////////////////////////////////////////////////////////
            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Vip_List.aspx\" target=\"mainFram\">会员特权产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Vip_List.aspx\" target=\"mainFram\">特权产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");
            ////////////////////////////

            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_JiFen_List.aspx\" target=\"mainFram\">会员积分兑换产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_JiFen_List.aspx\" target=\"mainFram\">积分兑换产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");

            /////////////////////////
            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_taocan_List.aspx\" target=\"mainFram\">打包套餐产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_taocan_List.aspx\" target=\"mainFram\">打包套餐产品添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");

            /////////////////////////


            sbResult.Append("<div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <a class=\"index_menu2_title\" href=\"javascript:void(0)\">订单管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append(" <div class=\"lv3\"> \r\n");
            sbResult.Append("  <a href=\"/memb/Goods/B2C_order_List.aspx\" target=\"mainFram\">订单查询</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/reg_advance.aspx\" target=\"mainFram\">订单导出</a> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append(" <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append(" <a class=\"index_menu2_title\" href=\"/memb/Goods/Action_TeamList.aspx\" target=\"mainFram\">团购管理</a> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append(" <div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/Action_TeamList.aspx\" target=\"mainFram\">团购列表</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append("<a href=\"/memb/Goods/tm_order_List.aspx\" target=\"mainFram\">团购订单</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<div class=\"lv2\"> \r\n");
            sbResult.Append(" <div class=\"arrow\"> \r\n");

            sbResult.Append(" </div> \r\n");
            sbResult.Append(" <a class=\"index_menu2_title\" href=\"/memb/Goods/Action_MsList.aspx\" target=\"mainFram\">秒杀管理</a> \r\n");

            sbResult.Append("</div> \r\n");

            sbResult.Append("<div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");

            sbResult.Append("   <div class=\"lv3\"> \r\n");

            sbResult.Append("<a href=\"/memb/Goods/Action_MsList.aspx\" target=\"mainFram\">秒杀设置</a> \r\n");

            sbResult.Append(" </div> \r\n");

            sbResult.Append(" <div class=\"lv3\"> \r\n");

            sbResult.Append("<a href=\"/memb/Goods/ms_order_List.aspx\" target=\"mainFram\">秒杀订单</a> \r\n");

            sbResult.Append("    </div> \r\n");
            sbResult.Append("</div>  \r\n");
            sbResult.Append(" </div>  \r\n");
            sbResult.Append("  </div>  \r\n");
            sbResult.Append("</div>  \r\n");

            //        <%--     <div class="lv2"><div class="arrow"></div><a class="index_menu2_title" href="javascript:void(0)">预定管理</a></div>
            //<div class="index_menu2">
            //    <div>
            //        <div class="lv3"><a href="/memb/reg_advance.aspx" target="mainFram">预订设置</a> </div>
            //        <div class="lv3"><a href="/memb/reg_advance.aspx" target="mainFram">预订订单</a> </div>
            //    </div>
            //</div>
            //<div class="lv2"><div class="arrow"></div><a class="index_menu2_title" href="javascript:void(0)">订餐管理</a></div>
            //<div class="index_menu2">
            //    <div>
            //        <div class="lv3"><a href="/memb/reg_advance.aspx" target="mainFram">订餐管理</a> </div>
            //        <div class="lv3"><a href="/memb/reg_advance.aspx" target="mainFram">订餐订单</a> </div>
            //    </div>
            //</div>--%>
            return sbResult.ToString();
        }
        public static string CreateWeb()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("		<div class=\"lv1\">");
            sbResult.Append("                    <div class=\"arrow\">");
            sbResult.Append("                    </div>");
            sbResult.Append("                    <a class=\"index_menu_title\" href=\"javascript:void(0)\">微官网</a>");
            sbResult.Append("                </div>");
            sbResult.Append("                <div class=\"index_menu\">");
            sbResult.Append("                    <div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                            <a href=\"/memb/Sets/wxConfig_mb.aspx\" target=\"mainFram\">网站模板选择</a>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                            <a href=\"/memb/ads/B2C_ADS_Add2.aspx?cno=009\" target=\"mainFram\">首页幻灯片设置</a>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                            <a href=\"/memb/ads/B2C_ADS_Add3.aspx\" target=\"mainFram\">背景图片设置</a>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                            <a href=\"/memb/Sets/B2C_menu_list.aspx\" target=\"mainFram\">首页栏目设置</a>");
            sbResult.Append("                       </div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                            <div class=\"arrow\"></div>");
            sbResult.Append("                            <a class=\"index_menu2_title\" href=\"/memb/Texts/B2C_Tmsg_list.aspx\" target=\"mainFram\">");
            sbResult.Append("                                图文添加</a>");
            sbResult.Append("                           </div>");
            sbResult.Append("");
            sbResult.Append("                        <div class=\"index_menu2\">");
            sbResult.Append("                            <div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/B2C_Tclass_list.aspx\" target=\"mainFram\">图文类别编辑</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/B2C_Tmsg_list.aspx\" target=\"mainFram\">图文内容添加</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                            </div>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                            <div class=\"arrow\">");
            sbResult.Append("                            </div>");
            sbResult.Append("                            <a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Goods_list.aspx\" target=\"mainFram\">");
            sbResult.Append("                                产品添加</a>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"index_menu2\">");
            sbResult.Append("                            <div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Goods/B2C_category_list.aspx\" target=\"mainFram\">产品类别编辑</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Goods/B2C_Goods_list.aspx\" target=\"mainFram\">产品内容添加</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                            </div>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                            <div class=\"arrow\">");
            sbResult.Append("                            </div>");
            sbResult.Append("                            <a class=\"index_menu2_title\" href=\"/memb/Texts/B2C_Tpage_list.aspx\" target=\"mainFram\">");
            sbResult.Append("                                通用页面</a>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"index_menu2\">");
            sbResult.Append("                            <div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/B2C_Tpage_list.aspx\" target=\"mainFram\">页面内容编辑</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/B2c_TPageClassList.aspx\" target=\"mainFram\">页面类别编辑</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                            </div>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                            <div class=\"arrow\">");
            sbResult.Append("                            </div>");
            sbResult.Append("                            <a class=\"index_menu2_title\" href=\"/memb/Texts/B2C_honor_list.aspx\" target=\"mainFram\">");
            sbResult.Append("                                图片管理</a>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"index_menu2\">");
            sbResult.Append("                            <div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/B2C_Hclass_list.aspx\" target=\"mainFram\">图片类别设置</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/B2C_honor_list.aspx\" target=\"mainFram\">图片上传</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                            </div>");
            sbResult.Append("                       </div>");
            sbResult.Append("                        <div class=\"lv2\">");
            sbResult.Append("                        <div class=\"arrow\">");
            sbResult.Append("                            </div>");
            sbResult.Append("                            <a href=\"/memb/Texts/vote_Album_List.aspx\" target=\"mainFram\">投票管理</a>");
            sbResult.Append("                        </div>");
            sbResult.Append("                        <div class=\"index_menu2\">");
            sbResult.Append("                            <div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/vote_Album_List.aspx\" target=\"mainFram\">投票项信息列表</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/vote_Bigpic_List.aspx\" target=\"mainFram\">投票项目列表</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                                <div class=\"lv3\">");
            sbResult.Append("                                    <a href=\"/memb/Texts/vote_log_list.aspx\" target=\"mainFram\">投票日志</a>");
            sbResult.Append("                                </div>");
            sbResult.Append("                            </div>");
            sbResult.Append("                        </div>");
            sbResult.Append("                    </div>");
            sbResult.Append("                </div>"); 

            return sbResult.ToString();
        }

        public static string CreateAPPC()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("<div class=\"lv1\"> \r\n");
            sbResult.Append("  <div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append(" <a class=\"index_menu_title\" href=\"javascript:void(0)\">微订餐</a> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<div class=\"index_menu\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv2\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Shop_Config.aspx\" target=\"mainFram\">订餐配置</a> \r\n");
            sbResult.Append(" </div> \r\n");


            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Goods_List.aspx\" target=\"mainFram\">产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append(" <div class=\"lv3\"> \r\n");
            sbResult.Append("<a href=\"/memb/Goods/B2C_category_List.aspx\" target=\"mainFram\">产品类别</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  <div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_brand_List.aspx\" target=\"mainFram\">产品品牌</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Goods_List.aspx\" target=\"mainFram\">产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");
            ////////////////////////////////////////////////////////////////////
            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Vip_List.aspx\" target=\"mainFram\">会员特权产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Vip_List.aspx\" target=\"mainFram\">特权产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");
            ////////////////////////////

            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_JiFen_List.aspx\" target=\"mainFram\">会员积分兑换产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_JiFen_List.aspx\" target=\"mainFram\">积分兑换产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");

            /////////////////////////
            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_taocan_List.aspx\" target=\"mainFram\">打包套餐产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_taocan_List.aspx\" target=\"mainFram\">打包套餐产品添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");

            /////////////////////////


            sbResult.Append("<div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <a class=\"index_menu2_title\" href=\"javascript:void(0)\">订单管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append(" <div class=\"lv3\"> \r\n");
            sbResult.Append("  <a href=\"/memb/Goods/B2C_order_List.aspx\" target=\"mainFram\">订单查询</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/reg_advance.aspx\" target=\"mainFram\">订单导出</a> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");  
 
            sbResult.Append(" </div> \r\n");
            sbResult.Append(" </div> \r\n");  
          
            sbResult.Append("</div>  \r\n");
            sbResult.Append(" </div>  \r\n");
            sbResult.Append("  </div>  \r\n");
            sbResult.Append("</div>  \r\n"); 
            

            return sbResult.ToString();
        }

        public static string CreateAPPH()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("<div class=\"lv1\"> \r\n");
            sbResult.Append("  <div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append(" <a class=\"index_menu_title\" href=\"javascript:void(0)\">微酒店</a> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<div class=\"index_menu\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv2\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Shop_Config.aspx\" target=\"mainFram\">酒店配置</a> \r\n");
            sbResult.Append(" </div> \r\n");


            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Goods_List.aspx\" target=\"mainFram\">产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append(" <div class=\"lv3\"> \r\n");
            sbResult.Append("<a href=\"/memb/Goods/B2C_category_List.aspx\" target=\"mainFram\">产品类别</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  <div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_brand_List.aspx\" target=\"mainFram\">产品品牌</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Goods_List.aspx\" target=\"mainFram\">产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");
            ////////////////////////////////////////////////////////////////////
            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Vip_List.aspx\" target=\"mainFram\">会员特权产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Vip_List.aspx\" target=\"mainFram\">特权产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");
            ////////////////////////////

            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_JiFen_List.aspx\" target=\"mainFram\">会员积分兑换产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_JiFen_List.aspx\" target=\"mainFram\">积分兑换产品内容添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");

            /////////////////////////
            sbResult.Append("  <div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_taocan_List.aspx\" target=\"mainFram\">打包套餐产品管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_taocan_List.aspx\" target=\"mainFram\">打包套餐产品添加</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");
            sbResult.Append("  </div> \r\n");

            /////////////////////////


            sbResult.Append("<div class=\"lv2\"> \r\n");
            sbResult.Append("<div class=\"arrow\"> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <a class=\"index_menu2_title\" href=\"javascript:void(0)\">订单管理</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append(" <div class=\"index_menu2\"> \r\n");
            sbResult.Append("<div> \r\n");
            sbResult.Append(" <div class=\"lv3\"> \r\n");
            sbResult.Append("  <a href=\"/memb/Goods/B2C_order_List.aspx\" target=\"mainFram\">订单查询</a> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("<div class=\"lv3\"> \r\n");
            sbResult.Append(" <a href=\"/memb/reg_advance.aspx\" target=\"mainFram\">订单导出</a> \r\n");
            sbResult.Append(" </div> \r\n");
            sbResult.Append("</div> \r\n");
            sbResult.Append("  </div> \r\n");  
 
            sbResult.Append(" </div> \r\n");
            sbResult.Append(" </div> \r\n");  
          
            sbResult.Append("</div>  \r\n");
            sbResult.Append(" </div>  \r\n");
            sbResult.Append("  </div>  \r\n");
            sbResult.Append("</div>  \r\n"); 
            
            return sbResult.ToString();
        }

        public static string CreateMem()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("		<div class=\"lv1\">\r\n");
            sbResult.Append("                    <div class=\"arrow\">\r\n");
            sbResult.Append("                    </div>\r\n");
            sbResult.Append("                    <a class=\"index_menu_title\" href=\"/memb/vipmemb/B2C_memList.aspx\" target=\"mainFram\">\r\n");
            sbResult.Append("                        微会员</a>\r\n");
            sbResult.Append("                </div>\r\n");
            sbResult.Append("                <div class=\"index_menu\">\r\n");
            sbResult.Append("                    <div>\r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <div class=\"arrow\">\r\n");
            sbResult.Append("                            </div>\r\n");
            sbResult.Append("                            <a class=\"index_menu2_title\" href=\"/memb/vipmemb/B2C_memList.aspx\" target=\"mainFram\">\r\n");
            sbResult.Append("                                会员管理</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"index_menu2\">\r\n");
            sbResult.Append("                            <div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/B2C_memEdit.aspx\" target=\"mainFram\">会员添加</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/VIPUser.aspx\" target=\"mainFram\">会员统计</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Integral.aspx\" target=\"mainFram\">积分设置</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Wallet.aspx\" target=\"mainFram\">钱包设置</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/pricecompare/BJ_merchant.aspx\" target=\"mainFram\">比价商户管理</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                            </div>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <div class=\"arrow\">\r\n");
            sbResult.Append("                            </div>\r\n");
            sbResult.Append("                            <a class=\"index_menu2_title\" href=\"javascript:void(0)\">会员卡管理</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"index_menu2\">\r\n");
            sbResult.Append("                            <div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/VipcardEdit.aspx\" target=\"mainFram\">会员卡配置</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                 <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/VIP_Share_List.aspx\" target=\"mainFram\">会员分享管理</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                     <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/VIP_Share_Log.aspx\" target=\"mainFram\">会员分享日志</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                 <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Voucher_List.aspx\" target=\"mainFram\">优惠劵管理</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                    <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Voucher_Log.aspx\" target=\"mainFram\">优惠劵日志</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Rankinfo.aspx\" target=\"mainFram\">会员卡等级</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Franchises.aspx\" target=\"mainFram\">会员卡特权</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Vip_Activity.aspx\" target=\"mainFram\">会员卡活动</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/VIPCardCount.aspx\" target=\"mainFram\">会员卡统计</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                            </div>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <div class=\"arrow\">\r\n");
            sbResult.Append("                            </div>\r\n");
            sbResult.Append("                            <a class=\"index_menu2_title\" href=\"/memb/vipmemb/VIP_Share_List.aspx\" target=\"mainFram\">\r\n");
            sbResult.Append("                                会员分享管理</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"index_menu2\">\r\n");
            sbResult.Append("                            <div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/VIP_Share_Add.aspx\" target=\"mainFram\">会员分享添加</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/VIP_Share_Log.aspx\" target=\"mainFram\">会员分享日志</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                            </div>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append(" \r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <div class=\"arrow\">\r\n");
            sbResult.Append("                            </div>\r\n");
            sbResult.Append("                            <a class=\"index_menu2_title\" href=\"/memb/vipmemb/Voucher_List.aspx\" target=\"mainFram\">\r\n");
            sbResult.Append("                                代金卷管理</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                         <div class=\"index_menu2\">\r\n");
            sbResult.Append("                            <div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Voucher_Add.aspx\" target=\"mainFram\">代金卷添加</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                                <div class=\"lv3\">\r\n");
            sbResult.Append("                                    <a href=\"/memb/vipmemb/Voucher_Log.aspx\" target=\"mainFram\">代金卷日志</a>\r\n");
            sbResult.Append("                                </div>\r\n");
            sbResult.Append("                            </div>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                    </div>\r\n");
            sbResult.Append("                </div>\r\n");

            return sbResult.ToString();
        }

        public static string CreateHonor()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("		<div class=\"lv1\">\r\n");
            sbResult.Append("                    <div class=\"arrow\">\r\n");
            sbResult.Append("                    </div>\r\n");
            sbResult.Append("                    <a class=\"index_menu_title\" href=\"/memb/actions/Action_Now.aspx\" target=\"mainFram\">微活动</a>\r\n");
            sbResult.Append("                </div>\r\n");
            sbResult.Append("                <div class=\"index_menu\">\r\n");
            sbResult.Append("                    <div>\r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <a href=\"/memb/actions/Edit_Action.aspx\" target=\"mainFram\">添加新活动</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <a href=\"/memb/actions/Action_Now.aspx\" target=\"mainFram\">正在进行活动</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <a href=\"/memb/actions/Action_Will.aspx\" target=\"mainFram\">即将开始活动</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <a href=\"/memb/actions/Action_Passed.aspx\" target=\"mainFram\">已过期活动</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                        <div class=\"lv2\">\r\n");
            sbResult.Append("                            <a href=\"/memb/actions/TurntableList.aspx\" target=\"mainFram\">所有活动</a>\r\n");
            sbResult.Append("                        </div>\r\n");
            sbResult.Append("                    </div>\r\n");
            sbResult.Append("                </div>\r\n");

            return sbResult.ToString();
        }

        public static string CreateForm()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("		<div class=\"lv1\"> \r\n");
            sbResult.Append("                    <div class=\"arrow\"> \r\n");
            sbResult.Append("                    </div> \r\n");
            sbResult.Append("                    <a class=\"index_menu_title\" href=\"javascript:void(0)\">万能表单</a> \r\n");
            sbResult.Append("                </div> \r\n");
            sbResult.Append("                <div class=\"index_menu\"> \r\n");
            sbResult.Append("                    <div> \r\n");
            sbResult.Append("                        <div class=\"lv2\"> \r\n");
            sbResult.Append("                            <a href=\"/memb/formcontrols/ShowControlList.aspx?obj=5\" target=\"mainFram\">在线反馈</a> \r\n");
            sbResult.Append("                        </div> \r\n");
            sbResult.Append("                        <div class=\"lv2\"> \r\n");
            sbResult.Append("                            <a href=\"/memb/formcontrols/ShowControlList.aspx?obj=2\" target=\"mainFram\">在线预订</a> \r\n");
            sbResult.Append("                        </div> \r\n");
            sbResult.Append("                        <div class=\"lv2\"> \r\n");
            sbResult.Append("                            <a href=\"/memb/formcontrols/ShowControlList.aspx?obj=4\" target=\"mainFram\">在线报名</a> \r\n");
            sbResult.Append("                        </div> \r\n");
            sbResult.Append("                        <div class=\"lv2\"> \r\n");
            sbResult.Append("                            <a href=\"/memb/formcontrols/ShowControlList.aspx?obj=1\" target=\"mainFram\">在线预约</a> \r\n");
            sbResult.Append("                        </div> \r\n");
            sbResult.Append("                        <div class=\"lv2\"> \r\n");
            sbResult.Append("                            <a href=\"/memb/formcontrols/ShowControlList.aspx?obj=3\" target=\"mainFram\">在线挂号</a> \r\n");
            sbResult.Append("                        </div> \r\n");
            sbResult.Append("                        <div class=\"lv2\"> \r\n");
            sbResult.Append("                            <a href=\"/memb/formcontrols/objControlsList.aspx\" target=\"mainFram\">万能表单配置</a> \r\n");
            sbResult.Append("                        </div> \r\n");
            sbResult.Append("                        <div class=\"lv2\"> \r\n");
            sbResult.Append("                            <a href=\"/memb/formcontrols/objControlResultList.aspx\" target=\"mainFram\">万能表单结果查看</a> \r\n");
            sbResult.Append("                        </div> \r\n");
            sbResult.Append("                    </div> \r\n");
            sbResult.Append("                </div> \r\n");

            return sbResult.ToString();
        }
        /// <summary>
        /// 根据类型生成菜单
        /// </summary>
        /// <param name="_type">什么模板类型</param>
        /// <param name="_wid">wid</param>
        /// <returns></returns>
        public static string CreateMenu(int _wid)
        {
            string result = "";
            string _sql = "select  gids from b2c_worker_sp where wid =" + _wid.ToString() + " and cno='001' order by id desc";
            _sql += ";select gids from b2c_worker_sp where wid =" + _wid.ToString() + " and cno='002' order by id desc";
            //这里还未处理时间。
            if(_wid <= 464 )
            {
                result += CreateWeb() + "\r\n";
                result += CreateShop() + "\r\n";
                result += CreateMem() + "\r\n";
                result += CreateHonor() + "\r\n";
                result += CreateForm() + "\r\n";
                return result;
            }
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            result = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                int _type = Convert.ToInt32(ds.Tables[0].Rows[0]["gids"]);
                if(_type>1) 
                    result += CreateWeb() + "\r\n";
                if(_type>2)
                    result += CreateShop() + "\r\n";
                if (_type > 3)
                    result += CreateAPPC() + "\r\n";
                if (_type > 4)
                    result += CreateAPPH() + "\r\n";  
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                string _type2 = ",";
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    _type2 += dr["gids"].ToString().Trim() + ",";
                }
                if(_type2.IndexOf("10")!=-1)
                {
                    result += CreateMem() + "\r\n";
                }
                if (_type2.IndexOf("11") != -1)
                {
                    result += CreateHonor() + "\r\n";
                    result += CreateForm() + "\r\n";
                }
            }
            ds.Dispose();

            return result; 
        }
        #endregion

    }

}