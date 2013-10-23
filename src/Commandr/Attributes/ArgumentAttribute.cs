using System;

namespace Commandr.Attributes
{
	public class ArgumentAttribute
	{
		public string Name { get; set; }
		
		public ArgumentAttribute(string name)
		{
			this.Name = name;
		}
	}
}
