using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Room 的摘要说明
/// </summary>
public class Room
{
    public String RoomNumber { set; get; }
    public String Location { set; get; }
    public String DepartNumber { set; get; }
    public static Room CreateRoom(Dictionary<String, Object> dic)
    {
        Room room = new Room();
        room.RoomNumber = (String)dic["r_num"];
        room.Location = (String)dic["location"];
        room.DepartNumber = (String)dic["dep_num"];
        return room;
    }
}