using System;

namespace Commandr.Utils.Listener
{
	public class ConsoleListener : IListener
	{
		public string Listen(string prefix)
		{
            Console.Write(prefix);
			return Console.ReadLine();
		}
	}
}
