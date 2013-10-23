using System;

namespace Commandr.Validator
{
	public interface IValidator
	{
		bool Validate(string value);
	}
}
