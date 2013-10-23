using Commandr.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commandr.Utils.CommandSplitter
{
	public class DefaultCommandSplitter : ICommandSplitter
	{
		protected static string FRAGMENT_DELIMITER = CommandrConfiguration.COMMAND_FRAGMENT_DELIMITER;
		protected static string ARGUMENT_PREFIX = CommandrConfiguration.ARGUMENT_PREFIX;
		protected static string ARGUMENT_VALUE_PREFIX = CommandrConfiguration.ARGUMENT_VALUE_PREFIX;
		
		public SplittedCommand SplitCommand(string command)
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}
			
			var splittedCommand = new SplittedCommand();
			var splittedString = command.Split(FRAGMENT_DELIMITER.ToCharArray());
			
			var cmd = splittedString.FirstOrDefault();
			
			if (!this.CheckCommand(cmd))
			{
				throw new ArgumentException("Command is not valid!");
			}
			
			splittedCommand.Command = cmd;
			
			splittedCommand.Arguments = this.GetArguments(splittedString.Skip(1).ToList());
			
			return splittedCommand;
		}
		
		protected bool CheckCommand(string command)
		{
			return !string.IsNullOrEmpty(command) 
				&& !command.StartsWith(ARGUMENT_PREFIX)
				&& !command.StartsWith(ARGUMENT_VALUE_PREFIX);
		}
		
		protected IDictionary<string, string> GetArguments(IList<string> args)
		{
			args = args.Select(arg => arg.Replace(ARGUMENT_VALUE_PREFIX, string.Empty)).ToList();
			                   
			var indexes = args.Where(a => a.StartsWith(ARGUMENT_PREFIX)).Select(arg => new { Key = arg, Index = args.IndexOf(arg) });
			
			return 
				(from arg in args.Where(a => a.StartsWith(ARGUMENT_PREFIX))
				let index = args.IndexOf(arg)
				let others = indexes.SkipWhile(a => a.Key != arg).Skip(1)
				let next = others.Any() ? others.First().Index : args.Count
				let val = string.Join(FRAGMENT_DELIMITER, args.Skip(index + 1).Take(next - index - 1).ToArray())
				let cleanedArg = arg.Replace(ARGUMENT_PREFIX, string.Empty)
				select new KeyValuePair<string, string>(cleanedArg, val)).ToDictionary(x => x.Key, x => x.Value);
		}
	}
}
