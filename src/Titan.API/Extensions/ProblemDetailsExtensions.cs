using Microsoft.AspNetCore.Mvc;
using Titan.API.Helpers;

namespace Titan.API.Extensions;
internal static class ProblemDetailsExtensions
{
    extension(ProblemDetails)
    {
        internal static ProblemDetailsBuilder Builder => new();
    }
}
