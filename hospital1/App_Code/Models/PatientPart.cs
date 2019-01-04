using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 用于出院操作中先根据id搜索出来部分信息，进行信息确认，以免输入错误ID导致出院患者错误
/// </summary>
public class PatientPart
{
    public String Name { get; set; }
    public String Sex { get; set; }
    public int Age { get; set; }
    public String Tel { get; set; }
    public String Department { get; set; }
    
      public static PatientPart CreatePatientPart(Dictionary<String, Object> dic)
    {
        PatientPart patientPart = new PatientPart();
        patientPart.Name = (String) dic["p_name"];
        patientPart.Sex = (String)dic["sex"];
        patientPart.Tel = (String)dic["tel"];
        patientPart.Department = (String)dic["department"];
        patientPart.Age = (int)dic["age"];
        return patientPart;
    }
}