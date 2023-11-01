using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace miniServer
{
    public class Server
    {
        public static Server Instance = new Server();

        private SimpleTcpServer tcpServer;

        public void Start(string cfg = "cfg.json")
        {
            Init();

            tcpServer = new SimpleTcpServer();
            IPAddress serverIp = IPAddress.Parse("127.0.0.1");
            tcpServer.Start(serverIp, 8888);

            Console.WriteLine("mini server start");
            tcpServer.DataReceived += OnDataReceive;

            Console.ReadLine();
        }

        public void OnDataReceive(object s, Message m)
        {

        }

        private void Init()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void OnProcessExit(object sender, EventArgs args)
        {
            tcpServer.Stop();
        }
    }
}
