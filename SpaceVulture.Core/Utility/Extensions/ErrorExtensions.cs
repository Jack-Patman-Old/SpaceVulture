using System;
using SpaceVulture.Core.Errors;

namespace SpaceVulture.Core.Utility.Extensions
{
    public static class ErrorExtensions
    {


        public static string Message(this Error error, Object[] parameters)
        {
            string rawDescription = EnumExtensions.GetDescription(error);
            string message = string.Format(rawDescription, parameters);
            string prefix = error.ErrorCodePrefix();
            return $"{prefix}{message}";

        }

        public static string ErrorCodePrefix(this Error error)
        {
            string errorCode = ErrorCode(error);
            return $"Error Code {errorCode} encountered: ";
        }

        public static string ErrorCode(this Error error)
        {
            int errorCode = (int)error;
            return errorCode.ToString();
        }
    }
}
