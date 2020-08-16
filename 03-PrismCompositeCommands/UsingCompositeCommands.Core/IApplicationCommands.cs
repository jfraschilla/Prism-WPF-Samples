using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsingCompositeCommands.Core
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveAllCommand { get; }
    }
}
