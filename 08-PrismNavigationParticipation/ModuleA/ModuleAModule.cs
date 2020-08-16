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
            
            //when you use a custom name in you registration, there currently is an issue
            //depending on the container you are using that it won't find the custom name
            //when using the IsNavigationTarget.  Apparently Prism is not handling that when
            //using DryIoc.  In Unity it works fine.

            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();

        }
    }
}