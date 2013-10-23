using System;

namespace Commandr.Validator
{
	public class ArrayValidator : IValidator
	{
		public const char ARRAY_PREFIX = '[';
		public const char ARRAY_SUFFIX = ']';
		
		public bool Validate(string value)
		{
			return 
				value.StartsWith(ARRAY_PREFIX)
				&& value.EndsWith(ARRAY_SUFFIX);
		}
	}
}
