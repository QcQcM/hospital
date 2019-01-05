using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_updateUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        session.Text = Session["number"].ToString();
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }

    protected void search_user_Click(object sender, EventArgs e)
    {
        List < Users > users = new List<Users>();
       users =UsersService.QueryUsersByNum(user_search.Text);
        if (users.Count() == 0)
        {
            Response.Write("<script language=javascript>window.alert('该用户账号无效！请重新输入！');</script>");
        }
        for (int i = 0; i < users.Count(); i++)
        {
            user_name.Text = users[i].UserName.ToString();
            user_num.Text = users[i].UserNum.ToString();
            if (users[i].Type == 1)
                user_type.Text = "护士";
            else
                user_type.Text = "医生";
            user_sex.Text = users[i].Sex.ToString();
            user_password.Text = users[i].Password.ToString();
            user_age.Text = users[i].Age.ToString();
            user_phone.Text = users[i].Tel.ToString();
            user_department.Text = users[i].DepartmentNum.ToString();
        }
       
    }


    protected void update_user_Click(object sender, EventArgs e)
    {
        user_num.ReadOnly = false;
        user_name.ReadOnly = false;
        user_type.ReadOnly = false;
        user_password.ReadOnly = false;
        user_sex.ReadOnly = false;
        user_age.ReadOnly = false;
        user_phone.ReadOnly = false;
        user_department.ReadOnly = false;
    }

    protected void delete_user_Click(object sender, EventArgs e)
    {
        UsersService.DeleteUser(user_num.Text);
    }

    protected void ok_user_Click(object sender, EventArgs e)
    {
       if(UsersService.UpdateUser(user_name.Text, int.Parse(user_type.Text), user_password.Text, user_sex.Text, int.Parse(user_type.Text), user_phone.Text, user_department.Text, user_num.Text))
        {
            Response.Write("<script language=javascript>window.alert('更改用户信息成功');</script>");
        }
    }
}