using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libInvoker;
using MemoryData;
using Model;
using libNetwork.Sockets;

namespace libInvoker.Invokers
{
    internal class ExitRoom
    {
        internal bool Exit(MainBLL BASE)
        {
            try
            {
                if (BASE.user.Room_id == "" || BASE.user.User_id == "")
                    return false;
                if (!RoomControl.Rooms.ContainsKey(BASE.user.Room_id))
                    return false;
                Room room = RoomControl.Rooms[BASE.user.Room_id];
                if (!room.Users.ContainsKey(BASE.user.User_id))
                    return false;
                lock (RoomControl.Rooms)
                {
                    room.Users.Remove(BASE.user.User_id);
                    if (room.Users.Count == 0)
                        RoomControl.Rooms.Remove(BASE.user.Room_id);
                    return true;
                }
                BASE.user = new Model.Structs.UserData_mod();
            }
            catch
            {
                return false;
            }
        }
    }
}
