using MySqlConnector;
using Titan.API.Exceptions.Base;
using Titan.API.Helpers;

namespace Titan.API.Exceptions.Handlers;

public sealed class MySqlExceptionHandler(Exception exception) : BaseExceptionHandler(exception)
{
    private const string ErrorType = "Persistence Error";
    private const int StatusCode = StatusCodes.Status500InternalServerError;

    public override async Task HandleException(HttpContext context, ILogger? logger = null)
    {
        var databaseException = Error as MySqlException;
        var detailsBuilder = ProblemBuilder.Builder;

        detailsBuilder
            .WithStatusCode(StatusCode)
            .WithTitle(ErrorType)
            .WithInstance(context.Request.Path);

        detailsBuilder.WithDetails(databaseException!.ErrorCode switch
        {
            MySqlErrorCode.UnableToConnectToHost => "Database is not reachable, cannot connect to host.",

            MySqlErrorCode.AccessDenied => "Access denied! Please, ensure your MySQL account has sufficient privileges.",

            _ => $"An unknown error occurred while trying to access the database, error code: {databaseException.ErrorCode}"
        });

        var problemDetails = detailsBuilder
            .Build();

        logger?.LogError("Exception thrown during request (path: {Path}, detail: {Detail})", problemDetails.Instance, problemDetails.Detail);

        await Results.Problem(problemDetails)
            .ExecuteAsync(context);
    }
}

