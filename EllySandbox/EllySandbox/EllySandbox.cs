using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES30;

namespace EllySandbox
{
    class EllySandbox : GameWindow
    {
        public EllySandbox(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        public override void Exit()
        {
            base.Exit();
        }

        static void Main(string[] args)
        {

        }
    }
}
