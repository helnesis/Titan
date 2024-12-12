using Microsoft.AspNetCore.Mvc;
using Titan.API.Exceptions.Base;
using Titan.API.Helpers;

namespace Titan.API.Exceptions.Handlers;

public sealed class DefaultExceptionHandler(Exception exception) : BaseExceptionHandler(exception)
{
    private const string ErrorType = "Unhandled Exception";
    private const int Status = StatusCodes.Status500InternalServerError;

    public override async Task HandleException(HttpContext context, ILogger? logger = null)
    {
        var builder = ProblemBuilder.Builder
            .WithTitle(ErrorType)
            .WithStatusCode(Status)
            .WithDetails("An unhandled exception was throw. Re-try the operation, if its occurs again, reports the error on the project Github.")
            .WithInstance(context.Request.Path)
            .Build();

        await Results.Problem(builder)
            .ExecuteAsync(context);
    }
}

