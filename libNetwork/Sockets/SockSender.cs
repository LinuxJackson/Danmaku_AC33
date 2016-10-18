using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Model;

namespace libNetwork.Sockets
{
    public class SockSender
    {
        public bool SendMessage(DataPackage dp)
        {
            if (dp.Client == null) return false;
            try
            {
                NetworkStream streamToServer = dp.Client.GetStream();
                streamToServer.Write(dp.Data, 0, dp.Data.Length);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}