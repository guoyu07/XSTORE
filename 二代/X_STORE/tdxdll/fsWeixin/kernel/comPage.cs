using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace tdx.kernel
{
public class Class_Page
{


    private string 数据库连接字符串;
    private string SQL语句;
    private int 页记录数;

    private string 文件名称;
    private bool 排序方式;
    private string TableName;
    private string Fields;
    private string Where;
    private string 排序字段;

    private string _CssClass;
    /// <summary>
    /// 当前页
    /// </summary>
    /// <remarks></remarks>

    public int 当前页;
    /// <summary>
    /// 总页数
    /// </summary>
    public int PageCount;
    /// <summary>
    /// 记录总数
    /// </summary>

    public int RecordCount;

    /// <summary>
    /// 运行时间
    /// </summary>
    /// <remarks></remarks>

    public TimeSpan RunTime;
    /// <summary>
    /// 初始化分页类，需要sqlserver2005支持，否则会出错误
    /// </summary>
    /// <param name="_SQL语句">查询sql语句，类似：SELECT * FROM T_User WHERE (LoginPwd = '888888') ORDER BY LoginName DESC</param>
    /// <param name="_页记录数">每页的记录集数量，默认为10条/页</param>
    /// <param name="_当前页">请求的当前页</param>
    /// <param name="_文件名称">分页所在文件名，例如：booklist.aspx</param>
    /// <param name="_排序字段">排序字段</param>
    /// <param name="_数据库连接字符串">数据库连接字符串</param>
    /// <remarks></remarks>
    public Class_Page(string _SQL语句, int _页记录数, int _当前页, string _文件名称, string _排序字段, string _数据库连接字符串)
    {
        DateTime StartTime = System.DateTime.Now;

        SQL语句 = _SQL语句;
        页记录数 = _页记录数;
        当前页 = _当前页;
        文件名称 = _文件名称;

        排序字段 = _排序字段;
        数据库连接字符串 = _数据库连接字符串;

        TableName = GetTableNameBySQL(SQL语句, ref Fields, ref Where, ref 排序字段, ref 排序方式);

        //这里计算记录数量, 由此得到合计页数
        RecordCount = comfun.GetFieldCount(TableName, Where);
        PageCount = RecordCount / 页记录数;
        if (RecordCount % 页记录数 != 0)
        {
            PageCount += 1;
        }
        RunTime = DateTime.Now - StartTime;
    }

    /// <summary>
    /// 获得分页后的数据表
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public DataTable 分页数据表
    {
        get { return comfun.GetDataTableBySQL2005(SQL语句, 页记录数, 当前页, 排序字段, 排序方式); }
    }

    /// <summary>
    /// 获得分页的控制字符串
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public string PageString
    {
        get { return this.GetNextPage(文件名称); }
    }

    /// <summary>
    /// 分页链接的样式，可以自定义
    /// </summary>
    /// <value></value>
    /// <remarks></remarks>
    public string CssClass
    {
        set { _CssClass = " Class=" + value + " "; }
    }

    /// <summary>
    /// 从sql语句中获取特定的值，用于存储过程排序用
    /// </summary>
    /// <param name="SQL语句">Sql语句</param>
    /// <param name="Fields">需要提取的字段</param>
    /// <param name="Where">条件语句</param>
    /// <param name="排序字段">用于排序的字段</param>
    /// <param name="排序方式">排序的类别，True=正序，False=倒序</param>
    private string GetTableNameBySQL(string SQL语句, ref string Fields, ref string Where, ref string 排序字段, ref bool 排序方式)
    {
        //计算表名
        SQL语句 = SQL语句.ToUpper();
        string TableName = null;
        if (SQL语句.Contains("WHERE") == true)
        {
            TableName = this.GetValueFormTxt(SQL语句, "FROM", "WHERE").ToString().Trim();
            //'筛选出表名
        }
        else
        {
            if (SQL语句.Contains("ORDER") == true)
            {
                TableName = this.GetValueFormTxt(SQL语句, "FROM", "ORDER").ToString().Trim();
                //'筛选出表名
            }
            else
            {
                TableName = this.GetLastString(SQL语句, "FROM");
            }
        }
        Fields = this.GetValueFormTxt(SQL语句, "SELECT", "FROM").ToString().Trim(); ;
        if (SQL语句.Contains("WHERE") == false)
        {
            Where = "(1 = 1)";
            if (SQL语句.Contains("ORDER BY") == true)
            {
                if (SQL语句.Contains("DESC") == true)
                {
                    //说明是倒序
                    排序字段 = this.GetValueFormTxt(SQL语句, "ORDER BY", "DESC").ToString().Trim();
                    排序方式 = false;
                }
                else
                {
                    //说明是正序
                    排序字段 = this.GetLastString(SQL语句, "ORDER BY");
                    排序方式 = true;
                }
            }
        }
        else
        {
            if (SQL语句.Contains("ORDER BY") == true)
            {
                //这里说明有排序字段
                Where = this.GetValueFormTxt(SQL语句, "WHERE", "ORDER").ToString().Trim() ;
                //这里判断出排序字段和排序类型
                if (SQL语句.Contains("DESC") == true)
                {
                    //说明是倒序
                    排序字段 = this.GetValueFormTxt(SQL语句, "ORDER BY", "DESC").ToString().Trim();
                    排序方式 = false;
                }
                else
                {
                    //说明是正序
                    排序字段 = this.GetLastString(SQL语句, "ORDER BY");
                    排序方式 = true;
                }
            }
            else
            {
                //说明没有排序字段
                Where = this.GetLastString(SQL语句, "WHERE");
            }
        }
        return TableName;
    }


    /// <summary>
    /// 根据前后特定值从文本中获得特定数据
    /// </summary>
    /// <param name="Text">需要处理的文本</param>
    /// <param name="LeftTxt">左边标准的字符串</param>
    /// <param name="RightTxt">右边标准的字符串</param>
    /// <returns></returns>
    /// <remarks></remarks>
    private object GetValueFormTxt(string Text, string LeftTxt, string RightTxt)
    {
        System.Text.RegularExpressions.Regex Re = new System.Text.RegularExpressions.Regex(LeftTxt + "\\s*(?<TxtValue>[\\s|\\S]+?(?!\\n\\s*\\r\\n))" + RightTxt + "\\s*");
        System.Text.RegularExpressions.Match ReMatch = null;
        string Tmp = "";
        foreach (System.Text.RegularExpressions.Match ReMatch_loopVariable in Re.Matches(Text))
        {
            ReMatch = ReMatch_loopVariable;
            Tmp += ReMatch.Groups["TxtValue"].Value; //.Replace(Strings.Chr(10), "\n");
        }
        return Tmp;
    }

    /// <summary>
    /// 计算出最后字符串的开始位置
    /// </summary>
    /// <param name="Text"></param>
    /// <param name="SplitText"></param>
    private string GetLastString(string Text, string SplitText)
    {
        int LastStringIndex = Text.IndexOf(SplitText) + SplitText.Length;
        return Text.Substring(LastStringIndex, Text.Length - LastStringIndex).Trim();
    }

    /// <summary>
    /// 返回一个分页的提示条
    /// </summary>
    /// <param name="文件名称">文件名</param>
    private string GetNextPage(string 文件名称)
    {
        string NextPage = "共&nbsp;<strong>" + RecordCount + "</strong>&nbsp;记录&nbsp;&nbsp;";

        if (文件名称.Substring (文件名称.Length -5, 4) == "aspx")
        {
            文件名称 += "?";
        }
        else
        {
            文件名称 += "&";
        }

        if (当前页 == 1)
        {
            NextPage += "<font face=\"webdings\">9</font>";
            NextPage += "<font face=\"webdings\">3</font>";
        }
        else
        {
            NextPage += "&nbsp;<a " + _CssClass + " title=\"转到第1页\" href=\"" + 文件名称 + "PageID=1\"><font face=\"webdings\">9</font></a>&nbsp;";
            NextPage += "&nbsp;<a " + _CssClass + " title=\"转到第" + Convert.ToInt32(当前页 - 1) + "页\" href=\"" + 文件名称 + "PageID=" + Convert.ToInt32(当前页 - 1) + "\"><font face=\"webdings\">3</font></a>&nbsp;";
        }


        int StartPageID = 1;
        int EndPageID = PageCount;
        if (当前页 > 5)
        {
            StartPageID = 当前页 - 5;
        }
        if ((PageCount - 当前页) > 5)
        {
            EndPageID = 当前页 + 5;
        }

        for (int i = StartPageID; i <= EndPageID; i++)
        {
            if (i == 当前页)
            {
                NextPage += "&nbsp;" + i + "&nbsp;";
            }
            else
            {
                NextPage += "&nbsp;<a " + _CssClass + " title=\"转到第" + i + "页\" href=\"" + 文件名称 + "PageID=" + i + "\">" + i + "</a>&nbsp;";
            }
        }

        if (当前页 == PageCount)
        {
            NextPage += "<font face=\"webdings\">4</font>";
            NextPage += "<font face=\"webdings\">:</font>";
        }
        else
        {
            NextPage += "&nbsp;<a " + _CssClass + " title=\"转到第" + 当前页 + 1 + "页\" href=\"" + 文件名称 + "PageID=" + 当前页 + 1 + "\"><font face=\"webdings\">4</font></a>&nbsp;";
            NextPage += "&nbsp;<a " + _CssClass + " title=\"转到第" + PageCount + "页（末页）\" href=\"" + 文件名称 + "PageID=" + PageCount + "\"><font face=\"webdings\">:</font></a>&nbsp;";
        }
        return NextPage;
    }

}

}