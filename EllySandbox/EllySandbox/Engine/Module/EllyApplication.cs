using System.IO;
using Newtonsoft.Json;
using EllySandbox.Engine.Base;
using EllySandbox.Engine.Helper;
using EllySandbox.Engine.Struct;

namespace EllySandbox.Engine.Module
{
    /// <summary>
    /// 
    /// Game root
    /// 
    /// - Document 
    ///   - Elly Sandbox
    ///     - bin (model and polygon)
    ///     - data (language and json data)
    ///       - language
    ///     - mods (third part module)
    ///     - setting (application setting)
    /// 
    /// </summary>
    class EllyApplication : ModuleBase
    {
        private ApplicationInfo Appinfo;
        private EPath epath;

        protected override ModuleInfo GetInfo()
        {
            return new ModuleInfo("Elly Application", 0, 0, 1);
        }

        /// <summary>
        /// Check the system root folder in documents
        /// </summary>
        public EllyApplication()
        {
            epath = HelperFactory.GetModuleByType<EPath>();
            if (epath == null)
            {
                Debug.Log(GetInfo().ModuleName, "Cannot get EPath", Debug.DebugType.LogError);
                return;
            }

            InitializeFolder();
            ReadAppinfo();
        }

        public override void OnLoad()
        {
            base.OnLoad();
        }
        private void InitializeFolder()
        {
            CheckExistss(new string[] {
                /* document/Elly Sandbox/ */
                epath._ApplicationConfigPath(),
                /* document/Elly Sandbox/bin */
                Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationBin),
                /* document/Elly Sandbox/data */
                Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData),
                /* document/Elly Sandbox/data/language */
                Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLanguage),
                /* document/Elly Sandbox/data/logs */
                Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog),
                /* document/Elly Sandbox/mods */
                Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationMods),
                /* document/Elly Sandbox/web */
                Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationWeb),
                /* document/Elly Sandbox/setting */
                Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationSetting)
            });
        }
        private void CheckExistss(string[] paths)
        {
            for(int i = 0; i < paths.Length; i++)
            {
                CheckExist(paths[i]);
            }
        }
        private void CheckExist(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        private void ReadAppinfo()
        {
            if (!File.Exists(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationSetting, "Appinfo.json")))
                File.WriteAllText(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationSetting, "Appinfo.json"),
                    JsonConvert.SerializeObject(new ApplicationInfo(false, true), Formatting.Indented));

            try
            {
                Appinfo = JsonConvert.DeserializeObject<ApplicationInfo>(File.ReadAllText(Path.Combine(epath._ApplicationConfigPath(), "setting", "Appinfo.json")));
            }
            catch (IOException)
            {
                if (File.Exists(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationSetting, "Appinfo.json")))
                    File.Delete(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationSetting, "Appinfo.json"));
                File.WriteAllText(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationSetting, "Appinfo.json"),
                    JsonConvert.SerializeObject(new ApplicationInfo(false, true), Formatting.Indented));
                Appinfo = JsonConvert.DeserializeObject<ApplicationInfo>(File.ReadAllText(Path.Combine(epath._ApplicationConfigPath(), "setting", "Appinfo.json")));
            }
        }

        public override void OnStart()
        {
            base.OnStart();
            OutputSetting();
        }
        private void OutputSetting()
        {
            Debug.Log(GetInfo().ModuleName, Appinfo, Debug.DebugType.Log);
        }
    }
}
