using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UsersService 的摘要说明
/// </summary>
public class UsersService
{
    private const String INSERT_USERS_SQL = "insert into users(u_num,u_name,type,password,sex,age,tel,dep_num) values (\"{0} \",\"{1}\",{2},\"{3}\",\"{4}\",{5},\"{6}\",\"{7}\")";
    private const String UPDATE_USERS_SQL = "update users set u_name=\"{0}\",type={1},password=\"{2}\",sex=\"{3}\",age={4},tel=\"{5}\",dep_num=\"{6}\"  where u_num=\"{7}\" ";
    private const String QUERY_USERS_SQL = "select * from users where u_num=\"{0}\" ";
    private const String DELETE_USERS_SQL = "delete from users where u_num=\"{0}\" ";

    //根据用户号查找用户
    public static List<Users> QueryUsersByNum(String UserNum)
    {
        List<Dictionary<String, Object>> sqlResult = DatabaseTool.ExecSqlReturn(String.Format(QUERY_USERS_SQL, UserNum));
        List<Users> users = new List<Users>();
        if (sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
        {
            return users;
        }
        else
        {
            foreach (Dictionary<String, Object> dic in sqlResult) //遍历结果集，每一条都加入list
            {
                users.Add(Users.CreateUsers(dic));
            }
        }
        return users;
    }
    //添加用户
    public static int AddUsers(String UserNum,String UserName,int type,String password,String sex,int age,String tel,String departNum)
    {
        if (DatabaseTool.ExecSql(String.Format(INSERT_USERS_SQL, UserNum, UserName, type,password,sex,age,tel,departNum)))
        {
            return DatabaseTool.GetLastInsertId();
        }
        else return -1;
    }
    //根据用户号删除用户
    public static bool DeleteUser(String UserNum)
    {
        return DatabaseTool.ExecSql(String.Format(DELETE_USERS_SQL, UserNum));
    }
    //更新用户
    // "update users set u_name=\"{0}\",type={1},password=\"{2}\",sex=\"{3}\",age={4},tel=\"{5}\",dep_num=\"{6}\"  where u_num=\"{7}\" ";
    public static bool UpdateUser(String UserName,int type,String password,String sex,int age,String tel,String departNum,String UserNum)
    {
        return DatabaseTool.ExecSql(String.Format(UPDATE_USERS_SQL, UserName,type,password,sex,age,tel,departNum,UserNum));
    }

}