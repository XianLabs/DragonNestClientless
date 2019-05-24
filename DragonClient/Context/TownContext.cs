using DragonClient.Packet;
using DragonClient.Structure;
using DragonLib.IO;
using DragonLib.Network;
using System;
using System.Threading;
using System.Windows.Forms;

namespace DragonClient.Context
{
    public sealed class TownContext : ContextBase
    {
        public TownContext(Client client, Session session)
            : base(client, session, true)
        {
        }

        public override void HandleConnected()
        {
            Console.WriteLine("Connected to town");
            Send(PacketFactory.TownMigrate(Client.Magic, Client.Session));
        }

        public override void HandlePacket(PacketReader packet)
        {
            byte[] rawHeader = packet.ReadBytes(3);
            short length = packet.ReadShort();
            short opcode = packet.ReadShort();

            switch (opcode)
            {
                case RecvOps.EnterMap:
                    PacketHandler.HandleEnterMap(this, packet);
                    break;
                case RecvOps.GetMapInfo:
                    PacketHandler.HandleMapReady(this, packet);
                    break;
                case RecvOps.EnterPortal:
                    PacketHandler.HandleEnterPortal(this, packet);
                    break;
                case RecvOps.FieldInfo:
                    PacketHandler.HandleFieldInfo(this, packet);
                    break;
                case RecvOps.GetQuestNPC:
                    PacketHandler.HandleQuestNPC(this, packet);
                    break;
                case RecvOps.SpawnNPC:
                    PacketHandler.HandleSpawnNPC(this, packet);
                    break;
                case RecvOps.LoadActorList:
                    PacketHandler.HandlePlayerList(this, packet);
                    break;
                case RecvOps.StartMovement:
                    PacketHandler.HandlePlayerMovement(this, packet);
                    break;
                case RecvOps.PlayerChat:
                    PacketHandler.HandlePlayerSpeak(this, packet);
                    break;

                case RecvOps.GetCashInventory:
                    PacketHandler.HandleCashInventory(this, packet);
                    break;

                case RecvOps.BeginTownThreading:
                    PacketHandler.HandleLoadedCashInv(this, packet);
                    break;
                case RecvOps.MailList:
                    PacketHandler.HandleMailList(this, packet);
                    break;
            }
        }

        public override void HandleDisconnected(bool byChoice)
        {
            Console.WriteLine("Disconnected from town");

            if(Client.OpeningGoldPouches == true)
            {
                Client.GoldPouchOpenThread.Abort();
                Client.GoldPouches.Clear();
            }

            if (Client.AutoRestart == true)
            {
                //migrate back
                if (Client.Region == Regions.SEA)
                {
                    Client.Migrate("202.14.200.67", 14301, ServerType.Login);
                }
                else if (Client.Region == Regions.THAILAND)
                {
                    Client.Migrate("103.4.156.8", 14300, ServerType.Login);
                }
            }

        }

        public void OpenGoldPouches()
        {
            while(Client.GoldPouches.Count > 0)
            {
                int counter = 0;

                if (Client.session.Connected == true)
                {
                    long itemUUID = Client.GoldPouches.Dequeue();
                    this.Send(PacketFactory.OpenCashPouch(itemUUID));
                    Thread.Sleep(3000);
                    this.Send(PacketFactory.FinishOpenCashPouch(itemUUID));
                    Thread.Sleep(1000);
                    Console.WriteLine("Opened gold pouch!");
                    counter++;
                    if(counter % 3 == 0)
                    {
                        Console.WriteLine("Crashing nearby assholes!");
                        this.Send(PacketFactory.CrashNearbyPlayers(this.Client.Magic));
                    }
                }
                else
                    return;
            }
        }
    }
}
