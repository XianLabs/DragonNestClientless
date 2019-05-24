using DragonClient.Packet;
using DragonClient.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragonLib.Tools;
using DragonLib.IO;
using System.IO;

//by XIAN
namespace DragonClient
{
    

    public partial class MainForm : Form
    {
        public Client Client { get; private set; }

        Thread SpamThread;

        public MainForm()
        {
            InitializeComponent();
            Client = new Client();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Client.account = new Structure.Account();
            Client.account.Username = textBox_AcctName.Text;
            Client.account.Password = textBox_Pass.Text;
            Client.account.CharacterName = textBox_CharacterName.Text;
            this.Text = Client.account.Username;

            if (comboBox_World.Text == "SEA")
            {
                Client.Migrate("202.14.200.67", 14301, ServerType.Login);
                Client.Region = Regions.SEA;
            }
            else if(comboBox_World.Text == "TH")
            {
                Client.Migrate("103.4.156.8", 14300, ServerType.Login);
                Client.Region = Regions.THAILAND;
            }   
        }

        private void button_SendPacket_Click(object sender, EventArgs e)
        {
            string sendPacketText = textBox_SendPacket.Text.Trim();

            byte[] packetBytes = HexTool.ToBytes(sendPacketText);

            var p = new PacketWriter();
            p.WriteByte(packetBytes[0]);
            p.WriteByte(packetBytes[1]);
            p.WriteBytes(packetBytes);

            Client.session.SendPacket(p);
        }

        private void button_Notice_Click(object sender, EventArgs e)
        {
            Client.session.SendPacket(PacketFactory.Speak(1, "/notice " + textBox_NoticeMsg.Text));
        }

        private void checkBox_CollectGold_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_CollectGold.Checked == true)
            {
                Client.OpeningGoldPouches = true;
                //Client.GoldPouchOpenThread = new Thread(new ThreadStart(OpenGoldPouches));
                // Client.GoldPouchOpenThread.Start();
            }
            else
            {
                Client.OpeningGoldPouches = false;

                if (Client.GoldPouchOpenThread.ThreadState == ThreadState.Running)
                    Client.GoldPouchOpenThread.Abort();
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Client.session.Disconnect();
        }

        private void checkBox_CollectMail_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_CollectMail.Checked == true)
            {
                Client.OpeningMail = true;
                Client.session.SendPacket(PacketFactory.ChangePlayerState(0x10));
                Client.session.SendPacket(PacketFactory.OpenMailbox());
            }
            else
            {
                Client.OpeningMail = false;
            }           
        }

        private void checkBox_AutoRestart_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_AutoRestart.Checked == true)
            {
                Client.AutoRestart = true;
            }
            else
            {
                Client.AutoRestart = false;
            }
        }
    }
}
