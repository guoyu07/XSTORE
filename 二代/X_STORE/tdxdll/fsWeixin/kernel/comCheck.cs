using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tdx.kernel
{
/// <summary>
/// 验证数据
/// </summary>
/// <remarks></remarks>
public static class comCheck
{
    public static bool isDate(string s)
    {
        string strTemp = "^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-8]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
        if (s.Length != 10)
        {
            return false;
        }
        return (System.Text.RegularExpressions.Regex.IsMatch(s.Replace("/", "-"), strTemp));
    }

    public static bool isEmail(string s)
    {
        string strTemp = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        return (System.Text.RegularExpressions.Regex.IsMatch(s, strTemp));
    }

    public static bool isURL(string s)
    {
        string strTemp = "http://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?";
        return (System.Text.RegularExpressions.Regex.IsMatch(s, strTemp));
    }

    public static bool isNum(string s)
    {
        string strTemp = "^\\d+(\\.\\d*)?$";
        return (System.Text.RegularExpressions.Regex.IsMatch(s, strTemp));
    }
    public static bool isMobile(string s)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(s, @"^[1]+[3,5,8,4]+\d{9}");  
    }
    public static bool CheckIDCard(string Id)
    { 
        if (Id.Length == 18)
        { 
            bool check = CheckIDCard18(Id); 
            return check; 
        } 
        else if (Id.Length == 15)
        { 
            bool check = CheckIDCard15(Id); 
            return check; 
        } 
        else
        { 
            return false; 
        } 
    }
     
    private static bool CheckIDCard18(string Id)
    {  
        long n = 0; 
        if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
        { 
            return false;//数字验证 
        } 
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91"; 
        if (address.IndexOf(Id.Remove(2)) == -1)
        { 
            return false;//省份验证 
        } 
        string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-"); 
        DateTime time = new DateTime(); 
        if (DateTime.TryParse(birth, out time) == false)
        { 
            return false;//生日验证 
        } 
        string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(','); 
        string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');  
        char[] Ai = Id.Remove(17).ToCharArray(); 
        int sum = 0; 
        for (int i = 0; i < 17; i++)
        { 
            sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString()); 
        }

        int y = -1; 
        Math.DivRem(sum, 11, out y); 
        if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
        { 
            return false;//校验码验证 
        }

        return true;//符合GB11643-1999标准 
    }
      
    private static bool CheckIDCard15(string Id)
    { 
        long n = 0; 
        if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
        { 
            return false;//数字验证 
        } 
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91"; 
        if (address.IndexOf(Id.Remove(2)) == -1)
        { 
            return false;//省份验证 
        }

        string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-"); 
        DateTime time = new DateTime(); 
        if (DateTime.TryParse(birth, out time) == false)
        { 
            return false;//生日验证 
        } 
        return true;//符合15位身份证标准 
    }
}
}