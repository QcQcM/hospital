using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for publicService
/// </summary>
public class publicService
{
    //判断字符串是否含有数字、特殊字符（中英文字符串）
    public static bool isContainNumberOrSpecialChar(String str)
    {
        String[] specaialChar = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "\\", "|" };
        for (int i = 0; i < specaialChar.Length; i++)
        {
            if (str.Contains(specaialChar[i]))
                return true;
        }
        return false;
    }
    //判断字符串是否含有数字、特殊字符和英文字母（中文字符串）
    public static bool isContainNumberOrSpecialCharOrEnglish(String str)
    {
        String[] specaialChar = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "\\", "|" ,"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
        for (int i = 0; i < specaialChar.Length; i++)
        {
            if (str.Contains(specaialChar[i]))
                return true;
        }
        return false;
    }
    //判断是否纯数字
    public static bool isOnlyNumber(String str)
    {
        try
        {
            int number = Convert.ToInt32(str);
        }
        catch (InvalidCastException)
        {
            return false;
        }
        return true;
    }
    //验证身份证号是否合法 分别验证16位和18位
    public bool CheckIDCard(string idNumber)
    {
        if (idNumber.Length == 18)
        {
            bool check = CheckIDCard18(idNumber);
            return check;
        }
        else if (idNumber.Length == 15)
        {
            bool check = CheckIDCard15(idNumber);
            return check;
        }
        else
        {
            return false;
        }
    }
    //验证18位身份证号是否合法
    private bool CheckIDCard18(string idNumber)
    {
        long n = 0;
        if (long.TryParse(idNumber.Remove(17), out n) == false
            || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
        {
            return false;//数字验证  
        }
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (address.IndexOf(idNumber.Remove(2)) == -1)
        {
            return false;//省份验证  
        }
        string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
        DateTime time = new DateTime();
        if (DateTime.TryParse(birth, out time) == false)
        {
            return false;//生日验证  
        }
        string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
        string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
        char[] Ai = idNumber.Remove(17).ToCharArray();
        int sum = 0;
        for (int i = 0; i < 17; i++)
        {
            sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
        }
        int y = -1;
        Math.DivRem(sum, 11, out y);
        if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
        {
            return false;//校验码验证  
        }
        return true;//符合GB11643-1999标准  
    }
    //验证15位身份证号是否合法
    private bool CheckIDCard15(string idNumber)
    {
        long n = 0;
        if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
        {
            return false;//数字验证  
        }
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (address.IndexOf(idNumber.Remove(2)) == -1)
        {
            return false;//省份验证  
        }
        string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
        DateTime time = new DateTime();
        if (DateTime.TryParse(birth, out time) == false)
        {
            return false;//生日验证  
        }
        return true;
    }
}

