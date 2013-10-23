using System;

namespace Commandr.Utils.CommandSplitter
{
	public interface ICommandSplitter
	{
		SplittedCommand SplitCommand(string command);
	}
}
