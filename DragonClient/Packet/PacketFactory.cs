using DragonLib.IO;
using DragonLib.Tools;
using DragonLib.Network;
using System.Text;
using System;

//by XIAN
namespace DragonClient.Packet
{
    public static class PacketFactory
    {
        public static PacketWriter Validate()
        {
            var p = new PacketWriter(SendOps.Validate);
            p.WriteShort(0x0633);
            p.WriteShort(0x0101);
            p.WriteByte(0);
            p.WriteShort(0x07B1); //this needs changing on each patch ver
            return p;
        }

        public static PacketWriter ValidateThailand()
        {
            var p = new PacketWriter(SendOps.Validate);
            p.WriteShort(0x063D);
            p.WriteShort(0x0101);
            p.WriteByte(0);
            p.WriteShort(0x07D9); //this needs changing on each patch ver
            return p;
        }

        public static PacketWriter Login(string username, string password, string ip, string hwid) //dnsea login
        {
            var p = new PacketWriter(SendOps.Login);
            p.WriteString(username);
            p.WriteZero(102 - (username.Length * 2));
            p.WriteString(password);
            p.WriteZero(42 - (password.Length * 2));
            p.WriteString(ip);
            p.WriteZero(32 - (ip.Length * 2));
            p.WriteZero(32);
            return p;
        }

        public static PacketWriter LoginThailand(string username, string password, string ip) //dnsea login
        {
            var p = new PacketWriter(SendOps.LoginThailand);
            p.WriteCharString(username);
            p.WriteZero(128 - (username.Length));
            p.WriteCharString(password);
            p.WriteZero(12 - (password.Length));
            p.WriteZero(20);
            p.WriteCharString("THPP");
            p.WriteInt(0);
            p.WriteCharString(ip);
            p.WriteZero(31 - (ip.Length));
            System.Console.WriteLine("{0}", BitConverter.ToString(p.m_stream.ToArray()));
            return p;
        }

        public static PacketWriter RequestWorldList()
        {
            return new PacketWriter(SendOps.RequestWorldList);
        }

        public static PacketWriter SelectWorld(byte id)
        {
            var p = new PacketWriter(SendOps.SelectWorld);
            p.WriteByte(id);
            return p;
        }

        public static PacketWriter SelectCharacter(int id,int spwHash,int[] spw)
        {
            var p = new PacketWriter(SendOps.SelectCharacter);

            p.WriteInt(id);
            p.WriteInt();
            p.WriteInt(spwHash);

            foreach (int i in spw)
                p.WriteInt(i);
            return p;
        }

        public static PacketWriter SelectChannel(int id)
        {
            var p = new PacketWriter(SendOps.SelectChannel);
            p.WriteInt(id);
            return p;
        }


