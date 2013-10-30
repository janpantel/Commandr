using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using Commandr.Attributes;
using Commandr.Shared;
using Commandr.Utils.CommandSplitter;
using Commandr.Utils.Listener;
using Commandr.Utils.Output;
using Commandr.Utils.DefaultCommands;
using Commandr.Configuration;
using Commandr.Utils.Shutdown;
using Commandr.Utils.CommandResolver;

namespace Commandr
{
    public class Commandr : ICommandr
    {
        protected ICommandSplitter splitter;
        protected IOutput output;
        protected IListener listener;
        protected IShutdownBroker shutdownBroker;
        protected ICommandResolver resolver;
        
        protected bool shouldExit;
        
        /// <summary>
        /// Creates a new instance of <see cref="Commandr.Commandr"/>.
        /// </summary>
        /// <param name="commands">The commands to register</param>
        public Commandr(
        	ICommandSplitter splitter = null,
        	IOutput output = null,
        	IListener listener = null,
            IShutdownBroker shutdownBroker = null,
            ICommandResolver resolver = null
        )
        {
        	this.splitter = splitter ?? new DefaultCommandSplitter();
        	this.output = output ?? new ConsoleOutput();
        	this.listener = listener ?? new ConsoleListener();
            this.shutdownBroker = shutdownBroker ?? new DefaultShutdownBroker();
            this.resolver = new DefaultCommandResolver();

        	this.shouldExit = false;

            this.RegisterDefaultCommands();
        }
        
        public void RegisterCommand(ICommand cmd)
        {
            this.resolver.RegisterCommand(cmd);
        }

        public void RegisterShutdownHandler(IShutdownHandler handler)
        {
            this.shutdownBroker.RegisterHandler(handler);
        }

        public void ResolveCommand(string cmd)
        {
        	var splitted = this.splitter.SplitCommand(cmd);

            var message = this.resolver.Resolve(splitted);

            if (message != null)
            {
                message.ToList().ForEach(x => this.output.Write(x));
            }
        }

        public void StartListener(string prefix)
        {
        	while (!this.shouldExit)
        	{
        		this.ResolveCommand(this.listener.Listen(prefix));
        	}
            this.shutdownBroker.Shutdown();
        }
        
        public void StopListener()
        {
        	this.shouldExit = true;
        }

        protected void RegisterDefaultCommands()
        {
            this.RegisterCommand(new ClearCommand());
            this.RegisterCommand(new ExitCommand(this));
        }
    }
}
