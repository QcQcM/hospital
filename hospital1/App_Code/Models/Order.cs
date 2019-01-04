using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Order 的摘要说明
/// </summary>
public class Order
{
    public String patientNum { set; get; }
    public String useNum { set; get; }  //药或者是手术或者是检查仪器的编号
    public int Amount { set; get; }
    public String doctorNum { set; get; }
    public String orderNum { set; get; }
    public int type { set; get; }
    public String orderTime { set; get; } //订单时间
    public String useTime { set; get; }//该手术或者检查使用的时间
    public Decimal price { set; get; }//该订单的总价格
    public String useName { set; get; }//该订单所使用的药品或者是手术或者是设备的名字

    public static Order CreateOrder(Dictionary<String, Object> dic)
    {
        Order order = new Order();
        order.orderNum = (String)dic["order_num"];
        order.patientNum = (String)dic["patient_num"];
        order.orderTime = (String)dic["order_time"];
        order.useNum = (String)dic["use_number"];
        order.type = (int)dic["type"];
        order.Amount = (int)dic["amount"];
        order.useTime = (String)dic["use_time"];
        order.price = (Decimal)dic["price"];
        order.useName = (String)dic["use_name"];
        order.doctorNum = (String)dic["doctor_num"];
        return order;

    }
}