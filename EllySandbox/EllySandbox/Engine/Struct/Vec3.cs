using System;

namespace EllySandbox.Engine.Struct
{
    public struct Vec3
    {
        public float x;
        public float y;
        public float z;

        public Vec3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public static float Distance(Vec3 v1, Vec3 v2)
        {
            return (float)Math.Sqrt(Math.Pow(Math.Abs(v1.x - v2.x), 2) + Math.Pow(Math.Abs(v1.y - v2.y), 2) + Math.Pow(Math.Abs(v1.z - v2.z), 2));
        }
        public static Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static Vec3 operator *(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }
        public static Vec3 operator /(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }
    }
}
