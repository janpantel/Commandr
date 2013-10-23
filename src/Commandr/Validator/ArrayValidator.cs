using System;
using Commandr.Configuration;

namespace Commandr.Validator
{
	public class ArrayValidator : IValidator
	{
		public static string ARRAY_PREFIX = CommandrConfiguration.ARRAY_PREFIX;
		public static string ARRAY_SUFFIX = CommandrConfiguration.ARRAY_SUFFIX;
		
		public bool Validate(string value)
		{
			return 
				value.StartsWith(ARRAY_PREFIX)
				&& value.EndsWith(ARRAY_SUFFIX);
		}
	}
}
