using Commandr.Utils.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Shared
{
    public interface ICommand
    {
        IOutput Output { get; set; }

    	void Run(IDictionary<string, string> arguments);
    }
}