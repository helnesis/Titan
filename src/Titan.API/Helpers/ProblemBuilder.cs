using Microsoft.AspNetCore.Mvc;

namespace Titan.API
{
    internal sealed class ProblemBuilder
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

        public ProblemBuilder WithStatusCode(int statusCode)
        {
            if (!(statusCode >= 400 && statusCode <= 599))
                _status = StatusCodes.Status500InternalServerError;

            _status = statusCode;
            return this;
        }

        public ProblemBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public ProblemBuilder WithDetails(string details)
        {
            _details = details;
            return this;
        }

        public ProblemBuilder WithInstance(string instance)
        {
            _instance = instance;
            return this;
        }
    }


}
