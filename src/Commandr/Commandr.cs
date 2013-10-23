using Commandr.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Commandr
{
    public class Commandr
    {
        protected ICollection<ICommand> commands;

        /// <summary>
        /// Creates a new instance of <see cref="Commandr.Commandr"/>.
        /// </summary>
        public Commandr()
        {
        	if (this.commands == null)
        	{
        		commands = new List<ICommand>();
        	}
        }
        
        /// <summary>
        /// Creates a new instance of <see cref="Commandr.Commandr"/>.
        /// </summary>
        /// <param name="commands">The commands to register</param>
        public Commandr(ICollection<ICommand> commands) : this()
        {
        	this.commands = commands;
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
