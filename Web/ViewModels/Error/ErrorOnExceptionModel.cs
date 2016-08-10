using System;

namespace Web.ViewModels.Error
{
    public class ErrorOnExceptionModel
    {
        public string Action { get; set; }
        public string Controller { get; set; }

        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string Stacktrace { get; set; }

    }
}