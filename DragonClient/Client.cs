using DragonClient.Context;
using DragonClient.Packet;
using DragonClient.Structure;
using DragonLib.IO;
using DragonLib.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

//by XIAN
namespace DragonClient
{
    public sealed class Client
    {
        public byte[] Session;
        public uint Magic;
        public string Hwid;
        public string Ip;

        public int TcpPort;
        public short UdpPort;

        public bool MailUponLogin;
        public int MailboxNPCID;

        public Session session;

        private ContextBase m_context;

        public Socket TCPsocket;
        public Socket UDPsocket;

        public Account account;

        public bool AutoRestart = true;
        public bool OpeningGoldPouches = false;
        public bool OpeningMail = false;

        public Queue<long> GoldPouches = new Queue<long>();
        public Thread GoldPouchOpenThread;

        public Regions Region = 0;

        public void Migrate(string ip,int port,ServerType type)
        {

            if (type == ServerType.Login || type == ServerType.Town)
            {

                TCPsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                TCPsocket.Connect(ip, port);
                session = new Session(TCPsocket);
                TcpPort = port;

               
            }
            else if (type == ServerType.Field)
            {
                TCPsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                TCPsocket.Connect(ip, port);
                session = new Session(TCPsocket);
                TcpPort = port;
            }

            Ip = ip;
             
            if (m_context != null)
                m_context.Disconnect();

            switch(type)
            {
                case ServerType.Login:
                    m_context = new LoginContext(this, session);
                    break;
                case ServerType.Town:
                    m_context = new TownContext(this, session);
                    break;
                case ServerType.Field:
                    m_context = new FieldContext(this, session);
                    break;
            }
        }

    }
}
