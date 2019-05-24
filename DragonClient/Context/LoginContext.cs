using DragonClient.Packet;
using DragonLib.IO;
using DragonLib.Network;
using System;
using System.Threading;
using System.Net;
using DragonClient.Structure;

//by XIAN
namespace DragonClient.Context
{
    public sealed class LoginContext : ContextBase
    {
        public LoginContext(Client client, Session session)
            : base(client, session, true)
        { 
        }

        public override void HandleConnected()
        {
            Console.WriteLine("Connected to login");

            if(Client.Region == Regions.SEA)
            {
                Client.Hwid = "70-62-b8-06-d4-52";
                Send(PacketFactory.Validate());
                Send(PacketFactory.Login(Client.account.Username, Client.account.Password, "192.168.1.10", Client.Hwid));
            }
                
            else if(Client.Region == Regions.THAILAND)
            {
                Send(PacketFactory.ValidateThailand());
                Send(PacketFactory.LoginThailand(Client.account.Username, Client.account.Password, "192.168.1.10"));
            } 
        }

        public override void HandlePacket(PacketReader packet)
        {
            byte[] rawHeader = packet.ReadBytes(3);
            short length = packet.ReadShort();
            short opcode = packet.ReadShort();

            switch (opcode)
            {
                case RecvOps.Validate:
                    PacketHandler.HandleValidation(this, packet);
                    break;
                case RecvOps.LoginResponse:
                    PacketHandler.HandleLoginRespose(this, packet);
                    break;

                case RecvOps.WorldInfo:
                    PacketHandler.HandleWorldList(this, packet);
                    break;
                case RecvOps.CharacterList:
                    PacketHandler.HandleCharacterList(this, packet);
                    break;
                case RecvOps.ChannelList:
                    PacketHandler.HandleChannelList(this, packet);
                    break;
                case RecvOps.ServerIP:
                    PacketHandler.HandlServerIP(this, packet);
                    break;
            }
        }

        public override void HandleDisconnected(bool byChoice)
        {
            Console.WriteLine("Disconnected from login");

            if(!byChoice)
            {
                if(Client.Region == Regions.SEA)
                {
                    Thread.Sleep(5000);
                    Client.Migrate("202.14.200.67", 14301, ServerType.Login);
                }
                else if (Client.Region == Regions.THAILAND)
                {
                    Thread.Sleep(5000);
                    Client.Migrate("103.4.156.8", 14300, ServerType.Login);
                }
            }
        }
    }
}
