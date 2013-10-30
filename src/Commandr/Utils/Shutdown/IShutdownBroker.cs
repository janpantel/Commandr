using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Utils.Shutdown
{
    public interface IShutdownBroker
    {
        void RegisterHandler(IShutdownHandler handler);
        void Shutdown();
    }
}
