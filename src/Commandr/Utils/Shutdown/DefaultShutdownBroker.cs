using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Utils.Shutdown
{
    public class DefaultShutdownBroker : IShutdownBroker
    {
        protected ICollection<IShutdownHandler> shutdownHandler;

        public DefaultShutdownBroker(ICollection<IShutdownHandler> handler = null)
        {
            this.shutdownHandler = handler ?? new List<IShutdownHandler>();
        }

        public void RegisterHandler(IShutdownHandler handler)
        {
            this.shutdownHandler.Add(handler);
        }

        public void Shutdown()
        {
            foreach (var handler in this.shutdownHandler)
            {
                if (handler != null)
                {
                    handler.Run();
                }
            }
        }
    }
}
