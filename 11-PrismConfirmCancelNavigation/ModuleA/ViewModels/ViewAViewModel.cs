using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, IConfirmNavigationRequest
    {
        private string _text = "ViewA";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public ViewAViewModel()
        {

        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            //Demo code only, use DialogService instead of MessageBox in a ViewModel in production code
            if (MessageBox.Show("Do you want to navigation?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                result = false;
            }
            continuationCallback(result);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
