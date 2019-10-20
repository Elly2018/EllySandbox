namespace EllySandbox.Engine.Struct
{
    /// <summary>
    /// 
    /// Every module has its infomation
    /// Version and module name
    /// 
    /// </summary>
    struct ModuleInfo
    {
        public string ModuleName;
        public int BuildVersion;
        public int BetaVersion;
        public int AlphaVersion;

        public ModuleInfo(string moduleName, int buildVersion, int betaVersion, int alphaVersion)
        {
            ModuleName = moduleName;
            BuildVersion = buildVersion;
            BetaVersion = betaVersion;
            AlphaVersion = alphaVersion;
        }

        public override string ToString()
        {
            return ModuleName + " " + BuildVersion.ToString() + "." + BetaVersion.ToString() + "." + AlphaVersion.ToString();
        }
    }
}
