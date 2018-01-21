using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Creatrue.kernel
{
static class comCharset
{
    ///' 字符集之间转换
    public static string UTF2GB2312(string _str)
    {
        System.Text.Encoding utf8 = System.Text.Encoding.Default;
        System.Text.Encoding gb2312 = System.Text.Encoding.GetEncoding("gb2312");
        byte[] temp = utf8.GetBytes(_str);
        byte[] temp1 = System.Text.Encoding.Convert(utf8, gb2312, temp);
        string result = gb2312.GetString(temp1);
        return result;
    }
    public static string GB2UTF(string _str)
    {
        System.Text.Encoding utf8 = System.Text.Encoding.Default;
        System.Text.Encoding gb2312 = System.Text.Encoding.GetEncoding("gb2312");
        byte[] temp = gb2312.GetBytes(_str);
        byte[] temp1 = System.Text.Encoding.Convert(gb2312, utf8, temp);
        string result = utf8.GetString(temp1);
        return result;
    }

    /// <summary>
    /// 通用字符集互转工具
    /// </summary>
    /// <param name="_str">源字符串</param>
    /// <param name="soure">源字符集</param>
    /// <param name="target">目标字符集</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static string CharSetChange(string _str, System.Text.Encoding soure, System.Text.Encoding target)
    {
        byte[] temp = soure.GetBytes(_str);
        byte[] temp1 = System.Text.Encoding.Convert(soure, target, temp);
        string result = target.GetString(temp1);
        return result;
    }
}
}