using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace PrismDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Basic Navigation Demo";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string viewName)
        {
            if (viewName != null)
            {
                // RequestNavigate without callback
                //_regionManager.RequestNavigate("ContentRegion", viewName);

                // RequestNavigate with callback
                _regionManager.RequestNavigate("ContentRegion", viewName, Callback);

            }
        }

        private void Callback(NavigationResult result)
        {
            // result.Context has Parameters and Uri
            if (result.Error != null)
            {
                // handle error or do something else
            }
        }
    }
}
