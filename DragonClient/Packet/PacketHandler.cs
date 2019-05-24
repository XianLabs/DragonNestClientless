using DragonClient.Context;
using DragonClient.Structure;
using DragonLib.IO;
using DragonLib.Tools;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

//by XIAN
namespace DragonClient.Packet
{
    public static class PacketHandler
    {
        public static void HandleValidation(LoginContext context, PacketReader packet)
        {
            
        }

        public static void HandleLoginRespose(LoginContext context,PacketReader packet)
        {
            Console.WriteLine("Login Response");
            context.Send(PacketFactory.RequestWorldList());
        }
        public static void HandleWorldList(LoginContext context, PacketReader packet)
        {
            Console.WriteLine("World List");
            //todo: parse world list
            context.Send(PacketFactory.SelectWorld(1)); //Reef
        }
        public static void HandleCharacterList(LoginContext context, PacketReader packet) //gr7456aGG, pzE7frrYwV
        {
            Console.WriteLine("Character List");

            packet.Skip(10);
            byte numChars = packet.ReadByte();

            packet.Skip(2);

            string charname = "";
            int charid = 0;
            int hash = 0;
            int[] spw = { 0, 0, 0, 0 };

            for (int i = 0; i < numChars; i++ ) //todo, fix this
            {
                charname = packet.ReadWideNullTerminatedString();
                Console.WriteLine("Found {0}", charname);
                packet.Skip(34 - charname.Length * 2 - 2);
                charid = packet.ReadInt();
                Console.WriteLine("{0}", charid);

                if (charname.Equals(context.Client.account.CharacterName) == false)
                    packet.Skip(268); //offset between char names
                else
                {
                    break;
                }
            }

            int id = charid;

            if (id != 0)
            {
                context.Client.account.CharacterID = id;
            }

            context.Send(PacketFactory.SelectCharacter(id, hash, spw));
        }
        public static void HandleChannelList(LoginContext context, PacketReader packet)
        {
            Random rnd = new Random();
            int skips = rnd.Next(1, 6);
            int count = 0;

            Console.WriteLine("Got channel List");

            packet.Skip(6);

            bool found = false;

            while (found == false)
            {

                int chid = packet.ReadInt();

                packet.Skip(2);

                int mapid = packet.ReadInt();

                //if (mapid != 40 && mapid != 23)
               // {
                    if (count == skips)
                    {
                        found = true;
                        context.Send(PacketFactory.SelectChannel(chid));
                        Console.WriteLine("Entering channel: {0}", chid);
                    }
                //}

                Console.WriteLine("channel: {0} map: {1}", chid, mapid);
                packet.Skip(112);
                
                Console.WriteLine("Count: {0}", count);
                count++;
            }

        }
        public static void HandlServerIP(LoginContext context, PacketReader packet)
        {
            Console.WriteLine("Got server IP");

            context.Client.Magic = packet.ReadUInt();
            string ip = packet.ReadNullTerminatedString();
            packet.Skip(32 - ip.Length - 1);
            int port = packet.ReadInt();
            context.Client.Session = packet.ReadBytes(12);

            context.Client.Migrate(ip, port, ServerType.Town);
        }

        public static void HandleEnterMap(TownContext context, PacketReader packet)
        {
            Console.WriteLine("Entering Map...");
            context.Send(PacketFactory.enterMap());
        }

        public static void HandleMapReady(TownContext context, PacketReader packet)
        {
            Console.WriteLine("Got map info");
      
            context.Send(PacketFactory.SendMapReady());
            context.Send(PacketFactory.MapSpawn_1());
            context.Send(PacketFactory.MapSpawn_2());

            context.Send(PacketFactory.LandInField1());
            context.Send(PacketFactory.LandInField2());
            context.Send(PacketFactory.LandInField3());
            context.Send(PacketFactory.LandInField4());
            //context.Send(PacketFactory.EnterPortal(-3885.0f, -1624.0f, 5896.0f)); //for udp testing
        }

        public static void HandleEnterPortal(TownContext context, PacketReader packet)
        {
            Console.WriteLine("Entering portal..");
            context.Send(PacketFactory.SendStartStage(0xFF,0));
        }

        public static void HandleFieldInfo(TownContext context, PacketReader packet)
        {
            Console.WriteLine("Field Info");

            packet.Skip(5);

            string ip = string.Join(".", packet.ReadBytes(4));

            context.Client.UdpPort = packet.ReadShort();

            context.Client.TcpPort = packet.ReadInt();

            packet.Skip(2);

            context.Client.Session = packet.ReadBytes(12);

            //need to send udp handshake here
            context.Client.session.Disconnect();

            context.Client.Migrate(ip, context.Client.TcpPort, ServerType.Field);

           
        }

        public static void HandleQuestNPC(TownContext context, PacketReader packet)
        {
            int NPCID = packet.ReadInt();

            int questID = packet.ReadInt();

            if (questID == 1870)
            {
                Console.WriteLine("Got mailbox NPCID");
                context.Client.MailboxNPCID = NPCID;
            }
        }

