using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    public class Department
    {
        public String Number { set; get; }
        public String Name { set; get; }
        public String Manager { set; get; }

        public static Department CreateDepartment(Dictionary<String, Object> dic)
        {
            Department department = new Department();
            department.Number = (String)dic["d_number"];
        try {
            department.Name = (String)dic["d_name"];
        }
        catch (InvalidCastException e)
        {
            department.Name = "";
        }
        try
        {
            department.Manager = (String)dic["d_manager"];
        }
        catch (InvalidCastException e)
        {
            department.Manager = "";
        }
        return department;

    }
    }