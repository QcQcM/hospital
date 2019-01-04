using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class LoginService
    {
        private const String QUERY_USER_SQL = "select * from users where u_num=\"{0}\"  and password=\"{1}\" ";
        public static int indentifyUser(String username,String password)
        {
            Object selectType = DatabaseTool.ExeclSqlReturnItem(String.Format(QUERY_USER_SQL, username, password), "type");
            String type = selectType.ToString();
            if (type.Equals("-1"))
                return -1;
            else
            {
                return int.Parse(type);
            }
        }
       public static String returnName(String username,String password)
      {
        return DatabaseTool.ExeclSqlReturnItem(String.Format(QUERY_USER_SQL, username, password), "u_name").ToString();
    }
    }