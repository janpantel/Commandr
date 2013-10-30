using Commandr.Attributes;
using Commandr.Shared;
using Commandr.Utils.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Utils.DefaultCommands
{
    [Command("clear")]
    public class ClearCommand : ICommand
    {
        public IOutput Output { get; set; }

        public void Run(IDictionary<string, string> arguments)
        {
            Console.Clear();
        }
    }
}
