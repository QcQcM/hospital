using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Device 的摘要说明
/// </summary>
public class Device
{
    public String Number { set; get; }
    public String Name { set; get; }
    public String Manufacter { set; get; }
    public Decimal SinglePrice { set; get; }
    public String departmentNum { set; get; }

    public static Device CreateDevice(Dictionary<String, Object> dic)
    {
        Device device = new Device();
        device.Number = (String)dic["d_num"];
        try
        {
            device.Name = (String)dic["d_name"];
        }
        catch (InvalidCastException e)
        {
            device.Name = "";
        }
        try
        {
            device.Manufacter = (String)dic["manufacter"];
        }
        catch (InvalidCastException e)
        {
            device.Manufacter = "";
        }
        try
        {
            device.SinglePrice = (Decimal)dic["single_price"];
        }
        catch (InvalidCastException e)
        {
            device.SinglePrice = 0;
        }
        try
        {
            device.departmentNum = (String)dic["dep_num"];
        }
        catch (InvalidCastException)
        {
            device.departmentNum = "";
        }
        return device;
    }
}