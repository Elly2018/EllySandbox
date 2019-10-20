namespace EllySandbox.Engine.Struct
{
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public static ushort[] touShort(Color c)
        {
            return new ushort[4] { 
                (ushort)(c.r * 65535f),
                (ushort)(c.g * 65535f),
                (ushort)(c.b * 65535f),
                (ushort)(c.a * 65535f) };
        }
    }
}
