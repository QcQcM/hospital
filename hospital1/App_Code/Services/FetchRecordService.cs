 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FetchRecordService 的摘要说明
/// </summary>
public class FetchRecordService
{
    private const String INSERT_FETCHRECORDS_SQL = "insert into fetch_medicine(fetch_num,fetch_person,med_name,patient_name,amount,patient_num,med_num) values(\"{0}\",\"{1}\",\"{2}\",\"{3}\",{4},\"{5}\",\"{6}\")";
    private const String QUERY_FETCHRECORDS_SQL = "select * from fetch_medicine where patient_num=\"{0}\" ";
    private const String UPDATE_MEDICINE_AMOUNT_SQL = "update medicine set amount={0} where m_num=\"{1}\" ";
    //插入取药记录
    public static int AddFetchRecords(String fetchNum, String fetchPerson, String medName,String patientName,int amount,String patientNum,String medNum)
    {
        int nowAmout =(int) DatabaseTool.ExeclSqlReturnItem(String.Format(QUERY_FETCHRECORDS_SQL, medNum), "amount");
        nowAmout -= amount;
        if (nowAmout < 0) return -1;
        else
        {
            DatabaseTool.ExecSql(String.Format(INSERT_FETCHRECORDS_SQL, fetchNum, fetchPerson, medName, patientName, amount, patientNum, medNum));
            DatabaseTool.ExecSql(String.Format(UPDATE_MEDICINE_AMOUNT_SQL, nowAmout, medNum));
            return 1;
        }
        //取药，插入到取药记录表，还要更改药品信息表，将该药品的数量减去amount,先判断减去的是不是小于0，如果是，取药失败，返回-1
      
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