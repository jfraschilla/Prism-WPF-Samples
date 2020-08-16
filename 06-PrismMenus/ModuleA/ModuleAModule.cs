﻿using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("MessageInputRegion", typeof(MessageView));
            _regionManager.RegisterViewWithRegion("MenuRegion", typeof(MenuItems));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}