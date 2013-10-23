using System;

namespace Commandr.Validator
{
	public class Validator
	{
		public static IValidator Integer { get; set; }
		public static IValidator Array { get; set; }
		
		static Validator()
		{
			Validator.Integer = new IntegerValidator();
			Validator.Array = new ArrayValidator();
		}
	}
}
