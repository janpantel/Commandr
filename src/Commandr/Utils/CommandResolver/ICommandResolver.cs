using Commandr.Shared;
using Commandr.Utils.CommandSplitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Utils.CommandResolver
{
    public interface ICommandResolver
    {
        IEnumerable<string> Resolve(SplittedCommand cmd);
        void RegisterCommand(ICommand cmd);
    }
}
