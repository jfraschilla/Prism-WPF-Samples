using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // By default, the ViewName is the ViewType.  
            // You can explicity define it by passing the name as a parameter
            // When navigating you also need to use the CustomName
            //containerRegistry.RegisterForNavigation<ViewA>("CustomName");

            containerRegistry.RegisterForNavigation<ViewA>("CustomName");
            containerRegistry.RegisterForNavigation<ViewB>();

        }
    }
}