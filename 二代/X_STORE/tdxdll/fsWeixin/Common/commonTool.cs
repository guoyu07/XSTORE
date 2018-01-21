using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using tdx.kernel;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace tdx.Common
{
    public class commonTool
    {


        public static string DaohangImage(string imgName)
        {

            return "<img height=\"92px\" width=\"100%\"  src=\"/memb/images4/" + imgName + "\" align=\"absmiddle\"  border=\"0\"/>";
        }
        public static string DaohangButton(string upUrl, string overUrl, string downUrl)
        {


            string shang = string.Format("<a href='{0}'   class=\"{1}\" id=\"shangyibu\" title=\"{2}\" >上一步</a>", upUrl, upUrl == "####" ? "btnGray" : "btnSave", upUrl == "####" ? "请先保存" : "上一步");
            string zhopng = string.Format("<a href='{0}'   class=\"{1}\" id=\"tiaoguo\" title=\"{2}\" >跳过此步</a>", overUrl, overUrl == "####" ? "btnGray" : "btnSave", overUrl == "####" ? "请先保存" : "跳过此步");
            string xia = string.Format("<a href='{0}'   class=\"{1}\" id=\"tiaoguo\" title=\"{2}\" >下一步</a>", downUrl, downUrl == "####" ? "btnGray" : "btnSave", downUrl == "####" ? "请先保存" : "下一步");
            string neirong = string.Format("<tr><td colspan=\"3\" align=\"center\" style=\"height: 30px\">  {0}{1}{2} </td> </tr>", shang, zhopng, xia);
            return neirong;

        }
        public static string F_pagearrow(int currentpage, int totalcount, string _myfile)
        {

            int totalPage = totalcount / consts.pagesize_Txt;
            double total = Convert.ToDouble(totalcount) / Convert.ToDouble(consts.pagesize_Txt);
            if (totalPage < total)
            {
                totalPage = totalPage + 1;
            }

            string myfile = _myfile;
            int _myfileIndex = _myfile.LastIndexOf(".");
            string myfileExt = _myfile.Substring(_myfileIndex, _myfile.Length - _myfileIndex);
            myfile = _myfile.Substring(0, _myfileIndex); //链接网址的种子

            string res = "";
            //返回第一页
            if (currentpage > 1)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + _myfile + "\"><img src=\"/master/images/pager/endArrow_L.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
                //<a href="?page="+ (currentpage -10) + "\"></a>
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/endArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }

            //返回前十页
            if ((currentpage - 10) < 1)
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/doubleArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + ((currentpage - 10) > 1 ? "_" + (currentpage - 1) : "") + myfileExt) + "\"><img src=\"/master/images/pager/doubleArrow_L.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
            }


            //返回前一页
            if (currentpage > 1)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + ((currentpage - 1) > 1 ? "_" + (currentpage - 1) : "") + myfileExt) + "\"><img src=\"/master/images/pager/singleArrow_L.gif\" align=\"absmiddle\"  border=\"0\"/></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/singleArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }
            if (totalPage <= 10)
            {
                for (int tmpi = 1; tmpi <= totalPage; tmpi++)
                {
                    if (tmpi == currentpage)
                    {
                        res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                    }
                    else
                    {
                        //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                        res += "            <span class=\"hppage\"><a href=\"" + (myfile + (tmpi > 1 ? "_" + tmpi : "") + myfileExt) + "\">" + tmpi + "</a></span>";
                    }
                }
            }
            else if (currentpage < 10)
            {
                for (int tmpi = 1; tmpi <= 10; tmpi++)
                {
                    if (tmpi == currentpage)
                    {
                        res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                    }
                    else
                    {
                        //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                        res += "            <span class=\"hppage\"><a href=\"" + (myfile + (tmpi > 1 ? "_" + tmpi : "") + myfileExt) + "\">" + tmpi + "</a></span>";
                    }
                }
            }
            else if (currentpage > (totalPage - 10))
            {
                for (int tmpi = currentpage; tmpi <= totalPage; tmpi++)
                {
                    if (tmpi == currentpage)
                    {
                        res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                    }
                    else
                    {
                        //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                        res += "            <span class=\"hppage\"><a href=\"" + (myfile + (tmpi > 1 ? "_" + tmpi : "") + myfileExt) + "\">" + tmpi + "</a></span>";
                    }
                }
            }
            else
            {
                for (int tmpi = (currentpage - 4); tmpi <= (currentpage + 5); tmpi++)
                {
                    if (tmpi == currentpage)
                    {
                        res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                    }
                    else
                    {
                        //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                        res += "            <span class=\"hppage\"><a href=\"" + (myfile + (tmpi > 1 ? "_" + tmpi : "") + myfileExt) + "\">" + tmpi + "</a></span>";
                    }
                }
            }


            res += "            <span class=\"hppage\">of " + totalPage + "</span>";
            //向后翻一页
            if (currentpage < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + ((currentpage + 1) > 1 ? "_" + (currentpage + 1) : "") + myfileExt) + "\"><img src=\"/master/images/pager/singleArrow_R.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/singleArrow_R_disabled.gif\" align=\"absmiddle\" /></span>";
            }

            //向后翻十页
            if ((currentpage + 10) < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + ((currentpage + 10) > 1 ? "_" + (currentpage + 10) : "") + myfileExt) + "\"><img src=\"/master/images/pager/doubleArrow_R_disabled.gif\" align=\"absmiddle\" border=\"0\"  /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/doubleArrow_R_disabled.gif\" align=\"absmiddle\"  /></span>";
            }

            //向后翻到尾页
            if (currentpage < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + (totalPage > 1 ? "_" + totalPage : "") + myfileExt) + "\"><img src=\"/master/images/pager/endArrow_R.gif\" align=\"absmiddle\" border='0' /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/endArrow_R_disabled.gif\" align=\"absmiddle\" border=\"0\" /></span>";
            }

            return res;

        }

        public static string F_pagearrow(int currentpage, int totalcount, string _myfile, int pagesize)
        {

            int totalPage = totalcount / pagesize;
            double total = Convert.ToDouble(totalcount) / Convert.ToDouble(pagesize);
            if (totalPage < total)
            {
                totalPage = totalPage + 1;
            }

            string myfile = _myfile;
            int _myfileIndex = _myfile.LastIndexOf(".");
            string myfileExt = _myfile.Substring(_myfileIndex, _myfile.Length - _myfileIndex);
            myfile = _myfile.Substring(0, _myfileIndex); //链接网址的种子

            string res = "";
            //返回第一页
            if (currentpage > 1)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + _myfile + "\"><img src=\"/master/images/pager/endArrow_L.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
                //<a href="?page="+ (currentpage -10) + "\"></a>
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/endArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }

            //返回前十页
            if ((currentpage - 10) < 1)
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/doubleArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + ((currentpage - 10) > 1 ? "_" + (currentpage - 1) : "") + myfileExt) + "\"><img src=\"/master/images/pager/doubleArrow_L.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
            }


            //返回前一页
            if (currentpage > 1)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + ((currentpage - 1) > 1 ? "_" + (currentpage - 1) : "") + myfileExt) + "\"><img src=\"/master/images/pager/singleArrow_L.gif\" align=\"absmiddle\"  border=\"0\"/></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/singleArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }


            for (int tmpi = 1; tmpi <= totalPage; tmpi++)
            {
                if (tmpi == currentpage)
                {
                    res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                }
                else
                {
                    //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                    res += "            <span class=\"hppage\"><a href=\"" + (myfile + (tmpi > 1 ? "_" + tmpi : "") + myfileExt) + "\">" + tmpi + "</a></span>";
                }
            }

            res += "            <span class=\"hppage\">of " + totalPage + "</span>";
            //向后翻一页
            if (currentpage < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + ((currentpage + 1) > 1 ? "_" + (currentpage + 1) : "") + myfileExt) + "\"><img src=\"/master/images/pager/singleArrow_R.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/singleArrow_R_disabled.gif\" align=\"absmiddle\" /></span>";
            }

            //向后翻十页
            if ((currentpage + 10) < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + ((currentpage + 10) > 1 ? "_" + (currentpage + 10) : "") + myfileExt) + "\"><img src=\"/master/images/pager/doubleArrow_R_disabled.gif\" align=\"absmiddle\" border=\"0\"  /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/doubleArrow_R_disabled.gif\" align=\"absmiddle\"  /></span>";
            }

            //向后翻到尾页
            if (currentpage < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"" + (myfile + (totalPage > 1 ? "_" + totalPage : "") + myfileExt) + "\"><img src=\"/master/images/pager/endArrow_R.gif\" align=\"absmiddle\" border='0' /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/endArrow_R_disabled.gif\" align=\"absmiddle\" border=\"0\" /></span>";
            }

            return res;

        }

        public static string F_pagearrow(int currentpage, int totalcount)
        {

            int totalPage = totalcount / consts.pagesize_Txt;
            double total = Convert.ToDouble(totalcount) / Convert.ToDouble(consts.pagesize_Txt);
            if (totalPage < total)
            {
                totalPage = totalPage + 1;
            }

            string res = "";
            res = res + "<input type='hidden' name='page' value='" + currentpage + "' />";
            res = res + "<script language='javascript'>";
            res = res + " function setAction(_tmpi)";
            res = res + " {";
            res = res + "    document.form1.page.value=_tmpi;";
            //res = res & "    document.form1.action= _url;" & vbCrLf
            //res = res & "    document.form1.submit();" & vbCrLf
            res = res + "    __doPostBack('ss_btn','');";
            res = res + " } ";
            res = res + "</script>";
            //返回第一页
            if (currentpage > 1)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"javascript:setAction(1);\"><img src=\"/master/images/pager/endArrow_L.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
                //<a href="?page="+ (currentpage -10) + "\"></a>
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/endArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }

            //返回前十页
            if ((currentpage - 10) < 1)
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/doubleArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><a href=\"javascript:setAction(" + (currentpage - 10) + ");\"><img src=\"/master/images/pager/doubleArrow_L.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
            }


            //返回前一页
            if (currentpage > 1)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"javascript:setAction(" + (currentpage - 1) + ");\"><img src=\"/master/images/pager/singleArrow_L.gif\" align=\"absmiddle\"  border=\"0\"/></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/singleArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }
            if (totalPage <= 10)
            {
                for (int tmpi = 1; tmpi <= totalPage; tmpi++)
                {
                    if (tmpi == currentpage)
                    {
                        res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                    }
                    else
                    {
                        //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                        res += "            <span class=\"hppage\"><a href=\"javascript:setAction(" + tmpi + ");\">" + tmpi + "</a></span>";
                    }
                }
            }
            else if (currentpage < 10)
            {
                for (int tmpi = 1; tmpi <= 10; tmpi++)
                {
                    if (tmpi == currentpage)
                    {
                        res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                    }
                    else
                    {
                        //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                        res += "            <span class=\"hppage\"><a href=\"javascript:setAction(" + tmpi + ");\">" + tmpi + "</a></span>";
                    }
                }
            }
            else if (currentpage > (totalPage - 10))
            {
                for (int tmpi = currentpage; tmpi <= totalPage; tmpi++)
                {
                    if (tmpi == currentpage)
                    {
                        res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                    }
                    else
                    {
                        //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                        res += "            <span class=\"hppage\"><a href=\"javascript:setAction(" + tmpi + ");\">" + tmpi + "</a></span>";
                    }
                }
            }
            else
            {
                for (int tmpi = (currentpage - 4); tmpi <= (currentpage + 5); tmpi++)
                {
                    if (tmpi == currentpage)
                    {
                        res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                    }
                    else
                    {
                        //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                        res += "            <span class=\"hppage\"><a href=\"javascript:setAction(" + tmpi + ");\">" + tmpi + "</a></span>";
                    }
                }
            }


            res += "            <span class=\"hppage\">of " + totalPage + "</span>";
            //向后翻一页
            if (currentpage < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"javascript:setAction(" + (currentpage + 1) + ");\"><img src=\"/master/images/pager/singleArrow_R.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/singleArrow_R_disabled.gif\" align=\"absmiddle\" /></span>";
            }

            //向后翻十页
            if ((currentpage + 10) < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"javascript:setAction(" + (currentpage + 10) + ");\"><img src=\"/master/images/pager/doubleArrow_R_disabled.gif\" align=\"absmiddle\" border=\"0\"  /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/doubleArrow_R_disabled.gif\" align=\"absmiddle\"  /></span>";
            }

            //向后翻到尾页
            if (currentpage < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"javascript:setAction(" + (totalPage) + ");\"><img src=\"/master/images/pager/endArrow_R.gif\" align=\"absmiddle\" /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/endArrow_R_disabled.gif\" align=\"absmiddle\" border=\"0\" /></span>";
            }

            return res;

        }

        public static string L_pagearrow(int currentpage, int totalcount)
        {

            int totalPage = totalcount / consts.pagesize_Txt;
            double total = Convert.ToDouble(totalcount) / Convert.ToDouble(consts.pagesize_Txt);
            if (totalPage < total)
            {
                totalPage = totalPage + 1;
            }

            string res = "";
            res = res + "<input type='hidden' name='page' value='" + currentpage + "' />";
            res = res + "<script language='javascript'>";
            res = res + " function setAction(_tmpi)";
            res = res + " {";
            res = res + "    document.form1.page.value=_tmpi;";
            //res = res & "    document.form1.action= _url;" & vbCrLf
            //res = res & "    document.form1.submit();" & vbCrLf
            res = res + "    __doPostBack('ss_btn','');";
            res = res + " } ";
            res = res + "</script>";
            //返回第一页
            if (currentpage > 1)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"?page=1\"><img src=\"/master/images/pager/endArrow_L.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
                //<a href="?page="+ (currentpage -10) + "\"></a>
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/endArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }

            //返回前十页
            if ((currentpage - 10) < 1)
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/doubleArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><a href=\"?page=" + (currentpage - 10) + "\"><img src=\"/master/images/pager/doubleArrow_L.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
            }


            //返回前一页
            if (currentpage > 1)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"?page=" + (currentpage - 1) + "\"><img src=\"/master/images/pager/singleArrow_L.gif\" align=\"absmiddle\"  border=\"0\"/></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/singleArrow_L_disabled.gif\" align=\"absmiddle\" /></span>";
            }


            for (int tmpi = 1; tmpi <= totalPage; tmpi++)
            {
                if (tmpi == currentpage)
                {
                    res += "            <span class=\"hppagecurrent\">" + tmpi + "</span>";
                }
                else
                {
                    //res += "            <span class=""hppage""><a href=""?page=" & tmpi & "&" & GetP() & """>" & tmpi & "</a></span>" & vbCrLf
                    res += "            <span class=\"hppage\"><a href=\"?page=" + tmpi + "\">" + tmpi + "</a></span>";
                }
            }

            res += "            <span class=\"hppage\">of " + totalPage + "</span>";
            //向后翻一页
            if (currentpage < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"?page=" + (currentpage + 1) + "\"><img src=\"/master/images/pager/singleArrow_R.gif\" align=\"absmiddle\" border=\"0\" /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/singleArrow_R_disabled.gif\" align=\"absmiddle\" /></span>";
            }

            //向后翻十页
            if ((currentpage + 10) < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"?page=" + (currentpage + 10) + "\"><img src=\"/master/images/pager/doubleArrow_R_disabled.gif\" align=\"absmiddle\" border=\"0\"  /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/doubleArrow_R_disabled.gif\" align=\"absmiddle\"  /></span>";
            }

            //向后翻到尾页
            if (currentpage < totalPage)
            {
                res += "            <span class=\"pagerarrow\"><a href=\"?page=" + (totalPage) + "\"><img src=\"/master/images/pager/endArrow_R.gif\" align=\"absmiddle\" /></a></span>";
            }
            else
            {
                res += "            <span class=\"pagerarrow\"><img src=\"/master/images/pager/endArrow_R_disabled.gif\" align=\"absmiddle\" border=\"0\" /></span>";
            }

            return res;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ipage"></param>
        /// <param name="totalcount"></param>
        /// <param name="_pagesize"></param>
        /// <param name="forms">必须是form</param>
        /// <param name="quests"></param>
        /// <returns></returns>
        public static string GetArrowHtmlNew(int _ipage, int totalcount, int _pagesize, NameValueCollection forms, NameValueCollection quests)
        {
            string ques = "";
            //  List<string> names = new List<string>();
            Dictionary<string, string> names = new Dictionary<string, string>();
            foreach (string keyName in forms.Keys)
            {
                if (keyName != "page")
                {
                    ques += "&" + keyName + "=" + forms[keyName];
                    names.Add(keyName, "");
                }
            }
            foreach (string keyNa in quests.Keys)
            {
                if (keyNa != "page")
                {
                    if (names.ContainsKey(keyNa))
                        continue;
                    else
                    {
                        ques += "&" + keyNa + "=" + quests[keyNa];
                        names.Add(keyNa, "");
                    }


                }
            }

            string result = "";
            result = result + "<input type='hidden' name='page' value='" + _ipage + "' />";
            result = result + "<script language='javascript'>";
            result = result + " function setAction(_tmpi)";
            result = result + " {";
            result = result + "    document.form1.page.value=_tmpi;";
            //result = result & "    document.form1.action= _url;" & vbCrLf
            //result = result & "    document.form1.submit();" & vbCrLf
            result = result + "    __doPostBack('ss_btn','');";
            result = result + " } ";
            result = result + "</script>";
            result += "\n <div style=\"clear: both;margin:10px auto;\">";
            //添加样式
            result += "\n <style>";
            result += "\n";
            result += "\n.page_fenye{display:inline;margin:0 auto;padding:0;overflow:hidden;}";
            result += "\n.prev,.arrow_num,.next{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 30px;border:1px solid #cccccc;font-weight: bolder;color: #420100}";
            //result += "\n.prev a,.arrow_num a,.next a{color: #420100}";
            //result += "\n.prev a:hover,.arrow_num a:hover,.next a:hover{color: #fe0000}";
            result += "\n.pagecurr{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 30px;color: #FF6600;border:1px solid #FF6600;font-weight: bolder;}";
            result += "\n";
            result += "\n </style>";

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
                    result += "<a class=\"prev\" href='?page=" + forwardpage + ques + "'>上一页</a>" + "\n";
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
                        result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n";
                    }
                }
                else //多于12页,需要存在...控制
                {
                    ///////////////小于5不跳分页数字
                    if (_ipage < 5)//10//前半部分,1~5,直接显示成页码框
                    {
                        for (int _tmppage = 1; _tmppage <= 5; _tmppage++)
                        {
                            string cclassname = "arrow_num";
                            if (_tmppage == _ipage)
                            {
                                cclassname = "pagecurr";
                            }
                            result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n";
                        }
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        ///////////////////////注释添加...后的框样式

                        result += "<a class=\"arrow_num\" href='?page=" + _totalpage + ques + "'> " + _totalpage + " </a>" + "\n";
                    }
                    else
                    {
                        result += "<a class=\"arrow_num\"  href='?page=1" + ques + "'> 1 </a>" + "\n";
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
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n";
                            }
                            result += "<span class=\"pagetext\">...</span>" + "\n";
                            result += "<a class=\"arrow_num\" href='?page=" + _totalpage + ques + "'> " + _totalpage + " </a>" + "\n";
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
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n";
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
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n";
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
                    result += "<a class=\"next\" href='?page=" + backpage + ques + "'> 下一页 </a>" + "\n";
                }

            }
            result += "\n </div>";

            return result;
        }

        public static string GetArrowHtml(int _ipage, int totalcount, int _pagesize)
        {
            string result = "";
            result += "\n <div style=\"clear: both;margin:10px auto;\">";
            //添加样式
            result += "\n <style>";
            result += "\n";
            result += "\n.page_fenye{display:inline;margin:0 auto;padding:0;overflow:hidden;}";
            result += "\n.prev,.arrow_num,.next{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 30px;border:1px solid #cccccc;font-weight: bolder;color: #420100}";
            //result += "\n.prev a,.arrow_num a,.next a{color: #420100}";
            //result += "\n.prev a:hover,.arrow_num a:hover,.next a:hover{color: #fe0000}";
            result += "\n.pagecurr{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 30px;color: #FF6600;border:1px solid #FF6600;font-weight: bolder;}";
            result += "\n";
            result += "\n </style>";

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
                    result += "<a class=\"prev\" href='?page=" + forwardpage + "'>上一页</a>" + "\n";
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
                        result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
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
                            result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                        }
                        result += "<span class=\"pagetext\">...</span>" + "\n";

                        result += "<a class=\"pagetext\" href='?page=" + _totalpage + "'> " + _totalpage + " </a>" + "\n";
                    }
                    else
                    {
                        result += "<a href='?1=1'> 1 </a>" + "\n";
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
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
                            }
                            result += "<span class=\"pagetext\">...</span>" + "\n";
                            result += "<a class=\"pagetext\" href='?page=" + _totalpage + "'> " + _totalpage + " </a>" + "\n";
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
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
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
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + "'> " + _tmppage + " </a>" + "\n";
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
                    result += "<a class=\"next\" href='?page=" + backpage + "'> 下一页 </a>" + "\n";
                }

            }
            result += "\n </div>";

            return result;
        }

        public static string GetArrowHtml3(int _ipage, int totalcount, string _myFile)
        {
            return GetArrowHtml3(_ipage, totalcount, _myFile, 20);
        }
        public static string GetArrowHtml3(int _ipage, int totalcount, string _myFile, int _pagesize)
        {
            string result = "";
            result += "\n <div style=\"clear: both;margin:10px auto;\">";
            //添加样式
            result += "\n <style>";
            result += "\n";
            result += "\n.page_fenye{display:inline;margin:0 auto;padding:0;overflow:hidden;}";
            result += "\n.prev,.arrow_num,.next{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 30px;border:1px solid #cccccc;font-weight: bolder;color: #420100}";
            //result += "\n.prev a,.arrow_num a,.next a{color: #420100}";
            //result += "\n.prev a:hover,.arrow_num a:hover,.next a:hover{color: #fe0000}";
            result += "\n.pagecurr{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 30px;color: #FF6600;border:1px solid #FF6600;font-weight: bolder;}";
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
                    result += "<a class=\"prev\">上一页</a>" + "\n";
                }
                else
                {
                    result += "<a class=\"prev\" href='" + (forwardpage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + forwardpage + myFile_ext)) + "'>上一页</a>" + "\n";
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
                    result += "<a class=\"next\"> 下一页 </a>" + "\n";
                }
                else
                {
                    result += "<a class=\"next\" href='" + (backpage == 1 ? (myFile_first + myFile_ext) : (myFile_first + "_" + backpage + myFile_ext)) + "'> 下一页 </a>" + "\n";
                }

            }
            result += "\n </div>";

            return result;
        }

        public static string GetMoney(string _money)
        {
            return string.Format("{0:F}", Convert.ToDouble(_money));
        }
        /// <summary>
        /// 判断输入的字符串是否是一个合法的手机号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMobilePhone(string input)
        {
            input = input.Replace(" ", "");
            Regex regex = new Regex("^1[34589]\\d{9}$");
            return regex.IsMatch(input);

        }


        /// <summary>
        /// lt_result显示信息
        /// </summary>
        /// <param name="_str"></param>
        /// <param name="_url"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static string Show_Have_Url(Literal lt, string _str, string _url, int flag)
        {
            lt.Text = _str;
            if (flag == 0)
                lt.Text += "<script language='javascript'>setTimeout(function(){location.href='" + _url + "';},300);</script>";
            string ret = lt.Text;
            return ret;
        }
        /// <summary>
        /// 验证是否为空
        /// </summary>
        /// <param name="lt">界面提示标签</param>
        /// <param name="_input">被验证字符串</param>
        /// <param name="_str">提示信息</param>
        /// <param name="_url">跳转链接</param>
        public static bool RemindMessageEmpty(Literal lt, string _input, string _str, string _url)
        {
            bool ret = true;
            if (_url == "")
            {
                if (_input == "")
                {
                    Show_Have_Url(lt, _str, "", 1);
                    ret = false;
                }
            }
            else
            {
                if (_input == "")
                {
                    Show_Have_Url(lt, _str, _url, 0);
                    ret = false;
                }
            }
            return ret;
        }

        /// <summary>
        /// 输入长度提示
        /// </summary>
        /// <param name="lt">界面提示标签</param>
        /// <param name="_realLength">被检测字符串长度</param>
        /// <param name="_length">需要检测的长度数</param>
        /// <param name="_str">提示信息</param>
        /// <param name="_url">跳转URL</param>
        public static bool RemindMessageLengh(Literal lt, int _realLength, int _length, string _str, string _url)
        {
            bool ret = true;
            if (_url == "")
            {
                if (_realLength > _length)
                {
                    Show_Have_Url(lt, _str, "", 1);
                    ret = false;
                }
            }
            else
            {
                if (_realLength > _length)
                {
                    Show_Have_Url(lt, _str, _url, 0);
                    ret = false;
                }
            }
            return ret;
        }

        public static bool IsEmail(string _input)
        {

            return Regex.IsMatch(

       _input, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)" +

       @"|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static string funcSelectBox(string _th)
        {
            string result = "";
            result += "\r\n	    <select id=\"txtUrl_1\" name=\"txtUrl_1\" onchange=\"selectChange(this,'#txtUrl_2')\" class=\"select-field\">";
            result += "\r\n         <option value=\"\">其他地址</option>";
            result += "\r\n         <option value=\"index\">首页</option>";
            result += "\r\n         <option value=\"newslist\">新闻</option>";
            result += "\r\n         <option value=\"prolist\">产品</option>"; 
            result += "\r\n         <option value=\"tpage\">页面</option>";
            result += "\r\n         <option value=\"photolist\">相册</option>";
            result += "\r\n         <option value=\"Goodslist\">商城</option>";
            result += "\r\n         <option value=\"teamlist\">团购</option>";
            result += "\r\n         <option value=\"mslist\">秒杀</option>";
            result += "\r\n         <option value=\"vote\">投票</option>";
            result += "\r\n         <option value=\"member\">会员</option>";
            result += "\r\n         <option value=\"honor_list\">活动</option>";
            result += "\r\n         <option value=\"controls\">表单</option>";
            result += "\r\n      </select>";
            result += "\r\n      <select id=\"txtUrl_2\" name=\"txtUrl_2\" onchange=\"selectChange2('#txtUrl_1',this,'#txtUrl_3')\" class=\"select-field\" style=\"display: none;\">";
            result += "\r\n      </select>";
            result += "\r\n      <select id=\"txtUrl_3\" name=\"txtUrl_3\" onchange=\"select_Change3('#txtUrl_1','#txtUrl_2',this)\" style=\"display: none;\" class=\"select-field\">";
            result += "\r\n      </select>";

            return result;
        }
    }
}
