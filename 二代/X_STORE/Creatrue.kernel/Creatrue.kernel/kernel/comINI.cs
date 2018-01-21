using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Creatrue.kernel
{
/// <summary>
/// 读写INI
/// </summary>
/// <remarks></remarks>
public class comINI
{


    private string INIPath;
    /// <summary>
    /// 类的构造函数，传递INI文件名
    /// </summary>
    /// <param name="_INIPath">INI文件的路径，例如：“d:\web.ini”</param>
    /// <remarks></remarks>
    public comINI(string _INIPath)
    {
        INIPath = _INIPath;
    }

    /// <summary>
    /// 写INI文件
    /// </summary>
    /// <param name="INI_mode"></param>
    /// <param name="INI_key"></param>
    /// <param name="INI_value"></param>
    /// <remarks></remarks>
    public void write(string INI_mode, string INI_key, string INI_value)
    {
        WritePrivateProfileString(INI_mode, INI_key, INI_value, INIPath);
    }

    //
    // 读取INI文件

    public string read(string INI_mode, string INI_key)
    {
        System.Text.StringBuilder INI_value = new System.Text.StringBuilder(255);
        GetPrivateProfileString(INI_mode, INI_key, "", INI_value, 255, INIPath);
        return INI_value.ToString();
    }

    [DllImport("Kernel32.dll")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);


    [DllImport("Kernel32.dll")]
    private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);


}

}