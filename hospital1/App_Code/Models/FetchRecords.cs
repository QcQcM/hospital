using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FetchRecords 的摘要说明
/// </summary>
public class FetchRecords
{
  
    public String Person { set; get; }//取药人
    public String medName { set; get; }//药品名
    public String PatientName { set; get; }//患者姓名
    public int Amount { set; get; }//取药数量
    public String PatientNum { set; get; }//患者编号
    public String MedcineNum { set; get; }//药品编号
    public String OrderNum { set; get; }//对应的订单编号

    public String FetchTime { set; get; }//取药时间
    public int FetchNumber { set; get; }//取药编号

    public static FetchRecords CreateFetchRecords(Dictionary<String, Object> dic)
    {
        FetchRecords fetchRecords = new FetchRecords();
        fetchRecords.Person = (String)dic["fetch_person"];
        fetchRecords.medName = (String)dic["med_name"];
        fetchRecords.PatientName= (String)dic["patient_name"];
        fetchRecords.Amount = (int)dic["amount"];
        fetchRecords.PatientNum = (String)dic["patient_num"];
        fetchRecords.FetchTime = (String)dic["fetch_time"];
        fetchRecords.FetchNumber =(int) dic["fetch_num"];
        return fetchRecords;
    }
}