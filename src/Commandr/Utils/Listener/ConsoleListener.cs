using System;

namespace Commandr.Utils.Listener
{
	public class ConsoleListener : IListener
	{
		public string Listen()
		{
			return Console.ReadLine();
		}
	}
}
