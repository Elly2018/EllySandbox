using EllySandbox.Engine.Interface;

namespace EllySandbox.Engine.Base
{
    /// <summary>
    /// 
    /// Work contain all the page information and scene information
    /// 
    /// </summary>
    class MasterPageBase : IModuleLifeCycle
    {
        private bool active;

        public bool Active()
        {
            return active;
        }

        public virtual void OnDestroy()
        {

        }

        public virtual void OnExit()
        {
            active = false;
        }

        public virtual void OnLoad()
        {
            
        }

        public virtual void OnPause()
        {
            
        }

        public virtual void OnRenderUpdate()
        {
            
        }

        public virtual void OnStart()
        {
            active = true;
        }

        public virtual void OnUpdate()
        {
            
        }
    }
}
