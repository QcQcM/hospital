using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    public class Patient
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Sex { get; set; }
        public int Age { get; set; }
        public String Tel { get; set; }
        public String Department { get; set; }
        public String DrugAllergy { get; set; }
        public String MedicalHistory { get; set; }
        public String RoomNum { get; set; }
        public String BedNum { get; set; }
        public String PhysicanNum { get; set; }
        public String AdmissionTime { get; set; }
        public String DischargeTime { get; set; }
        public String IDNum { get; set; }
        public String BirthDate { get; set; }
        public String Nation { get; set; }
        public String Country { get; set; }
        public String Marriage { get; set; }
        public String Occupation { get; set; }
        public String NativePlace { get; set; } //籍贯
        public String BirthPlace { get; set; }//出生地
        public String Address { get; set; }
        //public String Postcode { get; set; }
        public String WorkingPlace { get; set; }
        public String WorkingTel{ get; set; }
        public String Diagonse{ get; set; }
        public int Condition { get; set; }

        public static Patient CreatePatient( Dictionary<String ,Object> dic)
        {
            Patient patient = new Patient();
            patient.Id = (String)dic["p_number"];
            patient.Name = (String)dic["p_name"];
            patient.Sex = (String)dic["sex"];
            patient.Age = (int)dic["age"];
            patient.Tel = (String)dic["tel"];
            patient.Department = (String)dic["department"];
            patient.DrugAllergy = (String)dic["drug_allergy"];
            patient.MedicalHistory = (String)dic["medical_history"];
            patient.RoomNum = (String)dic["room_number"];
            patient.BedNum = (String)dic["bed_number"];
            patient.PhysicanNum = (String)dic["attending_physican_num"];
            patient.AdmissionTime = dic["admission_time"].ToString();
            patient.DischargeTime = dic["discharge_time"].ToString();
            patient.IDNum = (String)dic["IDnum"];
        try
        {
            patient.BirthDate = dic["birth_date"].ToString();
        }
        catch (InvalidCastException e)
        {
            patient.BirthDate = "";
        }
        try
        {
            patient.Nation = (String)dic["nation"];
        }
        catch (InvalidCastException e)
        {
            patient.Nation = "";
        }
        try
        {
            patient.Country = (String)dic["country"];
        }
        catch (InvalidCastException)
        {
            patient.Country = "";
        }
        try
        {
            patient.Marriage = (String)dic["marriage"];
        }
        catch(InvalidCastException e)
        {
            patient.Marriage = "";
        }
        try
        {
            patient.Occupation = (String)dic["occupation"];
        }
         catch(InvalidCastException e)
        {
            patient.Occupation = "";
        }

           
            patient.NativePlace = (String)dic["nativeplace"];
        try
        {
            patient.BirthPlace = (String)dic["birth_place"];
        }
        catch(InvalidCastException e)
        {
            patient.BirthPlace = "";
        }
            
            patient.Address = (String)dic["address"];
        //patient.Postcode = (String)dic["postcode"];
        try
        {
            patient.WorkingPlace = (String)dic["workingplace"];
        }
        catch(InvalidCastException e)
        {
            patient.WorkingPlace = "";
        }
        try
        {
            patient.WorkingTel = (String)dic["workingtel"];
        }
        catch(InvalidCastException e)
        {
            patient.WorkingTel = "";
        }
            
            patient.Diagonse = (String)dic["diagnose"];
            patient.Condition = (int)dic["conditions"];
            return patient;
        }
    }