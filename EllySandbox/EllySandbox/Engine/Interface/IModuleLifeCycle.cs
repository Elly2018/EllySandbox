namespace EllySandbox.Engine.Interface
{
    /// <summary>
    /// 
    /// Every module has its life cycle, user can override the method
    /// 
    /// </summary>
    public interface IModuleLifeCycle
    {
        /// <summary>
        /// When module load on initialization
        /// </summary>
        void OnLoad();

        /// <summary>
        /// When program start active
        /// </summary>
        void OnStart();

        /// <summary>
        /// After start method, called this method every update
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// After start method, called this method every render update
        /// </summary>
        void OnRenderUpdate();

        /// <summary>
        /// When receive pause event
        /// </summary>
        void OnPause();

        /// <summary>
        /// release the memory
        /// </summary>
        void OnExit();

        /// <summary>
        /// Delete the module itself
        /// </summary>
        void OnDestroy();

        /// <summary>
        /// Check if the module is active
        /// </summary>
        /// <returns></returns>
        bool Active();
    }
}
