using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    public class PatientService
    {
        //插入的SQL语句
        private const String INSERT_PATIENT_SQL = " insert into patient (p_number,p_name,sex,age,tel,department,drug_allergy,medical_history,room_number,bed_number,attending_physican_num,admission_time,discharge_time,IDnum,birth_date,nation,country,marriage,occupation,nativeplace,birth_place,address,workingplace,workingtel,diagnose,conditions) values(\"{0}\",\"{1}\",\"{2}\",{3},\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\",\"{23}\",\"{24}\",{25})";
        //根据病人ID查询病人的sql语句
        private const String SELECT_PATIENT_BY_ID = "select * from patient where p_number=\"{0}\" ";
       //根据病人的ID更改其信息表中的在院状态字段
       private const String UPDATE_PATIENT_CONDITION = "update patient set conditions=0 where p_number=\"{0}\" ";
       //查询病人的部分信息用于确认
       private const String SELECT_PART_INFORMATION = "select  p_name,sex,age,tel,department from patient where p_number=\"{0}\" ";
       //查找病人所有订单
       private const String SELECT_ALL_ORDERS_BY_ID = "select * from orders where patient_num=\"{0}\"";
      //更新病人出院时间为当前时间
       private const String UPDATE_DISCHARGE_TIME = "update patient set discharge_time=\"{0}\" where p_number=\"{1}\"  ";
     //查找病人的所有医嘱
       private const String SELECT_ALL_ADVICES_BY_ID = "select * from doctors_advice where p_num=\"{0}\"";
    //查询病人所有订单的总值
     private const String SELECT_ALL_PRICE= "select SUM(price) from orders where patient_num=\"{0}\"";
    //在病人入院登记时，需要将分配给病人的病床设置为不可用
    private const String UPDATE_BED_CONDITION = "update bed set isavailable=0 where b_num=\"{0}\" ";
    //执行插入操作
    public static int AddPatient(Patient patient)
        {
        //根据病人id查找病人名字，如果找到病人名字，说明有对应id的记录（因为名字不能为空），说明输入的病人id无效
        if (DatabaseTool.ExeclSqlReturnItem(string.Format(SELECT_PATIENT_BY_ID, patient.Id),"p_name").ToString().Equals("-1")==false)
        {
            return -1;
        }
        else
        {
            System.Diagnostics.Debug.Write(String.Format(INSERT_PATIENT_SQL, patient.Id, patient.Name, patient.Sex, patient.Age, patient.Tel, patient.Department, patient.DrugAllergy, patient.MedicalHistory, patient.RoomNum, patient.BedNum, patient.PhysicanNum, patient.AdmissionTime, "", patient.IDNum, patient.BirthDate, patient.Nation, patient.Country, patient.Marriage, patient.Occupation, patient.NativePlace, patient.BirthPlace, patient.Address, patient.WorkingPlace, patient.WorkingTel, patient.Diagonse, 1));
            if (DatabaseTool.ExecSql(String.Format(INSERT_PATIENT_SQL, patient.Id, patient.Name, patient.Sex, patient.Age, patient.Tel, patient.Department, patient.DrugAllergy, patient.MedicalHistory, patient.RoomNum, patient.BedNum, patient.PhysicanNum, patient.AdmissionTime, "", patient.IDNum, patient.BirthDate, patient.Nation, patient.Country, patient.Marriage, patient.Occupation, patient.NativePlace, patient.BirthPlace, patient.Address, patient.WorkingPlace, patient.WorkingTel, patient.Diagonse, 1)))
            {
                DatabaseTool.ExecSql(String.Format(UPDATE_BED_CONDITION, patient.BedNum));
                return DatabaseTool.GetLastInsertId();
            }
            else return -1;
        }
        }
        //按病人ID查找病人的操作
        public static List<Patient> GetPatientsById(String ID)
        {
            //查询返回的是一个结果集，每一个结果集是一个主键为ID的多组对应关系
            List<Dictionary<String, object>> sqlResult = DatabaseTool.ExecSqlReturn(String.Format(SELECT_PATIENT_BY_ID, ID));
            List<Patient> patient = new List<Patient>();
            if(sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
            {
                return patient;
            }
            else
            {
                foreach( Dictionary<String,Object> dic in sqlResult) //遍历结果集，每一条都加入list
                {
                    patient.Add(Patient.CreatePatient(dic));
                }
            }
            return patient;
        }
    //返回患者部分信息用于确认
     public static List<PatientPart> SearchPartInformation(String ID)
    {
        List<Dictionary<String, object>> partInformation = DatabaseTool.ExecSqlReturn(String.Format(SELECT_PART_INFORMATION,ID));
        List<PatientPart> patientParts = new List<PatientPart>();
        if(partInformation == null || partInformation.Count < 1)
        {
            return patientParts;
        }
        else
        {
            foreach (Dictionary<String, Object> dic in partInformation) //遍历结果集，每一条都加入list
            {
                patientParts.Add(PatientPart.CreatePatientPart(dic));
            }
            return patientParts;
        }
    }
        // 将患者出院未出院字段改为已经出院,返回病人信息和费用
      public static LeaveInformation LeaveHospital(String ID)
    {
            DatabaseTool.ExecSql(String.Format(UPDATE_PATIENT_CONDITION, ID)); //更新患者状态为已出院
            DatabaseTool.ExecSql(String.Format(UPDATE_DISCHARGE_TIME, System.DateTime.Now.ToString(), ID)); //插入病人出院时间
             //全部订单存放至orders
            List<Dictionary<String, Object>> sqlResult1 = DatabaseTool.ExecSqlReturn(String.Format(SELECT_ALL_ORDERS_BY_ID, ID));
            List<Order> orders = new List<Order>();
            foreach (Dictionary<String, Object> dic in sqlResult1) //遍历结果集，每一条都加入list
            {
                orders.Add(Order.CreateOrder(dic));
            }
        //获取入院时间与出院时间，计算时间差
        DateTime admissionTime = Convert.ToDateTime(DatabaseTool.ExeclSqlReturnItem(String.Format(SELECT_PATIENT_BY_ID, ID), "admission_time"));

        DateTime dischargeTime = Convert.ToDateTime(DatabaseTool.ExeclSqlReturnItem(String.Format(SELECT_PATIENT_BY_ID, ID), "discharge_time"));
           TimeSpan ts = dischargeTime.Subtract(admissionTime).Duration();
           String dateDiff = ts.Days.ToString() + "天";
           //获取全部医嘱存放至advices
           List<DoctorsAdvice> advices = new List<DoctorsAdvice>();
           List<Dictionary<String, Object>> sqlResult2 = DatabaseTool.ExecSqlReturn(String.Format(SELECT_ALL_ADVICES_BY_ID, ID));
          foreach (Dictionary<String, Object> dic in sqlResult2) //遍历结果集，每一条都加入list
          {
                advices.Add(DoctorsAdvice.CreateDoctorsAdvice(dic));
          }
        //计算最终费用存放至totalPrice
          Decimal totalPrice= DatabaseTool.ExeclSqlDecimal(String.Format(SELECT_ALL_PRICE,ID));

        //获取用户部分信息
        PatientPartInformation partInformation = new PatientPartInformation();
        List<Dictionary<String, Object>> sqlResult3 = DatabaseTool.ExecSqlReturn(String.Format(SELECT_PATIENT_BY_ID, ID));
        foreach (Dictionary<String, Object> dic in sqlResult3) //遍历结果集，每一条都加入list
        {
            partInformation = PatientPartInformation.CreatePatientInformation(dic);
        }


        //新建信息对象，返回
        LeaveInformation information = LeaveInformation.CreateLeavelInformation(advices, dateDiff, orders, totalPrice,partInformation);

        return information;
    }
}