using Commandr.Validator;
using System;

namespace Commandr.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ArgumentAttribute : Attribute
	{
        public bool IsRequired { get; set; }
		public string Name { get; set; }
        public IValidator Validator { get; set; }

		public ArgumentAttribute(string name, bool required = true)
		{
			this.Name = name;
            this.IsRequired = required;
		}
	}
}
