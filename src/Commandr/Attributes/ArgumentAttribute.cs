using System;

namespace Commandr.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ArgumentAttribute : Attribute
	{
		public string Name { get; set; }
		
		public ArgumentAttribute(string name)
		{
			this.Name = name;
		}
	}
}
