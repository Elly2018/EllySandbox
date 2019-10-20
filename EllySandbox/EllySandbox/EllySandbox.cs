using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES30;
using EllySandbox.Engine.Module;
using EllySandbox.Engine.Helper;

namespace EllySandbox
{
    /// <summary>
    /// 
    /// Elly sandbox is a game you can use first person perspetive mode to build a game.
    /// 
    /// </summary>
    class EllySandbox : GameWindow
    {
        /// <summary>
        /// This will call after OnLoad
        /// </summary>
        public event EventHandler<EventArgs> Start;
        /// <summary>
        /// Game window minimum size width 
        /// </summary>
        public const int MinimumWindowWidth = 800;
        /// <summary>
        /// Game window minimum size height
        /// </summary>
        public const int MinimumWindowHeight = 600;


        /// <summary>
        /// The program enter point
        /// </summary>
        /// <param name="args">Flags</param>
        static void Main(string[] args)
        {
            EllySandbox game = new EllySandbox(800, 600, "Elly Sandbox");
            game.Run();
        }

        /// <summary>
        /// The game window constructor, initialize all system module
        /// </summary>
        /// <param name="width">Initialize width</param>
        /// <param name="height">Initialize height</param>
        /// <param name="title">Initialize title</param>
        public EllySandbox(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            /* Set target log file name */
            Debug.Filename = DateTime.Now.Year.ToString()
            + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.Day.ToString()
            + "-" + DateTime.Now.Hour.ToString()
            + "-" + DateTime.Now.Minute.ToString()
            + "-" + DateTime.Now.Second.ToString()
            + ".txt";

            /* Initialize helper factory */
            HelperFactory.Initialize();
            /* Initialize module factory */
            ModuleFactory.Initialize();

            /* Register event */
            Load += ModuleFactory.Module_Load;
            Start += ModuleFactory.Module_Start;
            UpdateFrame += ModuleFactory.Module_Update;
            RenderFrame += ModuleFactory.Module_Render;
            Unload += ModuleFactory.Module_Exit;
            Closed += ModuleFactory.Module_Destroy;
        }


        /// <summary>
        /// The begining event, run once
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Start.Invoke(this, new EventArgs());
        }


        /// <summary>
        /// Render event, update every frame.
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
        }


        /// <summary>
        /// Logic event, update as fast as it need.
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }


        /// <summary>
        /// When user resize window
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }


        /// <summary>
        /// It will call after receive exit event
        /// Save data, delete memory
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        
        /// <summary>
        /// When window is closed
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
    }
}
