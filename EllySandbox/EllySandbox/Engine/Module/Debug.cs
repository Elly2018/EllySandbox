using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EllySandbox.Engine.Base;
using EllySandbox.Engine.Struct;
using EllySandbox.Engine.Helper;

namespace EllySandbox.Engine.Module
{
    /// <summary>
    /// 
    /// There are two file output:
    /// -Lastest: file is single forward output, and when controller clean the log or delete line, it will effect on the file.
    /// -Datetime: file is store all the information and log histroy. and refresh everytime it update.
    /// 
    /// </summary>
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
            FileUpdate("[" + tag + "] " + o.ToString());
        }
        /// <summary>
        /// writing message on end of target logging text file
        /// </summary>
        /// <param name="o"></param>
        private static void FileUpdate(string newLine)
        {
            EPath epath = HelperFactory.GetModuleByType<EPath>();

            /* Lastest */
            string[] currentLastest = File.ReadAllLines(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, "Lastest log.txt"));
            List<string> _currentLastest = new List<string>(currentLastest);
            _currentLastest.Add(newLine);
            File.WriteAllLines(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, "Lastest log.txt"), _currentLastest.ToArray());

            /* Datetime */
            if (File.Exists(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, Filename)))
                File.Delete(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, Filename));
            File.WriteAllLines(Path.Combine(epath._ApplicationConfigPath(), EPath.ApplicationData, EPath.ApplicationLog, Filename), Message);


        }
    }
}
