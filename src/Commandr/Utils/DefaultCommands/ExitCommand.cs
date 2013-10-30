using Commandr.Attributes;
using Commandr.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Utils.DefaultCommands
{
    [Command("exit")]
    public class ExitCommand : ICommand
    {
        protected Commandr instance;

        public ExitCommand(Commandr instance)
        {
            this.instance = instance;
        }

        public IEnumerable<string> Run(IDictionary<string, string> arguments)
        {
            this.instance.StopListener();
            return null;
        }
    }
}
