using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Shared
{
    public interface ICommand
    {
    	IEnumerable<string> Run(IDictionary<string, string> arguments);
    }
}
