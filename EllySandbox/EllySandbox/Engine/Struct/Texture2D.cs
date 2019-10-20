using ImageMagick;

namespace EllySandbox.Engine.Struct
{
    class Texture2D
    {
        MagickImage image;

        public Texture2D()
        {
            image = new MagickImage(new MagickColor(65535, 65535, 65535), 100, 100);
        }
        public Texture2D(string path)
        {

        }

        public void LoadTexture(string path)
        {

        }
    }
}
