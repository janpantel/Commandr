using System;

namespace Commandr.Attributes
{
	public class ArgumentAttribute : Attribute
	{
		public string Name { get; set; }
		
		public ArgumentAttribute(string name)
		{
			this.Name = name;
		}
	}
}
