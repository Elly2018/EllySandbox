namespace EllySandboxWeb
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

        public ApplicationInfo(bool fullscreen, bool developMode)
        {
            this.fullscreen = fullscreen;
            DevelopMode = developMode;
        }

        public override string ToString()
        {
            return "Fullscreen: " + fullscreen.ToString() + " " + "DevelopMode: " + DevelopMode.ToString();
        }
    }
}
