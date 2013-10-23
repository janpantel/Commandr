using System;

namespace Commandr.Attributes
{
	public class CommandAttribute : Attribute
	{
		public string Command { get; set; }
		
		public CommandAttribute(string command)
		{
			this.Command = command;
		}
	}
}
