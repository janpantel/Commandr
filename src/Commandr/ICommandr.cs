using Commandr.Shared;
using Commandr.Utils.Shutdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr
{
    public interface ICommandr
    {
        void RegisterCommand(ICommand cmd);
        void RegisterShutdownHandler(IShutdownHandler handler);
        void ResolveCommand(string cmd);
        void StartListener(string prefix);
        void StopListener();
    }
}
