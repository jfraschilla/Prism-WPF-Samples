using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using PrismDemo.Core;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        private ObservableCollection<string> _messages = new ObservableCollection<string>();
        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
        }

        private void MessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
