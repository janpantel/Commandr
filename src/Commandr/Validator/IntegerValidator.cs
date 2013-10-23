using System;
using System.Globalization;

namespace Commandr.Validator
{
	public class IntegerValidator : IValidator
	{
		public bool Validate(string value)
		{
			int o;
			return int.TryParse(value, NumberStyles.Integer, null, out o);
		}
	}
}
