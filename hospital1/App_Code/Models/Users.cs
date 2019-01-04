using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Users 的摘要说明
/// </summary>
public class Users
{
    public String UserNum { set; get; }
    public String UserName { set; get; }
    public int Type { set; get; }
    public String Password { set; get; }
    public String Sex { set; get; }
    public int Age { set; get; }
    public String Tel { set; get; }
    public String DepartmentNum { set; get; }
    public static Users CreateUsers(Dictionary<String, Object> dic)
    {
        Users users = new Users();
        users.UserNum = (String)dic["u_num"];
        users.UserName = (String)dic["u_name"];
        users.Type = (int)dic["type"];
        users.Password = (String)dic["password"];
        users.Sex = (String)dic["sex"];
        users.Age = (int)dic["age"];
        users.Tel = (String)dic["tel"];
        users.DepartmentNum = (String)dic["dep_num"];
        return users; 
    }
}