using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragonClient
{
    static class Program
    {
        private static void UdpTest()
        {
            const int UdpHeaderLen = 3;
            const short OpCode = DragonClient.Packet.SendOps.FieldMigrate;

            var pbody = new byte[] {0x0F,0x8A,0x1B,0xB9,0xC0,0xA8,0x00,0x6B,0x00,0x00};
            var packet = new DragonLib.IO.PacketWriter();
            packet.WriteBytes(pbody);

            var body = packet.ToArray();

            byte[] crypted = new byte[1024];

            int v1 = 0x03; //opcodes
            int v2 = 0x02;
            Console.WriteLine(DragonLib.Tools.HexTool.ToString(pbody));
            //int len = DragonLib.Network.Crypto.EncryptUDP(pbody, body.Length, v1, v2, crypted);

            //byte[] final = new byte[len + UdpHeaderLen];

            //final[0] = 0x2;     //hardcode udp header
           // final[2] = 0xe6;    //hardcode udp header

            //copy crypted to final,  at index 3
            //Buffer.BlockCopy(crypted, 0, final, UdpHeaderLen, len);

           // Console.WriteLine(DragonLib.Tools.HexTool.ToString(final));
           // Console.ReadLine();
        }

        [STAThread]
        static void Main()
        {
            Console.Title = "DragonClient Console";
            Console.ForegroundColor = ConsoleColor.White;

            //UdpTest();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
