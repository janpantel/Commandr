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
        protected IEnumerable<_Type> commands;

        /// <summary>
        /// Creates a new instance of <see cref="Commandr.Commandr"/> with the commands from the calling assembly.
        /// </summary>
        public Commandr() : this(new List<_Assembly>() { Assembly.GetCallingAssembly() })
        {
            
        }

        /// <summary>
        /// Creates a new instance of <see cref="Commandr.Commandr"/> with the commands from the given
        /// assemblies.
        /// If
        /// </summary>
        /// <param name="assemblies">A collection of assemblies from where Commandr should load the command classes.</param>
        public Commandr(IEnumerable<_Assembly> assemblies)
        {
            this.commands = 
                //Select every type from the assemblies...
                assemblies.SelectMany(a => a.GetTypes()
                    //..that implements ICommand.
                    .Where(t => t.GetInterfaces()
                        .Any(i => i.Equals(typeof(ICommand)))));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Commandr.Commandr"/> with the given commands.
        /// </summary>
        /// <param name="commands">A collection of the types of the command classes that should be registered.</param>
        public Commandr(IEnumerable<_Type> commands)
        {
            this.commands = commands;
        }
        
        public void ResolveCommand(string cmd)
        {
			        
        }
    }
}
