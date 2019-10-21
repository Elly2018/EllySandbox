namespace EllySandbox.Engine.Struct
{
    class IRect
    {
        public int x;
        public int y;
        public int width;
        public int height;

        public IRect(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.width = 100;
            this.height = 100;
        }
        public IRect(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Check if the point is in rect area
        /// </summary>
        /// <param name="v1">Target point</param>
        /// <param name="v2">Test rect</param>
        /// <returns></returns>
        public static bool CheckCollider(Vec2 v1, IRect v2)
        {
            Vec2[] point = new Vec2[4]
            {
                new Vec2(v2.x, v2.y),
                new Vec2(v2.x + v2.width, v2.y),
                new Vec2(v2.x + v2.width, v2.y + v2.height),
                new Vec2(v2.x, v2.y + v2.height),
            };
            float[] areas = new float[4]
            {
                GetTriangleArea(v1, point[0], point[1]),
                GetTriangleArea(v1, point[1], point[2]),
                GetTriangleArea(v1, point[2], point[3]),
                GetTriangleArea(v1, point[3], point[0]),
            };
            float fullArea = v2.width * v2.height;
            float Compare = areas[0] + areas[1] + areas[2] + areas[3];
            return !(Compare > fullArea);
        }
        /// <summary>
        /// Give it three point get the area of triangle
        /// </summary>
        /// <param name="v1">first point</param>
        /// <param name="v2">second point</param>
        /// <param name="v3">third point</param>
        /// <returns></returns>
        public static float GetTriangleArea(Vec2 v1, Vec2 v2, Vec2 v3)
        {
            return (v1.x * (v2.y - v3.y) + v2.x * (v3.y - v1.y) + v3.x * (v1.y - v2.y)) / 2;
        }

        public static IRect operator +(IRect v1, IRect v2)
        {
            return new IRect(v1.x + v2.x, v1.y + v2.y, v1.width + v2.width, v1.height + v2.height);
        }
        public static IRect operator -(IRect v1, IRect v2)
        {
            return new IRect(v1.x - v2.x, v1.y - v2.y, v1.width - v2.width, v1.height - v2.height);
        }
        public static IRect operator *(IRect v1, IRect v2)
        {
            return new IRect(v1.x * v2.x, v1.y * v2.y, v1.width * v2.width, v1.height * v2.height);
        }
        public static IRect operator /(IRect v1, IRect v2)
        {
            return new IRect(v1.x / v2.x, v1.y / v2.y, v1.width / v2.width, v1.height / v2.height);
        }
    }
}