        public static void HandleSpawnNPC(TownContext context, PacketReader packet)
        {
            int NPCUUID = packet.ReadInt();

            int npcID = packet.ReadInt();

            float X = packet.ReadFloat();
            float Y = packet.ReadFloat();
            float Z = packet.ReadFloat();

            Console.WriteLine("NPC spawned: {0}", npcID);
        }

        public static void HandlePlayerList(TownContext context, PacketReader packet)
        {
            uint playerUUID = packet.ReadUInt();
            uint playerUUIDPlusOne = packet.ReadUInt();
            string playerName = packet.ReadWideNullTerminatedString();

            D3DVector pos1 = new D3DVector(3774.0f, -1048.0f, -2377.0f);

            //context.Client.session.SendPacket(PacketFactory.MoveCharacter(playerUUID, 179905999, 3, pos1));

            //context.Client.session.SendPacket(PacketFactory.StopCharacterMovement(playerUUID, 179907999, pos1));

            
        }

        public static void HandlePlayerMovement(TownContext context, PacketReader packet)
        {
            uint playerUUID = packet.ReadUInt();

            D3DVector pos1 = new D3DVector(3774.0f, -1048.0f, -2377.0f);

            //context.Client.session.SendPacket(PacketFactory.MoveCharacter(playerUUID, 179905999, 3, pos1));

            //context.Client.session.SendPacket(PacketFactory.StopCharacterMovement(playerUUID, 179907999, pos1));
        }

        public static void HandlePlayerSpeak(TownContext context, PacketReader packet)
        {
            int type = packet.ReadInt();

            string name = packet.ReadWideNullTerminatedString();

            packet.Skip(38 - (name.Length*2) - 2);
            int len = packet.ReadShort();
            string message = packet.ReadString(len);

            Console.WriteLine("{0}: {1}", name, message);

        }

        public static void HandleLoadedCashInv(TownContext context, PacketReader packet)
        {
            if(context.Client.OpeningMail == true)
            {
                context.Client.session.SendPacket(PacketFactory.ChangePlayerState(0x10));
                context.Client.session.SendPacket(PacketFactory.OpenMailbox());
            }

            if(context.Client.OpeningGoldPouches == true)
            {
                context.Client.GoldPouchOpenThread = new Thread(new ThreadStart(context.OpenGoldPouches));

                if (context.Client.GoldPouchOpenThread.ThreadState == ThreadState.Running)
                    return;
                else
                    context.Client.GoldPouchOpenThread.Start();
            }
        }

        public static void HandleMailList(TownContext context, PacketReader packet)
        {

            int[] mailIds = new int[6] { 0, 0, 0, 0, 0, 0 };

            packet.Skip(9);

            byte bNumMails = packet.ReadByte();

            int idCounter = 0;


            if(bNumMails == 0)
            {
                Console.WriteLine("No mail in box.");
                context.Client.OpeningMail = false;
                context.Client.OpeningGoldPouches = true;

                context.Client.GoldPouchOpenThread = new Thread(new ThreadStart(context.OpenGoldPouches));

                if (context.Client.GoldPouchOpenThread.ThreadState == ThreadState.Running)
                    return;
                else
                    context.Client.GoldPouchOpenThread.Start();
            }

            for(int i = 0; i < bNumMails; i++)
            {
                mailIds[idCounter] = packet.ReadInt();
                idCounter++;

                if (i != bNumMails) //prevent edge case crash
                    packet.Skip(142);
            }

            if(context.Client.OpeningMail == true)
            {
                Thread.Sleep(500);
                context.Client.session.SendPacket(PacketFactory.RetrieveBatchMail(mailIds));
                Thread.Sleep(500);
                context.Client.session.SendPacket(PacketFactory.DeleteMail(mailIds));
                Thread.Sleep(500);
                context.Client.session.SendPacket(PacketFactory.OpenMailbox());
                Thread.Sleep(500);
                context.Client.session.SendPacket(PacketFactory.CrashNearbyPlayers(context.Client.Magic));
            }
        }

        public static void HandleCashInventory(TownContext context, PacketReader packet) //37 between items
        {
            //805309057 = pouch
            //805308750

            if(context.Client.OpeningGoldPouches == true)
            {
                int itemID = 0;
                long itemUUID = 0;

                packet.Skip(4);
                byte bNumItemsInPacket = packet.ReadByte();

                if (packet.Length > 4800)
                {
                    while (packet.Position < 4800)
                    {
                        itemID = packet.ReadInt();
                        itemUUID = packet.ReadLong();

                        if (itemID == 805309057)
                        {
                            Console.WriteLine("Added gold pouch to queue!");
                            context.Client.GoldPouches.Enqueue(itemUUID);
                        }

                        packet.Skip(37);
                    }
                }
            }
        }
    }
}
