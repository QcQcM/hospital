using System;
using System.Collections.Generic;
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
    }
    protected void sign_up_Click(object sender, EventArgs e)
    {
        Session["number"] = null;
        Response.Write("<script language=javascript>window.alert('请先登录！');window.location.href=('login.aspx');</script>");
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        if (DeviceService.AddDevice(device_num.Text, device_name.Text, manufacturer.Text, Convert.ToDecimal(single_price.Text), depart_num.Text)!=-1)
        {
            Response.Write("<script language=javascript>window.alert('添加设备成功！');</script>");
        }
       
    }
}