using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Model.Structs;
using libNetwork.Sockets;
using MemoryData;

namespace libInvoker.Invokers
{
    internal class Message
    {
        System.Net.Sockets.TcpClient client;
        Message_mod message = new Message_mod();
        byte[] data;
        MainBLL BASE;

        internal Message(DataPackage data, MainBLL BASE)
        {
            client = data.Client;
            message.FromBytes(data.Data);
            this.data = data.Data;
            this.BASE = BASE;
        }

        internal void Response()
        {
            try
            {
                if (BASE.user.User_id != message.Sender)
                    return;
                if (!RoomControl.Rooms.ContainsKey(BASE.user.Room_id))
                    return;
                Room room = RoomControl.Rooms[BASE.user.Room_id];
                if (!room.Users.ContainsKey(BASE.user.User_id))
                    return;

                SockSender sender = new SockSender();
                lock (room)
                {
                    foreach (UserData_mod ud in room.Users.Values)
                    {
                        new System.Threading.Thread(
                            delegate ()
                            {
                                sender.SendMessage(new DataPackage
                                {
                                    Client = ud.Client,
                                    Data = data
                                });
                            }
                            ).Start();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
