using System.Diagnostics;
using System.IO;
using System.Threading;
using EllySandbox.Engine.Base;
using EllySandbox.Engine.Struct;


namespace EllySandbox.Engine.Module
{
    class WebMenu : ModuleBase
    {
        protected override ModuleInfo GetInfo()
        {
            return new ModuleInfo("Web Menu", 0, 0, 1);
        }

        public override void OnLoad()
        {
            base.OnLoad();
            OpenWeb();
        }

        private void OpenWeb()
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(Path.Combine(Directory.GetCurrentDirectory(), "netcoreapp3.0", "EllySandboxWeb.exe"));
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }
    }
}
