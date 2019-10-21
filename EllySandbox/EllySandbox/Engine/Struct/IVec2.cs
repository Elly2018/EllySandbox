using System;

namespace EllySandbox.Engine.Struct
{
    public struct IVec2
    {
        public int x;
        public int y;

        public IVec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Distance(IVec2 v1, IVec2 v2)
        {
            return (float)Math.Sqrt(Math.Pow(Math.Abs(v2.x - v1.x), 2) + Math.Pow(Math.Abs(v2.y - v1.y), 2));
        }
        public static IVec2 operator +(IVec2 v1, IVec2 v2)
        {
            return new IVec2(v1.x + v2.x, v1.y + v2.y);
        }
        public static IVec2 operator -(IVec2 v1, IVec2 v2)
        {
            return new IVec2(v1.x - v2.x, v1.y - v2.y);
        }
        public static IVec2 operator *(IVec2 v1, IVec2 v2)
        {
            return new IVec2(v1.x * v2.x, v1.y * v2.y);
        }
        public static IVec2 operator /(IVec2 v1, IVec2 v2)
        {
            return new IVec2(v1.x / v2.x, v1.y / v2.y);
        }
    }
}
