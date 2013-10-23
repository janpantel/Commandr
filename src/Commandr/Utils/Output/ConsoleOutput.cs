
using System;

namespace Commandr.Utils.Output
{
	/// <summary>
	/// Description of ConsoleOutput.
	/// </summary>
	public class ConsoleOutput : IOutput
	{
		public void Write(string message)
		{
			Console.WriteLine(message);
		}
	}
}
