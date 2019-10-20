using EllySandbox.Design;
using EllySandbox.Engine.Base;

namespace EllySandbox.Engine.Module
{
    /// <summary>
    /// 
    /// The module factory handle the module instnace
    /// You won't need to create a instance in code 
    /// This handle the initialize work for you
    /// 
    /// </summary>
    class ModuleFactory
    {
        private static ModuleBase[] m_BuildinModule = new ModuleBase[] { };
        public static ModuleBase[] _BuildinModule { get { return m_BuildinModule; } }

        /// <summary>
        /// Initialize the factory
        /// Create instance for every system module
        /// </summary>
        public static void Initialize()
        {
            m_BuildinModule = new ModuleBase[]
            {
                new EllyApplication(), // Application must be first, for initialize the root folder struct
                new Debug(),
                new WebMenu(),
                new ModSupport(),
                new Language(),
                new Route(),
            };
        }
        public static T GetModuleByType<T>() where T : ModuleBase
        {
            for(int i = 0; i < m_BuildinModule.Length; i++)
            {
                /* Buildin module search */
                if (typeof(T) == m_BuildinModule[i].GetType()) return m_BuildinModule[i] as T;

                /* Third part module search */
                if(m_BuildinModule[i].GetType() == typeof(ModSupport))
                {
                    ModSupport modsupport = (ModSupport)m_BuildinModule[i];
                    T t = modsupport.GetModuleByType<T>();
                    if (t != null) return t;
                }
            }
            return null;
        }

        public static void Module_Load(object sender, System.EventArgs e)
        {
            for(int i = 0; i < m_BuildinModule.Length; i++)
            {
                m_BuildinModule[i].OnLoad();
            }
        }
        public static void Module_Start(object sender, System.EventArgs e)
        {
            for (int i = 0; i < m_BuildinModule.Length; i++)
            {
                m_BuildinModule[i].OnStart();
            }
        }
        public static void Module_Update(object sender, System.EventArgs e)
        {
            for (int i = 0; i < m_BuildinModule.Length; i++)
            {
                if(m_BuildinModule[i].Active())
                    m_BuildinModule[i].OnUpdate();
            }
        }
        public static void Module_Render(object sender, System.EventArgs e)
        {
            for (int i = 0; i < m_BuildinModule.Length; i++)
            {
                if (m_BuildinModule[i].Active())
                    m_BuildinModule[i].OnUpdate();
            }
        }
        public static void Module_Exit(object sender, System.EventArgs e)
        {
            for (int i = 0; i < m_BuildinModule.Length; i++)
            {
                m_BuildinModule[i].OnExit();
            }
        }
        public static void Module_Destroy(object sender, System.EventArgs e)
        {
            for (int i = 0; i < m_BuildinModule.Length; i++)
            {
                m_BuildinModule[i].OnDestroy();
            }
        }
    }
}
