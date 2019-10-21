using EllySandbox.Engine.Base;
using EllySandbox.Engine.Struct;

namespace EllySandbox.Engine.UI
{
    sealed partial class GUI
    {
        public class Image : GUIBase
        {
            public Texture2D image;
            public Color Tint;
        }
    }
}
