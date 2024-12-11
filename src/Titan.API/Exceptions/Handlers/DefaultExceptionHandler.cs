using Titan.API.Exceptions.Base;

namespace Titan.API.Exceptions.Handlers
{
    public sealed class DefaultExceptionHandler(Exception exception) : BaseExceptionHandler(exception)
    {
        public override Task HandleException(HttpContext context, ILogger? logger = null)
        {            
            throw new NotImplementedException();
        }
    }
}
