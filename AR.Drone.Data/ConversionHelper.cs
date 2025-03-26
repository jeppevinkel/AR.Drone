namespace AR.Drone.Data
{
    public class ConversionHelper
    {
        public static int ToInt(float value)
        {
            var result = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
            return result;
        }

        public static float ToSingle(uint value)
        {
            var result = BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
            return result;
        }

        public static float ToSingle(int value)
        {
            var result = BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
            return result;
        }
    }
}