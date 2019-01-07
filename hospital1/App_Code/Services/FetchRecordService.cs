 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FetchRecordService 的摘要说明
/// </summary>
public class FetchRecordService
{
    private const String INSERT_FETCHRECORDS_SQL = "insert into fetch_medicine(fetch_person,med_name,patient_name,amount,patient_num,fetch_time) values(\"{0}\",\"{1}\",\"{2}\",{3},\"{4}\",\"{5}\")";
    private const String QUERY_FETCHRECORDS_SQL = "select * from fetch_medicine where patient_num=\"{0}\" ";
    private const String UPDATE_MEDICINE_AMOUNT_SQL = "update medicine set amount={0} where m_num=\"{1}\" ";
    //插入取药记录
    public static int AddFetchRecords(List<FetchRecords> fetchRecords)
    {
        for (int i = 0; i < fetchRecords.Count; i++)
        {
            int nowAmout = Convert.ToInt32(DatabaseTool.ExeclSqlReturnItem(String.Format("select * from medicine", fetchRecords[i].MedcineNum), "amount"));
            nowAmout = nowAmout-fetchRecords[i].Amount;
            if (nowAmout < 0) return -1;
            else
            {
                DatabaseTool.ExecSql(String.Format(INSERT_FETCHRECORDS_SQL, fetchRecords[i].Person, fetchRecords[i].medName, fetchRecords[i].PatientName, fetchRecords[i].Amount, fetchRecords[i].PatientNum, fetchRecords[i].FetchTime));
                DatabaseTool.ExecSql(String.Format(UPDATE_MEDICINE_AMOUNT_SQL, nowAmout, fetchRecords[i].MedcineNum));
                DatabaseTool.ExecSql(String.Format("update orders set isfetch=1 where order_num =\"{0}\" ",fetchRecords[i].OrderNum));

            }

        }
        return 1;
    }
    //查询取药记录
    public static List<FetchRecords> QueryFetchByNum(String patientNum)
    {
        List<Dictionary<String, Object>> sqlResult = DatabaseTool.ExecSqlReturn(String.Format(QUERY_FETCHRECORDS_SQL, patientNum));
        List<FetchRecords> fetchRecords = new List<FetchRecords>();
        if (sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
        {
            return fetchRecords;
        }
        else
        {
            foreach (Dictionary<String, Object> dic in sqlResult) //遍历结果集，每一条都加入list
            {
                fetchRecords.Add(FetchRecords.CreateFetchRecords(dic));
            }
        }
        return fetchRecords;
    }
    public static int JudgeFetchDuplicate(String fetchNum)
    {
        List<FetchRecords> fetchRecords = new List<FetchRecords>();
        fetchRecords = FetchRecordService.QueryFetchByNum(fetchNum);
        if (fetchRecords.Count == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}