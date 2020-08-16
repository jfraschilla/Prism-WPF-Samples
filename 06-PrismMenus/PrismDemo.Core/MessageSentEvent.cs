using Prism.Events;

namespace PrismDemo.Core
{
    //You do not need to put your events in a core project unless it 
    //is going to be shared across multiple modules
    public class MessageSentEvent : PubSubEvent<string>
    {
    }
}
