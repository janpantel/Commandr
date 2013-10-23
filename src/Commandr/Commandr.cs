using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using Commandr.Attributes;
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
        protected IDictionary<string, ICommand> cache;
        
        /// <summary>
        /// Creates a new instance of <see cref="Commandr.Commandr"/>.
        /// </summary>
        /// <param name="commands">The commands to register</param>
        public Commandr(
        	ICollection<ICommand> commands = null, 
        	ICommandSplitter splitter = null,
        	IOutput output = null,
        	IDictionary<string, ICommand> cache = null
        )
        {
        	this.commands = commands ?? new List<ICommand>();
        	this.splitter = splitter ?? new DefaultCommandSplitter();
        	this.output = output ?? new ConsoleOutput();
        	this.cache = cache ?? new Dictionary<string, ICommand>();
        }
        
        public void RegisterCommand(ICommand cmd)
        {
        	this.commands.Add(cmd);
        }
        
        public void ResolveCommand(string cmd)
        {
        	var splitted = this.splitter.SplitCommand(cmd);
        	
        	ICommand command = null;

        	if (this.cache.ContainsKey(splitted.Command))
        	{
        		command = this.cache[splitted.Command];
        	}
        	else
        	{
        		command = 
	        		(from item in this.commands
	        		let type = item.GetType()
	        		let commandAttribute = 
	        			type.GetCustomAttributes(typeof(CommandAttribute), true).FirstOrDefault()
	        		where commandAttribute != null
	        		&& (commandAttribute as CommandAttribute).Command == splitted.Command
	        		select item).FirstOrDefault();
        		
        		this.cache.Add(splitted.Command, command);
        	}
        	
        	if (command == null)
        	{
        		throw new ArgumentException("The command " + splitted.Command + " does not exist");
        	}
        	
        	var message = command.Run(splitted.Arguments);
        	
        	message.ToList().ForEach(x => this.output.Write(x));
        }
    }
}
