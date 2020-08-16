using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismDemo.ViewAModule.Views;

namespace PrismDemo.ViewAModule
{
    public class ViewAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ViewAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate("ContentRegion", "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}