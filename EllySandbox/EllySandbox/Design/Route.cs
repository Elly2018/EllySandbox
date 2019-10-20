using EllySandbox.Design.Page;
using EllySandbox.Engine.Base;
using EllySandbox.Engine.Struct;

namespace EllySandbox.Design
{
    /// <summary>
    /// Import all the page into collection
    /// </summary>
    class Route : ModuleBase
    {
        private MasterPageBase[] masterPages;

        private MasterPageBase _CurrentPage;
        public MasterPageBase CurrentPage { get { return _CurrentPage; } }

        protected override ModuleInfo GetInfo()
        {
            return new ModuleInfo("Route", 0, 0, 1);
        }

        public Route()
        {
            masterPages = new MasterPageBase[]
            {
                new Intro() // The starter will be place at first index
            };
        }

        public override void OnLoad()
        {
            base.OnLoad();
            masterPages[0].OnLoad();
            _CurrentPage = masterPages[0];
        }
    }
}
