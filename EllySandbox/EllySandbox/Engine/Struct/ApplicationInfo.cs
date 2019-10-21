namespace EllySandbox.Engine.Struct
{
    /// <summary>
    /// The set contain the information about the program
    /// fullscreen, resolution, develop mode, etc
    /// </summary>
    [System.Serializable]
    struct ApplicationInfo
    {
        public bool fullscreen;
        public bool DevelopMode;
        public bool OpenConsole;

        public ApplicationInfo(bool fullscreen, bool developMode, bool console)
        {
            this.fullscreen = fullscreen;
            DevelopMode = developMode;
            OpenConsole = console;
        }

        public override string ToString()
        {
            return "Fullscreen: " + fullscreen.ToString() + " " + "DevelopMode: " + DevelopMode.ToString();
        }
    }
}
