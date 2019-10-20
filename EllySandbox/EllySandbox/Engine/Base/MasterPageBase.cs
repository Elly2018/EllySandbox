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

        public void OnDestroy()
        {

        }

        public void OnExit()
        {
            active = false;
        }

        public void OnLoad()
        {
            
        }

        public void OnPause()
        {
            
        }

        public void OnRenderUpdate()
        {
            
        }

        public void OnStart()
        {
            active = true;
        }

        public void OnUpdate()
        {
            
        }
    }
}
