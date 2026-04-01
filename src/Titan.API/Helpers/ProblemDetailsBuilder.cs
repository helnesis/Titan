using Microsoft.AspNetCore.Mvc;

namespace Titan.API.Helpers
{
    internal sealed class ProblemDetailsBuilder
    {
        private int _status;
        
        private string? _title;
        
        private string? _details;
        
        private string? _instance;
        public ProblemDetails Build()
            => new()
            {
                Status = _status,
                Title = _title,
                Detail = _details,
                Instance = _instance
            };

        public ProblemDetailsBuilder WithStatusCode(int statusCode)
        {
            if (statusCode is < 400 or > 599)
                _status = StatusCodes.Status500InternalServerError;

            _status = statusCode;
            return this;
        }

        public ProblemDetailsBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public ProblemDetailsBuilder WithDetails(string details)
        {
             _details = details;
            return this;
        }
        public ProblemDetailsBuilder WithInstance(string instance)
        {
            _instance = instance;
            return this;
        }

    }


}
