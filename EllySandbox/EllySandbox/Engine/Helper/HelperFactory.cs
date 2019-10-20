using EllySandbox.Engine.Module;

namespace EllySandbox.Engine.Helper
{
    class HelperFactory
    {
        private static HelperBase[] m_HelperBase = new HelperBase[] { };
        public static HelperBase[] _HelperBase { get { return m_HelperBase; } }

        public static void Initialize()
        {
            m_HelperBase = new HelperBase[]
            {
                new EPath()
            };
        }

        public static T GetModuleByType<T>() where T : HelperBase
        {
            for (int i = 0; i < m_HelperBase.Length; i++)
            {
                /* Buildin module search */
                if (typeof(T) == m_HelperBase[i].GetType()) return m_HelperBase[i] as T;
            }
            return null;
        }
    }
}
