using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace libNetwork.Sockets
{
    static public class GetClient
    {
        static TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 2001);
        static public TcpClient Get()
        {
            try
            {
                listener.Start();
                return listener.AcceptTcpClient();
            }
            catch
            {
                return null;
            }

        }
    }

}
