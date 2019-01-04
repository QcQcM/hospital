using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public class DatabaseTool
    {
        public static MySqlConnection sqlConnection;
        public static MySqlConnection GetSqlConnection()
        {
            if(sqlConnection == null || sqlConnection.State== System.Data.ConnectionState.Closed)
            {
            String str = "Server=localhost;Database=hospital;User ID=root;PWD=123456";
                sqlConnection = new MySqlConnection(str);
                sqlConnection.Open();
            }
            return sqlConnection;
        }
        public static bool ExecSql (String sql)
        {
            MySqlCommand command = new MySqlCommand(sql, GetSqlConnection());
            return command.ExecuteNonQuery() > 0 ? true : false; 
        }
        public static int GetLastInsertId()
        {
            MySqlCommand command = new MySqlCommand("SELECT LAST_INSERT_ID()", GetSqlConnection());
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int result = reader.GetInt32(0);
            reader.Close();
            return result;
        }
        public static List<Dictionary<String,Object>> ExecSqlReturn(String sql) //返回查找结果集的
        {
            List<Dictionary<String, Object>> list = new List<Dictionary<String, Object>>();
            MySqlCommand command = new MySqlCommand(sql, GetSqlConnection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Dictionary<string, Object> keyValues = new Dictionary<string,Object>();
                for(int i=0;i< reader.FieldCount; i++)
                {
                    keyValues.Add(reader.GetName(i),reader.GetFieldValue<Object>(i));
                }
                list.Add(keyValues);
            }
            reader.Close();
            return list;
        }
        public  static Object ExeclSqlReturnItem(String sql,String item) //查找返回结果中某字段的值,查找结果唯一
        {
            MySqlCommand command = new MySqlCommand(sql, GetSqlConnection());
            Object result = "-1";
            MySqlDataReader reader = command.ExecuteReader(); //执行查询操作得到查找结果集
            while (reader.Read())
            {
                result = reader[item];
            }
           reader.Close();
            return result;
        }
       public static Decimal ExeclSqlDecimal(String sql)
    {
        MySqlCommand command = new MySqlCommand(sql, GetSqlConnection());
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            Decimal result = reader.GetDecimal(0);
            reader.Close();
            return result;
        }
        else
        {
            reader.Close();
            return 0;
        }
    }
    public static DataTable ExecSqlReturnTable(String sql)  //通过sql语句查询数据库中的数据，并将结果保存到DataSet数据集中，最终将该数据集中的查找结果的数据表返回
    {
        try
        {
            MySqlConnection mySqlConnection = DatabaseTool.GetSqlConnection();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, mySqlConnection);
            DataSet ds = new DataSet();
            mySqlDataAdapter.Fill(ds);
            mySqlConnection.Close();
            return (ds.Tables[0]);
        }
        catch (Exception)
        {
            throw;
        }
    }
}