        public static PacketWriter TownMigrate(uint magic,byte[] session)
        {
            var p = new PacketWriter(SendOps.TownMigrate);
            p.WriteUInt(magic);
            p.WriteBytes(session);
            p.WriteHexString("31 00 39 00 32 00 2E 00 31 00 36 00 38 00 2E 00 30 00 2E 00 31 00 30 00 37 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
            return p; //above is 192.168.0.107, no need to change it unless mass-botting
        }

        public static PacketWriter enterMap()
        {
            var p = new PacketWriter(SendOps.EnterMap);
            p.WriteShort(1);
            return p;
        }

        public static PacketWriter SendMapReady()
        {
            var p = new PacketWriter(SendOps.SendMapReady);
            return p;
        }

        public static PacketWriter MapSpawn_1()
        {
            var p = new PacketWriter(SendOps.MapSpawn_1);
            p.WriteByte(0);
            return p;
        }

        public static PacketWriter MapSpawn_2()
        {
            var p = new PacketWriter(SendOps.MapSpawn_2);
            return p;
        }

        public static PacketWriter LandInField1()
        {
            var p = new PacketWriter(SendOps.LandInField1);
            return p;
        }

        public static PacketWriter LandInField2()
        {
            var p = new PacketWriter(SendOps.LandInField2);
            return p;
        }
        public static PacketWriter LandInField3()
        {
            var p = new PacketWriter(SendOps.LandInField3);
            return p;
        }

        public static PacketWriter LandInField4()
        {
            var p = new PacketWriter(SendOps.LandInField4);
            return p;
        } 

        public static PacketWriter EnterPortal(float X, float Z, float Y)
        {
            var p = new PacketWriter(SendOps.EnterPortal);
            p.WriteFloat(X);
            p.WriteFloat(Z);
            p.WriteFloat(Y);
            p.WriteByte(1);
            return p;
        }

        public static PacketWriter SendStartStage(int StageIndex, int Difficulty)
        {
            var p = new PacketWriter(SendOps.SendStartStage);
            p.WriteByte(0);
            p.WriteInt(Difficulty);
            p.WriteInt(StageIndex);
            p.WriteInt(0);
            return p;
        }

        public static PacketWriter SendMail(string CharacterName, string MailTitle, string MailBody, int copperCount)
        {
            var p = new PacketWriter(SendOps.SendMail);
            p.WriteString(CharacterName); //17 bytes devoted to char name
            p.WriteString(MailTitle); //60 bytes devoted for title
            p.WriteString(MailBody);
            p.WriteShort(10);
            p.WriteZero(382);
            p.WriteByte(1);
            p.WriteInt(copperCount);
            p.WriteByte(0);
            return p;
        }

        public static PacketWriter InitNPCDialog(int oid, int DialogID, int NPCID)
        {
            var p = new PacketWriter(SendOps.NPCDialog);
            p.WriteInt(oid);
            p.WriteInt(DialogID);
            p.WriteInt(NPCID);
            return p;
        }

        public static PacketWriter FieldMigrate(uint playerUID, byte[] session)
        {
            var p = new PacketWriter(SendOps.FieldMigrate);
            p.WriteUInt(playerUID);
            p.WriteBytes(session);
            return p;
        }

        public static PacketWriter MoveCharacter(uint playerUID, int time, short animationType, D3DVector pos)
        {
            var p = new PacketWriter(SendOps.StartCharacterMovement);
            p.WriteUInt(playerUID);
            p.WriteInt(time);
            p.WriteShort(animationType);

            byte[] x = new byte[3];

            //Crypto.EncodeCoord(pos.GetX(), x);
            //p.WriteBytes(x);

            //byte[] y = new byte[3];

            //Crypto.EncodeCoord(pos.GetY(), y);
            //p.WriteBytes(y);

            //byte[] z = new byte[3];

            //Crypto.EncodeCoord(pos.GetZ(), z);
            //p.WriteBytes(z);

            p.WriteShort(0x699F);
            p.WriteShort(0x483F);
            p.WriteUShort(0x7578);
            p.WriteUShort(0x32C2);
            p.WriteUShort(0xA303);
            p.WriteShort(0x0001);
            p.WriteZero(1);
            return p;
        }

        public static PacketWriter StopCharacterMovement(uint playerUID, int time, D3DVector pos)
        {
            var p = new PacketWriter(SendOps.StopCharacterMovement);
            p.WriteUInt(playerUID);
            //p.WriteInt(time);

            //byte[] x = new byte[3];

            //Crypto.EncodeCoord(pos.GetX(), x);
            //p.WriteBytes(x);

            //byte[] y = new byte[3];

            //Crypto.EncodeCoord(pos.GetY(), y);
            //p.WriteBytes(y);

            //byte[] z = new byte[3];

            //Crypto.EncodeCoord(pos.GetZ(), z);
            //p.WriteBytes(z);

            p.WriteByte(0);
            p.WriteByte(1);
            return p;
        }

        public static PacketWriter Speak(int speakType, string message)
        {
            var p = new PacketWriter(SendOps.Speak);
            p.WriteInt(speakType);
            p.WriteZero(8);
            p.WriteShort((short)message.Length);
            p.WriteString(message);
            return p;
            //[0B 01] [01 00 00 00] 00 00 00 00 00 00 00 00 [01 00] [61 00] 
        }

        public static PacketWriter OpenCashPouch(long itemUUID)
        {
            var p = new PacketWriter(SendOps.OpenCashPouch);
            p.WriteByte(6); //inv type
            p.WriteShort(0x1560); //slots
            p.WriteLong(itemUUID);
            p.WriteZero(4);
            return p;
        }

        public static PacketWriter FinishOpenCashPouch(long itemUUID)
        {
            var p = new PacketWriter(SendOps.FinishOpenCashPouch);
            p.WriteByte(6); //inv type
            p.WriteShort(0x1560); //slots
            p.WriteLong(itemUUID);
            p.WriteZero(4);
            return p;
        }

        public static PacketWriter OpenMailbox()
        {
            var p = new PacketWriter(SendOps.OpenMailBox);
            p.WriteShort(1);
            return p;
        }

        public static PacketWriter RetrieveBatchMail(int[] mailIDs)
        {
            var p = new PacketWriter(SendOps.BatchCollectMail);
            int count = 0;

            for (int i = 0; i < mailIDs.Length; i++)
            {
                p.WriteInt(mailIDs[i]);
                count++;
            }

            if(count != 6)
            {
                p.WriteZero(mailIDs.Length - (count * 4));
            }

            return p;
        }

        public static PacketWriter DeleteMail(int[] mailIDs)
        {
            var p = new PacketWriter(SendOps.DeleteMail);
            int count = 0;

            for (int i = 0; i < mailIDs.Length; i++)
            {
                p.WriteInt(mailIDs[i]);
                count++;
            }

            if (count != 6)
            {
                p.WriteZero(mailIDs.Length - (count * 4));
            }

            return p;
        }

        public static PacketWriter ChangePlayerState(short state)
        {
            var p = new PacketWriter(SendOps.ChangeState);
            p.WriteShort(state);
            return p;
        }

        public static PacketWriter CrashNearbyPlayers(uint uuID)
        {
            var p = new PacketWriter(SendOps.CrashNearbyActors);
            p.WriteUInt(uuID);
            p.WriteInt(0x7FFFFFFF);
            p.WriteInt(1);
            p.WriteZero(10);
            return p;
        }
    }
}
