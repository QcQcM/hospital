using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_addUser : System.Web.UI.Page
{
    public string id;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        session.Text = Session["number"].ToString();
        if(!IsPostBack )
        {
            DataTable dt = DatabaseTool.ExecSqlReturnTable("select * from department");
            user_department.DataSource = dt;
            user_department.DataTextField = "d_name";
            user_department.DataValueField = "d_number";
            user_department.DataBind();
        }
        
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }

    protected void user_add_Click(object sender, EventArgs e)
    {
        int type;
        if (user_type.Text == "医生")
        {
            type = 3;

        }
        else
        {
            type = 1;
        }
        if (UsersService.AddUsers(user_num.Text, user_name.Text, type, user_password.Text, user_sex.Text, int.Parse(user_age.Text), user_phone.Text, user_department.SelectedItem .Text .Trim ()) != -1)
        {
            Response.Write("<script language=javascript>window.alert('添加用户成功');</script>");
            user_num.Text = ""; user_name.Text = "";
            user_password.Text = "";
            user_age.Text = "";
            user_phone.Text = "";
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('该用户编号已存在，请输入其他编号！');</script>");
        }
    }
   
    protected void user_department_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.id = this.user_department.SelectedValue;
        this.user_department.DataSource = DatabaseTool.ExecSqlReturnTable("select * from department where d_number= " + id);
        this.user_department.DataTextField = "d_name";
        this.user_department.DataValueField = "d_number";
        
        user_department.DataBind();

    }
}