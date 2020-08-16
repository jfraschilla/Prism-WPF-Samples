using Prism.Ioc;
using Prism.Modularity;
using PrismDemo.Dialogs.Dialogs;

namespace PrismDemo.Dialogs
{
    public class DialogsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>();
        }
    }
}