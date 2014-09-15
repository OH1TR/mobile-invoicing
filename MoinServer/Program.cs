using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Logging;
using SuperSocket.SocketEngine;
using SuperWebSocket;
using SuperWebSocket.SubProtocol;



namespace MoinServer
{
    class Program
    {
        protected WebSocketServer WebSocketServer { get; private set; }

        protected void Setup(WebSocketServer websocketServer, Action<ServerConfig> configurator)
        {
            var rootConfig = new RootConfig { DisablePerformanceDataCollector = true };

            websocketServer.NewDataReceived += new SessionHandler<WebSocketSession, byte[]>(WebSocketServer_NewDataReceived);
            websocketServer.NewMessageReceived += websocketServer_NewMessageReceived;
            websocketServer.NewSessionConnected += websocketServer_NewSessionConnected;

            var config = new ServerConfig();
            configurator(config);

            var ret = websocketServer.Setup(rootConfig, config, null, null, new ConsoleLogFactory(), null, null);

            WebSocketServer = websocketServer;
        }

        void websocketServer_NewMessageReceived(WebSocketSession session, string value)
        {
            session.Send(value + "rep");
        }

        void websocketServer_NewSessionConnected(WebSocketSession session)
        {
            System.Threading.Thread.Sleep(1);
        }


        protected void WebSocketServer_NewMessageReceived(WebSocketSession session, string e)
        {
            session.Send(e);
        }

        protected void WebSocketServer_NewDataReceived(WebSocketSession session, byte[] e)
        {
            session.Send(e, 0, e.Length);
        }


        static void Main(string[] args)
        {
            Program p = new Program();
            p.Setup(new WebSocketServer(), c =>
                {
                    c.Port = 8181;
                    c.Ip = "Any";
                    c.MaxConnectionNumber = 100;
                    c.MaxRequestLength = 100000;
                    c.Name = "SuperWebSocket Server";
                });
            p.WebSocketServer.Start();
            Console.ReadLine();
        }

    }
}
