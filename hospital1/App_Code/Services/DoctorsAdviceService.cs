using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DoctorsAdviceService 的摘要说明
/// </summary>
public class DoctorsAdviceService
{
    private const String INSERT_DOCTORSADVICE_SQL = "insert into doctors_advice(d_num,p_num,time,content,type,d_name) values(\"{0}\",\"{1}\",\"{2}\",\"{3}\",{4},\"{5}\")";
    private const String QUERY_DOCTORSADVICE_SQL = "select * from doctors_advice where p_num=\"{0}\" ";

    //插入医嘱
   public static int InsertDoctorsAdvice(String doctorNum,String patientNum,String content,int type,String doctorName)
    {
        if (DatabaseTool.ExecSql(String.Format(INSERT_DOCTORSADVICE_SQL, doctorNum, patientNum, System.DateTime.Now.ToString(), content, type,doctorName)))
        {
            return DatabaseTool.GetLastInsertId();
        }
        else
            return -1;

    }
    //出院时查询医嘱
    public List<DoctorsAdvice> QueryAdvicesByNum(String patientNum)
    {
        List<Dictionary<String, Object>> sqlResult = DatabaseTool.ExecSqlReturn(String.Format(QUERY_DOCTORSADVICE_SQL, patientNum));
        List<DoctorsAdvice> advices = new List<DoctorsAdvice>();
        if (sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
        {
            return advices;
        }
        else
        {
            foreach (Dictionary<String, Object> dic in sqlResult) //遍历结果集，每一条都加入list
            {
                advices.Add(DoctorsAdvice.CreateDoctorsAdvice(dic));
            }
        }
        return advices;
    }
}