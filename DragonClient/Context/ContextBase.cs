using DragonLib.IO;
using DragonLib.Network;
using System.Net.Sockets;

//by XIAN
namespace DragonClient.Context
{
    public abstract class ContextBase
    {
        public Client Client { get; private set; }

        private Session m_session;

        public ContextBase(Client client, Session session, bool receiving)
        {
            Client = client;

            m_session = session;
            m_session.OnPacket += (s, e) => HandlePacket(e);
            m_session.OnDisconnected += (s, e) => HandleDisconnected(e);

            HandleConnected();

            m_session.Receive();
        }

        public abstract void HandleConnected();
        public abstract void HandlePacket(PacketReader packet);
        public abstract void HandleDisconnected(bool byChoice);

        public void Send(PacketWriter packet)
        {
            if (m_session != null)
                m_session.SendPacket(packet);
        }

        public void Disconnect()
        {
            m_session.Disconnect();
        }
    }
}
