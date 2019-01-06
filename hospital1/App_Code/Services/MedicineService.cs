
using System;
using System.Collections.Generic;

public class MedicineService
    {
        private const String QUERY_MEDICINE_SQL = "select * from medicine where m_num=\"{0}\"  ";
        private const String INSERT_MEDICINE_SQL =  "insert into medicine(m_num,m_name,manufactor,price,amount,type) values (\"{0}\",\"{1}\",\"{2}\",{3},{4},\"{5}\" )";
        private const String DELETE_MEDICINE_SQL = "delete from medicine where m_num=\"{0}\" ";
        private const String UPDATE_MEDICINE_SQL = "update medicine set m_name=\"{0}\", manufactor=\"{1}\", price={2}, amount={3}, type=\"{4}\"  where m_num=\"{5}\" ";

        public static List<Medicine> QueryMedicineByNum(String medicineNum)
        {
            List<Dictionary<String, Object>> sqlResult = DatabaseTool.ExecSqlReturn(String.Format(QUERY_MEDICINE_SQL, medicineNum));
            List<Medicine> medicine = new List<Medicine>();
            if (sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
            {
                return medicine;
            }
            else
            {
                foreach (Dictionary<String, Object> dic in sqlResult) //遍历结果集，每一条都加入list
                {
                    medicine.Add(Medicine.createMedicine(dic));
                }
            }
            return medicine;
        }
        //添加药品
        public static int AddMedicine(String medNum,String medName,String manufactor,Decimal price,Int32 amount,String type)
        {
        if (DatabaseTool.ExeclSqlReturnItem(string.Format(QUERY_MEDICINE_SQL, medNum), "m_name").ToString().Equals("-1") == false)
        {
            return -1;
        }
        if (DatabaseTool.ExecSql(String.Format(INSERT_MEDICINE_SQL, medNum, medName, manufactor,price,amount,type)))
            {
                return DatabaseTool.GetLastInsertId();
            }
            else return -1;
        }
        //根据药品号删除药品
        public static bool DeleteMedicine(String medNum)
        {
            return DatabaseTool.ExecSql(String.Format(DELETE_MEDICINE_SQL, medNum));
        }
       //更新药品信息
        public static bool UpdateMedicine(String medName,String manufactor,Decimal price,int amount,String type, String medNum)
        {
        // private const String UPDATE_MEDICINE_SQL = "update medicine set m_name=\"{1}\" manufactor=\"{2}\" price={3} amount={4} type=\"{5}\"  where m_num=\"{5}\" ";
        System.Diagnostics.Debug.Write(String.Format(UPDATE_MEDICINE_SQL, medName, manufactor, price, amount, type, medNum));
            return DatabaseTool.ExecSql(String.Format(UPDATE_MEDICINE_SQL, medName,manufactor,price,amount,type,medNum));
        }
    }