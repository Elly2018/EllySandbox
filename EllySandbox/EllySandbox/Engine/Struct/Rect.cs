namespace EllySandbox.Engine.Struct
{
    public struct Rect
    {
        public float x;
        public float y;
        public float width;
        public float height;

        public Rect(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.width = 100f;
            this.height = 100f;
        }
        public Rect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public static bool CheckCollider(Vec2 v1, Rect v2)
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
        public static float GetTriangleArea(Vec2 v1, Vec2 v2, Vec2 v3)
        {
            return (v1.x * (v2.y - v3.y) + v2.x * (v3.y - v1.y) + v3.x * (v1.y - v2.y)) / 2;
        }
        public static Rect operator +(Rect v1, Rect v2)
        {
            return new Rect(v1.x + v2.x, v1.y + v2.y, v1.width + v2.width, v1.height + v2.height);
        }
        public static Rect operator -(Rect v1, Rect v2)
        {
            return new Rect(v1.x - v2.x, v1.y - v2.y, v1.width - v2.width, v1.height - v2.height);
        }
        public static Rect operator *(Rect v1, Rect v2)
        {
            return new Rect(v1.x * v2.x, v1.y * v2.y, v1.width * v2.width, v1.height * v2.height);
        }
        public static Rect operator /(Rect v1, Rect v2)
        {
            return new Rect(v1.x / v2.x, v1.y / v2.y, v1.width / v2.width, v1.height / v2.height);
        }
    }
}
