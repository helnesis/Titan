using Microsoft.AspNetCore.Mvc;

namespace Titan.API.Exceptions.Base;

public interface IExceptionHandler
{
    /// <summary>
    /// Handle the exception, log it and send a <see cref="ProblemDetails"/>
    /// </summary>
    /// <returns>Details</returns>
    Task HandleException(HttpContext context, ILogger? logger = null);
}

