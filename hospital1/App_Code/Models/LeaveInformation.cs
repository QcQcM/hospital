using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 该类型是病人出院时返回的信息类型
/// </summary>
public class LeaveInformation
{
    //包括病人在院期间的全部医嘱，病人的住院时长，全部订单,最终费用
    public List<DoctorsAdvice> Advices{ set; get; }
    public String LengthStay { set; get; }
    public List<Order> Orders { set; get; }
    public Decimal TotalPrice { set; get; }
    public PatientPartInformation Information { set; get; }
    public static LeaveInformation CreateLeavelInformation(List<DoctorsAdvice> advices,String lengthStay,List<Order>orders,Decimal totalPrice,PatientPartInformation partInformation)
    {
        LeaveInformation information = new LeaveInformation();
        information.Advices = advices;
        information.LengthStay = lengthStay;
        information.Orders = orders;
        information.TotalPrice = totalPrice;
        information.Information = partInformation;
        return information;
    }

}