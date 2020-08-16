using Prism.Services.Dialogs;
using System;


//Notice that I changed the namespace to the Prism namespace instead of the project namespace
namespace Prism.Services.Dialogs
{
    public static class IDialogServiceExtensions
    {
        public static void ShowMessageDialog(this IDialogService dialogService, string message, Action<IDialogResult> callback)
        {
            var p = new DialogParameters();
            p.Add("message", message);
            dialogService.ShowDialog("MessageDialog", p, callback);

        }
    }
}
