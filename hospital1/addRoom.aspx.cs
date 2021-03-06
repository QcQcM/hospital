﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_addRoom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
        }
        System.Diagnostics.Debug.Write(Session["number"]);
        session.Text = Session["number"].ToString();
        DataTable dt = DatabaseTool.ExecSqlReturnTable("select * from department");
        room_department.DataSource = dt;
        room_department.DataTextField = "d_name";
        room_department.DataBind();
    }

    protected void add_Room_Click(object sender, EventArgs e)
    {
       if(RoomService.AddRoom(room_num.Text, room_location.Text, room_department.Text)!= -1){
            {
                Response.Write("<script language=javascript>window.alert('添加病房成功');</script>");
                room_num.Text = "";
                room_location.Text = "";
                room_department.Text = "";
            }
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('该病房编号已存在，请输入其他编号！');</script>");
        }
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }
}