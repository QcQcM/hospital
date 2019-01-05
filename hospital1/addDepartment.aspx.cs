using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_addDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        else
        {
            session.Text = Session["number"].ToString();
        }
       
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if(DepartmentService.AddDepartment(text1.Text, TextBox2.Text, TextBox3.Text)!=-1)
        {
            Response.Write("<script language=javascript>window.alert('添加科室成功');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('该科室编号已存在，请输入其他编号！');</script>");
        }
    }
}