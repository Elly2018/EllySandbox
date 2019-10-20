using System.Reflection;
using EllySandbox.Engine.Base;
using EllySandbox.Engine.Struct;

namespace EllySandbox.Engine.Module
{
    class ModSupport : ModuleBase
    {
        private Assembly[] ThirdPartModules = new Assembly[] { };

        protected override ModuleInfo GetInfo()
        {
            return new ModuleInfo("Mod support", 0, 0, 1);
        }

        /// <summary>
        /// Loading module from folder
        /// </summary>
        public override void OnLoad()
        {
            base.OnLoad();
        }

        public T GetModuleByType<T>() where T : ModuleBase
        {
            for (int i = 0; i < ThirdPartModules.Length; i++)
            {
                for (int j = 0; j < ThirdPartModules[i].GetTypes().Length; j++)
                {
                    if (ThirdPartModules[i].GetTypes()[j].GetType() == typeof(T)) return ThirdPartModules[i].GetTypes()[j].GetType() as T;
                }
            }
            return null;
        }
    }
}
