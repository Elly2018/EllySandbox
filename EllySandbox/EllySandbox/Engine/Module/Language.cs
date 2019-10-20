using System.Collections.Generic;
using System.IO;
using EllySandbox.Engine.Base;
using EllySandbox.Engine.Helper;
using EllySandbox.Engine.Struct;
using Newtonsoft.Json;

namespace EllySandbox.Engine.Module
{
    /// <summary>
    /// 
    /// Handle multi language, the data will store in "document/data/language"
    /// 
    /// </summary>
    class Language : ModuleBase
    {
        private LanguageStruct[] languageStructs = new LanguageStruct[] { };
        private EPath epath;

        protected override ModuleInfo GetInfo()
        {
            return new ModuleInfo("Language", 0, 0, 1);
        }

        /// <summary>
        /// Reading data from "document/data/language"
        /// And if there is no data in the folder, create a empty one.
        /// </summary>
        public override void OnLoad()
        {
            base.OnLoad();

            epath = HelperFactory.GetModuleByType<EPath>();
            if (epath == null)
            {
                Debug.Log(GetInfo().ModuleName, "Cannot get EPath", Debug.DebugType.LogError);
                return;
            }

            ReadAppLanguage();
        }
        private void ReadAppLanguage()
        {
            DetectLanFolderSize();
            if(StartReadingLan().Length == 0)
            {
                DetectLanFolderSize();
                languageStructs = StartReadingLan();
            }
            else
            {
                languageStructs = StartReadingLan();
            }
        }
        private void DetectLanFolderSize()
        {
            string[] langaugeDataPaths = Directory.GetFiles(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLanguage));

            if (langaugeDataPaths.Length == 0)
            {
                Debug.Log(GetInfo().ModuleName, "No language detect, create a empty default one", Debug.DebugType.Log);
                File.WriteAllText(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLanguage, "DefaultLan.json"),
                    JsonConvert.SerializeObject(
                        new LanguageStruct("DefaultTag", new LanguageCategory[] {
                            new LanguageCategory( "Default category",
                                new LanguageLabel[] {
                                    new LanguageLabel("Default ID", "Test")
                                })}), Formatting.Indented));
                return;
            }
        }
        private LanguageStruct[] StartReadingLan()
        {
            string[] langaugeDataPaths = Directory.GetFiles(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLanguage));
            List<LanguageStruct> result = new List<LanguageStruct>();
            foreach (string p in langaugeDataPaths)
            {
                LanguageStruct local = new LanguageStruct();
                try
                {
                    local = JsonConvert.DeserializeObject<LanguageStruct>(File.ReadAllText(p));
                    result.Add(local);
                }
                catch (IOException)
                {
                    File.Delete(p);
                }
            }
            return result.ToArray();
        }

        public override void OnStart()
        {
            base.OnStart();
            for(int i = 0; i < languageStructs.Length; i++)
            {
                Debug.Log(GetInfo().ModuleName,
                    "Import \"" + languageStructs[i].LanguageTag + "\", " + " Total labels: " + CheckContainLabel(languageStructs[i]),
                    Debug.DebugType.Log);
            }
        }
        private int CheckContainLabel(LanguageStruct container)
        {
            int result = 0;
            for(int i = 0; i < container.Categories.Length; i++)
            {
                for(int j = 0; j < container.Categories[i].Labels.Length; j++)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
