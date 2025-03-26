using AR.Drone.Data;

namespace AR.Drone.Media
{
    public class PacketWriter : BinaryWriter
    {
        public PacketWriter(Stream stream) : base(stream)
        {
        }

        public void WritePacket(object packet)
        {
            switch (packet)
            {
                case null:
                    throw new NullReferenceException();
                case NavigationPacket navigationPacket:
                    Write(PacketType.Navigation);

                    Write(navigationPacket);
                    break;
                case VideoPacket videoPacket:
                    Write((byte) PacketType.Video);

                    Write(videoPacket);
                    break;
                default:
                {
                    var message = $"Not supported packet type - {packet.GetType().Name}.";
                    throw new NotSupportedException(message);
                }
            }
        }

        private void Write(PacketType packetType)
        {
            Write((byte) packetType);
        }

        public void Write(NavigationPacket packet)
        {
            Write(packet.Timestamp);
            Write(packet.Data.Length);
            Write(packet.Data);
        }

        public void Write(VideoPacket packet)
        {
            Write(packet.Timestamp);
            Write(packet.FrameNumber);
            Write(packet.Height);
            Write(packet.Width);
            Write((byte) packet.FrameType);
            Write(packet.Data.Length);
            Write(packet.Data);
        }
    }
}