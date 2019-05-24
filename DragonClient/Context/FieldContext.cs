using DragonClient.Packet;
using DragonLib.IO;
using DragonLib.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//By Xian
//Field not implemented here
namespace DragonClient.Context
{
    public sealed class FieldContext : ContextBase
    {
        public FieldContext(Client client, Session session)
            : base(client, session,false)
        {
        }

        public override void HandleConnected()
        {
            Console.WriteLine("Connected to TCP field (outside town)");
      
        }

        public override void HandlePacket(PacketReader packet)
        {
            byte[] rawHeader = packet.ReadBytes(3);
            short length = packet.ReadShort();
            short opcode = packet.ReadShort();

            switch (opcode)
            {
                default:
                    Console.WriteLine("Got some packet... field not implemented in this version");
                    break;
            }
        }

        public override void HandleDisconnected(bool byChoice)
        {
            if(byChoice == false)
                Console.WriteLine("Force disconnected from TCP field");
            else
                Console.WriteLine("Disconnected from TCP field");
        }
    }
}
