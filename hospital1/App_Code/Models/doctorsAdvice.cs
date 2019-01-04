using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// doctorsAdvice 的摘要说明
/// </summary>
public class DoctorsAdvice
{
    public String DoctorNum { set; get; } //医生编号
    public String PatientNum { set; get; }//患者编号
    public String Time { set; get; }//医嘱给出时间
    public String Content { set; get; }//医嘱内容
    public int Type { set; get; }//医嘱类型：0为治疗医嘱，1为出院医嘱
    public String DoctorName { set; get; }//医生名字
    public static DoctorsAdvice CreateDoctorsAdvice(Dictionary<String,Object> dic)
    {
        DoctorsAdvice doctorsAdvice = new DoctorsAdvice();
        doctorsAdvice.DoctorNum =(String) dic["d_num"];
        doctorsAdvice.PatientNum = (String)dic["p_num"];
        doctorsAdvice.Time = dic["time"].ToString();
        doctorsAdvice.DoctorName = (String)dic["d_name"];
        try
        {
            doctorsAdvice.Content = (String)dic["content"];
        }
        catch (InvalidCastException)
        {
            doctorsAdvice.Content = "";
        }
        try
        {
            doctorsAdvice.Type = (int)dic["type"];
        }
        catch (InvalidCastException)
        {
            doctorsAdvice.Type = 0;
        }
        return doctorsAdvice;
    }
}