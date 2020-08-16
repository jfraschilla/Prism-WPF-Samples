using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private IDialogService _dialogService;

        private string _messageReceived;

        public string MessageReceived
        {
            get { return _messageReceived; }
            set { SetProperty(ref _messageReceived, value); }
        }

        public DelegateCommand ShowDialogCommand { get; private set; }

        public ViewAViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            ShowDialogCommand = new DelegateCommand(ShowDialog);
        }

        private void ShowDialog()
        {
            var p = new DialogParameters();
            p.Add("message", "Hello from ViewAViewModel");
            _dialogService.ShowDialog("MessageDialog", p, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    MessageReceived = r.Parameters.GetValue<string>("myParam");
                }
                else
                {
                    MessageReceived = "Not closed by user";
                }
            });
        }
    }
}
