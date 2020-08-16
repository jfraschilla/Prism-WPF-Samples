using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismDemo.Core;

namespace ModuleA.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        private string _message = "Message to Send";
        private readonly IEventAggregator _eventAggregator;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _eventAggregator.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
