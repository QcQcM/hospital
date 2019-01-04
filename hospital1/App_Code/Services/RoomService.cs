using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// RoomService 的摘要说明
/// </summary>
public class RoomService
{
    //查询、添加、修改、删除
    private const String QUERY_ROOM_SQL = "select* from  room ";
    private const String INSERT_ROOM_SQL = "insert into room(r_num,location,dep_num) values( \"{0}\",\"{1}\",\"{2}\")";
    private const String UPDATE_ROOM_SQL = "update room set location=\"{0}\",dep_num=\"{1}\" where r_num=\"{2}\" ";
    private const String DELETE_ROOM_SQL = "delete from room where r_num=\"{0}\"";
    public static List<Room> QueryRoomByNum(String roomNum)
    {
        List<Dictionary<String, Object>> sqlResult = DatabaseTool.ExecSqlReturn(String.Format(QUERY_ROOM_SQL, roomNum));
        List<Room> room = new List<Room>();
        if (sqlResult == null || sqlResult.Count < 1) //如果结果为空，返回空对象
        {
            return room;
        }
        else
        {
            foreach (Dictionary<String, Object> dic in sqlResult) //遍历结果集，每一条都加入list
            {
                room.Add(Room.CreateRoom(dic));
            }
        }
        return room;
    }
    //添加病房
    public static int AddRoom(String roomNum, String location, String departNum)
    {
        if (DatabaseTool.ExecSql(String.Format(INSERT_ROOM_SQL,roomNum, location, departNum)))
        {
            return DatabaseTool.GetLastInsertId();
        }
        else return -1;
    }
    //根据病房号删除病房
    public static bool DeleteRoom(String roomNum)
    {
        return DatabaseTool.ExecSql(String.Format(DELETE_ROOM_SQL, roomNum));
    }
    //更新病房信息
    public static bool UpdateRoom(String location,String departNum,String roomNum)
    {
        return DatabaseTool.ExecSql(String.Format(UPDATE_ROOM_SQL, location,departNum,roomNum));
    }
}