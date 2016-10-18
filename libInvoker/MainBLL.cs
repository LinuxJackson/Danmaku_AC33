using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Model;
using Model.Structs;
using libInvoker.Invokers;

namespace libInvoker
{
    public class MainBLL
    {
        public UserData_mod user = new UserData_mod();

        public void Analysis(DataPackage data)
        {
            new Thread(delegate ()
            {
                byte[] bType = new byte[2];
                bType[0] = data.Data[0];
                bType[1] = data.Data[1];
                short type = BitConverter.ToInt16(bType, 0);

                if (type == 0)
                    Thread.CurrentThread.Abort();
                switch (type)
                {
                    case 1:
                        Message message = new Message(data, this);
                        message.Response();
                        break;
                    case 2:
                        CreateRoom createRoom = new CreateRoom(data, this);
                        createRoom.Response();
                        break;
                    case 3:
                        ExitRoom exitRoom = new ExitRoom();
                        exitRoom.Exit(this);
                        break;
                    case 4:
                        JoinRoom joinRoom = new JoinRoom(data, this);
                        joinRoom.Response();
                        break;
                }

            }).Start();
        }
    }
}
