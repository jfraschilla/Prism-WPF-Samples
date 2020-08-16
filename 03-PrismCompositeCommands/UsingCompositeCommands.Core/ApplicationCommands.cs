using Prism.Commands;

namespace UsingCompositeCommands.Core
{
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SaveAllCommand { get; } = new CompositeCommand();

    }
}
