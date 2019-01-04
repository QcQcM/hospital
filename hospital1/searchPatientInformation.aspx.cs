using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class searchPatientInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        session.Text = Session["number"].ToString();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        List<Patient> patient = new List<Patient>();
        patient=PatientService.GetPatientsById(Request["number"].ToString());
        
        if (patient.Count() == 0)
        {
            Response.Write("<script language=javascript>window.alert('无此病人信息，请重新输入');");
        }
        else
        {
            //个人信息
            patient_name.Text = patient[0].Id.ToString();
            patient_sex.Text = patient[0].Sex.ToString();
            patient_number.Text = patient[0].Id.ToString();
            patient_birthday.Text = patient[0].BirthDate.ToString();
            patient_nationality.Text = patient[0].Nation.ToString();
            patient_county.Text = patient[0].Country.ToString();
            patient_tel.Text = patient[0].Tel.ToString();
            patient_age.Text = patient[0].Age.ToString();
            patient_merrige.Text = patient[0].Marriage.ToString();
            patient_work.Text = patient[0].Occupation.ToString();
            patient_id.Text = patient[0].IDNum.ToString();
            //地址信息
            patient_nativeplace.Text = patient[0].NativePlace.ToString();//籍贯
            patient_birthplace.Text = patient[0].BirthPlace.ToString();//出生地
            patient_workplace.Text = patient[0].WorkingPlace.ToString();//工作单位及地址
            patient_worktel.Text = patient[0].WorkingTel.ToString();//工作单位电话
            patient_nowaddress.Text = patient[0].Address.ToString();  //现在居住的地址           
            //patient_postcode.Text = patient[0].Postcode.ToString();       //邮编
            //入院信息
            patient_admissiontime.Text = patient[0].AdmissionTime.ToString();
            patient_dischargetime.Text = patient[0].DischargeTime.ToString();
            patient_department.Text = patient[0].Department.ToString();
            patient_doctor.Text = patient[0].PhysicanNum.ToString();
            patient_room_number.Text = patient[0].RoomNum.ToString();
            patient_bed_number.Text = patient[0].BedNum.ToString();
            patient_drug_allergy.Text = patient[0].DrugAllergy.ToString();
            patient_medical_history.Text = patient[0].MedicalHistory.ToString();
            patient_judge.Text = patient[0].Diagonse.ToString();
       }
    }
}