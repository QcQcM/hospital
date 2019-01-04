using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class DepartmentService
    {
        private const String INSERT_DEPARTMENT_SQL = "insert into department(d_number,d_name,d_manager) values (\" {0} \",\"{1}\",\"{2}\")";
        private const String UPDATE_DEPARTMENT_SQL = "update department set d_name=\"{0}\",d_manager=\"{1}\"  where d_number=\"{2}\" ";
        private const String QUERY_DEPARTMENT_SQL = "select * from department where d_number=\"{0}\" ";
        private const String DELETE_DEPARTMENT_SQL = "delete from department where d_number=\"{0}\" ";
        
        public static List<Department> QueryDepartmentByNum(String departmentNum)
        {
            List<Dictionary<String, Object>> sqlResult= DatabaseTool.ExecSqlReturn(String.Format(QUERY_DEPARTMENT_SQL, departmentNum));
            List<Department> department = new List<Department>();
            if (sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
            {
                return department;
            }
            else
            {
                foreach (Dictionary<String, Object> dic in sqlResult) //遍历结果集，每一条都加入list
                {
                    department.Add(Department.CreateDepartment(dic));
                }
            }
            return department;
        }
        public static int AddDepartment(String departNum, String departName, String departManager)
        {
            if (DatabaseTool.ExecSql(String.Format(INSERT_DEPARTMENT_SQL,departNum,departName,departManager)))
            {
                return DatabaseTool.GetLastInsertId();
            }
            else return -1;
        }
        //根据科室号删除科室
        public static bool DeleteDepartment(String departNum)
        {
            return DatabaseTool.ExecSql(String.Format(DELETE_DEPARTMENT_SQL, departNum));
        }
      //更新科室
        public static bool UpdateDepartment(String departName,String departManager,String departNum)
        {
            return DatabaseTool.ExecSql(String.Format(UPDATE_DEPARTMENT_SQL, departName,departManager,departNum));
        }
       
    }