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
    internal class JoinRoom
    {
        Room_mod rm = new Room_mod();
        System.Net.Sockets.TcpClient client;
        MainBLL BASE;

        internal JoinRoom(DataPackage data, MainBLL BASE)
        {
            rm.FromBytes(data.Data);
            client = data.Client;
            this.BASE = BASE;
        }

        internal void Response()
        {
            try
            {
                SockSender sender = new SockSender();
                if (rm.User_id == "" || rm.Room_name == "")
                {
                    sender.SendMessage(new DataPackage
                    {
                        Client = client,
                        Data = rm.ToBytes(libData.ConstData.OP_code_CreateRoom_Failed, rm.Uid)
                    });
                    return;
                }
                if (!RoomControl.Rooms.ContainsKey(rm.Room_name))
                {
                    sender.SendMessage(new DataPackage
                    {
                        Client = client,
                        Data = rm.ToBytes(libData.ConstData.OP_code_JoinRoom_RoomExistsFailed, rm.Uid)
                    });
                    return;
                }

                Room room = RoomControl.Rooms[rm.Room_name];
                if (room.Users.ContainsKey(rm.User_id))
                {
                    sender.SendMessage(new DataPackage
                    {
                        Client = client,
                        Data = rm.ToBytes(libData.ConstData.OP_code_JoinRoom_NameTaken, rm.Uid)
                    });
                    return;
                }
                if (room.EoomInfo.Room_key != rm.Room_key)
                {
                    sender.SendMessage(new DataPackage
                    {
                        Client = client,
                        Data = rm.ToBytes(libData.ConstData.OP_code_JoinRoom_RoomKeyError, rm.Uid)
                    });
                    return;
                }

                BASE.user.Room_id = rm.Room_name;
                BASE.user.User_id = rm.User_id;
                BASE.user.Client = client;

                lock (room)
                {
                    room.Users.Add(rm.User_id, BASE.user);
                }
                sender.SendMessage(new DataPackage
                {
                    Client = client,
                    Data = rm.ToBytes(libData.ConstData.OP_code_JoinRoom_Succeed, rm.Uid)
                });
            }
            catch
            {
                SockSender sender = new SockSender();
                sender.SendMessage(new DataPackage
                {
                    Client = client,
                    Data = rm.ToBytes(libData.ConstData.OP_code_JoinRoom_Failed, rm.Uid)
                });
            }
        }
    }
}
