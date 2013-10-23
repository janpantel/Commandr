using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using Commandr.Shared;
using Commandr.Utils.CommandSplitter;
using Commandr.Utils.Output;

namespace Commandr
{
    public class Commandr
    {
        protected ICollection<ICommand> commands;
        protected ICommandSplitter splitter;
        protected IOutput output;
        
        /// <summary>
        /// Creates a new instance of <see cref="Commandr.Commandr"/>.
        /// </summary>
        /// <param name="commands">The commands to register</param>
        public Commandr(
        	ICollection<ICommand> commands = null, 
        	ICommandSplitter splitter = null,
        	IOutput output = null
        )
        {
        	this.commands = commands ?? new List<ICommand>();
        	this.splitter = splitter ?? new DefaultCommandSplitter();
        	this.output = output ?? new ConsoleOutput();
        }
        
        public void RegisterCommand(ICommand cmd)
        {
        	this.commands.Add(cmd);
        }
        
        public void ResolveCommand(string cmd)
        {
        	        	
        }
    }
}
