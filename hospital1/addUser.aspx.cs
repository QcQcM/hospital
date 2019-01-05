using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_addUser : System.Web.UI.Page
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
        if (UsersService.AddUsers(user_num.Text, user_name.Text, type, user_password.Text, user_sex.Text, int.Parse(user_age.Text), user_phone.Text, user_department.Text) != -1)
        {
            Response.Write("<script language=javascript>window.alert('添加用户成功');</script>");
        }
    }
}