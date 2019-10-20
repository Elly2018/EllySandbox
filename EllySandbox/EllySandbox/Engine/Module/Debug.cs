using System;
using System.IO;
using EllySandbox.Engine.Base;
using EllySandbox.Engine.Struct;
using System.Collections.Generic;
using EllySandbox.Engine.Helper;
using System.Text;

namespace EllySandbox.Engine.Module
{
    class Debug : ModuleBase
    {
        public enum DebugType
        {
            Log, LogWarming, LogError, LogTypeError
        }

        public static string Filename = "";
        public static string[] Message = new string[] { };

        protected override ModuleInfo GetInfo()
        {
            return new ModuleInfo("Debug", 0, 0, 1);
        }

        public override void OnLoad()
        {
            base.OnLoad();
        }

        public static void Log(string tag, object o, DebugType messageType)
        {
            switch (messageType)
            {
                case DebugType.Log:
                    Log(tag, o, System.ConsoleColor.White);
                    break;
                case DebugType.LogWarming:
                    Log(tag, o, System.ConsoleColor.Yellow);
                    break;
                case DebugType.LogError:
                    Log(tag, o, System.ConsoleColor.Red);
                    break;
                case DebugType.LogTypeError:
                    Log(tag, o, System.ConsoleColor.Magenta);
                    break;
            }
        }
        public static void Log(string tag, object o, System.ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine("[" + tag + "] " + o.ToString());

            List<string> s = new List<string>(Message);
            s.Add("[" + tag + "] " + o.ToString());
            Message = s.ToArray();
            FileUpdate();
        }
        /// <summary>
        /// writing message on end of target logging text file
        /// </summary>
        /// <param name="o"></param>
        private static void FileUpdate()
        {
            EPath epath = HelperFactory.GetModuleByType<EPath>();

            if (File.Exists(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, Filename)))
                File.Delete(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, Filename));

            File.WriteAllLines(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, Filename), Message);
            File.WriteAllLines(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, "Lastest log.txt"), Message);
        }
    }
}
