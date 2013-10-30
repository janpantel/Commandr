using Commandr.Attributes;
using Commandr.Shared;
using Commandr.Utils.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Utils.DefaultCommands
{
    [Command("exit")]
    public class ExitCommand : ICommand
    {
        public IOutput Output { get; set; }
        protected Commandr instance;

        public ExitCommand(Commandr instance)
        {
            this.instance = instance;
        }

        public void Run(IDictionary<string, string> arguments)
        {
            this.instance.StopListener();
        }
    }
}
