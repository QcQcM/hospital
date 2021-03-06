﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addDevice : System.Web.UI.Page
{
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
            depart_num.DataSource = dt;
            depart_num.DataTextField = "d_name";
            depart_num.DataBind();
        }
       

    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        if (DeviceService.AddDevice(device_num.Text, device_name.Text, manufacturer.Text, Convert.ToDecimal(single_price.Text), depart_num.Text )!=-1)
        {
            Response.Write("<script language=javascript>window.alert('添加设备成功！');</script>");
            device_num.Text = "";
            device_name.Text = "";
            manufacturer.Text = "";
            single_price.Text = "";
            
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('该设备编号已存在，请输入其他编号！');</script>");
        }

    }
}