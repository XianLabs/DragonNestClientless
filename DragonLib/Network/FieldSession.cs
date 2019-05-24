using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonLib.IO;

//not finished. needs changing to udp from tcp
namespace DragonLib.Network
{
    public sealed class FieldSession : IDisposable
    {
        public const int HeaderLen = 7; //udp header is 7 bytes
        public const short ReceiveSize = 1024; //whatever

        private readonly Socket m_socket;

        private bool m_connected;
        private bool m_userClose;

        private byte[] m_recvBuffer;
        private byte[] m_packetBuffer;
        private int m_cursor;

        private object m_sendLock;

        public event EventHandler<PacketReader> OnPacket;
        public event EventHandler<bool> OnDisconnected;

        public bool Connected
        {
            get
            {
                return m_connected;
            }
        }

        public FieldSession(Socket socket)
        {
            m_socket = socket;

            m_connected = true;
            m_userClose = false;

            m_packetBuffer = new byte[ReceiveSize];
            m_recvBuffer = new byte[ReceiveSize];
            m_cursor = 0;

            m_sendLock = new object();
        }

        public void Receive()
        {
            if (m_connected)
            {
                var error = SocketError.Success;

                m_socket.BeginReceive(m_recvBuffer, 0, ReceiveSize, SocketFlags.None, out error, PacketCallback, null);

                if (error != SocketError.Success)
                {
                    Dispose();
                }
            }
        }

        private void PacketCallback(IAsyncResult iar)
        {
            if (m_connected)
            {
                var error = SocketError.Success;

                int length = m_socket.EndReceive(iar, out error);

                if (length == 0 || error != SocketError.Success)
                {
                    Dispose();
                }
                else
                {
                    Append(length);
                    ManipulateBuffer();
                    Receive();
                }
            }
        }
        private void Append(int length)
        {
            if (m_packetBuffer.Length - m_cursor < length)
            {
                int newSize = m_packetBuffer.Length * 2;

                while (newSize < m_cursor + length)
                    newSize *= 2;

                Array.Resize<byte>(ref m_packetBuffer, newSize);
            }

            Buffer.BlockCopy(m_recvBuffer, 0, m_packetBuffer, m_cursor, length);

            m_cursor += length;
        }
        private void ManipulateBuffer()
        {
            while (m_cursor > HeaderLen && m_connected)
            {
                int packetSize = m_packetBuffer[0] | m_packetBuffer[1] << 8 | m_packetBuffer[2] << 16;

                if (m_cursor < packetSize)
                {
                    break;
                }

                byte[] buffer = new byte[packetSize];
                Buffer.BlockCopy(m_packetBuffer, 0, buffer, 0, packetSize);

                Crypto.DecryptTCP(buffer);

                m_cursor -= packetSize;

                if (m_cursor > 0)
                {
                    Buffer.BlockCopy(m_packetBuffer, packetSize, m_packetBuffer, 0, m_cursor);
                }

                if (OnPacket != null)
                    OnPacket(this, new PacketReader(buffer));

                buffer = null;
            }
        }

        public void SendPacket(PacketWriter packet)
        {
            if (m_connected)
            {
                byte[] data = packet.ToArray();
                byte[] final = new byte[data.Length + HeaderLen];

                final[0] = (byte)(final.Length & 0xFF);
                final[1] = (byte)((final.Length >> 8) & 0xFF);
                final[2] = (byte)((final.Length >> 16) & 0xFF);

                Crypto.EncryptTCP(data);

                Buffer.BlockCopy(data, 0, final, HeaderLen, data.Length);

                lock (m_sendLock)
                {
                    int offset = 0;

                    while (offset < final.Length)
                    {
                        SocketError errorCode = SocketError.Success;
                        int sent = m_socket.Send(final, offset, final.Length - offset, SocketFlags.None, out errorCode);

                        if (sent == 0 || errorCode != SocketError.Success)
                        {
                            Dispose();
                            return;
                        }

                        offset += sent;
                    }
                }

                packet.Dispose();
            }
        }

        public void Disconnect()
        {
            m_userClose = true;
            Dispose();
        }
        public void Dispose()
        {
            if (m_connected)
            {
                m_connected = false;
                m_cursor = 0;

                try
                {

                    m_socket.Shutdown(SocketShutdown.Both);
                    m_socket.Close();
                }
                finally
                {
                    if (OnDisconnected != null)
                        OnDisconnected(this, m_userClose);
                }
            }
        }
    }
}
