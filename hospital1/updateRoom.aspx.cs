using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_updateRoom : System.Web.UI.Page
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
    protected void search_room_Click(object sender, EventArgs e)
    {
        List < Room > room = new List<Room>();
        room = RoomService.QueryRoomByNum(search_room.Text);
        if (room.Count() == 0)
        {
            Response.Write("<script language=javascript>window.alert('该病房编号无效！请重新输入！');</script>");
        }
        for (int i = 0; i <room.Count(); i++)
        {
            room_num.Text = room[i].RoomNumber.ToString();
            room_location.Text = room[i].Location.ToString();
            room_department.Text = room[i].DepartNumber.ToString();
        }
    }
protected void add_room_Click(object sender, EventArgs e)
    {
        if(room_num .Text .Equals ("")==false )
        {
            
            room_location.ReadOnly = false;
            room_department.ReadOnly = false;
        }
        
    }

    protected void delete_room_Click(object sender, EventArgs e)
    {
        RoomService.DeleteRoom(room_num.Text);
        room_num.Text = "";
        room_location.Text ="";
        room_department.Text = "";
    }

    protected void ok_Click(object sender, EventArgs e)
    {
        if (RoomService.UpdateRoom(room_location.Text, room_department.Text, room_num.Text))
        {
            Response.Write("<script language=javascript>window.alert('更改病房信息成功');</script>");
        }
    }
}