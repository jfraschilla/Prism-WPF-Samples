using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.ViewAModule.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        private string _text;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string Text
        {
            get { return _text; }
            private set { SetProperty(ref _text, value); } 
        }

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
            DoSomething().Await(CompletedHandler, HandleError);
        }

        private void HandleError(Exception ex)
        {
            Text = ex.Message;
        }

        private void CompletedHandler()
        {
            Text = "It Completed!";
        }

        private async Task DoSomething()
        {
            await Task.Delay(5000);
            Text = "Change in task.";
            //throw new Exception("thrown in task");
        }

    }
}
