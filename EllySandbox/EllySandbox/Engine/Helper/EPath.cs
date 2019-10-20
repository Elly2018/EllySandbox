using System;
using System.IO;

namespace EllySandbox.Engine.Helper
{
    /// <summary>
    /// 
    /// The work help you find the system path
    /// 
    /// </summary>
    class EPath : HelperBase
    {
        public const string ApplicationName = "Elly Sandbox";
        public const string ApplicationBin = "bin";
        public const string ApplicationData = "data";
        public const string ApplicationLanguage = "language";
        public const string ApplicationLog = "logs";
        public const string ApplicationMods = "mods";
        public const string ApplicationWeb = "web";
        public const string ApplicationSetting = "setting";

        /// <summary>
        /// The place where program run
        /// </summary>
        /// <returns></returns>
        public string _ApplicationDataPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), ApplicationName);
        }


        /// <summary>
        /// The place where put config, map, or mod
        /// </summary>
        /// <returns></returns>
        public string _ApplicationConfigPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ApplicationName);
        }


        /// <summary>
        /// The place where put cache data
        /// </summary>
        /// <returns></returns>
        public string _ApplicationPersistentPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationName);
        }
    }
}
