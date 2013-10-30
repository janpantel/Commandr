using Commandr.Attributes;
using Commandr.Configuration;
using Commandr.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commandr.Utils.CommandResolver
{
    public class DefaultCommandResolver : ICommandResolver
    {
        protected IDictionary<string, ICommand> cache;
        protected ICollection<ICommand> commands;

        public DefaultCommandResolver(
            ICollection<ICommand> commands = null,
            IDictionary<string, ICommand> cache = null
            )
        {
            this.commands = commands ?? new List<ICommand>();
            this.cache = cache ?? new Dictionary<string, ICommand>();
        }

        public IEnumerable<string> Resolve(CommandSplitter.SplittedCommand cmd)
        {
            ICommand command = null;

            if (this.cache.ContainsKey(cmd.Command))
            {
                command = this.cache[cmd.Command];
            }
            else
            {
                command =
                    (from item in this.commands
                     let type = item.GetType()
                     let commandAttribute =
                         type.GetCustomAttributes(typeof(CommandAttribute), true).FirstOrDefault()
                     where commandAttribute != null
                     && (commandAttribute as CommandAttribute).Command == cmd.Command
                     select item).FirstOrDefault();

                this.cache.Add(cmd.Command, command);
            }

            if (command == null)
            {
                var failMessage = CommandrConfiguration.COMMAND_NOT_FOUND_MESSAGE.Replace("%cmd%", "\"" + cmd + "\"");
                return new List<string> { failMessage };
            }

            return command.Run(cmd.Arguments);
        }

        public void RegisterCommand(ICommand cmd)
        {
            this.commands.Add(cmd);
        }
    }
}
