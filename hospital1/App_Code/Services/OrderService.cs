using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OrderService 的摘要说明
/// </summary>
public class OrderService
{
    private const String INSERT_ORDER_SQL = "insert into orders(patient_num,use_number,amount,doctor_num,order_num,type,order_time,use_time,price,use_name,isfetch) values(\"{0}\",\"{1}\",{2},\"{3}\",\"{4}\",{5},\"{6}\",\"{7}\",{8},\"{9}\",{10}) ";
   private const String SELECT_ORDER_SQL = "select * from orders where order_num=\"{0}\" ";//按照订单编号查找订单
   // private const String SELECT_ORDER_USED_AMOUNT = "select amount from orders where order_num=\"{0}\" ";//查询订单包括的药品数量
    private const String SELECT_MEDICINE_PRICE_BYID = "select price from medicine where m_num=\"{0}\"";//在药品表查价格
    private const String SELECT_OPERATION_PRICE_BYID = "select single_price from operation where o_num=\"{0}\"";//在手术表查价格
    private const String SELECT_DEVICE_PRICE_BYID = "select single_price from device where d_num=\"{0}\" ";//在设备表查价格

    //重载函数
    //函数一用于插入检查订单或者手术订单
    //函数一需要传入 患者编号、手术或者检查的编号、医生的编号、订单编号、类型（用于区分三类操作：药品是1 手术是2 检查是3）、使用的时间
    public static List<Order> QueryOrderByNum(String orderNum)
    {
        List<Dictionary<String, Object>> sqlResult = DatabaseTool.ExecSqlReturn(String.Format(SELECT_ORDER_SQL, orderNum));
        List<Order> order = new List<Order>();
        if (sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
        {
            return order;
        }
        else
        {
            foreach (Dictionary<String, Object> dic in sqlResult) //遍历结果集，每一条都加入list
            {
                order.Add(Order.CreateOrder(dic));
            }
        }
        return order;
    }
    //判断订单编号是否已经存在在数据库里
    public static int JudgeOrderDuplicate(String orderNum)
    {
        List<Order> orders = new List<Order>();
        orders = OrderService.QueryOrderByNum(orderNum);
        if(orders.Count == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
    public static int AddOrder(String patientNum, String useNum, String doctorNum, String orderNum, int type, String use_time)
    {
        String useName;
        Decimal price;
        if (type == 2)
        {
            price = (Decimal)DatabaseTool.ExeclSqlReturnItem(String.Format(SELECT_OPERATION_PRICE_BYID, useNum), "single_price");
            useName = (String)DatabaseTool.ExeclSqlReturnItem(String.Format("select * from operation where o_num =\"{0}\"",useNum), "o_name");
        }
        else if (type == 3)
        {
            price = (Decimal)DatabaseTool.ExeclSqlReturnItem(String.Format(SELECT_DEVICE_PRICE_BYID, useNum), "single_price");
            useName = (String)DatabaseTool.ExeclSqlReturnItem(String.Format("select * from device where d_num =\"{0}\"", useNum), "d_name");
        }
        else
        {
            return -1;
        }
        if (DatabaseTool.ExecSql(String.Format(INSERT_ORDER_SQL,patientNum,useNum,1,doctorNum,orderNum, type,System.DateTime.Now.ToString(),use_time,price,useName,0)))
        {
            return DatabaseTool.GetLastInsertId();

        }
        else{
            return -1;
        }
    }
    //函数二用于插入药品订单 
    //函数二需要传入 患者编号、药品编号、数量、医生的编号、订单编号、类型（用于区分三类操作：药品是1 手术是2 检查是3）
    public static int AddOrder(String patientNum,String useNum,int amount,String doctorNum,String orderNum,int type)
    {
        String useName = (String)DatabaseTool.ExeclSqlReturnItem(String.Format("select * from medicine where m_num =\"{0}\"", useNum), "m_name");
        Decimal price = (Decimal)DatabaseTool.ExeclSqlReturnItem(String.Format(SELECT_MEDICINE_PRICE_BYID, useNum), "price");
        price *= amount;
        if (DatabaseTool.ExecSql(String.Format(INSERT_ORDER_SQL, patientNum, useNum, amount,doctorNum, orderNum, type,System.DateTime.Now.ToString(),"",price,useName,0)))
        {
            return DatabaseTool.GetLastInsertId();
        }
        else
            return -1;
    }
}