using AR.Drone.Data;

namespace AR.Drone.Media
{
    public class PacketReader : BinaryReader
    {
        public PacketReader(Stream stream) : base(stream)
        {
        }

        public PacketType ReadPacketType()
        {
            return (PacketType) ReadByte();
        }

        public NavigationPacket ReadNavigationPacket()
        {
            var packet = new NavigationPacket
            {
                Timestamp = ReadInt64()
            };
            var dataSize = ReadInt32();
            packet.Data = ReadBytes(dataSize);
            return packet;
        }

        public VideoPacket ReadVideoPacket()
        {
            var packet = new VideoPacket
            {
                Timestamp = ReadInt64(),
                FrameNumber = ReadUInt32(),
                Height = ReadUInt16(),
                Width = ReadUInt16(),
                FrameType = (VideoFrameType) ReadByte()
            };
            var dataSize = ReadInt32();
            packet.Data = ReadBytes(dataSize);
            return packet;
        }

        public object? ReadPacket()
        {
            try
            {
                PacketType packetType = ReadPacketType();
                return packetType switch
                {
                    PacketType.Navigation => ReadNavigationPacket(),
                    PacketType.Video => ReadVideoPacket(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (EndOfStreamException)
            {
                return null;
            }
        }
    }
}