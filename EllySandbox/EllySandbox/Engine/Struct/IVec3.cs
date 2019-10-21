using System;

namespace EllySandbox.Engine.Struct
{
    public struct IVec3
    {
        public int x;
        public int y;
        public int z;

        public IVec3(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public static float Distance(IVec3 v1, IVec3 v2)
        {
            return (float)Math.Sqrt(Math.Pow(Math.Abs(v1.x - v2.x), 2) + Math.Pow(Math.Abs(v1.y - v2.y), 2) + Math.Pow(Math.Abs(v1.z - v2.z), 2));
        }
        public static IVec3 operator+(IVec3 v1, IVec3 v2)
        {
            return new IVec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static IVec3 operator -(IVec3 v1, IVec3 v2)
        {
            return new IVec3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static IVec3 operator *(IVec3 v1, IVec3 v2)
        {
            return new IVec3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }
        public static IVec3 operator /(IVec3 v1, IVec3 v2)
        {
            return new IVec3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }
    }
}
