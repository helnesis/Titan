using Microsoft.AspNetCore.Mvc;

namespace Titan.API.Exceptions.Base;

public abstract class BaseExceptionHandler(Exception exception) : IExceptionHandler
{
    protected readonly Exception Error = exception;
    public abstract Task HandleException(HttpContext context, ILogger? logger = null);
}

