using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DeviceService 的摘要说明
/// </summary>
public class DeviceService
{
    private const String QUERY_DEVICE_SQL = "select * from device where d_num=\"{0}\"  ";
    private const String INSERT_DEVICE_SQL = "insert into device(d_num,d_name,manufacter,single_price,dep_num) values (\"{0}\",\"{1}\",\"{2}\",{3},\"{4}\" )";
    private const String DELETE_DEVICE_SQL = "delete from device where d_num=\"{0}\" ";
    private const String UPDATE_DEVICE_SQL = "update device set d_name=\"{0}\" ,manufacter=\"{1}\", single_price={2} ,dep_num=\"{3}\"  where d_num=\"{4}\" ";

    public static List<Device> QueryDeviceByNum(String deviceNum)
    {
        List<Dictionary<String, Object>> sqlResult = DatabaseTool.ExecSqlReturn(String.Format(QUERY_DEVICE_SQL, deviceNum));
        List<Device> device = new List<Device>();
        if (sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
        {
            return device;
        }
        else
        {
            foreach (Dictionary<String, Object> dic in sqlResult) //遍历结果集，每一条都加入list
            {
                device.Add(Device.CreateDevice(dic));
            }
        }
        return device;
    }
    //添加设备
    public static int AddDevice(String deviceNum, String deviceName, String manufacter, Decimal single_price, String dep_num)
    {
        if (DatabaseTool.ExecSql(String.Format(INSERT_DEVICE_SQL, deviceNum, deviceName, manufacter, single_price, dep_num)))
        {
            return DatabaseTool.GetLastInsertId();
        }
        else return -1;
    }
    //根据设备号删除药品
    public static bool DeleteDevice(String deviceNum)
    {
        return DatabaseTool.ExecSql(String.Format(DELETE_DEVICE_SQL, deviceNum));
    }
    //更新设备信息
    // private const String UPDATE_DEVICE_SQL = "update device set d_name=\"{1}\" ,manufacter=\"{2}\", single_price={3} dep_num=\"{5}\"  where d_num="\{5}\" ";
    public static bool UpdateDevice(String deviceName,String manufacter,Decimal singlePrice, String departNum,String deviceNum)
    {
        return DatabaseTool.ExecSql(String.Format(UPDATE_DEVICE_SQL, deviceName,manufacter,singlePrice,departNum,deviceNum));
    }
}