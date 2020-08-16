using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using PrismDemo.Core;
using Prism.Commands;
using System;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private MessageSentEvent _messageSentEvent;
        private ObservableCollection<string> _messages = new ObservableCollection<string>();
        private bool _isSubscribed = true;

        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            //set { SetProperty(ref _isSubscribed, value); }
            //Could also do this
            set { SetProperty(ref _isSubscribed, value, ()=>HandleSubscribe(value)); }
        }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _messageSentEvent = _eventAggregator.GetEvent<MessageSentEvent>();

            HandleSubscribe(true);
        }

        private void HandleSubscribe(bool isSubscribe)
        {
            if (_isSubscribed)
                _messageSentEvent.Subscribe(MessageReceived);
            else
                _messageSentEvent.Unsubscribe(MessageReceived);
        }

        private void MessageReceived(string message)
        {
            Messages.Add(message);
        }

    }
}
