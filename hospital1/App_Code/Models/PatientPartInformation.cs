using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 出院打印的记录中的部分病人信息，应该包括病人姓名、性别、年龄、入院时间、出院时间、入院诊断
/// //出院返回的信息里面要添加一个这个类型的对象
/// </summary>
public class PatientPartInformation
{
    public String PatientName { set; get; } //患者姓名
    public String Sex { set; get; }//性别
    public int Age { set; get; }//年龄
    public String AdmissionTime { set; get; }//入院时间
    public String DischargeTime { set; get; }//出院时间
    public String Diagnose { set; get; }//入院诊断
    public static PatientPartInformation CreatePatientInformation(Dictionary<String, Object> dic)
    {
        PatientPartInformation information = new PatientPartInformation();
        try
        {
            information.PatientName =(String) dic["p_name"];
        }
        catch (InvalidCastException)
        {
            information.PatientName = "";
        }
        try
        {
            information.Sex = (String)dic["sex"];
        }
        catch (InvalidCastException)
        {
            information.Sex = "";
        }
        try
        {
            information.Age = (int)dic["age"];
        }
        catch(InvalidCastException)
        {
            information.Age = 0;
        }
        try
        {
            information.DischargeTime = (String)dic["discharge_time"];
        }
        catch (InvalidCastException)
        {
            information.DischargeTime = "";
        }
        try
        {
            information.AdmissionTime = (String)dic["admission_time"];
        }
        catch (InvalidCastException)
        {
            information.AdmissionTime = "";
        }
        try
        {
            information.Diagnose = (String)dic["diagnose"];
        }
        catch (InvalidCastException)
        {
            information.Diagnose = "";
        }
        return information;

    }
}