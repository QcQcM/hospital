using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_updateDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        session.Text = Session["number"].ToString();
    }

    protected void Search_Department_Click(object sender, EventArgs e)
    {
        List < Department > department = new List<Department>();
        department = DepartmentService.QueryDepartmentByNum(Department_num.Text);
        if (department.Count() == 0)
        {
            Response.Write("<script language=javascript>window.alert('该科室编号无效！请重新输入！');</script>");
        }
          
        for (int i = 0; i < department.Count(); i++)
        {
            department_num1.Text = department[i].Number.ToString();
            department_name.Text = department[i].Name.ToString();
            department_user.Text = department[i].Manager.ToString();
        }
    }


    protected void add_department_Click(object sender, EventArgs e)
    {
        department_num1.ReadOnly = false;
        department_name.ReadOnly = false;
        department_user.ReadOnly = false;
    }

    protected void delete_department_Click(object sender, EventArgs e)
    {
        DepartmentService.DeleteDepartment(department_num1.Text);
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        if (DepartmentService.UpdateDepartment(department_name.Text, department_user.Text, department_num1.Text))
        {
            Response.Write("<script language=javascript>window.alert('更改科室信息成功');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('更改科室信息失败');</script>");
        }
    }
}