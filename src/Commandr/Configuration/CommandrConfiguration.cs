using System;

namespace Commandr.Configuration
{
	public static class CommandrConfiguration
	{
		public static string COMMAND_FRAGMENT_DELIMITER = " ";
		public static string ARGUMENT_PREFIX = "-";
		public static string ARGUMENT_VALUE_PREFIX = "\"";
		public static string ARRAY_PREFIX = "[";
		public static string ARRAY_SUFFIX = "]";
        public static string COMMAND_NOT_FOUND_MESSAGE = "The command %cmd% does not exist";
	}
}
