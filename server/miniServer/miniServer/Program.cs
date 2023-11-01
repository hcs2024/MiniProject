using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using SimpleTCP;

namespace miniServer
{
    class Program
    {
        static SimpleTcpServer server;

        static void Main(string[] args)
        {
            Server.Instance.Start();
        }
    }
}
