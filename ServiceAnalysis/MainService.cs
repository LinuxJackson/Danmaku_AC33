using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libNetwork.Sockets;
using System.Net.Sockets;
using libInvoker;
using System.Threading;
using Model;

namespace ServiceAnalysis
{
    public class MainService
    {
        public void Start()
        {
            while (true)
            {
                TcpClient client = GetClient.Get();

                new Thread(delegate ()
                {
                    try
                    {
                        SockReceiver rece = new SockReceiver();
                        MainBLL main = new MainBLL();
                        while (true)
                            main.Analysis(rece.ReceiveData(client));
                    }
                    catch
                    {
                        Thread.CurrentThread.Abort();
                    }
                }).Start();
            }
        }
    }
}
