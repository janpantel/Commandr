using Commandr.Attributes;
using Commandr.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Utils.DefaultCommands
{
    [Command("clear")]
    public class ClearCommand : ICommand
    {
        public IEnumerable<string> Run(IDictionary<string, string> arguments)
        {
            Console.Clear();
            return null;
        }
    }
}
