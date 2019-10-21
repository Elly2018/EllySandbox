using EllySandbox.Engine.Interface;
using EllySandbox.Engine.Module;
using EllySandbox.Engine.Struct;

namespace EllySandbox.Engine.Base
{
    /// <summary>
    /// The base class of module
    /// </summary>
    abstract class ModuleBase : IModuleLifeCycle
    {
        private bool ModuleActive = false;

        protected abstract ModuleInfo GetInfo();

        public virtual void OnLoad() { Debug.Log("Initialize", GetInfo().ToString(), Debug.DebugType.Log); }
        public virtual void OnStart() { ModuleActive = true; }
        public virtual void OnUpdate() { }
        public virtual void OnRenderUpdate() { }
        public virtual void OnPause() { }
        public virtual void OnExit() { ModuleActive = false; }
        public virtual void OnDestroy() { }
        public bool Active() { return ModuleActive; }
    }
}
