using System;
using System.Collections.Generic;

namespace Commandr.Utils.CommandSplitter
{
	/// <summary>
	/// Description of SplittedCommand.
	/// </summary>
	public class SplittedCommand
	{
		public string Command { get; set; }
		public IDictionary<string, string> Arguments { get; set; }
	}
}
